#region Using Directives

using System;
using System.Linq;
using System.Text;
using MusicStore.Infrastructure.Authentication;
using MusicStore.Infrastructure.Encryption;
using MusicStore.Infrastructure.Querying;
using MusicStore.Infrastructure.UnitOfWork;
using MusicStore.Model.Customers;
using MusicStore.Model.Ecommerce;
using MusicStore.Services.Interfaces;
using MusicStore.Services.Mapping;
using MusicStore.Services.Messaging.MembershipService;

#endregion

namespace MusicStore.Services.Implementations
{
    public class MembershipService : IMembershipService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEncryptor _encryptor;
        private readonly IMembershipValidator _membershipValidator;
        private readonly IStateRepository _stateRepository;
        private readonly IUnitOfWork _uow;
        private readonly IUserLoginRepository _userLoginRepository;

        public MembershipService(ICustomerRepository customerRepository, IEncryptor encryptor, IMembershipValidator membershipValidator,
            IStateRepository stateRepository, IUnitOfWork uow, IUserLoginRepository userLoginRepository)
        {
            _customerRepository = customerRepository;
            _encryptor = encryptor;
            _membershipValidator = membershipValidator;
            _stateRepository = stateRepository;
            _uow = uow;
            _userLoginRepository = userLoginRepository;
        }

        public GetAllStatesResponse GetAllStates()
        {
            var response = new GetAllStatesResponse();

            var states = _stateRepository.FindAll();

            response.States = states.ConvertToStateViews();

            return response;
        }

        public LoginUserResponse LoginUser(LoginUserRequest request)
        {
            var response = new LoginUserResponse { HasIssues = false, ErrorMessage = string.Empty };

            var customer = _customerRepository.FindByEmailAddress(request.EmailAddress);

            if (customer == null)
            {
                response.HasIssues = true;

                response.ErrorMessage = string.Format("We were unable to locate a user with the email address: {0}. Please try again.",
                    request.EmailAddress);

                return response;
            }

            if (!_encryptor.Validate(request.Password, customer.UserLogin.Password))
            {
                response.HasIssues = true;

                response.ErrorMessage = "Invalid password. Please try again.";

                return response;
            }

            customer.UserLogin.IsAuthenticated = true;

            response.CustomerId = customer.Id.ToString();
            response.UserLogin = customer.UserLogin.ConvertToUserLoginView();
            response.FirstName = customer.FirstName;
            response.LastName = customer.LastName;

            return response;
        }

        public RegisterUserResponse RegisterUserLogin(RegisterUserRequest request)
        {
            var response = new RegisterUserResponse { HasIssues = false, ErrorMessage = string.Empty };

            string errorMessage;

            if (!_membershipValidator.IsValid(request.EmailAddress, request.Password, out errorMessage))
            {
                response.UserLogin.IsAuthenticated = false;

                response.HasIssues = true;

                response.ErrorMessage = errorMessage;

                return response;
            }

            var userLoginQuery = new Query();

            userLoginQuery.Add(Criterion.Create<UserLogin>(u => u.Username, request.EmailAddress, CriteriaOperator.Equal));

            if (_userLoginRepository.Exists(userLoginQuery))
            {
                response.UserLogin = null;

                response.HasIssues = true;

                response.ErrorMessage = "A user with that email address already exists.";

                return response;
            }

            var userLogin = new UserLogin
            {
                Username = request.EmailAddress,
                Password = _encryptor.HashPassword(request.Password, 8)
            };

            ThrowExceptionIfUserLoginIsInvalid(userLogin);

            _userLoginRepository.Add(userLogin);

            // Create the customer
            if (_customerRepository.Exists(request.FirstName, request.LastName, request.EmailAddress))
            {
                throw new CustomerExistsException(string.Format("Customer already exists: {0} ,{1} ,{2}.", request.FirstName,
                    request.LastName, request.EmailAddress));
            }

            var customer = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailAddress = request.EmailAddress,
                UserLogin = userLogin
            };

            ThrowExceptionIfCustomerIsInvalid(customer);

            _customerRepository.Save(customer);

            _uow.Commit();

            userLogin.IsAuthenticated = true;

            response.CustomerId = customer.Id;
            response.FirstName = customer.FirstName;
            response.LastName = customer.LastName;

            response.UserLogin = userLogin.ConvertToUserLoginView();

            return response;
        }

        private static void ThrowExceptionIfUserLoginIsInvalid(UserLogin userLogin)
        {
            if (!userLogin.GetBrokenRules().Any()) { return; }

            var brokenRules = new StringBuilder();

            brokenRules.AppendLine("There were problems saving the user login:");

            foreach (var businessRule in userLogin.GetBrokenRules())
            {
                brokenRules.AppendLine(businessRule.Rule);
            }

            throw new ApplicationException(brokenRules.ToString());
        }

        private static void ThrowExceptionIfCustomerIsInvalid(Customer customer)
        {
            if (!customer.GetBrokenRules().Any()) { return; }

            var brokenRules = new StringBuilder();

            brokenRules.AppendLine("There were problems saving the customer:");

            foreach (var businessRule in customer.GetBrokenRules())
            {
                brokenRules.AppendLine(businessRule.Rule);
            }

            throw new ApplicationException(brokenRules.ToString());
        }
    }
}
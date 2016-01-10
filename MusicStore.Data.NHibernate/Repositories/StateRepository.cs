﻿#region Using Directives

using System.Collections.Generic;
using MusicStore.Model.Customers;

#endregion

namespace MusicStore.Data.NHibernate.Repositories
{
    public class StateRepository : IStateRepository
    {
        public IEnumerable<State> FindAll()
        {
            var states = new List<State>
            {
                new State { Name = "Alabama", Abbr = "AL" },
                new State { Name = "Alaska", Abbr = "AK" },
                new State { Name = "Arizona", Abbr = "AZ" },
                new State { Name = "Arkansas", Abbr = "AR" },
                new State { Name = "California", Abbr = "CA" },
                new State { Name = "Colorado", Abbr = "CO" },
                new State { Name = "Connecticut", Abbr = "CT" },
                new State { Name = "District of Columbia", Abbr = "DC" },
                new State { Name = "Delaware", Abbr = "DE" },
                new State { Name = "Florida", Abbr = "FL" },
                new State { Name = "Georgia", Abbr = "GA" },
                new State { Name = "Hawaii", Abbr = "HI" },
                new State { Name = "Idaho", Abbr = "ID" },
                new State { Name = "Illinois", Abbr = "IL" },
                new State { Name = "Indiana", Abbr = "IN" },
                new State { Name = "Iowa", Abbr = "IA" },
                new State { Name = "Kansas", Abbr = "KS" },
                new State { Name = "Kentucky", Abbr = "KY" },
                new State { Name = "Louisiana", Abbr = "LA" },
                new State { Name = "Maine", Abbr = "ME" },
                new State { Name = "Maryland", Abbr = "MD" },
                new State { Name = "Massachusetts", Abbr = "MA" },
                new State { Name = "Michigan", Abbr = "MI" },
                new State { Name = "Minnesota", Abbr = "MN" },
                new State { Name = "Mississippi", Abbr = "MS" },
                new State { Name = "Missouri", Abbr = "MO" },
                new State { Name = "Montana", Abbr = "MT" },
                new State { Name = "Nebraska", Abbr = "NE" },
                new State { Name = "Nevada", Abbr = "NV" },
                new State { Name = "New Hampshire", Abbr = "NH" },
                new State { Name = "New Jersey", Abbr = "NJ" },
                new State { Name = "New Mexico", Abbr = "NM" },
                new State { Name = "New York", Abbr = "NY" },
                new State { Name = "North Carolina", Abbr = "NC" },
                new State { Name = "North Dakota", Abbr = "ND" },
                new State { Name = "Ohio", Abbr = "OH" },
                new State { Name = "Oklahoma", Abbr = "OK" },
                new State { Name = "Oregon", Abbr = "OR" },
                new State { Name = "Pennsylvania", Abbr = "PA" },
                new State { Name = "Rhode Island", Abbr = "RI" },
                new State { Name = "South Carolina", Abbr = "SC" },
                new State { Name = "South Dakota", Abbr = "SD" },
                new State { Name = "Tennessee", Abbr = "TN" },
                new State { Name = "Texas", Abbr = "TX" },
                new State { Name = "Utah", Abbr = "UT" },
                new State { Name = "Vermont", Abbr = "VT" },
                new State { Name = "Virginia", Abbr = "VA" },
                new State { Name = "Washington", Abbr = "WA" },
                new State { Name = "West Virginia", Abbr = "WV" },
                new State { Name = "Wisconsin", Abbr = "WI" },
                new State { Name = "Wyoming", Abbr = "WY" }
            };

            return states;
        }
    }
}
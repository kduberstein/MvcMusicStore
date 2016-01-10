namespace MusicStore.Services.ViewModels
{
    public class StateView
    {
        public string Abbr { get; set; }

        public string Name { get; set; }

        public string FullName
        {
            get { return Abbr + " - " + Name; }
        }
    }
}
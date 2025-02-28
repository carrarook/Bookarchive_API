namespace Application.Configurations
{
    public class StartupTimeService
    {
        public DateTime StartupTime { get; }

        public StartupTimeService()
        {
            StartupTime = DateTime.Now;
        }
    }

}


namespace Application.Interfaces
{
    public class IResponseHome
    {
        public string ProjectName { get; set; }
        public string Machine { get; set; }
        public string Culture { get; set; }
        public string Environment { get; set; }
        public string TargetFramework { get; set; }
        public DateTime StartupTime { get; set; }
        public bool Alive { get; set; }
    }
}

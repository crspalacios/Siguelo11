
namespace Siguelo11.Infrastructure
{
    using MainViewModels;
    public class InstanceLocator
    {
        public MainViewModel Main
        {
            get; set;
        }
        public InstanceLocator()
        {
            Main = new MainViewModel();
        }
    }
}

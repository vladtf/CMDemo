using Caliburn.Micro;

namespace CMDemo.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public HomeViewModel HomeView { get; set; } = (HomeViewModel)IoC.GetInstance(typeof(HomeViewModel), null);
        public WorkViewModel WorkView { get; set; } = (WorkViewModel)IoC.GetInstance(typeof(WorkViewModel), null);

        public ShellViewModel()
        {
            ActivateItem(HomeView);
        }

        public void Home()
        {
            ActivateItem(HomeView);
        }

        public void Work()
        {
            ActivateItem(WorkView);
        }
    }
}
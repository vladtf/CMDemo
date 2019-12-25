using Caliburn.Micro;
using CMDemo.EventAggregatorMessages;
using CMDemo.Helpers;
using CMDemo.Models;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
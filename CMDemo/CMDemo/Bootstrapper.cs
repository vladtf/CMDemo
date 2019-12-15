using Caliburn.Micro;
using CMDemo.Models;
using CMDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro.Autofac;
using Autofac;

namespace CMDemo
{
    public class Bootstrapper : AutofacBootstrapper<ShellViewModel>
    {

        //private SimpleContainer _container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();
        }


        //Set the window that would be shown on initializing the app.
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override void ConfigureBootstrapper()
        {
            base.ConfigureBootstrapper();
            EnforceNamespaceConvention = true;
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {

            builder.RegisterType<ShellViewModel>().SingleInstance();
            builder.RegisterType<FirstChildViewModel>().SingleInstance();
            builder.RegisterType<SecondChildViewModel>().SingleInstance();
            builder.RegisterType<ThirdChildViewModel>().SingleInstance();
            builder.RegisterType<PersonModel>().SingleInstance();

        }


        //protected override void Configure()
        //{
        //    _container
        //        .Singleton<IWindowManager, WindowManager>()
        //        .Singleton<PersonModel, PersonModel>();

        //    GetType().Assembly.GetTypes()
        //        .Where(type => type.IsClass)
        //        .Where(type => type.Name.EndsWith("ViewModel"))
        //        .ToList()
        //        .ForEach(viewModelType => _container.RegisterPerRequest(
        //            viewModelType, viewModelType.ToString(), viewModelType));

        //}


        //protected override object GetInstance(Type service, string key)
        //{
        //    return _container.GetInstance(service, key);
        //}

        //protected override IEnumerable<object> GetAllInstances(Type service)
        //{
        //    return _container.GetAllInstances(service);
        //}

        //public SimpleContainer GetSimpleContainer()
        //{
        //    return _container;
        //}

        //protected override void BuildUp(object instance)
        //{
        //    _container.BuildUp(instance);
        //}


    }
}

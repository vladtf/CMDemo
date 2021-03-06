﻿using Caliburn.Micro;
using CMDemo.Models;
using CMDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace CMDemo
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();
        }

        //Set the window that would be shown on initializing the app.
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        //protected override void ConfigureBootstrapper()
        //{
        //    base.ConfigureBootstrapper();
        //    EnforceNamespaceConvention = true;
        //}

        //protected override void ConfigureContainer(ContainerBuilder builder)
        //{
        //    builder.RegisterType<ShellViewModel>().SingleInstance();
        //    builder.RegisterType<FirstChildViewModel>().SingleInstance();
        //    builder.RegisterType<SecondChildViewModel>().SingleInstance();
        //    builder.RegisterType<ThirdChildViewModel>().SingleInstance();
        //    builder.RegisterType<PersonModel>().SingleInstance();

        //}

        protected override void Configure()
        {
            _container.Instance(_container);

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<ShellViewModel>()
                .Singleton<FirstChildViewModel>()
                .Singleton<SecondChildViewModel>()
                .Singleton<ThirdChildViewModel>()
                .Singleton<AnotherChildViewModel>()
                .Singleton<WorkViewModel>()
                .Singleton<HomeViewModel>()
                .Singleton<PersonModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
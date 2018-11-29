using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;
using Unity.RegistrationByConvention;
using Unity.ServiceLocation;
using WPF.DependencyInjection.Common;
using WPF.DependencyInjection.FakeServices;
using WPF.DependencyInjection.IServices;

namespace WPF.DependencyInjection.ViewModels
{
    public class ViewModelLocator
    {

        private readonly UnityContainer container;
        private readonly LifetimeManager _mainWindowLifetimeManager = new ContainerControlledLifetimeManager();
        private readonly LifetimeManager _databaseLifetimeManager = new TransientLifetimeManager();

        public ViewModelLocator()
        {
            container = new UnityContainer();            
            container.RegisterType<CustomersViewModel>(_mainWindowLifetimeManager);
            container.RegisterType<ICustomersService, CustomersService>();
            container.RegisterType<IFrameNavigationService, FrameNavigationService>();

            //container.RegisterTypes(
            //       AllClasses.FromLoadedAssemblies(),
            //       WithMappings.FromMatchingInterface,
            //       WithName.Default);

            // ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));

        }


        // ServiceLocator jest abstrakcją do wstrzykiwania. 
        // Izoluje nas od konkretnej implementacji DI

        // Wstrzykiwanie poprzez ServiceLocator
        public ShellViewModel ShellViewModel => ServiceLocator.Current.GetInstance<ShellViewModel>();
        public CustomersViewModel CustomersViewModel => ServiceLocator.Current.GetInstance<CustomersViewModel>();
        public Page1ViewModel Page1ViewModel => ServiceLocator.Current.GetInstance<Page1ViewModel>();

        // Wstrzykiwanie za pomocą Unity
        //public ShellViewModel ShellViewModel => container.Resolve<ShellViewModel>();
        //public CustomersViewModel CustomersViewModel => container.Resolve<CustomersViewModel>();
        //public Page1ViewModel Page1ViewModel => container.Resolve<Page1ViewModel>();

    }
}

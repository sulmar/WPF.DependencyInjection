using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.DependencyInjection.IServices;
using WPF.DependencyInjection.Models;

namespace WPF.DependencyInjection.ViewModels
{
    public class CustomersViewModel : ViewModelBase
    {
        private readonly ICustomersService customersService;

        public CustomersViewModel(ICustomersService customersService)
        {
            this.customersService = customersService;

            Load();
        }

        private void Load()
        {
            Customers = customersService.Get();
        }

        public IList<Customer>  Customers { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.DependencyInjection.Fakers;
using WPF.DependencyInjection.IServices;
using WPF.DependencyInjection.Models;

namespace WPF.DependencyInjection.FakeServices
{
    public class CustomersService : ICustomersService
    {
        CustomerFaker customerFaker = new CustomerFaker();

        public IList<Customer> Get()
        {
            return customerFaker.Generate(100);
            
        }
    }
}

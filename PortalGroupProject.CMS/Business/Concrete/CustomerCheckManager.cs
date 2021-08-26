using MernisServiceReference;
using PortalGroupProject.CMS.Business.Abstract;
using PortalGroupProject.CMS.Entities.Concrete;
using System;
using System.Threading.Tasks;

namespace PortalGroupProject.CMS.Business.Concrete
{
    public class CustomerCheckManager : ICustomerCheckService
    {
        public Task<bool> CheckIfRealPerson(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}

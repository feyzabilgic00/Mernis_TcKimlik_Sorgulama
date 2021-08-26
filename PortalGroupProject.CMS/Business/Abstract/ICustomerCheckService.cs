using MernisServiceReference;
using PortalGroupProject.CMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalGroupProject.CMS.Business.Abstract
{
    public interface ICustomerCheckService
    {
        Task<bool> CheckIfRealPerson(Customer customer);
    }
}

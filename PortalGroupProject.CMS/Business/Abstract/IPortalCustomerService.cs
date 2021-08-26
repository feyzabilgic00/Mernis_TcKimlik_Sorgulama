using PortalGroupProject.CMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalGroupProject.CMS.Business.Abstract
{
    public interface IPortalCustomerService
    {
        Customer Save(Customer customer);
        Customer GetByTc(string nationalityId);
    }
}

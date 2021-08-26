using PortalGroupProject.CMS.Business.Abstract;
using PortalGroupProject.CMS.DataAccess.Abstract;
using PortalGroupProject.CMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalGroupProject.CMS.Business.Concrete
{
    public class PortalCustomerManager : IPortalCustomerService
    {
        private readonly IPortalCustomerDal _portalCustomerDal;
        public PortalCustomerManager(IPortalCustomerDal portalCustomerDal)
        {
            _portalCustomerDal = portalCustomerDal;
        }

        public Customer GetByTc(string nationalityId)
        {
            return _portalCustomerDal.GetByTc(x=>x.NationalityId==nationalityId);
        }

        public Customer Save(Customer customer)
        {
            return _portalCustomerDal.Save(customer);
        }
    }
}

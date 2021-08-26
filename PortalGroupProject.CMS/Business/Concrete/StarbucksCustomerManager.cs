using PortalGroupProject.CMS.Business.Abstract;
using PortalGroupProject.CMS.DataAccess.Abstract;
using PortalGroupProject.CMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalGroupProject.CMS.Business.Concrete
{
    public class StarbucksCustomerManager : IStarbucksCustomerService
    {
        private readonly IStarbucksCustomerDal _starbucksCustomerDal;
        public StarbucksCustomerManager(IStarbucksCustomerDal starbucksCustomerDal)
        {
            _starbucksCustomerDal = starbucksCustomerDal;
        }

        public Customer GetByTc(string nationalityId)
        {
            return _starbucksCustomerDal.GetByTc(x => x.NationalityId == nationalityId);
        }

        public async Task Save(Customer customer)
        {
            _starbucksCustomerDal.Save(customer);
        }
    }
}

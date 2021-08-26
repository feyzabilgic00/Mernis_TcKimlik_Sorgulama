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
        private readonly ICustomerCheckService _customerCheckService;
        public StarbucksCustomerManager(IStarbucksCustomerDal starbucksCustomerDal,ICustomerCheckService customerCheckService)
        {
            _starbucksCustomerDal = starbucksCustomerDal;
            _customerCheckService = customerCheckService;
        }

        public Customer GetByTc(string nationalityId)
        {
            return _starbucksCustomerDal.GetByTc(x => x.NationalityId == nationalityId);
        }

        public async Task Save(Customer customer)
        {
            var result = await _customerCheckService.CheckIfRealPerson(customer);
            if (result)
            {
                _starbucksCustomerDal.Save(customer);
            }
            else
            {
                throw new Exception("Not a valid person");
            }
        }
    }
}

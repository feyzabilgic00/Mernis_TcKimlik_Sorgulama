using PortalGroupProject.CMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PortalGroupProject.CMS.DataAccess.Abstract
{
    public interface ICustomerDal
    {
        Customer Save(Customer customer);
        Customer GetByTc(Expression<Func<Customer, bool>> filter);
    }
}

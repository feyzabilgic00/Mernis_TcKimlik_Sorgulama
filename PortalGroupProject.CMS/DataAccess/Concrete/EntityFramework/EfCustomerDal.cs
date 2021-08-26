using Microsoft.EntityFrameworkCore;
using PortalGroupProject.CMS.DataAccess.Abstract;
using PortalGroupProject.CMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PortalGroupProject.CMS.DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : ICustomerDal
    {
        public Customer Save(Customer customer)
        {
            using (PortalDbContext context=new PortalDbContext())
            {
                var addedCustomer = context.Entry(customer);
                addedCustomer.State = EntityState.Added;
                context.SaveChanges();
            }
            return customer;
        }
        public Customer GetByTc(Expression<Func<Customer, bool>> filter)
        {
            using (PortalDbContext context = new PortalDbContext())
            {
                return context.Set<Customer>().SingleOrDefault(filter);
            }
        }
    }
}

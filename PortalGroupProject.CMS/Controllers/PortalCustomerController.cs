using Microsoft.AspNetCore.Mvc;
using PortalGroupProject.CMS.Business.Abstract;
using PortalGroupProject.CMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalGroupProject.CMS.Controllers
{
    public class PortalCustomerController : Controller
    {
        public IPortalCustomerService _portalCustomerService;
        public PortalCustomerController(IPortalCustomerService portalCustomerService)
        {
            _portalCustomerService = portalCustomerService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Save(Customer customer)
        {
            var query = _portalCustomerService.GetByTc(customer.NationalityId);
            if (query!=null)
            {
                ViewBag.mesaj = "Kullanıcı sistemde kayıtlı!";
                return View();
            }
            Customer result = _portalCustomerService.Save(customer);
            return RedirectToAction("Index", result);        
        }
    }
}

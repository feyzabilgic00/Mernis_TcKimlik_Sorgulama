using Microsoft.AspNetCore.Mvc;
using PortalGroupProject.CMS.Business.Abstract;
using PortalGroupProject.CMS.Entities.Concrete;
using System.Threading.Tasks;

namespace PortalGroupProject.CMS.Controllers
{
    public class StarbucksCustomerController : Controller
    {
        public IStarbucksCustomerService _starbucksCustomerService;
        public StarbucksCustomerController(IStarbucksCustomerService starbucksCustomerService)
        {
            _starbucksCustomerService = starbucksCustomerService;
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
        public async Task<IActionResult> Save(Customer customer)
        {                        
            var query = _starbucksCustomerService.GetByTc(customer.NationalityId);
            if (query!=null)
            {
                ViewBag.tc = "Kullanıcı sistemde kayıtlı!";
                return View();
            }
                await _starbucksCustomerService.Save(customer);
                return RedirectToAction("Index"); 
        }
    }
}

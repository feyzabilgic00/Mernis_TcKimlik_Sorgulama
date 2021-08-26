using Microsoft.AspNetCore.Mvc;
using PortalGroupProject.CMS.Business.Abstract;
using PortalGroupProject.CMS.Entities.Concrete;
using System.Threading.Tasks;

namespace PortalGroupProject.CMS.Controllers
{
    public class StarbucksCustomerController : Controller
    {
        public IStarbucksCustomerService _starbucksCustomerService;
        public ICustomerCheckService _customerCheckService;
        public StarbucksCustomerController(IStarbucksCustomerService starbucksCustomerService, ICustomerCheckService customerCheckService)
        {
            _starbucksCustomerService = starbucksCustomerService;
            _customerCheckService = customerCheckService;
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
            var result = await _customerCheckService.CheckIfRealPerson(customer);
            
            if (!ModelState.IsValid)
            {
                ViewBag.mesaj = "Alanları tekrar kontrol ediniz!";
                return View();
            }
            else if (query != null)
            {
                ViewBag.tc = "Kullanıcı sistemde kayıtlı!";
                return View();
            }
            else if (!result)
            {
                ViewBag.person = "Kullanıcı bilgileri geçerli değil";
                return View();
            }
            else
            { 
                await _starbucksCustomerService.Save(customer);
                return RedirectToAction("Index");
            }
        }
    }
}

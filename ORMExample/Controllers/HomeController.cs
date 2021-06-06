using Microsoft.AspNetCore.Mvc;
using ORMExample.Abstract;
using ORMExample.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ORMExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonelService _personelService;

        public HomeController(IPersonelService personelService)
        {
            _personelService = personelService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _personelService.GetAllPersonel());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _personelService.GetPersonelById(id));
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Personel personel)
        {
            if (ModelState.IsValid)
                {
                    await _personelService.CreatePersonelAsync(personel);
                    return RedirectToAction("Index");
                }
            return View(personel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _personelService.GetPersonelById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Personel personel)
        {          
                if (ModelState.IsValid)
                {
                    var dbPersonel = await _personelService.GetPersonelById(id);
                    if (await TryUpdateModelAsync<Personel>(dbPersonel))
                    {
                        await _personelService.UpdatePersonelAsync(dbPersonel);
                        return RedirectToAction("Index");
                    }
                }                    
            return View(personel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
           
                var dbProduct = await _personelService.GetPersonelById(id);
                if (dbProduct != null)
                {
                    await _personelService.DeletePersonelAsync(dbProduct);
                }                  
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

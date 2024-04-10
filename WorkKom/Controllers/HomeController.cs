using WorkKom.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace WorkKom.Controllers
{
    public class HomeController : Controller
    {
        private Airbilet2Context db; //создание экземпляра контекста Бд

        public HomeController(Airbilet2Context db) //создание экземпляра контекста Бд
        {
            this.db = db;
        }

        public async Task<IActionResult> Index() //получение данных из базы данных и передача их на вкладку
        {
            return View(await db.Billets.ToListAsync());
        }

        //метод обращения к представлению, метод обращения к POST запросу
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(Billet Billet)
        {
            db.Billets.Add(Billet);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //Первый метод ищет определенного пользователя для изменения, а второй сохраняет полученные изменения
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Billet Billet = await db.Billets.FirstOrDefaultAsync(p => p.IdB == id);
                if (Billet != null)
                    return View(Billet);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Billet Billet)
        {
            db.Billets.Update(Billet);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //Первый метод нужен для поиска пользователя по Id а второй для удаления записи из БД
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Billet Billet = await db.Billets.FirstOrDefaultAsync(p => p.IdB == id);
                if (Billet != null)
                    return View(Billet);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Billet Billet = await db.Billets.FirstOrDefaultAsync(p => p.IdB == id);
                if (Billet != null)
                {
                    db.Billets.Remove(Billet);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
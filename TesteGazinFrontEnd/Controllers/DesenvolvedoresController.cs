using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteGazinFrontEnd.Models;

namespace TesteGazinFrontEnd.Controllers
{
    public class DesenvolvedoresController : Controller
    {
        private readonly HttpSolicitacao.HttpSolicitacao _context;

        public DesenvolvedoresController()
        {
            _context = new HttpSolicitacao.HttpSolicitacao();
        }

        // GET: Desenvolvedores
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetDevsAsync());
        }

        // GET: Desenvolvedores/Sobre
        public IActionResult Sobre()
        {
            return View();
        }

        // GET: Desenvolvedores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desenvolvedor = await _context.GetDevAsync(id.ToString());
            if (desenvolvedor == null)
            {
                return NotFound();
            }

            return View(desenvolvedor);
        }

        // GET: Desenvolvedores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Desenvolvedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sexo,Idade,Hobby,DataNascimento")] Desenvolvedor desenvolvedor)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateDevAsync(desenvolvedor);
                return RedirectToAction(nameof(Index));
            }
            return View(desenvolvedor);
        }

        // GET: Desenvolvedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desenvolvedor = await _context.GetDevAsync(id.ToString());
            if (desenvolvedor == null)
            {
                return NotFound();
            }
            return View(desenvolvedor);
        }

        // POST: Desenvolvedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sexo,Idade,Hobby,DataNascimento")] Desenvolvedor desenvolvedor)
        {
            if (id != desenvolvedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateDevAsync(desenvolvedor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesenvolvedorExists(desenvolvedor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(desenvolvedor);
        }

        // GET: Desenvolvedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desenvolvedor = await _context.GetDevAsync(id.ToString());
            if (desenvolvedor == null)
            {
                return NotFound();
            }

            return View(desenvolvedor);
        }

        // POST: Desenvolvedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var desenvolvedor = _context.DeleteDev(id.ToString());
            return RedirectToAction(nameof(Index));
        }
        
        private bool DesenvolvedorExists(int id)
        {
            return _context.GetDevAsync(id.ToString()) != null;
        }
    }
}

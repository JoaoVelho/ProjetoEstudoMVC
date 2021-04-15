using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEstudoMVC.Data;
using ProjetoEstudoMVC.Models;

namespace ProjetoEstudoMVC.Controllers
{
    public class MusicasController : Controller
    {
        private readonly ApplicationDbContext _database;
        private readonly UserManager<Artista> _userManager;

        public MusicasController(ApplicationDbContext database, UserManager<Artista> userManager) {
            _database = database;
            _userManager = userManager;
        }

        public IActionResult Index() {
            List<Musica> listaMusicas = _database.Musicas.Include(m => m.Artista).ToList();
            return View(listaMusicas);
        }

        [Authorize]
        public IActionResult Ver() {
            string userId = _userManager.GetUserId(User);
            List<Musica> listaMusicas = _database.Musicas
                .Include(m => m.Artista)
                .Where(m => m.ArtistaId == userId)
                .ToList();
            return View(listaMusicas);
        }

        [Authorize]
        public async Task<IActionResult> Cadastrar() {
            Artista user = await _userManager.GetUserAsync(User);
            ViewData["user"] = user.Id;
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Editar(int id) {
            Artista user = await _userManager.GetUserAsync(User);
            Musica musica = _database.Musicas.First(registro => registro.Id == id);
            ViewData["user"] = user.Id;
            return View("Cadastrar", musica);
        }

        [Authorize]
        public IActionResult Deletar(int id) {
            Musica musica = _database.Musicas.First(registro => registro.Id == id);
            _database.Musicas.Remove(musica);
            _database.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public IActionResult Salvar(Musica musica) {
            if (musica.Id == 0) {
                _database.Musicas.Add(musica);
            } else {
                Musica musicaBanco = _database.Musicas.First(registro => registro.Id == musica.Id);

                _database.Entry(musicaBanco).CurrentValues.SetValues(musica);
            }
            _database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ProjetoEstudoMVC.Models
{
    public class Artista : IdentityUser
    {
        public string Nome { get; set; }
        public List<Musica> Musicas { get; set; }
    }
}
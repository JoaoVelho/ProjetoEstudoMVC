namespace ProjetoEstudoMVC.Models
{
    public class Musica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }

        public string ArtistaId { get; set; }
        public Artista Artista { get; set; }
    }
}
namespace APINoticias.Models
{
    public class Noticia
    {
        #region
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public string Seccion { get; set; }
        public string Autores { get; set; }
        public DateTime Fecha { get; set; }
        public int CantidadCaracteres { get; set; }
        public bool Autorizada { get; set; }

        #endregion

        #region
        public static IEnumerable<Noticia> ObtenerNoticias()
        {
            string fileName = @".\Models\Noticias.json";
            string jsonString = System.IO.File.ReadAllText(fileName);
            List<Noticia> listaNoticias =
                System.Text.Json.JsonSerializer.Deserialize<List<Noticia>>(jsonString).ToList();
            return listaNoticias;
        }
        #endregion

        #region
        public static Noticia ObtenerNoticia(string id)
        {
            IEnumerable<Noticia> listaNoticias = ObtenerNoticias();
            Noticia encontrado = listaNoticias.Where(x => x.Id == id).SingleOrDefault();
            return encontrado;
        }
        #endregion
    }
}

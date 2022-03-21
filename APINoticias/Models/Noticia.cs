namespace APINoticias.Models
{
    public class Noticia
    {
        #region "Datos"
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public string Seccion { get; set; }
        public string Autores { get; set; }
        public DateTime Fecha { get; set; }
        public int CantidadCaracteres { get; set; }
        public bool Autorizada { get; set; }

        #endregion

        #region "Metodos"
        public static IEnumerable<Noticia> ObtenerNoticias()
        {
            string fileName = @".\Models\Noticias.json";
            string jsonString = System.IO.File.ReadAllText(fileName);
            List<Noticia> listaNoticias =
                System.Text.Json.JsonSerializer.Deserialize<List<Noticia>>(jsonString).ToList(); 
            return listaNoticias;
        }
 
        public static Noticia ObtenerNoticia(string id)
        {
            IEnumerable<Noticia> listaNoticias = ObtenerNoticias();
            Noticia encontrado = listaNoticias.Where(x => x.Id == id && x.Autorizada == true).SingleOrDefault();
            return encontrado;
        }

        public static void AgregarNoticia(Noticia value)
        {
            string fileName = @".\Models\Noticias.json";
            List<Noticia> listaNoticias = ObtenerNoticias().ToList();
            listaNoticias.Add(value);
            string jsonString = System.Text.Json.JsonSerializer.Serialize(listaNoticias);
            System.IO.File.WriteAllText(fileName, jsonString);
        }

        public static bool ActualizarNoticia(string id, Noticia value)
        {
            bool resultado = false;
            string fileName = @".\Models\Noticias.json";
            List<Noticia> listaNoticias = ObtenerNoticias().ToList();
            Noticia encontrado = listaNoticias.Where(x => x.Id == id).SingleOrDefault();

            if (encontrado != null)
            {
                encontrado.Titulo = value.Titulo;
                encontrado.Contenido = value.Contenido;
                encontrado.Seccion = value.Seccion;
                encontrado.Autores = value.Autores;
                encontrado.Fecha = value.Fecha;
                encontrado.CantidadCaracteres = value.CantidadCaracteres;
                string jsonString = System.Text.Json.JsonSerializer.Serialize(listaNoticias);
                System.IO.File.WriteAllText(fileName, jsonString);
                resultado = true;
            }
            return resultado;
        }

        public static bool EliminarNoticia(string id)
        {
            bool resultado = false;
            string fileName = @".\Models\Noticias.json";
            List<Noticia> listaNoticias = ObtenerNoticias().ToList();
            Noticia encontrado = listaNoticias.Where(x => x.Id == id).SingleOrDefault();

            if (encontrado != null)
            {
                listaNoticias.Remove(encontrado);
                string jsonString = System.Text.Json.JsonSerializer.Serialize(listaNoticias);
                System.IO.File.WriteAllText(fileName, jsonString);
                resultado = true;
            }
            return resultado;
        }

        public static bool AutorizarNoticia(string id)
        {
            bool resultado = false;
            string fileName = @".\Models\Noticias.json";
            List<Noticia> listaNoticias = ObtenerNoticias().ToList();
            Noticia encontrado = listaNoticias.Where(x => x.Id == id).SingleOrDefault();

            if (encontrado != null)
            {
                encontrado.Autorizada = true;
                string jsonString = System.Text.Json.JsonSerializer.Serialize(listaNoticias);
                System.IO.File.WriteAllText(fileName, jsonString);
                resultado = true;
            }

            return resultado;
        }
        #endregion
    }
}

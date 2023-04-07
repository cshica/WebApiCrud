namespace WebApi.Models
{
    public class Resultado
    {
        public Resultado() { }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public object Obj { get; set; }
    }
}

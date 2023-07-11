namespace Dominio
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string descripcion_proyecto { get; set; }
        public string nombre_proyecto { get; set; }
        public string url_proyecto { get; set; }
        public int persona_id { get; set; }
    }
}
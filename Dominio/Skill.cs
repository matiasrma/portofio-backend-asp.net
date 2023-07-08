namespace Dominio
{
    public class Skill
    {
        public int Id { get; set; }
        public string img_skill { get; set; }
        public string nombre_skill { get; set; }
        public int percentage_skill { get; set; }
        public byte show_img { get; set; }
        public int persona_id { get; set; }
    }
}
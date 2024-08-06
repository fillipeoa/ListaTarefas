namespace ListaTarefasApi.Models
{
    public class TarefaDto
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public int status_id { get; set; }
        public string status { get; set; }
        public DateOnly prazo_final { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

}

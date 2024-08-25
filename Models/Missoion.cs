using System.ComponentModel.DataAnnotations;

namespace MosadMVC.Models
{
    public class Missoion
    {
        
        public int Id { get; set; }
        public int AgentId { get; set; }
        public int TargetId { get; set; }
        public Double? timeToDo { get; set; }
        public StatusMissoion Status { get; set; }
        public DateTime? Executiontime { get; set; }
    }
}

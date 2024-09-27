using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
    }
}

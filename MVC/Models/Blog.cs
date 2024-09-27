using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(2000)]
        public string? Description { get; set; } = string.Empty;
        [StringLength(100)]
        public string? Image { get; set; }
        public bool IsNew { get; set; }
        public DateTime Date { get; set; }

        [StringLength(50)]
        public string? CreatedBy { get; set; }
    }
}

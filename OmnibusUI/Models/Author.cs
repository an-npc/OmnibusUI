using System.ComponentModel.DataAnnotations;

namespace OmnibusUI.Models
{
    public class Author
    {
        [Key]
        public int authID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}

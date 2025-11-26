using System.ComponentModel.DataAnnotations;

namespace OmnibusUI.Models
{
    public class LibraryCard
    {
        public DateOnly issueDate { get; set; }
        public DateOnly expDate { get; set; }
        public double fines {  get; set; }
        public int booksBorrowed { get; set; }
        [Key]
        public string libCardNum { get; set; }
    }
}

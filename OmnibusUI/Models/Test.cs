using System.ComponentModel.DataAnnotations;

namespace OmnibusUI.Models
{
    public class Test
    {
            [Key]
            public string bookID { get; set; }
            public string title { get; set; }
            public string authorFirst { get; set; }
            public string authorLast { get; set; }
        }
}

namespace OmnibusUI.Models
{
    public class Book
    {
        public string bookID { get; set; }
        public string title { get; set; }
        public string authorFirst { get; set; }
        public string authorLast { get; set; }
        public DateTime publicationDate { get; set; }
        public string genre { get; set; }
        public int numPages { get; set; }
        public double avgRating { get; set; }
        public bool isDigital { get; set; } // this is a boolean bit
        public int copiesAvail { get; set; }

    }

}

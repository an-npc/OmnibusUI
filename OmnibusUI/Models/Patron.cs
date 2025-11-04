namespace OmnibusUI.Models
{
    // contains all information of Patron Entity: a person who borrows books
    public class Patron
    {
        // all of these properties should match the attribute columns in ssms
        
        public int patronID { get; set; }
        public string libCardNum { get; set; }
        public string userFirst { get; set; }
        public string userLast { get; set; }
        public string email { get; set; }
        public int booksBorrowed { get; set; }

    }
}

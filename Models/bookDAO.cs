namespace CST391_Milestone_C.Models
{
    //Data access object that matches the fields in the DB
    public class bookDAO
    {
        //Object properties
        public int id { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string genre { get; set; }
        public float cost { get; set; }
        public int stock { get; set; }

        //Object constructors
        public bookDAO(int id, string author, string title, string genre, float cost, int stock)
        {
            this.id = id;
            this.author = author;
            this.title = title;
            this.genre = genre;
            this.cost = cost;
            this.stock = stock;
        }

        public bookDAO()
        {
        }
    }
}

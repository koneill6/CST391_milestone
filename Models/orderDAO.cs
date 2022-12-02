namespace CST391_Milestone_C.Models
{
    //Data access object that matches the fields in the DB
    public class orderDAO
    {
        //Object properties
        public int id { get; set; }
        public string customer_name { get; set; }
        public float cost { get; set; }
        public string books { get; set; }

        //Object constructors
        public orderDAO(int id, string customer_name, float cost, string books)
        {
            this.id = id;
            this.customer_name = customer_name;
            this.cost = cost;
            this.books = books;
        }

        public orderDAO()
        {
        }
    }
}

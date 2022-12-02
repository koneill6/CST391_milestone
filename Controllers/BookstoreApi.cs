using CST391_Milestone_C.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CST391_Milestone_C.Controllers
{
    //Api end points. Named all end points to be self explanitory
    [ApiController]
    [Route("api/[controller]")]
    public class BookstoreApi : Controller
    {

        [HttpGet]
        [Route("getAllBooks")]
        public ActionResult GetAllBooks()
        {
            dbConnector dbc = new dbConnector();
            List<bookDAO> b = dbc.getAllBooks();
            return Ok(b);
        }

        [HttpGet]
        [Route("getBooks/id/{id}")]
        public ActionResult GetBooksById([FromRoute] int id)
        {
            dbConnector dbc = new dbConnector();
            bookDAO b = dbc.getBookById(id);
            return Ok(b);
        }

        [HttpGet]
        [Route("getBooks/author/{author}")]
        public ActionResult GetBooksByAuthor([FromRoute] string author)
        {
            dbConnector dbc = new dbConnector();
            List<bookDAO> b = dbc.getBooksByAuthor(author);
            return Ok(b);
        }

        [HttpGet]
        [Route("getBooks/genre/{genre}")]
        public ActionResult GetBooksByGenre([FromRoute] string genre)
        {
            dbConnector dbc = new dbConnector();
            List<bookDAO> b = dbc.getBooksByGenre(genre);
            return Ok(b);
        }

        [HttpGet]
        [Route("getBooks/title/{title}")]
        public ActionResult GetBooksByTitle([FromRoute] string title)
        {
            dbConnector dbc = new dbConnector();
            List<bookDAO> b = dbc.getBooksByTitle(title);
            return Ok(b);
        }

        [HttpPost]
        [Route("addBook")]
        public ActionResult AddBook(JObject payload)
        {
            //converts the json to a string then parses out the string into variables
            var data = (JObject)JsonConvert.DeserializeObject(payload.ToString());
            var author = data["author"].ToString();
            var title = data["title"].ToString();
            var genre = data["genre"].ToString();
            var cost = float.Parse(data["cost"].ToString());
            var stock = int.Parse(data["stock"].ToString());

            //builds object with variables
            bookDAO b = new bookDAO(-1, author, title, genre, cost, stock);

            dbConnector dbc = new dbConnector();
            dbc.addBook(b);
            return Ok(payload);
        }

        

        [HttpPut]
        [Route("updateBook")]
        public ActionResult UpdateBook(JObject payload)
        {
            //converts the json to a string then parses out the string into variables
            var data = (JObject)JsonConvert.DeserializeObject(payload.ToString());
            var id = int.Parse(data["id"].ToString());
            var author = data["author"].ToString();
            var title = data["title"].ToString();
            var genre = data["genre"].ToString();
            var cost = float.Parse(data["cost"].ToString());
            var stock = int.Parse(data["stock"].ToString());

            //builds object with variables
            bookDAO b = new bookDAO(id, author, title, genre, cost, stock);

            dbConnector dbc = new dbConnector();
            dbc.updateBook(b);
            return Ok(payload);
        }

        [HttpDelete]
        [Route("deleteBook/{id}")]
        public ActionResult DeleteBook([FromRoute] int id)
        {
            dbConnector dbc = new dbConnector();
            dbc.deleteBook(id);
            return Ok();
        }

        [HttpGet]
        [Route("getAllOrders")]
        public ActionResult GetAllOrders()
        {
            dbConnector dbc = new dbConnector();
            List<orderDAO> o = dbc.getAllOrders();
            return Ok(o);
        }

        [HttpGet]
        [Route("getOrders/id/{id}")]
        public ActionResult GetOrdersById([FromRoute] int id)
        {
            dbConnector dbc = new dbConnector();
            orderDAO o = dbc.getOrderById(id);
            return Ok(o);
        }

        [HttpGet]
        [Route("getOrders/customer/{name}")]
        public ActionResult GetOrdersByCustomerName([FromRoute] string name)
        {
            dbConnector dbc = new dbConnector();
            List<orderDAO> o = dbc.getOrdersByCustomerName(name);
            return Ok(o);
        }

        [HttpPost]
        [Route("addOrder")]
        public ActionResult AddOrder(JObject payload)
        {
            //converts the json to a string then parses out the string into variables
            var data = (JObject)JsonConvert.DeserializeObject(payload.ToString());
            var customer_name = data["customerName"].ToString();
            var cost = float.Parse(data["cost"].ToString());
            var books = data["books"].ToString();

            //builds object with variables
            orderDAO o = new orderDAO(-1, customer_name, cost, books);

            dbConnector dbc = new dbConnector();
            dbc.addOrder(o);
            return Ok(payload);
        }

        [HttpPut]
        [Route("updateOrder")]
        public ActionResult UpdateOrder(JObject payload)
        {
            //converts the json to a string then parses out the string into variables
            var data = (JObject)JsonConvert.DeserializeObject(payload.ToString());
            var id = int.Parse(data["id"].ToString());
            var customer_name = data["customerName"].ToString();
            var cost = float.Parse(data["cost"].ToString());
            var books = data["books"].ToString();

            //builds object with variables
            orderDAO o = new orderDAO(id, customer_name, cost, books);

            dbConnector dbc = new dbConnector();
            dbc.updateOrder(o);
            return Ok(payload);
        }

        [HttpDelete]
        [Route("deleteOrder/{id}")]
        public ActionResult DeleteOrder([FromRoute] int id)
        {
            dbConnector dbc = new dbConnector();
            dbc.deleteOrder(id);
            return Ok();
        }
    }
}

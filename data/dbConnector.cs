
using System.Collections.Generic;
using CST391_Milestone_C.Models;
using MySql.Data.MySqlClient;

namespace CST391_Milestone_C.Controllers
{
    public class dbConnector
    {
        //prebuilt connection to by MAMP server and the bookstore database
        public MySqlConnection connect()
        {
            string connectionString = "server=localhost;user=root;database=bookstore;password=root;";
            return new MySqlConnection(connectionString);
        }

        //All methods are descriptively named to be self explanitory
        public List<bookDAO> getAllBooks()
        {
            List<bookDAO> books = new List<bookDAO>();
            MySqlConnection cn = connect();
            cn.Open();

            String sql = "SELECT * FROM books";
            MySqlCommand cmd = new MySqlCommand(sql, cn);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    books.Add(new bookDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetFloat(4), reader.GetInt32(5)));
                }
            }
            cmd.Dispose();
            cn.Close();

            return books;
        }

        public bookDAO getBookById(int id)
        {
            bookDAO b = new bookDAO();
            MySqlConnection cn = connect();
            cn.Open();

            String sql = "SELECT * FROM books WHERE ID = "+id;
            MySqlCommand cmd = new MySqlCommand(sql, cn);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    b = new bookDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetFloat(4), reader.GetInt32(5));
                }
            }
            cmd.Dispose();
            cn.Close();

            return b;
        }

        public List<bookDAO> getBooksByAuthor(string author)
        {
            List<bookDAO> books = new List<bookDAO>();
            MySqlConnection cn = connect();
            cn.Open();

            String sql = "SELECT * FROM books WHERE AUTHOR LIKE '%"+author+"%'";
            MySqlCommand cmd = new MySqlCommand(sql, cn);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    books.Add(new bookDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetFloat(4), reader.GetInt32(5)));
                }
            }
            cmd.Dispose();
            cn.Close();

            return books;
        }

        public List<bookDAO> getBooksByGenre(string genre)
        {
            List<bookDAO> books = new List<bookDAO>();
            MySqlConnection cn = connect();
            cn.Open();

            String sql = "SELECT * FROM books WHERE GENRE LIKE '%" + genre + "%'";
            MySqlCommand cmd = new MySqlCommand(sql, cn);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    books.Add(new bookDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetFloat(4), reader.GetInt32(5)));
                }
            }
            cmd.Dispose();
            cn.Close();

            return books;
        }

        public List<bookDAO> getBooksByTitle(string title)
        {
            List<bookDAO> books = new List<bookDAO>();
            MySqlConnection cn = connect();
            cn.Open();

            String sql = "SELECT * FROM books WHERE TITLE LIKE '%" + title + "%'";
            MySqlCommand cmd = new MySqlCommand(sql, cn);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    books.Add(new bookDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetFloat(4), reader.GetInt32(5)));
                }
            }
            cmd.Dispose();
            cn.Close();

            return books;
        }

        public void addBook(bookDAO b)
        {
            List<bookDAO> books = new List<bookDAO>();
            MySqlConnection cn = connect();
            cn.Open();
          
            String sql = "INSERT INTO books(AUTHOR, TITLE, GENRE, COST, STOCK) VALUES('"+b.author+"','"+b.title+"','"+b.genre+"','"+b.cost+"','"+b.stock+"')";
            MySqlCommand cmd = new MySqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cn.Close();
        }

        public void updateBook(bookDAO b)
        {
            List<bookDAO> books = new List<bookDAO>();
            MySqlConnection cn = connect();
            cn.Open();

            String sql = "UPDATE books SET AUTHOR='"+b.author+"', TITLE='"+b.title+"', GENRE='"+b.genre+"', COST="+b.cost+", STOCK="+b.stock+" WHERE ID="+b.id;
            MySqlCommand cmd = new MySqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cn.Close();
        }

        public void deleteBook(int id)
        {
            MySqlConnection cn = connect();
            cn.Open();

            String sql = "DELETE FROM books WHERE ID = "+id;
            MySqlCommand cmd = new MySqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cn.Close();
        }

        public List<orderDAO> getAllOrders()
        {
            List<orderDAO> orders = new List<orderDAO>();
            MySqlConnection cn = connect();
            cn.Open();

            String sql = "SELECT * FROM orders";
            MySqlCommand cmd = new MySqlCommand(sql, cn);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    orders.Add(new orderDAO(reader.GetInt32(0), reader.GetString(1), reader.GetFloat(2), reader.GetString(3)));
                }
            }
            cmd.Dispose();
            cn.Close();

            return orders;
        }

        public orderDAO getOrderById(int id)
        {
            orderDAO o = new orderDAO();
            MySqlConnection cn = connect();
            cn.Open();

            String sql = "SELECT * FROM orders WHERE ID = " + id;
            MySqlCommand cmd = new MySqlCommand(sql, cn);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    o = new orderDAO(reader.GetInt32(0), reader.GetString(1), reader.GetFloat(2), reader.GetString(3));
                }
            }
            cmd.Dispose();
            cn.Close();

            return o;
        }

        public List<orderDAO> getOrdersByCustomerName(string name)
        {
            List<orderDAO> orders = new List<orderDAO>();
            MySqlConnection cn = connect();
            cn.Open();

            String sql = "SELECT * FROM orders WHERE CUSTOMER_NAME LIKE '%" + name + "%'";
            MySqlCommand cmd = new MySqlCommand(sql, cn);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    orders.Add(new orderDAO(reader.GetInt32(0), reader.GetString(1), reader.GetFloat(2), reader.GetString(3)));
                }
            }
            cmd.Dispose();
            cn.Close();

            return orders;
        }

        public void addOrder(orderDAO o)
        {
            List<orderDAO> orders = new List<orderDAO>();
            MySqlConnection cn = connect();
            cn.Open();

            String sql = "INSERT INTO orders(CUSTOMER_NAME, COST, BOOKS) VALUES('" + o.customer_name + "','" + o.cost + "','" + o.books + "')";
            MySqlCommand cmd = new MySqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cn.Close();
        }

        public void updateOrder(orderDAO o)
        {
            List<bookDAO> books = new List<bookDAO>();
            MySqlConnection cn = connect();
            cn.Open();

            String sql = "UPDATE orders SET CUSTOMER_NAME='" + o.customer_name + "', COST=" + o.cost + ", BOOKS='" + o.books + "' WHERE ID=" + o.id;
            MySqlCommand cmd = new MySqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cn.Close();
        }

        public void deleteOrder(int id)
        {
            MySqlConnection cn = connect();
            cn.Open();

            String sql = "DELETE FROM orders WHERE ID = " + id;
            MySqlCommand cmd = new MySqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cn.Close();
        }
    }
}

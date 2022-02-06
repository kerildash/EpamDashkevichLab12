using System;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamDashkevichLab12.Db
{
    class Mdb
    {
        private readonly string connectionString;
        private readonly OleDbConnection connection;
        public Mdb()
        {
            connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\EPAM\EpamDashkevichLab12\storage_db.mdb";
            connection = new OleDbConnection(connectionString);

        }
        public string Read()
        {
            try
            {
                string readQuery = "SELECT * FROM Items";
                var read = new OleDbCommand(readQuery, connection);
                string data = "";
                connection.Open();
                using (var reader = read.ExecuteReader())
                {
                    Console.WriteLine("id, item name, quantity");
                    while (reader.Read())
                    {
                        data += reader.GetInt32(0) + ", " + reader.GetString(1) + ", " + reader.GetInt32(2) + "\n";
                    }
                    reader.Close();
                }
                connection.Close();
                return data;
            }
            catch
            {
                throw;
            }
        }
        public void Create(string item, int amount)
        {
            try
            {

                string insertQuery = @"INSERT INTO Items (Item, Amount) VALUES (@Item,@Amount)";
                var insert = new OleDbCommand(insertQuery, connection);

                insert.Parameters.AddWithValue("@Item", item);
                insert.Parameters.AddWithValue("@Amount", amount);

                connection.Open();
                insert.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Updates an amount of some item by its id. To change item name too,
        /// delete this item with Delete() and add another with new name.
        /// </summary>
        public void Update(int id, int amount)
        {
            try
            {
                string updateQuery = "UPDATE Items SET Amount = @Amount WHERE [ID] = @Id";
                var update = new OleDbCommand(updateQuery, connection);

                update.Parameters.AddWithValue("@Amount", amount);
                update.Parameters.AddWithValue("@Id", id);

                connection.Open();
                update.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                string deleteQuery = "DELETE FROM Items WHERE [ID] = @Id";
                var delete = new OleDbCommand(deleteQuery, connection);

                delete.Parameters.AddWithValue("@Id", id);

                connection.Open();
                delete.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                throw;
            }

        }
    }
}

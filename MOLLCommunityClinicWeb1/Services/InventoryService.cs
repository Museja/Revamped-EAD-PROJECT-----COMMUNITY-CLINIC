using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MOLLCommunityClinicWeb1.Models;

namespace MOLLCommunityClinicWeb1
{
    public class InventoryService
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["CommunityClinicLLOMDB"].ConnectionString;

        // ADD INVENTORY ITEM
        public void AddInventory(Inventory1 item)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Inventory
                (Item, Date_Added, Quantity, Description, Price, Expiration,
                 Category, Unit, Batch, Manufacturer, Supplier, Status, Notes)
                VALUES
                (@Item, @Date_Added, @Quantity, @Description, @Price, @Expiration,
                 @Category, @Unit, @Batch, @Manufacturer, @Supplier, @Status, @Notes)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Item", item.Item);
                cmd.Parameters.AddWithValue("@Date_Added", item.Date_Added);
                cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                cmd.Parameters.AddWithValue("@Description", item.Description);
                cmd.Parameters.AddWithValue("@Price", item.Price);
                cmd.Parameters.AddWithValue("@Expiration", item.Expiration);
                cmd.Parameters.AddWithValue("@Category", item.Category);
                cmd.Parameters.AddWithValue("@Unit", item.Unit);
                cmd.Parameters.AddWithValue("@Batch", item.Batch);
                cmd.Parameters.AddWithValue("@Manufacturer", item.Manufacturer);
                cmd.Parameters.AddWithValue("@Supplier", item.Supplier);
                cmd.Parameters.AddWithValue("@Status", item.Status);
                cmd.Parameters.AddWithValue("@Notes", item.Notes ?? (object)DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // GET ALL INVENTORY
        public List<Inventory1> GetAllInventory()
        {
            List<Inventory1> list = new List<Inventory1>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Inventory";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Inventory1
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Item = reader["Item"].ToString(),
                        Date_Added = Convert.ToDateTime(reader["Date_Added"]),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        Description = reader["Description"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Expiration = Convert.ToDateTime(reader["Expiration"]),
                        Category = reader["Category"].ToString(),
                        Unit = reader["Unit"].ToString(),
                        Batch = reader["Batch"].ToString(),
                        Manufacturer = reader["Manufacturer"].ToString(),
                        Supplier = reader["Supplier"].ToString(),
                        Status = reader["Status"].ToString(),
                        Notes = reader["Notes"].ToString()
                    });
                }
            }

            return list;
        }

        // ✔ SEARCH INVENTORY
        public List<Inventory1> SearchInventory(string keyword)
        {
            List<Inventory1> list = new List<Inventory1>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Inventory
                                 WHERE Item LIKE @Keyword
                                 OR Category LIKE @Keyword
                                 OR Supplier LIKE @Keyword
                                 OR Status LIKE @Keyword
                                 OR BatchNumber LIKE @Keyword";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Inventory1
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Item = reader["Item"].ToString(),
                        Date_Added = Convert.ToDateTime(reader["Date_Added"]),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        Description = reader["Description"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Expiration = Convert.ToDateTime(reader["Expiration"]),
                        Category = reader["Category"].ToString(),
                        Unit = reader["Unit"].ToString(),
                        Batch = reader["Batch"].ToString(),
                        Manufacturer = reader["Manufacturer"].ToString(),
                        Supplier = reader["Supplier"].ToString(),
                        Status = reader["Status"].ToString(),
                        Notes = reader["Notes"].ToString()
                    });
                }
            }

            return list;
        }

        // UPDATE INVENTORY
        public void UpdateInventory(Inventory1 item)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Inventory SET
                                Item = @Item,
                                Date_Added = @Date_Added,
                                Quantity = @Quantity,
                                Description = @Description,
                                Price = @Price,
                                Expiration = @Expiration,
                                Category = @Category,
                                Unit = @Unit,
                                Batch = @Batch,
                                Manufacturer = @Manufacturer,
                                Supplier = @Supplier,
                                Status = @Status,
                                Notes = @Notes
                                WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Item", item.Item);
                cmd.Parameters.AddWithValue("@DateAdded", item.Date_Added);
                cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                cmd.Parameters.AddWithValue("@Description", item.Description);
                cmd.Parameters.AddWithValue("@Price", item.Price);
                cmd.Parameters.AddWithValue("@Expiration", item.Expiration);
                cmd.Parameters.AddWithValue("@Category", item.Category);
                cmd.Parameters.AddWithValue("@Unit", item.Unit);
                cmd.Parameters.AddWithValue("@Batch", item.Batch);
                cmd.Parameters.AddWithValue("@Manufacturer", item.Manufacturer);
                cmd.Parameters.AddWithValue("@Supplier", item.Supplier);
                cmd.Parameters.AddWithValue("@Status", item.Status);
                cmd.Parameters.AddWithValue("@Notes", item.Notes ?? (object)DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE INVENTORY
        public void DeleteInventory(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Inventory WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
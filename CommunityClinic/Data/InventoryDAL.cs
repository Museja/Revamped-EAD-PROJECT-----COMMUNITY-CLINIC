using CommunityClinic.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CommunityClinic
{
    public class InventoryDAL
    {
        private string connectionString =
            @"Data Source=TEEN-HUB-LAP-03\SQLEXPRESS;
              Initial Catalog=CommunityClinicLLOMDB;
              Integrated Security=True;
              TrustServerCertificate=True;";

        // GET ALL ITEMS
        public DataTable GetItems()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Inventory";

                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }

        // GET ALL QUERY
        public DataTable GetAllItems()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT *
                    FROM Inventory
                    ORDER BY Item";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            return dt;
        }

        // SEARCH ITEMS
        public DataTable SearchItems(string searchText)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT * FROM Inventory
                    WHERE Item LIKE @Search
                       OR Category LIKE @Search
                       OR Batch LIKE @Search
                       OR Manufacturer LIKE @Search
                       OR Supplier LIKE @Search";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Search", "%" + searchText + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                conn.Open();
                da.Fill(dt);
            }

            return dt;
        }

        // INSERT ITEM
        public bool InsertItem(Inventoryitems item)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Inventory
                (Item, Date_Added, Quantity, Description, Price, Expiration,
                 Category, Unit, Batch, Manufacturer, Supplier, Status, Notes)
                VALUES
                (@Item, @DateAdded, @Quantity, @Description, @Price, @Expiration,
                 @Category, @Unit, @BatchNumber, @Manufacturer, @Supplier, @Status, @Notes)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Item", item.Item);
                cmd.Parameters.AddWithValue("@DateAdded", item.Date_Added);
                cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                cmd.Parameters.AddWithValue("@Description", item.Description);
                cmd.Parameters.AddWithValue("@Price", item.Price);
                cmd.Parameters.AddWithValue("@Expiration", item.Expiration);
                cmd.Parameters.AddWithValue("@Category", item.Category);
                cmd.Parameters.AddWithValue("@Unit", item.Unit);
                cmd.Parameters.AddWithValue("@BatchNumber", item.Batch);
                cmd.Parameters.AddWithValue("@Manufacturer", item.Manufacturer);
                cmd.Parameters.AddWithValue("@Supplier", item.Supplier);
                cmd.Parameters.AddWithValue("@Status", item.Status);
                cmd.Parameters.AddWithValue("@Notes", item.Notes);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // UPDATE ITEM
        public bool Update(Inventoryitems item)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Inventory SET
                    Item=@Item,
                    Date_Added=@DateAdded,
                    Quantity=@Quantity,
                    Description=@Description,
                    Price=@Price,
                    Expiration=@Expiration,
                    Category=@Category,
                    Unit=@Unit,
                    Batch=@BatchNumber,
                    Manufacturer=@Manufacturer,
                    Supplier=@Supplier,
                    Status=@Status,
                    Notes=@Notes
                    WHERE Batch=@BatchNumber";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Item", item.Item);
                cmd.Parameters.AddWithValue("@DateAdded", item.Date_Added);
                cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                cmd.Parameters.AddWithValue("@Description", item.Description);
                cmd.Parameters.AddWithValue("@Price", item.Price);
                cmd.Parameters.AddWithValue("@Expiration", item.Expiration);
                cmd.Parameters.AddWithValue("@Category", item.Category);
                cmd.Parameters.AddWithValue("@Unit", item.Unit);
                cmd.Parameters.AddWithValue("@BatchNumber", item.Batch);
                cmd.Parameters.AddWithValue("@Manufacturer", item.Manufacturer);
                cmd.Parameters.AddWithValue("@Supplier", item.Supplier);
                cmd.Parameters.AddWithValue("@Status", item.Status);
                cmd.Parameters.AddWithValue("@Notes", item.Notes);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
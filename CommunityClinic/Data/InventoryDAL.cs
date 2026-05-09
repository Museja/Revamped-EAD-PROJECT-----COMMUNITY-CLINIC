
using CommunityClinic.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CommunityClinic
{
        public class InventoryDAL
        {
        private string connectionString =
     @"Data Source=TEEN-HUB-LAP-03\SQLEXPRESS;
      Initial Catalog=CommunityClinicLLOMDB;
      Integrated Security=True;
      TrustServerCertificate=True;";

        // GET ALL ITEMS (FOR GRIDVIEW)
        //public DataTable GetItems()
        //{

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        string query = "SELECT * FROM Inventory";

        //        SqlDataAdapter da = new SqlDataAdapter(query, conn);
        //        //DataTable dt = new DataTable();
        //        DataSet ds = new  DataSet();

        //        da.Fill(ds);
        //        return ds.Tables[0];
        //    }
        //}
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
                    cmd.Parameters.AddWithValue("@DateAdded", item.DateAdded);
                    cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                    cmd.Parameters.AddWithValue("@Description", item.Description);
                    cmd.Parameters.AddWithValue("@Price", item.Price);
                    cmd.Parameters.AddWithValue("@Expiration", item.Expiration);
                    cmd.Parameters.AddWithValue("@Category", item.Category);
                    cmd.Parameters.AddWithValue("@Unit", item.Unit);
                    cmd.Parameters.AddWithValue("@BatchNumber", item.BatchNumber);
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
                    cmd.Parameters.AddWithValue("@DateAdded", item.DateAdded);
                    cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                    cmd.Parameters.AddWithValue("@Description", item.Description);
                    cmd.Parameters.AddWithValue("@Price", item.Price);
                    cmd.Parameters.AddWithValue("@Expiration", item.Expiration);
                    cmd.Parameters.AddWithValue("@Category", item.Category);
                    cmd.Parameters.AddWithValue("@Unit", item.Unit);
                    cmd.Parameters.AddWithValue("@BatchNumber", item.BatchNumber);
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
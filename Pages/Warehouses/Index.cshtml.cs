using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WareHouse_and_Inventory.Pages.Warehouses
{
    public class IndexModel : PageModel
    {
        public List<WarehouseInfo>  ListWarehouses = new();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-6LJ8HPO;Integrated Security=True";
                using SqlConnection connection = new(connectionString);
                connection.Open();
                string sql = "SELECT * FROM Warehouses";
                SqlCommand cmd = new(sql, connection);
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    {
                        while (reader.Read())
                        {
                            WarehouseInfo warehouseInfo = new()
                            {
                                id = "" + reader.GetInt32(0),
                                name = reader.GetString(1),
                                description=reader.GetString(2)
                            };
                            WarehouseInfo info = warehouseInfo;

                            ListWarehouses.Add(info);








                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
    }
    public class WarehouseInfo
    {
        public String? id;
        public String? name;
        public String? description;


    }
}

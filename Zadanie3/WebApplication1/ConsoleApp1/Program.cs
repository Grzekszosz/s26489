// See https://aka.ms/new-console-template for more information

using Microsoft.Data.SqlClient;

String connectionString = "Data Source=db-mssql;Initial Catalog=S26489;Integrated Security=True;Trust Server Certificate=True";

using (SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();
    System.Console.WriteLine(connection.State);
    using var cmd = new SqlCommand();
    cmd.Connection = connection;
    cmd.CommandText = "SELECT IDAnimal, Name, Description, Category, Area  FROM s26489.APDBP.Animals ORDER BY IDAnimal";
    var dr = cmd.ExecuteReader();
    while (dr.Read())
    {
        System.Console.WriteLine((int)dr["IDAnimal"]);
        System.Console.WriteLine(dr["Name"].ToString());
        System.Console.WriteLine(dr["Description"].ToString());
        System.Console.WriteLine(dr["Category"].ToString());
        System.Console.WriteLine(dr["Area"].ToString());
        
    }
    connection.Close();
}
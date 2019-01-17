using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Types;

namespace geospacial_test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);
            string connection = "<ENTER CONNECTION STRING HERE>";

            using (var conn = new SqlConnection(connection))
            {
                conn.Open();

                var load = new SqlCommand(@"
                    if object_id('dbo.spacial_data', 'U') is not null
                      drop table dbo.spacial_data; 
                    create table dbo.spacial_data (
                        id int not null identity primary key,
                        data Geometry  
                    );
                    Declare @g geometry;
		            SET @g= geometry::STGeomFromText('POINT(4 5)',0);
                    insert into dbo.spacial_data (data) values (@g);
                ", conn);

                load.ExecuteNonQuery();

                var cmd = new SqlCommand("select data from dbo.spacial_data", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    Console.WriteLine(((IDataRecord)reader)[0]);
                }

                conn.Close();

            }
            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}

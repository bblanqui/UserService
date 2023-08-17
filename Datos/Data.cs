using System.Data.SqlClient;
using System.Configuration;
namespace Datos
{
    public class ConectionUser
    {

        public SqlConnection ConectUser()
        {
           
            return new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        }
        }
    }

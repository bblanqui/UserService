using System.Data.SqlClient;

namespace UserService
{
    public class ConectionUser
    {

        public SqlConnection ConectUser()
        {
            return new SqlConnection("Data Source = localhost; Initial Catalog = digital_bank; Integrated Security = True;");
        }
    }
}
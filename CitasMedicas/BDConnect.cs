using System.Data.SqlClient;

namespace CitasMedicas
{
    public class BDConnect
    {
        private string StringConnection;

        public BDConnect(string StringConnection)
        {
            this.StringConnection = StringConnection;
        }

        public (SqlDataReader, bool) getConnectionReader(string StringCommand)
        {
            try
            {
                SqlConnection con = new SqlConnection(StringConnection);

                con.OpenAsync();

                var comando = new SqlCommand(StringCommand, con);
                var reader = comando.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                return (reader, true);
            }
            catch (SqlException)
            {
                throw;
            }
            
        }

        public void changeStringConnection(string StringConnection)
        {
            this.StringConnection = StringConnection;
        }
    }
}

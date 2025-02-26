using Microsoft.Data.SqlClient;

namespace AgilePoker.Shared
{
    public class SqlLogger : ILogger
    {
        //private readonly string db = @"Server=ROBDESKTOP\SQLEXPRESS;User Id=apAdmin;Password=zyxel999;Database=AgilePoker;Trusted_Connection=True;TrustServerCertificate=True;";
        private readonly string db = @"Server=db14570.public.databaseasp.net;Database=db14570; User Id=db14570; Password=7Nb%?a9PiQ+6; Encrypt=False; MultipleActiveResultSets=True;";
        public void Log(Enums.LogLevel level, string message, Exception? exception = null)
        {
            using (SqlConnection cn = new(db))
            {
                SqlCommand cmd = new("INSERT db14570.dbo.RoomLog (dt, Message) VALUES (@dt, @message)", cn);
                cmd.Parameters.AddWithValue("@dt", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@message", message);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

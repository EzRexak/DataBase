using MySqlConnector;

namespace Database2024
{
    public static class DbHelper
    {
        private static readonly string ConnStr = "Server=MySQL-8.0;DataBase=CALC;port=3306;User Id=root;password=";
        private static readonly MySqlConnection Conn = new(ConnStr);

        static DbHelper()
        {
            Conn.Open();
        }

        public static long AddRecord(Record u)
        {
            try
            {
                var cmd = Conn.CreateCommand();
                cmd.CommandText = "INSERT INTO `full_records` (h_pr,l_pr,result) VALUES (@n, @a, @p)";
                cmd.Parameters.Add(new MySqlParameter("@n", u.H_Pr));
                cmd.Parameters.Add(new MySqlParameter("@a", u.L_Pr));
                cmd.Parameters.Add(new MySqlParameter("@p", u.Result));
                cmd.ExecuteNonQuery();
                return cmd.LastInsertedId;
            }
            catch
            {
                return -1;
            }
        }

        public static IEnumerable<Record> LoadAll()
        {
            List<Record> users = new ();
            try
            {
                var cmd = Conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM `full_records`";
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            users.Add(new Record
                            {
                                H_Pr = reader.GetUInt32("h_pr"),
                                L_Pr = reader.GetUInt32("l_pr"),
                                Result = reader.GetDouble("result"),
                            });
                        }
                    }
                }
            }
            catch
            {
            }
            return users;
        }

        public static long GetRecordsCount()
        {
            try
            {
                var cmd = Conn.CreateCommand();
                cmd.CommandText = "SELECT COUNT(id) FROM `full_records`;";
                var res = cmd.ExecuteScalar();
                if (res is long r) return r;
                return 0;
            }
            catch
            {
                return 0;
            }
        }
    }
}

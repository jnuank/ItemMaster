using System;
using MySql.Data.MySqlClient;


namespace Domain.Model.Items
{
    public class ItemService
    {
        string ConnectionString = "Data Source=hogehoge";
        public bool IsDuplicated(Item item)
        {
            // DBへの問い合わせ
            var con = new MySqlConnection(ConnectionString); // 接続文字列は static で定義されているとして
            con.Open();
            using (var command = con.CreateCommand())
            {
                command.CommandText = "SELECT * FROM t_item WHERE skucode = @skucode";
                command.Parameters.Add(new MySqlParameter("@skucode", item.Code.Value));
                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        var fromDate = reader["fromdate"] as DateTime?;
                        var toDate = reader["todate"] as DateTime?;
                        
                        var term = new ValidTerm((DateTime)fromDate, (DateTime)toDate);
                        
                        if (item.Term.IsOverrap(term))
                            return true;
                    }
                }
            }
            
            return false;
        }
    }
}

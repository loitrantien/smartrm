using System;
using System.Data;
using System.Data.SqlClient;

namespace SmartRm.Models.databases
{

        public class DBlibs
        {
            //Khai báo biến thành viên
            private SqlConnection cnn;
            private SqlCommand cmd;

            //Phương thức khởi tạo
            public DBlibs()
            {
                string strcnn = @"Data Source=DESKTOP-NQEUCB5;Initial Catalog=QLNH;Integrated Security=True";
                cnn = new SqlConnection();
                cnn.ConnectionString = strcnn;
                cmd = new SqlCommand();
                cmd.Connection = cnn;
            }

            //Phương thức mở kết nối CSDL
            public void Open()
            {
                //Kiểm tra trạng thái kết nối
                if (cnn.State != System.Data.ConnectionState.Open)
                {
                    cnn.Open();
                }
            }

            //Phương thức đóng kết nối CSDL
            public void Close()
            {
                //Kiểm tra trạng thái kết nối
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }
            }

            //Phương thức truyền tham số
            public void AddParameter(string name, object value)
            {
                SqlParameter para = new SqlParameter();
                para.ParameterName = name;
                para.Value = value;
                cmd.Parameters.Add(para);
            }

            //Phương thức thực thi câu lệnh với câu lệnh và kiểu câu lệnh SQL
            public int ExecuteNonQuery(string cmdText, CommandType cmdType)
            {
                int count = 0;
                try
                {
                    //Mở kết nối
                    Open();
                    cmd.CommandText = cmdText;
                    cmd.CommandType = cmdType;
                    count = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }
                return count;
            }

            //public DataTable FillDataTable(string cmdText, CommandType cmdType)
            //{
            //    DataTable table = new DataTable();
            //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //    try
            //    {
            //        cmd.CommandText = cmdText;
            //        cmd.CommandType = cmdType;
            //        adapter.Fill(table);
            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }

            //    return table;
            //}
        }
    

}

using System;
using System.Collections.Generic;
using System.Web;

namespace VD10
{
    public class WebClass
    {
        /// <summary>
        /// Hàm này lấy connection string từ file web.config theo tên của connection string
        /// Nếu lưu chuỗi kết nối cùng với mã nguồn C# thì sau này không thể dùng chương trình đã biên dịch với các cấu hình khác, cần phải điều chỉnh
        /// chuỗi kết nối trong mã nguồn C# và biên dịch lại...
        /// Nếu lưu trong web.config và các kiểu cấu hình khác, chỉ cần thay đổi cấu hình trong các tệp đó...
        /// </summary>
        /// <param name="connectionStringName"></param> - xem web.config để thấy tên và nội dung của chuỗi kết nối có tên connectionStringName
        /// <returns></returns>
        public static string getConnectionStringByName(string connectionStringName)
        {
            System.Configuration.Configuration rootWebConfig = //Dung System.Reflection.Assembly.GetExecutingAssembly().FullName de lay namespace=websiate thay vi moi lan phai dieu chinh cho moi du an
                System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(String.Format("\\{0}", System.Reflection.Assembly.GetExecutingAssembly().FullName));// /VD9 ten website = project
            System.Configuration.ConnectionStringSettings connString;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString =
                    rootWebConfig.ConnectionStrings.ConnectionStrings[connectionStringName];
                if (connString != null)
                    return connString.ConnectionString;
            }
            return "";
        }
    }
}
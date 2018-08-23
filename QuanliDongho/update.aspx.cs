using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanliDongho
{
    public partial class update : System.Web.UI.Page
    {
        string conString = @"Data Source = DESKTOP-T6VGD9K\SQLEXPRESS; Initial Catalog=dongho;User id=sa;Password=123";
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void bCapNhat_Click(object sender, EventArgs e)
        {
            lThongBao.Text = "";
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcmd1 = new SqlCommand();
            try
            {
                if (ID.Text.Trim() == "")
                {
                    lThongBao.Text = "Phải nhập đủ dữ liệu!";
                    return;
                }
                sqlcon.ConnectionString = conString;
                sqlcon.Open();
                if (sqlcon.State == System.Data.ConnectionState.Open)
                {
                    //lThongBao.Text = "Kết nối CSDL thành công!";
                    sqlcmd1.Connection = sqlcon;
                    sqlcmd1.CommandType = System.Data.CommandType.Text;
                    sqlcmd1.CommandText = "update Thongtin1 set id= " + ID1.Text.Trim() + "," + "hang = '" + hang.Text.Trim() + "'," + "mausac = '" + mausac.Text.Trim() + "'," + "gia = '" + gia.Text.Trim() + "' where id=" + ID.Text.Trim()     ;
                    lThongBao.Text = sqlcmd1.CommandText;
                    int cnt = sqlcmd1.ExecuteNonQuery();
                    lThongBao.Text = cnt.ToString() + " đã được thêm thành công!";
                }
                else lThongBao.Text = "Kết nối CSDL thất bại!";
            }
            catch (Exception exc)
            {
                lThongBao.Text = "Kết nối CSDL thất bại! Lỗi: " + exc.Message + ". " + exc.StackTrace;

            }
            finally
            {
                sqlcon.Close();
                sqlcmd1.Dispose();
            }

        }

       
            
               
            
        }
    }

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// 
/// </summary>
using System.Data.SqlClient;

namespace VD
{
    public partial class QT1 : System.Web.UI.Page
    {
        string conString = @"Data Source = DESKTOP-T6VGD9K\SQLEXPRESS; Initial Catalog=Sample;User id=sa;Password=123";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //ddlTheLoai.Items.Clear();
                ListItem item0 = new ListItem();
                item0.Value = "-1";
                item0.Text = "Chọn thể loại";
                ddlTheLoai.Items.Add(item0);

                SqlConnection sqlcon = new SqlConnection();
                SqlCommand sqlcom2 = new SqlCommand();
                try
                {
                    sqlcon.ConnectionString = conString;
                    sqlcon.Open();
                    if (sqlcon.State == System.Data.ConnectionState.Open)
                    {
                        sqlcom2.Connection = sqlcon;
                        sqlcom2.CommandType = System.Data.CommandType.Text;
                        sqlcom2.CommandText = "SELECT maTheLoai, tenTheLoai FROM TheLoai";
                        SqlDataReader sqlreader = sqlcom2.ExecuteReader();


                        if (sqlreader.HasRows)
                        {
                            while (sqlreader.Read())
                            {
                                ListItem item = new ListItem();
                                item.Value = sqlreader.GetInt32(0).ToString(); //ma the loai
                                item.Text = sqlreader.GetSqlString(1).ToString();//ten the loai
                                ddlTheLoai.Items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception exc)
                {
                    lThongBao.Text = String.Format("Lỗi: {0}. Chi tiết: {1}", exc.Message, exc.StackTrace);
                }
                finally
                {
                    sqlcon.Close();
                    sqlcom2.Dispose();
                }
            }
        }

        protected void bThemMoi_Click(object sender, EventArgs e)
        {
            lThongBao.Text = "";
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcmd1 = new SqlCommand();
            try
            {
                if (tbID.Text.Trim() == "" || tbTen.Text.Trim() == "" || ddlTheLoai.SelectedIndex == 0)
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
                    sqlcmd1.CommandText = "INSERT INTO HangHoa(ID, Ten, maTheLoai) VALUES("
                        + tbID.Text.Trim()+", '"+tbTen.Text.Trim()+"', '"
                        +ddlTheLoai.SelectedValue+"')";
                    lThongBao.Text = sqlcmd1.CommandText;
                    int cnt = sqlcmd1.ExecuteNonQuery();
                    lThongBao.Text = cnt.ToString() + " đã được thêm thành công!";
                }
                else lThongBao.Text = "Kết nối CSDL thất bại!";
            }
            catch(Exception exc)
            {
                lThongBao.Text = "Kết nối CSDL thất bại! Lỗi: "+exc.Message+". "+exc.StackTrace;

            }
            finally
            {
                sqlcon.Close();
                sqlcmd1.Dispose();
            }
        }
    }
}
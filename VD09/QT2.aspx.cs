using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// 
/// </summary>
using System.Data.SqlClient;
namespace VD9
{
    public partial class QT2 : System.Web.UI.Page
    {
        string conString;// = @"Data Source = DESKTOP-TSV4T6E\MSSQL2014; Initial Catalog=Sample;User id=log1;Password=1";
        protected void Page_Load(object sender, EventArgs e)
        {
            conString = WebClass.getConnectionStringByName("sqlSConString");
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

        protected void bCapNhat_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(conString);//Dùng constructor khác
            SqlCommand sqlcom3 = new SqlCommand();
            try
            {
                if (tbID.Text.Trim() == "" || tbTen.Text.Trim() == "" || ddlTheLoai.SelectedIndex == 0)
                {
                    lThongBao.Text = "Phải nhập đủ dữ liệu!";
                    return;
                }
                sqlcon.Open();
                if (sqlcon.State == System.Data.ConnectionState.Open)
                {
                    //Dùng Parameters sẽ giúp loại bỏ nhiều vấn đề so với cách như ở QT1
                    sqlcom3.Connection = sqlcon;
                    sqlcom3.CommandText = "UPDATE HangHoa SET ten = @tenHang, maTheLoai = @maTheLoai WHERE ID = @id";
                    //Truy vấn có 3 parameter tương ứng 3 tên có @ ở trước
                    sqlcom3.Parameters.Add("tenHang", System.Data.SqlDbType.NVarChar);//Thêm parameter
                    sqlcom3.Parameters["tenHang"].Value = tbTen.Text.Trim();//Gán giá trị cho parameter
                    sqlcom3.Parameters.Add("maTheLoai", System.Data.SqlDbType.Int);
                    sqlcom3.Parameters["maTheLoai"].Value = ddlTheLoai.SelectedValue;
                    sqlcom3.Parameters.Add("id", System.Data.SqlDbType.Int);
                    sqlcom3.Parameters["id"].Value = tbID.Text.Trim();
                    int cnt = sqlcom3.ExecuteNonQuery();
                    lThongBao.Text = String.Format("{0} bản ghi đã được cập nhật thành công!", cnt);
                }
            }
            catch (Exception exc)
            {
                lThongBao.Text = String.Format("Lỗi: {0}. Chi tiết: {1}", exc.Message, exc.StackTrace);
            }
            finally
            {
                sqlcon.Close();
                sqlcom3.Dispose();
            }

        }
    }
}
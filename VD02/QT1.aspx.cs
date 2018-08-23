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
        string conString = @"Data Source = DESKTOP-TSV4T6E\MSSQL2014; Initial Catalog=Sample;User id=log1;Password=1";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                #region Đưa ds thể loại lên drop-down-list ddlTheLoai
                ///Thêm lựa chọn mặc định, thể hiện người dùng chưa chọn một giá trị thích hợp
                ListItem item0 = new ListItem();
                item0.Value = "-1";//Giá trị sẽ được lấy
                item0.Text = "Chọn thể loại";//Nội dung hiển thị trong danh sách
                //ddlTheLoai.Items.Clear();//Xoá danh sách của ddlTheLoai
                ddlTheLoai.Items.Add(item0);//Thêm mục đầu tiên
                

                SqlConnection sqlcon = new SqlConnection();
                SqlCommand sqlcom2 = new SqlCommand();
                try
                {
                    sqlcon.ConnectionString = conString;
                    sqlcon.Open();
                    if (sqlcon.State == System.Data.ConnectionState.Open)//Kiểm tra tình trạng kết nối
                    {
                        sqlcom2.Connection = sqlcon;
                        sqlcom2.CommandType = System.Data.CommandType.Text;
                        sqlcom2.CommandText = "SELECT maTheLoai, tenTheLoai FROM TheLoai ";//where 1=0
                        SqlDataReader sqlreader = sqlcom2.ExecuteReader();//SqlDataReader để làm gì?
                        if (sqlreader.HasRows)//Nếu kết quả trả về có tối thiểu 1 bản ghi
                        {
                            while (sqlreader.Read())//còn có thể đọc bản ghi ở vị trí con trỏ hiện tại (kế tiếp)
                            {
                                ListItem item = new ListItem();
                                item.Value = sqlreader.GetInt32(0).ToString(); //ma the loai
                                item.Text = sqlreader.GetSqlString(1).ToString();//ten the loai
                                ddlTheLoai.Items.Add(item);//Thêm mục vào danh sách ddl
                            }
                        }
                        //else {...}
                    }
                }
                catch (Exception exc)
                {
                    Response.Write(String.Format("Loi: {0}<br />{1}", exc.Message, exc.StackTrace));
                }
                finally
                {
                    try
                    {
                        sqlcon.Close();
                        sqlcom2.Dispose();
                    }
                    catch (Exception exc1)
                    {
                        Response.Write(String.Format("Loi: {0}<br />{1}", exc1.Message, exc1.StackTrace));
                    }
                    finally
                    {

                    }
                }
                #endregion

            }
        }

        protected void bThemMoi_Click(object sender, EventArgs e)
        {
            if (ddlTheLoai.SelectedValue == "-1")
                Response.Write("<script>alert('Bạn chưa chọn thể loại')</script>");
            else Response.Write("<script>alert('Bạn đã chọn thể loại, nhưng không thêm được bản ghi vì...')</script>");

        }
    }
}
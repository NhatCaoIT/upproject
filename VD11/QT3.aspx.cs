using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// 
/// </summary>
using System.Data;
using System.Data.SqlClient;

namespace VD11
{
    public partial class QT3 : System.Web.UI.Page
    {
        string conString;// = @"Data Source = DESKTOP-TSV4T6E\MSSQL2014; Initial Catalog=Sample;User id=log1;Password=1";
        protected void Page_Load(object sender, EventArgs e)
        {
            conString = WebClass.getConnectionStringByName("sqlSConString");
            if (!Page.IsPostBack)
            {
                #region Đọc dữ liệu và đưa lên danh sách dropdownlist
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
                #endregion
                //đưa dữ liệu lên lưới dữ liệu gridview
                //BindDataToGridView(-1);
            }
        }

        /// <summary>
        ///Phương thức này dùng để đọc dữ liệu và đưa lên gridview, có phân trang
        /// </summary>
        /// <param name="pageIndex"></param>
        /// 
        private void BindDataToGridView(int pageIndex)
        {
            SqlConnection sqlSconn = new SqlConnection();
            SqlCommand sqlScomm4 = new SqlCommand();
            try
            {
                sqlSconn.ConnectionString = conString;
                sqlSconn.Open();
                if (sqlSconn.State == System.Data.ConnectionState.Open)
                {
                    //Doc cac ban ghi tu CSDL va the hien tren luoi du lieu
                    GridView1.DataSource = null;
                    DataTable dt = new DataTable();
                    sqlScomm4.Connection = sqlSconn;
                    sqlScomm4.CommandType = CommandType.Text;
                    sqlScomm4.CommandText =  String.Format("SELECT ID, ten, maTheLoai FROM HangHoa {0} ORDER BY ID DESC",
                        (ViewState["dieuKienTimKiem"] != null ? (ViewState["dieuKienTimKiem"] as string) : ""));
                    lThongBao.Text = sqlScomm4.CommandText;//in ra truy vấn để kiểm tra trước
                    SqlDataAdapter da = new SqlDataAdapter(sqlScomm4);
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    //sắp xếp, trên thực tế, có thể đưa vào sqlScomm4.CommandText
                    if(ViewState["sortExpression"] != null)
                        dt.DefaultView.Sort = String.Format("{0} {1}", (ViewState["sortExpression"] as string),
                            (ViewState["sortDirection"] != null ? (ViewState["sortDirection"] as string) : "ASC"));
                    //dung cai nay de phan trang
                    if (pageIndex >= 0)
                        GridView1.PageIndex = pageIndex;
                    GridView1.DataBind();
                    //Đổi tiêu đề cột
                    if (GridView1.Rows.Count > 0)
                    {
                        ((LinkButton)(GridView1.HeaderRow.Cells[0].Controls[0])).Text = "Mã";
                        ((LinkButton)(GridView1.HeaderRow.Cells[1].Controls[0])).Text = "Tên hàng";
                        ((LinkButton)(GridView1.HeaderRow.Cells[2].Controls[0])).Text = "Thể loại";
                    }
                    //lThongBao.Text = String.Format("Tìm được {0} bản ghi!", dt.Rows.Count);
                }


            }
            catch (Exception exc)
            {
                //MessageBox.Show
                Response.Write(String.Format("Loi: {0}<br />{1}", exc.Message, exc.StackTrace));
            }
            finally
            {
                sqlSconn.Close();
                sqlScomm4.Dispose();
            }
        }
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                string sortDirection;
                //Mặc định ASC
                if (ViewState["sortDirection"] != null) sortDirection = ViewState["sortDirection"] as string;
                else sortDirection = "ASC";
                //Đưa thông báo dưới dạng javascript alert
                Response.Write(String.Format("<script>alert('Sắp xếp {1} theo cột {0}')</script>", e.SortExpression, sortDirection));
                //Lưu cách cột theo đó thực hiện sắp xếp vào ViewState để có thể sử dụng khi chuyển sang lần gọi sau 
                ViewState["sortExpression"] = e.SortExpression;
                BindDataToGridView(GridView1.PageIndex);
                //Đảo chiều sau mỗi lần click
                if (sortDirection == "ASC") sortDirection = "DESC";
                else sortDirection = "ASC";
                //Lưu cách sắp xếp vào ViewState để có thể sử dụng khi chuyển sang lần gọi sau 
                ViewState["sortDirection"] = sortDirection;
            }
            catch (Exception exc)
            {
                Response.Write(String.Format("Lỗi: {0}<br />{1}",exc.Message,exc.StackTrace));
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindDataToGridView(e.NewPageIndex);
        }

        protected void bTimKiem_Click(object sender, EventArgs e)
        {
            //Kiểm tra xem điều kiện tìm kiếm đã có hay chưa
            if (tbID.Text.Trim() == "" && tbTen.Text.Trim() == "" && ddlTheLoai.SelectedIndex == -1)
            {
                lThongBao.Text = "Hãy nhập tiêu chí tìm kiếm!";
                return;
            }
            string dieuKienTimKiem = " WHERE 1=1 "; //đưa 1=1 để dễ nối các điều kiện khác vào
            if (tbID.Text.Trim() != "") dieuKienTimKiem += " AND ID = " + tbID.Text.Trim();

            if (tbTen.Text.Trim() != "") dieuKienTimKiem += " AND ten LIKE N'%" + tbTen.Text.Trim() + "%'";

            if (ddlTheLoai.SelectedValue != "-1")//"Không chọn"
                dieuKienTimKiem += " AND maTheLoai = " + ddlTheLoai.SelectedValue;

            ////Dùng ViewState để chuyển truy van tìm kiếm sang lần gọi trang này kế tiếp
            //luu truy van tim kiem hien tai vao viewstate
            //Cac TextBox... cung su dung thuoc tinh viewstate = enabled = true de giu lai gia tri khi chay lai (kich chuot...)...
            ViewState["dieuKienTimKiem"] = dieuKienTimKiem;

            //Doc cac ban ghi tu CSDL va the hien tren luoi du lieu
            BindDataToGridView(-1);
        }
    }

}
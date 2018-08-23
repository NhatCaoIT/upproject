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

namespace VD8
{
    public partial class QT1 : System.Web.UI.Page
    {
        string conString; //= @"Data Source = DESKTOP-TSV4T6E\MSSQL2014; Initial Catalog=Sample;User id=log1;Password=1";
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
                BindDataToGridView(-1);
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
                    //Đọc lại dữ liệu và đưa lên gridview
                    BindDataToGridView(-1);
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
                    sqlScomm4.CommandText = "SELECT ID, ten, maTheLoai FROM HangHoa ORDER BY ID DESC";//ko dung schema TP.
                    SqlDataAdapter da = new SqlDataAdapter(sqlScomm4);
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    //dung cai nay de phan trang
                    if (pageIndex >= 0)
                        GridView1.PageIndex = pageIndex;
                    GridView1.DataBind();
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
        /// <summary>
        /// Phương thức này đọc dữ liệu từ CSDL và đưa lên gridview
        /// Thực tế không cần viết riêng vì chỉ khác phương thức ở trên các tham số và 1 dòng mã nguồn dùng để sắp xếp
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="sortExpression"></param>
        /// <param name="sortDirection"></param>
        private void BindDataToGridView(int pageIndex, string sortExpression, string sortDirection = "ASC")
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
                    sqlScomm4.CommandText = "SELECT ID, ten, maTheLoai FROM HangHoa ORDER BY ID DESC";
                    SqlDataAdapter da = new SqlDataAdapter(sqlScomm4);
                    da.Fill(dt);
                    dt.Columns[0].Caption = "Tên hàng";
                    dt.Columns["maTheLoai"].Caption = "Thể loại";
                    GridView1.DataSource = dt;
                    //sắp xếp
                    dt.DefaultView.Sort = String.Format("{0} {1}", sortExpression, sortDirection);
                    //dung cai nay de phan trang
                    if (pageIndex >= 0)
                        GridView1.PageIndex = pageIndex;

                    GridView1.DataBind();
                    //Đổi tiêu đề của cột
                    //GridView1.Columns[1].HeaderText = "Tên hàng"; //Cách này sẽ làm mất link dùng để sắp xếp
                    //GridView1.Columns[2].HeaderText = "Thể loại";
                    ((LinkButton)(GridView1.HeaderRow.Cells[0].Controls[0])).Text = "Mã";
                    ((LinkButton)(GridView1.HeaderRow.Cells[1].Controls[0])).Text = "Tên hàng";
                    ((LinkButton)(GridView1.HeaderRow.Cells[2].Controls[0])).Text = "Thể loại";
                }
            }
            catch (Exception exc)
            {
                //MessageBox.Show
                Response.Write(String.Format("Loi: {0}\n{1}", exc.Message, exc.StackTrace));
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

                BindDataToGridView(GridView1.PageIndex, e.SortExpression, sortDirection);
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

    }
}
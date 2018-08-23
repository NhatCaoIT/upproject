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
    public partial class NV3 : System.Web.UI.Page
    {
        string conString; //= @"Data Source = DESKTOP-TSV4T6E\MSSQL2014; Initial Catalog=Sample;User id=log1;Password=1";
        protected void Page_Load(object sender, EventArgs e)
        {
            conString = WebClass.getConnectionStringByName("sqlSConString");
            //Response.Write("conString: "+conString+"<br />");
            if (!Page.IsPostBack)
            {
                #region Đọc dữ liệu và đưa lên danh sách dropdownlist
                //ddlTheLoai.Items.Clear();
                ListItem item0 = new ListItem();
                item0.Value = "-1";
                item0.Text = "Chọn thể loại";
                ddlTheLoai.Items.Add(item0);
               
                try
                {
                    CommonCode.DataClasses.DataTool dataTool = new CommonCode.DataClasses.DataTool();
                        string sql = "SELECT maTheLoai, tenTheLoai FROM TheLoai";
                        SqlDataReader sqlreader = dataTool.execReader(conString, sql, null);
                        if (sqlreader != null && sqlreader.HasRows)
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
                catch (Exception exc)
                {
                    Response.Write(String.Format("Lỗi: {0}. Chi tiết: {1}", exc.Message, exc.StackTrace));
                }
                finally
                {
                }
                #endregion
                //đưa dữ liệu lên Datalist
                BindDataToDataList();
            }
        }

        protected void bThemMoi_Click(object sender, EventArgs e)
        {
            lThongBao.Text = "";
            try
            {
                if (tbID.Text.Trim() == "" || tbTen.Text.Trim() == ""
                    || ddlTheLoai.SelectedIndex == 0 || !FileUploadControl.HasFile)
                {
                    lThongBao.Text = "Phải nhập đủ dữ liệu!";
                    return;
                }
                ///Có thể thêm mã nguồn kiểm tra file tải lên có định dạng như mong muốn hay không
                /// hoặc kích thước đảm bảo yêu cầu không... - dùng FileUploadControl.PostedFile.ContentLength,
                /// FileUploadControl.PostedFile.ContentType...
                

                //Vẫn thêm bản ghi vào bảng HangHoa, giờ có thêm tên file
                string sql = "INSERT INTO HangHoa(ID, Ten, maTheLoai, hinhAnh) VALUES(@id, @ten, @loai, @tenFile)";
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter("id", tbID.Text.Trim()));
                sqlParams.Add(new SqlParameter("ten", tbTen.Text.Trim()));
                sqlParams.Add(new SqlParameter("loai", ddlTheLoai.SelectedValue));
                sqlParams.Add(new SqlParameter("tenFile", string.Format("hangHoa_{0}.jpg", tbID.Text.Trim())));
                CommonCode.DataClasses.DataTool dataTool = new CommonCode.DataClasses.DataTool();
                int cnt = dataTool.execInsUpdDel(conString, sql, sqlParams);
                lThongBao.Text = cnt.ToString() + " đã được thêm thành công!";

                //Lưu file vào thư mục files/img với tên là hangHoa_ID.jpg
                FileUploadControl.SaveAs(string.Format("{0}/files/img/hangHoa_{1}.jpg",
                    Server.MapPath("~"), tbID.Text.Trim()));

                BindDataToDataList();
            }
            catch (Exception exc)
            {
                lThongBao.Text = "Kết nối CSDL thất bại! Lỗi: " + exc.Message + ". " + exc.StackTrace;

            }
            finally
            {
                ///Đặt vấn đề hoặc chỉ thêm được bản ghi hoặc chỉ lưu được file thì sao?
            }
        }

        protected void FileUploadControl_Load(object sender, EventArgs e)
        {
            //FileUploadControl.PostedFile.ContentType
        }

        private void BindDataToDataList()
        {

            try
            {
                string sql = "SELECT ID, ten, maTheLoai, hinhAnh FROM HangHoa ORDER BY ID DESC";
                //CommonCode.DataClasses.DataTool dataTool = new CommonCode.DataClasses.DataTool();
                //DataTable dt = dataTool.execSelect(conString, sql, null);
                //GridView1.DataSource = dataTool.execSelect(conString, sql, null);
                DataList1.DataSource = (new CommonCode.DataClasses.DataTool()).execSelect(conString, sql, null);
                DataList1.DataBind();
            }
            catch (Exception exc)
            {
                //MessageBox.Show
                Response.Write(String.Format("Loi: {0}<br />{1}", exc.Message, exc.StackTrace));
            }
            finally
            {
            }
        }
    }
}
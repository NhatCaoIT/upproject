using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VD10
{
    public partial class NV1 : System.Web.UI.Page
    {
        List<SV> svlist;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Khai báo danh sách các phần tử kiểu SV, class SV được định nghĩa bên dưới
            svlist = new List<SV>();
            if (!IsPostBack) //Lần đầu tiên gọi trang. Sau này click phân trang...là lần gọi sau...
            {
                //Thêm phần tử vào danh sách
                int n = 100;
                Random rd = new Random();
                for (int i = 0; i < n; i++)
                {
                    svlist.Add(new SV(i + 1, "Sinh Viên", rd.Next(1, n).ToString()));
                }
                //svlist.Add(new SV(2, "Sinh Viên", "2"));
                //svlist.Add(new SV(3, "Sinh Viên", "3"));
                //Lưu danh sách vào viestate để sử dụng cho lần load trang sau
                ViewState["svlist"] = svlist;
                //Gắn danh sách làm nguồn dữ liệu cho gridview
                BindDataToGridView(-1);
            }
        }

        public void BindDataToGridView(int pageIndex)
        {
            svlist = (ViewState["svlist"] != null) ? (ViewState["svlist"] as List<SV>) : null;
            GridView1.DataSource = svlist;
            if (pageIndex >= 0) GridView1.PageIndex = pageIndex;
            GridView1.DataBind();
            GridView1.HeaderRow.Cells[0].Text = "Mã SV";
            GridView1.HeaderRow.Cells[1].Text = "Họ lót";
            GridView1.HeaderRow.Cells[2].Text = "Tên";
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Xử lý phân trang ở đây
            BindDataToGridView(e.NewPageIndex);
        }
    }

    [Serializable]
    class SV
    {
        public int iD { get; set; }
        public string hoLot { get; set; }
        public string ten { get; set; }
        public SV(int id, string hl, string t)
        {
            iD = id;
            hoLot = hl;
            ten = t;
        }
    }
}
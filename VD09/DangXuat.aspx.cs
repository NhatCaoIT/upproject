using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VD9
{
    public partial class DangXuat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Xoá tất cả thông tin Session liên quan
            Session["id"] = "";
            Session["hoLot"] = "";
            Session["ten"] = "";
            Session["role"] = "";
            Response.Write("<script>alert('Bạn đã đăng xuất thành công!')</script>");
            Response.Redirect("TrangChu.aspx");
        }
    }
}
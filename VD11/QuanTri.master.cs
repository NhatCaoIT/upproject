using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VD11
{
    public partial class QuanTri : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Nếu chưa đăng nhập thì không có vai trò QT
            if ((string)Session["role"] != "QT")
                Response.Redirect("DangNhap.aspx");
        }
    }
}
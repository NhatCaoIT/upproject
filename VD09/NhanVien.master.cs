using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VD9
{
    public partial class NhanVien : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Nếu chưa đăng nhập thì không có vai trò NV
            if ((string)Session["role"] != "NV")
                Response.Redirect("DangNhap.aspx");
        }
    }
}
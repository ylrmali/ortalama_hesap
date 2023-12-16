using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DonemSonu
{
    public partial class Default : System.Web.UI.Page
    {

        public static class GlobalData
        {
            // tüm sayfalardan ulaşılabilir bir ArrayList oluştur
            public static ArrayList Dersler { get; set; } = new ArrayList();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            error.Visible = false;

            if (mail_box.Text == "ali@pau.com" && pass_box.Text == "123")
            {
                Session["User"] = mail_box.Text;
                Response.Redirect("DersEkle.aspx");
            }
            else
            {
                error.Visible = true;
                mail_box.Text = ""; 
                pass_box.Text = "";
            }
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DonemSonu
{
    public partial class Layout : System.Web.UI.MasterPage
    {

        public static string DersAdınıAl(string metin)
        {
            // secili dersin sadece adını göndürür
            string[] items = metin.Split('|');
            string dersObject = items[0];
            string[] dersObjectList = dersObject.Split(':');
            string dersAdı = dersObjectList[1].Trim();
            return dersAdı;
        }


        public static void NotlarıAl(string metin, out int vize, out int proje, out int final, out int akts)
        {
            /* ArrayList içindeki string ders bilgilerini al,
               Bu veri içindeki not yüzdeliklerini döndür
             */
            vize = 0;
            proje = 0;
            final = 0;
            akts = 0;

            string[] items = metin.Split('|');

            foreach (var item in items)
            {
                string[] objects = item.Split(':');

                if (objects.Length == 2)
                {
                    string key = objects[0].Trim();
                    string value = objects[1].Trim();

                    if (key == "Vize")
                    {
                        int.TryParse(value, out vize);
                    }
                    else if (key == "Proje")
                    {
                        int.TryParse(value, out proje);
                    }
                    else if (key == "Final")
                    {
                        int.TryParse(value, out final);
                    }
                    else if (key == "AKTS")
                    {
                        int.TryParse(value, out akts);
                    }
                }
            }
        }


        public static bool NotToplamKontrol(int vize, int proje, int final)
        {
            /* 
             * Ders eklerken  girilen notların yüzdelik dağılımını kontrol eder
             * Eğer toplam 100'den büyükse false değer döndürür.
            */
            int toplam = vize + proje + final;
            return toplam <= 100;
        }

        public static bool NotKontrol(int not)
        {
            // Girilen notun 100 den küçük olmasını kontrol eder.
            return not <= 100;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect("Giriş.aspx");
            if (Session["User"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Button1.Text = Session["User"].ToString();
            }
            
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Clear();
            Response.Redirect("Default.aspx");
        }

    }
}
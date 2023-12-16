using System;
using System.Linq;
using System.Web;

namespace DonemSonu
{
    public partial class DönemSonuOrtalama : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                double toplam = 0.00;
                // Tüm dersleri session dan al
                string[] keys = HttpContext.Current.Session.Keys.Cast<string>().ToArray();

                // Anahtarları kullanarak değerlere erişmek için
                foreach (string key in keys)
                {
                    if (!key.Equals("Ortalama") && !key.Equals("akts") && 
                        !key.Equals("HarfNotu") && !key.Equals("toplamAkts") && 
                        !key.Equals("User"))
                    {
                        object value = HttpContext.Current.Session[key];
                        string msg = string.Format("Ders Adı: {0} | Kazanılan Puan: {1}", key, value);
                        DersPuanlari.Items.Add(msg);
                        toplam += Convert.ToDouble(value);
                    }
                }

                int AKTS =  Convert.ToInt32(Session["toplamAkts"]);
                double yuzlukOrtalama = (Convert.ToDouble(toplam / AKTS));
                ortalama.Text = DortlukPuan(yuzlukOrtalama).ToString();
                ortalama.Visible = true;
            }
        }

        public double DortlukPuan(double yuzlukPuan)
        {
            // 100 luk puan notunu 4 luk puan notuna cevirir.
            double dortluk = (yuzlukPuan / 100) * 4;
            return Math.Round(dortluk, 2);
        }
    }
}
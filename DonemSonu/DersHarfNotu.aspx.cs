using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DonemSonu
{
    public partial class DersHarfNotu : System.Web.UI.Page
    {

        protected void FillDropdown()
        {
            if (!IsPostBack) {
                ArrayList Dersler = (ArrayList)Application["Dersler"];
                if (Dersler != null)
                {
                    foreach (var ders in Dersler)
                    {
                        dersler_dropdown.Items.Add(ders.ToString());
                    }
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           FillDropdown();
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public string HarfNotuHesapla(int vize, int proje, int final, 
                                   int ogr_vize, int ogr_proje, int ogr_final) {
            /* dersin yüzdelik dağılını alır ve hesaplamayı gerçekleştirip, 
             * sonucu geri döndürür 
            */
            double result_vize = Convert.ToDouble(ogr_vize) * Convert.ToDouble(vize) / Convert.ToDouble(100);
            double result_proje = Convert.ToDouble(ogr_proje) * Convert.ToDouble(proje) / Convert.ToDouble(100);
            double result_final = Convert.ToDouble(ogr_final) * Convert.ToDouble(final) / Convert.ToDouble(100);
            double total = result_vize + result_proje + result_final;

            string harfNotu = "";


            if (ogr_final < 40)
            {
                harfNotu = string.Format("F1 Kalir - {0} | Final notu 40'ın altında", total);
                return harfNotu;
            }
            
            if (total >= 90)
            {
                harfNotu = string.Format("A1 - {0} Geçer", total);
            }
            else if (total >= 80)
            {
                harfNotu = string.Format("A2 - {0} Geçer", total);
            }
            else if (total >= 75)
            {
                harfNotu = string.Format("B1 - {0} Geçer", total);
            }
            else if (total >= 70)
            {
                harfNotu = string.Format("B2 - {0} Geçer", total);
            }
            else if (total >= 65)
            {
                harfNotu = string.Format("C1 Geçer", total);
            }
            else if (total >= 60)
            {
                harfNotu = string.Format("C2 - {0} Geçer", total);
            }
            else if (total >= 55)
            {
                harfNotu = string.Format("D1 - {0} Koşullu Geçer", total);
            }
            else if (total >= 50)
            {
                harfNotu = string.Format("D2 - {0} Koşullu Geçer", total);
            }
            else if (total >= 40)
            {
                harfNotu = string.Format("E - {0} Kalır", total);
            }
            else if (total >= 0)
            {
                harfNotu = string.Format("F1 - {0} Kalır", total);
            }

            Session["Ortalama"] = total;
            Session["HarfNotu"] = harfNotu.Split('-')[0];
            return harfNotu;
        }

        protected void hesapla_btn_Click(object sender, EventArgs e)
        {
            error.Visible = false;
            accept_btn.Visible = false;
            string seciliDers = dersler_dropdown.SelectedValue.ToString();
            ListBox1.Items.Clear();
            int vize, proje, final, akts;
            Layout.NotlarıAl(seciliDers, out vize, out proje, out final, out akts);
            // kullanıcının yolladıgı verilerin kontrolunu yap
            string ogr_vize = vize_not.Text;
            string ogr_proje = proje_not.Text;
            string ogr_final = final_not.Text;
            if (string.IsNullOrEmpty(ogr_vize) || 
                string.IsNullOrEmpty(ogr_proje) ||
                string.IsNullOrEmpty(ogr_final))
            {
                // eger bos bir alan varsa hata mesajını göster
                error.Visible = true; return;
            }
            else
            {
                // not kontrolu
                if (Layout.NotKontrol(Convert.ToInt32(ogr_vize)) &
                     Layout.NotKontrol(Convert.ToInt32(ogr_proje)) &
                     Layout.NotKontrol(Convert.ToInt32(ogr_final)))
                {
                    // verilerle beraber hesapla işlemini yap
                    ListBox1.Items.Add(seciliDers);
                    string sonuc = HarfNotuHesapla(vize, proje, final,
                        Convert.ToInt32(ogr_vize), Convert.ToInt32(ogr_proje), Convert.ToInt32(ogr_final));
                    ListBox1.Items.Add(sonuc);
                    ListBox1.Visible = true;
                    accept_btn.Visible = true;
                    int prevAkts = Convert.ToInt32(Session["toplamAkts"]);
                    Session["toplamAkts"] = prevAkts + Convert.ToInt32(akts);
                    Session["akts"] = akts;
                }
                else
                {
                    error.Text = "Notlar 100' den büyük olamaz";
                    error.Visible = true;
                    return;
                }
            }
        }

        protected void accept_btn_Click(object sender, EventArgs e)
        {
            // eskileri temizle
            error.Visible = false;
            accept_btn.Visible = false;

            string dersAdı = Layout.DersAdınıAl(dersler_dropdown.SelectedValue.ToString());
            double sonuc = Convert.ToDouble(Session["Ortalama"]) * Convert.ToInt32(Session["akts"]);
            Session[dersAdı] = sonuc.ToString();
            error.Text = "Ders ortalaması başarılıyla kaydedildi!";
            error.Visible = true;
        }
    }
}
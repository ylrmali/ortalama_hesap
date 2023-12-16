using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DonemSonu
{
    public partial class DersEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArrayList Dersler = (ArrayList)Application["Dersler"];
                if (Dersler != null)
                {
                    // Daha önceden Defalt.aspx de tanımlanmıs dersler listesini al
                    // Array içindeki ders bilgilerini listbox da görüntüle
                    foreach (var item in Dersler)
                    {
                        dersler.Items.Add(item.ToString());
                    }
                }
                else
                {
                    Session["toplamAkts"] = 0;
                }

            }
        }

        public bool HataliNotKontrol(int vize, int proje, int final)
        {
            // true = hata var 
            return (vize + final + proje) < 100;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label5.Visible = false;

            string ders = ders_textBox.Text;
            string vize = vize_ort.Text;
            string proje = proje_ort.Text;
            string final = final_ort.Text;
            string Akts = akts.Text;

            if (string.IsNullOrEmpty(ders) || string.IsNullOrEmpty(vize) || 
                string.IsNullOrEmpty(proje) || string.IsNullOrEmpty(final) || 
                string.IsNullOrEmpty(Akts))
            {
                Label5.Visible = true;
                return;
            }
            else
            {
                bool v =  Layout.NotKontrol(Convert.ToInt32(vize));
                bool p = Layout.NotKontrol(Convert.ToInt32(proje));
                bool f =  Layout.NotKontrol(Convert.ToInt32(final));
                


                // her notun kontrolu
                if (!v || !p || !f ) 
                {
                    Label5.Text = "Not yüzdeleri 100'den büyük olamaz";
                    Label5.Visible = true;
                    return;
                }

                // Not dağılım toplam kontrolu
                if (!Layout.NotToplamKontrol(
                    Convert.ToInt32(vize),
                    Convert.ToInt32(proje),
                    Convert.ToInt32(final)))
                {
                    Label5.Text = "Not dağılım toplamı 100'den büyük olamaz";
                    Label5.Visible = true;
                    return;
                }

                if (HataliNotKontrol(
                    Convert.ToInt32(vize),
                    Convert.ToInt32(proje),
                    Convert.ToInt32(final)))
                {
                    Label5.Text = "Not dağılım toplamı 100'den küçük olamaz";
                    Label5.Visible = true;
                    return;
                }
                    

                ArrayList Dersler = (ArrayList)Application["Dersler"];
                if (Dersler == null)
                {
                    Dersler = new ArrayList();
                    Application["Dersler"] = Dersler;
                }

                string dersItem = string.Format(
                                    "Ders: {0} | Vize: {1} | Proje: {2} | Final: {3} | AKTS: {4}", 
                                    ders, vize, proje, final, Akts);
                Dersler.Add(dersItem); // yeni eklenen veriyi Desrler listesine ekle
                

                // Eklemeden sonra listbox i temizle ve tüm verileri tekrar yazdır.
                dersler.Items.Clear(); // Önceki verileri temizle
                foreach (var item in Dersler)
                {
                    dersler.Items.Add(item.ToString());
                }
            }
        }

    }
}
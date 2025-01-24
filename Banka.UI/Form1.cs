using Banka.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banka.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pnlKurumsal.Location = pnlBireysel.Location;

            MusteriYukle();
        }

        private void MusteriYukle()
        {
            BireyselMusteri bm = new BireyselMusteri()
            {
                Adres = "Karşıyaka",
                AnneSoyad = "Yılmaz",
                Bakiye = 20000,
                KimlikNo = "13213254688",
                MusteriAd = "Ali",
                MusteriNo = "125",
                Soyad = "Veli",
                Telefon = "555 55 55",
                //DogumTarih=DateTime.Now.Add(-25)
                //DogumTarih = DateTime.Parse("11.10.2000")
                DogumTarih = Convert.ToDateTime("11.10.2000")

            };
            lbxMusteri.Items.Add(bm);
            cmbAlici.Items.Add(bm);

            KurumsalMusteri km = new KurumsalMusteri()
            {
                Adres = "Bornova",
                Bakiye=500000,
                MusteriAd = "Koç İnşaat",
                MusteriNo = "326",
                Telefon = "333 33 33",
                VergiDairesi = "Konak",
                VergiNo = "348674",
                Yetkili = "Emre Koç"

            };
            lbxMusteri.Items.Add(km);
            cmbAlici.Items.Add(km);
        }

        private void rbBireysel_CheckedChanged(object sender, EventArgs e)
        {
            pnlBireysel.Visible = rbBireysel.Checked;
            pnlKurumsal.Visible = rbKurumsal.Checked;
        }

        private void lbxMusteri_SelectedIndexChanged(object sender, EventArgs e)
        {
            Musteri secilen = lbxMusteri.SelectedItem as Musteri;

            if(secilen == null)  //Listboxtan seçim yapılmamıştır.
            {
                return;
            }
            MusteriGoster(secilen);
            btnKaydet.Text = "Güncelle";
        }

        private void MusteriGoster(Musteri secilen) //seçilen müşterinin ne müşterisi olduğu
        {
            
            if (secilen is BireyselMusteri)
            {
                BireyselMusteri musteri = secilen as BireyselMusteri;
                txtSoyad.Text = musteri.Soyad;
                txtAnneSoyad.Text = musteri.AnneSoyad;
                txtTCNo.Text = musteri.KimlikNo;
                dtDogum.Value = musteri.DogumTarih;
                rbBireysel.Checked = true;
            }
            else
            {
                KurumsalMusteri musteri = secilen as KurumsalMusteri;
                txtVergiDaire.Text = musteri.VergiDairesi;
                txtVergiNo.Text = musteri.VergiNo;
                txtYetkili.Text = musteri.Yetkili;
                rbKurumsal.Checked = true;
            }
            txtAd.Text = secilen.MusteriAd;
            txtAdres.Text = secilen.Adres;
            txtBakiye.Text = secilen.Bakiye.ToString();
            txtMusteriNo.Text = secilen.MusteriNo;
            txtTelefon.Text = secilen.Telefon;
            rbBireysel.Enabled = rbKurumsal.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void Temizle()
        {
            foreach  (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = null;
                }
            }
            foreach (Control item in this.pnlBireysel.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = null;
                }
            }
            foreach (Control item in this.pnlKurumsal.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = null;
                }
            }
            dtDogum.Value = DateTime.Now;
            rbBireysel.Enabled = rbKurumsal.Enabled = true;
            rbBireysel.Checked = true;
            lbxMusteri.SelectedItem = null;
            cmbAlici.SelectedItem = null;
            btnKaydet.Text = "KAYDET";
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            MusteriKaydet();
        }

        private void MusteriKaydet()
        {
            Musteri musteri = lbxMusteri.SelectedItem as Musteri;

            int index = lbxMusteri.Items.Count;

            if (musteri != null)
            {
                index = lbxMusteri.Items.IndexOf(musteri);
                //lbxMusteri.Items.Remove(musteri);
                lbxMusteri.Items.RemoveAt(index);
                cmbAlici.Items.RemoveAt(index);
            }

            if (rbBireysel.Checked)//Bireysel Müşteri
            {
                musteri = new BireyselMusteri()
                {
                    Soyad = txtSoyad.Text,
                    AnneSoyad = txtAnneSoyad.Text,
                    DogumTarih = dtDogum.Value,
                    KimlikNo = txtTCNo.Text
                };

            }
            else//Kurumsal Müşteri
            {
                musteri = new KurumsalMusteri()
                {
                    VergiDairesi = txtVergiDaire.Text,
                    VergiNo = txtVergiNo.Text,
                    Yetkili = txtYetkili.Text
                };
            }
            musteri.MusteriAd = txtAd.Text;
            musteri.Adres = txtAdres.Text;
            musteri.MusteriNo = txtMusteriNo.Text;
            musteri.Bakiye = double.Parse(txtBakiye.Text);
            musteri.Telefon = txtTelefon.Text;

            lbxMusteri.Items.Insert(index, musteri);
            cmbAlici.Items.Insert(index, musteri);
            Temizle();
        }

        private void btnHavale_Click(object sender, EventArgs e)
        {
            pnlHavale.Visible = !pnlHavale.Visible;
        }

        private void btnParaCek_Click(object sender, EventArgs e)
        {
            //Musteri secilen = lbxMusteri.SelectedItem as Musteri;
            Musteri secilen = (Musteri)lbxMusteri.SelectedItem;
            if (secilen==null)
            {
                MessageBox.Show("Hesap Seçmediniz");
                return;
            }

            frmBakiyeislemleri frm = new frmBakiyeislemleri(secilen, IslemTipi.PCEK);
            frm.BakiyeYenile += Frm_BakiyeYenile;
            frm.ShowDialog();
        }

        private void Frm_BakiyeYenile(Musteri musteri)
        {
            MusteriGoster(musteri);
        }

        private void btnPYatir_Click(object sender, EventArgs e)
        {
            Musteri secilen = (Musteri)lbxMusteri.SelectedItem;
            if (secilen == null)
            {
                MessageBox.Show("Hesap Seçmediniz");
                return;
            }

            frmBakiyeislemleri frm = new frmBakiyeislemleri(secilen, IslemTipi.PYATIR);
            frm.BakiyeYenile += Frm_BakiyeYenile;
            frm.ShowDialog();

        }

        private void btnAlici_Click(object sender, EventArgs e)
        {
            Musteri gond = (Musteri)lbxMusteri.SelectedItem;
            Musteri alan = (Musteri)cmbAlici.SelectedItem;

            if (gond == null)
            {
                MessageBox.Show("Gönderici Hesabı Seçmediniz!");
                return;
            }
            if (alan == null)
            {
                MessageBox.Show("Alıcı Hesabı Seçmediniz!");
                return;
            }
            if (gond == alan)
            {
                MessageBox.Show("Gönderici-Alıcı Aynı Olamaz");
                return;
            }

            frmBakiyeislemleri frm = new frmBakiyeislemleri(gond, alan);
            frm.BakiyeYenile += Frm_BakiyeYenile;

            frm.ShowDialog();
        }
    }
}

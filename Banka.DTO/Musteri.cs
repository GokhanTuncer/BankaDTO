using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka.DTO
{
    public abstract class Musteri
    {
        public string MusteriNo { get; set; }
        public string MusteriAd { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public double Bakiye { get; set; }

        public void ParaCek(double miktar) 
        {
            if (this.Bakiye >= miktar) //Bakiye yeterli ise
            {
                this.Bakiye -= miktar;
                System.Windows.Forms.MessageBox.Show("Islem Tamam!\n Yeni Bakiye:" + this.Bakiye);
            }
            else                     //Bakiye yetersiz ise
            {
                System.Windows.Forms.MessageBox.Show("HATA!\nÇekilebilecek tutar: "+ this.Bakiye);
            }
        }
        public void ParaYatir(double miktar) 
        {
            this.Bakiye += miktar;
            System.Windows.Forms.MessageBox.Show("Islem Tamam!\n Yeni Bakiye:" + this.Bakiye);
        }
        public virtual void Havale(double miktar, Musteri Alici) //Kalıtım alan diğer sınıflarda ezebiliriz.(Override)
        {
            double masraf = 100;

            if (this.Bakiye >= (miktar+masraf)) //Bakiye yeterli ise
            {
                this.Bakiye -= (miktar + masraf);
                Alici.Bakiye += miktar;

                System.Windows.Forms.MessageBox.Show("Islem Tamam!\n Yeni Bakiye:" + this.Bakiye);
            }
            else                     //Bakiye yetersiz ise
            {
                System.Windows.Forms.MessageBox.Show("HATA!\nÇekilebilecek tutar: " + this.Bakiye);
            }
        }
    }
}

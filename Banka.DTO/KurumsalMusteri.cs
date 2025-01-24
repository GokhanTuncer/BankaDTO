using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Banka.DTO
{
    public class KurumsalMusteri : Musteri
    {
        public string Yetkili { get; set; }
        public string VergiNo { get; set; }
        public string VergiDairesi { get; set; }

        public override void Havale(double miktar, Musteri Alici)
        {
            if (this.Bakiye >= miktar) //Bakiye yeterli ise
            {
                this.Bakiye -= miktar;
                Alici.Bakiye += miktar;

                System.Windows.Forms.MessageBox.Show("Islem Tamam!\n Yeni Bakiye:" + this.Bakiye);
            }
            else                     //Bakiye yetersiz ise
            {
                System.Windows.Forms.MessageBox.Show("HATA!\nÇekilebilecek tutar: " + this.Bakiye);
            }
            
        }
        public override string ToString()
        {
            return this.MusteriNo + "-" + this.MusteriAd.ToUpper() + "(Kurumsal)";
        }
        
    }
}

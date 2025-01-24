using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka.DTO
{
    public class BireyselMusteri : Musteri
    {
        public string Soyad { get; set; }
        public string AnneSoyad { get; set; }
        public DateTime DogumTarih { get; set; }
        public string KimlikNo { get; set; }

        public override string ToString()
        {
            return this.MusteriNo + "-" + this.MusteriAd.Substring(0,1).ToUpper()+this.MusteriAd.Substring(1).ToLower() + " " + this.Soyad.ToUpper();
        }
    }
}

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
    public partial class frmBakiyeislemleri : Form
    {
        public delegate void MyEventHandler(Musteri musteri);
        public event MyEventHandler BakiyeYenile;

        Musteri HESAPSAHIBI, ALICI;
        IslemTipi ISLEM;
        public frmBakiyeislemleri(Musteri gelen, IslemTipi islem)
        {
            InitializeComponent();
            HESAPSAHIBI = gelen;
            ISLEM = islem;
        }
        public frmBakiyeislemleri(Musteri gond, Musteri alan)
        {
            InitializeComponent();
            HESAPSAHIBI = gond;
            ALICI = alan;
            ISLEM = IslemTipi.HAVALEYAP;
        }

        private void btnOnay_Click(object sender, EventArgs e)
        {
            double miktar = double.Parse(txtTutar.Text);

            switch (ISLEM)
            {
                case IslemTipi.PCEK: HESAPSAHIBI.ParaCek(miktar); break;
                case IslemTipi.PYATIR: HESAPSAHIBI.ParaYatir(miktar); break;
           



            }
            BakiyeYenile(HESAPSAHIBI);
            this.Close();
        }

        private void frmBakiyeislemleri_Load(object sender, EventArgs e)
        {
            switch (ISLEM)
            {
                case IslemTipi.PCEK:lblMesaj.Text = "Çekilecek Tutarı Giriniz:"; break;
                case IslemTipi.PYATIR:lblMesaj.Text = "Yatırılacak Tutarı Giriniz:";break;
                case IslemTipi.HAVALEYAP:lblMesaj.Text = "Havale Tutarını Giriniz:";break;
           
               
            }
        }
    }
}

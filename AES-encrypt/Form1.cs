using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AES_encrypt.Lib;
namespace AES_encrypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btMaHoa_Click(object sender, EventArgs e)
        {
            Enmode128();
            //if (rd128.checked) Enmode128();
            //else if (rd192.checked) Enmode192();
            //else if (rd256.checked) Enmode256();
        }


        private void Enmode128 ()
        {
            tbBanRo.Text = "MDEyMzQ1Njc4OWFiY2RlZg==";
            tbKhoa.Text = "MDEyMzQ1Njc4OWFiY2RlZg==";
            foreach(byte b in System.Convert.FromBase64String(tbKhoa.Text))
            {
                Console.Write($"{b,0:x}");
            }
            return;
            Regex reBanro = new Regex(@"^([A-za-z0-9+/=])*$");
            Regex reKhoa = new Regex(@"^([A-za-z0-9+/=]){24}$");
            if (!reBanro.IsMatch(tbBanRo.Text))
            {
                MessageBox.Show("Sai định dạng bản rõ, bản rõ cần ở ở định dạng base64");
                return;
            }
            if (!reKhoa.IsMatch(tbKhoa.Text))
            {
                MessageBox.Show("Sai định dạng khoá, khoá cần ở định dạng base 64, độ dài 24 ký tự");
                return;
            }
            string[] sbanro = tbBanRo.Text.Split(',');
            string[] skhoa = tbKhoa.Text.Split(',');
            byte[] bbanro = new byte[sbanro.Length];
            byte[] bkhoa = new byte[skhoa.Length];

            DateTime time1 = DateTime.Now;
            AESCore core = new AESCore();
            for (int i = 0; i < sbanro.Length; i++)
            {
                bbanro[i] = Byte.Parse(sbanro[i]);
            }
            for (int i = 0; i < skhoa.Length; i++)
            {
                bkhoa[i] = Byte.Parse(skhoa[i]);
            }
            byte[] bbanma = core.Encrypt128bit(bbanro, bkhoa);
            tbBanMa.Text = String.Join(",", bbanma);
            DateTime time2 = DateTime.Now;
            TimeSpan span = time2.Subtract(time1);
            ETime.Text = "" + span.TotalSeconds + " Giây";
        }

        private void Enmode192()
        {
            tbBanRo.Text = "31,32,31,32,31,32,31,32,31,32,31,32,31,32,31,32";
            tbKhoa.Text = "33,33,33,33,33,33,33,33,33,33,33,20,20,33,33,33";
            Regex reBanro = new Regex(@"^[0-9]{1,3}(,[0-9]{1,3})*$");
            Regex reKhoa = new Regex(@"^([0-9]{1,3}){1}(,[0-9]{1,3}){23}$");
            if (!reBanro.IsMatch(tbBanRo.Text))
            {
                MessageBox.Show("Sai định dạng bản rõ (vd : 1,2,3,4,...)");
                return;
            }
            if (!reKhoa.IsMatch(tbKhoa.Text))
            {
                MessageBox.Show("Sai định dạng khoá (vd : 1,2,3,4,...), độ dài phải bằng 192bit ~ 24byte");
                return;
            }
            string[] sbanro = tbBanRo.Text.Split(',');
            string[] skhoa = tbKhoa.Text.Split(',');
            byte[] bbanro = new byte[sbanro.Length];
            byte[] bkhoa = new byte[skhoa.Length];

            for (int i = 0; i < sbanro.Length; i++)
            {
                bbanro[i] = Byte.Parse(sbanro[i]);
            }
            for (int i = 0; i < skhoa.Length; i++)
            {
                bkhoa[i] = Byte.Parse(skhoa[i]);
            }
            DateTime time1 = DateTime.Now;
            AESCore core = new AESCore();
            byte[] bbanma = core.Encrypt192bit(bbanro, bkhoa);
            tbBanMa.Text = String.Join(",", bbanma);
            DateTime time2 = DateTime.Now;
            TimeSpan span = time2.Subtract(time1);
            ETime.Text = "" + span.TotalSeconds + " Giây";
        }

        private void Enmode256()
        {
            tbBanRo.Text = "48,49,50,51,52,53,54,55,56,57,97,98,99,100,101,102";
            tbKhoa.Text = "48,49,50,51,52,53,54,55,56,57,97,98,99,100,101,102,48,49,50,51,52,53,54,55,56,57,97,98,99,100,101,102";
            Regex reBanro = new Regex(@"^[0-9]{1,3}(,[0-9]{1,3})*$");
            Regex reKhoa = new Regex(@"^([0-9]{1,3}){1}(,[0-9]{1,3}){31}$");
            if (!reBanro.IsMatch(tbBanRo.Text))
            {
                MessageBox.Show("Sai định dạng bản rõ (vd : 1,2,3,4,...)");
                return;
            }
            if (!reKhoa.IsMatch(tbKhoa.Text))
            {
                MessageBox.Show("Sai định dạng khoá (vd : 1,2,3,4,...), độ dài phải bằng 256bit ~ 32byte");
                return;
            }

            string[] sbanro = tbBanRo.Text.Split(',');
            string[] skhoa = tbKhoa.Text.Split(',');
            byte[] bbanro = new byte[sbanro.Length];
            byte[] bkhoa = new byte[skhoa.Length];
            for (int i = 0; i < sbanro.Length; i++)
            {
                bbanro[i] = Byte.Parse(sbanro[i]);
            }
            for (int i = 0; i < skhoa.Length; i++)
            {
                bkhoa[i] = Byte.Parse(skhoa[i]);
            }
            DateTime time1 = DateTime.Now;
            AESCore core = new AESCore();
            byte[] bbanma = core.Encrypt256bit(bbanro, bkhoa);
            tbBanMa.Text = String.Join(",", bbanma);
            DateTime time2 = DateTime.Now;
            TimeSpan span = time2.Subtract(time1);
            ETime.Text = "" + span.TotalSeconds + " Giây";
        }

        private void btGiaiMa_Click(object sender, EventArgs e)
        {
            if (rd128.Checked) Demode128();
            else if (rd192.Checked) Demode192();
            else if (rd256.Checked) Demode256();
        }

        private void Demode128()
        {
            tbDBanMa.Text = "114,114,126,136,30,220,253,1,0,167,24,104,121,9,181,101";
            tbDKhoa.Text = "48,49,50,51,52,53,54,55,56,57,97,98,99,100,101,102";
            Regex reBanma = new Regex(@"^[0-9]{1,3}(,[0-9]{1,3})*$");
            Regex reKhoa = new Regex(@"^([0-9]{1,3}){1}(,[0-9]{1,3}){15}$");
            if (!reBanma.IsMatch(tbDBanMa.Text))
            {
                MessageBox.Show("Sai định dạng bản mã (vd : 1,2,3,4,...)");
                return;
            }
            if (!reKhoa.IsMatch(tbDKhoa.Text))
            {
                MessageBox.Show("Sai định dạng khoá (vd : 1,2,3,4,...), độ dài phải bằng 128bit ~ 16byte");
                return;
            }
            string[] sbanma = tbDBanMa.Text.Split(',');
            string[] skhoa = tbDKhoa.Text.Split(',');
            byte[] bbanma = new byte[sbanma.Length];
            byte[] bkhoa = new byte[skhoa.Length];

            DateTime time1 = DateTime.Now;
            AESCore core = new AESCore();
            for (int i = 0; i < sbanma.Length; i++)
            {
                bbanma[i] = Byte.Parse(sbanma[i]);
            }
            for (int i = 0; i < skhoa.Length; i++)
            {
                bkhoa[i] = Byte.Parse(skhoa[i]);
            }
            byte[] bbanro = core.Decrypt128bit(bbanma, bkhoa);
            tbDBanRo.Text = String.Join(",", bbanro);
            DateTime time2 = DateTime.Now;
            TimeSpan span = time2.Subtract(time1);
            DTime.Text = "" + span.TotalSeconds + " Giây";
        }

        private void Demode192()
        {
            tbDBanMa.Text = "A1,40,04,F8,09,0D,16,AA,D9,9C,41,12,8C,FF,E7,B0";
            tbDKhoa.Text = "33,33,33,33,33,33,33,33,33,33,33,20,20,33,33,33";
            Regex reBanma = new Regex(@"^[0-9]{1,3}(,[0-9]{1,3})*$");
            Regex reKhoa = new Regex(@"^([0-9]{1,3}){1}(,[0-9]{1,3}){23}$");
            if (!reBanma.IsMatch(tbDBanMa.Text))
            {
                MessageBox.Show("Sai định dạng bản mã (vd : 1,2,3,4,...)");
                return;
            }
            if (!reKhoa.IsMatch(tbDKhoa.Text))
            {
                MessageBox.Show("Sai định dạng khoá (vd : 1,2,3,4,...), độ dài phải bằng 128bit ~ 16byte");
                return;
            }
            string[] sbanma = tbDBanMa.Text.Split(',');
            string[] skhoa = tbDKhoa.Text.Split(',');
            byte[] bbanma = new byte[sbanma.Length];
            byte[] bkhoa = new byte[skhoa.Length];

            DateTime time1 = DateTime.Now;
            AESCore core = new AESCore();
            for (int i = 0; i < sbanma.Length; i++)
            {
                bbanma[i] = Byte.Parse(sbanma[i]);
            }
            for (int i = 0; i < skhoa.Length; i++)
            {
                bkhoa[i] = Byte.Parse(skhoa[i]);
            }
            byte[] bbanro = core.Decrypt192bit(bbanma, bkhoa);
            tbDBanRo.Text = String.Join(",", bbanro);
            DateTime time2 = DateTime.Now;
            TimeSpan span = time2.Subtract(time1);
            DTime.Text = "" + span.TotalSeconds + " Giây";
        }


        private void Demode256()
        {
            tbDBanMa.Text = "248,60,154,96,220,12,219,152,33,159,121,214,213,219,22,53";
            tbDKhoa.Text = "48,49,50,51,52,53,54,55,56,57,97,98,99,100,101,102,48,49,50,51,52,53,54,55,56,57,97,98,99,100,101,102";
            Regex reBanma = new Regex(@"^[0-9]{1,3}(,[0-9]{1,3})*$");
            Regex reKhoa = new Regex(@"^([0-9]{1,3}){1}(,[0-9]{1,3}){31}$");
            if (!reBanma.IsMatch(tbDBanMa.Text))
            {
                MessageBox.Show("Sai định dạng bản mã (vd : 1,2,3,4,...)");
                return;
            }
            if (!reKhoa.IsMatch(tbDKhoa.Text))
            {
                MessageBox.Show("Sai định dạng khoá (vd : 1,2,3,4,...), độ dài phải bằng 128bit ~ 16byte");
                return;
            }
            string[] sbanma = tbDBanMa.Text.Split(',');
            string[] skhoa = tbDKhoa.Text.Split(',');
            byte[] bbanma = new byte[sbanma.Length];
            byte[] bkhoa = new byte[skhoa.Length];

            DateTime time1 = DateTime.Now;
            AESCore core = new AESCore();
            for (int i = 0; i < sbanma.Length; i++)
            {
                bbanma[i] = Byte.Parse(sbanma[i]);
            }
            for (int i = 0; i < skhoa.Length; i++)
            {
                bkhoa[i] = Byte.Parse(skhoa[i]);
            }
            byte[] bbanro = core.Decrypt256bit(bbanma, bkhoa);
            tbDBanRo.Text = String.Join(",", bbanro);
            DateTime time2 = DateTime.Now;
            TimeSpan span = time2.Subtract(time1);
            DTime.Text = "" + span.TotalSeconds + " Giây";
        }
        
    }
}

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
            if (rd128.Checked) Enmode128();
            else if (rd192.Checked) Enmode192();
            else if (rd256.Checked) Enmode256();
        }


        private void Enmode128 ()
        {
            tbBanRo.Text = "MDEyMzQ1Njc4OWFiY2VkZQ==";
            tbKhoa.Text = "MDEyMzQ1Njc4OWFiY2VkZQ==";
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

            DateTime time1 = DateTime.Now;
            AESCore core = new AESCore();
            byte[] bbanma = core.Encrypt128bit(
                    System.Convert.FromBase64String(tbBanRo.Text),
                    System.Convert.FromBase64String(tbKhoa.Text)
                );
            tbBanMa.Text = System.Convert.ToBase64String(bbanma);
            DateTime time2 = DateTime.Now;
            TimeSpan span = time2.Subtract(time1);
            ETime.Text = "" + span.TotalSeconds + " Giây";
        }

        private void Enmode192()
        {
            tbBanRo.Text = "MDEyMzQ1Njc4OWFiY2VkZQ==";
            tbKhoa.Text = "MDEyMzQ1Njc4OWFiY2VkZTAxMjM0NTY3";
            Regex reBanro = new Regex(@"^([A-za-z0-9+/=])*$");
            Regex reKhoa = new Regex(@"^([A-za-z0-9+/=]){32}$");
            if (!reBanro.IsMatch(tbBanRo.Text))
            {
                MessageBox.Show("Sai định dạng bản rõ, bản rõ cần ở ở định dạng base64");
                return;
            }
            if (!reKhoa.IsMatch(tbKhoa.Text))
            {
                MessageBox.Show("Sai định dạng khoá, khoá cần ở định dạng base 64, độ dài 32 ký tự");
                return;
            }
            DateTime time1 = DateTime.Now;
            AESCore core = new AESCore();
            byte[] banma = core.Encrypt192bit(
                    System.Convert.FromBase64String(tbBanRo.Text),
                    System.Convert.FromBase64String(tbKhoa.Text)
                );
            tbBanMa.Text = System.Convert.ToBase64String(banma);
            DateTime time2 = DateTime.Now;
            TimeSpan span = time2.Subtract(time1);
            ETime.Text = "" + span.TotalSeconds + " Giây";
        }

        private void Enmode256()
        {
            tbBanRo.Text = "MDEyMzQ1Njc4OWFiY2VkZQ==";
            tbKhoa.Text = "MDEyMzQ1Njc4OWFiY2VkZTAxMjM0NTY3ODlhYmNlZGU=";
            Regex reBanro = new Regex(@"^([A-za-z0-9+/=])*$");
            Regex reKhoa = new Regex(@"^([A-za-z0-9+/=]){44}$");
            if (!reBanro.IsMatch(tbBanRo.Text))
            {
                MessageBox.Show("Sai định dạng bản rõ, bản rõ cần ở ở định dạng base64");
                return;
            }
            if (!reKhoa.IsMatch(tbKhoa.Text))
            {
                MessageBox.Show("Sai định dạng khoá, khoá cần ở định dạng base 64, độ dài 44 ký tự");
                return;
            }
            DateTime time1 = DateTime.Now;
            AESCore core = new AESCore();
            byte[] banma = core.Encrypt256bit(
                    System.Convert.FromBase64String(tbBanRo.Text),
                    System.Convert.FromBase64String(tbKhoa.Text)
                );
            tbBanMa.Text = System.Convert.ToBase64String(banma);
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
            tbDBanMa.Text = "IF0fwnGtvaoN8BNKr85g9Q==";
            tbDKhoa.Text = "MDEyMzQ1Njc4OWFiY2VkZQ==";
            Regex reBanma = new Regex(@"^([A-za-z0-9+/=])*$");
            Regex reKhoa = new Regex(@"^([A-za-z0-9+/=]){24}$");
            if (!reBanma.IsMatch(tbDBanMa.Text))
            {
                MessageBox.Show("Sai định dạng bản mã, bản mã cần ở định dạng base64");
                return;
            }
            if (!reKhoa.IsMatch(tbDKhoa.Text))
            {
                MessageBox.Show("Sai định dạng khoá, khoá cần ở định dạng base 64, độ dài 24 ký tự");
                return;
            }

            DateTime time1 = DateTime.Now;
            AESCore core = new AESCore();
            byte[] banro = core.Decrypt128bit(
                    System.Convert.FromBase64String(tbDBanMa.Text),
                    System.Convert.FromBase64String(tbDKhoa.Text)
                );
            tbDBanRo.Text = System.Convert.ToBase64String(banro);
            DateTime time2 = DateTime.Now;
            TimeSpan span = time2.Subtract(time1);
            DTime.Text = "" + span.TotalSeconds + " Giây";
        }

        private void Demode192()
        {
            tbDBanMa.Text = "JsyGY6MZ5v97rFDvqX1CKg==";
            tbDKhoa.Text = "MDEyMzQ1Njc4OWFiY2VkZTAxMjM0NTY3";
            Regex reBanma = new Regex(@"^([A-za-z0-9+/=])*$");
            Regex reKhoa = new Regex(@"^([A-za-z0-9+/=]){32}$");
            if (!reBanma.IsMatch(tbDBanMa.Text))
            {
                MessageBox.Show("Sai định dạng bản mã, bản mã cần ở định dạng base64");
                return;
            }
            if (!reKhoa.IsMatch(tbDKhoa.Text))
            {
                MessageBox.Show("Sai định dạng khoá, khoá cần ở định dạng base 64, độ dài 32 ký tự");
                return;
            }

            DateTime time1 = DateTime.Now;
            AESCore core = new AESCore();
            byte[] banro = core.Decrypt192bit(
                    System.Convert.FromBase64String(tbDBanMa.Text),
                    System.Convert.FromBase64String(tbDKhoa.Text)
                );
            tbDBanRo.Text = System.Convert.ToBase64String(banro);
            DateTime time2 = DateTime.Now;
            TimeSpan span = time2.Subtract(time1);
            DTime.Text = "" + span.TotalSeconds + " Giây";
        }


        private void Demode256()
        {
            tbDBanMa.Text = "oJyvTscsUNC5ZoqfbT86AQ==";
            tbDKhoa.Text = "MDEyMzQ1Njc4OWFiY2VkZTAxMjM0NTY3ODlhYmNlZGU=";
            Regex reBanma = new Regex(@"^([A-za-z0-9+/=])*$");
            Regex reKhoa = new Regex(@"^([A-za-z0-9+/=]){44}$");
            if (!reBanma.IsMatch(tbDBanMa.Text))
            {
                MessageBox.Show("Sai định dạng bản mã, bản mã cần ở định dạng base64");
                return;
            }
            if (!reKhoa.IsMatch(tbDKhoa.Text))
            {
                MessageBox.Show("Sai định dạng khoá, khoá cần ở định dạng base 64, độ dài 44 ký tự");
                return;
            }
            DateTime time1 = DateTime.Now;
            AESCore core = new AESCore();
            byte[] banro = core.Decrypt256bit(
                    System.Convert.FromBase64String(tbDBanMa.Text),
                    System.Convert.FromBase64String(tbDKhoa.Text)
                );
            tbDBanRo.Text = System.Convert.ToBase64String(banro);
            DateTime time2 = DateTime.Now;
            TimeSpan span = time2.Subtract(time1);
            DTime.Text = "" + span.TotalSeconds + " Giây";
        }
        
    }
}

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
            Regex reBanro = new Regex(@"^[0-9]{1,3}(,[0-9]{1,3})*$");
            Regex reKhoa = new Regex(@"^([0-9]{1,3}){1}(,[0-9]{1,3}){15}$");
            if (!reBanro.IsMatch(tbBanRo.Text))
            {
                MessageBox.Show("Sai định dạng bản rõ (vd : 1,2,3,4,...)");
                return;
            }
            if (!reKhoa.IsMatch(tbKhoa.Text))
            {
                MessageBox.Show("Sai định dạng khoá (vd : 1,2,3,4,...), độ dài phải bằng 128bit ~ 16byte");
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

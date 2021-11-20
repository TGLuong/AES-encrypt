using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AES_encrypt
{
    public partial class Form1 : Form
    {
        private byte[,] state = new byte[4, 4] {
            {1,2,3,4 },
            {1,2,3,4 },
            {1,2,3,4 },
            {1,2,3,4 }
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void btMaHoa_Click(object sender, EventArgs e)
        {
            Console.WriteLine("abc ");
        }

        private void btGiaiMa_Click(object sender, EventArgs e)
        {

        }
        
    }
}

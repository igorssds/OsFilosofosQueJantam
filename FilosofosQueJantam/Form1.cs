using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilosofosQueJantam
{
    public partial class Form1 : Form
    {

        Filosofo f1 = new Filosofo(false, false, true, true, true, true);
        Filosofo f2 = new Filosofo(true, false, false, true, false, true);
        Filosofo f3 = new Filosofo(true, true, false, false, false, false);


        public Form1()
        {
            InitializeComponent();


            //pictureBox1.Image = Properties.Resources.Comendo;

            f1.VizinhoE = f3;
            f1.VizinhoD = f2;
            f2.VizinhoE = f1;
            f2.VizinhoD = f3;
            f3.VizinhoE = f2;
            f3.VizinhoD = f1;


        }


        private void btnf1_Click(object sender, EventArgs e)
        {
            
            f1.VerificarComer();
            //f2.VerificarComer();
            f3.PedirComer();
            f1.PararComer();
            f2.PedirComer();
        }
    }
}

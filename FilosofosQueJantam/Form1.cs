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
            verificarImagens(f1, btnf1, pictureBox1);
        }

        private void btnf2_Click(object sender, EventArgs e)
        {
            verificarImagens(f2, btnf2, pictureBox2);
        }

        private void btnf3_Click(object sender, EventArgs e)
        {
            verificarImagens(f3, btnf3, pictureBox3);
        }

        private void verificarImagens(Filosofo filosofo, Button botao, PictureBox img)
        {

            if (filosofo.Meditando)
            {
                img.Image = Properties.Resources.Pensando;

                if (filosofo.GarfoSujoE && filosofo.GarfoSujoD)
                {
                    filosofo.VerificarComer();
                } else
                {
                    filosofo.PedirComer();
                }
               
            }

            if (filosofo.ComFome)
            {
                img.Image = Properties.Resources.ComFome;
                botao.Text = "Estou com fome";
            }

            if (filosofo.Comendo)
            {
                img.Image = Properties.Resources.Comendo;

                if (botao.Text == "Parar de Comer")
                {
                    filosofo.PararComer();
                }
                
                if (filosofo.GarfoSujoE && filosofo.GarfoSujoD)
                {
                    botao.Text = "Parar de Comer";
                }
            }

          

        }
    }
}

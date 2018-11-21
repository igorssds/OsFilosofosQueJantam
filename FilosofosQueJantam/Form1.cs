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
        string pararComer = "Parar de comer";
        string comFome = "Estou com fome";
        string comecarComer = "Começar a comer";

        public Form1()
        {
            InitializeComponent();

            f1.VizinhoE = f3;
            f1.VizinhoD = f2;
            f2.VizinhoE = f1;
            f2.VizinhoD = f3;
            f3.VizinhoE = f2;
            f3.VizinhoD = f1;
            verificarGarfosTickets(f1, garfoDF1, garfoEF1, ticketDF1, ticketEF1);
            verificarGarfosTickets(f2, garfoDF2, garfoEF2, ticketDF2, ticketEF2);
            verificarGarfosTickets(f3, garfoDF3, garfoEF3, ticketDF3, ticketEF3);

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
                }
                else
                {
                    filosofo.PedirComer();
                }

            }

            if (filosofo.ComFome)
            {
                img.Image = Properties.Resources.ComFome;
                botao.Text = comFome;
            }

            if (filosofo.Comendo)
            {
                img.Image = Properties.Resources.Comendo;

                if (botao.Text == pararComer)
                {
                    filosofo.PararComer();
                    img.Image = Properties.Resources.Pensando;
                    botao.Text = comecarComer;

                    if (f1.Comendo)
                    {
                        pictureBox1.Image = Properties.Resources.Comendo;
                        btnf1.Text = pararComer;
                    }

                    if (f2.Comendo)
                    {
                        pictureBox2.Image = Properties.Resources.Comendo;
                        btnf2.Text = pararComer;
                    }

                    if (f3.Comendo)
                    {
                        pictureBox3.Image = Properties.Resources.Comendo;
                        btnf3.Text = pararComer;
                    }
                }

                if (filosofo.GarfoSujoE && filosofo.GarfoSujoD)
                {
                    botao.Text = pararComer;
                }
            }

            verificarGarfosTickets(f1, garfoDF1, garfoEF1, ticketDF1, ticketEF1);
            verificarGarfosTickets(f2, garfoDF2, garfoEF2, ticketDF2, ticketEF2);
            verificarGarfosTickets(f3, garfoDF3, garfoEF3, ticketDF3, ticketEF3);


        }

        private void verificarGarfosTickets(Filosofo f, Label garfoD, Label garfoE, Label ticketD, Label ticketE)
        {
            if (f1.GarfoSujoD)
            {
                garfoD.BackColor = Color.Tomato;
            }
            else
            {
                garfoD.BackColor = Color.White;
            }
            if (f1.GarfoSujoE)
            {
                garfoE.BackColor = Color.Tomato;
            }
            else
            {
                garfoE.BackColor = Color.White;
            }

            if (f1.TokenD)
            {
                ticketD.BackColor = Color.Green;
            } 
            else
            {
                ticketD.BackColor = Color.White;
            }

            if (f1.TokenE)
            {
                ticketE.BackColor = Color.Green;
            }
            else
            {
                ticketE.BackColor = Color.White;
            }
           
        }
    }
}

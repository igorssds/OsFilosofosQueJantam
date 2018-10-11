using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilosofosQueJantam
{
    class Filosofo
    {
        private bool TokenE, TokenD;
        private bool GarfoE, GarfoD;
        private bool Comendo, Meditando = true , ComFome;
        private bool GarfoSujoD , GarfoSujoE;
        public Filosofo VizinhoE, VizinhoD;
        
        private void EnviarTokenE()
        {
            TokenE = false;
            VizinhoE.ReceberTokenD();
        }

        private void EnviarTokenD()
        {
            TokenD = false;
            VizinhoD.ReceberTokenE();
        }

        private void ReceberTokenE()
        {
            TokenE = true;
            //@@@
        }

        private void ReceberTokenD()
        {
            TokenD = true;
            //@@@
        }


        private void EnviarGarfD()
        {
            GarfoD = false;
            VizinhoD.ReceberGarfoE();
            //@@@
        }

        private void EnviarGarfE()
        {
            GarfoE = false;
            VizinhoE.ReceberGarfoD();
            //@@@
        }

        private void ReceberGarfoE()
        {
            GarfoE = true;
            GarfoSujoE = false;
            VerificarComer();
        }

        private void ReceberGarfoD()
        {
            GarfoD = true;
            GarfoSujoD = false;
            VerificarComer();
        }

        private void VerificarComer()
        {
            Comendo = (GarfoE && GarfoD) ? true : false;
            
            if(Comendo)
            {
                GarfoSujoD = true;
                GarfoSujoE = true;
            } 
        }

        private void PedirComer()
        {
            if (TokenD)
            {
                if (GarfoSujoD)
                {
                    EnviarGarfD();
                }
            }

            if (TokenE)
            {
                if (GarfoSujoE)
                {
                    EnviarGarfE();
                }
            }
        }

        private void PararComer()
        {
            Comendo = false;
            if(TokenD)
            {
                    EnviarGarfD();
            }

            if (TokenE)
            {
                    EnviarGarfE();
            }
        }
    }
}

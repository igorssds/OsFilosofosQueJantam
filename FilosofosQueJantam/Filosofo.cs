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
        private bool Comendo, Meditando = true, ComFome;
        private bool GarfoSujoD, GarfoSujoE;
        public Filosofo VizinhoE, VizinhoD;



        public Filosofo(bool tokenE, bool tokenD, bool garfoE, bool garfoD, bool garfoSujoE, bool garfoSujoD)
        {
            TokenE = tokenE;
            TokenD = tokenD;
            GarfoE = garfoE;
            GarfoD = garfoD;
            GarfoSujoE = garfoSujoE;
            GarfoSujoD = garfoSujoD;


            

        }

        public void EnviarTokenE()
        {
            TokenE = false;
            VizinhoE.ReceberTokenD();
        }

        public void EnviarTokenD()
        {
            TokenD = false;
            VizinhoD.ReceberTokenE();
        }

        public void ReceberTokenE()
        {
            TokenE = true;

            if (!Comendo && GarfoE && GarfoSujoE)
            {
                EnviarGarfE();
                //@@@@
            }

        }

        public void ReceberTokenD()
        {
            TokenD = true;

            if (!Comendo && GarfoD && GarfoSujoD)
            {
                EnviarGarfD();
            }
        }


        public void EnviarGarfD()
        {
            GarfoD = false;
            GarfoSujoD = false;
            VizinhoD.ReceberGarfoE();
        }

        public void EnviarGarfE()
        {
            GarfoE = false;
            GarfoSujoE = false;
            VizinhoE.ReceberGarfoD();
        }

        public void ReceberGarfoE()
        {
            GarfoE = true;
            GarfoSujoE = false;
            VerificarComer();
        }

        public void ReceberGarfoD()
        {
            GarfoD = true;
            GarfoSujoD = false;
            VerificarComer();
        }

        public void VerificarComer()
        {
            Comendo = (GarfoE && GarfoD);

            if (Comendo)
            {

                Meditando = false;
                ComFome = false;

                GarfoSujoD = true;
                GarfoSujoE = true;
            }
        }

        public void PedirComer()
        {
            // if() @@@
            Meditando = false;
            ComFome = true;
            Comendo = false;

            if (TokenD)
            {
                EnviarTokenD();
            }

            if (TokenE)
            {
                EnviarTokenE();
            }
        }

        public void PararComer()
        {
            // if () @@@
            Comendo = false;
            Meditando = true;
            if (TokenD)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class AutoBE
    {
        public string modelo { get; set; }
        public decimal distanciaRecorrida { get; set; }
        public int velocidad { get; set; }
        public Thread HiloAuto {  get; set; }

        public AutoBE()
        {

        }
        
        public AutoBE( string m , decimal n, int v)
        {
            modelo = m; 
            distanciaRecorrida = n;
            velocidad = v;
        }
          
    }
}

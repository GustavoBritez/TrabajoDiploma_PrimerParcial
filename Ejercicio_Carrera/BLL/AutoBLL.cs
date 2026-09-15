using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace BLL
{
    public class AutoBLL
    {
        public event Action<AutoBE> AvanceAuto;

        public void ComenzarCarrera( AutoBE auto)
        {
            auto.HiloAuto = new Thread(() => EjecutarCarrera(auto)); 
            auto.HiloAuto.Start();
        }

        public void EjecutarCarrera(AutoBE auto)
        {
            Random rand = new Random();

            while (auto.distanciaRecorrida < 500)
            {

                // Me puse creativo para que avanze jsjsjs
                auto.distanciaRecorrida += rand.Next(1, 10) * auto.velocidad;
                
                // Para que todos tengan al final de la carrera distnacia recorrida 500 forzamos
                if ( auto.distanciaRecorrida > 500)
                {
                    auto.distanciaRecorrida = 500;
                }

                // Con esto nos comunicamos con la interfaz
                AvanceAuto?.Invoke(auto);

            }
        }
    }
}

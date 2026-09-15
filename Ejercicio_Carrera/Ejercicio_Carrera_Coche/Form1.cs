using BE;
using BLL;

namespace Ejercicio_Carrera_Coche
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            
            AutoBE auto = new AutoBE("toyota", 0, 2);

            AutoBLL autoBLL = new AutoBLL();

            autoBLL.AvanceAuto += (Auto_SeMueve) =>
            {
                this.Invoke(new Action(() =>
                    {

                        LB_1_1.Text = $"{Convert.ToString(Auto_SeMueve.distanciaRecorrida)}";

                    }));
                };

                autoBLL.ComenzarCarrera(auto);

        }
    }
}

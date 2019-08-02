using System;
using System.Globalization;
using System.Windows.Forms;

namespace PredictorPicoPlaca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            TxtPlaca.Text = Lblresultado.Text = Lblmensajedia.Text= "";
            TxtFecha.Text = fecha.ToString("dd/MM/yyyy");
            TxtHora.Text = fecha.ToString("HH:mm:ss");
            TxtPlaca.Focus();
        }

        private void BtnDetectar_Click(object sender, EventArgs e)
        {
            if (TxtPlaca.Text != string.Empty)
                Lblresultado.Text = Predictor_pico_y_placa(TxtPlaca.Text,TxtFecha.Text,TxtHora.Text);
        }

        private string Predictor_pico_y_placa(string _placa, string _fecha, string _hora)
        {
            string mensaje="Vehículo, SI puede circular";
            string mensaje1 = "";

            DateTime fecha= Convert.ToDateTime(_fecha, new CultureInfo("es-ES"));

            int dia = (int)fecha.DayOfWeek;

            char digito_placa=Convert.ToChar(_placa.Substring(_placa.Length-1,1));

            int hora = Convert.ToInt32(_hora.Substring(0,2));
            int minuto= Convert.ToInt32(_hora.Substring(3, 2));

            char auto1_nocircula;
            char auto2_nocircula;

            switch (dia)
            {
                case 1: //LUNES
                    mensaje1 = "Es, LUNES:";
                    auto1_nocircula = '1';
                    auto2_nocircula = '2';
                    break;
                case 2: //MARTES
                    mensaje1 = "Es, MARTES:";
                    auto1_nocircula = '3';
                    auto2_nocircula = '4';
                    break;
                case 3: //MIERCOLES
                    mensaje1 = "Es, MIERCOLES:";
                    auto1_nocircula = '5';
                    auto2_nocircula = '6';
                    break;
                case 4: //JUEVES
                    mensaje1 = "Es, JUEVES:";
                    auto1_nocircula = '7';
                    auto2_nocircula = '8';
                    break;
                case 5: //VIERNES
                    mensaje1 = "Es, VIERNES:";
                    auto1_nocircula = '9';
                    auto2_nocircula = '0';
                    break;

                default:
                    mensaje1 = "Es, SABADO o DOMINGO";
                    auto1_nocircula = 'x';
                    auto2_nocircula = 'x';
                    mensaje = "El vehículo puede circular";
                    break;

            }

            if (auto1_nocircula==digito_placa || auto2_nocircula==digito_placa)
            {

                switch(hora)
                {
                    case 7:
                    case 8:
                        mensaje = "El vehículo NO puede circular";
                        break;
                    case 9:
                        if (minuto <= 30)
                            mensaje = "El vehículo NO puede circular";
                        break;
                    case 16:
                    case 17:
                    case 18:
                        mensaje = "El vehículo NO puede circular";
                        break;
                    case 19:
                        if (minuto <= 30)
                            mensaje = "El vehículo NO puede circular";
                        break;

                }

            }


            Lblmensajedia.Text = mensaje1;

            return mensaje;
        }
     
    }
}

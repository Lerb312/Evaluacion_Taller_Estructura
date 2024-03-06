using System;
namespace Emergencia.Properties
{
    public class Emergenciologo
    {
        //Propiedades
        private Paciente paciente;

        //Constructor
        public Emergenciologo(){
            paciente = null;
        }

        public void ReporteConsulta(int n){
            String cambio = null;
            if (n == 1)
            {
                cambio = "Medico de niños ";
            }
            else
            {
                cambio = "Medico de adultos";
            }


            if (this.paciente != null)
            {
                Console.WriteLine("\n*****************"+cambio+" esta atendiendo al paciente: *********************" +
                	"\nNombre: "+this.paciente.GetNombre()+
                    "\nSituacion de edad: "+ this.paciente.TraducirEdad()+
                    "\nEstado de salud: "+ this.paciente.TraducirCondicion());

            }

        }

        
        public void SetPaciente(Paciente p1)
        {
            this.paciente = p1;
        }

        public Paciente GetPaciente()
        {
            return this.paciente;
        }

    }
}

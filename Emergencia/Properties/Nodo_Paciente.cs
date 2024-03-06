using System;
namespace Emergencia.Properties
{
    public class Nodo_Paciente
    {
        //Propiedades
        private Paciente paciente;
        private Nodo_Paciente siguiente;

        //Constructor
        public Nodo_Paciente(Paciente p1) {
            this.paciente = p1;
            this.siguiente = null;
        }

        //Segundo constructor
        public Nodo_Paciente()
        {
            this.siguiente = null;
        }

        //Setter
        public void SetSiguiente(Nodo_Paciente siguiente)
        {
            this.siguiente = siguiente;
        }

        //Getter
        public Paciente GetPaciente()
        {
            return paciente;
        }

        //Getter
        public Nodo_Paciente GetSiguiente()
        {
            return siguiente;
        }

          //ToString
         public override String ToString()
        {
            return this.paciente.ToString();
        }


    }
}

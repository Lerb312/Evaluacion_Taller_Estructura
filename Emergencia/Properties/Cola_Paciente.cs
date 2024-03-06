using System;
namespace Emergencia.Properties
{
    public class Cola_Paciente
    {
        //Propiedades
        private Nodo_Paciente inicio, fin;
        private  int tamañoMaximoCola;
        private int numeroIngresados;

        //Constructor
        public Cola_Paciente(int tamañoMax) {
            this.inicio = null;
            this.fin = null;
            this.tamañoMaximoCola = tamañoMax;
        }

        //Cola esta vacia
        public bool EstaVacia()
        {
            return this.inicio == null;
            //true ----- esta vacia
            //false ----- tiene elementos
        }

        //Cola esta llena
        public bool EstaLlena()
        {
            return this.numeroIngresados == tamañoMaximoCola;
            //true --- esta llena
            //false --- aun tiene espacios disponibles
        }

        //Retorna al primer elemento de la cola
        public Nodo_Paciente GetInicio()
        {
            return this.inicio;
        }

        public int GetNroIngresados()
        {
            return this.numeroIngresados;
        }

        //Insertar pacientes a la cola
        public void InsertarPaciente(Paciente paciente)
        {
            Nodo_Paciente nodo = new Nodo_Paciente(paciente);

            if (EstaVacia())
            {
                this.inicio = nodo;
                this.fin = nodo;
            }
            else if (EstaLlena())
            {
                Console.WriteLine("No se pueden añadir mas pacientes a la cola");
            }
            else
            {
                this.fin.SetSiguiente(nodo);
                this.fin = nodo;
            }

            if (this.numeroIngresados < this.tamañoMaximoCola){
                this.numeroIngresados++;
            }

        }



        public Paciente RemoverPaciente()
        {
            Paciente atendido = null;
            if (!EstaVacia())
            {
                atendido = this.inicio.GetPaciente();
                this.inicio = inicio.GetSiguiente();
                numeroIngresados--;
            }
            else
            {
                Console.WriteLine("No se puede remover a nadie, no hay pacientes en esta cola");
            }
            return atendido;
        }

       

    }
}

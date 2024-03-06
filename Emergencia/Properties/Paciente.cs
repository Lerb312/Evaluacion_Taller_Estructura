using System;
namespace Emergencia.Properties
{

    public class Paciente
    {
        //Propiedades
        private String nombre;
        private int edad;
        private int prioridad;

        //Constructor
        public Paciente(String nombre){
            this.edad = GenerarEdad();
            this.prioridad = GenerarPrioridad();
            this.nombre = nombre;  
        }

        public Paciente() { }

        /*Se genera aleatoriamente un numero entre 1 y 2, donde se describe de forma general
           si el paciente que entra a emergencias es niño(masculinos y femeninos) y adultos (masculinos y femeninos)
           1 = Niño y 2= Adulto

        */
        private int GenerarEdad()
        {
            return new Random().Next(1, 3);
        }


        public String GetNombre()
        {
            return this.nombre;
        }

        /*
          Se generan numeros  de 0 a 4, los cuales decriben el estado (Prioridad para ser atendidos) 
          en el que llegan los pacientes a emergencia:

          0 =Paciente normal
          1 = Accidente aparatoso
          2 = Infarto
          3 = Afección respiratoria
          4 = Parto
        */
        private int GenerarPrioridad()
        {
            return  new Random().Next(0, 5); ;
        }

        //Getter de edad
        public int GetEdad()
        {
            return edad;
        }

        //Getter de prioridad
        public int GetPrioridad()
        {
            return prioridad;
        }


        public String TraducirCondicion()
        {
            String traducido = null;

            switch (this.prioridad)
            {
                case 0:
                    traducido = " normal";
                    break;
                case 1:
                    traducido = " accidentado aparatosamente";
                    break;
                case 2:
                    traducido = " de infarto";
                    break;
                case 3:
                    traducido = " de afección respiratoria";
                    break;
                case 4:
                    traducido = " de parto";
                    break;
                default:
                    break;
            }
            return traducido;
        }


        public String TraducirEdad()
        {
            String traducido = null;

                switch (this.edad)
            {
                case 1:
                    traducido = " niño";
                    break;
                case 2:
                    traducido = " adulto";
                    break;
                default:
                    break;
            }
            return traducido;
        }


        public override String ToString()
        {
            return "Paciente de nombre: "+ this.GetNombre() + " es un "+ TraducirEdad()+ "  que posee una condicion " + TraducirCondicion();
        }

    }
}

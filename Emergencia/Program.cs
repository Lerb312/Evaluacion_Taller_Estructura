using System;
using Emergencia.Properties;

namespace Emergencia
{
    class MainClass
    {
        private const int MAX = 50;
        public static void Main(string[] args)
        {

            //Colas con sus prioridades 0 = normal, 1-4 prioridades mas importantes
            Cola_Paciente cola = new Cola_Paciente(MAX);
            Emergenciologo MedicoNiño = new Emergenciologo();
            Emergenciologo MedicoAdulto = new Emergenciologo();
            //Cola auxiliar

            bool salir = false;
            try
            {
                do
                {

                    Console.WriteLine("*****************************************************************************************************************" +
                    	"\n\nRegistro de pacientes en Emergencias\n" +
                        "Opciones para el registro:\n" +
                        "1)Ingresar un Paciente\n" +
                        "2)Atender a un Paciente\n" +
                        "3)Verificar estado de la cola y ver que paciente esta siendo atendido\n" +
                        "4) Salir de la Aplicacion\n");

                   
                    int opc = int.Parse(Console.ReadLine());

                    switch (opc)
                    {
                        case 1:
                            Console.WriteLine("Ingrese el nombre del paciente: ");
                            String nombre = Console.ReadLine();
                            Paciente paciente = new Paciente(nombre);
                            cola.InsertarPaciente(paciente);
                            Console.WriteLine("Paciente ingresado exitosamente");
                           
                            break;

                        case 2:
                                Cola_Paciente aux = new Cola_Paciente(MAX);
                                Paciente atendido = null;
                                //generar si es Niño o Adulto
                                int numEdad = new Random().Next(1, 3);

                                Nodo_Paciente auxiliar = new Nodo_Paciente();
                                auxiliar = cola.GetInicio();
                                //genera la prioridad de 0 (normal) a 4 (otras prioridades)
                                int numNOP = new Random().Next(0, 5);// genera prioridad a buscar
                               bool unaEntrada = false;

                          
                            do
                            {

                                if (auxiliar.GetPaciente().GetEdad() == numEdad && auxiliar.GetPaciente().GetPrioridad() == numNOP && unaEntrada == false)
                                {

                                    atendido = cola.RemoverPaciente();//remueve al primero de la lista
                                    Console.WriteLine("Paciente siendo llevado a hacer atendido...");
                                    if(atendido.GetEdad() == 1)
                                    {
                                        MedicoNiño.SetPaciente(atendido);
                                    }
                                    else
                                    {
                                        MedicoAdulto.SetPaciente(atendido);
                                    }
                                    unaEntrada = true;
                                }
                               else 
                                {
                                   
                                    //se emplea esta cola aux para ir sacando elementos de la otra cola que no deben ser atendidos aun y se van anexando
                                    //en el mismo orden en el que fueron ingresados 

                                    aux.InsertarPaciente(cola.RemoverPaciente());
                                }


                                auxiliar = auxiliar.GetSiguiente();

                            } while (auxiliar != null);

                            //reacomoda la cola. Se vuelca aux en cola, pero habiendo sido atendido el apciente solicitado
                            cola = aux;
                            break;

                        case 3:
                            //Estado actual de la cola
                            Nodo_Paciente nodo1 = new Nodo_Paciente();
                            nodo1 = cola.GetInicio();

                            if (!cola.EstaVacia())
                            {
                                Console.WriteLine("\nLista actual de pacientes en cola: \n");
                                do
                                {
                                    Console.WriteLine(nodo1.GetPaciente());
                                    nodo1 = nodo1.GetSiguiente();
                                } while (nodo1 != null);

                                if(MedicoNiño.GetPaciente()!= null)
                                {
                                    MedicoNiño.ReporteConsulta(1);

                                }
                                if (MedicoAdulto.GetPaciente() !=null)
                                {
                                    MedicoAdulto.ReporteConsulta(2);
                                }

                            }
                            else
                            {
                                if (MedicoNiño.GetPaciente() != null)
                                {
                                    MedicoNiño.ReporteConsulta(1);

                                }
                                if (MedicoAdulto.GetPaciente() != null)
                                {
                                    MedicoAdulto.ReporteConsulta(2);
                                }
                                Console.WriteLine("\nNo hay pacientes esperando en la cola\n");
                            }
                          
                            break;
                        case 4:
                            salir = true;
                            break;

                        
                    }
                   
                } while (!salir);


            }
            catch (FormatException e)
            {
                Console.WriteLine("El dato que suministro no es un numero, por ende no es valido, intente de nuevo \n" + e.Message);
            }
        }
    }
}

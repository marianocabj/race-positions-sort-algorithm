using System;

namespace Competencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese la cantidad de participantes:");
            int cantidadParticipantes = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la cantidad de etapas:");
            int cantidadEtapas = Int32.Parse(Console.ReadLine());
            Console.WriteLine("La cantidad de participantes es " + cantidadParticipantes);
            Console.WriteLine("La cantidad de etapas es " + cantidadEtapas);

            var participantes = new double[cantidadParticipantes,cantidadEtapas];
            var totalizadorParticipantes = new double[cantidadParticipantes];
            var totalizadorParticipantesPorEtapa = new double [cantidadParticipantes,cantidadEtapas];
            var totalizadorParticipantesPorEtapaOrdenado = new double[cantidadParticipantes, cantidadEtapas];

            for (int i = 0;i<cantidadEtapas;i++){
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("E T A P A " + (i+1));
                Console.WriteLine("----------------------------------------------------------");

                var largadaTime = DateTime.Now;
                Console.WriteLine("Hora de largada: " + largadaTime);

                for (int j = 0; j< cantidadParticipantes; j++){
                    Console.WriteLine("---------------------");
                    Console.WriteLine("Participante " + (j+1));
                    Console.WriteLine("---------------------");

                    var llegadaTime = DateTime.Now.AddMinutes(new Random().Next(0, 60));
                    Console.WriteLine("Hora de llegada participante " + (j+1) +": " +llegadaTime);

                    //Calculo la diferencia entre la llegada y la largada en minutos y sumo en los totalizadores
                    var diferenciaTime = (llegadaTime.Subtract(largadaTime).TotalMinutes);
                    participantes[j,i] = diferenciaTime;
                    totalizadorParticipantes[j] += diferenciaTime;
                    totalizadorParticipantesPorEtapa[j,i] = totalizadorParticipantes[j];

                    Console.WriteLine("El tiempo parcial en la etapa " + (i + 1) + " para el participante " + (j + 1) + " es: " + diferenciaTime + " minutos");
                    Console.WriteLine("El tiempo total en la etapa " + (i + 1) + " para el participante " + (j + 1) + " es: " + totalizadorParticipantes[j] + " minutos");
                }
                for (int k = 0;k<(cantidadParticipantes - 1); k++){
                    var mejorParticipantePorEtapa = k;
                    var mejorTiempo = totalizadorParticipantesPorEtapa[k, i];
                    for (int l = (k + 1); l<cantidadParticipantes; l++){
                        //Para cada etapa busco el participante de mejor tiempo
                        if (mejorTiempo > totalizadorParticipantesPorEtapa[l,i]){
                            mejorTiempo = totalizadorParticipantesPorEtapa[l, i];
                            mejorParticipantePorEtapa = l;
                        }
                    }

                    //Ordeno el arreglo de totalizadores
                    var aux = totalizadorParticipantesPorEtapa[k,i];
                    totalizadorParticipantesPorEtapa[k,i] = totalizadorParticipantesPorEtapa[mejorParticipantePorEtapa,i];
                    totalizadorParticipantesPorEtapa[mejorParticipantePorEtapa,i] = aux;
                }

                Console.WriteLine("---------------------");
                Console.WriteLine("Posiciones etapa " + (i+1));
                Console.WriteLine("---------------------");

                for (int m = 0;m<(cantidadParticipantes); m++){
                    /*Tengo que buscar en el arreglo original sin ordenar (totalizadorParticipantes)
                     * la POSICION(indice) que coincida con el valor de la celda del arreglo
                     * ordenado y ese es el numero del participante a devolver */ 
                    var participante = Array.FindIndex(totalizadorParticipantes, row => row == totalizadorParticipantesPorEtapa[m, i]);
                    Console.WriteLine("Al concluir la etapa "+ (i+1) +" quien finalizó en el puesto " + (m+1) + " de la tabla general fue el participante " + (participante + 1) + " con un tiempo de " + totalizadorParticipantesPorEtapa[m,i] + " minutos");
                }


            }


            Console.ReadLine();
        }
    }
}

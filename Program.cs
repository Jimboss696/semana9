using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semana9
{
    class Program
    {
        static void Main()
        {
            // Paso 1: Crear conjuntos ficticios

            // Creamos un conjunto de 500 ciudadanos con identificadores únicos (del 1 al 500)
            // HashSet es una estructura de datos que no permite duplicados, ideal para representar conjuntos.
            HashSet<int> todosLosCiudadanos = new HashSet<int>(Enumerable.Range(1, 500));

            // Generamos un conjunto de 75 ciudadanos vacunados con Pfizer, elegidos al azar
            // Se utiliza la función GenerarVacunados que retorna un conjunto aleatorio de ciudadanos vacunados.
            HashSet<int> vacunadosPfizer = new HashSet<int>(GenerarVacunados(todosLosCiudadanos, 75));

            // Generamos un conjunto de 75 ciudadanos vacunados con AstraZeneca, elegidos al azar
            // De nuevo, se utiliza GenerarVacunados para obtener otro conjunto de 75 ciudadanos.
            HashSet<int> vacunadosAstraZeneca = new HashSet<int>(GenerarVacunados(todosLosCiudadanos, 75));

            // Paso 2: Operaciones de conjuntos

            // 1. Ciudadanos que no se han vacunado
            // Creamos una copia del conjunto total de ciudadanos para trabajar sobre él.
            HashSet<int> noVacunados = new HashSet<int>(todosLosCiudadanos);
            // Se elimina del conjunto los ciudadanos que han sido vacunados con Pfizer o AstraZeneca.
            noVacunados.ExceptWith(vacunadosPfizer);
            noVacunados.ExceptWith(vacunadosAstraZeneca);

            // 2. Ciudadanos que han recibido ambas vacunas (Pfizer y AstraZeneca)
            // Creamos un nuevo conjunto a partir del conjunto de vacunados con Pfizer.
            HashSet<int> vacunadosDosVacunas = new HashSet<int>(vacunadosPfizer);
            // Realizamos la intersección con los vacunados con AstraZeneca para obtener los que recibieron ambas vacunas.
            vacunadosDosVacunas.IntersectWith(vacunadosAstraZeneca);

            // 3. Ciudadanos que solamente han recibido la vacuna de Pfizer
            // Creamos un nuevo conjunto a partir de los vacunados con Pfizer.
            HashSet<int> soloPfizer = new HashSet<int>(vacunadosPfizer);
            // Eliminamos aquellos ciudadanos que también recibieron AstraZeneca, quedando solo los vacunados exclusivamente con Pfizer.
            soloPfizer.ExceptWith(vacunadosAstraZeneca);

            // 4. Ciudadanos que solamente han recibido la vacuna de AstraZeneca
            // Creamos un nuevo conjunto a partir de los vacunados con AstraZeneca.
            HashSet<int> soloAstraZeneca = new HashSet<int>(vacunadosAstraZeneca);
            // Eliminamos aquellos ciudadanos que también recibieron Pfizer, quedando solo los vacunados exclusivamente con AstraZeneca.
            soloAstraZeneca.ExceptWith(vacunadosPfizer);

            // Paso 3: Mostrar los resultados
            // Mostramos en consola cada uno de los conjuntos resultantes de las operaciones anteriores.
            Console.WriteLine("Listado de ciudadanos que no se han vacunado:");
            MostrarConjunto(noVacunados);

            Console.WriteLine("\nListado de ciudadanos que han recibido las dos vacunas:");
            MostrarConjunto(vacunadosDosVacunas);

            Console.WriteLine("\nListado de ciudadanos que solamente han recibido la vacuna de Pfizer:");
            MostrarConjunto(soloPfizer);

            Console.WriteLine("\nListado de ciudadanos que solamente han recibido la vacuna de AstraZeneca:");
            MostrarConjunto(soloAstraZeneca);                    
        }

        // Función para generar un conjunto de ciudadanos vacunados aleatoriamente
        static IEnumerable<int> GenerarVacunados(HashSet<int> ciudadanos, int cantidad)
        {
            // Creamos un generador de números aleatorios.
            Random random = new Random();
            // Ordenamos los ciudadanos aleatoriamente y tomamos la cantidad especificada.
            return ciudadanos.OrderBy(x => random.Next()).Take(cantidad);
        }

        // Función para mostrar el contenido de un conjunto en la consola
        static void MostrarConjunto(HashSet<int> conjunto)
        {
            // Recorremos cada elemento en el conjunto y lo imprimimos en la consola.
            foreach (var ciudadano in conjunto)
            {
                Console.WriteLine(ciudadano);
                Console.Read();
            }
        }
    }
}

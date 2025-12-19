using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSortApp
{
    public class Order
    {
        public static long SwapCount = 0;
        public static long ComparisonCount = 0;

        // BUBBLE SORT 
        public static void BubbleSort(int[] array)
        {
            int n = array.Length;
            bool swapped; 

            for (int i = 0; i < n - 1; i++) // controla las pasadas
            {
                swapped = false; // bandera para detectar si hubo intercambios

                for (int j = 0; j < n - i - 1; j++) 
                {
                    ComparisonCount++;
                    if (array[j] > array[j + 1])
                    {
                        Exchange(array, j, j + 1);
                        swapped = true; 
                    }
                }
                if (!swapped) break;
            }
        }
        //COCKTAIL SORT-BURBUJA BIDIRECCIONAL
        public static void CocktailSort(int[] array)
        {
            bool swapped = true;
            int start = 0;
            int end = array.Length;

            while (swapped)
            {
                swapped = false;

                // --- IDA (Izquierda -> Derecha) ---
                // Lleva el más grande al final
                for (int i = start; i < end - 1; i++)
                {
                     ComparisonCount++;
                    if (array[i] > array[i + 1])
                    {
                        Exchange(array, i, i + 1);
                        swapped = true;
                    }
                }

                if (!swapped) break; // Si no hubo cambios, terminamos

                swapped = false;
                end = end - 1; // "Protegemos" la última posición que ya tiene al mayor

                // --- VUELTA (Derecha -> Izquierda) ---
                for (int i = end - 2; i >= start; i--)
                {
                     ComparisonCount++;
                    if (array[i] > array[i + 1])
                    {
                        Exchange(array, i, i + 1);
                        swapped = true;
                    }
                }

                start = start + 1; // "Protegemos" la primera posición
            }
        }
        /// Helper method to swap two elements in an array.
        private static void Exchange(int[] array, int index1, int index2)
        {
            if (index1 == index2) return;
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
            SwapCount++;
        }
    }
}

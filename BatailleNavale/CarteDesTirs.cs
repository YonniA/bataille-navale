using BatailleNavale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoteurDeBatailleNavale
{
    public class CarteDesTirs
    {
        private RésultatDeTir[,] _cases;

        public CarteDesTirs()
        {
            _cases = new RésultatDeTir[10, 10];
        }

        public void MarquerEmplacement(CoordonnéesDeBatailleNavale coordonnées, RésultatDeTir résultat)
        {
            _cases[coordonnées.Colonne - 'A', coordonnées.Ligne - 1] = résultat;
        }

        public void MiseAZéro()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    _cases[i, j] = RésultatDeTir.Inconnu;
                }
            }
        }

        public RésultatDeTir VérifierEmplacement(CoordonnéesDeBatailleNavale coordonnées)
        {
            return _cases[coordonnées.Colonne - 'A', coordonnées.Ligne - 1];
        }

        public void DessinerDansLaConsole()
        {
            Console.WriteLine("--------------------------------------------");
            Console.Write(" | ");
            for (int x = 0; x < 10; x++)
            {
                Console.Write((char)('A' + x));
                Console.Write(" | ");
            }
            Console.WriteLine();
            for (byte y = 0; y < 10; y++)
            {
                Console.WriteLine("--------------------------------------------");
                Console.Write(" " + (y + 1).ToString("00") + " | ");
                for (int x = 0; x < 10; x++)
                {
                    switch (_cases[x, y])
                    {
                        case RésultatDeTir.Raté:
                            Console.Write("o");
                            break;
                        case RésultatDeTir.Touché:
                            Console.Write("x");
                            break;
                        case RésultatDeTir.TouchéCoulé:
                        case RésultatDeTir.TouchéCouléFinal:
                            Console.Write("X");
                            break;
                        default:
                            Console.Write(" ");
                            break;
                    }
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("--------------------------------------------");
        }
    }
}

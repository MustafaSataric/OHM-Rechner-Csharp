using System;
using System.Text;

namespace OHMProjekt
{
    class Program
    {

        static void Main()
        {
            ConsoleKeyInfo taste;
            int selectedClass;

            do
            {

                selectedClass = Menue("Ohm Rechner", "Spannungs Rechner", "Widerstands Rechner", "Strom Rechner");

                switch (selectedClass)
                {
                    case 0:
                        SpannungsRechner();
                        break;
                    case 1:
                        WiderstandsRechner();
                        break;
                    case 2:
                        StromRechner();
                        break;
                }

                taste = Console.ReadKey();
            } while (selectedClass != -1);
        }

        public static int Menue(string title, params string[] options)
        {
            Console.SetWindowSize(70, 30);
            Console.SetBufferSize(70, 30);
            int startY = 8, currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            do
            {
                Console.Clear();
                color(1);
                Console.SetCursorPosition(Convert.ToInt32(Console.WindowWidth * 0.2), 3);
                Console.WriteLine(title);
                Console.SetCursorPosition(Convert.ToInt32(Console.WindowWidth * 0.2), 4);
                Console.WriteLine(string.Empty.PadLeft(title.Length, '='));
                Console.SetCursorPosition(0, Console.WindowHeight - 2);
                Console.Write(string.Empty.PadLeft(Console.WindowWidth - Console.CursorLeft, '─'));
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                string textToEnter = "Enter - Auswählen | ↑ - Hoch | ↓ - Runter | ESC - Beenden";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));

                Console.ResetColor();


                for (int i = 0, z = 0; i < options.Length; i++, z = z + 2)
                {
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - ("X. Option: " + options[0]).Length / 2), startY + z);
                    if (i == currentSelection)
                    {
                        color(0);
                    }


                    string currentOption = (i + 1) + ". Option: " + options[i] + " ";
                    Console.WriteLine(currentOption);

                    Console.ResetColor();
                    color(1);
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection == 0)
                            {
                                currentSelection = options.Length - 1;
                            }
                            else
                            {
                                currentSelection--;
                            }
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {

                            if (currentSelection == options.Length - 1)
                            {
                                currentSelection = 0;
                            }
                            else
                            {
                                currentSelection++;
                            }
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            return -1;
                        }
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;

            return currentSelection;
        }


static int color(int choice)
{
    if (choice == 0)
    {
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.DarkGray;
    }
    else if (choice == 1)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.BackgroundColor = ConsoleColor.DarkGray;
    }
    return 0;
}
static void SpannungsRechner()
        {
            double U = 1, R = 1, I = 1;

            Console.Clear();
            Console.SetCursorPosition(8, 2);
            Console.Write("Spannung U Rechnung:");
            Console.SetCursorPosition(8, 3);
            Console.WriteLine(string.Empty.PadLeft(22, '='));
            Console.SetCursorPosition(10, 5);
            Console.Write("Widerstand   R:");
            R = Ueberpufungeingabefliesskommazahl(2);
            Console.SetCursorPosition(10, 8);
            Console.Write("Strom        I:");
            I = Ueberpufungeingabefliesskommazahl(0);
            U = R * I;
            Console.SetCursorPosition(6, 12);
            Console.SetCursorPosition(8, 14);
            Console.WriteLine("Ergebniss:");
            Console.SetCursorPosition(8, 15);
            Console.WriteLine(string.Empty.PadLeft(10, '='));
            Console.SetCursorPosition(4, 17);
            Console.WriteLine(Maßeinheit(R) + "Ohm * " + Maßeinheit(I) + "A =  " + Maßeinheit(U) + "V"); ;
        }
        static void WiderstandsRechner()
        {
            double U = 1, R = 1, I = 1;


            Console.Clear();
            Console.SetCursorPosition(8, 2);
            Console.Write("Widerstand R Rechnung:");
            Console.SetCursorPosition(8, 3);
            Console.WriteLine(string.Empty.PadLeft(22, '='));
            Console.SetCursorPosition(10, 5);
            Console.Write("Spannung     U:");
            U = Ueberpufungeingabefliesskommazahl(2);
            Console.SetCursorPosition(10, 8);
            Console.Write("Strom        I:");
            I = Ueberpufungeingabefliesskommazahl(2);
            R = U / I;
            Console.SetCursorPosition(6, 12);
            Console.SetCursorPosition(8, 14);
            Console.WriteLine("Ergebniss:");
            Console.SetCursorPosition(8, 15);
            Console.WriteLine(string.Empty.PadLeft(10, '='));
            Console.SetCursorPosition(4, 17);
            Console.WriteLine(Maßeinheit(U) + "V / " + Maßeinheit(I) + "A =  " + Maßeinheit(R) + "Ohm");
        }


        static void StromRechner()
        {
            double U = 1, R = 1, I = 1;

            Console.Clear();
            Console.SetCursorPosition(8, 2);
            Console.Write("Strom I Rechnung:");
            Console.SetCursorPosition(8, 3);
            Console.WriteLine(string.Empty.PadLeft(22, '='));
            Console.SetCursorPosition(10, 5);
            Console.Write("Spannung     U:");
            Console.SetCursorPosition(25, 5);
            U = Ueberpufungeingabefliesskommazahl(0);
                Console.SetCursorPosition(10, 8);
                Console.Write("Widerstand   R:");
            Console.SetCursorPosition(25, 8);
            R = Ueberpufungeingabefliesskommazahl(2);            
            I = U / R;
            Console.SetCursorPosition(6, 12);
            Console.SetCursorPosition(8, 14);
            Console.WriteLine("Ergebniss:");
            Console.SetCursorPosition(8, 15);
            Console.WriteLine(string.Empty.PadLeft(10, '='));
            Console.SetCursorPosition(4, 17);
            Console.WriteLine(Maßeinheit(U) + "V / " + Maßeinheit(R) + "Ohm =  " + Maßeinheit(I) + "A");
        }

        static int UeberpufungEingabe()
        {
            ConsoleKeyInfo tastenDruck;
            StringBuilder meineEingabe = new StringBuilder();

            int zahl;
            do
            {
                tastenDruck = Console.ReadKey(true);
                switch (tastenDruck.Key)
                {
                    case ConsoleKey.Subtract:
                    case ConsoleKey.OemMinus:
                        if (meineEingabe.Length == 0)
                        {
                            meineEingabe.Append(tastenDruck.KeyChar);
                            Console.Write(tastenDruck.KeyChar);
                        }
                        break;
                    case ConsoleKey.Backspace:
                        if (meineEingabe.Length > 0)
                        {
                            meineEingabe.Remove(meineEingabe.Length - 1, 1);
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                            Console.Write(" ");
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        }
                        break;
                    default:
                        if (char.IsDigit(tastenDruck.KeyChar))
                        {
                            meineEingabe.Append(tastenDruck.KeyChar);
                            Console.Write(tastenDruck.KeyChar);
                        }
                        break;
                }

            } while (tastenDruck.Key != ConsoleKey.Enter);


            if (meineEingabe.Length == 0 || (meineEingabe.Length == 1 && meineEingabe[0] == '-'))
            {
                return 1;
            }

            meineEingabe.Insert(meineEingabe.Length, "\n");

            zahl = Convert.ToInt32(meineEingabe.ToString());

            if (zahl == 0)
            {
                return 1;
            }

            return zahl;
        }

        // Methode die Eingabe von double überprüft
        static double Ueberpufungeingabefliesskommazahl(int ausschliessen)
        // 1 schließt komma aus
        // 2 schließt negative zahlen und null aus
        {
            ConsoleKeyInfo tastenDruck;
            StringBuilder meineEingabe = new StringBuilder();
            StringBuilder exponent = new StringBuilder();
            double zahl = 0;
            int ausschluss = ausschliessen;
            do
            {
                tastenDruck = Console.ReadKey(true);
                switch (tastenDruck.Key)
                {
                    case ConsoleKey.Backspace:
                        // Erlaubt Backspace solange die Zahl länger als null stellen ist
                        if (meineEingabe.Length > 0)
                        {
                            meineEingabe.Remove(meineEingabe.Length - 1, 1);
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                            Console.Write(" ");
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                            if (meineEingabe.ToString().Contains("E"))
                            {
                                exponent.Remove(exponent.Length - 1, 1);
                            }
                        }
                        break;
                        //Erlaubt koma wenn Eingabe zwei stellen lang ist und '-' beinhaltet zbsp: '-1' dann darf ',' eingesetzt werden
                        //Erlaubt koma wenn Eingabe eine stelle lang ist und '-' nicht beinhaltet zbsp: '1'
                    case ConsoleKey.OemComma:
                    case ConsoleKey.OemPeriod:
                        if ((meineEingabe.Length >= 2 && meineEingabe.ToString().Contains(',') == false && meineEingabe.ToString().Contains("E") == false) ||
                            (meineEingabe.ToString().Contains('-') == false && meineEingabe.Length == 1
                            && meineEingabe.ToString().Contains(',') == false)
                            )
                        {
                            meineEingabe.Append(',');
                            Console.Write(',');
                        }
                        break;
                        //Erlaubt Entf taste -> löscht alles wenn eingabe länger als 0 ist
                    case ConsoleKey.Clear:
                        if (meineEingabe.Length > 0)
                        {
                            meineEingabe.Remove(meineEingabe.Length - meineEingabe.Length, meineEingabe.Length);
                            meineEingabe.Remove(exponent.Length - exponent.Length, exponent.Length);
                            Console.SetCursorPosition(25, Console.CursorTop);
                            Console.Write("                                       ");
                            Console.SetCursorPosition(25, Console.CursorTop);
                        }
                        break;
                        //Erlaubt '-' an erster stelle
                        //Erlaubt '-' an erster stelle nach 'E'
                    case ConsoleKey.OemMinus:
                    case ConsoleKey.Subtract:
                        if(ausschliessen != 2)
                        {                       
                            if (meineEingabe.Length == 0 )
                            {
                                meineEingabe.Append('-');
                                Console.Write('-');
                            }
                        }
                        if(exponent.ToString().Contains('-') == false &&
                            meineEingabe.ToString().Contains('E') &&
                            exponent.Length == 0)
                        {
                            meineEingabe.Append('-');
                            Console.Write('-');
                            exponent.Append('-');
                        }
                        break;
                        //Erlaubt 'E' nach einer Ziffer schließt '-E' aus
                    case ConsoleKey.E:
                        if ((meineEingabe.Length > 0 && meineEingabe.ToString().Contains('E') == false && meineEingabe.ToString().Contains('-') == false) ||
                            (meineEingabe.Length > 1 && meineEingabe[0] == '-' && meineEingabe.ToString().Contains('E') == false))
                        {
                            meineEingabe.Append('E');
                            Console.Write('E');
                        }
                        break;
                        //Macht Delete taste funktionsfähig 
                    case ConsoleKey.OemClear:
                        meineEingabe.Remove(meineEingabe.Length - 1, meineEingabe.Length);
                        Console.SetCursorPosition(Console.CursorLeft - meineEingabe.Length, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft - meineEingabe.Length, Console.CursorTop);
                        break;
                        //Fügt nur buchstaben zum StringBuilder hinzu
                    default:
                        if (char.IsDigit(tastenDruck.KeyChar))
                        {
                            meineEingabe.Append(tastenDruck.KeyChar);
                            Console.Write(tastenDruck.KeyChar);
                        }
                        if (meineEingabe.ToString().Contains('E'))
                        {
                            exponent.Append(tastenDruck.KeyChar);
                        }
                        break;

                }

            } while (tastenDruck.Key != ConsoleKey.Enter);
            //Falls der User keinen adequaten exponenten angibt wird dieser entfernt (nur 'E').
            if (meineEingabe.Length != 0 && meineEingabe[meineEingabe.Length - 1] == 'E')
            {
                meineEingabe = meineEingabe.Remove(meineEingabe.Length - 1, 1);
                exponent.Remove(exponent.Length - 1, 1);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.Write("  ");
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }

            //Falls der User keinen adequaten exponenten angibt wird dieser entfernt (nur 'E' & '-').
            if (meineEingabe.Length != 0 && meineEingabe[meineEingabe.Length - 1] == '-' && meineEingabe.ToString().Contains("E"))
            {
                meineEingabe = meineEingabe.Remove(meineEingabe.Length - 2, 2);
                exponent.Remove(exponent.Length - 2, 2);
                Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                Console.Write("  ");
                Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
            }
            //Falls der User nichts eingibt wird eine erneute usereingabe angefragt bis diese adequat ausgeführt wird.
            if (meineEingabe.Length == 0)
            {
                var yAchse = Console.CursorTop;
                Console.SetCursorPosition(4, 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Eingabe erfordert, eingabe durchführen");
                Console.SetCursorPosition(25, yAchse);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("                                        ");
                Console.SetCursorPosition(25, yAchse);
                return Ueberpufungeingabefliesskommazahl(ausschluss);
            }
            //Falls der User eine 0 eingibt dies aber nicht zulässig ist.
            if (meineEingabe.ToString() == "0" && ausschluss == 2)
            {
                var yAchse = Console.CursorTop;
                Console.SetCursorPosition(4, 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Eingabe ungültig");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(25, yAchse);
                Console.Write("                                        ");
                Console.SetCursorPosition(25, yAchse);
                return Ueberpufungeingabefliesskommazahl(ausschluss);
            }
            //Falls der User nur ein '-' zeichen eingibt also keine Zahl wird eine erneute usereingabe angefragt bis diese adequat ausgeführt wird.
            if (meineEingabe.Length == 1 && meineEingabe[0] == '-')
            {
                var yAchse = Console.CursorTop;
                Console.SetCursorPosition(4, 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unzulässige Eingabe, eingabe durchführen");
                Console.SetCursorPosition(25, yAchse);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("                                        ");
                Console.SetCursorPosition(25, yAchse);
                return Ueberpufungeingabefliesskommazahl(ausschluss);
            }

            // Begrenzt von 999Tera bis 1piko bei falscher usereingabe outofrange wird eine erneute usereingabe angefragt bis diese adequat ausgeführt wird.
            if (exponent.ToString().Length > 0)
            {
                if
                (Convert.ToDouble(exponent.ToString()) <= 12 && Convert.ToDouble(exponent.ToString()) >= -12) 
                {
                        var yAchse = Console.CursorTop;
                Console.SetCursorPosition(4, 1);
                Console.Write("                                        ");
                Console.SetCursorPosition(25, yAchse);
                zahl = Convert.ToDouble(meineEingabe.ToString());
                        return Convert.ToDouble(meineEingabe.ToString());
                }
                else
                {
                        var yAchse = Console.CursorTop;
                        Console.SetCursorPosition(4, 1);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Zugroße/kleine Zahl, eingabe Wiederholen");
                        Console.SetCursorPosition(25, yAchse);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("                                        ");
                        Console.SetCursorPosition(25, yAchse);
                        return Ueberpufungeingabefliesskommazahl(ausschluss);
                }
            }   
            else
            {
                var yAchse = Console.CursorTop;
                Console.SetCursorPosition(4, 1);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("                                        ");
                Console.SetCursorPosition(25, yAchse);
                zahl = Convert.ToDouble(meineEingabe.ToString());
                return zahl;

            }

        }

        static string Maßeinheit(double zahl)
        {
            string vergleich = Convert.ToString(zahl) + " ";
            //stellt alle positiven zahlen bis tera um somit hat das ergebniss maximal 3 stellen vor dem koma und maximal 2 nach denn koma durch runden.
            if (zahl > 999 && zahl < 1000000)
            {
                vergleich = Convert.ToString(Math.Round(zahl * Math.Pow(10, -3), 2) + " k");
                return vergleich;
            }
            if (zahl >= 1000000 && zahl < 1000000000)
            {
                vergleich = Convert.ToString(Math.Round(zahl * Math.Pow(10, -6), 2) + " M");
                return vergleich;
            }
            if (zahl >= 1000000000 && zahl < 1000000000000)
            {
                vergleich = Convert.ToString(Math.Round(zahl * Math.Pow(10, -9), 2) + " G");
                return vergleich;
            }
            if (zahl >= 1000000000000 )
            {
                vergleich = Convert.ToString(Math.Round(zahl * Math.Pow(10, -12), 2) + " T");
                return vergleich;
            }
            //stellt alle negativen zahlen bis piko um somit hat das ergebniss maximal 3 stellen vor dem koma und maximal 2 nach denn koma durch runden.
            if (zahl > 0.000001)
            {
                vergleich = Convert.ToString(Math.Round(zahl * Math.Pow(10, 3), 2) + " m");
                return vergleich;
            }
            if (zahl <= 0.000001 && zahl > 0.000000001)
            {
                vergleich = Convert.ToString(Math.Round(zahl * Math.Pow(10, 6), 2) + " y");
                return vergleich;
            }
            if (zahl <= 0.000000001 && zahl > 0.000000000001)
            {
                vergleich = Convert.ToString(Math.Round(zahl * Math.Pow(10, 9), 2) + " n");
                return vergleich;
            }
            if (zahl <= 0.000000000001 && zahl > 0.000000000000001)
            {
                vergleich = Convert.ToString(Math.Round(zahl * Math.Pow(10, 12), 2) + " p");
                return vergleich;
            }
            return vergleich;
        }
    }
}

//All rights reserved by Semir Sljiivic Developer of this project!!!!

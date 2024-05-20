// Program för att lägga till och visa personer i ett personalregister.
// Registret sparas ej.
// Programmet förutsätter korrekt inmatning; det kan inte hantera exceptions.
// Programmet är "skrivet på svenska" för att göra det lättförståeligt.

// Uppgift 1: 

// Uppgift 2: 

// 

namespace Personalregister
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool igång = true;

            Register personalRegister = new Register();

            while (igång)
            {
                    Console.WriteLine("Vänligen välj ett av följande alternativ:\n" +
                    "0) Lägg till en person i personalregistret.\n" +
                    "1) Vissa personalen i registret i en lista.\n" +
                    "2) Avsluta programmet.\n");

                switch (int.Parse(Console.ReadLine()))
                {
                    case 0:
                        Console.WriteLine("\nDu har valt att lägga till en person i personalregistret." +
                            "Vänligen skriv in namnet på personen.");
                        string namn = Console.ReadLine();
                        Console.WriteLine("Skriv in personens lön");
                        int lön = int.Parse(Console.ReadLine());
                        personalRegister.LäggTillPersonal(new Personal(namn, lön));
                        Console.WriteLine("{0} med {1:C} i lön har lagts till i personalregistret.", namn, lön);
                        break;

                    case 1:
                        Console.WriteLine();
                        personalRegister.SkrivListaÖverPersonalen();
                        break;

                    case 2:
                        igång = false;
                        break;

                    default:

                        break;
                }

                // Skapar mellanrum till nästa iteration.
                Console.WriteLine();
            }
        }
    }

    internal class Personal
    {
        public string namn { get; set; }
        public int lön {  get; set; }

        public Personal(string n, int l)
        {
            namn = n;
            lön = l;
        }
    }

    internal class Register
    {
        List<Personal> register = new List<Personal>();

        public void LäggTillPersonal(Personal person)
        {
            register.Add(person);
        }

        public void SkrivListaÖverPersonalen()
        {
            foreach (Personal person in register)
            {
                Console.WriteLine("{0}  {1:C}", person.namn, person.lön);
            }
        }
    }
}

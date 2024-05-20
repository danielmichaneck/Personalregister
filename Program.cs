// Program för att lägga till och visa personer i ett personalregister.
// Registret sparas ej.
// Programmet förutsätter korrekt inmatning; det kan inte hantera exceptions.
// Programmet är "skrivet på svenska" för att göra det lättförståeligt för potentiella användare.

// Uppgift 1:
// Klasser som bör ingå: En för registret och en för personerna som sedan ingår i registret.

// Uppgift 2:
// Varje person bör ha ett namn och en lön. Variablerna kan antingen initieras med en set-funktion eller i konstruktorn.
// Registret bör ha en lista över personerna i det. Registret behöver två funktioner:
// En för att lägga till nya personer och en för att visa dess innehåll.

// Ytterligare funktioner:
// En funktion för att ta bort personer ur registret.
// En funktion för att visa den totala lönen för all personal i registret.

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
                    "2) Avsluta programmet.\n" +
                    "3) Ta bort en person ur personalregistret.\n" +
                    "4) Visa antal anställa och den totala lönen för alla.\n" +
                    "5) Rensar personalregistret och kör ett test.");

                switch (int.Parse(Console.ReadLine()))
                {
                    case 0:
                        // Skapa ny person med attribut från inmatning.
                        Console.WriteLine("\nDu har valt att lägga till en person i personalregistret." +
                            "Vänligen skriv in namnet på personen.");
                        string namn = Console.ReadLine();
                        Console.WriteLine("Skriv in personens lön.");
                        int lön = int.Parse(Console.ReadLine());
                        personalRegister.LäggTillPersonal(new Personal(namn, lön));
                        Console.WriteLine("\n{0} med {1:C} i lön har lagts till i personalregistret.", namn, lön);
                        break;

                    case 1:
                        // Skriv ut en lista över alla personer i registret om inte registret är tomt.
                        Console.WriteLine();
                        if (personalRegister.register.Count > 0)
                        {
                            personalRegister.SkrivListaÖverPersonalen();
                        }
                        else Console.WriteLine("\nIngen person är tillagd i registret.");
                        break;

                    case 2:
                        // Avsluta loopen.
                        igång = false;
                        break;

                    case 3:
                        // Ta bort en person ur registret om inte registret är tomt.
                        if (personalRegister.register.Count > 0)
                        {
                            Console.WriteLine("\nDu har valt att ta bort en person ur personalregistret.\n" +
                                "Vänligen skriv in namnet på personen du vill ta bort.");
                            personalRegister.TaBortPersonal(Console.ReadLine());
                        }
                        else Console.WriteLine("\nIngen person är tillagd i registret.");
                        break;

                    case 4:
                        // Skriv ut antal anställda och den sammanlagda lönen för alla.
                        Console.WriteLine();
                        if (personalRegister.register.Count > 0)
                        {
                            personalRegister.SkrivTotalaLönen();
                        }
                        else Console.WriteLine("\nIngen person är tillagd i registret.");
                        break;

                    case 5:
                        // Rensar personalregistret och testar
                        Console.WriteLine("Rensar personalregistret och skriver in ny information som test.\n");
                        personalRegister = new Register();
                        personalRegister.LäggTillPersonal(new Personal ("Daniel", 100));
                        personalRegister.LäggTillPersonal(new Personal ("Daniels katt", 10000));
                        Console.WriteLine("\nDaniel med 100 kronor i lön har lagts till i registret.\n" +
                            "Daniels katt med 10 000 kronor i lön har lagts till i registret.\n");
                        Console.WriteLine("Skriver ut antal anställda och den totala lönen.\n");
                        personalRegister.SkrivTotalaLönen();
                        Console.WriteLine("Tar bort Daniel från personalregistret.");
                        personalRegister.TaBortPersonal("Daniel");
                        Console.WriteLine("Skriver ut en lista över alla i personalregistret.");
                        personalRegister.SkrivListaÖverPersonalen();
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
        public List<Personal> register { get; } = new List<Personal>();

        public void LäggTillPersonal(Personal person)
        {
            register.Add(person);
        }

        public void SkrivListaÖverPersonalen()
        {
            Console.WriteLine();
            foreach (Personal person in register)
            {
                Console.WriteLine("{0} {1:C}", person.namn, person.lön);
            }
        }

        // Extra funktion för att ta bort personer från registret.
        public void TaBortPersonal(string n)
        {
            Console.WriteLine();
            Personal personAttTaBort = register.Find(person => person.namn == n);
            if (personAttTaBort != null)
            {
                Console.WriteLine("{0} har tagits bort ur registret.", n);
                register.Remove(personAttTaBort);
            }
            else Console.WriteLine("{0} finns inte i registret.", n);
        }

        // Extra funktion för att summera och visa lönen för all personal i registret.
        public void SkrivTotalaLönen()
        {
            int totalt = 0;
            int antalAnställda = 0;

            foreach (Personal person in register)
            {
                totalt += person.lön;
                antalAnställda++;
            }

            Console.WriteLine();

            if (antalAnställda == 1)
            {
                Console.WriteLine("Det finns 1 person i registret. Personen har {0:C} i lön.", totalt);
            }
            else
            {
                Console.WriteLine("Det finns {0} personer i registret och de har sammanlagt {1:C} i lön.", antalAnställda, totalt);
            }
        }
    }
}

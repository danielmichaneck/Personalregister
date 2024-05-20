namespace Personalregister
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vänligen välj ett av följande alternativ:\n" +
                "0) Lägg till en person i personalregistret.\n" +
                "1) Vissa personalen i registret i en lista.");

            switch(int.Parse(Console.ReadLine()))
            {
                case 0:

                    break;

                case 1:

                    break;

                default:

                    break;
            }
        }
    }

    internal class Personal
    {
        string namn;
        int lön;

        Personal(string n, int l)
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
                Console.WriteLine("");
        }
    }
}

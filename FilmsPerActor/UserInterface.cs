using Microsoft.IdentityModel.Tokens;

namespace FilmsPerActor
{
    internal class UserInterface
    {
        private FilmDBService filmDBService;
        public UserInterface(FilmDBService filmDBService)
        {
            this.filmDBService = filmDBService;
        }

        public void StartDialog()
        {
            while (true)
            {
                Console.WriteLine("Ange skådespelarens namn för att hitta alla filmer skädespelaren deltagit i. (t.ex Penelope Guiness)");

                Console.Write("Ange förnamn: ");
                string firstName = Console.ReadLine();

                Console.Write("Ange efternamn: ");
                string lastName = Console.ReadLine();

                List<string> films = filmDBService.GetFilmsByActorName(firstName, lastName);

                if (films.IsNullOrEmpty())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Inga filmer hittades för skådespelaren.");
                    Console.WriteLine("Kontrollera stavning.");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                foreach (string film in films)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{film}");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine("Vill du fortsätta? J/N");
                string continueAnswer = Console.ReadKey(true).KeyChar.ToString();
                if(continueAnswer.ToUpper() == "J")
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    break;
                }
            }
        }
    }
}

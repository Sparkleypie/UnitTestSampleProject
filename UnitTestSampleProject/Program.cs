using System;
using UnitTestSampleProject.Model;

namespace UnitTestSampleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //De rest van die tutorial is meer voor MVC
            //Dus we kunnen nu gewoon het gaan gebruiken.
            //Dus bijv. stel je wilt een persoon toevoegen

            //Dit was wat we ook hadden in de horsegame uhu
            while (true)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1 - Add a person");
                Console.WriteLine("E - Exit");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddPerson();
                        break;
                    case "E":
                        Console.WriteLine("ok doei");
                        return;
                    default:
                        break;
                }
            }
        }

        public static void AddPerson()
        {
            
            //Goed, hoe doen we dit nou :)

            //wat je altijd moet doen is die dbcontext aanmaken
            //Dus bijvoorbeeld:
            //Reden dat het in een using moet is omdat dat ding zegmaar een database connectie opent
            //Als je nu uit die using gaat gooit hij die weer dicht
            using (var uitleenContext = new UitleenContext())
            {
                var person = new Person();
                //Hierin kunnen we nu een persoon maken
                //Vraag anders eerst eens via die console.readline dingen wat de naam en age enzo van een persoon is
                Console.WriteLine("What is your first name?");
                string firstName = Console.ReadLine();
                Console.WriteLine("And your surname?");
                string lastName = Console.ReadLine();

                //ja die laatste zou niet eens nodig zijn maar prima :)
                //ok laten we er ff first name en last name van maken want dat is ook op die Person

                //ok kan je dit eens runnen, gewoon om ff te testen? goed, ff inchecken
                //=]]]
            }
        }
    }
}

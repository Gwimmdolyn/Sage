using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sage
{
    public class SageApp
    {
        private readonly KnowledgeGraph _graph = new KnowledgeGraph();

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n--- SAGE PKM SYSTEM ---");
                Console.WriteLine("1. Create Node");
                Console.WriteLine("2. View Node");
                Console.WriteLine("3. Edit Node");
                Console.WriteLine("4. Link Nodes");
                Console.WriteLine("5. Search");
                Console.WriteLine("6. List All Nodes");
                Console.WriteLine("7. Exit");
                Console.WriteLine("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1": CreateNode(); break;
                    case "2": ViewNode(); break;
                    case "3": EditNode(); break;
                    case "4": LinkNodes(); break;
                    case "5": SearchNodes(); break;
                    case "6": ListNodes(); break;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }

    }
}

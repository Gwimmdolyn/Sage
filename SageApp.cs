using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sage
{
    public class SageApp
    {
        private readonly KnowledgeGraph _graph = new KnowledgeGraph();// The knowledge graph that stores all nodes and relationships

        public void Run()
        {
            while (true)// Runs until the user exits
            {
                // Displays the menu options
                Console.WriteLine("\n--- SAGE PKM SYSTEM ---");
                Console.WriteLine("1. Create Node");
                Console.WriteLine("2. View Node");
                Console.WriteLine("3. Edit Node");
                Console.WriteLine("4. Link Nodes");
                Console.WriteLine("5. Search");
                Console.WriteLine("6. List All Nodes");
                Console.WriteLine("7. Exit");
                Console.WriteLine("Choose an option: ");

                // Reads the users choice and executes the corresponding action
                switch (Console.ReadLine())
                {
                    case "1": CreateNode(); break;
                    case "2": ViewNode(); break;
                    case "3": EditNode(); break;
                    case "4": LinkNodes(); break;
                    case "5": SearchNodes(); break;
                    case "6": ListNodes(); break;
                    
                    // Handles invalid inputs
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }

        private void CreateNode()
        {
            Console.WriteLine("Title: ");// Asks the user for the node title 
            string title = Console.ReadLine();
            Console.WriteLine("content: ");// Asks the user for the contents of the node
            string content = Console.ReadLine();

            var node = _graph.CreateNode(title, content);// Creates a new node in the knowledge graph
            Console.WriteLine($"Node created with ID {node.Id}");// Confirms creation to the user
        }

        private void ViewNode()
        {
            Console.WriteLine("Enter ID: ");// asks the user for the node ID
            if (!int.TryParse( Console.ReadLine(), out int id))// if true then sends the user a message if they entered a invalid number
            {
                Console.WriteLine("Invalid ID.");
                return;// Stops because the user did not enter a valid number
            }

            // Attempts to retrieve the node from the graph
            var node = _graph.GetNode(id);
            if (node == null)
            {
                Console.WriteLine("Node not found.");
                return;// Stops if the node doesnt exist
            }

            // Displays the nodes information
            Console.WriteLine($"\nID: {node.Id}");
            Console.WriteLine($"Title: {node.Title}");
            Console.WriteLine($"Content: {node.Content}");
            Console.WriteLine($"Links: ");

            // Displays each linked node by ID and title
            foreach (var linkId in node.LinkedNodes)
            {
                var linked = _graph.GetNode(linkId);
                if (linked != null)
                    Console.WriteLine($"- [{linked.Id} {linked.Title}]");
            }
        }

    }
}

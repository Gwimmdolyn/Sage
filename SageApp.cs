using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
                    case "6": ListAllNodes(); break;
                    case "7": return;
                    
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
            if (!int.TryParse( Console.ReadLine(), out int id))// if false then sends the user a message if they entered a invalid number
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

        private void EditNode()
        {
            Console.WriteLine("Enter ID: ");// Asks the user what node they want to edit
            if (!int.TryParse(Console.ReadLine(), out int id)) return;// validates that the input is a number

            var node = _graph.GetNode(id); // Attempts to retrieve the node from the graph
            if (node == null)
            {
                Console.WriteLine("Node not found.");// notifys the user if the node doesnt exist
                return;
            }

            // Asks the user for the updated title and content
            Console.WriteLine("New Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("New Content: ");
            string content = Console.ReadLine();

            // Apply the edits to the node 
            node.Edit(title, content);
            // Conmfirms that the node has been updated to the user
            Console.WriteLine("Node updated.");
        }

        private void LinkNodes()
        {
            Console.WriteLine("First node ID: ");// Asks the user for the first node ID
            int a = int.Parse(Console.ReadLine());// Converts the input to an integer

            Console.WriteLine("Second node ID: ");// Asks the user for the second node ID
            int b = int.Parse(Console.ReadLine());// Converts the input to an integer

            _graph.LinkNodes(a, b);// Creates a link between the nodes
            Console.WriteLine("Nodes linked.");
        }

        private void SearchNodes()
        {
            Console.WriteLine("Search query: ");// asks the user for the search text
            string query = Console.ReadLine();

            var results = _graph.Search(query);// Performs a search in the knowledge graph based on the query

            foreach (var n in results)// Displays each matching node by ID and title
                Console.WriteLine($"[{n.Id}] {n.Title}");
        }

        private void ListAllNodes()
        {
            Console.WriteLine("All Nodes: ");// Label so the user knows whats being shown
            foreach (var n in _graph.GetAllNodes())// Loop through every node returned by the knowledge graph
            {
                Console.WriteLine($"[{n.Id}] {n.Title}");// Print each nodes ID and title 
            }
        }
    }
}

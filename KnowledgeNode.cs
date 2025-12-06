using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SageNew
{
    public class KnowledgeNode
    {
        public int Id { get; }// Unique identifier for this node 
        public string Title { get; set; }// Title describes the node
        public string Content { get; set; }// Main body of text or information stored in the node
        public List<int> LinkedNodes { get; }// List of IDs representing other nodes link to


        public KnowledgeNode(int id, string title, string content)
        {
            // Node properties
            Id = id;
            Title = title;
            Content = content;
            LinkedNodes = new List<int>();// Creates an empty list to store linked node IDs
        }

        public void Edit(string newTitle, string newContent)
        {
            // Update the nodes title and content
            Title = newTitle;
            Content = newContent;
        }

        public void AddLink(int id)
        {
            // Only adds the link if it doesnt exist already
            if (!LinkedNodes.Contains(id))
                LinkedNodes.Add(id);
        }
    }
}

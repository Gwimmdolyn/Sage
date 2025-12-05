using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sage
{
    public class KnowledgeGraph
    {
        // Stores all KnowledgeNode objects using their ID as the key
        private readonly Dictionary<int, KnowledgeNode> _nodes = new Dictionary<int, KnowledgeNode>();
        private int _nextId = 1;// Tracks the next unique ID to assign when creating a node

        public KnowledgeNode CreateNode(string title, string content)
        {
            var node = new KnowledgeNode(_nextId, title, content);// Create a new node with a unique ID
            _nodes[node.Id] = node;// Add the node to the dictionary so it can be retrieved later
            _nextId++;// Increment the ID counter for the next created node
            return node;
        }

        public KnowledgeNode GetNode(int id)
        {
            if (_nodes.ContainsKey(id))// Check whether the dictionary contains a node with this ID 
                return _nodes[id];
            else 
                return null;// Return null if no node exists with the given ID
        }

        public List<KnowledgeNode> Search(string query)
        {
            // Make the search text lowercase so it's not case sensitive
            query = query.ToLower();

            // This will store all matching nodes
            List<KnowledgeNode> results = new List<KnowledgeNode>();

            // Loop through every node in the dictionary
            foreach (var node in _nodes.Values)
            {
                // Convert title and content to lowercase
                string title = node.Title.ToLower();
                string content = node.Content.ToLower();

                // Check if the search text exists in the title OR content
                if (title.Contains(query) || content.Contains(query))
                {
                    results.Add(node);
                }
            }

            // Return everything that matched
            return results;
        }

        public void LinkNodes(int a, int b)
        {
            if (_nodes.ContainsKey(a)  && _nodes.ContainsKey(b))// Checks that both node IDs exist in the dictionary
            {
                _nodes[a].AddLink(b);// Add a link from node A to node B
                _nodes[b].AddLink(a);// Add a link from node B to node A
            }
        }
    }
}

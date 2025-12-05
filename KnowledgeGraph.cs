using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sage
{
    public class KnowledgeGraph
    {
        private readonly Dictionary<int, KnowledgeNode> _nodes = new Dictionary<int, KnowledgeNode>();
        private int _nextId = 1;

        public KnowledgeNode CreateNode(string title, string content)
        {
            var node = new KnowledgeNode(_nextId, title, content);
            _nodes[node.Id] = node;
            _nextId++;
            return node;
        }

        public KnowledgeNode GetNode(int id)
        {
            if (_nodes.ContainsKey(id)) 
                return _nodes[id];
            else 
                return null;
        }
    }
}

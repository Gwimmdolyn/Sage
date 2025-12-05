using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sage
{
    public class KnowledgeNode
    {
        public int Id { get; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<int> LinkedNodes { get; }


        public KnowledgeNode(int id, string title, string content)
        {
            Id = id;
            Title = title;
            Content = content;
            LinkedNodes = new List<int>();
        }

        public void Edit()
        {
            Title = newTitle;
            Content = newContent;
        }

        public void AddLink(int id)
        {
            if (!LinkedNodes.Contains(id))
                LinkedNodes.Add(id);
        }
    }
}

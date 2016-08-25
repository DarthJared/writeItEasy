using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteMeEasy_WindowsFormsApplication
{
    public class Section
    {
        public List<SubSection> subSections;
        public string content;
        public string title;
        public int index;

        public Section()
        {
            this.subSections = new List<SubSection>();
            this.content = "";
            this.title = "";
            this.index = 0;
        }
        
        public Section(List<SubSection> subSections, string content, string title, int index)
        {
            this.subSections = subSections;
            this.content = content;
            this.title = title;
            this.index = index;
        }
    }
}

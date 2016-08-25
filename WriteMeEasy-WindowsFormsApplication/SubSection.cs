using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteMeEasy_WindowsFormsApplication
{
    public class SubSection
    {
        public List<SubSubSection> subSections;
        public string content;
        public string title;
        public int index;

        public SubSection()
        {
            this.subSections = new List<SubSubSection>();
            this.content = "";
            this.title = "";
            this.index = 0;
        }

        public SubSection(List<SubSubSection> subSubSection, string content, string title, int index)
        {
            this.subSections = subSubSection;
            this.content = content;
            this.title = title;
            this.index = index;
        }
    }
}

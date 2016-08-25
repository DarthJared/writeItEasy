using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteMeEasy_WindowsFormsApplication
{
    public class SubSubSection
    {
        public string content;
        public string title;
        public int index;

        public SubSubSection()
        {
            this.content = "";
            this.title = "";
            this.index = 0;
        }

        public SubSubSection(string content, string title, int index)
        {
            this.content = content;
            this.title = title;
            this.index = index;
        }
    }
}

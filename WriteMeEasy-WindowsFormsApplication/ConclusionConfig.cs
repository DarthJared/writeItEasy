using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteMeEasy_WindowsFormsApplication
{
    public class ConclusionConfig
    {
        public bool onOwnPage;
        public bool includeTitle;
        public string title;
        public string titleAlign;
        public bool boldTitle;
        public string titleFont;
        public int titleSize;
        public string titleColor;
        public string conclusionContent;

        public ConclusionConfig()
        {
            conclusionContent = "";
        }
    }
}

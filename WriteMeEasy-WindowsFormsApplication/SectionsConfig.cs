using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteMeEasy_WindowsFormsApplication
{
    public class SectionsConfig
    {
        public bool blankLineBetween;
        public bool newPageBetween;
        public bool noSpaceBetween;

        public bool includeSectionLabels;
        public bool includeSubsectionLabels;
        public bool includeSubsubsectionLabels;

        public bool sectionLabelInlineWithText;
        public bool sectionLabelOnOwnLine;
        public bool sectionLabelBold;
        public string sectionLabelAlignment;
        public string sectionLabelFont;
        public int sectionLabelSize;
        public string sectionLabelColor;

        public bool subsectionLabelInlineWithText;
        public bool subsectionLabelOnOwnLine;
        public bool subsectionLabelBold;
        public string subsectionLabelAlignment;
        public string subsectionLabelFont;
        public int subsectionLabelSize;
        public string subsectionLabelColor;

        public bool subsubsectionLabelInlineWithText;
        public bool subsubsectionLabelOnOwnLine;
        public bool subsubsectionLabelBold;
        public string subsubsectionLabelAlignment;
        public string subsubsectionLabelFont;
        public int subsubsectionLabelSize;
        public string subsubsectionLabelColor;

        public SectionsConfig()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteMeEasy_WindowsFormsApplication
{
    public class HeaderFooterConfig
    {
        public bool differentFirstPage;
        public bool useRunningHead;

        public bool leftTitle;
        public bool leftPageNum;
        public bool leftOther;
        public bool leftNone;

        public bool centerTitle;
        public bool centerPageNum;
        public bool centerOther;
        public bool centerNone;

        public bool rightTitle;
        public bool rightPageNum;
        public bool rightOther;
        public bool rightNone;

        public bool firstLeftTitle;
        public bool firstLeftPageNum;
        public bool firstLeftOther;
        public bool firstLeftNone;

        public bool firstCenterTitle;
        public bool firstCenterPageNum;
        public bool firstCenterOther;
        public bool firstCenterNone;

        public bool firstRightTitle;
        public bool firstRightPageNum;
        public bool firstRightOther;
        public bool firstRightNone;

        public string leftTitleText;
        public int leftPageNumStart;
        public string leftOtherText;

        public string centerTitleText;
        public int centerPageNumStart;
        public string centerOtherText;

        public string rightTitleText;
        public int rightPageNumStart;
        public string rightOtherText;

        public string firstLeftTitleText;
        public int firstLeftPageNumStart;
        public string firstLeftOtherText;

        public string firstCenterTitleText;
        public int firstCenterPageNumStart;
        public string firstCenterOtherText;

        public string firstRightTitleText;
        public int firstRightPageNumStart;
        public string firstRightOtherText;

        public HeaderFooterConfig()
        {

        }
    }
}

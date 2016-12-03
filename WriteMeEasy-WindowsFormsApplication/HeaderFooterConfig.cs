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
            differentFirstPage = false;
            useRunningHead = false;

            leftTitle = false;
            leftPageNum = false;
            leftOther = false;
            leftNone = false;

            centerTitle = false;
            centerPageNum = false;
            centerOther = false;
            centerNone = false;

            rightTitle = false;
            rightPageNum = false;
            rightOther = false;
            rightNone = false;

            firstLeftTitle = false;
            firstLeftPageNum = false;
            firstLeftOther = false;
            firstLeftNone = false;

            firstCenterTitle = false;
            firstCenterPageNum = false;
            firstCenterOther = false;
            firstCenterNone = false;

            firstRightTitle = false;
            firstRightPageNum = false;
            firstRightOther = false;
            firstRightNone = false;

            leftTitleText = "";
            leftPageNumStart = 0;
            leftOtherText = "";

            centerTitleText = "";
            centerPageNumStart = 0;
            centerOtherText = "";

            rightTitleText = "";
            rightPageNumStart = 0;
            rightOtherText = "";

            firstLeftTitleText = "";
            firstLeftPageNumStart = 0;
            firstLeftOtherText = "";

            firstCenterTitleText = "";
            firstCenterPageNumStart = 0;
            firstCenterOtherText = "";

            firstRightTitleText = "";
            firstRightPageNumStart = 0;
            firstRightOtherText = "";
        }
    }
}

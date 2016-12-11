﻿using System;
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
        public bool leftLastPageNum;
        public bool leftNone;
        
        public bool rightTitle;
        public bool rightPageNum;
        public bool rightOther;
        public bool rightLastPageNum;
        public bool rightNone;

        public bool firstLeftTitle;
        public bool firstLeftPageNum;
        public bool firstLeftOther;
        public bool firstLeftLastPageNum;
        public bool firstLeftNone;

        public bool firstRightTitle;
        public bool firstRightPageNum;
        public bool firstRightOther;
        public bool firstRightLastPageNum;
        public bool firstRightNone;

        public string leftTitleText;
        public int leftPageNumStart;
        public string leftLastName;
        public string leftOtherText;

        public string rightTitleText;
        public int rightPageNumStart;
        public string rightLastName;
        public string rightOtherText;

        public string firstLeftTitleText;
        public int firstLeftPageNumStart;
        public string firstLeftLastName;
        public string firstLeftOtherText;

        public string firstRightTitleText;
        public int firstRightPageNumStart;
        public string firstRightLastName;
        public string firstRightOtherText;

        public HeaderFooterConfig()
        {
            differentFirstPage = false;
            useRunningHead = false;

            leftTitle = false;
            leftPageNum = false;
            leftOther = false;
            leftLastPageNum = false;
            leftNone = false;

            rightTitle = false;
            rightPageNum = false;
            rightOther = false;
            rightLastPageNum = false;
            rightNone = false;

            firstLeftTitle = false;
            firstLeftPageNum = false;
            firstLeftOther = false;
            firstLeftLastPageNum = false;
            firstLeftNone = false;

            firstRightTitle = false;
            firstRightPageNum = false;
            firstRightOther = false;
            firstRightLastPageNum = false;
            firstRightNone = false;

            leftTitleText = "";
            leftPageNumStart = 0;
            leftLastName = "";
            leftOtherText = "";

            rightTitleText = "";
            rightPageNumStart = 0;
            rightLastName = "";
            rightOtherText = "";

            firstLeftTitleText = "";
            firstLeftPageNumStart = 0;
            firstLeftLastName = "";
            firstLeftOtherText = "";

            firstRightTitleText = "";
            firstRightPageNumStart = 0;
            firstRightLastName = "";
            firstRightOtherText = "";
        }
    }
}

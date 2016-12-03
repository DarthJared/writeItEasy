using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteMeEasy_WindowsFormsApplication
{
    public class TitlePageConfig
    {
        public bool includeTitle;
        public bool includeName;
        public bool includeClass;
        public bool includeProfessor;
        public bool includeSchool;
        public bool includeDate;

        public string title;
        public string name;
        public string className;
        public string professor;
        public string school;
        public string date;

        public List<string> titlePageOrder;

        public string alignment;
        public string position;

        public TitlePageConfig()
        {
            includeTitle = false;
            includeName = false;
            includeClass = false;
            includeProfessor = false;
            includeSchool = false;
            includeDate = false;

            title = "";
            name = "";
            className = "";
            professor = "";
            school = "";
            date = "";
            alignment = "";
            position = "";
            titlePageOrder = new List<string>();
        }
    }
}

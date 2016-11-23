using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteMeEasy_WindowsFormsApplication
{
    public class Reference
    {
        public string formattedReference;
        public string type;
        public string publicationDate;
        public List<Author> authors;
        public List<Author> translators;
        public string title;
        public string publisher;
        public string publishLocation;
        public string edition;
        public string section;
        public string volume;
        public string issue;
        public string startPage;
        public string endPage;
        public string originalPublishDate;
        public string source;

        public Reference()
        {
            authors = new List<Author>();
            translators = new List<Author>();
        }
    }
}

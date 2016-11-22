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
        public string title;
        public string publisher;
        public string publishLocation;
        public string edition;

        public Reference()
        {
            authors = new List<Author>();
        }
    }
}

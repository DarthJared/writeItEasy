using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WriteMeEasy_WindowsFormsApplication
{
    public partial class UI : Form
    {
        public UI()
        {
            InitializeComponent();

            string curDir = Directory.GetCurrentDirectory();
            curDir += "\\..\\..\\UI\\";
            webBrowser1.Navigate(curDir + "main.html");
            //webBrowser1.Navigate(@"http://www.google.com");


        }
    }
}

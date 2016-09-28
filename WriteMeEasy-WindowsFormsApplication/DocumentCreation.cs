using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
//using Novacode;
using Microsoft.Office.Interop.Word;

namespace WriteMeEasy_WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        private void writeButton_Click(object sender, EventArgs e)
        {
            //// Modify to suit your machine:
            //string fileName = @"C:\Users\Jbeag_000\Desktop\DocXExample.docx";

            //// Create a document in memory:
            //var doc = DocX.Create(fileName);

            //// Insert a paragrpah:
            //doc.InsertParagraph("This is my first paragraph");
            //doc.InsertSectionPageBreak();
            //doc.InsertParagraph("This is my second page!");

            //// Save to the output directory:
            //doc.Save();

            //// Open in Word:
            //Process.Start("WINWORD.EXE", fileName);
            try
            {
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                wordApp.ShowAnimation = false;
                wordApp.Visible = false;

                object missing = System.Reflection.Missing.Value;

                Document document = wordApp.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                //foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
                //{
                //    Range headerRange = section.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                //    headerRange.Fields.Add(headerRange, WdFieldType.wdFieldPage);
                //    headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                //    headerRange.Font.ColorIndex = WdColorIndex.wdBlue;
                //    headerRange.Font.Size = 10;
                //    headerRange.Text = "Header text goes here";
                //}

                //foreach (Microsoft.Office.Interop.Word.Section wordSection in document.Sections)
                //{
                //    Range footerRange = wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                //    footerRange.Font.ColorIndex = WdColorIndex.wdDarkRed;
                //    footerRange.Font.Size = 10;
                //    footerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                //    footerRange.Text = "Footer text goes here";
                //}

                //document.Content.SetRange(0, 0);
                //document.Content.Text = "This is test document " + Environment.NewLine;

                if (myPaper.includeTitlePage)
                {

                }

                if (myPaper.includeSummary)
                {
                    if (myPaper.summary.includeTitle)
                    {
                        Paragraph labelText = document.Content.Paragraphs.Add(ref missing);
                        labelText.Range.Text = myPaper.summary.title;
                        labelText.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        labelText.Range.InsertParagraphAfter();
                    }
                    Paragraph paragraphText = document.Content.Paragraphs.Add(ref missing);
                    paragraphText.Range.Text = myPaper.summary.content;
                    paragraphText.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    paragraphText.Range.InsertParagraphAfter();
                }

                if (myPaper.includeAbstract)
                {
                    if (myPaper.abstractConfig.includeTitle)
                    {
                        Paragraph labelText = document.Content.Paragraphs.Add(ref missing);
                        labelText.Range.Text = myPaper.abstractConfig.title;
                        labelText.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        labelText.Range.InsertParagraphAfter();
                    }
                    Paragraph paragraphText = document.Content.Paragraphs.Add(ref missing);
                    paragraphText.Range.Text = myPaper.abstractConfig.content;
                    paragraphText.Range.InsertParagraphAfter();
                }

                if (myPaper.includeHeader)
                {

                }

                if (myPaper.includeFooter)
                {

                }

                

                foreach(Section section in myPaper.sections)
                {
                    Paragraph sectionText = document.Content.Paragraphs.Add(ref missing);
                    if (includeSectionLabelsCheck.Checked)
                    {
                        if (myPaper.sectionsConfig.sectionLabelInlineWithText)
                        {
                            sectionText.Range.Text = section.title + ". " + section.content;
                            int start = 0;
                            int end = section.title.Length + 1;
                            if (myPaper.sectionsConfig.sectionLabelBold)
                            {
                                Range rangeToBold = sectionText.Range.Duplicate;
                                rangeToBold.SetRange(start, end);
                                rangeToBold.Bold = 1;
                            }                            
                        }
                        else if (myPaper.sectionsConfig.sectionLabelOnOwnLine)
                        {
                            Paragraph labelText = document.Content.Paragraphs.Add(ref missing);
                            labelText.Range.Text = section.title;
                            if (myPaper.sectionsConfig.sectionLabelBold)
                            {
                                labelText.Range.Bold = 1;
                            }
                            labelText.Range.InsertParagraphAfter();
                            sectionText.Range.Text = section.content;
                        }  
                        else
                        {
                            sectionText.Range.Text = section.title + ". " + section.content;
                            int start = 0;
                            int end = section.title.Length + 1;
                            if (myPaper.sectionsConfig.sectionLabelBold)
                            {
                                Range rangeToBold = sectionText.Range.Duplicate;
                                rangeToBold.SetRange(start, end);
                                rangeToBold.Bold = 1;
                            }
                        }                      
                    }
                    sectionText.Range.InsertParagraphAfter();
                    
                    foreach (SubSection subsection in section.subSections)
                    {
                        Paragraph subsectionText = document.Content.Paragraphs.Add(ref missing);
                        if (includeSubsectionLabelCheck.Checked)
                        {
                            if (myPaper.sectionsConfig.subsectionLabelInlineWithText)
                            {
                                subsectionText.Range.Text = subsection.title + ". " + subsection.content;
                                int start = 0;
                                int end = subsection.title.Length + 1;
                                if (myPaper.sectionsConfig.subsectionLabelBold)
                                {
                                    Range rangeToBold = subsectionText.Range.Duplicate;
                                    rangeToBold.SetRange(start, end);
                                    rangeToBold.Bold = 1;
                                }
                            }
                            else if (myPaper.sectionsConfig.subsectionLabelOnOwnLine)
                            {
                                Paragraph labelText = document.Content.Paragraphs.Add(ref missing);
                                labelText.Range.Text = subsection.title;
                                if (myPaper.sectionsConfig.subsectionLabelBold)
                                {
                                    labelText.Range.Bold = 1;
                                }
                                labelText.Range.InsertParagraphAfter();
                                subsectionText.Range.Text = subsection.content;
                            }   
                            else
                            {
                                subsectionText.Range.Text = subsection.title + ". " + subsection.content;
                                int start = 0;
                                int end = subsection.title.Length + 1;
                                if (myPaper.sectionsConfig.subsectionLabelBold)
                                {
                                    Range rangeToBold = subsectionText.Range.Duplicate;
                                    rangeToBold.SetRange(start, end);
                                    rangeToBold.Bold = 1;
                                }
                            }                         
                        }
                        subsectionText.Range.InsertParagraphAfter();

                        foreach (SubSubSection subsubsection in subsection.subsubSections)
                        {
                            Paragraph subsubsectionText = document.Content.Paragraphs.Add(ref missing);
                            if (includeSubsubsectionLabelCheck.Checked)
                            {
                                if (myPaper.sectionsConfig.subsubsectionLabelInlineWithText)
                                {
                                    subsubsectionText.Range.Text = subsubsection.title + ". " + subsubsection.content;
                                    int start = 0;
                                    int end = subsubsection.title.Length + 1;
                                    if (myPaper.sectionsConfig.subsubsectionLabelBold)
                                    {
                                        Range rangeToBold = subsubsectionText.Range.Duplicate;
                                        rangeToBold.SetRange(start, end);
                                        rangeToBold.Bold = 1;
                                    }
                                }
                                else if (myPaper.sectionsConfig.subsubsectionLabelOnOwnLine)
                                {
                                    Paragraph labelText = document.Content.Paragraphs.Add(ref missing);
                                    labelText.Range.Text = subsubsection.title;
                                    if (myPaper.sectionsConfig.subsubsectionLabelBold)
                                    {
                                        labelText.Range.Bold = 1;
                                    }
                                    labelText.Range.InsertParagraphAfter();
                                    subsubsectionText.Range.Text = subsubsection.content;
                                }          
                                else
                                {
                                    subsubsectionText.Range.Text = subsubsection.title + ". " + subsubsection.content;
                                    int start = 0;
                                    int end = subsubsection.title.Length + 1;
                                    if (myPaper.sectionsConfig.subsubsectionLabelBold)
                                    {
                                        Range rangeToBold = subsubsectionText.Range.Duplicate;
                                        rangeToBold.SetRange(start, end);
                                        rangeToBold.Bold = 1;
                                    }
                                }                      
                            }
                            subsubsectionText.Range.InsertParagraphAfter();
                        }
                    }
                }

                if (myPaper.includeConclusion)
                {
                    if (myPaper.conclusion.onOwnPage)
                    {
                        Paragraph pagebreak = document.Content.Paragraphs.Add(ref missing);
                        pagebreak.Range.InsertBreak(WdBreakType.wdPageBreak);
                    }
                    if (myPaper.conclusion.includeTitle)
                    {
                        Paragraph labelText = document.Content.Paragraphs.Add(ref missing);
                        labelText.Range.Text = myPaper.conclusion.title;
                        labelText.Range.InsertParagraphAfter();
                    }
                    Paragraph paragraphText = document.Content.Paragraphs.Add(ref missing);
                    paragraphText.Range.Text = myPaper.conclusion.conclusionContent;
                    paragraphText.Range.InsertParagraphAfter();
                }

                if (myPaper.includeReferences)
                {

                }

                //Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
                //object styleHeading1 = "Heading 1";
                //para1.Range.set_Style(ref styleHeading1);
                //para1.Range.Text = "Para 1 text";
                //para1.Range.InsertParagraphAfter();

                //Paragraph para2 = document.Content.Paragraphs.Add(ref missing);
                //object styleHeading2 = "Heading 2";
                //para2.Range.set_Style(ref styleHeading2);
                //para2.Range.Text = "Para 2 text";
                //para2.Range.InsertParagraphAfter();

                object filename = @"C:\Users\Jbeag_000\Desktop\DocXExample.docx";
                document.SaveAs2(ref filename);
                document.Close(ref missing, ref missing, ref missing);
                document = null;
                wordApp.Quit(ref missing, ref missing, ref missing);
                wordApp = null;
                MessageBox.Show("Document created successfully !");
                Process.Start("WINWORD.EXE", (string)filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

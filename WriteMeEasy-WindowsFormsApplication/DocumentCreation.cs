﻿using System;
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

                foreach(Section section in myPaper.sections)
                {
                    if (includeSectionLabelsCheck.Checked)
                    {
                        Paragraph labelText = document.Content.Paragraphs.Add(ref missing);
                        labelText.Range.Text = section.title;
                        labelText.Range.InsertParagraphAfter();
                    }
                    Paragraph sectionText = document.Content.Paragraphs.Add(ref missing);
                    sectionText.Range.Text = section.content;
                    sectionText.Range.InsertParagraphAfter();
                    
                    foreach (SubSection subsection in section.subSections)
                    {
                        if (includeSubsectionLabelCheck.Checked)
                        {
                            Paragraph labelText = document.Content.Paragraphs.Add(ref missing);
                            labelText.Range.Text = subsection.title;
                            labelText.Range.InsertParagraphAfter();
                        }
                        Paragraph subsectionText = document.Content.Paragraphs.Add(ref missing);
                        subsectionText.Range.Text = subsection.content;
                        subsectionText.Range.InsertParagraphAfter();

                        foreach (SubSubSection subsubsection in subsection.subsubSections)
                        {
                            if (includeSubsubsectionLabelCheck.Checked)
                            {
                                Paragraph labelText = document.Content.Paragraphs.Add(ref missing);
                                labelText.Range.Text = subsubsection.title;
                                labelText.Range.InsertParagraphAfter();
                            }
                            Paragraph subsubsectionText = document.Content.Paragraphs.Add(ref missing);
                            subsubsectionText.Range.Text = subsubsection.content;
                            subsubsectionText.Range.InsertParagraphAfter();
                        }
                    }
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

                object filename = @"C:\Users\Jbeagle\Desktop\DocXExample.docx";
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

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
                    Paragraph blankLines1 = document.Content.Paragraphs.Add(ref missing);
                    blankLines1.Range.InsertParagraphAfter();
                    Paragraph blankLines2 = document.Content.Paragraphs.Add(ref missing);
                    blankLines2.Range.InsertParagraphAfter();
                    Paragraph blankLines3 = document.Content.Paragraphs.Add(ref missing);
                    blankLines3.Range.InsertParagraphAfter();
                    Paragraph blankLines4 = document.Content.Paragraphs.Add(ref missing);
                    blankLines4.Range.InsertParagraphAfter();
                    Paragraph blankLines5 = document.Content.Paragraphs.Add(ref missing);
                    blankLines5.Range.InsertParagraphAfter();
                    foreach (string titleItem in myPaper.titlePage.titlePageOrder)
                    {
                        string textToAdd = "";
                        bool includeChecked = false;
                        switch(titleItem)
                        {
                            case "TITLE":
                                includeChecked = myPaper.titlePage.includeTitle;
                                textToAdd = myPaper.titlePage.title;
                                break;
                            case "NAME":
                                includeChecked = myPaper.titlePage.includeName;
                                textToAdd = myPaper.titlePage.name;
                                break;
                            case "CLASS":
                                includeChecked = myPaper.titlePage.includeClass;
                                textToAdd = myPaper.titlePage.className;
                                break;
                            case "PROFESSOR":
                                includeChecked = myPaper.titlePage.includeProfessor;
                                textToAdd = myPaper.titlePage.professor;
                                break;
                            case "SCHOOL":
                                includeChecked = myPaper.titlePage.includeSchool;
                                textToAdd = myPaper.titlePage.school;
                                break;
                            case "DATE":
                                includeChecked = myPaper.titlePage.includeDate;
                                textToAdd = myPaper.titlePage.date;
                                break;
                        }

                        if (includeChecked)
                        {
                            Paragraph lineToAdd = document.Content.Paragraphs.Add(ref missing);
                            lineToAdd.Range.Text = textToAdd;
                            lineToAdd.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                            lineToAdd.Range.InsertParagraphAfter();
                        }                        
                    }
                    Paragraph pagebreak = document.Content.Paragraphs.Add(ref missing);
                    pagebreak.Range.InsertBreak(WdBreakType.wdPageBreak);
                }

                if (myPaper.includeSummary)
                {
                    Paragraph text = document.Content.Paragraphs.Add(ref missing);
                    if (myPaper.summary.includeTitle)
                    {                        
                        if (myPaper.summary.titleBold)
                        {
                            text.Range.Bold = 1;
                        }
                        text.Range.Text = myPaper.summary.title;
                        text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        text.Range.InsertParagraphAfter();
                    }
                    //Paragraph paragraphText = document.Content.Paragraphs.Add(ref missing);
                    text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    text.Range.Bold = 0;
                    text.Range.Text = myPaper.summary.content;
                    text.Range.InsertParagraphAfter();
                    if (myPaper.summary.onOwnPage)
                    {
                        Paragraph pagebreak = document.Content.Paragraphs.Add(ref missing);
                        pagebreak.Range.InsertBreak(WdBreakType.wdPageBreak);
                    }
                }

                if (myPaper.includeAbstract)
                {
                    Paragraph text = document.Content.Paragraphs.Add(ref missing);
                    if (myPaper.abstractConfig.includeTitle)
                    {                        
                        if (myPaper.abstractConfig.titleBold)
                        {
                            text.Range.Bold = 1;
                        }
                        text.Range.Text = myPaper.abstractConfig.title;
                        text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        text.Range.InsertParagraphAfter();
                    }
                    text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    text.Range.Bold = 0;
                    text.Range.Text = myPaper.abstractConfig.content;                    
                    text.Range.InsertParagraphAfter();
                    if (myPaper.abstractConfig.onOwnPage)
                    {
                        Paragraph pagebreak = document.Content.Paragraphs.Add(ref missing);
                        pagebreak.Range.InsertBreak(WdBreakType.wdPageBreak);
                    }
                }                

                foreach(Section section in myPaper.sections)
                {
                    Paragraph text = document.Content.Paragraphs.Add(ref missing);
                    if (includeSectionLabelsCheck.Checked)
                    {
                        if (myPaper.sectionsConfig.sectionLabelInlineWithText)
                        {
                            text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                            text.Range.Text = section.title + ". " + section.content;                            
                            int start = 0;
                            int end = section.title.Length + 1;
                            if (myPaper.sectionsConfig.sectionLabelBold)
                            {
                                Range rangeToBold = text.Range.Duplicate;
                                rangeToBold.SetRange(start, end);
                                rangeToBold.Bold = 1;
                            }                            
                        }
                        else if (myPaper.sectionsConfig.sectionLabelOnOwnLine)
                        {
                            if (myPaper.sectionsConfig.sectionLabelBold)
                            {
                                text.Range.Bold = 1;
                            }
                            text.Range.Text = section.title;
                            text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                            text.Range.InsertParagraphAfter();
                            text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                            text.Range.Bold = 0;
                            text.Range.Text = section.content;
                        }  
                        else
                        {
                            text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                            text.Range.Text = section.title + ". " + section.content;                            
                            int start = 0;
                            int end = section.title.Length + 1;
                            if (myPaper.sectionsConfig.sectionLabelBold)
                            {
                                Range rangeToBold = text.Range.Duplicate;
                                rangeToBold.SetRange(start, end);
                                rangeToBold.Bold = 1;
                            }
                        }                      
                    }
                    else
                    {
                        text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                        text.Range.Text = section.content;                        
                    }
                    text.Range.InsertParagraphAfter();
                    
                    foreach (SubSection subsection in section.subSections)
                    {
                        if (includeSubsectionLabelCheck.Checked)
                        {
                            if (myPaper.sectionsConfig.subsectionLabelInlineWithText)
                            {
                                text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                text.Range.Text = subsection.title + ". " + subsection.content;
                                int start = 0;
                                int end = subsection.title.Length + 1;
                                if (myPaper.sectionsConfig.subsectionLabelBold)
                                {
                                    Range rangeToBold = text.Range.Duplicate;
                                    rangeToBold.SetRange(start, end);
                                    rangeToBold.Bold = 1;
                                }
                            }
                            else if (myPaper.sectionsConfig.subsectionLabelOnOwnLine)
                            {
                                if (myPaper.sectionsConfig.subsectionLabelBold)
                                {
                                    text.Range.Bold = 1;
                                }
                                text.Range.Text = subsection.title;
                                text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                                text.Range.InsertParagraphAfter();
                                text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                text.Range.Bold = 0;
                                text.Range.Text = subsection.content;
                            }   
                            else
                            {
                                text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                text.Range.Text = subsection.title + ". " + subsection.content;
                                int start = 0;
                                int end = subsection.title.Length + 1;
                                if (myPaper.sectionsConfig.subsectionLabelBold)
                                {
                                    Range rangeToBold = text.Range.Duplicate;
                                    rangeToBold.SetRange(start, end);
                                    rangeToBold.Bold = 1;
                                }
                            }                         
                        }
                        else
                        {
                            text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                            text.Range.Text = subsection.content;
                        }
                        text.Range.InsertParagraphAfter();

                        foreach (SubSubSection subsubsection in subsection.subsubSections)
                        {
                            if (includeSubsubsectionLabelCheck.Checked)
                            {
                                if (myPaper.sectionsConfig.subsubsectionLabelInlineWithText)
                                {
                                    text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                    text.Range.Text = subsubsection.title + ". " + subsubsection.content;
                                    int start = 0;
                                    int end = subsubsection.title.Length + 1;
                                    if (myPaper.sectionsConfig.subsubsectionLabelBold)
                                    {
                                        Range rangeToBold = text.Range.Duplicate;
                                        rangeToBold.SetRange(start, end);
                                        rangeToBold.Bold = 1;
                                    }
                                }
                                else if (myPaper.sectionsConfig.subsubsectionLabelOnOwnLine)
                                {
                                    if (myPaper.sectionsConfig.subsubsectionLabelBold)
                                    {
                                        text.Range.Bold = 1;
                                    }
                                    text.Range.Text = subsubsection.title;
                                    text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                                    text.Range.InsertParagraphAfter();
                                    text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                    text.Range.Bold = 0;
                                    text.Range.Text = subsubsection.content;
                                }          
                                else
                                {
                                    text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                    text.Range.Text = subsubsection.title + ". " + subsubsection.content;
                                    int start = 0;
                                    int end = subsubsection.title.Length + 1;
                                    if (myPaper.sectionsConfig.subsubsectionLabelBold)
                                    {
                                        Range rangeToBold = text.Range.Duplicate;
                                        rangeToBold.SetRange(start, end);
                                        rangeToBold.Bold = 1;
                                    }
                                }                      
                            }
                            else
                            {
                                text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                text.Range.Text = subsubsection.content;
                            }
                            text.Range.InsertParagraphAfter();
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
                    Paragraph text = document.Content.Paragraphs.Add(ref missing);
                    if (myPaper.conclusion.includeTitle)
                    {
                        if (myPaper.conclusion.boldTitle)
                        {
                            text.Range.Bold = 1;
                        }
                        text.Range.Text = myPaper.conclusion.title;
                        text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        text.Range.InsertParagraphAfter();
                    }
                    text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    text.Range.Bold = 0;
                    text.Range.Text = myPaper.conclusion.conclusionContent;
                    text.Range.InsertParagraphAfter();
                }

                if (myPaper.includeReferences)
                {

                }

                if (myPaper.includeHeader)
                {

                }

                if (myPaper.includeFooter)
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

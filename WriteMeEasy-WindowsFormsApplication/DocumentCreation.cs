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
                            if (myPaper.titlePage.alignment == "center")
                            {
                                lineToAdd.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                            }
                            else if (myPaper.titlePage.alignment == "left")
                            {
                                lineToAdd.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                            }
                            else if (myPaper.titlePage.alignment == "right")
                            {
                                lineToAdd.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                            }                            
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
                        if (myPaper.summary.titleAlign == "Center")
                        {
                            text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        }
                        else if (myPaper.summary.titleAlign == "Right")
                        {
                            text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                        }
                        else if (myPaper.summary.titleAlign == "Left")
                        {
                            text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                        }
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
                        if (myPaper.abstractConfig.titleAlign == "Center")
                        {
                            text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        }
                        else if (myPaper.abstractConfig.titleAlign == "Right")
                        {
                            text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                        }
                        else if (myPaper.abstractConfig.titleAlign == "Left")
                        {
                            text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                        }
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
                    string[] splitSection = section.content.Split('\n');
                    bool isFirstOfPara = true;
                    foreach(string splitPara in splitSection)
                    {
                        Paragraph sectiontext = document.Content.Paragraphs.Add(ref missing);
                        if (isFirstOfPara)
                        {
                            isFirstOfPara = false;
                            if (includeSectionLabelsCheck.Checked)
                            {
                                if (myPaper.sectionsConfig.sectionLabelInlineWithText)
                                {
                                    sectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                    sectiontext.Range.Text = section.title + ". " + splitPara;
                                    int start = sectiontext.Range.Start;
                                    int end = sectiontext.Range.Start + section.title.Length + 1;
                                    if (myPaper.sectionsConfig.sectionLabelBold)
                                    {
                                        Range rangeToBold = sectiontext.Range.Duplicate;
                                        rangeToBold.SetRange(start, end);
                                        rangeToBold.Bold = 1;
                                    }
                                }
                                else if (myPaper.sectionsConfig.sectionLabelOnOwnLine)
                                {
                                    if (myPaper.sectionsConfig.sectionLabelBold)
                                    {
                                        sectiontext.Range.Bold = 1;
                                    }
                                    sectiontext.Range.Text = section.title;
                                    if (myPaper.sectionsConfig.sectionLabelAlignment == "Center")
                                    {
                                        sectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                                    }
                                    else if (myPaper.sectionsConfig.sectionLabelAlignment == "Right")
                                    {
                                        sectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                                    }
                                    else if (myPaper.sectionsConfig.sectionLabelAlignment == "Left")
                                    {
                                        sectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                    }
                                    sectiontext.Range.InsertParagraphAfter();
                                    sectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                    sectiontext.Range.Bold = 0;
                                    sectiontext.Range.Text = splitPara;
                                }
                                else
                                {
                                    sectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                                    sectiontext.Range.Text = section.title + ". " + splitPara;
                                    int start = sectiontext.Range.Start;
                                    int end = sectiontext.Range.Start + section.title.Length + 1;
                                    if (myPaper.sectionsConfig.sectionLabelBold)
                                    {
                                        Range rangeToBold = sectiontext.Range.Duplicate;
                                        rangeToBold.SetRange(start, end);
                                        rangeToBold.Bold = 1;
                                    }
                                }
                            }
                            else
                            {
                                sectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                sectiontext.Range.Text = splitPara;
                            }
                            sectiontext.Range.InsertParagraphAfter();
                        }
                        else
                        {
                            sectiontext.Range.Text = splitPara;
                            sectiontext.Range.InsertParagraphAfter();
                        }
                    }                   
                    
                    foreach (SubSection subsection in section.subSections)
                    {
                        string[] splitSubsection = subsection.content.Split('\n');
                        bool isFirstOfParaSub = true;
                        foreach (string splitPara in splitSubsection)
                        {
                            Paragraph subsectiontext = document.Content.Paragraphs.Add(ref missing);
                            if (isFirstOfParaSub)
                            {
                                isFirstOfParaSub = false;
                                if (includeSubsectionLabelCheck.Checked)
                                {
                                    if (myPaper.sectionsConfig.subsectionLabelInlineWithText)
                                    {
                                        subsectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                        subsectiontext.Range.Text = subsection.title + ". " + splitPara;
                                        int start = subsectiontext.Range.Start;
                                        int end = subsectiontext.Range.Start + subsection.title.Length + 1;
                                        if (myPaper.sectionsConfig.subsectionLabelBold)
                                        {
                                            Range rangeToBold = subsectiontext.Range.Duplicate;
                                            rangeToBold.SetRange(start, end);
                                            rangeToBold.Bold = 1;
                                        }
                                    }
                                    else if (myPaper.sectionsConfig.subsectionLabelOnOwnLine)
                                    {
                                        if (myPaper.sectionsConfig.subsectionLabelBold)
                                        {
                                            subsectiontext.Range.Bold = 1;
                                        }
                                        subsectiontext.Range.Text = subsection.title;
                                        if (myPaper.sectionsConfig.subsectionLabelAlignment == "Center")
                                        {
                                            subsectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                                        }
                                        else if (myPaper.sectionsConfig.subsectionLabelAlignment == "Right")
                                        {
                                            subsectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                                        }
                                        else if (myPaper.sectionsConfig.subsectionLabelAlignment == "Left")
                                        {
                                            subsectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                        }
                                        subsectiontext.Range.InsertParagraphAfter();
                                        subsectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                        subsectiontext.Range.Bold = 0;
                                        subsectiontext.Range.Text = splitPara;
                                    }
                                    else
                                    {
                                        subsectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                        subsectiontext.Range.Text = subsection.title + ". " + splitPara;
                                        int start = subsectiontext.Range.Start;
                                        int end = subsectiontext.Range.Start + subsection.title.Length + 1;
                                        if (myPaper.sectionsConfig.subsectionLabelBold)
                                        {
                                            Range rangeToBold = subsectiontext.Range.Duplicate;
                                            rangeToBold.SetRange(start, end);
                                            rangeToBold.Bold = 1;
                                        }
                                    }
                                }
                                else
                                {
                                    subsectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                    subsectiontext.Range.Text = splitPara;
                                }
                                subsectiontext.Range.InsertParagraphAfter();
                            }
                            else
                            {
                                subsectiontext.Range.Text = splitPara;
                                subsectiontext.Range.InsertParagraphAfter();
                            }
                        }

                        foreach (SubSubSection subsubsection in subsection.subsubSections)
                        {
                            string[] splitSubsubsection = subsubsection.content.Split('\n');
                            bool isFirstOfParaSubSub = true;
                            foreach (string splitPara in splitSubsubsection)
                            {
                                Paragraph subsubsectiontext = document.Content.Paragraphs.Add(ref missing);
                                if (isFirstOfParaSubSub)
                                {
                                    isFirstOfParaSubSub = false;

                                    if (includeSubsubsectionLabelCheck.Checked)
                                    {
                                        if (myPaper.sectionsConfig.subsubsectionLabelInlineWithText)
                                        {
                                            subsubsectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                            subsubsectiontext.Range.Text = subsubsection.title + ". " + splitPara;
                                            int start = subsubsectiontext.Range.Start;
                                            int end = subsubsectiontext.Range.Start + subsubsection.title.Length + 1;
                                            if (myPaper.sectionsConfig.subsubsectionLabelBold)
                                            {
                                                Range rangeToBold = subsubsectiontext.Range.Duplicate;
                                                rangeToBold.SetRange(start, end);
                                                rangeToBold.Bold = 1;
                                            }
                                        }
                                        else if (myPaper.sectionsConfig.subsubsectionLabelOnOwnLine)
                                        {
                                            if (myPaper.sectionsConfig.subsubsectionLabelBold)
                                            {
                                                subsubsectiontext.Range.Bold = 1;
                                            }
                                            subsubsectiontext.Range.Text = subsubsection.title;
                                            if (myPaper.sectionsConfig.subsubsectionLabelAlignment == "Center")
                                            {
                                                subsubsectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                                            }
                                            else if (myPaper.sectionsConfig.subsubsectionLabelAlignment == "Right")
                                            {
                                                subsubsectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                                            }
                                            else if (myPaper.sectionsConfig.subsubsectionLabelAlignment == "Left")
                                            {
                                                subsubsectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                            }
                                            subsubsectiontext.Range.InsertParagraphAfter();
                                            subsubsectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                            subsubsectiontext.Range.Bold = 0;
                                            subsubsectiontext.Range.Text = splitPara;
                                        }
                                        else
                                        {
                                            subsubsectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                            subsubsectiontext.Range.Text = subsubsection.title + ". " + splitPara;
                                            int start = subsubsectiontext.Range.Start;
                                            int end = subsubsectiontext.Range.Start + subsubsection.title.Length + 1;
                                            if (myPaper.sectionsConfig.subsubsectionLabelBold)
                                            {
                                                Range rangeToBold = subsubsectiontext.Range.Duplicate;
                                                rangeToBold.SetRange(start, end);
                                                rangeToBold.Bold = 1;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        subsubsectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                        subsubsectiontext.Range.Text = splitPara;
                                    }
                                    subsubsectiontext.Range.InsertParagraphAfter();
                                }
                                else
                                {
                                    subsubsectiontext.Range.Text = splitPara;
                                    subsubsectiontext.Range.InsertParagraphAfter();
                                }
                            }
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
                        if (myPaper.conclusion.titleAlign == "Center")
                        {
                            text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        }
                        else if (myPaper.conclusion.titleAlign == "Right")
                        {
                            text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                        }
                        else if (myPaper.conclusion.titleAlign == "Left")
                        {
                            text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                        }
                        
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
                    foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
                    {
                        Range headerRange = section.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                        headerRange.Fields.Add(headerRange, WdFieldType.wdFieldPage);
                        headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                        headerRange.Font.Size = 12;
                        string headerText = constructHeader();
                        headerRange.Text = headerText;
                    }
                }

                if (myPaper.includeFooter)
                {

                }


                //TODO Make this dependent upon the setting
                object beginDoc = document.Content.Start;
                object endDoc = document.Content.End;

                document.Range(ref beginDoc, ref endDoc).Paragraphs.Space2();
                document.Range(ref beginDoc, ref endDoc).Paragraphs.SpaceAfter = 0;
                document.Range(ref beginDoc, ref endDoc).Font.Size = 12;

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

        public string constructHeader()
        {
            string headerText = "";

            if (myPaper.header.leftTitle)
            {
                headerText += myPaper.header.leftTitleText;
            }
            else if (myPaper.header.leftPageNum)
            {
                //add page number
            }
            else if (myPaper.header.leftOther)
            {
                headerText += myPaper.header.leftOtherText;
            }
            headerText += "\t";

            

            if (myPaper.header.rightTitle)
            {
                headerText += myPaper.header.rightTitleText;
            }
            else if (myPaper.header.rightPageNum)
            {
                //add page number
            }
            else if (myPaper.header.rightOther)
            {
                headerText += myPaper.header.rightOtherText;
            }

            return headerText;
        }
    }
}

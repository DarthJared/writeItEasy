using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
//using Novacode;
using Microsoft.Office.Interop.Word;
using System.Text.RegularExpressions;

namespace WriteMeEasy_WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        public string fontPattern = @"\\ffffffffff\\.{1,20}\\ffffffffffff\\";
        public string sizePattern = @"\\ssssssssss\\.{1,20}\\ssssssssssss\\";

        private void writeFile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            saveToObject();

            string fileName = writeFile.FileName;
            if (fileName.Length > 0)
            {
                if (fileName.Length > 5)
                {
                    string ext = fileName[fileName.Length - 5].ToString() + fileName[fileName.Length - 4].ToString() + fileName[fileName.Length - 3].ToString() + fileName[fileName.Length - 2].ToString() + fileName[fileName.Length - 1].ToString();
                    if (!ext.Equals(".docx"))
                    {
                        fileName += ".docx";
                    }
                }
                else
                {
                    fileName += ".docx";
                }
                try
                {
                    Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                    wordApp.ShowAnimation = false;
                    wordApp.Visible = false;

                    object missing = System.Reflection.Missing.Value;

                    Document document = wordApp.Documents.Add(ref missing);

                    if (myPaper.includeTitlePage)
                    {
                        if (myPaper.titlePage.ownPage)
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
                        }
                        
                        foreach (string titleItem in myPaper.titlePage.titlePageOrder)
                        {
                            string textToAdd = "";
                            bool includeChecked = false;
                            switch (titleItem)
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
                                lineToAdd.Range.Font.Name = "Times New Roman";
                                lineToAdd.Range.Font.Size = 12;
                                lineToAdd.Range.InsertParagraphAfter();
                            }
                        }
                        if (myPaper.titlePage.ownPage)
                        {
                            Paragraph pagebreak = document.Content.Paragraphs.Add(ref missing);
                            pagebreak.Range.InsertBreak(WdBreakType.wdPageBreak);
                        }
                    }

                    if (myPaper.includeAbstract)
                    {
                        string[] splitAbstract = myPaper.abstractConfig.content.Split('\n');
                        bool isFirstOfPara = true;

                        foreach (string splitPara in splitAbstract)
                        {
                            Paragraph text = document.Content.Paragraphs.Add(ref missing);
                            if (isFirstOfPara)
                            {
                                isFirstOfPara = false;

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
                                    text.Range.ParagraphFormat.FirstLineIndent = 0;
                                    text.Range.Font.Name = myPaper.abstractConfig.titleFont;
                                    text.Range.Font.Size = myPaper.abstractConfig.titleSize;
                                    string[] colors = myPaper.abstractConfig.titleColor.Split(',');
                                    Color color = Color.FromArgb(Convert.ToInt32(colors[3]), Convert.ToInt32(colors[0]), Convert.ToInt32(colors[1]), Convert.ToInt32(colors[2]));
                                    text.Range.Font.Color = (WdColor)(color.R + 0x100 * color.G + 0x10000 * color.B);
                                    text.Range.InsertParagraphAfter();
                                }

                                string unformatted = Regex.Replace(Regex.Replace(splitPara.Replace('\b'.ToString(), "").Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, ""), sizePattern, "");
                                text.Range.Text = unformatted;
                                text.Range.ParagraphFormat.LeftIndent = 0;
                                text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                text.Range.Bold = 0;
                                text.Range.Font.Color = WdColor.wdColorBlack;

                                string noFontSize = Regex.Replace(Regex.Replace(splitPara, fontPattern, ""), sizePattern, "");

                                string[] splitIndent = noFontSize.Split('\v');
                                for (int i = 0; i < splitIndent.Length; i++)
                                {
                                    if (i % 2 == 1)
                                    {
                                        int previousSplitLength = 0;
                                        for (int j = i - 1; j >= 0; j--)
                                        {
                                            previousSplitLength += splitIndent[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "").Length;
                                        }
                                        string unformattedSplit = splitIndent[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "");
                                        Range rangeToIndent = text.Range.Duplicate;
                                        rangeToIndent.SetRange(previousSplitLength + text.Range.Start, previousSplitLength + unformattedSplit.Length + text.Range.Start);
                                        rangeToIndent.ParagraphFormat.LeftIndent = 36;
                                    }
                                }

                                string[] splitBold = noFontSize.Split('\b');
                                for (int i = 0; i < splitBold.Length; i++)
                                {
                                    if (i % 2 == 1)
                                    {
                                        int previousSplitLength = 0;
                                        for (int j = i - 1; j >= 0; j--)
                                        {
                                            previousSplitLength += splitBold[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                        }
                                        string unformattedSplit = splitBold[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                        Range rangeToBold = text.Range.Duplicate;
                                        rangeToBold.SetRange(previousSplitLength + text.Range.Start, previousSplitLength + unformattedSplit.Length + text.Range.Start);
                                        rangeToBold.Bold = 1;
                                    }
                                }

                                string[] splitItalic = noFontSize.Split('\a');
                                for (int i = 0; i < splitItalic.Length; i++)
                                {
                                    if (i % 2 == 1)
                                    {
                                        int previousSplitLength = 0;
                                        for (int j = i - 1; j >= 0; j--)
                                        {
                                            previousSplitLength += splitItalic[j].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                        }
                                        string unformattedSplit = splitItalic[i].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                        Range rangeToItalic = text.Range.Duplicate;
                                        rangeToItalic.SetRange(previousSplitLength + text.Range.Start, previousSplitLength + unformattedSplit.Length + text.Range.Start);
                                        rangeToItalic.Italic = 1;
                                    }
                                }

                                string[] splitUnderline = noFontSize.Split('\f');
                                for (int i = 0; i < splitUnderline.Length; i++)
                                {
                                    if (i % 2 == 1)
                                    {
                                        int previousSplitLength = 0;
                                        for (int j = i - 1; j >= 0; j--)
                                        {
                                            previousSplitLength += splitUnderline[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                        }
                                        string unformattedSplit = splitUnderline[i].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "");
                                        Range rangeToUnderline = text.Range.Duplicate;
                                        rangeToUnderline.SetRange(previousSplitLength + text.Range.Start, previousSplitLength + unformattedSplit.Length + text.Range.Start);
                                        rangeToUnderline.Underline = WdUnderline.wdUnderlineSingle;
                                    }
                                }

                                string secondFontPattern = @".{1,20}\\ffffffffffff\\";
                                string sizeRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), sizePattern, "");
                                string[] splitFont = sizeRemoved.Split(new string[] { "\\ffffffffff\\" }, StringSplitOptions.None); //Regex.Split(myPaper.summary.content, fontPattern);
                                for (int i = 0; i < splitFont.Length; i++)
                                {
                                    if (splitFont[i].Length > 0)
                                    {
                                        string[] fontParts = splitFont[i].Split(new string[] { "\\ffffffffffff\\" }, StringSplitOptions.None);
                                        string currentFont = fontParts[0];
                                        int previousSplitLength = 0;
                                        if (i > 0)
                                        {
                                            for (int j = i - 1; j >= 0; j--)
                                            {
                                                string unformattedContent = splitFont[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                string noFont = Regex.Replace(unformattedContent, secondFontPattern, "");
                                                previousSplitLength += noFont.Length;
                                            }
                                        }
                                        string unformattedSplit = fontParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                        Range rangeToFontChange = text.Range.Duplicate;
                                        rangeToFontChange.SetRange(previousSplitLength + text.Range.Start, previousSplitLength + unformattedSplit.Length + text.Range.Start);
                                        rangeToFontChange.Font.Name = currentFont;
                                    }
                                }

                                string secondSizePattern = @".{1,20}\\ssssssssssss\\";
                                string fontRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                string[] splitSize = fontRemoved.Split(new string[] { "\\ssssssssss\\" }, StringSplitOptions.None);
                                for (int i = 0; i < splitSize.Length; i++)
                                {
                                    if (splitSize[i].Length > 0)
                                    {
                                        string[] sizeParts = splitSize[i].Split(new string[] { "\\ssssssssssss\\" }, StringSplitOptions.None);
                                        string currentSize = sizeParts[0];
                                        int previousSplitLength = 0;
                                        if (i > 0)
                                        {
                                            for (int j = i - 1; j >= 0; j--)
                                            {
                                                string unformattedContent = Regex.Replace(splitSize[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                                string noSize = Regex.Replace(unformattedContent, secondSizePattern, "");
                                                previousSplitLength += noSize.Length;
                                            }
                                        }
                                        string unformattedSplit = sizeParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                        Range rangeToSizeChange = text.Range.Duplicate;
                                        rangeToSizeChange.SetRange(previousSplitLength + text.Range.Start, previousSplitLength + unformattedSplit.Length + text.Range.Start);
                                        rangeToSizeChange.Font.Size = (float)Convert.ToDouble(currentSize);
                                    }
                                }

                                if (text.Range.ParagraphFormat.LeftIndent != 36)
                                {
                                    text.Range.ParagraphFormat.FirstLineIndent = 36;
                                }
                                else
                                {
                                    text.Range.ParagraphFormat.FirstLineIndent = 0;
                                }
                                text.Range.InsertParagraphAfter();
                            }
                            else
                            {
                                string unformatted = Regex.Replace(Regex.Replace(splitPara.Replace('\b'.ToString(), "").Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, ""), sizePattern, "");
                                text.Range.Text = unformatted;
                                text.Range.ParagraphFormat.LeftIndent = 0;
                                text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                text.Range.Bold = 0;

                                string noFontSize = Regex.Replace(Regex.Replace(splitPara, fontPattern, ""), sizePattern, "");

                                string[] splitIndent = noFontSize.Split('\v');
                                for (int i = 0; i < splitIndent.Length; i++)
                                {
                                    if (i % 2 == 1)
                                    {
                                        int previousSplitLength = 0;
                                        for (int j = i - 1; j >= 0; j--)
                                        {
                                            previousSplitLength += splitIndent[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "").Length;
                                        }
                                        string unformattedSplit = splitIndent[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "");
                                        Range rangeToIndent = text.Range.Duplicate;
                                        rangeToIndent.SetRange(previousSplitLength + text.Range.Start, previousSplitLength + unformattedSplit.Length + text.Range.Start);
                                        rangeToIndent.ParagraphFormat.LeftIndent = 36;
                                    }
                                }

                                string[] splitBold = noFontSize.Split('\b');
                                for (int i = 0; i < splitBold.Length; i++)
                                {
                                    if (i % 2 == 1)
                                    {
                                        int previousSplitLength = 0;
                                        for (int j = i - 1; j >= 0; j--)
                                        {
                                            previousSplitLength += splitBold[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                        }
                                        string unformattedSplit = splitBold[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                        Range rangeToBold = text.Range.Duplicate;
                                        rangeToBold.SetRange(previousSplitLength + text.Range.Start, previousSplitLength + unformattedSplit.Length + text.Range.Start);
                                        rangeToBold.Bold = 1;
                                    }
                                }

                                string[] splitItalic = noFontSize.Split('\a');
                                for (int i = 0; i < splitItalic.Length; i++)
                                {
                                    if (i % 2 == 1)
                                    {
                                        int previousSplitLength = 0;
                                        for (int j = i - 1; j >= 0; j--)
                                        {
                                            previousSplitLength += splitItalic[j].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                        }
                                        string unformattedSplit = splitItalic[i].Replace('\b'.ToString(), "").Replace('\f'.ToString().Replace('\v'.ToString(), ""), "");
                                        Range rangeToItalic = text.Range.Duplicate;
                                        rangeToItalic.SetRange(previousSplitLength + text.Range.Start, previousSplitLength + unformattedSplit.Length + text.Range.Start);
                                        rangeToItalic.Italic = 1;
                                    }
                                }

                                string[] splitUnderline = noFontSize.Split('\f');
                                for (int i = 0; i < splitUnderline.Length; i++)
                                {
                                    if (i % 2 == 1)
                                    {
                                        int previousSplitLength = 0;
                                        for (int j = i - 1; j >= 0; j--)
                                        {
                                            previousSplitLength += splitUnderline[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                        }
                                        string unformattedSplit = splitUnderline[i].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "");
                                        Range rangeToUnderline = text.Range.Duplicate;
                                        rangeToUnderline.SetRange(previousSplitLength + text.Range.Start, previousSplitLength + unformattedSplit.Length + text.Range.Start);
                                        rangeToUnderline.Underline = WdUnderline.wdUnderlineSingle;
                                    }
                                }

                                string secondFontPattern = @".{1,20}\\ffffffffffff\\";
                                string sizeRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), sizePattern, "");
                                string[] splitFont = sizeRemoved.Split(new string[] { "\\ffffffffff\\" }, StringSplitOptions.None); //Regex.Split(myPaper.summary.content, fontPattern);
                                for (int i = 0; i < splitFont.Length; i++)
                                {
                                    if (splitFont[i].Length > 0)
                                    {
                                        string[] fontParts = splitFont[i].Split(new string[] { "\\ffffffffffff\\" }, StringSplitOptions.None);
                                        string currentFont = fontParts[0];
                                        int previousSplitLength = 0;
                                        if (i > 0)
                                        {
                                            for (int j = i - 1; j >= 0; j--)
                                            {
                                                string unformattedContent = splitFont[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                string noFont = Regex.Replace(unformattedContent, secondFontPattern, "");
                                                previousSplitLength += noFont.Length;
                                            }
                                        }
                                        string unformattedSplit = fontParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                        Range rangeToFontChange = text.Range.Duplicate;
                                        rangeToFontChange.SetRange(previousSplitLength + text.Range.Start, previousSplitLength + unformattedSplit.Length + text.Range.Start);
                                        rangeToFontChange.Font.Name = currentFont;
                                    }
                                }

                                string secondSizePattern = @".{1,20}\\ssssssssssss\\";
                                string fontRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                string[] splitSize = fontRemoved.Split(new string[] { "\\ssssssssss\\" }, StringSplitOptions.None);
                                for (int i = 0; i < splitSize.Length; i++)
                                {
                                    if (splitSize[i].Length > 0)
                                    {
                                        string[] sizeParts = splitSize[i].Split(new string[] { "\\ssssssssssss\\" }, StringSplitOptions.None);
                                        string currentSize = sizeParts[0];
                                        int previousSplitLength = 0;
                                        if (i > 0)
                                        {
                                            for (int j = i - 1; j >= 0; j--)
                                            {
                                                string unformattedContent = Regex.Replace(splitSize[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                                string noSize = Regex.Replace(unformattedContent, secondSizePattern, "");
                                                previousSplitLength += noSize.Length;
                                            }
                                        }
                                        string unformattedSplit = sizeParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                        Range rangeToSizeChange = text.Range.Duplicate;
                                        rangeToSizeChange.SetRange(previousSplitLength + text.Range.Start, previousSplitLength + unformattedSplit.Length + text.Range.Start);
                                        rangeToSizeChange.Font.Size = (float)Convert.ToDouble(currentSize);
                                    }
                                }

                                if (text.Range.ParagraphFormat.LeftIndent != 36)
                                {
                                    text.Range.ParagraphFormat.FirstLineIndent = 36;
                                }
                                else
                                {
                                    text.Range.ParagraphFormat.FirstLineIndent = 0;
                                }
                                text.Range.InsertParagraphAfter();
                            }
                        }


                        if (myPaper.abstractConfig.onOwnPage)
                        {
                            Paragraph pagebreak = document.Content.Paragraphs.Add(ref missing);
                            pagebreak.Range.InsertBreak(WdBreakType.wdPageBreak);
                        }
                    }

                    foreach (Section section in myPaper.sections)
                    {
                        string[] splitSection = section.content.Split('\n');
                        bool isFirstOfPara = true;
                        foreach (string splitPara in splitSection)
                        {
                            Paragraph sectiontext = document.Content.Paragraphs.Add(ref missing);
                            if (isFirstOfPara)
                            {
                                isFirstOfPara = false;
                                if (includeSectionLabelsCheck.Checked)
                                {
                                    if (myPaper.sectionsConfig.sectionLabelInlineWithText)
                                    {
                                        string unformatted = Regex.Replace(Regex.Replace(splitPara.Replace('\b'.ToString(), "").Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, ""), sizePattern, "");
                                        sectiontext.Range.Text = section.title + ". " + unformatted;

                                        Range rangeForFontSize = sectiontext.Range.Duplicate;
                                        rangeForFontSize.SetRange(sectiontext.Range.Start, sectiontext.Range.Start + section.title.Length + 2);
                                        rangeForFontSize.Font.Name = myPaper.sectionsConfig.sectionLabelFont;
                                        rangeForFontSize.Font.Size = myPaper.sectionsConfig.sectionLabelSize;
                                        string[] colors = myPaper.sectionsConfig.sectionLabelColor.Split(',');
                                        Color color = Color.FromArgb(Convert.ToInt32(colors[3]), Convert.ToInt32(colors[0]), Convert.ToInt32(colors[1]), Convert.ToInt32(colors[2]));
                                        rangeForFontSize.Font.Color = (WdColor)(color.R + 0x100 * color.G + 0x10000 * color.B);

                                        sectiontext.Range.ParagraphFormat.LeftIndent = 0;
                                        sectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                        
                                        string noFontSize = Regex.Replace(Regex.Replace(splitPara, fontPattern, ""), sizePattern, "");

                                        string[] splitIndent = noFontSize.Split('\v');
                                        for (int i = 0; i < splitIndent.Length; i++)
                                        {
                                            if (i % 2 == 1)
                                            {
                                                int previousSplitLength = 0;
                                                for (int j = i - 1; j >= 0; j--)
                                                {
                                                    previousSplitLength += splitIndent[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "").Length;
                                                }
                                                string unformattedSplit = splitIndent[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "");
                                                Range rangeToIndent = sectiontext.Range.Duplicate;
                                                rangeToIndent.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                                rangeToIndent.ParagraphFormat.LeftIndent = 36;
                                            }
                                        }

                                        string[] splitBold = noFontSize.Split('\b');
                                        for (int i = 0; i < splitBold.Length; i++)
                                        {
                                            if (i % 2 == 1)
                                            {
                                                int previousSplitLength = section.title.Length + 2;
                                                for (int j = i - 1; j >= 0; j--)
                                                {
                                                    previousSplitLength += splitBold[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                }
                                                previousSplitLength += section.title.Length + 2;
                                                string unformattedSplit = splitBold[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToBold = sectiontext.Range.Duplicate;
                                                rangeToBold.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                                rangeToBold.Bold = 1;
                                            }
                                        }

                                        string[] splitItalic = noFontSize.Split('\a');
                                        for (int i = 0; i < splitItalic.Length; i++)
                                        {
                                            if (i % 2 == 1)
                                            {
                                                int previousSplitLength = section.title.Length + 2;
                                                for (int j = i - 1; j >= 0; j--)
                                                {
                                                    previousSplitLength += splitItalic[j].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                }
                                                previousSplitLength += section.title.Length + 2;
                                                string unformattedSplit = splitItalic[i].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToItalic = sectiontext.Range.Duplicate;
                                                rangeToItalic.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                                rangeToItalic.Italic = 1;
                                            }
                                        }

                                        string[] splitUnderline = noFontSize.Split('\f');
                                        for (int i = 0; i < splitUnderline.Length; i++)
                                        {
                                            if (i % 2 == 1)
                                            {
                                                int previousSplitLength = section.title.Length + 2;
                                                for (int j = i - 1; j >= 0; j--)
                                                {
                                                    previousSplitLength += splitUnderline[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                }
                                                previousSplitLength += section.title.Length + 2;
                                                string unformattedSplit = splitUnderline[i].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToUnderline = sectiontext.Range.Duplicate;
                                                rangeToUnderline.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                                rangeToUnderline.Underline = WdUnderline.wdUnderlineSingle;
                                            }
                                        }

                                        string secondFontPattern = @".{1,20}\\ffffffffffff\\";
                                        string sizeRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), sizePattern, "");
                                        string[] splitFont = sizeRemoved.Split(new string[] { "\\ffffffffff\\" }, StringSplitOptions.None); //Regex.Split(myPaper.summary.content, fontPattern);
                                        for (int i = 0; i < splitFont.Length; i++)
                                        {
                                            if (splitFont[i].Length > 0)
                                            {
                                                string[] fontParts = splitFont[i].Split(new string[] { "\\ffffffffffff\\" }, StringSplitOptions.None);
                                                string currentFont = fontParts[0];
                                                int previousSplitLength = section.title.Length + 2;
                                                if (i > 0)
                                                {
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        string unformattedContent = splitFont[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                        string noFont = Regex.Replace(unformattedContent, secondFontPattern, "");
                                                        previousSplitLength += noFont.Length;
                                                    }
                                                }
                                                string unformattedSplit = fontParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToFontChange = sectiontext.Range.Duplicate;
                                                rangeToFontChange.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                                rangeToFontChange.Font.Name = currentFont;
                                            }
                                        }

                                        string secondSizePattern = @".{1,20}\\ssssssssssss\\";
                                        string fontRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                        string[] splitSize = fontRemoved.Split(new string[] { "\\ssssssssss\\" }, StringSplitOptions.None);
                                        for (int i = 0; i < splitSize.Length; i++)
                                        {
                                            if (splitSize[i].Length > 0)
                                            {
                                                string[] sizeParts = splitSize[i].Split(new string[] { "\\ssssssssssss\\" }, StringSplitOptions.None);
                                                string currentSize = sizeParts[0];
                                                int previousSplitLength = section.title.Length + 2;
                                                if (i > 0)
                                                {
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        string unformattedContent = Regex.Replace(splitSize[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                                        string noSize = Regex.Replace(unformattedContent, secondSizePattern, "");
                                                        previousSplitLength += noSize.Length;
                                                    }
                                                }
                                                string unformattedSplit = sizeParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToSizeChange = sectiontext.Range.Duplicate;
                                                rangeToSizeChange.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                                rangeToSizeChange.Font.Size = (float)Convert.ToDouble(currentSize);
                                            }
                                        }

                                        if (sectiontext.Range.ParagraphFormat.LeftIndent != 36)
                                        {
                                            sectiontext.Range.ParagraphFormat.FirstLineIndent = 36;
                                        }
                                        else
                                        {
                                            sectiontext.Range.ParagraphFormat.FirstLineIndent = 0;
                                        }

                                        int start = sectiontext.Range.Start;
                                        int end = sectiontext.Range.Start + section.title.Length + 1;
                                        if (myPaper.sectionsConfig.sectionLabelBold)
                                        {
                                            Range rangeToBold = sectiontext.Range.Duplicate;
                                            rangeToBold.SetRange(start, end);
                                            rangeToBold.Bold = 1;
                                        }
                                        if (myPaper.sectionsConfig.sectionLabelItalics)
                                        {
                                            Range rangeToItalicize = sectiontext.Range.Duplicate;
                                            rangeToItalicize.SetRange(start, end);
                                            rangeToItalicize.Italic = 1;
                                        }
                                    }
                                    else if (myPaper.sectionsConfig.sectionLabelOnOwnLine)
                                    {
                                        if (myPaper.sectionsConfig.sectionLabelBold)
                                        {
                                            sectiontext.Range.Bold = 1;
                                        }
                                        if (myPaper.sectionsConfig.sectionLabelItalics)
                                        {
                                            sectiontext.Range.Italic = 1;
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
                                        if (sectiontext.Range.ParagraphFormat.LeftIndent != 36)
                                        {
                                            sectiontext.Range.ParagraphFormat.FirstLineIndent = 36;
                                        }
                                        else
                                        {
                                            sectiontext.Range.ParagraphFormat.FirstLineIndent = 0;
                                        }
                                        sectiontext.Range.Font.Name = myPaper.sectionsConfig.sectionLabelFont;
                                        sectiontext.Range.Font.Size = myPaper.sectionsConfig.sectionLabelSize;
                                        string[] colors = myPaper.sectionsConfig.sectionLabelColor.Split(',');
                                        Color color = Color.FromArgb(Convert.ToInt32(colors[3]), Convert.ToInt32(colors[0]), Convert.ToInt32(colors[1]), Convert.ToInt32(colors[2]));
                                        sectiontext.Range.Font.Color = (WdColor)(color.R + 0x100 * color.G + 0x10000 * color.B);

                                        sectiontext.Range.InsertParagraphAfter();
                                        sectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                        sectiontext.Range.Bold = 0;
                                        sectiontext.Range.Italic = 0;
                                        sectiontext.Range.Font.Color = WdColor.wdColorBlack;

                                        string unformatted = Regex.Replace(Regex.Replace(splitPara.Replace('\b'.ToString(), "").Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, ""), sizePattern, "");
                                        sectiontext.Range.Text = unformatted;
                                        sectiontext.Range.ParagraphFormat.LeftIndent = 0;

                                        string noFontSize = Regex.Replace(Regex.Replace(splitPara, fontPattern, ""), sizePattern, "");

                                        string[] splitIndent = noFontSize.Split('\v');
                                        for (int i = 0; i < splitIndent.Length; i++)
                                        {
                                            if (i % 2 == 1)
                                            {
                                                int previousSplitLength = 0;
                                                for (int j = i - 1; j >= 0; j--)
                                                {
                                                    previousSplitLength += splitIndent[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "").Length;
                                                }
                                                string unformattedSplit = splitIndent[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "");
                                                Range rangeToIndent = sectiontext.Range.Duplicate;
                                                rangeToIndent.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                                rangeToIndent.ParagraphFormat.LeftIndent = 36;
                                            }
                                        }

                                        string[] splitBold = noFontSize.Split('\b');
                                        for (int i = 0; i < splitBold.Length; i++)
                                        {
                                            if (i % 2 == 1)
                                            {
                                                int previousSplitLength = 0;
                                                for (int j = i - 1; j >= 0; j--)
                                                {
                                                    previousSplitLength += splitBold[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                }
                                                string unformattedSplit = splitBold[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToBold = sectiontext.Range.Duplicate;
                                                rangeToBold.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                                rangeToBold.Bold = 1;
                                            }
                                        }

                                        string[] splitItalic = noFontSize.Split('\a');
                                        for (int i = 0; i < splitItalic.Length; i++)
                                        {
                                            if (i % 2 == 1)
                                            {
                                                int previousSplitLength = 0;
                                                for (int j = i - 1; j >= 0; j--)
                                                {
                                                    previousSplitLength += splitItalic[j].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                }
                                                string unformattedSplit = splitItalic[i].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToItalic = sectiontext.Range.Duplicate;
                                                rangeToItalic.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                                rangeToItalic.Italic = 1;
                                            }
                                        }

                                        string[] splitUnderline = noFontSize.Split('\f');
                                        for (int i = 0; i < splitUnderline.Length; i++)
                                        {
                                            if (i % 2 == 1)
                                            {
                                                int previousSplitLength = 0;
                                                for (int j = i - 1; j >= 0; j--)
                                                {
                                                    previousSplitLength += splitUnderline[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                }
                                                string unformattedSplit = splitUnderline[i].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToUnderline = sectiontext.Range.Duplicate;
                                                rangeToUnderline.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                                rangeToUnderline.Underline = WdUnderline.wdUnderlineSingle;
                                            }
                                        }

                                        string secondFontPattern = @".{1,20}\\ffffffffffff\\";
                                        string sizeRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), sizePattern, "");
                                        string[] splitFont = sizeRemoved.Split(new string[] { "\\ffffffffff\\" }, StringSplitOptions.None); //Regex.Split(myPaper.summary.content, fontPattern);
                                        for (int i = 0; i < splitFont.Length; i++)
                                        {
                                            if (splitFont[i].Length > 0)
                                            {
                                                string[] fontParts = splitFont[i].Split(new string[] { "\\ffffffffffff\\" }, StringSplitOptions.None);
                                                string currentFont = fontParts[0];
                                                int previousSplitLength = 0;
                                                if (i > 0)
                                                {
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        string unformattedContent = splitFont[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                        string noFont = Regex.Replace(unformattedContent, secondFontPattern, "");
                                                        previousSplitLength += noFont.Length;
                                                    }
                                                }
                                                string unformattedSplit = fontParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToFontChange = sectiontext.Range.Duplicate;
                                                rangeToFontChange.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                                rangeToFontChange.Font.Name = currentFont;
                                            }
                                        }

                                        string secondSizePattern = @".{1,20}\\ssssssssssss\\";
                                        string fontRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                        string[] splitSize = fontRemoved.Split(new string[] { "\\ssssssssss\\" }, StringSplitOptions.None);
                                        for (int i = 0; i < splitSize.Length; i++)
                                        {
                                            if (splitSize[i].Length > 0)
                                            {
                                                string[] sizeParts = splitSize[i].Split(new string[] { "\\ssssssssssss\\" }, StringSplitOptions.None);
                                                string currentSize = sizeParts[0];
                                                int previousSplitLength = 0;
                                                if (i > 0)
                                                {
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        string unformattedContent = Regex.Replace(splitSize[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                                        string noSize = Regex.Replace(unformattedContent, secondSizePattern, "");
                                                        previousSplitLength += noSize.Length;
                                                    }
                                                }
                                                string unformattedSplit = sizeParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToSizeChange = sectiontext.Range.Duplicate;
                                                rangeToSizeChange.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                                rangeToSizeChange.Font.Size = (float)Convert.ToDouble(currentSize);
                                            }
                                        }

                                        if (sectiontext.Range.ParagraphFormat.LeftIndent != 36)
                                        {
                                            sectiontext.Range.ParagraphFormat.FirstLineIndent = 36;
                                        }
                                        else
                                        {
                                            sectiontext.Range.ParagraphFormat.FirstLineIndent = 0;
                                        }
                                    }
                                    else
                                    {
                                        string unformatted = Regex.Replace(Regex.Replace(splitPara.Replace('\b'.ToString(), "").Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, ""), sizePattern, "");
                                        sectiontext.Range.Text = section.title + ". " + unformatted;
                                        sectiontext.Range.ParagraphFormat.LeftIndent = 0;
                                        sectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                                        Range rangeForFontSize = sectiontext.Range.Duplicate;
                                        rangeForFontSize.SetRange(sectiontext.Range.Start, sectiontext.Range.Start + section.title.Length + 2);
                                        rangeForFontSize.Font.Name = myPaper.sectionsConfig.sectionLabelFont;
                                        rangeForFontSize.Font.Size = myPaper.sectionsConfig.sectionLabelSize;
                                        string[] colors = myPaper.sectionsConfig.sectionLabelColor.Split(',');
                                        Color color = Color.FromArgb(Convert.ToInt32(colors[3]), Convert.ToInt32(colors[0]), Convert.ToInt32(colors[1]), Convert.ToInt32(colors[2]));
                                        rangeForFontSize.Font.Color = (WdColor)(color.R + 0x100 * color.G + 0x10000 * color.B);

                                        string noFontSize = Regex.Replace(Regex.Replace(splitPara, fontPattern, ""), sizePattern, "");

                                        string[] splitIndent = noFontSize.Split('\v');
                                        for (int i = 0; i < splitIndent.Length; i++)
                                        {
                                            if (i % 2 == 1)
                                            {
                                                int previousSplitLength = 0;
                                                for (int j = i - 1; j >= 0; j--)
                                                {
                                                    previousSplitLength += splitIndent[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "").Length;
                                                }
                                                string unformattedSplit = splitIndent[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "");
                                                Range rangeToIndent = sectiontext.Range.Duplicate;
                                                rangeToIndent.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                                rangeToIndent.ParagraphFormat.LeftIndent = 36;
                                            }
                                        }

                                        string[] splitBold = noFontSize.Split('\b');
                                        for (int i = 0; i < splitBold.Length; i++)
                                        {
                                            if (i % 2 == 1)
                                            {
                                                int previousSplitLength = section.title.Length + 2;
                                                for (int j = i - 1; j >= 0; j--)
                                                {
                                                    previousSplitLength += splitBold[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                }
                                                previousSplitLength += section.title.Length + 2;
                                                string unformattedSplit = splitBold[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToBold = sectiontext.Range.Duplicate;
                                                rangeToBold.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                                rangeToBold.Bold = 1;
                                            }
                                        }

                                        string[] splitItalic = noFontSize.Split('\a');
                                        for (int i = 0; i < splitItalic.Length; i++)
                                        {
                                            if (i % 2 == 1)
                                            {
                                                int previousSplitLength = section.title.Length + 2;
                                                for (int j = i - 1; j >= 0; j--)
                                                {
                                                    previousSplitLength += splitItalic[j].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                }
                                                previousSplitLength += section.title.Length + 2;
                                                string unformattedSplit = splitItalic[i].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToItalic = sectiontext.Range.Duplicate;
                                                rangeToItalic.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                                rangeToItalic.Italic = 1;
                                            }
                                        }

                                        string[] splitUnderline = noFontSize.Split('\f');
                                        for (int i = 0; i < splitUnderline.Length; i++)
                                        {
                                            if (i % 2 == 1)
                                            {
                                                int previousSplitLength = section.title.Length + 2;
                                                for (int j = i - 1; j >= 0; j--)
                                                {
                                                    previousSplitLength += splitUnderline[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                }
                                                previousSplitLength += section.title.Length + 2;
                                                string unformattedSplit = splitUnderline[i].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToUnderline = sectiontext.Range.Duplicate;
                                                rangeToUnderline.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                                rangeToUnderline.Underline = WdUnderline.wdUnderlineSingle;
                                            }
                                        }

                                        string secondFontPattern = @".{1,20}\\ffffffffffff\\";
                                        string sizeRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), sizePattern, "");
                                        string[] splitFont = sizeRemoved.Split(new string[] { "\\ffffffffff\\" }, StringSplitOptions.None); //Regex.Split(myPaper.summary.content, fontPattern);
                                        for (int i = 0; i < splitFont.Length; i++)
                                        {
                                            if (splitFont[i].Length > 0)
                                            {
                                                string[] fontParts = splitFont[i].Split(new string[] { "\\ffffffffffff\\" }, StringSplitOptions.None);
                                                string currentFont = fontParts[0];
                                                int previousSplitLength = section.title.Length + 2;
                                                if (i > 0)
                                                {
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        string unformattedContent = splitFont[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString().Replace('\v'.ToString(), ""), "");
                                                        string noFont = Regex.Replace(unformattedContent, secondFontPattern, "");
                                                        previousSplitLength += noFont.Length;
                                                    }
                                                }
                                                string unformattedSplit = fontParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToFontChange = sectiontext.Range.Duplicate;
                                                rangeToFontChange.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                                rangeToFontChange.Font.Name = currentFont;
                                            }
                                        }

                                        string secondSizePattern = @".{1,20}\\ssssssssssss\\";
                                        string fontRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                        string[] splitSize = fontRemoved.Split(new string[] { "\\ssssssssss\\" }, StringSplitOptions.None);
                                        for (int i = 0; i < splitSize.Length; i++)
                                        {
                                            if (splitSize[i].Length > 0)
                                            {
                                                string[] sizeParts = splitSize[i].Split(new string[] { "\\ssssssssssss\\" }, StringSplitOptions.None);
                                                string currentSize = sizeParts[0];
                                                int previousSplitLength = section.title.Length + 2;
                                                if (i > 0)
                                                {
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        string unformattedContent = Regex.Replace(splitSize[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                                        string noSize = Regex.Replace(unformattedContent, secondSizePattern, "");
                                                        previousSplitLength += noSize.Length;
                                                    }
                                                }
                                                string unformattedSplit = sizeParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToSizeChange = sectiontext.Range.Duplicate;
                                                rangeToSizeChange.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                                rangeToSizeChange.Font.Size = (float)Convert.ToDouble(currentSize);
                                            }
                                        }

                                        if (sectiontext.Range.ParagraphFormat.LeftIndent != 36)
                                        {
                                            sectiontext.Range.ParagraphFormat.FirstLineIndent = 36;
                                        }
                                        else
                                        {
                                            sectiontext.Range.ParagraphFormat.FirstLineIndent = 0;
                                        }
                                        int start = sectiontext.Range.Start;
                                        int end = sectiontext.Range.Start + section.title.Length + 1;
                                        if (myPaper.sectionsConfig.sectionLabelBold)
                                        {
                                            Range rangeToBold = sectiontext.Range.Duplicate;
                                            rangeToBold.SetRange(start, end);
                                            rangeToBold.Bold = 1;
                                        }
                                        if (myPaper.sectionsConfig.sectionLabelItalics)
                                        {
                                            Range rangeToItalicize = sectiontext.Range.Duplicate;
                                            rangeToItalicize.SetRange(start, end);
                                            rangeToItalicize.Italic = 1;
                                        }
                                    }
                                }
                                else
                                {
                                    string unformatted = Regex.Replace(Regex.Replace(splitPara.Replace('\b'.ToString(), "").Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, ""), sizePattern, "");
                                    sectiontext.Range.Text = unformatted;
                                    sectiontext.Range.ParagraphFormat.LeftIndent = 0;
                                    sectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                                    string noFontSize = Regex.Replace(Regex.Replace(splitPara, fontPattern, ""), sizePattern, "");

                                    string[] splitIndent = noFontSize.Split('\v');
                                    for (int i = 0; i < splitIndent.Length; i++)
                                    {
                                        if (i % 2 == 1)
                                        {
                                            int previousSplitLength = 0;
                                            for (int j = i - 1; j >= 0; j--)
                                            {
                                                previousSplitLength += splitIndent[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "").Length;
                                            }
                                            string unformattedSplit = splitIndent[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "");
                                            Range rangeToIndent = sectiontext.Range.Duplicate;
                                            rangeToIndent.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                            rangeToIndent.ParagraphFormat.LeftIndent = 36;
                                        }
                                    }

                                    string[] splitBold = noFontSize.Split('\b');
                                    for (int i = 0; i < splitBold.Length; i++)
                                    {
                                        if (i % 2 == 1)
                                        {
                                            int previousSplitLength = 0;
                                            for (int j = i - 1; j >= 0; j--)
                                            {
                                                previousSplitLength += splitBold[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                            }
                                            string unformattedSplit = splitBold[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                            Range rangeToBold = sectiontext.Range.Duplicate;
                                            rangeToBold.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                            rangeToBold.Bold = 1;
                                        }
                                    }

                                    string[] splitItalic = noFontSize.Split('\a');
                                    for (int i = 0; i < splitItalic.Length; i++)
                                    {
                                        if (i % 2 == 1)
                                        {
                                            int previousSplitLength = 0;
                                            for (int j = i - 1; j >= 0; j--)
                                            {
                                                previousSplitLength += splitItalic[j].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                            }
                                            string unformattedSplit = splitItalic[i].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                            Range rangeToItalic = sectiontext.Range.Duplicate;
                                            rangeToItalic.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                            rangeToItalic.Italic = 1;
                                        }
                                    }

                                    string[] splitUnderline = noFontSize.Split('\f');
                                    for (int i = 0; i < splitUnderline.Length; i++)
                                    {
                                        if (i % 2 == 1)
                                        {
                                            int previousSplitLength = 0;
                                            for (int j = i - 1; j >= 0; j--)
                                            {
                                                previousSplitLength += splitUnderline[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                            }
                                            string unformattedSplit = splitUnderline[i].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "");
                                            Range rangeToUnderline = sectiontext.Range.Duplicate;
                                            rangeToUnderline.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                            rangeToUnderline.Underline = WdUnderline.wdUnderlineSingle;
                                        }
                                    }

                                    string secondFontPattern = @".{1,20}\\ffffffffffff\\";
                                    string sizeRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), sizePattern, "");
                                    string[] splitFont = sizeRemoved.Split(new string[] { "\\ffffffffff\\" }, StringSplitOptions.None); //Regex.Split(myPaper.summary.content, fontPattern);
                                    for (int i = 0; i < splitFont.Length; i++)
                                    {
                                        if (splitFont[i].Length > 0)
                                        {
                                            string[] fontParts = splitFont[i].Split(new string[] { "\\ffffffffffff\\" }, StringSplitOptions.None);
                                            string currentFont = fontParts[0];
                                            int previousSplitLength = 0;
                                            if (i > 0)
                                            {
                                                for (int j = i - 1; j >= 0; j--)
                                                {
                                                    string unformattedContent = splitFont[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                    string noFont = Regex.Replace(unformattedContent, secondFontPattern, "");
                                                    previousSplitLength += noFont.Length;
                                                }
                                            }
                                            string unformattedSplit = fontParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                            Range rangeToFontChange = sectiontext.Range.Duplicate;
                                            rangeToFontChange.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                            rangeToFontChange.Font.Name = currentFont;
                                        }
                                    }

                                    string secondSizePattern = @".{1,20}\\ssssssssssss\\";
                                    string fontRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                    string[] splitSize = fontRemoved.Split(new string[] { "\\ssssssssss\\" }, StringSplitOptions.None);
                                    for (int i = 0; i < splitSize.Length; i++)
                                    {
                                        if (splitSize[i].Length > 0)
                                        {
                                            string[] sizeParts = splitSize[i].Split(new string[] { "\\ssssssssssss\\" }, StringSplitOptions.None);
                                            string currentSize = sizeParts[0];
                                            int previousSplitLength = 0;
                                            if (i > 0)
                                            {
                                                for (int j = i - 1; j >= 0; j--)
                                                {
                                                    string unformattedContent = Regex.Replace(splitSize[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                                    string noSize = Regex.Replace(unformattedContent, secondSizePattern, "");
                                                    previousSplitLength += noSize.Length;
                                                }
                                            }
                                            string unformattedSplit = sizeParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                            Range rangeToSizeChange = sectiontext.Range.Duplicate;
                                            rangeToSizeChange.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                            rangeToSizeChange.Font.Size = (float)Convert.ToDouble(currentSize);
                                        }
                                    }

                                    if (sectiontext.Range.ParagraphFormat.LeftIndent != 36)
                                    {
                                        sectiontext.Range.ParagraphFormat.FirstLineIndent = 36;
                                    }
                                    else
                                    {
                                        sectiontext.Range.ParagraphFormat.FirstLineIndent = 0;
                                    }
                                }
                                sectiontext.Range.InsertParagraphAfter();
                            }
                            else
                            {
                                string unformatted = Regex.Replace(Regex.Replace(splitPara.Replace('\b'.ToString(), "").Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, ""), sizePattern, "");
                                sectiontext.Range.Text = unformatted;
                                sectiontext.Range.ParagraphFormat.LeftIndent = 0;
                                sectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                                string noFontSize = Regex.Replace(Regex.Replace(splitPara, fontPattern, ""), sizePattern, "");

                                string[] splitIndent = noFontSize.Split('\v');
                                for (int i = 0; i < splitIndent.Length; i++)
                                {
                                    if (i % 2 == 1)
                                    {
                                        int previousSplitLength = 0;
                                        for (int j = i - 1; j >= 0; j--)
                                        {
                                            previousSplitLength += splitIndent[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "").Length;
                                        }
                                        string unformattedSplit = splitIndent[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "");
                                        Range rangeToIndent = sectiontext.Range.Duplicate;
                                        rangeToIndent.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                        rangeToIndent.ParagraphFormat.LeftIndent = 36;
                                    }
                                }

                                string[] splitBold = noFontSize.Split('\b');
                                for (int i = 0; i < splitBold.Length; i++)
                                {
                                    if (i % 2 == 1)
                                    {
                                        int previousSplitLength = 0;
                                        for (int j = i - 1; j >= 0; j--)
                                        {
                                            previousSplitLength += splitBold[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                        }
                                        string unformattedSplit = splitBold[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                        Range rangeToBold = sectiontext.Range.Duplicate;
                                        rangeToBold.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                        rangeToBold.Bold = 1;
                                    }
                                }

                                string[] splitItalic = noFontSize.Split('\a');
                                for (int i = 0; i < splitItalic.Length; i++)
                                {
                                    if (i % 2 == 1)
                                    {
                                        int previousSplitLength = 0;
                                        for (int j = i - 1; j >= 0; j--)
                                        {
                                            previousSplitLength += splitItalic[j].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                        }
                                        string unformattedSplit = splitItalic[i].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                        Range rangeToItalic = sectiontext.Range.Duplicate;
                                        rangeToItalic.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                        rangeToItalic.Italic = 1;
                                    }
                                }

                                string[] splitUnderline = noFontSize.Split('\f');
                                for (int i = 0; i < splitUnderline.Length; i++)
                                {
                                    if (i % 2 == 1)
                                    {
                                        int previousSplitLength = 0;
                                        for (int j = i - 1; j >= 0; j--)
                                        {
                                            previousSplitLength += splitUnderline[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                        }
                                        string unformattedSplit = splitUnderline[i].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "");
                                        Range rangeToUnderline = sectiontext.Range.Duplicate;
                                        rangeToUnderline.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                        rangeToUnderline.Underline = WdUnderline.wdUnderlineSingle;
                                    }
                                }

                                string secondFontPattern = @".{1,20}\\ffffffffffff\\";
                                string sizeRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), sizePattern, "");
                                string[] splitFont = sizeRemoved.Split(new string[] { "\\ffffffffff\\" }, StringSplitOptions.None); //Regex.Split(myPaper.summary.content, fontPattern);
                                for (int i = 0; i < splitFont.Length; i++)
                                {
                                    if (splitFont[i].Length > 0)
                                    {
                                        string[] fontParts = splitFont[i].Split(new string[] { "\\ffffffffffff\\" }, StringSplitOptions.None);
                                        string currentFont = fontParts[0];
                                        int previousSplitLength = 0;
                                        if (i > 0)
                                        {
                                            for (int j = i - 1; j >= 0; j--)
                                            {
                                                string unformattedContent = splitFont[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                string noFont = Regex.Replace(unformattedContent, secondFontPattern, "");
                                                previousSplitLength += noFont.Length;
                                            }
                                        }
                                        string unformattedSplit = fontParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                        Range rangeToFontChange = sectiontext.Range.Duplicate;
                                        rangeToFontChange.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                        rangeToFontChange.Font.Name = currentFont;
                                    }
                                }

                                string secondSizePattern = @".{1,20}\\ssssssssssss\\";
                                string fontRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                string[] splitSize = fontRemoved.Split(new string[] { "\\ssssssssss\\" }, StringSplitOptions.None);
                                for (int i = 0; i < splitSize.Length; i++)
                                {
                                    if (splitSize[i].Length > 0)
                                    {
                                        string[] sizeParts = splitSize[i].Split(new string[] { "\\ssssssssssss\\" }, StringSplitOptions.None);
                                        string currentSize = sizeParts[0];
                                        int previousSplitLength = 0;
                                        if (i > 0)
                                        {
                                            for (int j = i - 1; j >= 0; j--)
                                            {
                                                string unformattedContent = Regex.Replace(splitSize[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                                string noSize = Regex.Replace(unformattedContent, secondSizePattern, "");
                                                previousSplitLength += noSize.Length;
                                            }
                                        }
                                        string unformattedSplit = sizeParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                        Range rangeToSizeChange = sectiontext.Range.Duplicate;
                                        rangeToSizeChange.SetRange(previousSplitLength + sectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + sectiontext.Range.Start);
                                        rangeToSizeChange.Font.Size = (float)Convert.ToDouble(currentSize);
                                    }
                                }
                                if (sectiontext.Range.ParagraphFormat.LeftIndent != 36)
                                {
                                    sectiontext.Range.ParagraphFormat.FirstLineIndent = 36;
                                }
                                else
                                {
                                    sectiontext.Range.ParagraphFormat.FirstLineIndent = 0;
                                }
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
                                            string unformatted = Regex.Replace(Regex.Replace(splitPara.Replace('\b'.ToString(), "").Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, ""), sizePattern, "");
                                            subsectiontext.Range.Text = subsection.title + ". " + unformatted;
                                            subsectiontext.Range.ParagraphFormat.LeftIndent = 0;
                                            subsectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                                            Range rangeForFontSize = subsectiontext.Range.Duplicate;
                                            rangeForFontSize.SetRange(subsectiontext.Range.Start, subsectiontext.Range.Start + subsection.title.Length + 2);
                                            rangeForFontSize.Font.Name = myPaper.sectionsConfig.subsectionLabelFont;
                                            rangeForFontSize.Font.Size = myPaper.sectionsConfig.subsectionLabelSize;
                                            string[] colors = myPaper.sectionsConfig.subsectionLabelColor.Split(',');
                                            Color color = Color.FromArgb(Convert.ToInt32(colors[3]), Convert.ToInt32(colors[0]), Convert.ToInt32(colors[1]), Convert.ToInt32(colors[2]));
                                            rangeForFontSize.Font.Color = (WdColor)(color.R + 0x100 * color.G + 0x10000 * color.B);

                                            string noFontSize = Regex.Replace(Regex.Replace(splitPara, fontPattern, ""), sizePattern, "");

                                            string[] splitIndent = noFontSize.Split('\v');
                                            for (int i = 0; i < splitIndent.Length; i++)
                                            {
                                                if (i % 2 == 1)
                                                {
                                                    int previousSplitLength = 0;
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        previousSplitLength += splitIndent[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "").Length;
                                                    }
                                                    string unformattedSplit = splitIndent[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "");
                                                    Range rangeToIndent = subsectiontext.Range.Duplicate;
                                                    rangeToIndent.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                                    rangeToIndent.ParagraphFormat.LeftIndent = 36;
                                                }
                                            }

                                            string[] splitBold = noFontSize.Split('\b');
                                            for (int i = 0; i < splitBold.Length; i++)
                                            {
                                                if (i % 2 == 1)
                                                {
                                                    int previousSplitLength = subsection.title.Length + 2;
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        previousSplitLength += splitBold[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                    }
                                                    previousSplitLength += subsection.title.Length + 2;
                                                    string unformattedSplit = splitBold[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                    Range rangeToBold = subsectiontext.Range.Duplicate;
                                                    rangeToBold.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                                    rangeToBold.Bold = 1;
                                                }
                                            }

                                            string[] splitItalic = noFontSize.Split('\a');
                                            for (int i = 0; i < splitItalic.Length; i++)
                                            {
                                                if (i % 2 == 1)
                                                {
                                                    int previousSplitLength = subsection.title.Length + 2;
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        previousSplitLength += splitItalic[j].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                    }
                                                    previousSplitLength += subsection.title.Length + 2;
                                                    string unformattedSplit = splitItalic[i].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                    Range rangeToItalic = subsectiontext.Range.Duplicate;
                                                    rangeToItalic.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                                    rangeToItalic.Italic = 1;
                                                }
                                            }

                                            string[] splitUnderline = noFontSize.Split('\f');
                                            for (int i = 0; i < splitUnderline.Length; i++)
                                            {
                                                if (i % 2 == 1)
                                                {
                                                    int previousSplitLength = subsection.title.Length + 2;
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        previousSplitLength += splitUnderline[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                    }
                                                    previousSplitLength += subsection.title.Length + 2;
                                                    string unformattedSplit = splitUnderline[i].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "");
                                                    Range rangeToUnderline = subsectiontext.Range.Duplicate;
                                                    rangeToUnderline.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                                    rangeToUnderline.Underline = WdUnderline.wdUnderlineSingle;
                                                }
                                            }

                                            string secondFontPattern = @".{1,20}\\ffffffffffff\\";
                                            string sizeRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), sizePattern, "");
                                            string[] splitFont = sizeRemoved.Split(new string[] { "\\ffffffffff\\" }, StringSplitOptions.None); //Regex.Split(myPaper.summary.content, fontPattern);
                                            for (int i = 0; i < splitFont.Length; i++)
                                            {
                                                if (splitFont[i].Length > 0)
                                                {
                                                    string[] fontParts = splitFont[i].Split(new string[] { "\\ffffffffffff\\" }, StringSplitOptions.None);
                                                    string currentFont = fontParts[0];
                                                    int previousSplitLength = subsection.title.Length + 2;
                                                    if (i > 0)
                                                    {
                                                        for (int j = i - 1; j >= 0; j--)
                                                        {
                                                            string unformattedContent = splitFont[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                            string noFont = Regex.Replace(unformattedContent, secondFontPattern, "");
                                                            previousSplitLength += noFont.Length;
                                                        }
                                                    }
                                                    string unformattedSplit = fontParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                    Range rangeToFontChange = subsectiontext.Range.Duplicate;
                                                    rangeToFontChange.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                                    rangeToFontChange.Font.Name = currentFont;
                                                }
                                            }

                                            string secondSizePattern = @".{1,20}\\ssssssssssss\\";
                                            string fontRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                            string[] splitSize = fontRemoved.Split(new string[] { "\\ssssssssss\\" }, StringSplitOptions.None);
                                            for (int i = 0; i < splitSize.Length; i++)
                                            {
                                                if (splitSize[i].Length > 0)
                                                {
                                                    string[] sizeParts = splitSize[i].Split(new string[] { "\\ssssssssssss\\" }, StringSplitOptions.None);
                                                    string currentSize = sizeParts[0];
                                                    int previousSplitLength = subsection.title.Length + 2;
                                                    if (i > 0)
                                                    {
                                                        for (int j = i - 1; j >= 0; j--)
                                                        {
                                                            string unformattedContent = Regex.Replace(splitSize[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                                            string noSize = Regex.Replace(unformattedContent, secondSizePattern, "");
                                                            previousSplitLength += noSize.Length;
                                                        }
                                                    }
                                                    string unformattedSplit = sizeParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                    Range rangeToSizeChange = subsectiontext.Range.Duplicate;
                                                    rangeToSizeChange.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                                    rangeToSizeChange.Font.Size = (float)Convert.ToDouble(currentSize);
                                                }
                                            }
                                            if (subsectiontext.Range.ParagraphFormat.LeftIndent != 36)
                                            {
                                                subsectiontext.Range.ParagraphFormat.FirstLineIndent = 36;
                                            }
                                            else
                                            {
                                                subsectiontext.Range.ParagraphFormat.FirstLineIndent = 0;
                                            }
                                            int start = subsectiontext.Range.Start;
                                            int end = subsectiontext.Range.Start + subsection.title.Length + 1;
                                            if (myPaper.sectionsConfig.subsectionLabelBold)
                                            {
                                                Range rangeToBold = subsectiontext.Range.Duplicate;
                                                rangeToBold.SetRange(start, end);
                                                rangeToBold.Bold = 1;
                                            }
                                            if (myPaper.sectionsConfig.subsectionLabelItalics)
                                            {
                                                Range rangeToItalicize = subsectiontext.Range.Duplicate;
                                                rangeToItalicize.SetRange(start, end);
                                                rangeToItalicize.Italic = 1;
                                            }
                                        }
                                        else if (myPaper.sectionsConfig.subsectionLabelOnOwnLine)
                                        {
                                            if (myPaper.sectionsConfig.subsectionLabelBold)
                                            {
                                                subsectiontext.Range.Bold = 1;
                                            }
                                            if (myPaper.sectionsConfig.subsectionLabelItalics)
                                            {
                                                subsectiontext.Range.Italic = 1;
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
                                            subsectiontext.Range.Font.Name = myPaper.sectionsConfig.subsectionLabelFont;
                                            subsectiontext.Range.Font.Size = myPaper.sectionsConfig.subsectionLabelSize;
                                            string[] colors = myPaper.sectionsConfig.subsectionLabelColor.Split(',');
                                            Color color = Color.FromArgb(Convert.ToInt32(colors[3]), Convert.ToInt32(colors[0]), Convert.ToInt32(colors[1]), Convert.ToInt32(colors[2]));
                                            subsectiontext.Range.Font.Color = (WdColor)(color.R + 0x100 * color.G + 0x10000 * color.B);

                                            subsectiontext.Range.ParagraphFormat.FirstLineIndent = 0;
                                            subsectiontext.Range.InsertParagraphAfter();
                                            subsectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                            subsectiontext.Range.Bold = 0;
                                            subsectiontext.Range.Italic = 0;
                                            subsectiontext.Range.Font.Color = WdColor.wdColorBlack;

                                            string unformatted = Regex.Replace(Regex.Replace(splitPara.Replace('\b'.ToString(), "").Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, ""), sizePattern, "");
                                            subsectiontext.Range.Text = unformatted;
                                            subsectiontext.Range.ParagraphFormat.LeftIndent = 0;

                                            string noFontSize = Regex.Replace(Regex.Replace(splitPara, fontPattern, ""), sizePattern, "");

                                            string[] splitIndent = noFontSize.Split('\v');
                                            for (int i = 0; i < splitIndent.Length; i++)
                                            {
                                                if (i % 2 == 1)
                                                {
                                                    int previousSplitLength = 0;
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        previousSplitLength += splitIndent[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "").Length;
                                                    }
                                                    string unformattedSplit = splitIndent[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "");
                                                    Range rangeToIndent = subsectiontext.Range.Duplicate;
                                                    rangeToIndent.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                                    rangeToIndent.ParagraphFormat.LeftIndent = 36;
                                                }
                                            }

                                            string[] splitBold = noFontSize.Split('\b');
                                            for (int i = 0; i < splitBold.Length; i++)
                                            {
                                                if (i % 2 == 1)
                                                {
                                                    int previousSplitLength = 0;
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        previousSplitLength += splitBold[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                    }
                                                    string unformattedSplit = splitBold[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                    Range rangeToBold = subsectiontext.Range.Duplicate;
                                                    rangeToBold.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                                    rangeToBold.Bold = 1;
                                                }
                                            }

                                            string[] splitItalic = noFontSize.Split('\a');
                                            for (int i = 0; i < splitItalic.Length; i++)
                                            {
                                                if (i % 2 == 1)
                                                {
                                                    int previousSplitLength = 0;
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        previousSplitLength += splitItalic[j].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                    }
                                                    string unformattedSplit = splitItalic[i].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                    Range rangeToItalic = subsectiontext.Range.Duplicate;
                                                    rangeToItalic.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                                    rangeToItalic.Italic = 1;
                                                }
                                            }

                                            string[] splitUnderline = noFontSize.Split('\f');
                                            for (int i = 0; i < splitUnderline.Length; i++)
                                            {
                                                if (i % 2 == 1)
                                                {
                                                    int previousSplitLength = 0;
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        previousSplitLength += splitUnderline[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                    }
                                                    string unformattedSplit = splitUnderline[i].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "");
                                                    Range rangeToUnderline = subsectiontext.Range.Duplicate;
                                                    rangeToUnderline.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                                    rangeToUnderline.Underline = WdUnderline.wdUnderlineSingle;
                                                }
                                            }

                                            string secondFontPattern = @".{1,20}\\ffffffffffff\\";
                                            string sizeRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), sizePattern, "");
                                            string[] splitFont = sizeRemoved.Split(new string[] { "\\ffffffffff\\" }, StringSplitOptions.None); //Regex.Split(myPaper.summary.content, fontPattern);
                                            for (int i = 0; i < splitFont.Length; i++)
                                            {
                                                if (splitFont[i].Length > 0)
                                                {
                                                    string[] fontParts = splitFont[i].Split(new string[] { "\\ffffffffffff\\" }, StringSplitOptions.None);
                                                    string currentFont = fontParts[0];
                                                    int previousSplitLength = 0;
                                                    if (i > 0)
                                                    {
                                                        for (int j = i - 1; j >= 0; j--)
                                                        {
                                                            string unformattedContent = splitFont[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                            string noFont = Regex.Replace(unformattedContent, secondFontPattern, "");
                                                            previousSplitLength += noFont.Length;
                                                        }
                                                    }
                                                    string unformattedSplit = fontParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                    Range rangeToFontChange = subsectiontext.Range.Duplicate;
                                                    rangeToFontChange.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                                    rangeToFontChange.Font.Name = currentFont;
                                                }
                                            }

                                            string secondSizePattern = @".{1,20}\\ssssssssssss\\";
                                            string fontRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                            string[] splitSize = fontRemoved.Split(new string[] { "\\ssssssssss\\" }, StringSplitOptions.None);
                                            for (int i = 0; i < splitSize.Length; i++)
                                            {
                                                if (splitSize[i].Length > 0)
                                                {
                                                    string[] sizeParts = splitSize[i].Split(new string[] { "\\ssssssssssss\\" }, StringSplitOptions.None);
                                                    string currentSize = sizeParts[0];
                                                    int previousSplitLength = 0;
                                                    if (i > 0)
                                                    {
                                                        for (int j = i - 1; j >= 0; j--)
                                                        {
                                                            string unformattedContent = Regex.Replace(splitSize[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                                            string noSize = Regex.Replace(unformattedContent, secondSizePattern, "");
                                                            previousSplitLength += noSize.Length;
                                                        }
                                                    }
                                                    string unformattedSplit = sizeParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                    Range rangeToSizeChange = subsectiontext.Range.Duplicate;
                                                    rangeToSizeChange.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                                    rangeToSizeChange.Font.Size = (float)Convert.ToDouble(currentSize);
                                                }
                                            }
                                            if (subsectiontext.Range.ParagraphFormat.LeftIndent != 36)
                                            {
                                                subsectiontext.Range.ParagraphFormat.FirstLineIndent = 36;
                                            }
                                            else
                                            {
                                                subsectiontext.Range.ParagraphFormat.FirstLineIndent = 0;
                                            }
                                        }
                                        else
                                        {
                                            string unformatted = Regex.Replace(Regex.Replace(splitPara.Replace('\b'.ToString(), "").Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, ""), sizePattern, "");
                                            subsectiontext.Range.Text = subsection.title + ". " + unformatted;
                                            subsectiontext.Range.ParagraphFormat.LeftIndent = 0;
                                            subsectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                                            Range rangeForFontSize = subsectiontext.Range.Duplicate;
                                            rangeForFontSize.SetRange(subsectiontext.Range.Start, subsectiontext.Range.Start + subsection.title.Length + 2);
                                            rangeForFontSize.Font.Name = myPaper.sectionsConfig.subsectionLabelFont;
                                            rangeForFontSize.Font.Size = myPaper.sectionsConfig.subsectionLabelSize;
                                            string[] colors = myPaper.sectionsConfig.subsectionLabelColor.Split(',');
                                            Color color = Color.FromArgb(Convert.ToInt32(colors[3]), Convert.ToInt32(colors[0]), Convert.ToInt32(colors[1]), Convert.ToInt32(colors[2]));
                                            rangeForFontSize.Font.Color = (WdColor)(color.R + 0x100 * color.G + 0x10000 * color.B);

                                            string noFontSize = Regex.Replace(Regex.Replace(splitPara, fontPattern, ""), sizePattern, "");

                                            string[] splitIndent = noFontSize.Split('\v');
                                            for (int i = 0; i < splitIndent.Length; i++)
                                            {
                                                if (i % 2 == 1)
                                                {
                                                    int previousSplitLength = 0;
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        previousSplitLength += splitIndent[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "").Length;
                                                    }
                                                    string unformattedSplit = splitIndent[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "");
                                                    Range rangeToIndent = subsectiontext.Range.Duplicate;
                                                    rangeToIndent.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                                    rangeToIndent.ParagraphFormat.LeftIndent = 36;
                                                }
                                            }

                                            string[] splitBold = noFontSize.Split('\b');
                                            for (int i = 0; i < splitBold.Length; i++)
                                            {
                                                if (i % 2 == 1)
                                                {
                                                    int previousSplitLength = subsection.title.Length + 2;
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        previousSplitLength += splitBold[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                    }
                                                    previousSplitLength += subsection.title.Length + 2;
                                                    string unformattedSplit = splitBold[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                    Range rangeToBold = subsectiontext.Range.Duplicate;
                                                    rangeToBold.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                                    rangeToBold.Bold = 1;
                                                }
                                            }

                                            string[] splitItalic = noFontSize.Split('\a');
                                            for (int i = 0; i < splitItalic.Length; i++)
                                            {
                                                if (i % 2 == 1)
                                                {
                                                    int previousSplitLength = subsection.title.Length + 2;
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        previousSplitLength += splitItalic[j].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                    }
                                                    previousSplitLength += subsection.title.Length + 2;
                                                    string unformattedSplit = splitItalic[i].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                    Range rangeToItalic = subsectiontext.Range.Duplicate;
                                                    rangeToItalic.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                                    rangeToItalic.Italic = 1;
                                                }
                                            }

                                            string[] splitUnderline = noFontSize.Split('\f');
                                            for (int i = 0; i < splitUnderline.Length; i++)
                                            {
                                                if (i % 2 == 1)
                                                {
                                                    int previousSplitLength = subsection.title.Length + 2;
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        previousSplitLength += splitUnderline[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                    }
                                                    previousSplitLength += subsection.title.Length + 2;
                                                    string unformattedSplit = splitUnderline[i].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "");
                                                    Range rangeToUnderline = subsectiontext.Range.Duplicate;
                                                    rangeToUnderline.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                                    rangeToUnderline.Underline = WdUnderline.wdUnderlineSingle;
                                                }
                                            }

                                            string secondFontPattern = @".{1,20}\\ffffffffffff\\";
                                            string sizeRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), sizePattern, "");
                                            string[] splitFont = sizeRemoved.Split(new string[] { "\\ffffffffff\\" }, StringSplitOptions.None); //Regex.Split(myPaper.summary.content, fontPattern);
                                            for (int i = 0; i < splitFont.Length; i++)
                                            {
                                                if (splitFont[i].Length > 0)
                                                {
                                                    string[] fontParts = splitFont[i].Split(new string[] { "\\ffffffffffff\\" }, StringSplitOptions.None);
                                                    string currentFont = fontParts[0];
                                                    int previousSplitLength = subsection.title.Length + 2;
                                                    if (i > 0)
                                                    {
                                                        for (int j = i - 1; j >= 0; j--)
                                                        {
                                                            string unformattedContent = splitFont[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                            string noFont = Regex.Replace(unformattedContent, secondFontPattern, "");
                                                            previousSplitLength += noFont.Length;
                                                        }
                                                    }
                                                    string unformattedSplit = fontParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                    Range rangeToFontChange = subsectiontext.Range.Duplicate;
                                                    rangeToFontChange.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                                    rangeToFontChange.Font.Name = currentFont;
                                                }
                                            }

                                            string secondSizePattern = @".{1,20}\\ssssssssssss\\";
                                            string fontRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                            string[] splitSize = fontRemoved.Split(new string[] { "\\ssssssssss\\" }, StringSplitOptions.None);
                                            for (int i = 0; i < splitSize.Length; i++)
                                            {
                                                if (splitSize[i].Length > 0)
                                                {
                                                    string[] sizeParts = splitSize[i].Split(new string[] { "\\ssssssssssss\\" }, StringSplitOptions.None);
                                                    string currentSize = sizeParts[0];
                                                    int previousSplitLength = subsection.title.Length + 2;
                                                    if (i > 0)
                                                    {
                                                        for (int j = i - 1; j >= 0; j--)
                                                        {
                                                            string unformattedContent = Regex.Replace(splitSize[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                                            string noSize = Regex.Replace(unformattedContent, secondSizePattern, "");
                                                            previousSplitLength += noSize.Length;
                                                        }
                                                    }
                                                    string unformattedSplit = sizeParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                    Range rangeToSizeChange = subsectiontext.Range.Duplicate;
                                                    rangeToSizeChange.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                                    rangeToSizeChange.Font.Size = (float)Convert.ToDouble(currentSize);
                                                }
                                            }

                                            if (subsectiontext.Range.ParagraphFormat.LeftIndent != 36)
                                            {
                                                subsectiontext.Range.ParagraphFormat.FirstLineIndent = 36;
                                            }
                                            else
                                            {
                                                subsectiontext.Range.ParagraphFormat.FirstLineIndent = 0;
                                            }
                                            int start = subsectiontext.Range.Start;
                                            int end = subsectiontext.Range.Start + subsection.title.Length + 1;
                                            if (myPaper.sectionsConfig.subsectionLabelBold)
                                            {
                                                Range rangeToBold = subsectiontext.Range.Duplicate;
                                                rangeToBold.SetRange(start, end);
                                                rangeToBold.Bold = 1;
                                            }
                                            if (myPaper.sectionsConfig.subsectionLabelItalics)
                                            {
                                                Range rangeToItalicize = subsectiontext.Range.Duplicate;
                                                rangeToItalicize.SetRange(start, end);
                                                rangeToItalicize.Italic = 1;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        string unformatted = Regex.Replace(Regex.Replace(splitPara.Replace('\b'.ToString(), "").Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, ""), sizePattern, "");
                                        subsectiontext.Range.Text = unformatted;
                                        subsectiontext.Range.ParagraphFormat.LeftIndent = 0;
                                        subsectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                                        string noFontSize = Regex.Replace(Regex.Replace(splitPara, fontPattern, ""), sizePattern, "");

                                        string[] splitIndent = noFontSize.Split('\v');
                                        for (int i = 0; i < splitIndent.Length; i++)
                                        {
                                            if (i % 2 == 1)
                                            {
                                                int previousSplitLength = 0;
                                                for (int j = i - 1; j >= 0; j--)
                                                {
                                                    previousSplitLength += splitIndent[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "").Length;
                                                }
                                                string unformattedSplit = splitIndent[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "");
                                                Range rangeToIndent = subsectiontext.Range.Duplicate;
                                                rangeToIndent.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                                rangeToIndent.ParagraphFormat.LeftIndent = 36;
                                            }
                                        }

                                        string[] splitBold = noFontSize.Split('\b');
                                        for (int i = 0; i < splitBold.Length; i++)
                                        {
                                            if (i % 2 == 1)
                                            {
                                                int previousSplitLength = 0;
                                                for (int j = i - 1; j >= 0; j--)
                                                {
                                                    previousSplitLength += splitBold[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                }
                                                string unformattedSplit = splitBold[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToBold = subsectiontext.Range.Duplicate;
                                                rangeToBold.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                                rangeToBold.Bold = 1;
                                            }
                                        }

                                        string[] splitItalic = noFontSize.Split('\a');
                                        for (int i = 0; i < splitItalic.Length; i++)
                                        {
                                            if (i % 2 == 1)
                                            {
                                                int previousSplitLength = 0;
                                                for (int j = i - 1; j >= 0; j--)
                                                {
                                                    previousSplitLength += splitItalic[j].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                }
                                                string unformattedSplit = splitItalic[i].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToItalic = subsectiontext.Range.Duplicate;
                                                rangeToItalic.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                                rangeToItalic.Italic = 1;
                                            }
                                        }

                                        string[] splitUnderline = noFontSize.Split('\f');
                                        for (int i = 0; i < splitUnderline.Length; i++)
                                        {
                                            if (i % 2 == 1)
                                            {
                                                int previousSplitLength = 0;
                                                for (int j = i - 1; j >= 0; j--)
                                                {
                                                    previousSplitLength += splitUnderline[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                }
                                                string unformattedSplit = splitUnderline[i].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToUnderline = subsectiontext.Range.Duplicate;
                                                rangeToUnderline.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                                rangeToUnderline.Underline = WdUnderline.wdUnderlineSingle;
                                            }
                                        }

                                        string secondFontPattern = @".{1,20}\\ffffffffffff\\";
                                        string sizeRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), sizePattern, "");
                                        string[] splitFont = sizeRemoved.Split(new string[] { "\\ffffffffff\\" }, StringSplitOptions.None); //Regex.Split(myPaper.summary.content, fontPattern);
                                        for (int i = 0; i < splitFont.Length; i++)
                                        {
                                            if (splitFont[i].Length > 0)
                                            {
                                                string[] fontParts = splitFont[i].Split(new string[] { "\\ffffffffffff\\" }, StringSplitOptions.None);
                                                string currentFont = fontParts[0];
                                                int previousSplitLength = 0;
                                                if (i > 0)
                                                {
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        string unformattedContent = splitFont[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                        string noFont = Regex.Replace(unformattedContent, secondFontPattern, "");
                                                        previousSplitLength += noFont.Length;
                                                    }
                                                }
                                                string unformattedSplit = fontParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToFontChange = subsectiontext.Range.Duplicate;
                                                rangeToFontChange.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                                rangeToFontChange.Font.Name = currentFont;
                                            }
                                        }

                                        string secondSizePattern = @".{1,20}\\ssssssssssss\\";
                                        string fontRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                        string[] splitSize = fontRemoved.Split(new string[] { "\\ssssssssss\\" }, StringSplitOptions.None);
                                        for (int i = 0; i < splitSize.Length; i++)
                                        {
                                            if (splitSize[i].Length > 0)
                                            {
                                                string[] sizeParts = splitSize[i].Split(new string[] { "\\ssssssssssss\\" }, StringSplitOptions.None);
                                                string currentSize = sizeParts[0];
                                                int previousSplitLength = 0;
                                                if (i > 0)
                                                {
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        string unformattedContent = Regex.Replace(splitSize[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                                        string noSize = Regex.Replace(unformattedContent, secondSizePattern, "");
                                                        previousSplitLength += noSize.Length;
                                                    }
                                                }
                                                string unformattedSplit = sizeParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToSizeChange = subsectiontext.Range.Duplicate;
                                                rangeToSizeChange.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                                rangeToSizeChange.Font.Size = (float)Convert.ToDouble(currentSize);
                                            }
                                        }

                                        if (subsectiontext.Range.ParagraphFormat.LeftIndent != 36)
                                        {
                                            subsectiontext.Range.ParagraphFormat.FirstLineIndent = 36;
                                        }
                                        else
                                        {
                                            subsectiontext.Range.ParagraphFormat.FirstLineIndent = 0;
                                        }
                                    }
                                    subsectiontext.Range.InsertParagraphAfter();
                                }
                                else
                                {
                                    string unformatted = Regex.Replace(Regex.Replace(splitPara.Replace('\b'.ToString(), "").Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, ""), sizePattern, "");
                                    subsectiontext.Range.Text = unformatted;
                                    subsectiontext.Range.ParagraphFormat.LeftIndent = 0;
                                    subsectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                                    string noFontSize = Regex.Replace(Regex.Replace(splitPara, fontPattern, ""), sizePattern, "");

                                    string[] splitIndent = noFontSize.Split('\v');
                                    for (int i = 0; i < splitIndent.Length; i++)
                                    {
                                        if (i % 2 == 1)
                                        {
                                            int previousSplitLength = 0;
                                            for (int j = i - 1; j >= 0; j--)
                                            {
                                                previousSplitLength += splitIndent[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "").Length;
                                            }
                                            string unformattedSplit = splitIndent[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "");
                                            Range rangeToIndent = subsectiontext.Range.Duplicate;
                                            rangeToIndent.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                            rangeToIndent.ParagraphFormat.LeftIndent = 36;
                                        }
                                    }

                                    string[] splitBold = noFontSize.Split('\b');
                                    for (int i = 0; i < splitBold.Length; i++)
                                    {
                                        if (i % 2 == 1)
                                        {
                                            int previousSplitLength = 0;
                                            for (int j = i - 1; j >= 0; j--)
                                            {
                                                previousSplitLength += splitBold[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                            }
                                            string unformattedSplit = splitBold[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                            Range rangeToBold = subsectiontext.Range.Duplicate;
                                            rangeToBold.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                            rangeToBold.Bold = 1;
                                        }
                                    }

                                    string[] splitItalic = noFontSize.Split('\a');
                                    for (int i = 0; i < splitItalic.Length; i++)
                                    {
                                        if (i % 2 == 1)
                                        {
                                            int previousSplitLength = 0;
                                            for (int j = i - 1; j >= 0; j--)
                                            {
                                                previousSplitLength += splitItalic[j].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                            }
                                            string unformattedSplit = splitItalic[i].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                            Range rangeToItalic = subsectiontext.Range.Duplicate;
                                            rangeToItalic.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                            rangeToItalic.Italic = 1;
                                        }
                                    }

                                    string[] splitUnderline = noFontSize.Split('\f');
                                    for (int i = 0; i < splitUnderline.Length; i++)
                                    {
                                        if (i % 2 == 1)
                                        {
                                            int previousSplitLength = 0;
                                            for (int j = i - 1; j >= 0; j--)
                                            {
                                                previousSplitLength += splitUnderline[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                            }
                                            string unformattedSplit = splitUnderline[i].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "");
                                            Range rangeToUnderline = subsectiontext.Range.Duplicate;
                                            rangeToUnderline.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                            rangeToUnderline.Underline = WdUnderline.wdUnderlineSingle;
                                        }
                                    }

                                    string secondFontPattern = @".{1,20}\\ffffffffffff\\";
                                    string sizeRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), sizePattern, "");
                                    string[] splitFont = sizeRemoved.Split(new string[] { "\\ffffffffff\\" }, StringSplitOptions.None); //Regex.Split(myPaper.summary.content, fontPattern);
                                    for (int i = 0; i < splitFont.Length; i++)
                                    {
                                        if (splitFont[i].Length > 0)
                                        {
                                            string[] fontParts = splitFont[i].Split(new string[] { "\\ffffffffffff\\" }, StringSplitOptions.None);
                                            string currentFont = fontParts[0];
                                            int previousSplitLength = 0;
                                            if (i > 0)
                                            {
                                                for (int j = i - 1; j >= 0; j--)
                                                {
                                                    string unformattedContent = splitFont[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                    string noFont = Regex.Replace(unformattedContent, secondFontPattern, "");
                                                    previousSplitLength += noFont.Length;
                                                }
                                            }
                                            string unformattedSplit = fontParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                            Range rangeToFontChange = subsectiontext.Range.Duplicate;
                                            rangeToFontChange.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                            rangeToFontChange.Font.Name = currentFont;
                                        }
                                    }

                                    string secondSizePattern = @".{1,20}\\ssssssssssss\\";
                                    string fontRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                    string[] splitSize = fontRemoved.Split(new string[] { "\\ssssssssss\\" }, StringSplitOptions.None);
                                    for (int i = 0; i < splitSize.Length; i++)
                                    {
                                        if (splitSize[i].Length > 0)
                                        {
                                            string[] sizeParts = splitSize[i].Split(new string[] { "\\ssssssssssss\\" }, StringSplitOptions.None);
                                            string currentSize = sizeParts[0];
                                            int previousSplitLength = 0;
                                            if (i > 0)
                                            {
                                                for (int j = i - 1; j >= 0; j--)
                                                {
                                                    string unformattedContent = Regex.Replace(splitSize[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                                    string noSize = Regex.Replace(unformattedContent, secondSizePattern, "");
                                                    previousSplitLength += noSize.Length;
                                                }
                                            }
                                            string unformattedSplit = sizeParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                            Range rangeToSizeChange = subsectiontext.Range.Duplicate;
                                            rangeToSizeChange.SetRange(previousSplitLength + subsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsectiontext.Range.Start);
                                            rangeToSizeChange.Font.Size = (float)Convert.ToDouble(currentSize);
                                        }
                                    }

                                    if (subsectiontext.Range.ParagraphFormat.LeftIndent != 36)
                                    {
                                        subsectiontext.Range.ParagraphFormat.FirstLineIndent = 36;
                                    }
                                    else
                                    {
                                        subsectiontext.Range.ParagraphFormat.FirstLineIndent = 0;
                                    }
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
                                                string unformatted = Regex.Replace(Regex.Replace(splitPara.Replace('\b'.ToString(), "").Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, ""), sizePattern, "");
                                                subsubsectiontext.Range.Text = subsubsection.title + ". " + unformatted;
                                                subsubsectiontext.Range.ParagraphFormat.LeftIndent = 0;
                                                subsubsectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                                                Range rangeForFontSize = subsubsectiontext.Range.Duplicate;
                                                rangeForFontSize.SetRange(subsubsectiontext.Range.Start, subsubsectiontext.Range.Start + subsubsection.title.Length + 2);
                                                rangeForFontSize.Font.Name = myPaper.sectionsConfig.subsubsectionLabelFont;
                                                rangeForFontSize.Font.Size = myPaper.sectionsConfig.subsubsectionLabelSize;
                                                string[] colors = myPaper.sectionsConfig.subsubsectionLabelColor.Split(',');
                                                Color color = Color.FromArgb(Convert.ToInt32(colors[3]), Convert.ToInt32(colors[0]), Convert.ToInt32(colors[1]), Convert.ToInt32(colors[2]));
                                                rangeForFontSize.Font.Color = (WdColor)(color.R + 0x100 * color.G + 0x10000 * color.B);

                                                string noFontSize = Regex.Replace(Regex.Replace(splitPara, fontPattern, ""), sizePattern, "");

                                                string[] splitIndent = noFontSize.Split('\v');
                                                for (int i = 0; i < splitIndent.Length; i++)
                                                {
                                                    if (i % 2 == 1)
                                                    {
                                                        int previousSplitLength = 0;
                                                        for (int j = i - 1; j >= 0; j--)
                                                        {
                                                            previousSplitLength += splitIndent[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "").Length;
                                                        }
                                                        string unformattedSplit = splitIndent[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "");
                                                        Range rangeToIndent = subsubsectiontext.Range.Duplicate;
                                                        rangeToIndent.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                        rangeToIndent.ParagraphFormat.LeftIndent = 36;
                                                    }
                                                }

                                                string[] splitBold = noFontSize.Split('\b');
                                                for (int i = 0; i < splitBold.Length; i++)
                                                {
                                                    if (i % 2 == 1)
                                                    {
                                                        int previousSplitLength = subsubsection.title.Length + 2;
                                                        for (int j = i - 1; j >= 0; j--)
                                                        {
                                                            previousSplitLength += splitBold[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                        }
                                                        previousSplitLength += subsection.title.Length + 2;
                                                        string unformattedSplit = splitBold[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                        Range rangeToBold = subsubsectiontext.Range.Duplicate;
                                                        rangeToBold.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                        rangeToBold.Bold = 1;
                                                    }
                                                }

                                                string[] splitItalic = noFontSize.Split('\a');
                                                for (int i = 0; i < splitItalic.Length; i++)
                                                {
                                                    if (i % 2 == 1)
                                                    {
                                                        int previousSplitLength = subsubsection.title.Length + 2;
                                                        for (int j = i - 1; j >= 0; j--)
                                                        {
                                                            previousSplitLength += splitItalic[j].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                        }
                                                        previousSplitLength += subsection.title.Length + 2;
                                                        string unformattedSplit = splitItalic[i].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                        Range rangeToItalic = subsubsectiontext.Range.Duplicate;
                                                        rangeToItalic.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                        rangeToItalic.Italic = 1;
                                                    }
                                                }

                                                string[] splitUnderline = noFontSize.Split('\f');
                                                for (int i = 0; i < splitUnderline.Length; i++)
                                                {
                                                    if (i % 2 == 1)
                                                    {
                                                        int previousSplitLength = subsubsection.title.Length + 2;
                                                        for (int j = i - 1; j >= 0; j--)
                                                        {
                                                            previousSplitLength += splitUnderline[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                        }
                                                        previousSplitLength += subsection.title.Length + 2;
                                                        string unformattedSplit = splitUnderline[i].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "");
                                                        Range rangeToUnderline = subsubsectiontext.Range.Duplicate;
                                                        rangeToUnderline.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                        rangeToUnderline.Underline = WdUnderline.wdUnderlineSingle;
                                                    }
                                                }

                                                string secondFontPattern = @".{1,20}\\ffffffffffff\\";
                                                string sizeRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), sizePattern, "");
                                                string[] splitFont = sizeRemoved.Split(new string[] { "\\ffffffffff\\" }, StringSplitOptions.None); //Regex.Split(myPaper.summary.content, fontPattern);
                                                for (int i = 0; i < splitFont.Length; i++)
                                                {
                                                    if (splitFont[i].Length > 0)
                                                    {
                                                        string[] fontParts = splitFont[i].Split(new string[] { "\\ffffffffffff\\" }, StringSplitOptions.None);
                                                        string currentFont = fontParts[0];
                                                        int previousSplitLength = subsubsection.title.Length + 2;
                                                        if (i > 0)
                                                        {
                                                            for (int j = i - 1; j >= 0; j--)
                                                            {
                                                                string unformattedContent = splitFont[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                                string noFont = Regex.Replace(unformattedContent, secondFontPattern, "");
                                                                previousSplitLength += noFont.Length;
                                                            }
                                                        }
                                                        string unformattedSplit = fontParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                        Range rangeToFontChange = subsubsectiontext.Range.Duplicate;
                                                        rangeToFontChange.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                        rangeToFontChange.Font.Name = currentFont;
                                                    }
                                                }

                                                string secondSizePattern = @".{1,20}\\ssssssssssss\\";
                                                string fontRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                                string[] splitSize = fontRemoved.Split(new string[] { "\\ssssssssss\\" }, StringSplitOptions.None);
                                                for (int i = 0; i < splitSize.Length; i++)
                                                {
                                                    if (splitSize[i].Length > 0)
                                                    {
                                                        string[] sizeParts = splitSize[i].Split(new string[] { "\\ssssssssssss\\" }, StringSplitOptions.None);
                                                        string currentSize = sizeParts[0];
                                                        int previousSplitLength = subsubsection.title.Length + 2;
                                                        if (i > 0)
                                                        {
                                                            for (int j = i - 1; j >= 0; j--)
                                                            {
                                                                string unformattedContent = Regex.Replace(splitSize[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                                                string noSize = Regex.Replace(unformattedContent, secondSizePattern, "");
                                                                previousSplitLength += noSize.Length;
                                                            }
                                                        }
                                                        string unformattedSplit = sizeParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                        Range rangeToSizeChange = subsubsectiontext.Range.Duplicate;
                                                        rangeToSizeChange.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                        rangeToSizeChange.Font.Size = (float)Convert.ToDouble(currentSize);
                                                    }
                                                }

                                                if (subsubsectiontext.Range.ParagraphFormat.LeftIndent != 36)
                                                {
                                                    subsubsectiontext.Range.ParagraphFormat.FirstLineIndent = 36;
                                                }
                                                else
                                                {
                                                    subsubsectiontext.Range.ParagraphFormat.FirstLineIndent = 0;
                                                }
                                                int start = subsubsectiontext.Range.Start;
                                                int end = subsubsectiontext.Range.Start + subsubsection.title.Length + 1;
                                                if (myPaper.sectionsConfig.subsubsectionLabelBold)
                                                {
                                                    Range rangeToBold = subsubsectiontext.Range.Duplicate;
                                                    rangeToBold.SetRange(start, end);
                                                    rangeToBold.Bold = 1;
                                                }
                                                if (myPaper.sectionsConfig.subsubsectionLabelItalics)
                                                {
                                                    Range rangeToItalicize = subsubsectiontext.Range.Duplicate;
                                                    rangeToItalicize.SetRange(start, end);
                                                    rangeToItalicize.Italic = 1;
                                                }
                                            }
                                            else if (myPaper.sectionsConfig.subsubsectionLabelOnOwnLine)
                                            {
                                                if (myPaper.sectionsConfig.subsubsectionLabelBold)
                                                {
                                                    subsubsectiontext.Range.Bold = 1;
                                                }
                                                if (myPaper.sectionsConfig.subsubsectionLabelItalics)
                                                {
                                                    subsubsectiontext.Range.Italic = 1;
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
                                                subsubsectiontext.Range.ParagraphFormat.FirstLineIndent = 0;
                                                subsubsectiontext.Range.Font.Name = myPaper.sectionsConfig.subsubsectionLabelFont;
                                                subsubsectiontext.Range.Font.Size = myPaper.sectionsConfig.subsubsectionLabelSize;
                                                string[] colors = myPaper.sectionsConfig.subsubsectionLabelColor.Split(',');
                                                Color color = Color.FromArgb(Convert.ToInt32(colors[3]), Convert.ToInt32(colors[0]), Convert.ToInt32(colors[1]), Convert.ToInt32(colors[2]));
                                                subsubsectiontext.Range.Font.Color = (WdColor)(color.R + 0x100 * color.G + 0x10000 * color.B);

                                                subsubsectiontext.Range.InsertParagraphAfter();
                                                subsubsectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                                subsubsectiontext.Range.Bold = 0;
                                                subsubsectiontext.Range.Italic = 0;
                                                subsubsectiontext.Range.Font.Color = WdColor.wdColorBlack;

                                                string unformatted = Regex.Replace(Regex.Replace(splitPara.Replace('\b'.ToString(), "").Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, ""), sizePattern, "");
                                                subsubsectiontext.Range.Text = unformatted;
                                                subsubsectiontext.Range.ParagraphFormat.LeftIndent = 0;

                                                string noFontSize = Regex.Replace(Regex.Replace(splitPara, fontPattern, ""), sizePattern, "");

                                                string[] splitIndent = noFontSize.Split('\v');
                                                for (int i = 0; i < splitIndent.Length; i++)
                                                {
                                                    if (i % 2 == 1)
                                                    {
                                                        int previousSplitLength = 0;
                                                        for (int j = i - 1; j >= 0; j--)
                                                        {
                                                            previousSplitLength += splitIndent[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "").Length;
                                                        }
                                                        string unformattedSplit = splitIndent[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "");
                                                        Range rangeToIndent = subsubsectiontext.Range.Duplicate;
                                                        rangeToIndent.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                        rangeToIndent.ParagraphFormat.LeftIndent = 36;
                                                    }
                                                }

                                                string[] splitBold = noFontSize.Split('\b');
                                                for (int i = 0; i < splitBold.Length; i++)
                                                {
                                                    if (i % 2 == 1)
                                                    {
                                                        int previousSplitLength = 0;
                                                        for (int j = i - 1; j >= 0; j--)
                                                        {
                                                            previousSplitLength += splitBold[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                        }
                                                        string unformattedSplit = splitBold[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                        Range rangeToBold = subsubsectiontext.Range.Duplicate;
                                                        rangeToBold.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                        rangeToBold.Bold = 1;
                                                    }
                                                }

                                                string[] splitItalic = noFontSize.Split('\a');
                                                for (int i = 0; i < splitItalic.Length; i++)
                                                {
                                                    if (i % 2 == 1)
                                                    {
                                                        int previousSplitLength = 0;
                                                        for (int j = i - 1; j >= 0; j--)
                                                        {
                                                            previousSplitLength += splitItalic[j].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                        }
                                                        string unformattedSplit = splitItalic[i].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                        Range rangeToItalic = subsubsectiontext.Range.Duplicate;
                                                        rangeToItalic.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                        rangeToItalic.Italic = 1;
                                                    }
                                                }

                                                string[] splitUnderline = noFontSize.Split('\f');
                                                for (int i = 0; i < splitUnderline.Length; i++)
                                                {
                                                    if (i % 2 == 1)
                                                    {
                                                        int previousSplitLength = 0;
                                                        for (int j = i - 1; j >= 0; j--)
                                                        {
                                                            previousSplitLength += splitUnderline[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                        }
                                                        string unformattedSplit = splitUnderline[i].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "");
                                                        Range rangeToUnderline = subsubsectiontext.Range.Duplicate;
                                                        rangeToUnderline.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                        rangeToUnderline.Underline = WdUnderline.wdUnderlineSingle;
                                                    }
                                                }

                                                string secondFontPattern = @".{1,20}\\ffffffffffff\\";
                                                string sizeRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), sizePattern, "");
                                                string[] splitFont = sizeRemoved.Split(new string[] { "\\ffffffffff\\" }, StringSplitOptions.None); //Regex.Split(myPaper.summary.content, fontPattern);
                                                for (int i = 0; i < splitFont.Length; i++)
                                                {
                                                    if (splitFont[i].Length > 0)
                                                    {
                                                        string[] fontParts = splitFont[i].Split(new string[] { "\\ffffffffffff\\" }, StringSplitOptions.None);
                                                        string currentFont = fontParts[0];
                                                        int previousSplitLength = 0;
                                                        if (i > 0)
                                                        {
                                                            for (int j = i - 1; j >= 0; j--)
                                                            {
                                                                string unformattedContent = splitFont[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                                string noFont = Regex.Replace(unformattedContent, secondFontPattern, "");
                                                                previousSplitLength += noFont.Length;
                                                            }
                                                        }
                                                        string unformattedSplit = fontParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                        Range rangeToFontChange = subsubsectiontext.Range.Duplicate;
                                                        rangeToFontChange.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                        rangeToFontChange.Font.Name = currentFont;
                                                    }
                                                }

                                                string secondSizePattern = @".{1,20}\\ssssssssssss\\";
                                                string fontRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                                string[] splitSize = fontRemoved.Split(new string[] { "\\ssssssssss\\" }, StringSplitOptions.None);
                                                for (int i = 0; i < splitSize.Length; i++)
                                                {
                                                    if (splitSize[i].Length > 0)
                                                    {
                                                        string[] sizeParts = splitSize[i].Split(new string[] { "\\ssssssssssss\\" }, StringSplitOptions.None);
                                                        string currentSize = sizeParts[0];
                                                        int previousSplitLength = 0;
                                                        if (i > 0)
                                                        {
                                                            for (int j = i - 1; j >= 0; j--)
                                                            {
                                                                string unformattedContent = Regex.Replace(splitSize[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                                                string noSize = Regex.Replace(unformattedContent, secondSizePattern, "");
                                                                previousSplitLength += noSize.Length;
                                                            }
                                                        }
                                                        string unformattedSplit = sizeParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                        Range rangeToSizeChange = subsubsectiontext.Range.Duplicate;
                                                        rangeToSizeChange.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                        rangeToSizeChange.Font.Size = (float)Convert.ToDouble(currentSize);
                                                    }
                                                }

                                                if (subsubsectiontext.Range.ParagraphFormat.LeftIndent != 36)
                                                {
                                                    subsubsectiontext.Range.ParagraphFormat.FirstLineIndent = 36;
                                                }
                                                else
                                                {
                                                    subsubsectiontext.Range.ParagraphFormat.FirstLineIndent = 0;
                                                }
                                            }
                                            else
                                            {
                                                string unformatted = Regex.Replace(Regex.Replace(splitPara.Replace('\b'.ToString(), "").Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, ""), sizePattern, "");
                                                subsubsectiontext.Range.Text = subsubsection.title + ". " + unformatted;
                                                subsubsectiontext.Range.ParagraphFormat.LeftIndent = 0;
                                                subsubsectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                                                Range rangeForFontSize = subsubsectiontext.Range.Duplicate;
                                                rangeForFontSize.SetRange(subsubsectiontext.Range.Start, subsubsectiontext.Range.Start + subsubsection.title.Length + 2);
                                                rangeForFontSize.Font.Name = myPaper.sectionsConfig.subsubsectionLabelFont;
                                                rangeForFontSize.Font.Size = myPaper.sectionsConfig.subsubsectionLabelSize;
                                                string[] colors = myPaper.sectionsConfig.subsubsectionLabelColor.Split(',');
                                                Color color = Color.FromArgb(Convert.ToInt32(colors[3]), Convert.ToInt32(colors[0]), Convert.ToInt32(colors[1]), Convert.ToInt32(colors[2]));
                                                rangeForFontSize.Font.Color = (WdColor)(color.R + 0x100 * color.G + 0x10000 * color.B);

                                                string noFontSize = Regex.Replace(Regex.Replace(splitPara, fontPattern, ""), sizePattern, "");

                                                string[] splitIndent = noFontSize.Split('\v');
                                                for (int i = 0; i < splitIndent.Length; i++)
                                                {
                                                    if (i % 2 == 1)
                                                    {
                                                        int previousSplitLength = 0;
                                                        for (int j = i - 1; j >= 0; j--)
                                                        {
                                                            previousSplitLength += splitIndent[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "").Length;
                                                        }
                                                        string unformattedSplit = splitIndent[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "");
                                                        Range rangeToIndent = subsubsectiontext.Range.Duplicate;
                                                        rangeToIndent.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                        rangeToIndent.ParagraphFormat.LeftIndent = 36;
                                                    }
                                                }

                                                string[] splitBold = noFontSize.Split('\b');
                                                for (int i = 0; i < splitBold.Length; i++)
                                                {
                                                    if (i % 2 == 1)
                                                    {
                                                        int previousSplitLength = subsubsection.title.Length + 2;
                                                        for (int j = i - 1; j >= 0; j--)
                                                        {
                                                            previousSplitLength += splitBold[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                        }
                                                        previousSplitLength += subsection.title.Length + 2;
                                                        string unformattedSplit = splitBold[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                        Range rangeToBold = subsubsectiontext.Range.Duplicate;
                                                        rangeToBold.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                        rangeToBold.Bold = 1;
                                                    }
                                                }

                                                string[] splitItalic = noFontSize.Split('\a');
                                                for (int i = 0; i < splitItalic.Length; i++)
                                                {
                                                    if (i % 2 == 1)
                                                    {
                                                        int previousSplitLength = subsubsection.title.Length + 2;
                                                        for (int j = i - 1; j >= 0; j--)
                                                        {
                                                            previousSplitLength += splitItalic[j].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                        }
                                                        previousSplitLength += subsection.title.Length + 2;
                                                        string unformattedSplit = splitItalic[i].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                        Range rangeToItalic = subsubsectiontext.Range.Duplicate;
                                                        rangeToItalic.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                        rangeToItalic.Italic = 1;
                                                    }
                                                }

                                                string[] splitUnderline = noFontSize.Split('\f');
                                                for (int i = 0; i < splitUnderline.Length; i++)
                                                {
                                                    if (i % 2 == 1)
                                                    {
                                                        int previousSplitLength = subsubsection.title.Length + 2;
                                                        for (int j = i - 1; j >= 0; j--)
                                                        {
                                                            previousSplitLength += splitUnderline[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                        }
                                                        previousSplitLength += subsection.title.Length + 2;
                                                        string unformattedSplit = splitUnderline[i].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "");
                                                        Range rangeToUnderline = subsubsectiontext.Range.Duplicate;
                                                        rangeToUnderline.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                        rangeToUnderline.Underline = WdUnderline.wdUnderlineSingle;
                                                    }
                                                }

                                                string secondFontPattern = @".{1,20}\\ffffffffffff\\";
                                                string sizeRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), sizePattern, "");
                                                string[] splitFont = sizeRemoved.Split(new string[] { "\\ffffffffff\\" }, StringSplitOptions.None); //Regex.Split(myPaper.summary.content, fontPattern);
                                                for (int i = 0; i < splitFont.Length; i++)
                                                {
                                                    if (splitFont[i].Length > 0)
                                                    {
                                                        string[] fontParts = splitFont[i].Split(new string[] { "\\ffffffffffff\\" }, StringSplitOptions.None);
                                                        string currentFont = fontParts[0];
                                                        int previousSplitLength = subsubsection.title.Length + 2;
                                                        if (i > 0)
                                                        {
                                                            for (int j = i - 1; j >= 0; j--)
                                                            {
                                                                string unformattedContent = splitFont[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                                string noFont = Regex.Replace(unformattedContent, secondFontPattern, "");
                                                                previousSplitLength += noFont.Length;
                                                            }
                                                        }
                                                        string unformattedSplit = fontParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                        Range rangeToFontChange = subsubsectiontext.Range.Duplicate;
                                                        rangeToFontChange.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                        rangeToFontChange.Font.Name = currentFont;
                                                    }
                                                }

                                                string secondSizePattern = @".{1,20}\\ssssssssssss\\";
                                                string fontRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                                string[] splitSize = fontRemoved.Split(new string[] { "\\ssssssssss\\" }, StringSplitOptions.None);
                                                for (int i = 0; i < splitSize.Length; i++)
                                                {
                                                    if (splitSize[i].Length > 0)
                                                    {
                                                        string[] sizeParts = splitSize[i].Split(new string[] { "\\ssssssssssss\\" }, StringSplitOptions.None);
                                                        string currentSize = sizeParts[0];
                                                        int previousSplitLength = subsubsection.title.Length + 2;
                                                        if (i > 0)
                                                        {
                                                            for (int j = i - 1; j >= 0; j--)
                                                            {
                                                                string unformattedContent = Regex.Replace(splitSize[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                                                string noSize = Regex.Replace(unformattedContent, secondSizePattern, "");
                                                                previousSplitLength += noSize.Length;
                                                            }
                                                        }
                                                        string unformattedSplit = sizeParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                        Range rangeToSizeChange = subsubsectiontext.Range.Duplicate;
                                                        rangeToSizeChange.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                        rangeToSizeChange.Font.Size = (float)Convert.ToDouble(currentSize);
                                                    }
                                                }

                                                if (subsubsectiontext.Range.ParagraphFormat.LeftIndent != 36)
                                                {
                                                    subsubsectiontext.Range.ParagraphFormat.FirstLineIndent = 36;
                                                }
                                                else
                                                {
                                                    subsubsectiontext.Range.ParagraphFormat.FirstLineIndent = 0;
                                                }
                                                int start = subsubsectiontext.Range.Start;
                                                int end = subsubsectiontext.Range.Start + subsubsection.title.Length + 1;
                                                if (myPaper.sectionsConfig.subsubsectionLabelBold)
                                                {
                                                    Range rangeToBold = subsubsectiontext.Range.Duplicate;
                                                    rangeToBold.SetRange(start, end);
                                                    rangeToBold.Bold = 1;
                                                }
                                                if (myPaper.sectionsConfig.subsubsectionLabelItalics)
                                                {
                                                    Range rangeToItalicize = subsubsectiontext.Range.Duplicate;
                                                    rangeToItalicize.SetRange(start, end);
                                                    rangeToItalicize.Italic = 1;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            string unformatted = Regex.Replace(Regex.Replace(splitPara.Replace('\b'.ToString(), "").Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, ""), sizePattern, "");
                                            subsubsectiontext.Range.Text = unformatted;
                                            subsubsectiontext.Range.ParagraphFormat.LeftIndent = 0;
                                            subsubsectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                                            string noFontSize = Regex.Replace(Regex.Replace(splitPara, fontPattern, ""), sizePattern, "");

                                            string[] splitIndent = noFontSize.Split('\v');
                                            for (int i = 0; i < splitIndent.Length; i++)
                                            {
                                                if (i % 2 == 1)
                                                {
                                                    int previousSplitLength = 0;
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        previousSplitLength += splitIndent[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "").Length;
                                                    }
                                                    string unformattedSplit = splitIndent[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "");
                                                    Range rangeToIndent = subsubsectiontext.Range.Duplicate;
                                                    rangeToIndent.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                    rangeToIndent.ParagraphFormat.LeftIndent = 36;
                                                }
                                            }

                                            string[] splitBold = noFontSize.Split('\b');
                                            for (int i = 0; i < splitBold.Length; i++)
                                            {
                                                if (i % 2 == 1)
                                                {
                                                    int previousSplitLength = 0;
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        previousSplitLength += splitBold[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                    }
                                                    string unformattedSplit = splitBold[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                    Range rangeToBold = subsubsectiontext.Range.Duplicate;
                                                    rangeToBold.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                    rangeToBold.Bold = 1;
                                                }
                                            }

                                            string[] splitItalic = noFontSize.Split('\a');
                                            for (int i = 0; i < splitItalic.Length; i++)
                                            {
                                                if (i % 2 == 1)
                                                {
                                                    int previousSplitLength = 0;
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        previousSplitLength += splitItalic[j].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                    }
                                                    string unformattedSplit = splitItalic[i].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                    Range rangeToItalic = subsubsectiontext.Range.Duplicate;
                                                    rangeToItalic.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                    rangeToItalic.Italic = 1;
                                                }
                                            }

                                            string[] splitUnderline = noFontSize.Split('\f');
                                            for (int i = 0; i < splitUnderline.Length; i++)
                                            {
                                                if (i % 2 == 1)
                                                {
                                                    int previousSplitLength = 0;
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        previousSplitLength += splitUnderline[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                    }
                                                    string unformattedSplit = splitUnderline[i].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "");
                                                    Range rangeToUnderline = subsubsectiontext.Range.Duplicate;
                                                    rangeToUnderline.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                    rangeToUnderline.Underline = WdUnderline.wdUnderlineSingle;
                                                }
                                            }

                                            string secondFontPattern = @".{1,20}\\ffffffffffff\\";
                                            string sizeRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), sizePattern, "");
                                            string[] splitFont = sizeRemoved.Split(new string[] { "\\ffffffffff\\" }, StringSplitOptions.None); //Regex.Split(myPaper.summary.content, fontPattern);
                                            for (int i = 0; i < splitFont.Length; i++)
                                            {
                                                if (splitFont[i].Length > 0)
                                                {
                                                    string[] fontParts = splitFont[i].Split(new string[] { "\\ffffffffffff\\" }, StringSplitOptions.None);
                                                    string currentFont = fontParts[0];
                                                    int previousSplitLength = 0;
                                                    if (i > 0)
                                                    {
                                                        for (int j = i - 1; j >= 0; j--)
                                                        {
                                                            string unformattedContent = splitFont[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                            string noFont = Regex.Replace(unformattedContent, secondFontPattern, "");
                                                            previousSplitLength += noFont.Length;
                                                        }
                                                    }
                                                    string unformattedSplit = fontParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                    Range rangeToFontChange = subsubsectiontext.Range.Duplicate;
                                                    rangeToFontChange.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                    rangeToFontChange.Font.Name = currentFont;
                                                }
                                            }

                                            string secondSizePattern = @".{1,20}\\ssssssssssss\\";
                                            string fontRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                            string[] splitSize = fontRemoved.Split(new string[] { "\\ssssssssss\\" }, StringSplitOptions.None);
                                            for (int i = 0; i < splitSize.Length; i++)
                                            {
                                                if (splitSize[i].Length > 0)
                                                {
                                                    string[] sizeParts = splitSize[i].Split(new string[] { "\\ssssssssssss\\" }, StringSplitOptions.None);
                                                    string currentSize = sizeParts[0];
                                                    int previousSplitLength = 0;
                                                    if (i > 0)
                                                    {
                                                        for (int j = i - 1; j >= 0; j--)
                                                        {
                                                            string unformattedContent = Regex.Replace(splitSize[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                                            string noSize = Regex.Replace(unformattedContent, secondSizePattern, "");
                                                            previousSplitLength += noSize.Length;
                                                        }
                                                    }
                                                    string unformattedSplit = sizeParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                    Range rangeToSizeChange = subsubsectiontext.Range.Duplicate;
                                                    rangeToSizeChange.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                    rangeToSizeChange.Font.Size = (float)Convert.ToDouble(currentSize);
                                                }
                                            }

                                            if (subsubsectiontext.Range.ParagraphFormat.LeftIndent != 36)
                                            {
                                                subsubsectiontext.Range.ParagraphFormat.FirstLineIndent = 36;
                                            }
                                            else
                                            {
                                                subsubsectiontext.Range.ParagraphFormat.FirstLineIndent = 0;
                                            }
                                        }
                                        subsubsectiontext.Range.InsertParagraphAfter();
                                    }
                                    else
                                    {
                                        string unformatted = Regex.Replace(Regex.Replace(splitPara.Replace('\b'.ToString(), "").Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, ""), sizePattern, "");
                                        subsubsectiontext.Range.Text = unformatted;
                                        subsubsectiontext.Range.ParagraphFormat.LeftIndent = 0;
                                        subsubsectiontext.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                                        string noFontSize = Regex.Replace(Regex.Replace(splitPara, fontPattern, ""), sizePattern, "");

                                        string[] splitIndent = noFontSize.Split('\v');
                                        for (int i = 0; i < splitIndent.Length; i++)
                                        {
                                            if (i % 2 == 1)
                                            {
                                                int previousSplitLength = 0;
                                                for (int j = i - 1; j >= 0; j--)
                                                {
                                                    previousSplitLength += splitIndent[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "").Length;
                                                }
                                                string unformattedSplit = splitIndent[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "");
                                                Range rangeToIndent = subsubsectiontext.Range.Duplicate;
                                                rangeToIndent.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                rangeToIndent.ParagraphFormat.LeftIndent = 36;
                                            }
                                        }

                                        string[] splitBold = noFontSize.Split('\b');
                                        for (int i = 0; i < splitBold.Length; i++)
                                        {
                                            if (i % 2 == 1)
                                            {
                                                int previousSplitLength = 0;
                                                for (int j = i - 1; j >= 0; j--)
                                                {
                                                    previousSplitLength += splitBold[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                }
                                                string unformattedSplit = splitBold[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToBold = subsubsectiontext.Range.Duplicate;
                                                rangeToBold.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                rangeToBold.Bold = 1;
                                            }
                                        }

                                        string[] splitItalic = noFontSize.Split('\a');
                                        for (int i = 0; i < splitItalic.Length; i++)
                                        {
                                            if (i % 2 == 1)
                                            {
                                                int previousSplitLength = 0;
                                                for (int j = i - 1; j >= 0; j--)
                                                {
                                                    previousSplitLength += splitItalic[j].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                }
                                                string unformattedSplit = splitItalic[i].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToItalic = subsubsectiontext.Range.Duplicate;
                                                rangeToItalic.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                rangeToItalic.Italic = 1;
                                            }
                                        }

                                        string[] splitUnderline = noFontSize.Split('\f');
                                        for (int i = 0; i < splitUnderline.Length; i++)
                                        {
                                            if (i % 2 == 1)
                                            {
                                                int previousSplitLength = 0;
                                                for (int j = i - 1; j >= 0; j--)
                                                {
                                                    previousSplitLength += splitUnderline[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                                }
                                                string unformattedSplit = splitUnderline[i].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToUnderline = subsubsectiontext.Range.Duplicate;
                                                rangeToUnderline.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                rangeToUnderline.Underline = WdUnderline.wdUnderlineSingle;
                                            }
                                        }

                                        string secondFontPattern = @".{1,20}\\ffffffffffff\\";
                                        string sizeRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), sizePattern, "");
                                        string[] splitFont = sizeRemoved.Split(new string[] { "\\ffffffffff\\" }, StringSplitOptions.None); //Regex.Split(myPaper.summary.content, fontPattern);
                                        for (int i = 0; i < splitFont.Length; i++)
                                        {
                                            if (splitFont[i].Length > 0)
                                            {
                                                string[] fontParts = splitFont[i].Split(new string[] { "\\ffffffffffff\\" }, StringSplitOptions.None);
                                                string currentFont = fontParts[0];
                                                int previousSplitLength = 0;
                                                if (i > 0)
                                                {
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        string unformattedContent = splitFont[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                        string noFont = Regex.Replace(unformattedContent, secondFontPattern, "");
                                                        previousSplitLength += noFont.Length;
                                                    }
                                                }
                                                string unformattedSplit = fontParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToFontChange = subsubsectiontext.Range.Duplicate;
                                                rangeToFontChange.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                rangeToFontChange.Font.Name = currentFont;
                                            }
                                        }

                                        string secondSizePattern = @".{1,20}\\ssssssssssss\\";
                                        string fontRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                        string[] splitSize = fontRemoved.Split(new string[] { "\\ssssssssss\\" }, StringSplitOptions.None);
                                        for (int i = 0; i < splitSize.Length; i++)
                                        {
                                            if (splitSize[i].Length > 0)
                                            {
                                                string[] sizeParts = splitSize[i].Split(new string[] { "\\ssssssssssss\\" }, StringSplitOptions.None);
                                                string currentSize = sizeParts[0];
                                                int previousSplitLength = 0;
                                                if (i > 0)
                                                {
                                                    for (int j = i - 1; j >= 0; j--)
                                                    {
                                                        string unformattedContent = Regex.Replace(splitSize[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                                        string noSize = Regex.Replace(unformattedContent, secondSizePattern, "");
                                                        previousSplitLength += noSize.Length;
                                                    }
                                                }
                                                string unformattedSplit = sizeParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                Range rangeToSizeChange = subsubsectiontext.Range.Duplicate;
                                                rangeToSizeChange.SetRange(previousSplitLength + subsubsectiontext.Range.Start, previousSplitLength + unformattedSplit.Length + subsubsectiontext.Range.Start);
                                                rangeToSizeChange.Font.Size = (float)Convert.ToDouble(currentSize);
                                            }
                                        }

                                        if (subsubsectiontext.Range.ParagraphFormat.LeftIndent != 36)
                                        {
                                            subsubsectiontext.Range.ParagraphFormat.FirstLineIndent = 36;
                                        }
                                        else
                                        {
                                            subsubsectiontext.Range.ParagraphFormat.FirstLineIndent = 0;
                                        }
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
                        string[] splitConclusion = myPaper.conclusion.conclusionContent.Split('\n');
                        bool isFirstOfPara = true;

                        foreach (string splitPara in splitConclusion)
                        {
                            Paragraph text = document.Content.Paragraphs.Add(ref missing);
                            if (isFirstOfPara)
                            {
                                isFirstOfPara = false;
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
                                    text.Range.ParagraphFormat.FirstLineIndent = 0;
                                    text.Range.Font.Name = myPaper.conclusion.titleFont;
                                    text.Range.Font.Size = myPaper.conclusion.titleSize;
                                    string[] colors = myPaper.conclusion.titleColor.Split(',');
                                    Color color = Color.FromArgb(Convert.ToInt32(colors[3]), Convert.ToInt32(colors[0]), Convert.ToInt32(colors[1]), Convert.ToInt32(colors[2]));
                                    text.Range.Font.Color = (WdColor)(color.R + 0x100 * color.G + 0x10000 * color.B);
                                    text.Range.InsertParagraphAfter();
                                }
                                string unformatted = Regex.Replace(Regex.Replace(splitPara.Replace('\b'.ToString(), "").Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, ""), sizePattern, "");
                                text.Range.Text = unformatted;
                                text.Range.ParagraphFormat.LeftIndent = 0;
                                text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                text.Range.Bold = 0;
                                text.Range.Font.Color = WdColor.wdColorBlack;

                                string noFontSize = Regex.Replace(Regex.Replace(splitPara, fontPattern, ""), sizePattern, "");

                                string[] splitIndent = noFontSize.Split('\v');
                                for (int i = 0; i < splitIndent.Length; i++)
                                {
                                    if (i % 2 == 1)
                                    {
                                        int previousSplitLength = 0;
                                        for (int j = i - 1; j >= 0; j--)
                                        {
                                            previousSplitLength += splitIndent[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "").Length;
                                        }
                                        string unformattedSplit = splitIndent[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "");
                                        Range rangeToIndent = text.Range.Duplicate;
                                        rangeToIndent.SetRange(previousSplitLength + text.Range.Start, previousSplitLength + unformattedSplit.Length + text.Range.Start);
                                        rangeToIndent.ParagraphFormat.LeftIndent = 36;
                                    }
                                }

                                string[] splitBold = noFontSize.Split('\b');
                                for (int i = 0; i < splitBold.Length; i++)
                                {
                                    if (i % 2 == 1)
                                    {
                                        int previousSplitLength = 0;
                                        for (int j = i - 1; j >= 0; j--)
                                        {
                                            previousSplitLength += splitBold[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                        }
                                        string unformattedSplit = splitBold[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                        Range rangeToBold = text.Range.Duplicate;
                                        rangeToBold.SetRange(previousSplitLength + text.Range.Start, previousSplitLength + unformattedSplit.Length + text.Range.Start);
                                        rangeToBold.Bold = 1;
                                    }
                                }

                                string[] splitItalic = noFontSize.Split('\a');
                                for (int i = 0; i < splitItalic.Length; i++)
                                {
                                    if (i % 2 == 1)
                                    {
                                        int previousSplitLength = 0;
                                        for (int j = i - 1; j >= 0; j--)
                                        {
                                            previousSplitLength += splitItalic[j].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                        }
                                        string unformattedSplit = splitItalic[i].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                        Range rangeToItalic = text.Range.Duplicate;
                                        rangeToItalic.SetRange(previousSplitLength + text.Range.Start, previousSplitLength + unformattedSplit.Length + text.Range.Start);
                                        rangeToItalic.Italic = 1;
                                    }
                                }

                                string[] splitUnderline = noFontSize.Split('\f');
                                for (int i = 0; i < splitUnderline.Length; i++)
                                {
                                    if (i % 2 == 1)
                                    {
                                        int previousSplitLength = 0;
                                        for (int j = i - 1; j >= 0; j--)
                                        {
                                            previousSplitLength += splitUnderline[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                        }
                                        string unformattedSplit = splitUnderline[i].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "");
                                        Range rangeToUnderline = text.Range.Duplicate;
                                        rangeToUnderline.SetRange(previousSplitLength + text.Range.Start, previousSplitLength + unformattedSplit.Length + text.Range.Start);
                                        rangeToUnderline.Underline = WdUnderline.wdUnderlineSingle;
                                    }
                                }

                                string secondFontPattern = @".{1,20}\\ffffffffffff\\";
                                string sizeRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), sizePattern, "");
                                string[] splitFont = sizeRemoved.Split(new string[] { "\\ffffffffff\\" }, StringSplitOptions.None); //Regex.Split(myPaper.summary.content, fontPattern);
                                for (int i = 0; i < splitFont.Length; i++)
                                {
                                    if (splitFont[i].Length > 0)
                                    {
                                        string[] fontParts = splitFont[i].Split(new string[] { "\\ffffffffffff\\" }, StringSplitOptions.None);
                                        string currentFont = fontParts[0];
                                        int previousSplitLength = 0;
                                        if (i > 0)
                                        {
                                            for (int j = i - 1; j >= 0; j--)
                                            {
                                                string unformattedContent = splitFont[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                string noFont = Regex.Replace(unformattedContent, secondFontPattern, "");
                                                previousSplitLength += noFont.Length;
                                            }
                                        }
                                        string unformattedSplit = fontParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                        Range rangeToFontChange = text.Range.Duplicate;
                                        rangeToFontChange.SetRange(previousSplitLength + text.Range.Start, previousSplitLength + unformattedSplit.Length + text.Range.Start);
                                        rangeToFontChange.Font.Name = currentFont;
                                    }
                                }

                                string secondSizePattern = @".{1,20}\\ssssssssssss\\";
                                string fontRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                string[] splitSize = fontRemoved.Split(new string[] { "\\ssssssssss\\" }, StringSplitOptions.None);
                                for (int i = 0; i < splitSize.Length; i++)
                                {
                                    if (splitSize[i].Length > 0)
                                    {
                                        string[] sizeParts = splitSize[i].Split(new string[] { "\\ssssssssssss\\" }, StringSplitOptions.None);
                                        string currentSize = sizeParts[0];
                                        int previousSplitLength = 0;
                                        if (i > 0)
                                        {
                                            for (int j = i - 1; j >= 0; j--)
                                            {
                                                string unformattedContent = Regex.Replace(splitSize[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                                string noSize = Regex.Replace(unformattedContent, secondSizePattern, "");
                                                previousSplitLength += noSize.Length;
                                            }
                                        }
                                        string unformattedSplit = sizeParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                        Range rangeToSizeChange = text.Range.Duplicate;
                                        rangeToSizeChange.SetRange(previousSplitLength + text.Range.Start, previousSplitLength + unformattedSplit.Length + text.Range.Start);
                                        rangeToSizeChange.Font.Size = (float)Convert.ToDouble(currentSize);
                                    }
                                }
                                if (text.Range.ParagraphFormat.LeftIndent != 36)
                                {
                                    text.Range.ParagraphFormat.FirstLineIndent = 36;
                                }
                                else
                                {
                                    text.Range.ParagraphFormat.FirstLineIndent = 0;
                                }
                                text.Range.InsertParagraphAfter();
                            }
                            else
                            {
                                string unformatted = Regex.Replace(Regex.Replace(splitPara.Replace('\b'.ToString(), "").Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, ""), sizePattern, "");
                                text.Range.Text = unformatted;
                                text.Range.ParagraphFormat.LeftIndent = 0;
                                text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                text.Range.Bold = 0;

                                string noFontSize = Regex.Replace(Regex.Replace(splitPara, fontPattern, ""), sizePattern, "");

                                string[] splitIndent = noFontSize.Split('\v');
                                for (int i = 0; i < splitIndent.Length; i++)
                                {
                                    if (i % 2 == 1)
                                    {
                                        int previousSplitLength = 0;
                                        for (int j = i - 1; j >= 0; j--)
                                        {
                                            previousSplitLength += splitIndent[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "").Length;
                                        }
                                        string unformattedSplit = splitIndent[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\b'.ToString(), "");
                                        Range rangeToIndent = text.Range.Duplicate;
                                        rangeToIndent.SetRange(previousSplitLength + text.Range.Start, previousSplitLength + unformattedSplit.Length + text.Range.Start);
                                        rangeToIndent.ParagraphFormat.LeftIndent = 36;
                                    }
                                }

                                string[] splitBold = noFontSize.Split('\b');
                                for (int i = 0; i < splitBold.Length; i++)
                                {
                                    if (i % 2 == 1)
                                    {
                                        int previousSplitLength = 0;
                                        for (int j = i - 1; j >= 0; j--)
                                        {
                                            previousSplitLength += splitBold[j].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                        }
                                        string unformattedSplit = splitBold[i].Replace('\a'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                        Range rangeToBold = text.Range.Duplicate;
                                        rangeToBold.SetRange(previousSplitLength + text.Range.Start, previousSplitLength + unformattedSplit.Length + text.Range.Start);
                                        rangeToBold.Bold = 1;
                                    }
                                }

                                string[] splitItalic = noFontSize.Split('\a');
                                for (int i = 0; i < splitItalic.Length; i++)
                                {
                                    if (i % 2 == 1)
                                    {
                                        int previousSplitLength = 0;
                                        for (int j = i - 1; j >= 0; j--)
                                        {
                                            previousSplitLength += splitItalic[j].Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                        }
                                        string unformattedSplit = splitItalic[i].Replace('\b'.ToString(), "").Replace('\f'.ToString().Replace('\v'.ToString(), ""), "");
                                        Range rangeToItalic = text.Range.Duplicate;
                                        rangeToItalic.SetRange(previousSplitLength + text.Range.Start, previousSplitLength + unformattedSplit.Length + text.Range.Start);
                                        rangeToItalic.Italic = 1;
                                    }
                                }

                                string[] splitUnderline = noFontSize.Split('\f');
                                for (int i = 0; i < splitUnderline.Length; i++)
                                {
                                    if (i % 2 == 1)
                                    {
                                        int previousSplitLength = 0;
                                        for (int j = i - 1; j >= 0; j--)
                                        {
                                            previousSplitLength += splitUnderline[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "").Length;
                                        }
                                        string unformattedSplit = splitUnderline[i].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\v'.ToString(), "");
                                        Range rangeToUnderline = text.Range.Duplicate;
                                        rangeToUnderline.SetRange(previousSplitLength + text.Range.Start, previousSplitLength + unformattedSplit.Length + text.Range.Start);
                                        rangeToUnderline.Underline = WdUnderline.wdUnderlineSingle;
                                    }
                                }

                                string secondFontPattern = @".{1,20}\\ffffffffffff\\";
                                string sizeRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), sizePattern, "");
                                string[] splitFont = sizeRemoved.Split(new string[] { "\\ffffffffff\\" }, StringSplitOptions.None); //Regex.Split(myPaper.summary.content, fontPattern);
                                for (int i = 0; i < splitFont.Length; i++)
                                {
                                    if (splitFont[i].Length > 0)
                                    {
                                        string[] fontParts = splitFont[i].Split(new string[] { "\\ffffffffffff\\" }, StringSplitOptions.None);
                                        string currentFont = fontParts[0];
                                        int previousSplitLength = 0;
                                        if (i > 0)
                                        {
                                            for (int j = i - 1; j >= 0; j--)
                                            {
                                                string unformattedContent = splitFont[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                                string noFont = Regex.Replace(unformattedContent, secondFontPattern, "");
                                                previousSplitLength += noFont.Length;
                                            }
                                        }
                                        string unformattedSplit = fontParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                        Range rangeToFontChange = text.Range.Duplicate;
                                        rangeToFontChange.SetRange(previousSplitLength + text.Range.Start, previousSplitLength + unformattedSplit.Length + text.Range.Start);
                                        rangeToFontChange.Font.Name = currentFont;
                                    }
                                }

                                string secondSizePattern = @".{1,20}\\ssssssssssss\\";
                                string fontRemoved = Regex.Replace(splitPara.Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                string[] splitSize = fontRemoved.Split(new string[] { "\\ssssssssss\\" }, StringSplitOptions.None);
                                for (int i = 0; i < splitSize.Length; i++)
                                {
                                    if (splitSize[i].Length > 0)
                                    {
                                        string[] sizeParts = splitSize[i].Split(new string[] { "\\ssssssssssss\\" }, StringSplitOptions.None);
                                        string currentSize = sizeParts[0];
                                        int previousSplitLength = 0;
                                        if (i > 0)
                                        {
                                            for (int j = i - 1; j >= 0; j--)
                                            {
                                                string unformattedContent = Regex.Replace(splitSize[j].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), ""), fontPattern, "");
                                                string noSize = Regex.Replace(unformattedContent, secondSizePattern, "");
                                                previousSplitLength += noSize.Length;
                                            }
                                        }
                                        string unformattedSplit = sizeParts[1].Replace('\a'.ToString(), "").Replace('\b'.ToString(), "").Replace('\f'.ToString(), "").Replace('\v'.ToString(), "");
                                        Range rangeToSizeChange = text.Range.Duplicate;
                                        rangeToSizeChange.SetRange(previousSplitLength + text.Range.Start, previousSplitLength + unformattedSplit.Length + text.Range.Start);
                                        rangeToSizeChange.Font.Size = (float)Convert.ToDouble(currentSize);
                                    }
                                }

                                if (text.Range.ParagraphFormat.LeftIndent != 36)
                                {
                                    text.Range.ParagraphFormat.FirstLineIndent = 36;
                                }
                                else
                                {
                                    text.Range.ParagraphFormat.FirstLineIndent = 0;
                                }

                                text.Range.InsertParagraphAfter();
                            }
                        }
                    }

                    if (myPaper.includeReferences)
                    {
                        Paragraph pagebreak = document.Content.Paragraphs.Add(ref missing);
                        pagebreak.Range.InsertBreak(WdBreakType.wdPageBreak);
                        Paragraph text = document.Content.Paragraphs.Add(ref missing);
                        if (myPaper.references.includeTitle)
                        {
                            if (myPaper.references.boldTitle)
                            {
                                text.Range.Bold = 1;
                            }
                            text.Range.Text = myPaper.references.title;
                            if (myPaper.references.titleAlign == "Center")
                            {
                                text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                            }
                            else if (myPaper.references.titleAlign == "Right")
                            {
                                text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                            }
                            else if (myPaper.references.titleAlign == "Left")
                            {
                                text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                            }
                            text.Range.ParagraphFormat.FirstLineIndent = 0;
                            text.Range.Font.Name = myPaper.references.titleFont;
                            text.Range.Font.Size = myPaper.references.titleSize;
                            string[] colors = myPaper.references.titleColor.Split(',');
                            Color color = Color.FromArgb(Convert.ToInt32(colors[3]), Convert.ToInt32(colors[0]), Convert.ToInt32(colors[1]), Convert.ToInt32(colors[2]));
                            text.Range.Font.Color = (WdColor)(color.R + 0x100 * color.G + 0x10000 * color.B);
                            text.Range.InsertParagraphAfter();
                        }
                        foreach (Reference reference in myPaper.references.references)
                        {
                            string formattedReference = reference.formattedReference;
                            string unformattedReference = formattedReference.Replace('\a'.ToString(), "");
                            text.Range.Text = unformattedReference;
                            text.Range.Font.Name = myPaper.references.titleFont;
                            text.Range.Font.Size = myPaper.references.titleSize;
                            text.Range.Font.Color = WdColor.wdColorBlack;                           
                            text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                            text.Range.Bold = 0;
                            string[] splitReference = formattedReference.Split('\a');
                            for (int i = 0; i < splitReference.Length; i++)
                            {
                                if (i % 2 == 1)
                                {
                                    int previousCount = 0;
                                    for (int j = i - 1; j >= 0; j--)
                                    {
                                        previousCount += splitReference[j].Length;
                                    }
                                    Range rangeToItalic = text.Range.Duplicate;
                                    rangeToItalic.SetRange(previousCount + text.Range.Start, previousCount + splitReference[i].Length + text.Range.Start);
                                    rangeToItalic.Italic = 1;
                                }
                            }
                            if (myPaper.references.hangingIndent)
                            {
                                text.Range.ParagraphFormat.TabHangingIndent(Convert.ToInt16(myPaper.references.tabsHangingIndent));
                            }
                            text.Range.InsertParagraphAfter();
                        }


                        text.Range.InsertParagraphAfter();
                    }

                    if (myPaper.includeHeader)
                    {
                        foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
                        {
                            if (myPaper.header.differentFirstPage && myPaper.header.useRunningHead)
                            {
                                if (myPaper.header.moreDifferent)
                                {
                                    document.PageSetup.DifferentFirstPageHeaderFooter = -1;
                                    Range firstHeaderRange = section.Headers[WdHeaderFooterIndex.wdHeaderFooterFirstPage].Range;
                                    firstHeaderRange.Collapse(WdCollapseDirection.wdCollapseEnd);
                                    if (myPaper.header.firstRightLastPageNum)
                                    {
                                        firstHeaderRange.Fields.Add(firstHeaderRange, WdFieldType.wdFieldPage);                                        
                                        Paragraph lastName = firstHeaderRange.Paragraphs.Add();
                                        lastName.Range.Text = "\t\t" + myPaper.header.firstRightLastName + " ";
                                        lastName.Range.Font.Name = myPaper.references.titleFont;
                                        lastName.Range.Font.Size = myPaper.references.titleSize;
                                        firstHeaderRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                    }
                                    else if (myPaper.header.firstRightPageNum)
                                    {
                                        firstHeaderRange.Fields.Add(firstHeaderRange, WdFieldType.wdFieldPage);
                                        Paragraph spacer = firstHeaderRange.Paragraphs.Add();
                                        spacer.Range.Text = "\t\t";
                                        spacer.Range.Font.Name = myPaper.references.titleFont;
                                        spacer.Range.Font.Size = myPaper.references.titleSize;
                                        firstHeaderRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                    }
                                    else if (myPaper.header.firstRightOther)
                                    {
                                        Paragraph other = firstHeaderRange.Paragraphs.Add();
                                        other.Range.Text = "\t\t" + myPaper.header.firstRightOtherText;
                                        other.Range.Font.Name = myPaper.references.titleFont;
                                        other.Range.Font.Size = myPaper.references.titleSize;
                                        firstHeaderRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                    }
                                    else if (myPaper.header.firstRightTitle)
                                    {
                                        Paragraph other = firstHeaderRange.Paragraphs.Add();
                                        other.Range.Text = "\t\t" + myPaper.header.firstRightTitleText.ToUpper();
                                        other.Range.Font.Name = myPaper.references.titleFont;
                                        other.Range.Font.Size = myPaper.references.titleSize;
                                        firstHeaderRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                    }
                                    if (myPaper.header.firstLeftLastPageNum)
                                    {
                                        firstHeaderRange.Fields.Add(firstHeaderRange, WdFieldType.wdFieldPage);
                                        Paragraph lastName = firstHeaderRange.Paragraphs.Add();
                                        lastName.Range.Text = "Running head: " + myPaper.header.firstLeftLastName + " ";
                                        lastName.Range.Font.Name = myPaper.references.titleFont;
                                        lastName.Range.Font.Size = myPaper.references.titleSize;
                                        firstHeaderRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                    }
                                    else if (myPaper.header.firstLeftPageNum)
                                    {
                                        firstHeaderRange.Fields.Add(firstHeaderRange, WdFieldType.wdFieldPage);
                                        Paragraph text = firstHeaderRange.Paragraphs.Add();
                                        text.Range.Text = "Running head: ";
                                        text.Range.Font.Name = myPaper.references.titleFont;
                                        text.Range.Font.Size = myPaper.references.titleSize;
                                        firstHeaderRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                    }
                                    else if (myPaper.header.firstLeftOther)
                                    {
                                        Paragraph other = firstHeaderRange.Paragraphs.Add();
                                        other.Range.Text = "Running head: " + myPaper.header.firstLeftOtherText;
                                        other.Range.Font.Name = myPaper.references.titleFont;
                                        other.Range.Font.Size = myPaper.references.titleSize;
                                        firstHeaderRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                    }
                                    else if (myPaper.header.firstLeftTitle)
                                    {
                                        Paragraph other = firstHeaderRange.Paragraphs.Add();
                                        other.Range.Text = "Running head: " + myPaper.header.firstLeftTitleText.ToUpper();
                                        other.Range.Font.Name = myPaper.references.titleFont;
                                        other.Range.Font.Size = myPaper.references.titleSize;
                                        firstHeaderRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                    }
                                    firstHeaderRange.Font.Name = myPaper.references.titleFont;
                                    firstHeaderRange.Font.Size = myPaper.references.titleSize;
                                }
                                else
                                {
                                    document.PageSetup.DifferentFirstPageHeaderFooter = -1;
                                    Range firstHeaderRange = section.Headers[WdHeaderFooterIndex.wdHeaderFooterFirstPage].Range;
                                    firstHeaderRange.Collapse(WdCollapseDirection.wdCollapseEnd);
                                    if (myPaper.header.rightLastPageNum)
                                    {
                                        firstHeaderRange.Fields.Add(firstHeaderRange, WdFieldType.wdFieldPage);
                                        Paragraph lastName = firstHeaderRange.Paragraphs.Add();
                                        lastName.Range.Text = "\t\t" + myPaper.header.rightLastName + " ";
                                        lastName.Range.Font.Name = myPaper.references.titleFont;
                                        lastName.Range.Font.Size = myPaper.references.titleSize;
                                        firstHeaderRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                    }
                                    else if (myPaper.header.rightPageNum)
                                    {
                                        firstHeaderRange.Fields.Add(firstHeaderRange, WdFieldType.wdFieldPage);
                                        Paragraph spacer = firstHeaderRange.Paragraphs.Add();
                                        spacer.Range.Text = "\t\t";
                                        spacer.Range.Font.Name = myPaper.references.titleFont;
                                        spacer.Range.Font.Size = myPaper.references.titleSize;
                                        firstHeaderRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                    }
                                    else if (myPaper.header.rightOther)
                                    {
                                        Paragraph other = firstHeaderRange.Paragraphs.Add();
                                        other.Range.Text = "\t\t" + myPaper.header.rightOtherText;
                                        other.Range.Font.Name = myPaper.references.titleFont;
                                        other.Range.Font.Size = myPaper.references.titleSize;
                                        firstHeaderRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                    }
                                    else if (myPaper.header.rightTitle)
                                    {
                                        Paragraph other = firstHeaderRange.Paragraphs.Add();
                                        other.Range.Text = "\t\t" + myPaper.header.rightTitleText.ToUpper();
                                        other.Range.Font.Name = myPaper.references.titleFont;
                                        other.Range.Font.Size = myPaper.references.titleSize;
                                        firstHeaderRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                    }
                                    if (myPaper.header.leftLastPageNum)
                                    {
                                        firstHeaderRange.Fields.Add(firstHeaderRange, WdFieldType.wdFieldPage);
                                        Paragraph lastName = firstHeaderRange.Paragraphs.Add();
                                        lastName.Range.Text = "Running head: " + myPaper.header.leftLastName + " ";
                                        lastName.Range.Font.Name = myPaper.references.titleFont;
                                        lastName.Range.Font.Size = myPaper.references.titleSize;
                                        firstHeaderRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                    }
                                    else if (myPaper.header.leftPageNum)
                                    {
                                        firstHeaderRange.Fields.Add(firstHeaderRange, WdFieldType.wdFieldPage);
                                        Paragraph text = firstHeaderRange.Paragraphs.Add();
                                        text.Range.Text = "Running head: ";
                                        text.Range.Font.Name = myPaper.references.titleFont;
                                        text.Range.Font.Size = myPaper.references.titleSize;
                                        firstHeaderRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                    }
                                    else if (myPaper.header.leftOther)
                                    {
                                        Paragraph other = firstHeaderRange.Paragraphs.Add();
                                        other.Range.Text = "Running head: " + myPaper.header.leftOtherText;
                                        other.Range.Font.Name = myPaper.references.titleFont;
                                        other.Range.Font.Size = myPaper.references.titleSize;
                                        firstHeaderRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                    }
                                    else if (myPaper.header.leftTitle)
                                    {
                                        Paragraph other = firstHeaderRange.Paragraphs.Add();
                                        other.Range.Text = "Running head: " + myPaper.header.leftTitleText.ToUpper();
                                        other.Range.Font.Name = myPaper.references.titleFont;
                                        other.Range.Font.Size = myPaper.references.titleSize;
                                        firstHeaderRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                    }
                                    firstHeaderRange.Font.Name = myPaper.references.titleFont;
                                    firstHeaderRange.Font.Size = myPaper.references.titleSize;
                                }
                            }
                            if (myPaper.header.differentFirstPage && myPaper.header.moreDifferent)
                            {
                                document.PageSetup.DifferentFirstPageHeaderFooter = -1;
                                Range firstHeaderRange = section.Headers[WdHeaderFooterIndex.wdHeaderFooterFirstPage].Range;
                                firstHeaderRange.Collapse(WdCollapseDirection.wdCollapseEnd);
                                if (myPaper.header.firstRightLastPageNum)
                                {
                                    firstHeaderRange.Fields.Add(firstHeaderRange, WdFieldType.wdFieldPage);
                                    Paragraph lastName = firstHeaderRange.Paragraphs.Add();
                                    lastName.Range.Text = "\t\t" + myPaper.header.firstRightLastName + " ";
                                    lastName.Range.Font.Name = myPaper.references.titleFont;
                                    lastName.Range.Font.Size = myPaper.references.titleSize;
                                    firstHeaderRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                }
                                else if (myPaper.header.firstRightPageNum)
                                {
                                    firstHeaderRange.Fields.Add(firstHeaderRange, WdFieldType.wdFieldPage);
                                    Paragraph spacer = firstHeaderRange.Paragraphs.Add();
                                    spacer.Range.Text = "\t\t";
                                    spacer.Range.Font.Name = myPaper.references.titleFont;
                                    spacer.Range.Font.Size = myPaper.references.titleSize;
                                    firstHeaderRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                }
                                else if (myPaper.header.firstRightOther)
                                {
                                    Paragraph other = firstHeaderRange.Paragraphs.Add();
                                    other.Range.Text = "\t\t" + myPaper.header.firstRightOtherText;
                                    other.Range.Font.Name = myPaper.references.titleFont;
                                    other.Range.Font.Size = myPaper.references.titleSize;
                                    firstHeaderRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                }
                                else if (myPaper.header.firstRightTitle)
                                {
                                    Paragraph other = firstHeaderRange.Paragraphs.Add();
                                    other.Range.Text = "\t\t" + myPaper.header.firstRightTitleText;
                                    other.Range.Font.Name = myPaper.references.titleFont;
                                    other.Range.Font.Size = myPaper.references.titleSize;
                                    firstHeaderRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                }
                                if (myPaper.header.firstLeftLastPageNum)
                                {
                                    firstHeaderRange.Fields.Add(firstHeaderRange, WdFieldType.wdFieldPage);
                                    Paragraph lastName = firstHeaderRange.Paragraphs.Add();
                                    lastName.Range.Text = myPaper.header.firstLeftLastName + " ";
                                    lastName.Range.Font.Name = myPaper.references.titleFont;
                                    lastName.Range.Font.Size = myPaper.references.titleSize;
                                    firstHeaderRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                }
                                else if (myPaper.header.firstLeftPageNum)
                                {
                                    firstHeaderRange.Fields.Add(firstHeaderRange, WdFieldType.wdFieldPage);
                                    Paragraph lastName = firstHeaderRange.Paragraphs.Add();
                                    lastName.Range.Text = "";
                                    lastName.Range.Font.Name = myPaper.references.titleFont;
                                    lastName.Range.Font.Size = myPaper.references.titleSize;
                                    firstHeaderRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                }
                                else if (myPaper.header.firstLeftOther)
                                {
                                    Paragraph other = firstHeaderRange.Paragraphs.Add();
                                    other.Range.Text = myPaper.header.firstLeftOtherText;
                                    other.Range.Font.Name = myPaper.references.titleFont;
                                    other.Range.Font.Size = myPaper.references.titleSize;
                                    firstHeaderRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                }
                                else if (myPaper.header.firstLeftTitle)
                                {
                                    Paragraph other = firstHeaderRange.Paragraphs.Add();
                                    other.Range.Text = myPaper.header.firstLeftTitleText.ToUpper();
                                    other.Range.Font.Name = myPaper.references.titleFont;
                                    other.Range.Font.Size = myPaper.references.titleSize;
                                    firstHeaderRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                }
                                firstHeaderRange.Font.Name = myPaper.references.titleFont;
                                firstHeaderRange.Font.Size = myPaper.references.titleSize;
                            }

                            Range headerRange = section.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                            headerRange.Collapse(WdCollapseDirection.wdCollapseEnd);
                            if (myPaper.header.rightLastPageNum)
                            {
                                headerRange.Fields.Add(headerRange, WdFieldType.wdFieldPage);
                                Paragraph lastName = headerRange.Paragraphs.Add();
                                lastName.Range.Text = "\t\t" + myPaper.header.rightLastName + " ";
                                lastName.Range.Font.Name = myPaper.references.titleFont;
                                lastName.Range.Font.Size = myPaper.references.titleSize;
                                headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                            }
                            else if (myPaper.header.rightPageNum)
                            {
                                headerRange.Fields.Add(headerRange, WdFieldType.wdFieldPage);
                                Paragraph spacer = headerRange.Paragraphs.Add();
                                spacer.Range.Text = "\t\t";
                                spacer.Range.Font.Name = myPaper.references.titleFont;
                                spacer.Range.Font.Size = myPaper.references.titleSize;
                                headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                            }
                            else if (myPaper.header.rightOther)
                            {
                                Paragraph other = headerRange.Paragraphs.Add();
                                other.Range.Text = "\t\t" + myPaper.header.rightOtherText;
                                other.Range.Font.Name = myPaper.references.titleFont;
                                other.Range.Font.Size = myPaper.references.titleSize;
                                headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                            }
                            else if (myPaper.header.rightTitle)
                            {
                                Paragraph other = headerRange.Paragraphs.Add();
                                other.Range.Text = "\t\t" + myPaper.header.rightTitleText.ToUpper();
                                other.Range.Font.Name = myPaper.references.titleFont;
                                other.Range.Font.Size = myPaper.references.titleSize;
                                headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                            }
                            if (myPaper.header.leftLastPageNum)
                            {
                                headerRange.Fields.Add(headerRange, WdFieldType.wdFieldPage);
                                Paragraph lastName = headerRange.Paragraphs.Add();
                                lastName.Range.Text = myPaper.header.leftLastName + " ";
                                lastName.Range.Font.Name = myPaper.references.titleFont;
                                lastName.Range.Font.Size = myPaper.references.titleSize;
                                headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                            }
                            else if (myPaper.header.leftPageNum)
                            {
                                headerRange.Fields.Add(headerRange, WdFieldType.wdFieldPage);
                                Paragraph lastName = headerRange.Paragraphs.Add();
                                lastName.Range.Text = "";
                                lastName.Range.Font.Name = myPaper.references.titleFont;
                                lastName.Range.Font.Size = myPaper.references.titleSize;
                                headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                            }
                            else if (myPaper.header.leftOther)
                            {
                                Paragraph other = headerRange.Paragraphs.Add();
                                other.Range.Text = myPaper.header.leftOtherText;
                                other.Range.Font.Name = myPaper.references.titleFont;
                                other.Range.Font.Size = myPaper.references.titleSize;
                                headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                            }
                            else if (myPaper.header.leftTitle)
                            {
                                Paragraph other = headerRange.Paragraphs.Add();
                                other.Range.Text = myPaper.header.leftTitleText.ToUpper();
                                other.Range.Font.Name = myPaper.references.titleFont;
                                other.Range.Font.Size = myPaper.references.titleSize;
                                headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                            }
                            headerRange.Font.Name = myPaper.references.titleFont;
                            headerRange.Font.Size = myPaper.references.titleSize;


                            //Paragraph pageNum = headerRange.Paragraphs.Add();



                            //headerRange.Fields.Add(headerRange, WdFieldType.wdFieldPage);
                            //headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                            //headerRange.Font.Size = 12;
                            //string headerText = constructHeader();
                            //headerRange.Text = headerText;

                        }
                    }

                    //TODO Make this dependent upon the setting
                    object beginDoc = document.Content.Start;
                    object endDoc = document.Content.End;

                    document.Range(ref beginDoc, ref endDoc).Paragraphs.Space2();
                    document.Range(ref beginDoc, ref endDoc).Paragraphs.SpaceAfter = 0;
                    //document.Range(ref beginDoc, ref endDoc).Font.Size = 12;

                    object filename = fileName;
                    document.SaveAs2(ref filename);
                    document.Close(ref missing, ref missing, ref missing);
                    document = null;
                    wordApp.Quit(ref missing, ref missing, ref missing);
                    wordApp = null;
                    MessageBox.Show("Document created successfully!");
                    Process.Start("WINWORD.EXE", (string)filename);                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Enter the name you would like to use to save the formatted paper.\n");
            }
        }

        private void writeButton_Click(object sender, EventArgs e)
        {
            if (myPaper.titleOfPaper != null && myPaper.titleOfPaper.Length > 0)
            {
                saveFile.FileName = myPaper.titleOfPaper + ".docx";
            }
            else
            {
                saveFile.FileName = "newProject.docx";
            }
            writeFile.ShowDialog();            
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

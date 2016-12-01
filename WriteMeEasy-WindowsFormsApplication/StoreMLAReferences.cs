using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WriteMeEasy_WindowsFormsApplication
{
    public partial class CitationAdder : Form
    {
        private void addReferenceButton_Click(object sender, EventArgs e)
        {
            Reference reference = new Reference();
            bool error = false;
            string errorMessage = "";
            if (book.Checked)
            {
                reference.type = "book";
                int numAuthors = Convert.ToInt32(sourceInfoGroupBox.Tag.ToString().Split(',')[0]);

                for (int i = 0; i < numAuthors; i++)
                {
                    int index = i + 1;
                    Author author = new Author();
                    TextBox firstName = (TextBox)Controls.Find("authorFirstEnter" + index, true)[0];
                    TextBox middleName = (TextBox)Controls.Find("authorMiddleEnter" + index, true)[0];
                    TextBox lastName = (TextBox)Controls.Find("authorLastEnter" + index, true)[0];
                    author.firstName = firstName.Text;
                    author.middleName = middleName.Text;
                    author.lastName = lastName.Text;
                    if (author.firstName.Length > 0 || author.middleName.Length > 0 || author.lastName.Length > 0)
                    {
                        reference.authors.Add(author);
                    }
                }
                TextBox bookTitle = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = bookTitle.Text;
                TextBox publisher = (TextBox)Controls.Find("publisherEnter", true)[0];
                reference.publisher = publisher.Text;
                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox edition = (TextBox)Controls.Find("editionEnter", true)[0];
                reference.edition = edition.Text;

                if (reference.authors.Count > 0)
                {
                    int validAuthors = reference.authors.Count - 1;
                    if (reference.authors[validAuthors].lastName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].lastName + ", ";
                    }
                    if (reference.authors[validAuthors].firstName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].firstName;                        
                    }
                    if (reference.authors[validAuthors].lastName.Length < 1 || reference.authors[validAuthors].firstName.Length < 1)
                    {
                        error = true;
                        errorMessage += "Enter the first and last name of the author\n";
                    }
                    else
                    {
                        if (reference.authors.Count == 2)
                        {
                            reference.formattedReference += ", and ";
                            if (reference.authors[0].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].firstName + " ";
                            }
                            if (reference.authors[0].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].lastName;
                            }
                            if (reference.authors[0].lastName.Length < 1 || reference.authors[0].firstName.Length < 1)
                            {
                                error = true;
                                errorMessage += "Enter the first and last name of the authors\n";
                            }
                        }
                        else if (reference.authors.Count > 2)
                        {
                            reference.formattedReference += ", et al";
                        }
                        reference.formattedReference += ". ";                        
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        reference.formattedReference += reference.title + ". ";
                        reference.formattedReference += '\a';
                        if (reference.edition.Length > 0)
                        {
                            reference.formattedReference += reference.edition + " ed., ";
                        }
                        if (reference.publisher.Length > 0)
                        {
                            reference.formattedReference += reference.publisher + ", ";
                            if (reference.publicationDate.Length > 0)
                            {
                                reference.formattedReference += reference.publicationDate + ".";
                            }
                            else
                            {
                                reference.formattedReference += "n.d.";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the publisher\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the title of the book\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the author\n";
                }
            }
            else if (shortStory.Checked)
            {
                reference.type = "shortStory";
                int numAuthors = Convert.ToInt32(sourceInfoGroupBox.Tag.ToString().Split(',')[0]);

                for (int i = 0; i < numAuthors; i++)
                {
                    int index = i + 1;
                    Author author = new Author();
                    TextBox firstName = (TextBox)Controls.Find("authorFirstEnter" + index, true)[0];
                    TextBox middleName = (TextBox)Controls.Find("authorMiddleEnter" + index, true)[0];
                    TextBox lastName = (TextBox)Controls.Find("authorLastEnter" + index, true)[0];
                    author.firstName = firstName.Text;
                    author.middleName = middleName.Text;
                    author.lastName = lastName.Text;
                    if (author.firstName.Length > 0 || author.middleName.Length > 0 || author.lastName.Length > 0)
                    {
                        reference.authors.Add(author);
                    }
                }
                TextBox bookTitle = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = bookTitle.Text;
                TextBox collection = (TextBox)Controls.Find("collectionTitleEnter", true)[0];
                reference.source = collection.Text;
                Author editor = new Author();
                TextBox editFirstName = (TextBox)Controls.Find("editorFirstEnter", true)[0];
                TextBox editMiddleName = (TextBox)Controls.Find("editorMiddleEnter", true)[0];
                TextBox editLastName = (TextBox)Controls.Find("editorLastEnter", true)[0];
                editor.firstName = editFirstName.Text;
                editor.middleName = editMiddleName.Text;
                editor.lastName = editLastName.Text;
                if (editor.firstName.Length > 0 && editor.lastName.Length > 0)
                {
                    reference.editor = editor;
                }
                TextBox publisher = (TextBox)Controls.Find("publisherEnter", true)[0];
                reference.publisher = publisher.Text;
                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox pageStart = (TextBox)Controls.Find("pageStartEnter", true)[0];
                reference.startPage = pageStart.Text;
                TextBox pageEnd = (TextBox)Controls.Find("pageEndEnter", true)[0];
                reference.endPage = pageEnd.Text;

                if (reference.authors.Count > 0)
                {
                    int validAuthors = reference.authors.Count - 1;
                    if (reference.authors[validAuthors].lastName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].lastName + ", ";
                    }
                    if (reference.authors[validAuthors].firstName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].firstName;
                    }
                    if (reference.authors[validAuthors].lastName.Length < 1 || reference.authors[validAuthors].firstName.Length < 1)
                    {
                        error = true;
                        errorMessage += "Enter the first and last name of the author\n";
                    }
                    else
                    {
                        if (reference.authors.Count == 2)
                        {
                            reference.formattedReference += ", and ";
                            if (reference.authors[0].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].firstName + " ";
                            }
                            if (reference.authors[0].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].lastName;
                            }
                            if (reference.authors[0].lastName.Length < 1 || reference.authors[0].firstName.Length < 1)
                            {
                                error = true;
                                errorMessage += "Enter the first and last name of the authors\n";
                            }
                        }
                        else if (reference.authors.Count > 2)
                        {
                            reference.formattedReference += ", et al";
                        }
                        reference.formattedReference += ". ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += "\"" + reference.title + ".\" ";
                        if (reference.source.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            reference.formattedReference += reference.source;
                            reference.formattedReference += '\a';
                            if (editor.firstName.Length > 0 && editor.lastName.Length > 0)
                            {
                                reference.formattedReference += ", edited by " + reference.editor.firstName + " " + reference.editor.lastName + ", ";
                            }
                            else
                            {
                                reference.formattedReference += ". ";
                            }
                            if (reference.publisher.Length > 0)
                            {
                                reference.formattedReference += reference.publisher + ", ";
                                if (reference.publicationDate.Length > 0)
                                {
                                    reference.formattedReference += reference.publicationDate;
                                    if (reference.startPage.Length > 0)
                                    {
                                        reference.formattedReference += ", ";
                                    }
                                    else
                                    {
                                        reference.formattedReference += ".";
                                    }
                                }
                                else
                                {
                                    reference.formattedReference += "n.d.";
                                    if (reference.startPage.Length > 0)
                                    {
                                        reference.formattedReference += ", ";
                                    }
                                }
                                if (reference.startPage.Length < 1 && reference.endPage.Length > 0)
                                {
                                    error = true;
                                    errorMessage += "Enter the start page\n";
                                }
                                if ((reference.startPage.Length > 0 && reference.endPage.Length < 1) ||
                                    (reference.startPage.Equals(reference.endPage) && reference.startPage.Length > 0))
                                {
                                    reference.formattedReference += "p. " + reference.startPage + ".";
                                }
                                else if (reference.startPage.Length > 0 && reference.endPage.Length > 0)
                                {
                                    reference.formattedReference += "pp. " + reference.startPage + "-" + reference.endPage + ".";
                                }
                            }
                            else
                            {
                                error = true;
                                errorMessage += "Enter the publisher\n";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the source of the short story\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the title of the short story\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the author\n";
                }
            }
            else if (editorial.Checked)
            {
                reference.type = "editorial";
                int numAuthors = Convert.ToInt32(sourceInfoGroupBox.Tag.ToString().Split(',')[0]);

                for (int i = 0; i < numAuthors; i++)
                {
                    int index = i + 1;
                    Author author = new Author();
                    TextBox firstName = (TextBox)Controls.Find("authorFirstEnter" + index, true)[0];
                    TextBox middleName = (TextBox)Controls.Find("authorMiddleEnter" + index, true)[0];
                    TextBox lastName = (TextBox)Controls.Find("authorLastEnter" + index, true)[0];
                    author.firstName = firstName.Text;
                    author.middleName = middleName.Text;
                    author.lastName = lastName.Text;
                    if (author.firstName.Length > 0 || author.middleName.Length > 0 || author.lastName.Length > 0)
                    {
                        reference.authors.Add(author);
                    }
                }
                TextBox bookTitle = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = bookTitle.Text;
                TextBox source = (TextBox)Controls.Find("sourceEnter", true)[0];
                reference.source = source.Text;
                TextBox publishDate = (TextBox)Controls.Find("publicationDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox pageStart = (TextBox)Controls.Find("pageStartEnter", true)[0];
                reference.startPage = pageStart.Text;
                TextBox pageEnd = (TextBox)Controls.Find("pageEndEnter", true)[0];
                reference.endPage = pageEnd.Text;
                if (reference.authors.Count > 0)
                {
                    int validAuthors = reference.authors.Count - 1;
                    if (reference.authors[validAuthors].lastName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].lastName + ", ";
                    }
                    if (reference.authors[validAuthors].firstName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].firstName;
                    }
                    if (reference.authors[validAuthors].lastName.Length < 1 || reference.authors[validAuthors].firstName.Length < 1)
                    {
                        error = true;
                        errorMessage += "Enter the first and last name of the author\n";
                    }
                    else
                    {
                        if (reference.authors.Count == 2)
                        {
                            reference.formattedReference += ", and ";
                            if (reference.authors[0].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].firstName + " ";
                            }
                            if (reference.authors[0].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].lastName;
                            }
                            if (reference.authors[0].lastName.Length < 1 || reference.authors[0].firstName.Length < 1)
                            {
                                error = true;
                                errorMessage += "Enter the first and last name of the authors\n";
                            }
                        }
                        else if (reference.authors.Count > 2)
                        {
                            reference.formattedReference += ", et al";
                        }
                        reference.formattedReference += ". ";
                    }
                }
                if (reference.title.Length > 0)
                {
                    reference.formattedReference += "\"" + reference.title + ".\" Editorial. ";
                    if (reference.source.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        reference.formattedReference += reference.source + ", ";
                        reference.formattedReference += '\a';
                        if (reference.publicationDate.Length > 0)
                        {
                            reference.formattedReference += reference.publicationDate;
                            if (reference.startPage.Length > 0)
                            {
                                reference.formattedReference += ", ";
                            }
                            else
                            {
                                reference.formattedReference += ".";
                            }
                        }
                        else
                        {
                            reference.formattedReference += "n.d.";
                            if (reference.startPage.Length > 0)
                            {
                                reference.formattedReference += ", ";
                            }
                        }
                        if (reference.startPage.Length < 1 && reference.endPage.Length > 0)
                        {
                            error = true;
                            errorMessage += "Enter the start page\n";
                        }
                        if ((reference.startPage.Length > 0 && reference.endPage.Length < 1) ||
                            (reference.startPage.Equals(reference.endPage) && reference.startPage.Length > 0))
                        {
                            reference.formattedReference += "p. " + reference.startPage + ".";
                        }
                        else if (reference.startPage.Length > 0 && reference.endPage.Length > 0)
                        {
                            reference.formattedReference += "pp. " + reference.startPage + "-" + reference.endPage + ".";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the source that printed the editorial\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the title of the editorial\n";
                }
            }
            else if (encyclopedia.Checked)
            {
                TextBox section = (TextBox)Controls.Find("sectionNameEnter", true)[0];
                reference.section = section.Text;
                TextBox title = (TextBox)Controls.Find("bookNameEnter", true)[0];
                reference.title = title.Text;
                TextBox publishDate = (TextBox)Controls.Find("publicationDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox edition = (TextBox)Controls.Find("editionEnter", true)[0];
                reference.edition = edition.Text;

                if (reference.section.Length > 0)
                {
                    reference.formattedReference += "\"" + reference.section + ".\" ";
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        reference.formattedReference += reference.title + ". ";
                        reference.formattedReference += '\a';
                        if (reference.edition.Length > 0)
                        {
                            reference.formattedReference += reference.edition + " ed., ";
                        }
                        if (reference.publicationDate.Length > 0)
                        {
                            reference.formattedReference += reference.publicationDate + ".";
                        }
                        else
                        {
                            reference.formattedReference += "n.d.";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the name of the dictionary or encyclopedia\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the word referenced\n";
                }
            }
            else if (translated.Checked)
            {
                int numAuthors = Convert.ToInt32(sourceInfoGroupBox.Tag.ToString().Split(',')[0]);
                int numTranslators = Convert.ToInt32(sourceInfoGroupBox.Tag.ToString().Split(',')[2]);

                for (int i = 0; i < numAuthors; i++)
                {
                    int index = i + 1;
                    Author author = new Author();
                    TextBox firstName = (TextBox)Controls.Find("authorFirstEnter" + index, true)[0];
                    TextBox middleName = (TextBox)Controls.Find("authorMiddleEnter" + index, true)[0];
                    TextBox lastName = (TextBox)Controls.Find("authorLastEnter" + index, true)[0];
                    author.firstName = firstName.Text;
                    author.middleName = middleName.Text;
                    author.lastName = lastName.Text;
                    if (author.firstName.Length > 0 || author.middleName.Length > 0 || author.lastName.Length > 0)
                    {
                        reference.authors.Add(author);
                    }
                }
                for (int i = 0; i < numTranslators; i++)
                {
                    int index = i + 1;
                    Author author = new Author();
                    TextBox firstName = (TextBox)Controls.Find("translatorFirstEnter" + index, true)[0];
                    TextBox middleName = (TextBox)Controls.Find("translatorMiddleEnter" + index, true)[0];
                    TextBox lastName = (TextBox)Controls.Find("translatorLastEnter" + index, true)[0];
                    author.firstName = firstName.Text;
                    author.middleName = middleName.Text;
                    author.lastName = lastName.Text;
                    if (author.firstName.Length > 0 || author.middleName.Length > 0 || author.lastName.Length > 0)
                    {
                        reference.translators.Add(author);
                    }
                }
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox publisher = (TextBox)Controls.Find("publisherEnter", true)[0];
                reference.publisher = publisher.Text;
                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                if (reference.authors.Count > 0)
                {
                    int validAuthors = reference.authors.Count - 1;
                    if (reference.authors[validAuthors].lastName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].lastName + ", ";
                    }
                    if (reference.authors[validAuthors].firstName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].firstName;
                    }
                    if (reference.authors[validAuthors].lastName.Length < 1 || reference.authors[validAuthors].firstName.Length < 1)
                    {
                        error = true;
                        errorMessage += "Enter the first and last name of the author\n";
                    }
                    else
                    {
                        if (reference.authors.Count == 2)
                        {
                            reference.formattedReference += ", and ";
                            if (reference.authors[0].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].firstName + " ";
                            }
                            if (reference.authors[0].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].lastName;
                            }
                            if (reference.authors[0].lastName.Length < 1 || reference.authors[0].firstName.Length < 1)
                            {
                                error = true;
                                errorMessage += "Enter the first and last name of the authors\n";
                            }
                        }
                        else if (reference.authors.Count > 2)
                        {
                            reference.formattedReference += ", et al";
                        }
                        reference.formattedReference += ". ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        reference.formattedReference += reference.title + ". ";
                        reference.formattedReference += '\a';
                        if (reference.translators.Count > 0)
                        {
                            reference.formattedReference += "Translated by ";
                            int validTranslators = reference.translators.Count - 1;
                            if (reference.translators[validTranslators].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.translators[validTranslators].firstName + " ";
                            }
                            if (reference.translators[validTranslators].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.translators[validTranslators].lastName;
                            }
                            if (reference.translators[validTranslators].lastName.Length < 1 || reference.translators[validTranslators].firstName.Length < 1)
                            {
                                error = true;
                                errorMessage += "Enter the first and last name of the author\n";
                            }
                            if (reference.translators.Count == 2)
                            {
                                reference.formattedReference += ", and ";
                                if (reference.authors[0].firstName.Length > 0)
                                {
                                    reference.formattedReference += reference.translators[0].firstName + " ";
                                }
                                if (reference.translators[0].lastName.Length > 0)
                                {
                                    reference.formattedReference += reference.translators[0].lastName;
                                }
                                if (reference.translators[0].lastName.Length < 1 || reference.translators[0].firstName.Length < 1)
                                {
                                    error = true;
                                    errorMessage += "Enter the first and last name of the author\n";
                                }
                            }
                            else if (reference.translators.Count > 2)
                            {
                                reference.formattedReference += ", et al";
                            }
                            reference.formattedReference += ", ";
                            if (reference.publisher.Length > 0)
                            {
                                reference.formattedReference += reference.publisher + ", ";
                            }
                            if (reference.publicationDate.Length > 0)
                            {
                                reference.formattedReference += reference.publicationDate + ".";
                            }
                            else
                            {
                                reference.formattedReference += "n.d.";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the name of the translator\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the name of the book\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the name of the original author\n";
                }
            }
            else if (magazine.Checked)
            {
                int numAuthors = Convert.ToInt32(sourceInfoGroupBox.Tag.ToString().Split(',')[0]);

                for (int i = 0; i < numAuthors; i++)
                {
                    int index = i + 1;
                    Author author = new Author();
                    TextBox firstName = (TextBox)Controls.Find("authorFirstEnter" + index, true)[0];
                    TextBox middleName = (TextBox)Controls.Find("authorMiddleEnter" + index, true)[0];
                    TextBox lastName = (TextBox)Controls.Find("authorLastEnter" + index, true)[0];
                    author.firstName = firstName.Text;
                    author.middleName = middleName.Text;
                    author.lastName = lastName.Text;
                    if (author.firstName.Length > 0 || author.middleName.Length > 0 || author.lastName.Length > 0)
                    {
                        reference.authors.Add(author);
                    }
                }
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox magazine = (TextBox)Controls.Find("magazineNameEnter", true)[0];
                reference.source = magazine.Text;
                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox pageStart = (TextBox)Controls.Find("pageStartEnter", true)[0];
                reference.startPage = pageStart.Text;
                TextBox pageEnd = (TextBox)Controls.Find("pageEndEnter", true)[0];
                reference.endPage = pageEnd.Text;

                if (reference.authors.Count > 0)
                {
                    int validAuthors = reference.authors.Count - 1;
                    if (reference.authors[validAuthors].lastName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].lastName + ", ";
                    }
                    if (reference.authors[validAuthors].firstName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].firstName;
                    }
                    if (reference.authors[validAuthors].lastName.Length < 1 || reference.authors[validAuthors].firstName.Length < 1)
                    {
                        error = true;
                        errorMessage += "Enter the first and last name of the author\n";
                    }
                    else
                    {
                        if (reference.authors.Count == 2)
                        {
                            reference.formattedReference += ", and ";
                            if (reference.authors[0].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].firstName + " ";
                            }
                            if (reference.authors[0].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].lastName;
                            }
                            if (reference.authors[0].lastName.Length < 1 || reference.authors[0].firstName.Length < 1)
                            {
                                error = true;
                                errorMessage += "Enter the first and last name of the authors\n";
                            }
                        }
                        else if (reference.authors.Count > 2)
                        {
                            reference.formattedReference += ", et al";
                        }
                        reference.formattedReference += ". ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += "\"" + reference.title + ".\" ";
                        if (reference.source.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            reference.formattedReference += reference.source + ", ";
                            reference.formattedReference += '\a';
                            if (reference.publicationDate.Length > 0)
                            {
                                reference.formattedReference += reference.publicationDate;
                                if (reference.startPage.Length > 0)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += ".";
                                }
                            }
                            else
                            {
                                reference.formattedReference += "n.d.";
                                if (reference.startPage.Length > 0)
                                {
                                    reference.formattedReference += ", ";
                                }
                            }
                            if (reference.startPage.Length < 1 && reference.endPage.Length > 0)
                            {
                                error = true;
                                errorMessage += "Enter the start page\n";
                            }
                            if ((reference.startPage.Length > 0 && reference.endPage.Length < 1) ||
                                (reference.startPage.Equals(reference.endPage) && reference.startPage.Length > 0))
                            {
                                reference.formattedReference += "p. " + reference.startPage + ".";
                            }
                            else if (reference.startPage.Length > 0 && reference.endPage.Length > 0)
                            {
                                reference.formattedReference += "pp. " + reference.startPage + "-" + reference.endPage + ".";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the name of the magazine\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the title of the article\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the name of the author\n";
                }
            }
            else if (newspaper.Checked)
            {
                int numAuthors = Convert.ToInt32(sourceInfoGroupBox.Tag.ToString().Split(',')[0]);

                for (int i = 0; i < numAuthors; i++)
                {
                    int index = i + 1;
                    Author author = new Author();
                    TextBox firstName = (TextBox)Controls.Find("authorFirstEnter" + index, true)[0];
                    TextBox middleName = (TextBox)Controls.Find("authorMiddleEnter" + index, true)[0];
                    TextBox lastName = (TextBox)Controls.Find("authorLastEnter" + index, true)[0];
                    author.firstName = firstName.Text;
                    author.middleName = middleName.Text;
                    author.lastName = lastName.Text;
                    if (author.firstName.Length > 0 || author.middleName.Length > 0 || author.lastName.Length > 0)
                    {
                        reference.authors.Add(author);
                    }
                }
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox newspaper = (TextBox)Controls.Find("newspaperNameEnter", true)[0];
                reference.source = newspaper.Text;
                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox pageStart = (TextBox)Controls.Find("pageStartEnter", true)[0];
                reference.startPage = pageStart.Text;
                TextBox pageEnd = (TextBox)Controls.Find("pageEndEnter", true)[0];
                reference.endPage = pageEnd.Text;

                if (reference.authors.Count > 0)
                {
                    int validAuthors = reference.authors.Count - 1;
                    if (reference.authors[validAuthors].lastName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].lastName + ", ";
                    }
                    if (reference.authors[validAuthors].firstName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].firstName;
                    }
                    if (reference.authors[validAuthors].lastName.Length < 1 || reference.authors[validAuthors].firstName.Length < 1)
                    {
                        error = true;
                        errorMessage += "Enter the first and last name of the author\n";
                    }
                    else
                    {
                        if (reference.authors.Count == 2)
                        {
                            reference.formattedReference += ", and ";
                            if (reference.authors[0].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].firstName + " ";
                            }
                            if (reference.authors[0].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].lastName;
                            }
                            if (reference.authors[0].lastName.Length < 1 || reference.authors[0].firstName.Length < 1)
                            {
                                error = true;
                                errorMessage += "Enter the first and last name of the authors\n";
                            }
                        }
                        else if (reference.authors.Count > 2)
                        {
                            reference.formattedReference += ", et al";
                        }
                        reference.formattedReference += ". ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += "\"" + reference.title + ".\" ";
                        if (reference.source.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            reference.formattedReference += reference.source + ", ";
                            reference.formattedReference += '\a';
                            if (reference.publicationDate.Length > 0)
                            {
                                reference.formattedReference += reference.publicationDate;
                                if (reference.startPage.Length > 0)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += ".";
                                }
                            }
                            else
                            {
                                reference.formattedReference += "n.d.";
                                if (reference.startPage.Length > 0)
                                {
                                    reference.formattedReference += ", ";
                                }
                            }
                            if (reference.startPage.Length < 1 && reference.endPage.Length > 0)
                            {
                                error = true;
                                errorMessage += "Enter the start page\n";
                            }
                            else if ((reference.startPage.Length > 0 && reference.endPage.Length < 1) ||
                                (reference.startPage.Equals(reference.endPage) && reference.startPage.Length > 0))
                            {
                                reference.formattedReference += "p. " + reference.startPage + ".";
                            }
                            else if (reference.startPage.Length > 0 && reference.endPage.Length > 0)
                            {
                                reference.formattedReference += "pp. " + reference.startPage + "-" + reference.endPage + ".";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the name of the magazine\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the title of the article\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the name of the author\n";
                }
            }
            else if (journal.Checked)
            {
                int numAuthors = Convert.ToInt32(sourceInfoGroupBox.Tag.ToString().Split(',')[0]);

                for (int i = 0; i < numAuthors; i++)
                {
                    int index = i + 1;
                    Author author = new Author();
                    TextBox firstName = (TextBox)Controls.Find("authorFirstEnter" + index, true)[0];
                    TextBox middleName = (TextBox)Controls.Find("authorMiddleEnter" + index, true)[0];
                    TextBox lastName = (TextBox)Controls.Find("authorLastEnter" + index, true)[0];
                    author.firstName = firstName.Text;
                    author.middleName = middleName.Text;
                    author.lastName = lastName.Text;
                    if (author.firstName.Length > 0 || author.middleName.Length > 0 || author.lastName.Length > 0)
                    {
                        reference.authors.Add(author);
                    }
                }
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox journal = (TextBox)Controls.Find("journalNameEnter", true)[0];
                reference.source = journal.Text;
                TextBox volume = (TextBox)Controls.Find("volumeNumberEnter", true)[0];
                reference.volume = volume.Text;
                TextBox issue = (TextBox)Controls.Find("issueNumberEnter", true)[0];
                reference.issue = issue.Text;
                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox pageStart = (TextBox)Controls.Find("pageStartEnter", true)[0];
                reference.startPage = pageStart.Text;
                TextBox pageEnd = (TextBox)Controls.Find("pageEndEnter", true)[0];
                reference.endPage = pageEnd.Text;

                if (reference.authors.Count > 0)
                {
                    int validAuthors = reference.authors.Count - 1;
                    if (reference.authors[validAuthors].lastName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].lastName + ", ";
                    }
                    if (reference.authors[validAuthors].firstName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].firstName;
                    }
                    if (reference.authors[validAuthors].lastName.Length < 1 || reference.authors[validAuthors].firstName.Length < 1)
                    {
                        error = true;
                        errorMessage += "Enter the first and last name of the author\n";
                    }
                    else
                    {
                        if (reference.authors.Count == 2)
                        {
                            reference.formattedReference += ", and ";
                            if (reference.authors[0].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].firstName + " ";
                            }
                            if (reference.authors[0].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].lastName;
                            }
                            if (reference.authors[0].lastName.Length < 1 || reference.authors[0].firstName.Length < 1)
                            {
                                error = true;
                                errorMessage += "Enter the first and last name of the authors\n";
                            }
                        }
                        else if (reference.authors.Count > 2)
                        {
                            reference.formattedReference += ", et al";
                        }
                        reference.formattedReference += ". ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += "\"" + reference.title + ".\" ";
                        if (reference.source.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            reference.formattedReference += reference.source + ", ";
                            reference.formattedReference += '\a';
                            if (reference.volume.Length > 0)
                            {
                                reference.formattedReference += "vol. " + reference.volume + ", ";
                            }
                            if (reference.issue.Length > 0)
                            {
                                reference.formattedReference += "no. " + reference.issue + ", ";
                            }
                            if (reference.publicationDate.Length > 0)
                            {
                                reference.formattedReference += reference.publicationDate;
                                if (reference.startPage.Length > 0)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += ".";
                                }
                            }
                            else
                            {
                                reference.formattedReference += "n.d.";
                                if (reference.startPage.Length > 0)
                                {
                                    reference.formattedReference += ", ";
                                }
                            }
                            if (reference.startPage.Length < 1 && reference.endPage.Length > 0)
                            {
                                error = true;
                                errorMessage += "Enter the start page\n";
                            }
                            if ((reference.startPage.Length > 0 && reference.endPage.Length < 1) ||
                                (reference.startPage.Equals(reference.endPage) && reference.startPage.Length > 0))
                            {
                                reference.formattedReference += "p. " + reference.startPage + ".";
                            }
                            else if (reference.startPage.Length > 0 && reference.endPage.Length > 0)
                            {
                                reference.formattedReference += "pp. " + reference.startPage + "-" + reference.endPage + ".";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the name of the journal\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the title of the article\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the name of the author\n";
                }
            }
            else if (onlineOnlyJournal.Checked)
            {
                int numAuthors = Convert.ToInt32(sourceInfoGroupBox.Tag.ToString().Split(',')[0]);

                for (int i = 0; i < numAuthors; i++)
                {
                    int index = i + 1;
                    Author author = new Author();
                    TextBox firstName = (TextBox)Controls.Find("authorFirstEnter" + index, true)[0];
                    TextBox middleName = (TextBox)Controls.Find("authorMiddleEnter" + index, true)[0];
                    TextBox lastName = (TextBox)Controls.Find("authorLastEnter" + index, true)[0];
                    author.firstName = firstName.Text;
                    author.middleName = middleName.Text;
                    author.lastName = lastName.Text;
                    if (author.firstName.Length > 0 || author.middleName.Length > 0 || author.lastName.Length > 0)
                    {
                        reference.authors.Add(author);
                    }
                }
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox journal = (TextBox)Controls.Find("journalNameEnter", true)[0];
                reference.source = journal.Text;
                TextBox volume = (TextBox)Controls.Find("volumeNumberEnter", true)[0];
                reference.volume = volume.Text;
                TextBox issue = (TextBox)Controls.Find("issueNumberEnter", true)[0];
                reference.issue = issue.Text;
                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox retrievedFrom = (TextBox)Controls.Find("retrievedFromEnter", true)[0];
                reference.retrievedFrom = retrievedFrom.Text;
                TextBox accessedOn = (TextBox)Controls.Find("accessedEnter", true)[0];
                reference.accessedOn = accessedOn.Text;

                if (reference.authors.Count > 0)
                {
                    int validAuthors = reference.authors.Count - 1;
                    if (reference.authors[validAuthors].lastName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].lastName + ", ";
                    }
                    if (reference.authors[validAuthors].firstName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].firstName;
                    }
                    if (reference.authors[validAuthors].lastName.Length < 1 || reference.authors[validAuthors].firstName.Length < 1)
                    {
                        error = true;
                        errorMessage += "Enter the first and last name of the author\n";
                    }
                    else
                    {
                        if (reference.authors.Count == 2)
                        {
                            reference.formattedReference += ", and ";
                            if (reference.authors[0].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].firstName + " ";
                            }
                            if (reference.authors[0].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].lastName;
                            }
                            if (reference.authors[0].lastName.Length < 1 || reference.authors[0].firstName.Length < 1)
                            {
                                error = true;
                                errorMessage += "Enter the first and last name of the authors\n";
                            }
                        }
                        else if (reference.authors.Count > 2)
                        {
                            reference.formattedReference += ", et al";
                        }
                        reference.formattedReference += ". ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += "\"" + reference.title + ".\" ";
                        if (reference.source.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            reference.formattedReference += reference.source + ", ";
                            reference.formattedReference += '\a';
                            if (reference.volume.Length > 0)
                            {
                                reference.formattedReference += "vol. " + reference.volume + ", ";
                            }
                            if (reference.issue.Length > 0)
                            {
                                reference.formattedReference += "no. " + reference.issue + ", ";
                            }
                            if (reference.publicationDate.Length > 0)
                            {
                                reference.formattedReference += reference.publicationDate + ", ";
                            }
                            else
                            {
                                reference.formattedReference += "n.d., ";
                            }
                            if (reference.retrievedFrom.Length > 0)
                            {
                                reference.formattedReference += reference.retrievedFrom + ". ";
                                if (reference.accessedOn.Length > 0)
                                {
                                    reference.formattedReference += "Accessed " + reference.accessedOn + ".";
                                }
                                else
                                {
                                    error = true;
                                    errorMessage += "Enter the date the article was accessed\n";
                                }
                            }
                            else
                            {
                                error = true;
                                errorMessage += "Enter the URL where the article was viewed\n";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the name of the journal\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the title of the article\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the name of the author\n";
                }
            }
            else if (onlinePeriodical.Checked)
            {
                int numAuthors = Convert.ToInt32(sourceInfoGroupBox.Tag.ToString().Split(',')[0]);

                for (int i = 0; i < numAuthors; i++)
                {
                    int index = i + 1;
                    Author author = new Author();
                    TextBox firstName = (TextBox)Controls.Find("authorFirstEnter" + index, true)[0];
                    TextBox middleName = (TextBox)Controls.Find("authorMiddleEnter" + index, true)[0];
                    TextBox lastName = (TextBox)Controls.Find("authorLastEnter" + index, true)[0];
                    author.firstName = firstName.Text;
                    author.middleName = middleName.Text;
                    author.lastName = lastName.Text;
                    if (author.firstName.Length > 0 || author.middleName.Length > 0 || author.lastName.Length > 0)
                    {
                        reference.authors.Add(author);
                    }
                }
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox magazine = (TextBox)Controls.Find("periodicalNameEnter", true)[0];
                reference.source = magazine.Text;
                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox retrievedFrom = (TextBox)Controls.Find("retrievedFromEnter", true)[0];
                reference.retrievedFrom = retrievedFrom.Text;
                TextBox accessedOn = (TextBox)Controls.Find("accessedEnter", true)[0];
                reference.accessedOn = accessedOn.Text;

                if (reference.authors.Count > 0)
                {
                    int validAuthors = reference.authors.Count - 1;
                    if (reference.authors[validAuthors].lastName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].lastName + ", ";
                    }
                    if (reference.authors[validAuthors].firstName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].firstName;
                    }
                    if (reference.authors[validAuthors].lastName.Length < 1 || reference.authors[validAuthors].firstName.Length < 1)
                    {
                        error = true;
                        errorMessage += "Enter the first and last name of the author\n";
                    }
                    else
                    {
                        if (reference.authors.Count == 2)
                        {
                            reference.formattedReference += ", and ";
                            if (reference.authors[0].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].firstName + " ";
                            }
                            if (reference.authors[0].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].lastName;
                            }
                            if (reference.authors[0].lastName.Length < 1 || reference.authors[0].firstName.Length < 1)
                            {
                                error = true;
                                errorMessage += "Enter the first and last name of the authors\n";
                            }
                        }
                        else if (reference.authors.Count > 2)
                        {
                            reference.formattedReference += ", et al";
                        }
                        reference.formattedReference += ". ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += "\"" + reference.title + ".\" ";
                        if (reference.source.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            reference.formattedReference += reference.source + ", ";
                            reference.formattedReference += '\a';
                            if (reference.publicationDate.Length > 0)
                            {
                                reference.formattedReference += reference.publicationDate + ", ";
                            }
                            else
                            {
                                reference.formattedReference += "n.d., ";
                            }
                            if (reference.retrievedFrom.Length > 0)
                            {
                                reference.formattedReference += reference.retrievedFrom + ". ";
                                if (reference.accessedOn.Length > 0)
                                {
                                    reference.formattedReference += "Accessed " + reference.accessedOn + ".";
                                }
                                else
                                {
                                    error = true;
                                    errorMessage += "Enter the date the article was viewed\n";
                                }
                            }
                            else
                            {
                                error = true;
                                errorMessage += "Enter the URL where the magazine was viewed\n";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the name of the magazine\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the title of the article\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the name of the author\n";
                }
            }
            else if (onlineNewspaper.Checked)
            {
                int numAuthors = Convert.ToInt32(sourceInfoGroupBox.Tag.ToString().Split(',')[0]);

                for (int i = 0; i < numAuthors; i++)
                {
                    int index = i + 1;
                    Author author = new Author();
                    TextBox firstName = (TextBox)Controls.Find("authorFirstEnter" + index, true)[0];
                    TextBox middleName = (TextBox)Controls.Find("authorMiddleEnter" + index, true)[0];
                    TextBox lastName = (TextBox)Controls.Find("authorLastEnter" + index, true)[0];
                    author.firstName = firstName.Text;
                    author.middleName = middleName.Text;
                    author.lastName = lastName.Text;
                    if (author.firstName.Length > 0 || author.middleName.Length > 0 || author.lastName.Length > 0)
                    {
                        reference.authors.Add(author);
                    }
                }
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox magazine = (TextBox)Controls.Find("newspaperNameEnter", true)[0];
                reference.source = magazine.Text;
                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox retrievedFrom = (TextBox)Controls.Find("retrievedFromEnter", true)[0];
                reference.retrievedFrom = retrievedFrom.Text;
                TextBox accessedOn = (TextBox)Controls.Find("accessedEnter", true)[0];
                reference.accessedOn = accessedOn.Text;
                TextBox pageStart = (TextBox)Controls.Find("pageStartEnter", true)[0];
                reference.startPage = pageStart.Text;
                TextBox pageEnd = (TextBox)Controls.Find("pageEndEnter", true)[0];
                reference.endPage = pageEnd.Text;

                if (reference.authors.Count > 0)
                {
                    int validAuthors = reference.authors.Count - 1;
                    if (reference.authors[validAuthors].lastName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].lastName + ", ";
                    }
                    if (reference.authors[validAuthors].firstName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].firstName;
                    }
                    if (reference.authors[validAuthors].lastName.Length < 1 || reference.authors[validAuthors].firstName.Length < 1)
                    {
                        error = true;
                        errorMessage += "Enter the first and last name of the author\n";
                    }
                    else
                    {
                        if (reference.authors.Count == 2)
                        {
                            reference.formattedReference += ", and ";
                            if (reference.authors[0].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].firstName + " ";
                            }
                            if (reference.authors[0].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].lastName;
                            }
                            if (reference.authors[0].lastName.Length < 1 || reference.authors[0].firstName.Length < 1)
                            {
                                error = true;
                                errorMessage += "Enter the first and last name of the authors\n";
                            }
                        }
                        else if (reference.authors.Count > 2)
                        {
                            reference.formattedReference += ", et al";
                        }
                        reference.formattedReference += ". ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += "\"" + reference.title + ".\" ";
                        if (reference.source.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            reference.formattedReference += reference.source + ", ";
                            reference.formattedReference += '\a';
                            if (reference.publicationDate.Length > 0)
                            {
                                reference.formattedReference += reference.publicationDate + ", ";
                            }
                            else
                            {
                                reference.formattedReference += "n.d., ";
                            }
                            if (reference.startPage.Length < 1 && reference.endPage.Length > 0)
                            {
                                error = true;
                                errorMessage += "Enter the start page\n";
                            }
                            else if ((reference.startPage.Length > 0 && reference.endPage.Length < 1) ||
                                (reference.startPage.Equals(reference.endPage) && reference.startPage.Length > 0))
                            {
                                reference.formattedReference += "p. " + reference.startPage + ", ";
                            }
                            else if (reference.startPage.Length > 0 && reference.endPage.Length > 0)
                            {
                                reference.formattedReference += "pp. " + reference.startPage + "-" + reference.endPage + ", ";
                            }
                            if (reference.retrievedFrom.Length > 0)
                            {
                                reference.formattedReference += reference.retrievedFrom + ". ";
                                if (reference.accessedOn.Length > 0)
                                {
                                    reference.formattedReference += "Accessed " + reference.accessedOn + ".";
                                }
                                else
                                {
                                    error = true;
                                    errorMessage += "Enter the date the article was viewed\n";
                                }
                            }
                            else
                            {
                                error = true;
                                errorMessage += "Enter the URL where the newspaper was viewed\n";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the name of the newspaper\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the title of the article\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the name of the author\n";
                }
            }
            else if (website.Checked)
            {
                int numAuthors = Convert.ToInt32(sourceInfoGroupBox.Tag.ToString().Split(',')[0]);

                for (int i = 0; i < numAuthors; i++)
                {
                    int index = i + 1;
                    Author author = new Author();
                    TextBox firstName = (TextBox)Controls.Find("authorFirstEnter" + index, true)[0];
                    TextBox middleName = (TextBox)Controls.Find("authorMiddleEnter" + index, true)[0];
                    TextBox lastName = (TextBox)Controls.Find("authorLastEnter" + index, true)[0];
                    author.firstName = firstName.Text;
                    author.middleName = middleName.Text;
                    author.lastName = lastName.Text;
                    if (author.firstName.Length > 0 || author.middleName.Length > 0 || author.lastName.Length > 0)
                    {
                        reference.authors.Add(author);
                    }
                }
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox mainSite = (TextBox)Controls.Find("mainTitleEnter", true)[0];
                reference.source = mainSite.Text;
                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox retrievedFrom = (TextBox)Controls.Find("retrieveFromEnter", true)[0];
                reference.retrievedFrom = retrievedFrom.Text;
                TextBox accessedOn = (TextBox)Controls.Find("accessedEnter", true)[0];
                reference.accessedOn = accessedOn.Text;

                if (reference.authors.Count > 0)
                {
                    int validAuthors = reference.authors.Count - 1;
                    if (reference.authors[validAuthors].lastName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].lastName + ", ";
                    }
                    if (reference.authors[validAuthors].firstName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].firstName;
                    }
                    if (reference.authors[validAuthors].lastName.Length < 1 || reference.authors[validAuthors].firstName.Length < 1)
                    {
                        error = true;
                        errorMessage += "Enter the first and last name of the author\n";
                    }
                    else
                    {
                        if (reference.authors.Count == 2)
                        {
                            reference.formattedReference += ", and ";
                            if (reference.authors[0].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].firstName + " ";
                            }
                            if (reference.authors[0].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].lastName;
                            }
                            if (reference.authors[0].lastName.Length < 1 || reference.authors[0].firstName.Length < 1)
                            {
                                error = true;
                                errorMessage += "Enter the first and last name of the authors\n";
                            }
                        }
                        else if (reference.authors.Count > 2)
                        {
                            reference.formattedReference += ", et al";
                        }
                        reference.formattedReference += ". ";
                    }
                }
                if (reference.title.Length > 0)
                {
                    reference.formattedReference += "\"" + reference.title + ".\" ";
                    if (reference.source.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        reference.formattedReference += reference.source + ", ";
                        reference.formattedReference += '\a';
                        if (reference.publicationDate.Length > 0)
                        {
                            reference.formattedReference += reference.publicationDate + ", ";
                        }
                        else
                        {
                            reference.formattedReference += "n.d., ";
                        }                        
                        if (reference.retrievedFrom.Length > 0)
                        {
                            reference.formattedReference += reference.retrievedFrom + ". ";
                            if (reference.accessedOn.Length > 0)
                            {
                                reference.formattedReference += "Accessed " + reference.accessedOn + ".";
                            }
                            else
                            {
                                error = true;
                                errorMessage += "Enter the date the page was viewed\n";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the URL where the page was viewed\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the name of the source website\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the title of the page\n";
                }                
            }
            else if (onlinePrintJournal.Checked)
            {
                int numAuthors = Convert.ToInt32(sourceInfoGroupBox.Tag.ToString().Split(',')[0]);

                for (int i = 0; i < numAuthors; i++)
                {
                    int index = i + 1;
                    Author author = new Author();
                    TextBox firstName = (TextBox)Controls.Find("authorFirstEnter" + index, true)[0];
                    TextBox middleName = (TextBox)Controls.Find("authorMiddleEnter" + index, true)[0];
                    TextBox lastName = (TextBox)Controls.Find("authorLastEnter" + index, true)[0];
                    author.firstName = firstName.Text;
                    author.middleName = middleName.Text;
                    author.lastName = lastName.Text;
                    if (author.firstName.Length > 0 || author.middleName.Length > 0 || author.lastName.Length > 0)
                    {
                        reference.authors.Add(author);
                    }
                }
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox journal = (TextBox)Controls.Find("journalNameEnter", true)[0];
                reference.source = journal.Text;
                TextBox volume = (TextBox)Controls.Find("volumeNumberEnter", true)[0];
                reference.volume = volume.Text;
                TextBox issue = (TextBox)Controls.Find("issueNumberEnter", true)[0];
                reference.issue = issue.Text;
                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox pageStart = (TextBox)Controls.Find("pageStartEnter", true)[0];
                reference.startPage = pageStart.Text;
                TextBox pageEnd = (TextBox)Controls.Find("pageEndEnter", true)[0];
                reference.endPage = pageEnd.Text;
                TextBox retrievedFrom = (TextBox)Controls.Find("retrievedFromEnter", true)[0];
                reference.retrievedFrom = retrievedFrom.Text;
                TextBox accessedOn = (TextBox)Controls.Find("accessedEnter", true)[0];
                reference.accessedOn = accessedOn.Text;

                if (reference.authors.Count > 0)
                {
                    int validAuthors = reference.authors.Count - 1;
                    if (reference.authors[validAuthors].lastName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].lastName + ", ";
                    }
                    if (reference.authors[validAuthors].firstName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].firstName;
                    }
                    if (reference.authors[validAuthors].lastName.Length < 1 || reference.authors[validAuthors].firstName.Length < 1)
                    {
                        error = true;
                        errorMessage += "Enter the first and last name of the author\n";
                    }
                    else
                    {
                        if (reference.authors.Count == 2)
                        {
                            reference.formattedReference += ", and ";
                            if (reference.authors[0].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].firstName + " ";
                            }
                            if (reference.authors[0].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].lastName;
                            }
                            if (reference.authors[0].lastName.Length < 1 || reference.authors[0].firstName.Length < 1)
                            {
                                error = true;
                                errorMessage += "Enter the first and last name of the authors\n";
                            }
                        }
                        else if (reference.authors.Count > 2)
                        {
                            reference.formattedReference += ", et al";
                        }
                        reference.formattedReference += ". ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += "\"" + reference.title + ".\" ";
                        if (reference.source.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            reference.formattedReference += reference.source + ", ";
                            reference.formattedReference += '\a';
                            if (reference.volume.Length > 0)
                            {
                                reference.formattedReference += "vol. " + reference.volume + ", ";
                            }
                            if (reference.issue.Length > 0)
                            {
                                reference.formattedReference += "no. " + reference.issue + ", ";
                            }
                            if (reference.publicationDate.Length > 0)
                            {
                                reference.formattedReference += reference.publicationDate + ", ";
                            }
                            else
                            {
                                reference.formattedReference += "n.d., ";
                            }
                            if (reference.startPage.Length < 1 && reference.endPage.Length > 0)
                            {
                                error = true;
                                errorMessage += "Enter the start page\n";
                            }
                            else if ((reference.startPage.Length > 0 && reference.endPage.Length < 1) ||
                                (reference.startPage.Equals(reference.endPage) && reference.startPage.Length > 0))
                            {
                                reference.formattedReference += "p. " + reference.startPage + ", ";
                            }
                            else if (reference.startPage.Length > 0 && reference.endPage.Length > 0)
                            {
                                reference.formattedReference += "pp. " + reference.startPage + "-" + reference.endPage + ", ";
                            }
                            if (reference.retrievedFrom.Length > 0)
                            {
                                reference.formattedReference += reference.retrievedFrom + ". ";
                                if (reference.accessedOn.Length > 0)
                                {
                                    reference.formattedReference += "Accessed " + reference.accessedOn + ".";
                                }
                                else
                                {
                                    error = true;
                                    errorMessage += "Enter the date the article was accessed\n";
                                }
                            }
                            else
                            {
                                error = true;
                                errorMessage += "Enter the URL where the article was viewed\n";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the name of the journal\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the title of the article\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the name of the author\n";
                }
            }
            else if (onlineEncyclopedia.Checked)
            {
                TextBox section = (TextBox)Controls.Find("sectionNameEnter", true)[0];
                reference.section = section.Text;
                TextBox title = (TextBox)Controls.Find("bookNameEnter", true)[0];
                reference.title = title.Text;
                TextBox retrievedFrom = (TextBox)Controls.Find("retrievedFromEnter", true)[0];
                reference.retrievedFrom = retrievedFrom.Text;
                TextBox accessedOn = (TextBox)Controls.Find("accessedEnter", true)[0];
                reference.accessedOn = accessedOn.Text;

                if (reference.section.Length > 0)
                {
                    reference.formattedReference += "\"" + reference.section + ".\" ";
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        reference.formattedReference += reference.title + ". ";
                        reference.formattedReference += '\a';
                        if (reference.retrievedFrom.Length > 0)
                        {
                            reference.formattedReference += reference.retrievedFrom + ". ";
                            if (reference.accessedOn.Length > 0)
                            {
                                reference.formattedReference += "Accessed " + reference.accessedOn + ".";
                            }
                            else
                            {
                                error = true;
                                errorMessage += "Enter the date the article was accessed\n";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the URL where the article was viewed\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the name of the dictionary or encyclopedia\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the word referenced\n";
                }
            }
            else if (blogDiscussion.Checked)
            {
                Author poster = new Author();
                TextBox posterFirst = (TextBox)Controls.Find("posterFirstEnter", true)[0];
                TextBox posterMiddle = (TextBox)Controls.Find("posterMiddleEnter", true)[0];
                TextBox posterLast = (TextBox)Controls.Find("posterLastEnter", true)[0];
                poster.firstName = posterFirst.Text;
                poster.middleName = posterMiddle.Text;
                poster.lastName = posterLast.Text;
                reference.authors.Add(poster);
                TextBox screenName = (TextBox)Controls.Find("posterScreenEnter", true)[0];
                reference.screenName = screenName.Text;
                TextBox title = (TextBox)Controls.Find("postTitleEnter", true)[0];
                reference.title = title.Text;
                TextBox website = (TextBox)Controls.Find("websiteEnter", true)[0];
                reference.source = website.Text;
                TextBox postDate = (TextBox)Controls.Find("postDateEnter", true)[0];
                reference.publicationDate = postDate.Text;
                TextBox retrievedFrom = (TextBox)Controls.Find("retrieveFromEnter", true)[0];
                reference.retrievedFrom = retrievedFrom.Text;
                TextBox accessedOn = (TextBox)Controls.Find("accessedEnter", true)[0];
                reference.accessedOn = accessedOn.Text;

                if (reference.screenName.Length > 0)
                {
                    reference.formattedReference += reference.screenName;
                    if (poster.firstName.Length > 0 && poster.lastName.Length > 0)
                    {
                        reference.formattedReference += " [" + reference.authors[0].firstName + " " + reference.authors[0].lastName + "]. ";
                    }
                    else
                    {
                        reference.formattedReference += ". ";
                    }
                }
                else
                {
                    if (poster.firstName.Length > 0 && poster.lastName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[0].firstName + " " + reference.authors[0].lastName + ". ";
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the name of the person posting\n";
                    }
                }   
                if (reference.title.Length > 0)
                {
                    reference.formattedReference += "\"" + reference.title + ".\" ";
                    if (reference.source.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        reference.formattedReference += reference.source + ", ";
                        reference.formattedReference += '\a';
                        if (reference.publicationDate.Length > 0)
                        {
                            reference.formattedReference += reference.publicationDate + ", ";
                        }
                        else
                        {
                            reference.formattedReference += "n.d., ";
                        }
                        if (reference.retrievedFrom.Length > 0)
                        {
                            reference.formattedReference += reference.retrievedFrom + ". ";
                            if (reference.accessedOn.Length > 0)
                            {
                                reference.formattedReference += "Accessed " + reference.accessedOn + ".";
                            }
                            else
                            {
                                error = true;
                                errorMessage += "Enter the date the post was accessed\n";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the URL where the post was viewed\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the name of the website being posted to\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the title of the post\n";
                }                            
            }
            else if (publishedDissertation.Checked || publishedThesis.Checked || unpublishedDissertation.Checked || unpublishedThesis.Checked)
            {
                int numAuthors = Convert.ToInt32(sourceInfoGroupBox.Tag.ToString().Split(',')[0]);

                for (int i = 0; i < numAuthors; i++)
                {
                    int index = i + 1;
                    Author author = new Author();
                    TextBox firstName = (TextBox)Controls.Find("authorFirstEnter" + index, true)[0];
                    TextBox middleName = (TextBox)Controls.Find("authorMiddleEnter" + index, true)[0];
                    TextBox lastName = (TextBox)Controls.Find("authorLastEnter" + index, true)[0];
                    author.firstName = firstName.Text;
                    author.middleName = middleName.Text;
                    author.lastName = lastName.Text;
                    if (author.firstName.Length > 0 || author.middleName.Length > 0 || author.lastName.Length > 0)
                    {
                        reference.authors.Add(author);
                    }
                }
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox school = (TextBox)Controls.Find("schoolEnter", true)[0];
                reference.source = school.Text;
                TextBox awarded = (TextBox)Controls.Find("yearAwardedEnter", true)[0];
                reference.publicationDate = awarded.Text;
                TextBox retrievedFrom = (TextBox)Controls.Find("retrievedFromEnter", true)[0];
                reference.retrievedFrom = retrievedFrom.Text;
                TextBox accessedOn = (TextBox)Controls.Find("accessedEnter", true)[0];
                reference.accessedOn = accessedOn.Text;

                if (reference.authors.Count > 0)
                {
                    int validAuthors = reference.authors.Count - 1;
                    if (reference.authors[validAuthors].lastName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].lastName + ", ";
                    }
                    if (reference.authors[validAuthors].firstName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].firstName;
                    }
                    if (reference.authors[validAuthors].lastName.Length < 1 || reference.authors[validAuthors].firstName.Length < 1)
                    {
                        error = true;
                        errorMessage += "Enter the first and last name of the author\n";
                    }
                    else
                    {
                        if (reference.authors.Count == 2)
                        {
                            reference.formattedReference += ", and ";
                            if (reference.authors[0].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].firstName + " ";
                            }
                            if (reference.authors[0].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].lastName;
                            }
                            if (reference.authors[0].lastName.Length < 1 || reference.authors[0].firstName.Length < 1)
                            {
                                error = true;
                                errorMessage += "Enter the first and last name of the authors\n";
                            }
                        }
                        else if (reference.authors.Count > 2)
                        {
                            reference.formattedReference += ", et al";
                        }
                        reference.formattedReference += ". ";
                    }
                    if (publishedDissertation.Checked || publishedThesis.Checked)
                    {
                        if (reference.title.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            reference.formattedReference += reference.title + ". ";
                            reference.formattedReference += '\a';
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the title\n";
                        }
                    }
                    else if (unpublishedDissertation.Checked || unpublishedThesis.Checked)
                    {
                        if (reference.title.Length > 0)
                        {
                            reference.formattedReference += "\"" + reference.title + ".\" ";
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the title\n";
                        }
                    }
                    if (publishedDissertation.Checked || unpublishedDissertation.Checked)
                    {
                        reference.formattedReference += "Dissertation, ";
                    }
                    else if (publishedThesis.Checked || unpublishedThesis.Checked)
                    {
                        reference.formattedReference += "Thesis, ";
                    }
                    if (reference.source.Length > 0)
                    {
                        reference.formattedReference += reference.source + ", ";
                        if (reference.publicationDate.Length > 0)
                        {
                            reference.formattedReference += reference.publicationDate;
                        }
                        else
                        {
                            reference.formattedReference += "n.d.";
                        }
                        if (reference.retrievedFrom.Length > 0)
                        {
                            reference.formattedReference += ", " + reference.retrievedFrom + ". ";
                            if (reference.accessedOn.Length > 0)
                            {
                                reference.formattedReference += "Accessed " + reference.accessedOn + ".";
                            }
                            else
                            {
                                error = true;
                                errorMessage += "Enter the date the document was accessed\n";
                            }
                        }
                        else if (reference.publicationDate.Length > 0)
                        {
                            reference.formattedReference += ".";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the name of the school\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the name of the author\n";
                }
            }
            else if (governmentDocument.Checked)
            {
                TextBox organization = (TextBox)Controls.Find("authorEnter", true)[0];
                reference.organization = organization.Text;
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox publisher = (TextBox)Controls.Find("publisherEnter", true)[0];
                reference.publisher = publisher.Text;
                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox retrievedFrom = (TextBox)Controls.Find("retrievedFromEnter", true)[0];
                reference.retrievedFrom = retrievedFrom.Text;
                TextBox accessedOn = (TextBox)Controls.Find("accessedEnter", true)[0];
                reference.accessedOn = accessedOn.Text;

                if (reference.organization.Length > 0)
                {
                    reference.formattedReference += reference.organization + ". ";
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        reference.formattedReference += reference.title + ". ";
                        reference.formattedReference += '\a';
                        if (reference.publisher.Length > 0)
                        {
                            reference.formattedReference += reference.publisher + ", ";
                            if (reference.publicationDate.Length > 0)
                            {
                                reference.formattedReference += reference.publicationDate;
                            }
                            else
                            {
                                reference.formattedReference += "n.d.";
                            }
                            if (reference.retrievedFrom.Length > 0)
                            {
                                reference.formattedReference += ", " + reference.retrievedFrom + ". ";
                                if (reference.accessedOn.Length > 0)
                                {
                                    reference.formattedReference += "Accessed " + reference.accessedOn + ".";
                                }
                                else
                                {
                                    error = true;
                                    errorMessage += "Enter the date the document was accessed\n";
                                }
                            }
                            else if (reference.publicationDate.Length > 0)
                            {
                                reference.formattedReference += ".";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the name of the publisher\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the name of the title of the document\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the name of the organization that wrote the document\n";
                }
            }
            else if (review.Checked)
            {
                int numReviewers = Convert.ToInt32(sourceInfoGroupBox.Tag.ToString().Split(',')[0]);
                int numAuthors = Convert.ToInt32(sourceInfoGroupBox.Tag.ToString().Split(',')[2]);

                for (int i = 0; i < numReviewers; i++)
                {
                    int index = i + 1;
                    Author author = new Author();
                    TextBox firstName = (TextBox)Controls.Find("reviewerFirstEnter" + index, true)[0];
                    TextBox middleName = (TextBox)Controls.Find("reviewerMiddleEnter" + index, true)[0];
                    TextBox lastName = (TextBox)Controls.Find("reviewerLastEnter" + index, true)[0];
                    author.firstName = firstName.Text;
                    author.middleName = middleName.Text;
                    author.lastName = lastName.Text;
                    if (author.firstName.Length > 0 || author.middleName.Length > 0 || author.lastName.Length > 0)
                    {
                        reference.reviewers.Add(author);
                    }
                }

                for (int i = 0; i < numAuthors; i++)
                {
                    int index = i + 1;
                    Author author = new Author();
                    TextBox firstName = (TextBox)Controls.Find("authorFirstEnter" + index, true)[0];
                    TextBox middleName = (TextBox)Controls.Find("authorMiddleEnter" + index, true)[0];
                    TextBox lastName = (TextBox)Controls.Find("authorLastEnter" + index, true)[0];
                    author.firstName = firstName.Text;
                    author.middleName = middleName.Text;
                    author.lastName = lastName.Text;
                    if (author.firstName.Length > 0 || author.middleName.Length > 0 || author.lastName.Length > 0)
                    {
                        reference.authors.Add(author);
                    }
                }
                TextBox reviewTitle = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.reviewTitle = reviewTitle.Text;
                TextBox title = (TextBox)Controls.Find("reviewedTitleEnter", true)[0];
                reference.title = title.Text;
                TextBox source = (TextBox)Controls.Find("sourceEnter", true)[0];
                reference.source = source.Text;
                TextBox publicationyear = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publicationyear.Text;
                TextBox pageStart = (TextBox)Controls.Find("pageStartEnter", true)[0];
                reference.startPage = pageStart.Text;
                TextBox pageEnd = (TextBox)Controls.Find("pageEndEnter", true)[0];
                reference.endPage = pageEnd.Text;
                TextBox retrievedFrom = (TextBox)Controls.Find("retrievedFromEnter", true)[0];
                reference.retrievedFrom = retrievedFrom.Text;
                TextBox accessedOn = (TextBox)Controls.Find("accessedEnter", true)[0];
                reference.accessedOn = accessedOn.Text;

                if (reference.reviewers.Count > 0)
                {
                    int validReviewers = reference.reviewers.Count - 1;
                    if (reference.reviewers[validReviewers].lastName.Length > 0)
                    {
                        reference.formattedReference += reference.reviewers[validReviewers].lastName + ", ";
                    }
                    if (reference.reviewers[validReviewers].firstName.Length > 0)
                    {
                        reference.formattedReference += reference.reviewers[validReviewers].firstName;
                    }
                    if (reference.reviewers[validReviewers].lastName.Length < 1 || reference.reviewers[validReviewers].firstName.Length < 1)
                    {
                        error = true;
                        errorMessage += "Enter the first and last name of the reviewer\n";
                    }
                    else
                    {
                        if (reference.reviewers.Count == 2)
                        {
                            reference.formattedReference += ", and ";
                            if (reference.reviewers[0].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.reviewers[0].firstName + " ";
                            }
                            if (reference.reviewers[0].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.reviewers[0].lastName;
                            }
                            if (reference.reviewers[0].lastName.Length < 1 || reference.reviewers[0].firstName.Length < 1)
                            {
                                error = true;
                                errorMessage += "Enter the first and last name of the reviewer\n";
                            }
                        }
                        else if (reference.reviewers.Count > 2)
                        {
                            reference.formattedReference += ", et al";
                        }
                        reference.formattedReference += ". ";
                    }
                    if (reference.reviewTitle.Length > 0)
                    {
                        reference.formattedReference += "\"" + reference.reviewTitle + ".\" ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += "Review of ";
                        reference.formattedReference += '\a';
                        reference.formattedReference += reference.title + ", ";
                        reference.formattedReference += '\a';
                        reference.formattedReference += "by ";
                        if (reference.authors.Count > 0)
                        {
                            int validAuthors = reference.authors.Count - 1;
                            if (reference.authors[validAuthors].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[validAuthors].firstName + " ";
                            }
                            if (reference.authors[validAuthors].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[validAuthors].lastName;
                            }
                            if (reference.authors[validAuthors].lastName.Length < 1 || reference.authors[validAuthors].firstName.Length < 1)
                            {
                                error = true;
                                errorMessage += "Enter the first and last name of the author\n";
                            }
                            else
                            {
                                if (reference.authors.Count == 2)
                                {
                                    reference.formattedReference += ", and ";
                                    if (reference.authors[0].firstName.Length > 0)
                                    {
                                        reference.formattedReference += reference.authors[0].firstName + " ";
                                    }
                                    if (reference.authors[0].lastName.Length > 0)
                                    {
                                        reference.formattedReference += reference.authors[0].lastName;
                                    }
                                    if (reference.authors[0].lastName.Length < 1 || reference.authors[0].firstName.Length < 1)
                                    {
                                        error = true;
                                        errorMessage += "Enter the first and last name of the authors\n";
                                    }
                                }
                                else if (reference.authors.Count > 2)
                                {
                                    reference.formattedReference += ", et al";
                                }
                                reference.formattedReference += ", ";
                            }
                            if (reference.source.Length > 0)
                            {
                                reference.formattedReference += '\a';
                                reference.formattedReference += reference.source + ", ";
                                reference.formattedReference += '\a';
                                if (reference.publicationDate.Length > 0)
                                {
                                    reference.formattedReference += reference.publicationDate;
                                }
                                else
                                {
                                    reference.formattedReference += "n.d.";
                                }
                                if (reference.startPage.Length < 1 && reference.retrievedFrom.Length < 1 && reference.publicationDate.Length > 0)
                                {
                                    reference.formattedReference += ".";
                                }
                                else
                                {
                                    reference.formattedReference += ", ";
                                    if (reference.startPage.Length < 1 && reference.endPage.Length > 0)
                                    {
                                        error = true;
                                        errorMessage += "Enter the start page\n";
                                    }
                                    else if ((reference.startPage.Length > 0 && reference.endPage.Length < 1) ||
                                        (reference.startPage.Equals(reference.endPage) && reference.startPage.Length > 0))
                                    {
                                        reference.formattedReference += "p. " + reference.startPage + ", ";
                                    }
                                    else if (reference.startPage.Length > 0 && reference.endPage.Length > 0)
                                    {
                                        reference.formattedReference += "pp. " + reference.startPage + "-" + reference.endPage + ", ";
                                    }
                                    if (reference.retrievedFrom.Length > 0)
                                    {
                                        reference.formattedReference += reference.retrievedFrom + ". ";
                                        if (reference.accessedOn.Length > 0)
                                        {
                                            reference.formattedReference += "Accessed " + reference.accessedOn + ".";
                                        }
                                        else
                                        {
                                            error = true;
                                            errorMessage += "Enter the date the article was accessed\n";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                error = true;
                                errorMessage += "Enter the source of the review\n";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the name of the original author\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the name of the work being reviewed\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the name of the reviewer\n";
                }
            }
            else if (presentation.Checked)
            {
                int numAuthors = Convert.ToInt32(sourceInfoGroupBox.Tag.ToString().Split(',')[0]);

                for (int i = 0; i < numAuthors; i++)
                {
                    int index = i + 1;
                    Author author = new Author();
                    TextBox firstName = (TextBox)Controls.Find("presenterFirstEnter" + index, true)[0];
                    TextBox middleName = (TextBox)Controls.Find("presenterMiddleEnter" + index, true)[0];
                    TextBox lastName = (TextBox)Controls.Find("presenterLastEnter" + index, true)[0];
                    author.firstName = firstName.Text;
                    author.middleName = middleName.Text;
                    author.lastName = lastName.Text;
                    if (author.firstName.Length > 0 || author.middleName.Length > 0 || author.lastName.Length > 0)
                    {
                        reference.authors.Add(author);
                    }
                }
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox meeting = (TextBox)Controls.Find("meetingEnter", true)[0];
                reference.meeting = meeting.Text;
                TextBox dateGiven = (TextBox)Controls.Find("dateEnter", true)[0];
                reference.publicationDate = dateGiven.Text;
                TextBox venue = (TextBox)Controls.Find("venueEnter", true)[0];
                reference.venue = venue.Text;
                TextBox location = (TextBox)Controls.Find("locationEnter", true)[0];
                reference.location = location.Text;
                TextBox format = (TextBox)Controls.Find("formatEnter", true)[0];
                reference.format = format.Text;
                TextBox retrievedFrom = (TextBox)Controls.Find("retrievedFromEnter", true)[0];
                reference.retrievedFrom = retrievedFrom.Text;
                TextBox accessedOn = (TextBox)Controls.Find("accessedEnter", true)[0];
                reference.accessedOn = accessedOn.Text;

                if (reference.authors.Count > 0)
                {
                    int validAuthors = reference.authors.Count - 1;
                    if (reference.authors[validAuthors].lastName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].lastName + ", ";
                    }
                    if (reference.authors[validAuthors].firstName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].firstName;
                    }
                    if (reference.authors[validAuthors].lastName.Length < 1 || reference.authors[validAuthors].firstName.Length < 1)
                    {
                        error = true;
                        errorMessage += "Enter the first and last name of the author\n";
                    }
                    else
                    {
                        if (reference.authors.Count == 2)
                        {
                            reference.formattedReference += ", and ";
                            if (reference.authors[0].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].firstName + " ";
                            }
                            if (reference.authors[0].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[0].lastName;
                            }
                            if (reference.authors[0].lastName.Length < 1 || reference.authors[0].firstName.Length < 1)
                            {
                                error = true;
                                errorMessage += "Enter the first and last name of the authors\n";
                            }
                        }
                        else if (reference.authors.Count > 2)
                        {
                            reference.formattedReference += ", et al";
                        }
                        reference.formattedReference += ". ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += "\"" + reference.title + ".\" ";
                        if (reference.meeting.Length > 0)
                        {
                            reference.formattedReference += reference.meeting + ", ";
                        }
                        if (reference.publicationDate.Length > 0)
                        {
                            reference.formattedReference += reference.publicationDate;
                        }
                        else
                        {
                            reference.formattedReference += "n.d.";
                        }
                        if (reference.venue.Length > 0)
                        {
                            reference.formattedReference += ", " + reference.venue;
                        }
                        if (reference.location.Length > 0 && !reference.location.Equals(reference.venue))
                        {
                            reference.formattedReference += ", " + reference.location;
                        }
                        if (reference.format.Length > 0)
                        {
                            if (reference.publicationDate.Length > 0 || reference.venue.Length > 0 || reference.location.Length > 0)
                            {
                                reference.formattedReference += ".";
                            }
                            reference.formattedReference += " " + reference.format + ". ";
                            if (reference.retrievedFrom.Length > 0)
                            {
                                reference.formattedReference += reference.retrievedFrom + ". ";
                                if (reference.accessedOn.Length > 0)
                                {
                                    reference.formattedReference += "Accessed " + reference.accessedOn + ".";
                                }
                                else
                                {
                                    error = true;
                                    errorMessage += "Enter the date the article was accessed\n";
                                }
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the kind of address that was given\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the title of the presentation\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the name of the presenter\n";
                }
            }
            else if (movie.Checked)
            {
                Author director = new Author();
                TextBox directorFirst = (TextBox)Controls.Find("directorFirstEnter", true)[0];
                TextBox directorMiddle = (TextBox)Controls.Find("directorMiddleEnter", true)[0];
                TextBox directorLast = (TextBox)Controls.Find("directorLastEnter", true)[0];
                director.firstName = directorFirst.Text;
                director.middleName = directorMiddle.Text;
                director.lastName = directorLast.Text;
                reference.director = director;
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox distributor = (TextBox)Controls.Find("distributorEnter", true)[0];
                reference.studio = distributor.Text;
                TextBox releaseDate = (TextBox)Controls.Find("releaseEnter", true)[0];
                reference.publicationDate = releaseDate.Text;

                if (reference.title.Length > 0)
                {
                    reference.formattedReference += '\a';
                    reference.formattedReference += reference.title + ". ";
                    reference.formattedReference += '\a';
                    if (director.firstName.Length > 0 && director.lastName.Length > 0)
                    {
                        reference.formattedReference += "Directed by " + reference.director.firstName + " " + reference.director.lastName + ", ";
                        if (reference.studio.Length > 0)
                        {
                            reference.formattedReference += reference.studio + ", ";
                        }
                        if (reference.publicationDate.Length > 0)
                        {
                            reference.formattedReference += reference.publicationDate + ".";
                        }
                        else
                        {
                            reference.formattedReference += "n.d.";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the first and last name of the director\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the title of the movie\n";
                }                
            }
            else if (tvEpisode.Checked)
            {
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox series = (TextBox)Controls.Find("seriesTitleEnter", true)[0];
                reference.source = series.Text;
                TextBox season = (TextBox)Controls.Find("seasonEnter", true)[0];
                reference.season = season.Text;
                TextBox episode = (TextBox)Controls.Find("episodeEnter", true)[0];
                reference.episode = episode.Text;
                TextBox network = (TextBox)Controls.Find("networkEnter", true)[0];
                reference.studio = network.Text;
                TextBox letters = (TextBox)Controls.Find("lettersEnter", true)[0];
                reference.callLetters = letters.Text;
                TextBox location = (TextBox)Controls.Find("originEnter", true)[0];
                reference.location = location.Text;
                TextBox date = (TextBox)Controls.Find("publicationDateEnter", true)[0];
                reference.publicationDate = date.Text;

                if (reference.title.Length > 0)
                {
                    reference.formattedReference += "\"" + reference.title + ".\" ";
                    if (reference.source.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        reference.formattedReference += reference.source + ", ";
                        reference.formattedReference += '\a';
                        if (reference.season.Length > 0)
                        {
                            reference.formattedReference += "season " + reference.season + ", ";
                            if (reference.episode.Length > 0)
                            {
                                reference.formattedReference += "episode " + reference.episode + ", ";
                                if (reference.studio.Length > 0)
                                {
                                    reference.formattedReference += reference.studio + ", ";
                                    if (reference.callLetters.Length > 0)
                                    {
                                        reference.formattedReference += reference.callLetters + ", ";
                                    }
                                    if (reference.location.Length > 0)
                                    {
                                        reference.formattedReference += reference.location + ", ";
                                    }
                                    if (reference.publicationDate.Length > 0)
                                    {
                                        reference.formattedReference += reference.publicationDate + ".";
                                    }
                                    else
                                    {
                                        reference.formattedReference += "n.d.";
                                    }
                                }
                                else
                                {
                                    error = true;
                                    errorMessage += "Enter the network\n";
                                }
                            }
                            else
                            {
                                error = true;
                                errorMessage += "Enter the episode number\n";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the season number\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the name of the series\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the name of the episode\n";
                }
            }
            else if (music.Checked)
            {
                TextBox artist = (TextBox)Controls.Find("artistEnter", true)[0];
                reference.artistName = artist.Text;
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox album = (TextBox)Controls.Find("albumTitleEnter", true)[0];
                reference.source = album.Text;
                TextBox manufacturer = (TextBox)Controls.Find("manufacturerEnter", true)[0];
                reference.studio = manufacturer.Text;
                TextBox date = (TextBox)Controls.Find("copyrightDateEnter", true)[0];
                reference.publicationDate = date.Text;
                TextBox retrievedFrom = (TextBox)Controls.Find("retrievedFromEnter", true)[0];
                reference.retrievedFrom = retrievedFrom.Text;
                TextBox accessedOn = (TextBox)Controls.Find("accessedEnter", true)[0];
                reference.accessedOn = accessedOn.Text;

                if (reference.artistName.Length > 0)
                {
                    reference.formattedReference += reference.artistName + ". ";
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += "\"" + reference.title + ".\" ";
                        if (reference.source.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            reference.formattedReference += reference.source + ", ";
                            reference.formattedReference += '\a';
                            if (reference.studio.Length > 0)
                            {
                                reference.formattedReference += reference.studio + ", ";
                            }
                            if (reference.publicationDate.Length > 0)
                            {
                                reference.formattedReference += reference.publicationDate + ".";
                            }
                            else
                            {
                                reference.formattedReference += "n.d.";
                            }
                            if (reference.retrievedFrom.Length > 0)
                            {
                                reference.formattedReference += " ";
                                reference.formattedReference += reference.retrievedFrom + ". ";
                                if (reference.accessedOn.Length > 0)
                                {
                                    reference.formattedReference += "Accessed " + reference.accessedOn + ".";
                                }
                                else
                                {
                                    error = true;
                                    errorMessage += "Enter the date the article was accessed\n";
                                }
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the album\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the title of the song\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the name of the artist\n";
                }
            }
            else if (interview.Checked)
            {
                Author communicator = new Author();
                TextBox communicatorFirst = (TextBox)Controls.Find("communicatorFirstEnter", true)[0];
                TextBox communicatorMiddle = (TextBox)Controls.Find("communicatorMiddleEnter", true)[0];
                TextBox communicatorLast = (TextBox)Controls.Find("communicatorLastEnter", true)[0];
                communicator.firstName = communicatorFirst.Text;
                communicator.middleName = communicatorMiddle.Text;
                communicator.lastName = communicatorLast.Text;
                reference.communicator = communicator;
                TextBox date = (TextBox)Controls.Find("dateEnter", true)[0];
                reference.publicationDate = date.Text;

                if (communicator.firstName.Length > 0 && communicator.lastName.Length > 0)
                {
                    reference.formattedReference += communicator.lastName + ", " + communicator.firstName + ". Personal interview. ";
                    if (reference.publicationDate.Length > 0)
                    {
                        reference.formattedReference += reference.publicationDate + ".";
                    }
                    else
                    {
                        reference.formattedReference += "n.d.";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the name of the person being interviewed\n";
                }
            }
            else if (email.Checked)
            {
                Author communicator = new Author();
                TextBox communicatorFirst = (TextBox)Controls.Find("communicatorFirstEnter", true)[0];
                TextBox communicatorMiddle = (TextBox)Controls.Find("communicatorMiddleEnter", true)[0];
                TextBox communicatorLast = (TextBox)Controls.Find("communicatorLastEnter", true)[0];
                communicator.firstName = communicatorFirst.Text;
                communicator.middleName = communicatorMiddle.Text;
                communicator.lastName = communicatorLast.Text;
                reference.communicator = communicator;
                TextBox subjectLine = (TextBox)Controls.Find("subjectEnter", true)[0];
                reference.title = subjectLine.Text;
                Author receiver = new Author();
                TextBox receiverFirst = (TextBox)Controls.Find("receiverFirstEnter", true)[0];
                TextBox receiverMiddle = (TextBox)Controls.Find("receiverMiddleEnter", true)[0];
                TextBox receiverLast = (TextBox)Controls.Find("receiverLastEnter", true)[0];
                receiver.firstName = receiverFirst.Text;
                receiver.middleName = receiverMiddle.Text;
                receiver.lastName = receiverLast.Text;
                reference.receiver = receiver;
                TextBox date = (TextBox)Controls.Find("dateEnter", true)[0];
                reference.publicationDate = date.Text;

                if (communicator.firstName.Length > 0 && communicator.lastName.Length > 0)
                {
                    reference.formattedReference += communicator.lastName + ", " + communicator.firstName + ". Email. ";
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += "\"" + reference.title + ".\" ";
                        if (receiver.firstName.Length > 0 && receiver.lastName.Length > 0)
                        {
                            reference.formattedReference += "Received by " + receiver.firstName + " " + receiver.lastName + ", ";
                            if (reference.publicationDate.Length > 0)
                            {
                                reference.formattedReference += reference.publicationDate + ".";
                            }
                            else
                            {
                                reference.formattedReference += "n.d.";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the name of the person who received the email\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the subject line of the email\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the name of the person sending the email\n";
                }
            }
            else if (letterToEditor.Checked)
            {
                reference.type = "editorial";
                int numAuthors = Convert.ToInt32(sourceInfoGroupBox.Tag.ToString().Split(',')[0]);
                
                Author author = new Author();
                TextBox firstName = (TextBox)Controls.Find("authorFirstEnter", true)[0];
                TextBox middleName = (TextBox)Controls.Find("authorMiddleEnter", true)[0];
                TextBox lastName = (TextBox)Controls.Find("authorLastEnter", true)[0];
                author.firstName = firstName.Text;
                author.middleName = middleName.Text;
                author.lastName = lastName.Text;
                reference.authors.Add(author);
                
                TextBox bookTitle = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = bookTitle.Text;
                TextBox source = (TextBox)Controls.Find("wherePublishedEnter", true)[0];
                reference.source = source.Text;
                TextBox publishDate = (TextBox)Controls.Find("publicationDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox pageStart = (TextBox)Controls.Find("pageStartEnter", true)[0];
                reference.startPage = pageStart.Text;
                TextBox pageEnd = (TextBox)Controls.Find("pageEndEnter", true)[0];
                reference.endPage = pageEnd.Text;
                if (reference.authors.Count > 0)
                {
                    int validAuthors = reference.authors.Count - 1;
                    if (reference.authors[validAuthors].lastName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].lastName + ", ";
                    }
                    if (reference.authors[validAuthors].firstName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[validAuthors].firstName;
                    }
                    reference.formattedReference += ". ";
                    if (reference.authors[validAuthors].lastName.Length < 1 || reference.authors[validAuthors].firstName.Length < 1)
                    {
                        error = true;
                        errorMessage += "Enter the first and last name of the author\n";
                    }
                }
                if (reference.title.Length > 0)
                {
                    reference.formattedReference += "\"" + reference.title + ".\" Letter. ";
                    if (reference.source.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        reference.formattedReference += reference.source + ", ";
                        reference.formattedReference += '\a';
                        if (reference.publicationDate.Length > 0)
                        {
                            reference.formattedReference += reference.publicationDate;
                            if (reference.startPage.Length > 0)
                            {
                                reference.formattedReference += ", ";
                            }
                            else
                            {
                                reference.formattedReference += ".";
                            }
                        }
                        else
                        {
                            reference.formattedReference += "n.d.";
                            if (reference.startPage.Length > 0)
                            {
                                reference.formattedReference += ", ";
                            }
                        }
                        if (reference.startPage.Length < 1 && reference.endPage.Length > 0)
                        {
                            error = true;
                            errorMessage += "Enter the start page\n";
                        }
                        if ((reference.startPage.Length > 0 && reference.endPage.Length < 1) ||
                            (reference.startPage.Equals(reference.endPage) && reference.startPage.Length > 0))
                        {
                            reference.formattedReference += "p. " + reference.startPage + ".";
                        }
                        else if (reference.startPage.Length > 0 && reference.endPage.Length > 0)
                        {
                            reference.formattedReference += "pp. " + reference.startPage + "-" + reference.endPage + ".";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the source that printed the editorial\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the title of the editorial\n";
                }
            }
            else
            {

            }
            if (error)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                Form1.myPaper.references.references.Add(reference);
                //this.Close();
            }
        }
    }
}

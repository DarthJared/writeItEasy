using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WriteMeEasy_WindowsFormsApplication
{
    public partial class ReferenceAdder : Form
    {
        private void addReferenceButton_Click(object sender, EventArgs e)
        {
            Reference reference = new Reference();
            bool error = false;
            string errorMessage = "";
            if (bookAuth.Checked)
            {
                reference.type = "bookAuth";
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
                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox bookTitle = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = bookTitle.Text;
                TextBox publisher = (TextBox)Controls.Find("publisherEnter", true)[0];
                reference.publisher = publisher.Text;
                TextBox publishLocation = (TextBox)Controls.Find("publishLocationEnter", true)[0];
                reference.publishLocation = publishLocation.Text;
                TextBox edition = (TextBox)Controls.Find("editionEnter", true)[0];
                reference.edition = edition.Text;

                reference.formattedReference = "";
               
                if (reference.authors.Count > 0)
                {
                    for (int i = 0; i < reference.authors.Count; i++)
                    {
                        bool elipseAdded = false;
                        if (i < 6 && i != reference.authors.Count - 1)
                        {
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName + ", ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ".";
                                if (reference.authors[i].middleName.Length < 1)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += " ";
                                }
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + "., ";
                            }
                        }
                        else if (i == reference.authors.Count - 1)
                        {
                            if (!elipseAdded && i > 0)
                            {
                                reference.formattedReference += "& ";
                            }
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName;
                                if (reference.authors[i].firstName.Length > 0 || reference.authors[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += ",";
                                }
                                reference.formattedReference += " ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ". ";
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + ". ";
                            }
                        }
                        else
                        {
                            if (!elipseAdded)
                            {
                                elipseAdded = true;
                                reference.formattedReference += ". . . ";
                            }
                        }
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }                                
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        if (reference.edition.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            reference.formattedReference += " (" + reference.edition + " ed.). ";
                        }
                        else
                        {
                            reference.formattedReference += ". ";
                            reference.formattedReference += '\a';
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter a title for the book being referenced\n";
                    }
                    if (reference.publishLocation.Length > 0)
                    {
                        if (reference.publisher.Length > 0)
                        {
                            reference.formattedReference += reference.publishLocation + ": ";
                        }
                        else
                        {
                            reference.formattedReference += reference.publishLocation + ".";
                        }
                    }
                    if (reference.publisher.Length > 0)
                    {
                        reference.formattedReference += reference.publisher + ".";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter an author or switch reference type to \"Book without Author\"\n";
                }
            }
            else if (bookNoAuth.Checked)
            {
                reference.type = "bookNoAuth";

                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox bookTitle = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = bookTitle.Text;
                TextBox publisher = (TextBox)Controls.Find("publisherEnter", true)[0];
                reference.publisher = publisher.Text;
                TextBox publishLocation = (TextBox)Controls.Find("publishLocationEnter", true)[0];
                reference.publishLocation = publishLocation.Text;
                TextBox edition = (TextBox)Controls.Find("editionEnter", true)[0];
                reference.edition = edition.Text;

                if (bookTitle.Text.Length > 0)
                {
                    reference.formattedReference += '\a';
                    bool nextCapital = true;
                    for (int i = 0; i < reference.title.Length; i++)
                    {
                        if (nextCapital)
                        {
                            if (!reference.title[i].ToString().Equals(" "))
                            {
                                nextCapital = false;
                            }
                            reference.formattedReference += reference.title[i].ToString().ToUpper();
                        }
                        else
                        {
                            reference.formattedReference += reference.title[i].ToString().ToLower();
                        }
                        if (reference.title[i].ToString().Equals(":"))
                        {
                            nextCapital = true;
                        }
                    }
                    if (reference.edition.Length > 0)
                    {
                        reference.formattedReference += " (" + reference.edition + " ed.).";
                    }
                    else
                    {
                        reference.formattedReference += ".";
                        reference.formattedReference += '\a';
                    }
                    if (reference.publicationDate.Length > 0)
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    else
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    if (reference.publishLocation.Length > 0)
                    {
                        if (reference.publisher.Length > 0)
                        {
                            reference.formattedReference += reference.publishLocation + ": ";
                        }
                        else
                        {
                            reference.formattedReference += reference.publishLocation + ".";
                        }
                    }
                    if (reference.publisher.Length > 0)
                    {
                        reference.formattedReference += reference.publisher + ".";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter a title for the book being referenced\n";
                }
            }
            else if (bookByOrg.Checked)
            {
                reference.type = "bookOrg";
                
                TextBox orgName = (TextBox)Controls.Find("authorEnter", true)[0];
                Author author = new Author();
                author.completeName = orgName.Text;
                reference.authors.Add(author);
                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox bookTitle = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = bookTitle.Text;
                TextBox publisher = (TextBox)Controls.Find("publisherEnter", true)[0];
                reference.publisher = publisher.Text;
                TextBox publishLocation = (TextBox)Controls.Find("publishLocationEnter", true)[0];
                reference.publishLocation = publishLocation.Text;
                TextBox edition = (TextBox)Controls.Find("editionEnter", true)[0];
                reference.edition = edition.Text;

                reference.formattedReference = "";

                if (author.completeName.Length > 0)
                {
                    reference.formattedReference += author.completeName + ". ";
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        if (reference.edition.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            reference.formattedReference += " (" + reference.edition + " ed.). ";
                        }
                        else
                        {
                            reference.formattedReference += ". ";
                            reference.formattedReference += '\a';
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter a title for the book being referenced\n";
                    }
                    if (reference.publishLocation.Length > 0)
                    {
                        if (reference.publisher.Length > 0)
                        {
                            reference.formattedReference += reference.publishLocation + ": ";
                        }
                        else
                        {
                            reference.formattedReference += reference.publishLocation + ".";
                        }
                    }
                    if (reference.publisher.Length > 0)
                    {
                        reference.formattedReference += reference.publisher + ".";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the organization or switch reference type to \"Book without Author\"\n";
                }
            }
            else if (encyclopedia.Checked)
            {
                reference.type = "dictionEncyclo";
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
                TextBox publishDate = (TextBox)Controls.Find("publicationYearEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox sectionReferenced = (TextBox)Controls.Find("sectionNameEnter", true)[0];
                reference.section = sectionReferenced.Text;
                TextBox bookTitle = (TextBox)Controls.Find("bookNameEnter", true)[0];
                reference.title = bookTitle.Text;
                TextBox volume = (TextBox)Controls.Find("volumeEnter", true)[0];
                reference.volume = volume.Text;
                TextBox startPage = (TextBox)Controls.Find("pageStartEnter", true)[0];
                reference.startPage = startPage.Text;
                TextBox endPage = (TextBox)Controls.Find("pageEndEnter", true)[0];
                reference.endPage = endPage.Text;
                TextBox publisher = (TextBox)Controls.Find("publisherEnter", true)[0];
                reference.publisher = publisher.Text;
                TextBox publishLocation = (TextBox)Controls.Find("publicationLocationEnter", true)[0];
                reference.publishLocation = publishLocation.Text;

                reference.formattedReference = "";

                if (reference.authors.Count > 0)
                {
                    for (int i = 0; i < reference.authors.Count; i++)
                    {
                        bool elipseAdded = false;
                        if (i < 6 && i != reference.authors.Count - 1)
                        {
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName + ", ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ".";
                                if (reference.authors[i].middleName.Length < 1)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += " ";
                                }
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + "., ";
                            }
                        }
                        else if (i == reference.authors.Count - 1)
                        {
                            if (!elipseAdded && i > 0)
                            {
                                reference.formattedReference += "& ";
                            }
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName;
                                if (reference.authors[i].firstName.Length > 0 || reference.authors[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += ",";
                                }
                                reference.formattedReference += " ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ". ";
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + ". ";
                            }
                        }
                        else
                        {
                            if (!elipseAdded)
                            {
                                elipseAdded = true;
                                reference.formattedReference += ". . . ";
                            }
                        }
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.section.Length > 0)
                    {
                        reference.formattedReference += reference.section + ". In ";
                        if (reference.title.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            reference.formattedReference += reference.title + ". ";
                            reference.formattedReference += '\a';
                            if (reference.volume.Length > 0 || reference.startPage.Length > 0)
                            {
                                reference.formattedReference += "(";
                            }
                            if (reference.volume.Length > 0)
                            {
                                reference.formattedReference += "Vol. " + reference.volume;
                                if (reference.startPage.Length > 0)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += "). ";
                                }
                            }
                            if (reference.startPage.Length < 1 && reference.endPage.Length > 0)
                            {
                                error = true;
                                errorMessage += "Enter a start page\n";
                            }
                            else if ((reference.startPage.Length > 0 && reference.endPage.Length > 0) &&
                                !reference.startPage.Equals(reference.endPage))
                            {
                                reference.formattedReference += "pp. " + reference.startPage + "-" + reference.endPage + "). ";
                            }
                            else if ((reference.startPage.Length > 0 && reference.endPage.Length < 1) ||
                                (reference.startPage.Equals(reference.endPage) && reference.startPage.Length > 0))
                            {
                                reference.formattedReference += "p. " + reference.startPage + "). ";
                            }
                            if (reference.publishLocation.Length > 0)
                            {
                                if (reference.publisher.Length > 0)
                                {
                                    reference.formattedReference += reference.publishLocation + ": ";
                                }
                                else
                                {
                                    reference.formattedReference += reference.publishLocation + ".";
                                }
                            }
                            if (reference.publisher.Length > 0)
                            {
                                reference.formattedReference += reference.publisher + ".";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the title of the Encyclopedia or Dictionary used\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the word or section referenced\n";
                    }
                }
                else
                {
                    if (reference.section.Length > 0)
                    {
                        reference.formattedReference += reference.section + ". ";
                        if (reference.publicationDate.Length < 1)
                        {
                            reference.formattedReference += "(n.d.). ";
                        }
                        else
                        {
                            reference.formattedReference += "(" + reference.publicationDate + "). ";
                        }
                   
                        reference.formattedReference += "In ";
                        if (reference.title.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            reference.formattedReference += reference.title + ". ";
                            reference.formattedReference += '\a';
                            if (reference.volume.Length > 0 || reference.startPage.Length > 0)
                            {
                                reference.formattedReference += "(";
                            }
                            if (reference.volume.Length > 0)
                            {
                                reference.formattedReference += "Vol. " + reference.volume;
                                if (reference.startPage.Length > 0)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += "). ";
                                }
                            }
                            if (reference.startPage.Length < 1 && reference.endPage.Length > 0)
                            {
                                error = true;
                                errorMessage += "Enter a start page\n";
                            }
                            else if ((reference.startPage.Length > 0 && reference.endPage.Length > 0) &&
                                !reference.startPage.Equals(reference.endPage))
                            {
                                reference.formattedReference += "pp. " + reference.startPage + "-" + reference.endPage + "). ";
                            }
                            else if ((reference.startPage.Length > 0 && reference.endPage.Length < 1) ||
                                (reference.startPage.Equals(reference.endPage) && reference.startPage.Length > 0))
                            {
                                reference.formattedReference += "p. " + reference.startPage + "). ";
                            }
                            if (reference.publishLocation.Length > 0)
                            {
                                if (reference.publisher.Length > 0)
                                {
                                    reference.formattedReference += reference.publishLocation + ": ";
                                }
                                else
                                {
                                    reference.formattedReference += reference.publishLocation + ".";
                                }
                            }
                            if (reference.publisher.Length > 0)
                            {
                                reference.formattedReference += reference.publisher + ".";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the title of the Encyclopedia or Dictionary used\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the word or section referenced\n";
                    }
                }
            }
            else if (translated.Checked)
            {
                reference.type = "translated";
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

                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox bookTitle = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = bookTitle.Text;
                TextBox publisher = (TextBox)Controls.Find("publisherEnter", true)[0];
                reference.publisher = publisher.Text;
                TextBox publishLocation = (TextBox)Controls.Find("publishLocationEnter", true)[0];
                reference.publishLocation = publishLocation.Text;
                TextBox originalPublishDate = (TextBox)Controls.Find("originalPublishDateEnter", true)[0];
                reference.originalPublishDate = originalPublishDate.Text;
                TextBox edition = (TextBox)Controls.Find("editionEnter", true)[0];
                reference.edition = edition.Text;

                reference.formattedReference = "";

                if (reference.authors.Count > 0)
                {
                    bool elipseAdded = false;
                    for (int i = 0; i < reference.authors.Count; i++)
                    {                        
                        if (i < 6 && i != reference.authors.Count - 1)
                        {
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName + ", ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ".";
                                if (reference.authors[i].middleName.Length < 1)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += " ";
                                }
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + "., ";
                            }
                        }
                        else if (i == reference.authors.Count - 1)
                        {
                            if (!elipseAdded && i > 0)
                            {
                                reference.formattedReference += "& ";
                            }
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName;
                                if (reference.authors[i].firstName.Length > 0 || reference.authors[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += ",";
                                }
                                reference.formattedReference += " ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ". ";
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + ". ";
                            }
                        }
                        else
                        {
                            if (!elipseAdded)
                            {
                                elipseAdded = true;
                                reference.formattedReference += ". . . ";
                            }
                        }
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        if (reference.edition.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            reference.formattedReference += " (" + reference.edition + " ed.). ";
                        }
                        else
                        {
                            reference.formattedReference += ". ";
                            reference.formattedReference += '\a';
                        }                        
                    }
                    if (reference.translators.Count > 0)
                    {
                        reference.formattedReference += "(";
                        elipseAdded = false;
                        for (int i = 0; i < reference.translators.Count; i++)
                        {                            
                            if (i < 6 && i != reference.translators.Count - 1)
                            {
                                if (reference.translators[i].firstName.Length > 0)
                                {
                                    reference.formattedReference += reference.translators[i].firstName[0].ToString().ToUpper() + ".";
                                    if (reference.translators[i].lastName.Length < 1 && reference.translators[i].middleName.Length < 1)
                                    {
                                        reference.formattedReference += ", ";
                                    }
                                    else
                                    {
                                        reference.formattedReference += " ";
                                    }
                                }
                                if (reference.translators[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += reference.translators[i].middleName[0].ToString().ToUpper() + ".";
                                    if (reference.translators[i].lastName.Length < 1)
                                    {
                                        reference.formattedReference += ", ";
                                    }
                                    else
                                    {
                                        reference.formattedReference += " ";
                                    }
                                }
                                if (reference.translators[i].lastName.Length > 0)
                                {
                                    reference.formattedReference += reference.translators[i].lastName + ", ";
                                }
                            }
                            else if (i == reference.translators.Count - 1)
                            {
                                if (!elipseAdded && i > 0)
                                {
                                    reference.formattedReference += "& ";
                                }
                                if (reference.translators[i].firstName.Length > 0)
                                {
                                    reference.formattedReference += reference.translators[i].firstName[0].ToString().ToUpper() + ".";
                                    if (reference.translators[i].middleName.Length > 0 || reference.translators[i].lastName.Length > 0)
                                    {
                                        reference.formattedReference += " ";
                                    }
                                }
                                if (reference.translators[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += reference.translators[i].middleName[0].ToString().ToUpper() + ".";
                                    if (reference.translators[i].lastName.Length > 0)
                                    {
                                        reference.formattedReference += " ";
                                    }
                                }
                                if (reference.translators[i].lastName.Length > 0)
                                {
                                    reference.formattedReference += reference.translators[i].lastName;
                                }
                                reference.formattedReference += ", Trans.). ";
                            }
                            else
                            {
                                if (!elipseAdded)
                                {
                                    elipseAdded = true;
                                    reference.formattedReference += ". . . ";
                                }
                            }
                        }
                        if (reference.publishLocation.Length > 0)
                        {
                            if (reference.publisher.Length > 0)
                            {
                                reference.formattedReference += reference.publishLocation + ": ";
                            }
                            else
                            {
                                reference.formattedReference += reference.publishLocation + ". ";
                            }
                        }
                        if (reference.publisher.Length > 0)
                        {
                            reference.formattedReference += reference.publisher + ". ";
                        }
                        if (reference.originalPublishDate.Length > 0)
                        {
                            reference.formattedReference += "(Original work published " + reference.originalPublishDate + ")";
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter an Original Publication Date\n";
                        }

                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter an translator\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter an author\n";
                }
            }
            else if (magazine.Checked)
            {
                reference.type = "magazine";
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
                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox articleTitle = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = articleTitle.Text;
                TextBox magazineTitle = (TextBox)Controls.Find("magazineNameEnter", true)[0];
                reference.source = magazineTitle.Text;
                TextBox volume = (TextBox)Controls.Find("volumeNumberEnter", true)[0];
                reference.volume = volume.Text;
                TextBox issue = (TextBox)Controls.Find("issueNumberEnter", true)[0];
                reference.issue = issue.Text;
                TextBox startPage = (TextBox)Controls.Find("pageStartEnter", true)[0];
                reference.startPage = startPage.Text;
                TextBox endPage = (TextBox)Controls.Find("pageEndEnter", true)[0];
                reference.endPage = endPage.Text;

                reference.formattedReference = "";

                if (reference.authors.Count > 0)
                {
                    for (int i = 0; i < reference.authors.Count; i++)
                    {
                        bool elipseAdded = false;
                        if (i < 6 && i != reference.authors.Count - 1)
                        {
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName + ", ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ".";
                                if (reference.authors[i].middleName.Length < 1)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += " ";
                                }
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + "., ";
                            }
                        }
                        else if (i == reference.authors.Count - 1)
                        {
                            if (!elipseAdded && i > 0)
                            {
                                reference.formattedReference += "& ";
                            }
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName;
                                if (reference.authors[i].firstName.Length > 0 || reference.authors[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += ",";
                                }
                                reference.formattedReference += " ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ". ";
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + ". ";
                            }
                        }
                        else
                        {
                            if (!elipseAdded)
                            {
                                elipseAdded = true;
                                reference.formattedReference += ". . . ";
                            }
                        }
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }                        
                        reference.formattedReference += ". ";   
                        if (reference.source.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            reference.formattedReference += reference.source;
                            if (reference.volume.Length > 0 || reference.issue.Length > 0 ||
                                reference.startPage.Length > 0)
                            {
                                reference.formattedReference += ", ";
                            }
                            if (reference.volume.Length > 0)
                            {
                                reference.formattedReference += reference.volume;
                            }
                            reference.formattedReference += '\a';
                            if (reference.issue.Length > 0)
                            {
                                reference.formattedReference += "(" + reference.issue + ")";
                            }
                            if ((reference.volume.Length > 0 || reference.issue.Length > 0) &&
                                reference.startPage.Length > 0)
                            {
                                reference.formattedReference += ", ";
                            }

                            if (reference.startPage.Length < 1 && reference.endPage.Length > 0)
                            {
                                error = true;
                                errorMessage += "Enter a start page\n";
                            }
                            else if ((reference.startPage.Length > 0 && reference.endPage.Length > 0) &&
                                !reference.startPage.Equals(reference.endPage))
                            {
                                reference.formattedReference += reference.startPage + "-" + reference.endPage;
                            }
                            else if ((reference.startPage.Length > 0 && reference.endPage.Length < 1) ||
                                (reference.startPage.Equals(reference.endPage) && reference.startPage.Length > 0))
                            {
                                reference.formattedReference += reference.startPage;
                            }
                            reference.formattedReference += ".";
                        }                       
                        else
                        {
                            error = true;
                            errorMessage += "Enter the Magazine Name\n";
                        }       
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter a title for the article\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter an author\n";
                }
            }
            else if (newspaper.Checked)
            {
                reference.type = "newspaper";
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
                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox articleTitle = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = articleTitle.Text;
                TextBox newspaperTitle = (TextBox)Controls.Find("newspaperNameEnter", true)[0];
                reference.source = newspaperTitle.Text;
                TextBox volume = (TextBox)Controls.Find("volumeNumberEnter", true)[0];
                reference.volume = volume.Text;
                TextBox issue = (TextBox)Controls.Find("issueNumberEnter", true)[0];
                reference.issue = issue.Text;
                TextBox startPage = (TextBox)Controls.Find("pageStartEnter", true)[0];
                reference.startPage = startPage.Text;
                TextBox endPage = (TextBox)Controls.Find("pageEndEnter", true)[0];
                reference.endPage = endPage.Text;

                reference.formattedReference = "";

                if (reference.authors.Count > 0)
                {
                    for (int i = 0; i < reference.authors.Count; i++)
                    {
                        bool elipseAdded = false;
                        if (i < 6 && i != reference.authors.Count - 1)
                        {
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName + ", ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ".";
                                if (reference.authors[i].middleName.Length < 1)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += " ";
                                }
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + "., ";
                            }
                        }
                        else if (i == reference.authors.Count - 1)
                        {
                            if (!elipseAdded && i > 0)
                            {
                                reference.formattedReference += "& ";
                            }
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName;
                                if (reference.authors[i].firstName.Length > 0 || reference.authors[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += ",";
                                }
                                reference.formattedReference += " ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ". ";
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + ". ";
                            }
                        }
                        else
                        {
                            if (!elipseAdded)
                            {
                                elipseAdded = true;
                                reference.formattedReference += ". . . ";
                            }
                        }
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        reference.formattedReference += ". ";
                        if (reference.source.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            reference.formattedReference += reference.source;
                            if (reference.volume.Length > 0 || reference.issue.Length > 0 ||
                                reference.startPage.Length > 0)
                            {
                                reference.formattedReference += ", ";
                            }
                            if (reference.volume.Length > 0)
                            {
                                reference.formattedReference += reference.volume;
                            }
                            reference.formattedReference += '\a';
                            if (reference.issue.Length > 0)
                            {
                                reference.formattedReference += "(" + reference.issue + ")";
                            }
                            if ((reference.volume.Length > 0 || reference.issue.Length > 0) &&
                                reference.startPage.Length > 0)
                            {
                                reference.formattedReference += ", ";
                            }

                            if (reference.startPage.Length < 1 && reference.endPage.Length > 0)
                            {
                                error = true;
                                errorMessage += "Enter a start page\n";
                            }
                            else if ((reference.startPage.Length > 0 && reference.endPage.Length > 0) &&
                                !reference.startPage.Equals(reference.endPage))
                            {
                                reference.formattedReference += "pp. " + reference.startPage + "-" + reference.endPage;
                            }
                            else if ((reference.startPage.Length > 0 && reference.endPage.Length < 1) ||
                                (reference.startPage.Equals(reference.endPage) && reference.startPage.Length > 0))
                            {
                                reference.formattedReference += "p. " + reference.startPage;
                            }
                            reference.formattedReference += ".";
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the Newspaper Name\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter a title for the article\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter an author\n";
                }
            }
            else if (journal.Checked)
            {
                reference.type = "journal";
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
                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox articleTitle = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = articleTitle.Text;
                TextBox journalTitle = (TextBox)Controls.Find("journalNameEnter", true)[0];
                reference.source = journalTitle.Text;
                TextBox volume = (TextBox)Controls.Find("volumeNumberEnter", true)[0];
                reference.volume = volume.Text;
                TextBox issue = (TextBox)Controls.Find("issueNumberEnter", true)[0];
                reference.issue = issue.Text;
                TextBox startPage = (TextBox)Controls.Find("pageStartEnter", true)[0];
                reference.startPage = startPage.Text;
                TextBox endPage = (TextBox)Controls.Find("pageEndEnter", true)[0];
                reference.endPage = endPage.Text;

                reference.formattedReference = "";

                if (reference.authors.Count > 0)
                {
                    for (int i = 0; i < reference.authors.Count; i++)
                    {
                        bool elipseAdded = false;
                        if (i < 6 && i != reference.authors.Count - 1)
                        {
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName + ", ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ".";
                                if (reference.authors[i].middleName.Length < 1)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += " ";
                                }
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + "., ";
                            }
                        }
                        else if (i == reference.authors.Count - 1)
                        {
                            if (!elipseAdded && i > 0)
                            {
                                reference.formattedReference += "& ";
                            }
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName;
                                if (reference.authors[i].firstName.Length > 0 || reference.authors[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += ",";
                                }
                                reference.formattedReference += " ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ". ";
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + ". ";
                            }
                        }
                        else
                        {
                            if (!elipseAdded)
                            {
                                elipseAdded = true;
                                reference.formattedReference += ". . . ";
                            }
                        }
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        reference.formattedReference += ". ";
                        if (reference.source.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            reference.formattedReference += reference.source;
                            if (reference.volume.Length > 0 || reference.issue.Length > 0 ||
                                reference.startPage.Length > 0)
                            {
                                reference.formattedReference += ", ";
                            }
                            if (reference.volume.Length > 0)
                            {
                                reference.formattedReference += reference.volume;
                            }
                            reference.formattedReference += '\a';
                            if (reference.issue.Length > 0)
                            {
                                reference.formattedReference += "(" + reference.issue + ")";
                            }
                            if ((reference.volume.Length > 0 || reference.issue.Length > 0) &&
                                reference.startPage.Length > 0)
                            {
                                reference.formattedReference += ", ";
                            }

                            if (reference.startPage.Length < 1 && reference.endPage.Length > 0)
                            {
                                error = true;
                                errorMessage += "Enter a start page\n";
                            }
                            else if ((reference.startPage.Length > 0 && reference.endPage.Length > 0) &&
                                !reference.startPage.Equals(reference.endPage))
                            {
                                reference.formattedReference += "pp. " + reference.startPage + "-" + reference.endPage;
                            }
                            else if ((reference.startPage.Length > 0 && reference.endPage.Length < 1) ||
                                (reference.startPage.Equals(reference.endPage) && reference.startPage.Length > 0))
                            {
                                reference.formattedReference += "p. " + reference.startPage;
                            }
                            reference.formattedReference += ".";
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the Journal Name\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter a title for the article\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter an author\n";
                }
            }
            else if (onlineJournal.Checked)
            {
                reference.type = "onlineJournal";
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
                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox articleTitle = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = articleTitle.Text;
                TextBox journalTitle = (TextBox)Controls.Find("journalNameEnter", true)[0];
                reference.source = journalTitle.Text;
                TextBox volume = (TextBox)Controls.Find("volumeNumberEnter", true)[0];
                reference.volume = volume.Text;
                TextBox issue = (TextBox)Controls.Find("issueNumberEnter", true)[0];
                reference.issue = issue.Text;
                TextBox startPage = (TextBox)Controls.Find("pageStartEnter", true)[0];
                reference.startPage = startPage.Text;
                TextBox endPage = (TextBox)Controls.Find("pageEndEnter", true)[0];
                reference.endPage = endPage.Text;
                TextBox retrieved = (TextBox)Controls.Find("retrievedFromEnter", true)[0];
                reference.retrievedFrom = retrieved.Text;
                TextBox doi = (TextBox)Controls.Find("doiEnter", true)[0];
                reference.doi = doi.Text;

                reference.formattedReference = "";

                if (reference.authors.Count > 0)
                {
                    for (int i = 0; i < reference.authors.Count; i++)
                    {
                        bool elipseAdded = false;
                        if (i < 6 && i != reference.authors.Count - 1)
                        {
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName + ", ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ".";
                                if (reference.authors[i].middleName.Length < 1)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += " ";
                                }
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + "., ";
                            }
                        }
                        else if (i == reference.authors.Count - 1)
                        {
                            if (!elipseAdded && i > 0)
                            {
                                reference.formattedReference += "& ";
                            }
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName;
                                if (reference.authors[i].firstName.Length > 0 || reference.authors[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += ",";
                                }
                                reference.formattedReference += " ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ". ";
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + ". ";
                            }
                        }
                        else
                        {
                            if (!elipseAdded)
                            {
                                elipseAdded = true;
                                reference.formattedReference += ". . . ";
                            }
                        }
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        reference.formattedReference += ". ";
                        if (reference.source.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            reference.formattedReference += reference.source;
                            if (reference.volume.Length > 0 || reference.issue.Length > 0 ||
                                reference.startPage.Length > 0)
                            {
                                reference.formattedReference += ", ";
                            }
                            if (reference.volume.Length > 0)
                            {
                                reference.formattedReference += reference.volume;
                            }
                            reference.formattedReference += '\a';
                            if (reference.issue.Length > 0)
                            {
                                reference.formattedReference += "(" + reference.issue + ")";
                            }
                            if ((reference.volume.Length > 0 || reference.issue.Length > 0) &&
                                reference.startPage.Length > 0)
                            {
                                reference.formattedReference += ", ";
                            }

                            if (reference.startPage.Length < 1 && reference.endPage.Length > 0)
                            {
                                error = true;
                                errorMessage += "Enter a start page\n";
                            }
                            else if ((reference.startPage.Length > 0 && reference.endPage.Length > 0) &&
                                !reference.startPage.Equals(reference.endPage))
                            {
                                reference.formattedReference += "pp. " + reference.startPage + "-" + reference.endPage;
                            }
                            else if ((reference.startPage.Length > 0 && reference.endPage.Length < 1) ||
                                (reference.startPage.Equals(reference.endPage) && reference.startPage.Length > 0))
                            {
                                reference.formattedReference += "p. " + reference.startPage;
                            }
                            reference.formattedReference += ". ";
                            if (reference.doi.Length > 0)
                            {
                                reference.formattedReference += "doi:" + reference.doi;
                            }
                            else if (reference.retrievedFrom.Length > 0)
                            {
                                reference.formattedReference += "Retrieved from " + reference.retrievedFrom;
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the Journal Name\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter a title for the article\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter an author\n";
                }
            }
            else if (onlinePeriodical.Checked)
            {
                reference.type = "onlineMagazine";
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
                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox articleTitle = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = articleTitle.Text;
                TextBox periodicalTitle = (TextBox)Controls.Find("periodicalNameEnter", true)[0];
                reference.source = periodicalTitle.Text;
                TextBox volume = (TextBox)Controls.Find("volumeNumberEnter", true)[0];
                reference.volume = volume.Text;
                TextBox issue = (TextBox)Controls.Find("issueNumberEnter", true)[0];
                reference.issue = issue.Text;
                TextBox startPage = (TextBox)Controls.Find("pageStartEnter", true)[0];
                reference.startPage = startPage.Text;
                TextBox endPage = (TextBox)Controls.Find("pageEndEnter", true)[0];
                reference.endPage = endPage.Text;
                TextBox retrieved = (TextBox)Controls.Find("retrievedFromEnter", true)[0];
                reference.retrievedFrom = retrieved.Text;
                TextBox doi = (TextBox)Controls.Find("doiEnter", true)[0];
                reference.doi = doi.Text;

                reference.formattedReference = "";

                if (reference.authors.Count > 0)
                {
                    for (int i = 0; i < reference.authors.Count; i++)
                    {
                        bool elipseAdded = false;
                        if (i < 6 && i != reference.authors.Count - 1)
                        {
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName + ", ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ".";
                                if (reference.authors[i].middleName.Length < 1)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += " ";
                                }
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + "., ";
                            }
                        }
                        else if (i == reference.authors.Count - 1)
                        {
                            if (!elipseAdded && i > 0)
                            {
                                reference.formattedReference += "& ";
                            }
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName;
                                if (reference.authors[i].firstName.Length > 0 || reference.authors[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += ",";
                                }
                                reference.formattedReference += " ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ". ";
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + ". ";
                            }
                        }
                        else
                        {
                            if (!elipseAdded)
                            {
                                elipseAdded = true;
                                reference.formattedReference += ". . . ";
                            }
                        }
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        reference.formattedReference += ". ";
                        if (reference.source.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            reference.formattedReference += reference.source;
                            if (reference.volume.Length > 0 || reference.issue.Length > 0 ||
                                reference.startPage.Length > 0)
                            {
                                reference.formattedReference += ", ";
                            }
                            if (reference.volume.Length > 0)
                            {
                                reference.formattedReference += reference.volume;
                            }
                            reference.formattedReference += '\a';
                            if (reference.issue.Length > 0)
                            {
                                reference.formattedReference += "(" + reference.issue + ")";
                            }
                            if ((reference.volume.Length > 0 || reference.issue.Length > 0) &&
                                reference.startPage.Length > 0)
                            {
                                reference.formattedReference += ", ";
                            }

                            if (reference.startPage.Length < 1 && reference.endPage.Length > 0)
                            {
                                error = true;
                                errorMessage += "Enter a start page\n";
                            }
                            else if ((reference.startPage.Length > 0 && reference.endPage.Length > 0) &&
                                !reference.startPage.Equals(reference.endPage))
                            {
                                reference.formattedReference += "pp. " + reference.startPage + "-" + reference.endPage;
                            }
                            else if ((reference.startPage.Length > 0 && reference.endPage.Length < 1) ||
                                (reference.startPage.Equals(reference.endPage) && reference.startPage.Length > 0))
                            {
                                reference.formattedReference += "p. " + reference.startPage;
                            }
                            reference.formattedReference += ". ";
                            if (reference.doi.Length > 0)
                            {
                                reference.formattedReference += "doi:" + reference.doi;
                            }
                            else if (reference.retrievedFrom.Length > 0)
                            {
                                reference.formattedReference += "Retrieved from " + reference.retrievedFrom;
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the Magazine Name\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter a title for the article\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter an author\n";
                }
            }
            else if (onlineNewspaper.Checked)
            {
                reference.type = "onlineNewspaper";
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
                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox articleTitle = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = articleTitle.Text;
                TextBox newspaperTitle = (TextBox)Controls.Find("newspaperNameEnter", true)[0];
                reference.source = newspaperTitle.Text;
                TextBox retrieved = (TextBox)Controls.Find("retrieveFromEnter", true)[0];
                reference.retrievedFrom = retrieved.Text;

                reference.formattedReference = "";

                if (reference.authors.Count > 0)
                {
                    for (int i = 0; i < reference.authors.Count; i++)
                    {
                        bool elipseAdded = false;
                        if (i < 6 && i != reference.authors.Count - 1)
                        {
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName + ", ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ".";
                                if (reference.authors[i].middleName.Length < 1)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += " ";
                                }
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + "., ";
                            }
                        }
                        else if (i == reference.authors.Count - 1)
                        {
                            if (!elipseAdded && i > 0)
                            {
                                reference.formattedReference += "& ";
                            }
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName;
                                if (reference.authors[i].firstName.Length > 0 || reference.authors[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += ",";
                                }
                                reference.formattedReference += " ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ". ";
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + ". ";
                            }
                        }
                        else
                        {
                            if (!elipseAdded)
                            {
                                elipseAdded = true;
                                reference.formattedReference += ". . . ";
                            }
                        }
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        reference.formattedReference += ". ";
                        if (reference.source.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            reference.formattedReference += reference.source;
                            reference.formattedReference += '\a';                            
                            reference.formattedReference += ". ";
                            if (reference.retrievedFrom.Length > 0)
                            {
                                reference.formattedReference += "Retrieved from " + reference.retrievedFrom;
                            }
                            else
                            {
                                error = true;
                                errorMessage += "Enter the URL where this article was found or switch to the \"Newspaper Article\" reference type";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the Newspaper Name\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter a title for the article\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter an author\n";
                }
            }
            else if (electronicBook.Checked)
            {
                reference.type = "electronicBook";
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
                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox bookTitle = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = bookTitle.Text;
                TextBox retrieved = (TextBox)Controls.Find("retrieveFromEnter", true)[0];
                reference.retrievedFrom = retrieved.Text;

                reference.formattedReference = "";

                if (reference.authors.Count > 0)
                {
                    for (int i = 0; i < reference.authors.Count; i++)
                    {
                        bool elipseAdded = false;
                        if (i < 6 && i != reference.authors.Count - 1)
                        {
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName + ", ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ".";
                                if (reference.authors[i].middleName.Length < 1)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += " ";
                                }
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + "., ";
                            }
                        }
                        else if (i == reference.authors.Count - 1)
                        {
                            if (!elipseAdded && i > 0)
                            {
                                reference.formattedReference += "& ";
                            }
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName;
                                if (reference.authors[i].firstName.Length > 0 || reference.authors[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += ",";
                                }
                                reference.formattedReference += " ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ". ";
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + ". ";
                            }
                        }
                        else
                        {
                            if (!elipseAdded)
                            {
                                elipseAdded = true;
                                reference.formattedReference += ". . . ";
                            }
                        }
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        reference.formattedReference += reference.title;
                        reference.formattedReference += '\a';
                        reference.formattedReference += ". ";
                        if (reference.retrievedFrom.Length > 0)
                        {
                            reference.formattedReference += "Retrieved from " + reference.retrievedFrom;
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the URL where this book was found or switch to the \"Book with Author\" reference type";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter a title for the book\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter an author\n";
                }
            }
            else if (kindle.Checked)
            {
                reference.type = "kindle";
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
                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox bookTitle = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = bookTitle.Text;
                TextBox doi = (TextBox)Controls.Find("doiEnter", true)[0];
                reference.doi = doi.Text;
                TextBox retrieved = (TextBox)Controls.Find("retrieveFromEnter", true)[0];
                reference.retrievedFrom = retrieved.Text;

                reference.formattedReference = "";

                if (reference.authors.Count > 0)
                {
                    for (int i = 0; i < reference.authors.Count; i++)
                    {
                        bool elipseAdded = false;
                        if (i < 6 && i != reference.authors.Count - 1)
                        {
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName + ", ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ".";
                                if (reference.authors[i].middleName.Length < 1)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += " ";
                                }
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + "., ";
                            }
                        }
                        else if (i == reference.authors.Count - 1)
                        {
                            if (!elipseAdded && i > 0)
                            {
                                reference.formattedReference += "& ";
                            }
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName;
                                if (reference.authors[i].firstName.Length > 0 || reference.authors[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += ",";
                                }
                                reference.formattedReference += " ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ". ";
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + ". ";
                            }
                        }
                        else
                        {
                            if (!elipseAdded)
                            {
                                elipseAdded = true;
                                reference.formattedReference += ". . . ";
                            }
                        }
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        reference.formattedReference += reference.title;
                        reference.formattedReference += '\a';
                        reference.formattedReference += " [Kindle DX version]. ";
                        if (reference.doi.Length > 0)
                        {
                            reference.formattedReference += "doi:" + reference.doi;
                        }
                        else if (reference.retrievedFrom.Length > 0)
                        {
                            reference.formattedReference += "Retrieved from " + reference.retrievedFrom;
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the URL where this book was found or the DOI";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter a title for the book\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter an author\n";
                }
            }
            else if (onlineBibliography.Checked)
            {
                reference.type = "onlineBibliography";
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
                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox bookTitle = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = bookTitle.Text;
                TextBox retrieved = (TextBox)Controls.Find("retrieveFromEnter", true)[0];
                reference.retrievedFrom = retrieved.Text;

                reference.formattedReference = "";

                if (reference.authors.Count > 0)
                {
                    for (int i = 0; i < reference.authors.Count; i++)
                    {
                        bool elipseAdded = false;
                        if (i < 6 && i != reference.authors.Count - 1)
                        {
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName + ", ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ".";
                                if (reference.authors[i].middleName.Length < 1)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += " ";
                                }
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + "., ";
                            }
                        }
                        else if (i == reference.authors.Count - 1)
                        {
                            if (!elipseAdded && i > 0)
                            {
                                reference.formattedReference += "& ";
                            }
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName;
                                if (reference.authors[i].firstName.Length > 0 || reference.authors[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += ",";
                                }
                                reference.formattedReference += " ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ". ";
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + ". ";
                            }
                        }
                        else
                        {
                            if (!elipseAdded)
                            {
                                elipseAdded = true;
                                reference.formattedReference += ". . . ";
                            }
                        }
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        reference.formattedReference += reference.title;
                        reference.formattedReference += '\a';
                        reference.formattedReference += ". ";
                        if (reference.retrievedFrom.Length > 0)
                        {
                            reference.formattedReference += "Retrieved from " + reference.retrievedFrom;
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the URL where this book was found or switch to the \"Book with Author\" reference type";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter a title for the book\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter an author\n";
                }
            }
            else if (onlineInterview.Checked)
            {
                reference.type = "onlineInterview";
                int numInterviewer = Convert.ToInt32(sourceInfoGroupBox.Tag.ToString().Split(',')[0]);
                int numinterviewee = Convert.ToInt32(sourceInfoGroupBox.Tag.ToString().Split(',')[2]);

                for (int i = 0; i < numInterviewer; i++)
                {
                    int index = i + 1;
                    Author author = new Author();
                    TextBox firstName = (TextBox)Controls.Find("interviewerFirstEnter" + index, true)[0];
                    TextBox middleName = (TextBox)Controls.Find("interviewerMiddleEnter" + index, true)[0];
                    TextBox lastName = (TextBox)Controls.Find("interviewerLastEnter" + index, true)[0];
                    author.firstName = firstName.Text;
                    author.middleName = middleName.Text;
                    author.lastName = lastName.Text;
                    if (author.firstName.Length > 0 || author.middleName.Length > 0 || author.lastName.Length > 0)
                    {
                        reference.interviewers.Add(author);
                    }
                }

                for (int i = 0; i < numinterviewee; i++)
                {
                    int index = i + 1;
                    Author author = new Author();
                    TextBox firstName = (TextBox)Controls.Find("intervieweeFirstEnter" + index, true)[0];
                    TextBox middleName = (TextBox)Controls.Find("intervieweeMiddleEnter" + index, true)[0];
                    TextBox lastName = (TextBox)Controls.Find("intervieweeLastEnter" + index, true)[0];
                    author.firstName = firstName.Text;
                    author.middleName = middleName.Text;
                    author.lastName = lastName.Text;
                    if (author.firstName.Length > 0 || author.middleName.Length > 0 || author.lastName.Length > 0)
                    {
                        reference.interviewees.Add(author);
                    }
                }
                TextBox interviewTitle = (TextBox)Controls.Find("interviewTitleEnter", true)[0];
                reference.title = interviewTitle.Text;
                TextBox interviewDate = (TextBox)Controls.Find("interviewDateEnter", true)[0];
                reference.interviewDate = interviewDate.Text;
                TextBox retrievedFrom = (TextBox)Controls.Find("retrieveFromEnter", true)[0];
                reference.retrievedFrom = retrievedFrom.Text;

                reference.formattedReference = "";

                if (reference.interviewers.Count > 0)
                {
                    bool elipseAdded = false;
                    for (int i = 0; i < reference.interviewers.Count; i++)
                    {
                        if (i < 6 && i != reference.interviewers.Count - 1)
                        {
                            if (reference.interviewers[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.interviewers[i].lastName + ", ";
                            }
                            if (reference.interviewers[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.interviewers[i].firstName[0].ToString().ToUpper() + ".";
                                if (reference.interviewers[i].middleName.Length < 1)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += " ";
                                }
                            }
                            if (reference.interviewers[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.interviewers[i].middleName[0].ToString().ToUpper() + "., ";
                            }
                        }
                        else if (i == reference.interviewers.Count - 1)
                        {
                            if (!elipseAdded && i > 0)
                            {
                                reference.formattedReference += "& ";
                            }
                            if (reference.interviewers[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.interviewers[i].lastName;
                                if (reference.interviewers[i].firstName.Length > 0 || reference.interviewers[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += ",";
                                }
                                reference.formattedReference += " ";
                            }
                            if (reference.interviewers[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.interviewers[i].firstName[0].ToString().ToUpper() + ". ";
                            }
                            if (reference.interviewers[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.interviewers[i].middleName[0].ToString().ToUpper() + ". ";
                            }
                        }
                        else
                        {
                            if (!elipseAdded)
                            {
                                elipseAdded = true;
                                reference.formattedReference += ". . . ";
                            }
                        }
                    }
                    if (reference.interviewers.Count > 1)
                    {
                        reference.formattedReference += "(Interviewers) & ";
                    }
                    else
                    {
                        reference.formattedReference += "(Interviewer) & ";
                    }                    
                    if (reference.interviewees.Count > 0)
                    {
                        elipseAdded = false;
                        for (int i = 0; i < reference.interviewees.Count; i++)
                        {
                            if (i < 6 && i != reference.interviewees.Count - 1)
                            {
                                if (reference.interviewees[i].lastName.Length > 0)
                                {
                                    reference.formattedReference += reference.interviewees[i].lastName + ", ";
                                }
                                if (reference.interviewees[i].firstName.Length > 0)
                                {
                                    reference.formattedReference += reference.interviewees[i].firstName[0].ToString().ToUpper() + ".";
                                    if (reference.interviewees[i].middleName.Length < 1)
                                    {
                                        reference.formattedReference += ", ";
                                    }
                                    else
                                    {
                                        reference.formattedReference += " ";
                                    }
                                }
                                if (reference.interviewees[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += reference.interviewees[i].middleName[0].ToString().ToUpper() + "., ";
                                }
                            }
                            else if (i == reference.interviewees.Count - 1)
                            {
                                if (!elipseAdded && i > 0)
                                {
                                    reference.formattedReference += "& ";
                                }
                                if (reference.interviewees[i].lastName.Length > 0)
                                {
                                    reference.formattedReference += reference.interviewees[i].lastName;
                                    if (reference.interviewees[i].firstName.Length > 0 || reference.interviewees[i].middleName.Length > 0)
                                    {
                                        reference.formattedReference += ",";
                                    }
                                    reference.formattedReference += " ";
                                }
                                if (reference.interviewees[i].firstName.Length > 0)
                                {
                                    reference.formattedReference += reference.interviewees[i].firstName[0].ToString().ToUpper() + ". ";
                                }
                                if (reference.interviewees[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += reference.interviewees[i].middleName[0].ToString().ToUpper() + ". ";
                                }
                            }
                            else
                            {
                                if (!elipseAdded)
                                {
                                    elipseAdded = true;
                                    reference.formattedReference += ". . . ";
                                }
                            }
                        }
                        if (reference.interviewers.Count > 1)
                        {
                            reference.formattedReference += "(Interviewees). ";
                        }
                        else
                        {
                            reference.formattedReference += "(Interviewee). ";
                        }
                        if (reference.interviewDate.Length < 1)
                        {
                            reference.formattedReference += "(n.d.). ";
                        }
                        else
                        {
                            reference.formattedReference += "(" + reference.interviewDate + "). ";
                        }
                        if (reference.title.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            bool nextCapital = true;
                            for (int i = 0; i < reference.title.Length; i++)
                            {
                                if (nextCapital)
                                {
                                    if (!reference.title[i].ToString().Equals(" "))
                                    {
                                        nextCapital = false;
                                    }
                                    reference.formattedReference += reference.title[i].ToString().ToUpper();
                                }
                                else
                                {
                                    reference.formattedReference += reference.title[i].ToString().ToLower();
                                }
                                if (reference.title[i].ToString().Equals(":"))
                                {
                                    nextCapital = true;
                                }
                            }
                            reference.formattedReference += '\a';
                            reference.formattedReference += " [Interview Transcript]. ";                                                        
                        }                    
                        if (reference.retrievedFrom.Length > 0)
                        {
                            reference.formattedReference += "Retrieved from " + reference.retrievedFrom;
                        }                        
                        else
                        {
                            error = true;
                            errorMessage += "Enter where the interview was retrieved from\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter an interviewee\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter an interviewer\n";
                }
            }
            else if (onlineEncyclopedia.Checked)
            {
                reference.type = "onlineDictionEncyclo";

                TextBox term = (TextBox)Controls.Find("sectionNameEnter", true)[0];
                reference.section = term.Text;
                TextBox publishDate = (TextBox)Controls.Find("publicationDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox encyclopediaName = (TextBox)Controls.Find("nameEnter", true)[0];
                reference.title = encyclopediaName.Text;
                TextBox retrievedFrom = (TextBox)Controls.Find("retrievedFromEnter", true)[0];
                reference.retrievedFrom = retrievedFrom.Text;

                reference.formattedReference = "";

                if (reference.section.Length > 0)
                {
                    reference.formattedReference += reference.section + ". ";
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    reference.formattedReference += "In ";
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        reference.formattedReference += reference.title;
                        reference.formattedReference += '\a';
                        reference.formattedReference += ". ";
                        if (reference.retrievedFrom.Length > 0)
                        {
                            reference.formattedReference += "Retrieved from " + reference.retrievedFrom;
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the URL where the reference was retrieved\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the name of the encyclopedia or dictionary\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the word referenced in the encyclopedia or dictionary\n";
                }
            }
            else if (forumDiscussion.Checked)
            {
                reference.type = "forumDiscussion";

                Author author = new Author();
                TextBox posterFirst = (TextBox)Controls.Find("posterFirstEnter", true)[0];
                author.firstName = posterFirst.Text;
                TextBox posterMiddle = (TextBox)Controls.Find("posterMiddleEnter", true)[0];
                author.middleName = posterMiddle.Text;
                TextBox posterLast = (TextBox)Controls.Find("posterLastEnter", true)[0];
                author.lastName = posterLast.Text;
                reference.authors.Add(author);
                TextBox postDate = (TextBox)Controls.Find("postDateEnter", true)[0];
                reference.publicationDate = postDate.Text;
                TextBox messageTitle = (TextBox)Controls.Find("messageTitleEnter", true)[0];
                reference.title = messageTitle.Text;
                TextBox messageNumber = (TextBox)Controls.Find("messageNumberEnter", true)[0];
                reference.number = messageNumber.Text;
                TextBox retrievedFrom = (TextBox)Controls.Find("retrieveFromEnter", true)[0];
                reference.retrievedFrom = retrievedFrom.Text;

                if (reference.authors.Count > 0)
                {                   
                    if (reference.authors[0].lastName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[0].lastName;
                        if (reference.authors[0].firstName.Length > 0 || reference.authors[0].middleName.Length > 0)
                        {
                            reference.formattedReference += ",";
                        }
                        reference.formattedReference += " ";
                    }
                    if (reference.authors[0].firstName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[0].firstName[0].ToString().ToUpper() + ". ";
                    }
                    if (reference.authors[0].middleName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[0].middleName[0].ToString().ToUpper() + ". ";
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        if (reference.number.Length > 0)
                        {
                            reference.formattedReference += " [Msg " + reference.number + "]";
                        }
                        reference.formattedReference += ". Message posted to ";
                        if (reference.retrievedFrom.Length > 0)
                        {
                            reference.formattedReference += reference.retrievedFrom;
                        }   
                        else
                        {
                            error = true;
                            errorMessage += "Enter the URL where the post was retrieved\n";
                        }
                     
                           
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the tile of the post\n";
                    }

                }
                else
                {
                    error = true;
                    errorMessage += "Enter the name of the person posting\n";
                }
            }
            else if (bookReview.Checked)
            {
                reference.type = "onlineBookReview";
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
                TextBox publishDate = (TextBox)Controls.Find("publicationDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox reviewTitle = (TextBox)Controls.Find("reviewTitleEnter", true)[0];
                reference.reviewTitle = reviewTitle.Text;
                TextBox title = (TextBox)Controls.Find("reviewedEnter", true)[0];
                reference.title = title.Text;
                TextBox source = (TextBox)Controls.Find("sourceReviewingEnter", true)[0];
                reference.source = source.Text;
                TextBox volume = (TextBox)Controls.Find("volumeEnter", true)[0];
                reference.volume = volume.Text;
                TextBox issue = (TextBox)Controls.Find("issueEnter", true)[0];
                reference.issue = issue.Text;
                TextBox startPage = (TextBox)Controls.Find("pageStartEnter", true)[0];
                reference.startPage = startPage.Text;
                TextBox endPage = (TextBox)Controls.Find("pageEndEnter", true)[0];
                reference.endPage = endPage.Text;
                TextBox retrieved = (TextBox)Controls.Find("retrievedFromEnter", true)[0];
                reference.retrievedFrom = retrieved.Text;

                if (reference.authors.Count > 0)
                {
                    for (int i = 0; i < reference.authors.Count; i++)
                    {
                        bool elipseAdded = false;
                        if (i < 6 && i != reference.authors.Count - 1)
                        {
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName + ", ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ".";
                                if (reference.authors[i].middleName.Length < 1)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += " ";
                                }
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + "., ";
                            }
                        }
                        else if (i == reference.authors.Count - 1)
                        {
                            if (!elipseAdded && i > 0)
                            {
                                reference.formattedReference += "& ";
                            }
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName;
                                if (reference.authors[i].firstName.Length > 0 || reference.authors[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += ",";
                                }
                                reference.formattedReference += " ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ". ";
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + ". ";
                            }
                        }
                        else
                        {
                            if (!elipseAdded)
                            {
                                elipseAdded = true;
                                reference.formattedReference += ". . . ";
                            }
                        }
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.reviewTitle.Length > 0)
                    {
                        bool nextCapital = true;
                        for (int i = 0; i < reference.reviewTitle.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.reviewTitle[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.reviewTitle[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.reviewTitle[i].ToString().ToLower();
                            }
                            if (reference.reviewTitle[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        reference.formattedReference += " [Review of the book ";
                        if (reference.title.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            nextCapital = true;
                            for (int i = 0; i < reference.title.Length; i++)
                            {
                                if (nextCapital)
                                {
                                    if (!reference.title[i].ToString().Equals(" "))
                                    {
                                        nextCapital = false;
                                    }
                                    reference.formattedReference += reference.title[i].ToString().ToUpper();
                                }
                                else
                                {
                                    reference.formattedReference += reference.title[i].ToString().ToLower();
                                }
                                if (reference.title[i].ToString().Equals(":"))
                                {
                                    nextCapital = true;
                                }
                            }
                            reference.formattedReference += '\a';
                            reference.formattedReference += "]. ";
                            reference.formattedReference += '\a';
                            reference.formattedReference += reference.source;
                            if (reference.volume.Length > 0 || reference.issue.Length > 0 ||
                                reference.startPage.Length > 0)
                            {
                                reference.formattedReference += ", ";
                            }
                            if (reference.volume.Length > 0)
                            {
                                reference.formattedReference += reference.volume;
                            }
                            reference.formattedReference += '\a';
                            if (reference.issue.Length > 0)
                            {
                                reference.formattedReference += "(" + reference.issue + ")";
                            }
                            if ((reference.volume.Length > 0 || reference.issue.Length > 0) &&
                                reference.startPage.Length > 0)
                            {
                                reference.formattedReference += ", ";
                            }

                            if (reference.startPage.Length < 1 && reference.endPage.Length > 0)
                            {
                                error = true;
                                errorMessage += "Enter a start page\n";
                            }
                            else if ((reference.startPage.Length > 0 && reference.endPage.Length > 0) &&
                                !reference.startPage.Equals(reference.endPage))
                            {
                                reference.formattedReference += "pp. " + reference.startPage + "-" + reference.endPage;
                            }
                            else if ((reference.startPage.Length > 0 && reference.endPage.Length < 1) ||
                                (reference.startPage.Equals(reference.endPage) && reference.startPage.Length > 0))
                            {
                                reference.formattedReference += "p. " + reference.startPage;
                            }
                            reference.formattedReference += ". ";
                            if (reference.retrievedFrom.Length > 0)
                            {
                                reference.formattedReference += "Retrieved from " + reference.retrievedFrom;
                            }
                            else
                            {
                                error = true;
                                errorMessage += "Enter the URL where the review was obtained\n";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the name of the source for this review\n";
                        }                         
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the Title of the Review\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the Author\n";
                }
            }
            else if (blog.Checked)
            {
                reference.type = "blog";

                Author author = new Author();
                TextBox authorFirst = (TextBox)Controls.Find("authorFirstEnter", true)[0];
                author.firstName = authorFirst.Text;
                TextBox authorMiddle = (TextBox)Controls.Find("authorMiddleEnter", true)[0];
                author.middleName = authorMiddle.Text;
                TextBox authorLast = (TextBox)Controls.Find("authorLastEnter", true)[0];
                author.lastName = authorLast.Text;
                reference.authors.Add(author);
                TextBox postDate = (TextBox)Controls.Find("postDateEnter", true)[0];
                reference.publicationDate = postDate.Text;
                TextBox messageTitle = (TextBox)Controls.Find("messageTitleEnter", true)[0];
                reference.title = messageTitle.Text;
                TextBox type = (TextBox)Controls.Find("typeEnter", true)[0];
                reference.type = type.Text;
                TextBox retrievedFrom = (TextBox)Controls.Find("retrievedFromEnter", true)[0];
                reference.retrievedFrom = retrievedFrom.Text;

                if (reference.authors.Count > 0)
                {
                    if (reference.authors[0].lastName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[0].lastName;
                        if (reference.authors[0].firstName.Length > 0 || reference.authors[0].middleName.Length > 0)
                        {
                            reference.formattedReference += ",";
                        }
                        reference.formattedReference += " ";
                    }
                    if (reference.authors[0].firstName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[0].firstName[0].ToString().ToUpper() + ". ";
                    }
                    if (reference.authors[0].middleName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[0].middleName[0].ToString().ToUpper() + ". ";
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        if (reference.type.Length > 0)
                        {
                            reference.formattedReference += " [" + reference.type + "]";
                            reference.formattedReference += ". Retrieved from ";
                            if (reference.retrievedFrom.Length > 0)
                            {
                                reference.formattedReference += reference.retrievedFrom;
                            }
                            else
                            {
                                error = true;
                                errorMessage += "Enter the URL where the post was retrieved\n";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the kind of source being referenced\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the tile of the post\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the name of the person posting\n";
                }

            }
            else if (wiki.Checked)
            {
                reference.type = "wiki";

                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox postDate = (TextBox)Controls.Find("postDateEnter", true)[0];
                reference.publicationDate = postDate.Text;
                TextBox retrieveDate = (TextBox)Controls.Find("retrievedDateEnter", true)[0];
                reference.retrieveDate = retrieveDate.Text;
                TextBox retrievedFrom = (TextBox)Controls.Find("retrievedFromEnter", true)[0];
                reference.retrievedFrom = retrievedFrom.Text;

                if (reference.title.Length > 0)
                {
                    reference.formattedReference += reference.title + ". ";
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    reference.formattedReference += "Retrieved ";
                    if (reference.retrieveDate.Length > 0)
                    {
                        reference.formattedReference += reference.retrieveDate + " ";
                        if (reference.retrievedFrom.Length > 0)
                        {
                            reference.formattedReference += "from " + reference.retrievedFrom;
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the URL where the reference was found\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the date the source was viewed\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the title of the wiki\n";
                }
            }
            else if (webDoc.Checked)
            {
                reference.type = "webDoc";

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
                TextBox publishDate = (TextBox)Controls.Find("publicationDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox retrieved = (TextBox)Controls.Find("retrievedFromEnter", true)[0];
                reference.retrievedFrom = retrieved.Text;

                if (reference.authors.Count > 0)
                {
                    for (int i = 0; i < reference.authors.Count; i++)
                    {
                        bool elipseAdded = false;
                        if (i < 6 && i != reference.authors.Count - 1)
                        {
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName + ", ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ".";
                                if (reference.authors[i].middleName.Length < 1)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += " ";
                                }
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + "., ";
                            }
                        }
                        else if (i == reference.authors.Count - 1)
                        {
                            if (!elipseAdded && i > 0)
                            {
                                reference.formattedReference += "& ";
                            }
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName;
                                if (reference.authors[i].firstName.Length > 0 || reference.authors[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += ",";
                                }
                                reference.formattedReference += " ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ". ";
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + ". ";
                            }
                        }
                        else
                        {
                            if (!elipseAdded)
                            {
                                elipseAdded = true;
                                reference.formattedReference += ". . . ";
                            }
                        }
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        reference.formattedReference += '\a';
                        reference.formattedReference += ". ";
                        if (reference.retrievedFrom.Length > 0)
                        {
                            reference.formattedReference += "Retrieved from " + reference.retrievedFrom;
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the URL where the document was viewed\n";
                        }                        
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the tile\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the Author\n";
                }
            }
            else if (onlineDissertation.Checked)
            {
                reference.type = "onlineDiss";

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
                TextBox publishDate = (TextBox)Controls.Find("publicationDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox retrieved = (TextBox)Controls.Find("retrievedFromEnter", true)[0];
                reference.retrievedFrom = retrieved.Text;

                if (reference.authors.Count > 0)
                {
                    for (int i = 0; i < reference.authors.Count; i++)
                    {
                        bool elipseAdded = false;
                        if (i < 6 && i != reference.authors.Count - 1)
                        {
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName + ", ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ".";
                                if (reference.authors[i].middleName.Length < 1)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += " ";
                                }
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + "., ";
                            }
                        }
                        else if (i == reference.authors.Count - 1)
                        {
                            if (!elipseAdded && i > 0)
                            {
                                reference.formattedReference += "& ";
                            }
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName;
                                if (reference.authors[i].firstName.Length > 0 || reference.authors[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += ",";
                                }
                                reference.formattedReference += " ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ". ";
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + ". ";
                            }
                        }
                        else
                        {
                            if (!elipseAdded)
                            {
                                elipseAdded = true;
                                reference.formattedReference += ". . . ";
                            }
                        }
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        reference.formattedReference += '\a';
                        reference.formattedReference += ". ";
                        if (reference.retrievedFrom.Length > 0)
                        {
                            reference.formattedReference += "Retrieved from " + reference.retrievedFrom;
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the URL where the document was viewed\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the tile\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the Author\n";
                }
            }
            else if (publishedDissertation.Checked)
            {
                reference.type = "publishedDiss";

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
                TextBox publishDate = (TextBox)Controls.Find("publicationDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox source = (TextBox)Controls.Find("sourceEnter", true)[0];
                reference.source = source.Text;
                TextBox accession = (TextBox)Controls.Find("accessionEnter", true)[0];
                reference.accession = accession.Text;

                if (reference.authors.Count > 0)
                {
                    for (int i = 0; i < reference.authors.Count; i++)
                    {
                        bool elipseAdded = false;
                        if (i < 6 && i != reference.authors.Count - 1)
                        {
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName + ", ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ".";
                                if (reference.authors[i].middleName.Length < 1)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += " ";
                                }
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + "., ";
                            }
                        }
                        else if (i == reference.authors.Count - 1)
                        {
                            if (!elipseAdded && i > 0)
                            {
                                reference.formattedReference += "& ";
                            }
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName;
                                if (reference.authors[i].firstName.Length > 0 || reference.authors[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += ",";
                                }
                                reference.formattedReference += " ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ". ";
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + ". ";
                            }
                        }
                        else
                        {
                            if (!elipseAdded)
                            {
                                elipseAdded = true;
                                reference.formattedReference += ". . . ";
                            }
                        }
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        reference.formattedReference += '\a';
                        reference.formattedReference += " (Doctoral dissertation). ";
                        if (reference.source.Length > 0)
                        {
                            reference.formattedReference += "Retrieved from " + reference.source + ". ";
                        }
                        if (reference.accession.Length > 0)
                        {
                            reference.formattedReference += "(" + reference.accession + ")";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the tile\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the Author\n";
                }
            }
            else if (unpublishedDissertation.Checked)
            {
                reference.type = "unpublishedDiss";

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
                TextBox publishDate = (TextBox)Controls.Find("publicationDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox institution = (TextBox)Controls.Find("institutionNameEnter", true)[0];
                reference.institution = institution.Text;
                TextBox location = (TextBox)Controls.Find("locationEnter", true)[0];
                reference.location = location.Text;

                if (reference.authors.Count > 0)
                {
                    for (int i = 0; i < reference.authors.Count; i++)
                    {
                        bool elipseAdded = false;
                        if (i < 6 && i != reference.authors.Count - 1)
                        {
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName + ", ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ".";
                                if (reference.authors[i].middleName.Length < 1)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += " ";
                                }
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + "., ";
                            }
                        }
                        else if (i == reference.authors.Count - 1)
                        {
                            if (!elipseAdded && i > 0)
                            {
                                reference.formattedReference += "& ";
                            }
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName;
                                if (reference.authors[i].firstName.Length > 0 || reference.authors[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += ",";
                                }
                                reference.formattedReference += " ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ". ";
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + ". ";
                            }
                        }
                        else
                        {
                            if (!elipseAdded)
                            {
                                elipseAdded = true;
                                reference.formattedReference += ". . . ";
                            }
                        }
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        reference.formattedReference += '\a';
                        reference.formattedReference += " (Unpublished dissertation). ";
                        if (reference.institution.Length > 0)
                        {
                            reference.formattedReference += reference.institution;
                            if (reference.location.Length > 0)
                            {
                                reference.formattedReference += ", " + reference.location + ".";
                            }
                            else
                            {
                                error = true;
                                errorMessage += "Enter the location of the institution that has the dissertation\n";
                            }                        
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the name of the institution that has the dissertation\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the tile\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the Author\n";
                }
            }
            else if (governmentDocument.Checked)
            {
                TextBox organization = (TextBox)Controls.Find("authorEnter", true)[0];
                reference.organization = organization.Text;
                TextBox publicationDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publicationDate.Text;
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox publicationNumber = (TextBox)Controls.Find("publicationNumberEnter", true)[0];
                reference.number = publicationNumber.Text;
                TextBox publisher = (TextBox)Controls.Find("publisherEnter", true)[0];
                reference.publisher = publisher.Text;
                TextBox publishLocation = (TextBox)Controls.Find("publishLocationEnter", true)[0];
                reference.publishLocation = publishLocation.Text;
                if (reference.organization.Length > 0)
                {
                    reference.formattedReference += reference.organization + ". ";
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        reference.formattedReference += '\a';
                        if (reference.number.Length > 0)
                        {
                            reference.formattedReference += " (Publication no. " + reference.number + ")";
                        }
                        reference.formattedReference += ". ";
                        if (reference.publishLocation.Length > 0)
                        {
                            if (reference.publisher.Length > 0)
                            {
                                reference.formattedReference += reference.publishLocation + ": ";
                            }
                            else
                            {
                                reference.formattedReference += reference.publishLocation + ".";
                            }
                        }
                        if (reference.publisher.Length > 0)
                        {
                            reference.formattedReference += reference.publisher + ".";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the tile\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the name of the government organization that produced this document\n";
                }
            }
            else if (review.Checked)
            {
                reference.type = "review";
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
                TextBox publishDate = (TextBox)Controls.Find("publishDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox reviewTitle = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.reviewTitle = reviewTitle.Text;
                TextBox title = (TextBox)Controls.Find("reviewedTitleEnter", true)[0];
                reference.title = title.Text;
                TextBox source = (TextBox)Controls.Find("sourceEnter", true)[0];
                reference.source = source.Text;
                TextBox volume = (TextBox)Controls.Find("volumeEnter", true)[0];
                reference.volume = volume.Text;
                TextBox issue = (TextBox)Controls.Find("issueEnter", true)[0];
                reference.issue = issue.Text;
                TextBox startPage = (TextBox)Controls.Find("pageStartEnter", true)[0];
                reference.startPage = startPage.Text;
                TextBox endPage = (TextBox)Controls.Find("pageEndEnter", true)[0];
                reference.endPage = endPage.Text;

                if (reference.reviewers.Count > 0)
                {
                    for (int i = 0; i < reference.reviewers.Count; i++)
                    {
                        bool elipseAdded = false;
                        if (i < 6 && i != reference.reviewers.Count - 1)
                        {
                            if (reference.reviewers[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.reviewers[i].lastName + ", ";
                            }
                            if (reference.reviewers[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.reviewers[i].firstName[0].ToString().ToUpper() + ".";
                                if (reference.reviewers[i].middleName.Length < 1)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += " ";
                                }
                            }
                            if (reference.reviewers[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.reviewers[i].middleName[0].ToString().ToUpper() + "., ";
                            }
                        }
                        else if (i == reference.reviewers.Count - 1)
                        {
                            if (!elipseAdded && i > 0)
                            {
                                reference.formattedReference += "& ";
                            }
                            if (reference.reviewers[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.reviewers[i].lastName;
                                if (reference.reviewers[i].firstName.Length > 0 || reference.reviewers[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += ",";
                                }
                                reference.formattedReference += " ";
                            }
                            if (reference.reviewers[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.reviewers[i].firstName[0].ToString().ToUpper() + ". ";
                            }
                            if (reference.reviewers[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.reviewers[i].middleName[0].ToString().ToUpper() + ". ";
                            }
                        }
                        else
                        {
                            if (!elipseAdded)
                            {
                                elipseAdded = true;
                                reference.formattedReference += ". . . ";
                            }
                        }
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.reviewTitle.Length > 0)
                    {
                        bool nextCapital = true;
                        for (int i = 0; i < reference.reviewTitle.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.reviewTitle[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.reviewTitle[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.reviewTitle[i].ToString().ToLower();
                            }
                            if (reference.reviewTitle[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        reference.formattedReference += " [Review of the book ";
                        if (reference.title.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            nextCapital = true;
                            for (int i = 0; i < reference.title.Length; i++)
                            {
                                if (nextCapital)
                                {
                                    if (!reference.title[i].ToString().Equals(" "))
                                    {
                                        nextCapital = false;
                                    }
                                    reference.formattedReference += reference.title[i].ToString().ToUpper();
                                }
                                else
                                {
                                    reference.formattedReference += reference.title[i].ToString().ToLower();
                                }
                                if (reference.title[i].ToString().Equals(":"))
                                {
                                    nextCapital = true;
                                }
                            }
                            reference.formattedReference += '\a';
                            if (reference.authors.Count > 0)
                            {
                                reference.formattedReference += ", by ";
                                for (int i = 0; i < reference.authors.Count; i++)
                                {
                                    bool elipseAdded = false;
                                    if (i < 6 && i != reference.authors.Count - 1)
                                    {
                                        if (reference.authors[i].firstName.Length > 0)
                                        {
                                            reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ".";
                                            if (reference.authors[i].lastName.Length < 1 && reference.authors[i].middleName.Length < 1)
                                            {
                                                reference.formattedReference += ", ";
                                            }
                                            else
                                            {
                                                reference.formattedReference += " ";
                                            }
                                        }
                                        if (reference.authors[i].middleName.Length > 0)
                                        {
                                            reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + ".";
                                            if (reference.authors[i].lastName.Length < 1)
                                            {
                                                reference.formattedReference += ", ";
                                            }
                                            else
                                            {
                                                reference.formattedReference += " ";
                                            }
                                        }
                                        if (reference.authors[i].lastName.Length > 0)
                                        {
                                            reference.formattedReference += reference.authors[i].lastName + ", ";
                                        }
                                    }
                                    else if (i == reference.authors.Count - 1)
                                    {
                                        if (!elipseAdded && i > 0)
                                        {
                                            reference.formattedReference += "& ";
                                        }
                                        if (reference.authors[i].firstName.Length > 0)
                                        {
                                            reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ".";
                                            if (reference.authors[i].lastName.Length > 0 || reference.authors[i].middleName.Length > 0)
                                            {
                                                reference.formattedReference += " ";
                                            }
                                        }
                                        if (reference.authors[i].middleName.Length > 0)
                                        {
                                            reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + ".";
                                            if (reference.authors[i].lastName.Length > 0)
                                            {
                                                reference.formattedReference += " ";
                                            }
                                        }
                                        if (reference.authors[i].lastName.Length > 0)
                                        {
                                            reference.formattedReference += reference.authors[i].lastName;
                                        }
                                    }
                                    else
                                    {
                                        if (!elipseAdded)
                                        {
                                            elipseAdded = true;
                                            reference.formattedReference += ". . . ";
                                        }
                                    }
                                }
                                reference.formattedReference += "]. ";
                                reference.formattedReference += '\a';
                                reference.formattedReference += reference.source;
                                if (reference.volume.Length > 0 || reference.issue.Length > 0 ||
                                    reference.startPage.Length > 0)
                                {
                                    reference.formattedReference += ", ";
                                }
                                if (reference.volume.Length > 0)
                                {
                                    reference.formattedReference += reference.volume;
                                }
                                reference.formattedReference += '\a';
                                if (reference.issue.Length > 0)
                                {
                                    reference.formattedReference += "(" + reference.issue + ")";
                                }
                                if ((reference.volume.Length > 0 || reference.issue.Length > 0) &&
                                    reference.startPage.Length > 0)
                                {
                                    reference.formattedReference += ", ";
                                }

                                if (reference.startPage.Length < 1 && reference.endPage.Length > 0)
                                {
                                    error = true;
                                    errorMessage += "Enter a start page\n";
                                }
                                else if ((reference.startPage.Length > 0 && reference.endPage.Length > 0) &&
                                    !reference.startPage.Equals(reference.endPage))
                                {
                                    reference.formattedReference += reference.startPage + "-" + reference.endPage;
                                }
                                else if ((reference.startPage.Length > 0 && reference.endPage.Length < 1) ||
                                    (reference.startPage.Equals(reference.endPage) && reference.startPage.Length > 0))
                                {
                                    reference.formattedReference += reference.startPage;
                                }
                                reference.formattedReference += ". ";
                            }
                            else
                            {
                                error = true;
                                errorMessage += "Enter the Author\n";
                            }                            
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the name of the source for this review\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the Title of the Review\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the Reviewer\n";
                }
            }
            else if (lectureNotesSlides.Checked)
            {
                reference.type = "lecture";

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
                TextBox publishDate = (TextBox)Controls.Find("publicationDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox format = (TextBox)Controls.Find("formatEnter", true)[0];
                reference.type = format.Text;                
                TextBox retrievedFrom = (TextBox)Controls.Find("retrievedFromEnter", true)[0];
                reference.retrievedFrom = retrievedFrom.Text;

                if (reference.authors.Count > 0)
                {
                    for (int i = 0; i < reference.authors.Count; i++)
                    {
                        bool elipseAdded = false;
                        if (i < 6 && i != reference.authors.Count - 1)
                        {
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName + ", ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ".";
                                if (reference.authors[i].middleName.Length < 1)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += " ";
                                }
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + "., ";
                            }
                        }
                        else if (i == reference.authors.Count - 1)
                        {
                            if (!elipseAdded && i > 0)
                            {
                                reference.formattedReference += "& ";
                            }
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName;
                                if (reference.authors[i].firstName.Length > 0 || reference.authors[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += ",";
                                }
                                reference.formattedReference += " ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ". ";
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + ". ";
                            }
                        }
                        else
                        {
                            if (!elipseAdded)
                            {
                                elipseAdded = true;
                                reference.formattedReference += ". . . ";
                            }
                        }
                    }
                    if (reference.publicationDate.Length > 0)
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        reference.formattedReference += '\a';
                        if (reference.type.Length > 0)
                        {
                            reference.formattedReference += " [" + reference.type + "]. ";
                            if (reference.retrievedFrom.Length > 0)
                            {
                                reference.formattedReference += "Retrieved from " + reference.retrievedFrom;
                            }
                            else
                            {
                                error = true;
                                errorMessage += "Enter the URL where the presentation was viewed\n";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the file format of the presentation\n";
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
            else if (audioPodcast.Checked)
            {
                reference.type = "audioPodcast";

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
                TextBox publishDate = (TextBox)Controls.Find("publicationDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox host = (TextBox)Controls.Find("hostEnter", true)[0];
                reference.source = host.Text;
                TextBox retrievedFrom = (TextBox)Controls.Find("retrievedFromEnter", true)[0];
                reference.retrievedFrom = retrievedFrom.Text;

                if (reference.authors.Count > 0)
                {
                    for (int i = 0; i < reference.authors.Count; i++)
                    {
                        bool elipseAdded = false;
                        if (i < 6 && i != reference.authors.Count - 1)
                        {
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName + ", ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ".";
                                if (reference.authors[i].middleName.Length < 1)
                                {
                                    reference.formattedReference += ", ";
                                }
                                else
                                {
                                    reference.formattedReference += " ";
                                }
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + "., ";
                            }
                        }
                        else if (i == reference.authors.Count - 1)
                        {
                            if (!elipseAdded && i > 0)
                            {
                                reference.formattedReference += "& ";
                            }
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName;
                                if (reference.authors[i].firstName.Length > 0 || reference.authors[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += ",";
                                }
                                reference.formattedReference += " ";
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ". ";
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName[0].ToString().ToUpper() + ". ";
                            }
                        }
                        else
                        {
                            if (!elipseAdded)
                            {
                                elipseAdded = true;
                                reference.formattedReference += ". . . ";
                            }
                        }
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        reference.formattedReference += ". ";
                        if (reference.source.Length > 0 )
                        {
                            reference.formattedReference += '\a';
                            nextCapital = true;
                            for (int i = 0; i < reference.source.Length; i++)
                            {
                                if (nextCapital)
                                {
                                    if (!reference.source[i].ToString().Equals(" "))
                                    {
                                        nextCapital = false;
                                    }
                                    reference.formattedReference += reference.source[i].ToString().ToUpper();
                                }
                                else
                                {
                                    reference.formattedReference += reference.source[i].ToString().ToLower();
                                }
                                if (reference.source[i].ToString().Equals(":"))
                                {
                                    nextCapital = true;
                                }
                            }
                            reference.formattedReference += '\a';
                            reference.formattedReference += ". ";
                            if (reference.retrievedFrom.Length > 0)
                            {
                                reference.formattedReference += "Podcast retrieved from " + reference.retrievedFrom;
                            }
                            else
                            {
                                error = true;
                                errorMessage += "Enter the URL were the podcast was listened to\n";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the name of the podcast host\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the title of the podcast\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the name of the presenter\n";
                }
            }
            else if (videoPodcast.Checked)
            {
                reference.type = "videoPodcast";
                Author producer = new Author();
                TextBox producerFirst = (TextBox)Controls.Find("producerFirstEnter", true)[0];
                TextBox producerMiddle = (TextBox)Controls.Find("producerMiddleEnter", true)[0];
                TextBox producerLast = (TextBox)Controls.Find("producerLastEnter", true)[0];
                producer.firstName = producerFirst.Text;
                producer.middleName = producerMiddle.Text;
                producer.lastName = producerLast.Text;
                reference.producer = producer;
                Author director = new Author();
                TextBox directorFirst = (TextBox)Controls.Find("directorFirstEnter", true)[0];
                TextBox directorMiddle = (TextBox)Controls.Find("directorMiddleEnter", true)[0];
                TextBox directorLast = (TextBox)Controls.Find("directorLastEnter", true)[0];
                director.firstName = directorFirst.Text;
                director.middleName = directorMiddle.Text;
                director.lastName = directorLast.Text;
                reference.director = director;
                TextBox publishDate = (TextBox)Controls.Find("publicationDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox episodeNum = (TextBox)Controls.Find("episodeNumberEnter", true)[0];
                reference.number = episodeNum.Text;
                TextBox source = (TextBox)Controls.Find("sourceEnter", true)[0];
                reference.source = source.Text;
                TextBox retrievedFrom = (TextBox)Controls.Find("retrievedFromEnter", true)[0];
                reference.retrievedFrom = retrievedFrom.Text;

                if (producer.firstName.Length > 0 || producer.middleName.Length > 0 || producer.lastName.Length > 0)
                {
                    if (reference.producer.lastName.Length > 0)
                    {
                        reference.formattedReference += reference.producer.lastName;
                        if (reference.producer.middleName.Length > 0 || reference.producer.firstName.Length > 0)
                        {
                            reference.formattedReference += ", ";
                        }
                        else
                        {
                            reference.formattedReference += " ";
                        }
                    }
                    if (reference.producer.firstName.Length > 0)
                    {
                        reference.formattedReference += reference.producer.firstName[0].ToString().ToUpper() + ". ";
                    }
                    if (reference.producer.middleName.Length > 0)
                    {
                        reference.formattedReference += reference.producer.middleName[0].ToString().ToUpper() + ". ";
                    }
                    reference.formattedReference += "(Producer)";
                    if (director.firstName.Length > 0 || director.middleName.Length > 0 || director.lastName.Length > 0)
                    {
                        reference.formattedReference += ", & ";
                    }
                    else
                    {
                        reference.formattedReference += ". ";
                    }
                }
                if (director.firstName.Length > 0 || director.middleName.Length > 0 || director.lastName.Length > 0)
                {                    
                    if (reference.director.lastName.Length > 0)
                    {
                        reference.formattedReference += reference.director.lastName;
                        if (reference.director.middleName.Length > 0 || reference.director.firstName.Length > 0)
                        {
                            reference.formattedReference += ", ";
                        }
                        else
                        {
                            reference.formattedReference += " ";
                        }
                    }
                    if (reference.director.firstName.Length > 0)
                    {
                        reference.formattedReference += reference.director.firstName[0].ToString().ToUpper() + ". ";
                    }
                    if (reference.producer.middleName.Length > 0)
                    {
                        reference.formattedReference += reference.director.middleName[0].ToString().ToUpper() + ". ";
                    }
                    reference.formattedReference += "(Director). ";
                }
                if (director.firstName.Length < 1 && director.middleName.Length < 1 && director.lastName.Length < 1 && producer.firstName.Length < 1 && producer.middleName.Length < 1 && producer.lastName.Length < 1)
                {
                    if (reference.title.Length > 0)
                    {
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        if (reference.number.Length > 0)
                        {
                            reference.formattedReference += " [Episode " + reference.number + "]";
                        }
                        reference.formattedReference += ". ";
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the title of the video podcast\n";
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                }
                else
                {
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        if (reference.number.Length > 0)
                        {
                            reference.formattedReference += " [Episode " + reference.number + "]";
                        }
                        reference.formattedReference += ". ";
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the title of the video podcast\n";
                    }
                }
                if (reference.source.Length > 0)
                {
                    reference.formattedReference += '\a';
                    reference.formattedReference += reference.source + ". ";
                    reference.formattedReference += '\a';
                }
                if (reference.retrievedFrom.Length > 0)
                {
                    reference.formattedReference += "Podcast retrieved from " + reference.retrievedFrom;
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the URL where the podcast was viewed\n";
                }
            }
            else if (motionPicture.Checked)
            {
                reference.type = "movie";
                Author producer = new Author();
                TextBox producerFirst = (TextBox)Controls.Find("producerFirstEnter", true)[0];
                TextBox producerMiddle = (TextBox)Controls.Find("producerMiddleEnter", true)[0];
                TextBox producerLast = (TextBox)Controls.Find("producerLastEnter", true)[0];
                producer.firstName = producerFirst.Text;
                producer.middleName = producerMiddle.Text;
                producer.lastName = producerLast.Text;
                reference.producer = producer;
                Author director = new Author();
                TextBox directorFirst = (TextBox)Controls.Find("directorFirstEnter", true)[0];
                TextBox directorMiddle = (TextBox)Controls.Find("directorMiddleEnter", true)[0];
                TextBox directorLast = (TextBox)Controls.Find("directorLastEnter", true)[0];
                director.firstName = directorFirst.Text;
                director.middleName = directorMiddle.Text;
                director.lastName = directorLast.Text;
                reference.director = director;
                TextBox publishDate = (TextBox)Controls.Find("publicationDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox location = (TextBox)Controls.Find("countryEnter", true)[0];
                reference.location = location.Text;
                TextBox studio = (TextBox)Controls.Find("studioEnter", true)[0];
                reference.studio = studio.Text;

                if (producer.firstName.Length > 0 || producer.middleName.Length > 0 || producer.lastName.Length > 0)
                {
                    if (reference.producer.lastName.Length > 0)
                    {
                        reference.formattedReference += reference.producer.lastName;
                        if (reference.producer.middleName.Length > 0 || reference.producer.firstName.Length > 0)
                        {
                            reference.formattedReference += ", ";
                        }
                        else
                        {
                            reference.formattedReference += " ";
                        }
                    }
                    if (reference.producer.firstName.Length > 0)
                    {
                        reference.formattedReference += reference.producer.firstName[0].ToString().ToUpper() + ". ";
                    }
                    if (reference.producer.middleName.Length > 0)
                    {
                        reference.formattedReference += reference.producer.middleName[0].ToString().ToUpper() + ". ";
                    }
                    reference.formattedReference += "(Producer)";
                    if (director.firstName.Length > 0 || director.middleName.Length > 0 || director.lastName.Length > 0)
                    {
                        reference.formattedReference += ", & ";
                    }
                    else
                    {
                        reference.formattedReference += ". ";
                    }
                }
                if (director.firstName.Length > 0 || director.middleName.Length > 0 || director.lastName.Length > 0)
                {
                    if (reference.director.lastName.Length > 0)
                    {
                        reference.formattedReference += reference.director.lastName;
                        if (reference.director.middleName.Length > 0 || reference.director.firstName.Length > 0)
                        {
                            reference.formattedReference += ", ";
                        }
                        else
                        {
                            reference.formattedReference += " ";
                        }
                    }
                    if (reference.director.firstName.Length > 0)
                    {
                        reference.formattedReference += reference.director.firstName[0].ToString().ToUpper() + ". ";
                    }
                    if (reference.producer.middleName.Length > 0)
                    {
                        reference.formattedReference += reference.director.middleName[0].ToString().ToUpper() + ". ";
                    }
                    reference.formattedReference += "(Director). ";
                }
                if (director.firstName.Length < 1 && director.middleName.Length < 1 && director.lastName.Length < 1 && producer.firstName.Length < 1 && producer.middleName.Length < 1 && producer.lastName.Length < 1)
                {
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        reference.formattedReference += '\a';
                        reference.formattedReference += " [Motion picture]. ";
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the title of the video podcast\n";
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                }
                else
                {
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        reference.formattedReference += '\a';
                        reference.formattedReference += " [Motion picture]. ";
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the title of the motion picture\n";
                    }
                }
                if (reference.location.Length > 0)
                {
                    if (reference.studio.Length > 0)
                    {
                        reference.formattedReference += reference.location + ": ";
                    }
                    else
                    {
                        reference.formattedReference += reference.location + ".";
                    }
                }
                if (reference.studio.Length > 0)
                {
                    reference.formattedReference += reference.studio + ".";
                }
            }
            else if (tvBroadcast.Checked)
            {
                reference.type = "broadcast";
                Author producer = new Author();
                TextBox producerFirst = (TextBox)Controls.Find("producerFirstEnter", true)[0];
                TextBox producerMiddle = (TextBox)Controls.Find("producerMiddleEnter", true)[0];
                TextBox producerLast = (TextBox)Controls.Find("producerLastEnter", true)[0];
                producer.firstName = producerFirst.Text;
                producer.middleName = producerMiddle.Text;
                producer.lastName = producerLast.Text;
                reference.producer = producer;
                Author director = new Author();
                TextBox directorFirst = (TextBox)Controls.Find("directorFirstEnter", true)[0];
                TextBox directorMiddle = (TextBox)Controls.Find("directorMiddleEnter", true)[0];
                TextBox directorLast = (TextBox)Controls.Find("directorLastEnter", true)[0];
                director.firstName = directorFirst.Text;
                director.middleName = directorMiddle.Text;
                director.lastName = directorLast.Text;
                reference.director = director;
                TextBox publishDate = (TextBox)Controls.Find("publicationDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox location = (TextBox)Controls.Find("locationEnter", true)[0];
                reference.location = location.Text;
                TextBox studio = (TextBox)Controls.Find("broadcasterEnter", true)[0];
                reference.studio = studio.Text;

                if (producer.firstName.Length > 0 || producer.middleName.Length > 0 || producer.lastName.Length > 0)
                {
                    if (reference.producer.lastName.Length > 0)
                    {
                        reference.formattedReference += reference.producer.lastName;
                        if (reference.producer.middleName.Length > 0 || reference.producer.firstName.Length > 0)
                        {
                            reference.formattedReference += ", ";
                        }
                        else
                        {
                            reference.formattedReference += " ";
                        }
                    }
                    if (reference.producer.firstName.Length > 0)
                    {
                        reference.formattedReference += reference.producer.firstName[0].ToString().ToUpper() + ". ";
                    }
                    if (reference.producer.middleName.Length > 0)
                    {
                        reference.formattedReference += reference.producer.middleName[0].ToString().ToUpper() + ". ";
                    }
                    reference.formattedReference += "(Producer)";
                    if (director.firstName.Length > 0 || director.middleName.Length > 0 || director.lastName.Length > 0)
                    {
                        reference.formattedReference += ", & ";
                    }
                    else
                    {
                        reference.formattedReference += ". ";
                    }
                }
                if (director.firstName.Length > 0 || director.middleName.Length > 0 || director.lastName.Length > 0)
                {
                    if (reference.director.lastName.Length > 0)
                    {
                        reference.formattedReference += reference.director.lastName;
                        if (reference.director.middleName.Length > 0 || reference.director.firstName.Length > 0)
                        {
                            reference.formattedReference += ", ";
                        }
                        else
                        {
                            reference.formattedReference += " ";
                        }
                    }
                    if (reference.director.firstName.Length > 0)
                    {
                        reference.formattedReference += reference.director.firstName[0].ToString().ToUpper() + ". ";
                    }
                    if (reference.producer.middleName.Length > 0)
                    {
                        reference.formattedReference += reference.director.middleName[0].ToString().ToUpper() + ". ";
                    }
                    reference.formattedReference += "(Director). ";
                }
                if (director.firstName.Length < 1 && director.middleName.Length < 1 && director.lastName.Length < 1 && producer.firstName.Length < 1 && producer.middleName.Length < 1 && producer.lastName.Length < 1)
                {
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        reference.formattedReference += '\a';
                        reference.formattedReference += " [Television broadcast]. ";
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the title of the video podcast\n";
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                }
                else
                {
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        reference.formattedReference += '\a';
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        reference.formattedReference += '\a';
                        reference.formattedReference += " [Television broadcast]. ";
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the title of the broadcast\n";
                    }
                }
                if (reference.location.Length > 0)
                {
                    if (reference.studio.Length > 0)
                    {
                        reference.formattedReference += reference.location + ": ";
                    }
                    else
                    {
                        reference.formattedReference += reference.location + ".";
                    }
                }
                if (reference.studio.Length > 0)
                {
                    reference.formattedReference += reference.studio + ".";
                }
            }
            else if (tvEpisode.Checked)
            {
                reference.type = "episode";
                Author writer = new Author();
                TextBox writerFirst = (TextBox)Controls.Find("writerFirstEnter", true)[0];
                TextBox writerMiddle = (TextBox)Controls.Find("writerMiddleEnter", true)[0];
                TextBox writerLast = (TextBox)Controls.Find("writerLastEnter", true)[0];
                writer.firstName = writerFirst.Text;
                writer.middleName = writerMiddle.Text;
                writer.lastName = writerLast.Text;
                reference.writer = writer;
                Author producer = new Author();
                TextBox producerFirst = (TextBox)Controls.Find("producerFirstEnter", true)[0];
                TextBox producerMiddle = (TextBox)Controls.Find("producerMiddleEnter", true)[0];
                TextBox producerLast = (TextBox)Controls.Find("producerLastEnter", true)[0];
                producer.firstName = producerFirst.Text;
                producer.middleName = producerMiddle.Text;
                producer.lastName = producerLast.Text;
                reference.producer = producer;
                Author director = new Author();
                TextBox directorFirst = (TextBox)Controls.Find("directorFirstEnter", true)[0];
                TextBox directorMiddle = (TextBox)Controls.Find("directorMiddleEnter", true)[0];
                TextBox directorLast = (TextBox)Controls.Find("directorLastEnter", true)[0];
                director.firstName = directorFirst.Text;
                director.middleName = directorMiddle.Text;
                director.lastName = directorLast.Text;
                reference.director = director;
                TextBox publishDate = (TextBox)Controls.Find("publicationDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox series = (TextBox)Controls.Find("seriesTitleEnter", true)[0];
                reference.source = series.Text;
                TextBox location = (TextBox)Controls.Find("originEnter", true)[0];
                reference.location = location.Text;
                TextBox studio = (TextBox)Controls.Find("studioEnter", true)[0];
                reference.studio = studio.Text;

                if (writer.firstName.Length > 0 || writer.middleName.Length > 0 || writer.lastName.Length > 0)
                {
                    if (reference.writer.lastName.Length > 0)
                    {
                        reference.formattedReference += reference.writer.lastName;
                        if (reference.writer.middleName.Length > 0 || reference.writer.firstName.Length > 0)
                        {
                            reference.formattedReference += ", ";
                        }
                        else
                        {
                            reference.formattedReference += " ";
                        }
                    }
                    if (reference.writer.firstName.Length > 0)
                    {
                        reference.formattedReference += reference.writer.firstName[0].ToString().ToUpper() + ". ";
                    }
                    if (reference.writer.middleName.Length > 0)
                    {
                        reference.formattedReference += reference.writer.middleName[0].ToString().ToUpper() + ". ";
                    }
                    reference.formattedReference += "(Writer)";
                    if (director.firstName.Length > 0 || director.middleName.Length > 0 || director.lastName.Length > 0)
                    {
                        reference.formattedReference += ", & ";
                    }
                    else
                    {
                        reference.formattedReference += ". ";
                    }
                }
                if (director.firstName.Length > 0 || director.middleName.Length > 0 || director.lastName.Length > 0)
                {
                    if (reference.director.lastName.Length > 0)
                    {
                        reference.formattedReference += reference.director.lastName;
                        if (reference.director.middleName.Length > 0 || reference.director.firstName.Length > 0)
                        {
                            reference.formattedReference += ", ";
                        }
                        else
                        {
                            reference.formattedReference += " ";
                        }
                    }
                    if (reference.director.firstName.Length > 0)
                    {
                        reference.formattedReference += reference.director.firstName[0].ToString().ToUpper() + ". ";
                    }
                    if (reference.producer.middleName.Length > 0)
                    {
                        reference.formattedReference += reference.director.middleName[0].ToString().ToUpper() + ". ";
                    }
                    reference.formattedReference += "(Director). ";
                }
                if (director.firstName.Length < 1 && director.middleName.Length < 1 && director.lastName.Length < 1 && writer.firstName.Length < 1 && writer.middleName.Length < 1 && writer.lastName.Length < 1)
                {
                    if (reference.title.Length > 0)
                    {
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        reference.formattedReference += " [Television series episode]. ";
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the title of the video podcast\n";
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                }
                else
                {
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        reference.formattedReference += " [Television series episode]. ";
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the title of the episode\n";
                    }
                }
                if (producer.firstName.Length > 0 || producer.middleName.Length > 0 || producer.lastName.Length > 0)
                {
                    reference.formattedReference += "In ";
                    if (reference.producer.firstName.Length > 0 && reference.producer.lastName.Length > 0)
                    {
                        reference.formattedReference += reference.producer.firstName[0].ToString().ToUpper() + ". ";
                        if (reference.producer.middleName.Length > 0)
                        {
                            reference.formattedReference += reference.producer.middleName[0].ToString().ToUpper() + ". ";
                        }
                        reference.formattedReference += reference.producer.lastName + " (Producer), ";
                        if (reference.source.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            bool nextCapital = true;
                            for (int i = 0; i < reference.source.Length; i++)
                            {
                                if (nextCapital)
                                {
                                    if (!reference.source[i].ToString().Equals(" "))
                                    {
                                        nextCapital = false;
                                    }
                                    reference.formattedReference += reference.source[i].ToString().ToUpper();
                                }
                                else
                                {
                                    reference.formattedReference += reference.source[i].ToString().ToLower();
                                }
                                if (reference.source[i].ToString().Equals(":"))
                                {
                                    nextCapital = true;
                                }
                            }
                            reference.formattedReference += ". ";
                            reference.formattedReference += '\a';
                            if (reference.location.Length > 0)
                            {
                                if (reference.studio.Length > 0)
                                {
                                    reference.formattedReference += reference.location + ": ";
                                }
                                else
                                {
                                    reference.formattedReference += reference.location + ".";
                                }
                            }
                            if (reference.studio.Length > 0)
                            {
                                reference.formattedReference += reference.studio + ".";
                            }
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the title of the series\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the producer's first and last name\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the producer's name\n";
                }
            }
            else if (music.Checked)
            {
                reference.type = "music";
                Author writer = new Author();
                TextBox writerFirst = (TextBox)Controls.Find("writerFirstEnter", true)[0];
                TextBox writerMiddle = (TextBox)Controls.Find("writerMiddleEnter", true)[0];
                TextBox writerLast = (TextBox)Controls.Find("writerLastEnter", true)[0];
                writer.firstName = writerFirst.Text;
                writer.middleName = writerMiddle.Text;
                writer.lastName = writerLast.Text;
                reference.writer = writer;
                Author artist = new Author();
                TextBox artistFirst = (TextBox)Controls.Find("artistFirstEnter", true)[0];
                TextBox artistMiddle = (TextBox)Controls.Find("artistMiddleEnter", true)[0];
                TextBox artistLast = (TextBox)Controls.Find("artistLastEnter", true)[0];
                artist.firstName = artistFirst.Text;
                artist.middleName = artistMiddle.Text;
                artist.lastName = artistLast.Text;
                reference.producer = artist;
                TextBox publishDate = (TextBox)Controls.Find("copyrightDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox album = (TextBox)Controls.Find("albumTitleEnter", true)[0];
                reference.source = album.Text;
                TextBox medium = (TextBox)Controls.Find("mediumEnter", true)[0];
                reference.type = medium.Text;
                TextBox location = (TextBox)Controls.Find("locationEnter", true)[0];
                reference.location = location.Text;
                TextBox label = (TextBox)Controls.Find("labelEnter", true)[0];
                reference.studio = label.Text;
                TextBox recordDate = (TextBox)Controls.Find("recordingDateEnter", true)[0];
                reference.recordDate = recordDate.Text;

                if (writer.firstName.Length > 0 || writer.middleName.Length > 0 || writer.lastName.Length > 0)
                {
                    if (reference.writer.lastName.Length > 0)
                    {
                        reference.formattedReference += reference.writer.lastName;
                        if (reference.writer.middleName.Length > 0 || reference.writer.firstName.Length > 0)
                        {
                            reference.formattedReference += ", ";
                        }
                        else
                        {
                            reference.formattedReference += " ";
                        }
                    }
                    if (reference.writer.firstName.Length > 0)
                    {
                        reference.formattedReference += reference.writer.firstName[0].ToString().ToUpper() + ". ";
                    }
                    if (reference.writer.middleName.Length > 0)
                    {
                        reference.formattedReference += reference.writer.middleName[0].ToString().ToUpper() + ". ";
                    }
                    reference.formattedReference += "(Writer). ";
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        if ((artist.firstName.Length > 0 || artist.middleName.Length > 0 || artist.lastName.Length > 0) &&
                            (!artist.firstName.Equals(writer.firstName) || !artist.middleName.Equals(writer.middleName) || !artist.lastName.Equals(writer.lastName)))
                        {
                            reference.formattedReference += " [Recorded by " + artist.firstName + " " + artist.middleName + " " + artist.lastName+ "]. ";
                        }
                        else
                        {
                            reference.formattedReference += ". ";
                        }
                        if (reference.source.Length > 0)
                        {
                            reference.formattedReference += "On ";
                            reference.formattedReference += '\a';
                            nextCapital = true;
                            for (int i = 0; i < reference.source.Length; i++)
                            {
                                if (nextCapital)
                                {
                                    if (!reference.source[i].ToString().Equals(" "))
                                    {
                                        nextCapital = false;
                                    }
                                    reference.formattedReference += reference.source[i].ToString().ToUpper();
                                }
                                else
                                {
                                    reference.formattedReference += reference.source[i].ToString().ToLower();
                                }
                                if (reference.source[i].ToString().Equals(":"))
                                {
                                    nextCapital = true;
                                }
                            }
                            reference.formattedReference += " ";
                            reference.formattedReference += '\a';
                            if (reference.type.Length > 0)
                            {
                                reference.formattedReference += "[" + reference.type + "]. ";
                                if (reference.location.Length > 0)
                                {
                                    if (reference.studio.Length > 0)
                                    {
                                        reference.formattedReference += reference.location + ": ";
                                    }
                                    else
                                    {
                                        reference.formattedReference += reference.location + ".";
                                    }
                                }
                                if (reference.studio.Length > 0)
                                {
                                    reference.formattedReference += reference.studio + ".";
                                }
                                if (reference.recordDate.Length > 0 && !reference.recordDate.Equals(reference.publicationDate))
                                {
                                    reference.formattedReference += " (" + reference.recordDate + ").";
                                }
                            }
                            else
                            {
                                error = true;
                                errorMessage += "Enter the medium\n";
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
                        errorMessage += "Enter the song title\n";
                    }
                }
                else
                {
                    error = true;
                    errorMessage += "Enter the song writer\n";
                }
            }
            else if (interview.Checked)
            {
                reference.type = "interview";
                Author author = new Author();
                TextBox authorFirst = (TextBox)Controls.Find("communicatorFirstEnter", true)[0];
                TextBox authorMiddle = (TextBox)Controls.Find("communicatorMiddleEnter", true)[0];
                TextBox authorLast = (TextBox)Controls.Find("communicatorLastEnter", true)[0];
                author.firstName = authorFirst.Text;
                author.middleName = authorMiddle.Text;
                author.lastName = authorLast.Text;
                reference.authors.Add(author);
                TextBox publishDate = (TextBox)Controls.Find("dateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
            }
            else if (email.Checked)
            {
                reference.type = "email";
                Author author = new Author();
                TextBox authorFirst = (TextBox)Controls.Find("communicatorFirstEnter", true)[0];
                TextBox authorMiddle = (TextBox)Controls.Find("communicatorMiddleEnter", true)[0];
                TextBox authorLast = (TextBox)Controls.Find("communicatorLastEnter", true)[0];
                author.firstName = authorFirst.Text;
                author.middleName = authorMiddle.Text;
                author.lastName = authorLast.Text;
                reference.authors.Add(author);
                TextBox publishDate = (TextBox)Controls.Find("dateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
            }
            else if (personal.Checked)
            {
                reference.type = "personal";
                Author author = new Author();
                TextBox authorFirst = (TextBox)Controls.Find("communicatorFirstEnter", true)[0];
                TextBox authorMiddle = (TextBox)Controls.Find("communicatorMiddleEnter", true)[0];
                TextBox authorLast = (TextBox)Controls.Find("communicatorLastEnter", true)[0];
                author.firstName = authorFirst.Text;
                author.middleName = authorMiddle.Text;
                author.lastName = authorLast.Text;
                reference.authors.Add(author);
                TextBox publishDate = (TextBox)Controls.Find("dateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
            }
            else if (letterToEditor.Checked)
            {
                reference.type = "letterToEditor";
                Author author = new Author();
                TextBox authorFirst = (TextBox)Controls.Find("authorFirstEnter", true)[0];
                TextBox authorMiddle = (TextBox)Controls.Find("authorMiddleEnter", true)[0];
                TextBox authorLast = (TextBox)Controls.Find("authorLastEnter", true)[0];
                author.firstName = authorFirst.Text;
                author.middleName = authorMiddle.Text;
                author.lastName = authorLast.Text;
                reference.authors.Add(author);
                TextBox publishDate = (TextBox)Controls.Find("publicationDateEnter", true)[0];
                reference.publicationDate = publishDate.Text;
                TextBox title = (TextBox)Controls.Find("titleEnter", true)[0];
                reference.title = title.Text;
                TextBox source = (TextBox)Controls.Find("wherePublishedEnter", true)[0];
                reference.source = source.Text;
                TextBox volume = (TextBox)Controls.Find("volumeEnter", true)[0];
                reference.volume = volume.Text;
                TextBox issue = (TextBox)Controls.Find("issueEnter", true)[0];
                reference.issue = issue.Text;
                TextBox startPage = (TextBox)Controls.Find("pageStartEnter", true)[0];
                reference.startPage = startPage.Text;
                TextBox endPage = (TextBox)Controls.Find("pageEndEnter", true)[0];
                reference.endPage = endPage.Text;

                if (reference.authors.Count > 0)
                {                    
                    if (reference.authors[0].lastName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[0].lastName;
                        if (reference.authors[0].firstName.Length > 0 || reference.authors[0].middleName.Length > 0)
                        {
                            reference.formattedReference += ",";
                        }
                        reference.formattedReference += " ";
                    }
                    if (reference.authors[0].firstName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[0].firstName[0].ToString().ToUpper() + ". ";
                    }
                    if (reference.authors[0].middleName.Length > 0)
                    {
                        reference.formattedReference += reference.authors[0].middleName[0].ToString().ToUpper() + ". ";
                    }
                    if (reference.publicationDate.Length < 1)
                    {
                        reference.formattedReference += "(n.d.). ";
                    }
                    else
                    {
                        reference.formattedReference += "(" + reference.publicationDate + "). ";
                    }
                    if (reference.title.Length > 0)
                    {
                        bool nextCapital = true;
                        for (int i = 0; i < reference.title.Length; i++)
                        {
                            if (nextCapital)
                            {
                                if (!reference.title[i].ToString().Equals(" "))
                                {
                                    nextCapital = false;
                                }
                                reference.formattedReference += reference.title[i].ToString().ToUpper();
                            }
                            else
                            {
                                reference.formattedReference += reference.title[i].ToString().ToLower();
                            }
                            if (reference.title[i].ToString().Equals(":"))
                            {
                                nextCapital = true;
                            }
                        }
                        reference.formattedReference += " [Letter to the editor]. ";
                        if (reference.source.Length > 0)
                        {
                            reference.formattedReference += '\a';
                            reference.formattedReference += reference.source;
                            if (reference.volume.Length > 0 || reference.issue.Length > 0 ||
                                reference.startPage.Length > 0)
                            {
                                reference.formattedReference += ", ";
                            }
                            if (reference.volume.Length > 0)
                            {
                                reference.formattedReference += reference.volume;
                            }
                            reference.formattedReference += '\a';
                            if (reference.issue.Length > 0)
                            {
                                reference.formattedReference += "(" + reference.issue + ")";
                            }
                            if ((reference.volume.Length > 0 || reference.issue.Length > 0) &&
                                reference.startPage.Length > 0)
                            {
                                reference.formattedReference += ", ";
                            }
                            if (reference.startPage.Length < 1 && reference.endPage.Length > 0)
                            {
                                error = true;
                                errorMessage += "Enter a start page\n";
                            }
                            else if ((reference.startPage.Length > 0 && reference.endPage.Length > 0) &&
                                !reference.startPage.Equals(reference.endPage))
                            {
                                reference.formattedReference += reference.startPage + "-" + reference.endPage;
                            }
                            else if ((reference.startPage.Length > 0 && reference.endPage.Length < 1) ||
                                (reference.startPage.Equals(reference.endPage) && reference.startPage.Length > 0))
                            {
                                reference.formattedReference += reference.startPage;
                            }
                            reference.formattedReference += ".";
                        }
                        else
                        {
                            error = true;
                            errorMessage += "Enter the source name\n";
                        }
                    }
                    else
                    {
                        error = true;
                        errorMessage += "Enter the title of the letter\n";
                    }
                }                
                else
                {
                    error = true;
                    errorMessage += "Enter the author's name\n";
                }
            }
            else
            {
                error = true;
                errorMessage += "No valid reference type has been selected\n";
            }
            if (error)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                Form1.myPaper.references.references.Add(reference);
                this.Close();
            }            
        }
    }
}

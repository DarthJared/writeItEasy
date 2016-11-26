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
                    error = true;
                    errorMessage += "Enter an author or switch reference type to \"Book without Author\"\n";
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
                            errorMessage += "Enter the URL where this article was found or switch to the \"Book with Author\" reference type";
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

            }
            else if (onlineBibliography.Checked)
            {

            }
            else if (onlineInterview.Checked)
            {

            }
            else if (onlineEncyclopedia.Checked)
            {

            }
            else if (forumDiscussion.Checked)
            {

            }
            else if (bookReview.Checked)
            {

            }
            else if (blog.Checked)
            {

            }
            else if (wiki.Checked)
            {

            }
            else if (webDoc.Checked)
            {

            }
            else if (onlineDissertation.Checked)
            {

            }
            else if (publishedDissertation.Checked)
            {

            }
            else if (unpublishedDissertation.Checked)
            {

            }
            else if (privateOrgReport.Checked)
            {

            }
            else if (governmentDocument.Checked)
            {

            }
            else if (review.Checked)
            {

            }
            else if (lectureNotesSlides.Checked)
            {

            }
            else if (audioPodcast.Checked)
            {

            }
            else if (videoPodcast.Checked)
            {

            }
            else if (motionPicture.Checked)
            {

            }
            else if (tvBroadcast.Checked)
            {

            }
            else if (tvEpisode.Checked)
            {

            }
            else if (music.Checked)
            {

            }
            else if (interview.Checked)
            {

            }
            else if (email.Checked)
            {

            }
            else if (personal.Checked)
            {

            }
            else if (letterToEditor.Checked)
            {

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

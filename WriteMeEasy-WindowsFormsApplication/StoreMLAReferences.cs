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
            else if (shortStory.Checked)
            {
                
            }
            else if (editorial.Checked)
            {
                
            }
            else if (encyclopedia.Checked)
            {
                
            }
            else if (translated.Checked)
            {
                
            }
            else if (magazine.Checked)
            {
                
            }
            else if (newspaper.Checked)
            {
                
            }
            else if (journal.Checked)
            {                

            }
            else if (onlineOnlyJournal.Checked)
            {
                
            }
            else if (onlinePeriodical.Checked)
            {
                
            }
            else if (onlineNewspaper.Checked)
            {
                
            }
            else if (website.Checked)
            {
                
            }
            else if (onlinePrintJournal.Checked)
            {
                
            }
            else if (onlineEncyclopedia.Checked)
            {
                
            }
            else if (blogDiscussion.Checked)
            {
                
            }
            else if (publishedDissertation.Checked || publishedThesis.Checked || unpublishedDissertation.Checked || unpublishedThesis.Checked)
            {
                
            }
            else if (governmentDocument.Checked)
            {
                
            }
            else if (review.Checked)
            {
                
            }
            else if (presentation.Checked)
            {
                
            }
            else if (movie.Checked)
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

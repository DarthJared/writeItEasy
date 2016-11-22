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
                    reference.authors.Add(author);
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
                        if (i < 6 && i != reference.authors.Count)
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
                                reference.formattedReference += reference.authors[i].middleName + "., ";
                            }
                        }
                        else if (i != reference.authors.Count)
                        {
                            if (reference.authors[i].lastName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].lastName;
                                if (reference.authors[i].firstName.Length > 0 || reference.authors[i].middleName.Length > 0)
                                {
                                    reference.formattedReference += ",";
                                }
                            }
                            if (reference.authors[i].firstName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].firstName[0].ToString().ToUpper() + ". ";
                            }
                            if (reference.authors[i].middleName.Length > 0)
                            {
                                reference.formattedReference += reference.authors[i].middleName + ". ";
                            }
                        }
                    }
                }
            }
            else if (bookNoAuth.Checked)
            {

            }
            else if (bookByOrg.Checked)
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
            else if (onlineJournal.Checked)
            {

            }
            else if (onlinePeriodical.Checked)
            {

            }
            else if (onlineNewspaper.Checked)
            {

            }
            else if (electronicBook.Checked)
            {

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
            Form1.myPaper.references.references.Add(reference);
        }
    }
}

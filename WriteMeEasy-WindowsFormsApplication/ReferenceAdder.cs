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
    public partial class ReferenceAdder : Form
    {
        public ReferenceAdder()
        {
            InitializeComponent();

            this.Width = 1909;
            this.Height = 1447;
            sourceInfoGroupBox.Height = 155;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int getSourceInfoHeight(int numSourceInfo)
        {
            return (numSourceInfo * 25) + 30;
        }

        private void referenceTypeChange(object sender, EventArgs e)
        {
            if (bookOneAuth.Checked)
            {
                sourceInfoGroupBox.Height = getSourceInfoHeight(5);

                Label authorLabel = new Label();
                authorLabel.Text = "Author:";
                sourceInfoGroupBox.Controls.Add(authorLabel);
                authorLabel.Location = new Point(16, 25);

                TextBox authorFirstEnter = new TextBox();
                authorFirstEnter.Name = "authorFirstEnter";
                sourceInfoGroupBox.Controls.Add(authorFirstEnter);
                authorFirstEnter.Location = new Point(125, 25);
                authorFirstEnter.Width = 100;

                TextBox authorMiddleEnter = new TextBox();
                authorMiddleEnter.Name = "authorEnter";
                sourceInfoGroupBox.Controls.Add(authorMiddleEnter);
                authorMiddleEnter.Location = new Point(240, 25);
                authorMiddleEnter.Width = 100;

                TextBox authorLastEnter = new TextBox();
                authorLastEnter.Name = "authorLastEnter";
                sourceInfoGroupBox.Controls.Add(authorLastEnter);
                authorLastEnter.Location = new Point(355, 25);
                authorLastEnter.Width = 100;

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Title:";
                sourceInfoGroupBox.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(16, 50);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoGroupBox.Controls.Add(titleEnter);
                titleEnter.Location = new Point(125, 50);
                titleEnter.Width = 150;

                Label publisherLabel = new Label();
                publisherLabel.Text = "Publisher Name:";
                sourceInfoGroupBox.Controls.Add(publisherLabel);
                publisherLabel.Location = new Point(16, 75);

                TextBox publisherEnter = new TextBox();
                publisherEnter.Name = "publisherEnter";
                sourceInfoGroupBox.Controls.Add(publisherEnter);
                publisherEnter.Location = new Point(125, 75);
                publisherEnter.Width = 150;

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Publication Date:";
                sourceInfoGroupBox.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(16, 100);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoGroupBox.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(125, 100);
                publishDateEnter.Width = 150;

                Label editionLabel = new Label();
                editionLabel.Text = "Edition:";
                sourceInfoGroupBox.Controls.Add(editionLabel);
                editionLabel.Location = new Point(16, 125);

                TextBox editionEnter = new TextBox();
                editionEnter.Name = "editionEnter";
                sourceInfoGroupBox.Controls.Add(editionEnter);
                editionEnter.Location = new Point(125, 125);
                editionEnter.Width = 150;
            }
            else if (bookMoreAuth.Checked)
            {

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
            else if (anonymous.Checked)
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
        }

        
    }
}

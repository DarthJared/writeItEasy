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

            bookOneAuth.Checked = false;
            bookOneAuth.Checked = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int getSourceInfoHeight(int numSourceInfo)
        {
            return (numSourceInfo * 25) + 30;
        }

        private void removeInsideInfo()
        {
            sourceInfoGroupBox.Controls.Clear();
        }

        private void referenceTypeChange(object sender, EventArgs e)
        {
            if (bookOneAuth.Checked)
            {
                removeInsideInfo(); 

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
                authorMiddleEnter.Name = "authorMiddleEnter";
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
                removeInsideInfo();

            }
            else if (bookNoAuth.Checked)
            {
                removeInsideInfo();
                sourceInfoGroupBox.Height = getSourceInfoHeight(4);
                
                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Title:";
                sourceInfoGroupBox.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(16, 25);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoGroupBox.Controls.Add(titleEnter);
                titleEnter.Location = new Point(125, 25);
                titleEnter.Width = 150;

                Label publisherLabel = new Label();
                publisherLabel.Text = "Publisher Name:";
                sourceInfoGroupBox.Controls.Add(publisherLabel);
                publisherLabel.Location = new Point(16, 50);

                TextBox publisherEnter = new TextBox();
                publisherEnter.Name = "publisherEnter";
                sourceInfoGroupBox.Controls.Add(publisherEnter);
                publisherEnter.Location = new Point(125, 50);
                publisherEnter.Width = 150;

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Publication Date:";
                sourceInfoGroupBox.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(16, 75);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoGroupBox.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(125, 75);
                publishDateEnter.Width = 150;

                Label editionLabel = new Label();
                editionLabel.Text = "Edition:";
                sourceInfoGroupBox.Controls.Add(editionLabel);
                editionLabel.Location = new Point(16, 100);

                TextBox editionEnter = new TextBox();
                editionEnter.Name = "editionEnter";
                sourceInfoGroupBox.Controls.Add(editionEnter);
                editionEnter.Location = new Point(125, 100);
                editionEnter.Width = 150;
            }
            else if (bookByOrg.Checked)
            {
                removeInsideInfo();
                sourceInfoGroupBox.Height = getSourceInfoHeight(5);

                Label authorLabel = new Label();
                authorLabel.Text = "Organization:";
                sourceInfoGroupBox.Controls.Add(authorLabel);
                authorLabel.Location = new Point(16, 25);

                TextBox authorEnter = new TextBox();
                authorEnter.Name = "authorEnter";
                sourceInfoGroupBox.Controls.Add(authorEnter);
                authorEnter.Location = new Point(125, 25);
                authorEnter.Width = 150;

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
            else if (encyclopedia.Checked)
            {
                removeInsideInfo();
                sourceInfoGroupBox.Height = getSourceInfoHeight(5);

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Publication Date:";
                sourceInfoGroupBox.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(16, 25);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoGroupBox.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(200, 25);
                publishDateEnter.Width = 150;

                Label termLabel = new Label();
                termLabel.Text = "Term Referenced:";
                sourceInfoGroupBox.Controls.Add(termLabel);
                termLabel.Location = new Point(16, 50);

                TextBox termEnter = new TextBox();
                termEnter.Name = "termEnter";
                sourceInfoGroupBox.Controls.Add(termEnter);
                termEnter.Location = new Point(200, 50);
                termEnter.Width = 150;

                Label encycDictTitleLabel = new Label();
                encycDictTitleLabel.Text = "Encyclopedia or Dictionary Name:";
                sourceInfoGroupBox.Controls.Add(encycDictTitleLabel);
                encycDictTitleLabel.Location = new Point(16, 75);
                encycDictTitleLabel.Width = 175;

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoGroupBox.Controls.Add(titleEnter);
                titleEnter.Location = new Point(200, 75);
                titleEnter.Width = 150;

                Label volumeLabel = new Label();
                volumeLabel.Text = "Volume:";
                sourceInfoGroupBox.Controls.Add(volumeLabel);
                volumeLabel.Location = new Point(16, 100);

                TextBox volumeEnter = new TextBox();
                volumeEnter.Name = "volumeEnter";
                sourceInfoGroupBox.Controls.Add(volumeEnter);
                volumeEnter.Location = new Point(200, 100);
                volumeEnter.Width = 150;

                Label pagesLabel = new Label();
                pagesLabel.Text = "Pages:";
                sourceInfoGroupBox.Controls.Add(pagesLabel);
                pagesLabel.Location = new Point(16, 125);

                TextBox pageStartEnter = new TextBox();
                pageStartEnter.Name = "pageStartEnter";
                sourceInfoGroupBox.Controls.Add(pageStartEnter);
                pageStartEnter.Location = new Point(200, 125);
                pageStartEnter.Width = 100;

                TextBox pageEndEnter = new TextBox();
                pageEndEnter.Name = "pageEndEnter";
                sourceInfoGroupBox.Controls.Add(pageEndEnter);
                pageEndEnter.Location = new Point(315, 125);
                pageEndEnter.Width = 100;

            }
            else if (translated.Checked)
            {
                removeInsideInfo();
                
            }
            else if (magazine.Checked)
            {
                removeInsideInfo();

            }
            else if (newspaper.Checked)
            {
                removeInsideInfo();

            }
            else if (anonymous.Checked)
            {
                removeInsideInfo();

            }
            else if (journal.Checked)
            {
                removeInsideInfo();

            }
            else if (onlineJournal.Checked)
            {
                removeInsideInfo();

            }
            else if (onlinePeriodical.Checked)
            {
                removeInsideInfo();

            }
            else if (onlineNewspaper.Checked)
            {
                removeInsideInfo();

            }
            else if (electronicBook.Checked)
            {
                removeInsideInfo();

            }
            else if (kindle.Checked)
            {
                removeInsideInfo();

            }
            else if (onlineBibliography.Checked)
            {
                removeInsideInfo();

            }
            else if (onlineInterview.Checked)
            {
                removeInsideInfo();

            }
            else if (onlineEncyclopedia.Checked)
            {
                removeInsideInfo();

            }
            else if (forumDiscussion.Checked)
            {
                removeInsideInfo();

            }
            else if (bookReview.Checked)
            {
                removeInsideInfo();

            }
            else if (blog.Checked)
            {
                removeInsideInfo();

            }
            else if (wiki.Checked)
            {
                removeInsideInfo();

            }
            else if (webDoc.Checked)
            {
                removeInsideInfo();

            }
            else if (onlineDissertation.Checked)
            {
                removeInsideInfo();

            }
            else if (publishedDissertation.Checked)
            {
                removeInsideInfo();

            }
            else if (unpublishedDissertation.Checked)
            {
                removeInsideInfo();

            } 
            else if (privateOrgReport.Checked)
            {
                removeInsideInfo();

            }
            else if (governmentDocument.Checked)
            {
                removeInsideInfo();

            }
            else if (review.Checked)
            {
                removeInsideInfo();

            }
            else if (lectureNotesSlides.Checked)
            {
                removeInsideInfo();

            }
            else if (audioPodcast.Checked)
            {
                removeInsideInfo();

            }
            else if (videoPodcast.Checked)
            {
                removeInsideInfo();

            }
            else if (motionPicture.Checked)
            {
                removeInsideInfo();

            }
            else if (tvBroadcast.Checked)
            {
                removeInsideInfo();

            }
            else if (tvEpisode.Checked)
            {
                removeInsideInfo();

            }
            else if (music.Checked)
            {
                removeInsideInfo();

            }
            else if (interview.Checked)
            {
                removeInsideInfo();

            }
            else if (email.Checked)
            {
                removeInsideInfo();

            }
            else if (personal.Checked)
            {
                removeInsideInfo();

            }
            else if (letterToEditor.Checked)
            {
                removeInsideInfo();

            }
            else
            {

            }
        }

        
    }
}

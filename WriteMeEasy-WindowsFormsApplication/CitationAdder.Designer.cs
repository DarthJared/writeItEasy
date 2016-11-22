namespace WriteMeEasy_WindowsFormsApplication
{
    partial class CitationAdder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sourceTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.email = new System.Windows.Forms.RadioButton();
            this.shortStory = new System.Windows.Forms.RadioButton();
            this.editorial = new System.Windows.Forms.RadioButton();
            this.music = new System.Windows.Forms.RadioButton();
            this.tvEpisode = new System.Windows.Forms.RadioButton();
            this.movie = new System.Windows.Forms.RadioButton();
            this.interview = new System.Windows.Forms.RadioButton();
            this.blogDiscussion = new System.Windows.Forms.RadioButton();
            this.onlineEncyclopedia = new System.Windows.Forms.RadioButton();
            this.onlineNewspaper = new System.Windows.Forms.RadioButton();
            this.onlineOnlyJournal = new System.Windows.Forms.RadioButton();
            this.onlinePeriodical = new System.Windows.Forms.RadioButton();
            this.governmentDocument = new System.Windows.Forms.RadioButton();
            this.unpublishedDissertation = new System.Windows.Forms.RadioButton();
            this.publishedDissertation = new System.Windows.Forms.RadioButton();
            this.encyclopedia = new System.Windows.Forms.RadioButton();
            this.translated = new System.Windows.Forms.RadioButton();
            this.book = new System.Windows.Forms.RadioButton();
            this.review = new System.Windows.Forms.RadioButton();
            this.letterToEditor = new System.Windows.Forms.RadioButton();
            this.newspaper = new System.Windows.Forms.RadioButton();
            this.magazine = new System.Windows.Forms.RadioButton();
            this.journal = new System.Windows.Forms.RadioButton();
            this.sourceInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.sourceInfoPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.quoteContentGroupBox = new System.Windows.Forms.GroupBox();
            this.quoteContent = new System.Windows.Forms.RichTextBox();
            this.onlinePrintJournal = new System.Windows.Forms.RadioButton();
            this.website = new System.Windows.Forms.RadioButton();
            this.presentation = new System.Windows.Forms.RadioButton();
            this.art = new System.Windows.Forms.RadioButton();
            this.cdSong = new System.Windows.Forms.RadioButton();
            this.sourceTypeGroupBox.SuspendLayout();
            this.sourceInfoGroupBox.SuspendLayout();
            this.quoteContentGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // sourceTypeGroupBox
            // 
            this.sourceTypeGroupBox.Controls.Add(this.cdSong);
            this.sourceTypeGroupBox.Controls.Add(this.art);
            this.sourceTypeGroupBox.Controls.Add(this.presentation);
            this.sourceTypeGroupBox.Controls.Add(this.website);
            this.sourceTypeGroupBox.Controls.Add(this.onlinePrintJournal);
            this.sourceTypeGroupBox.Controls.Add(this.email);
            this.sourceTypeGroupBox.Controls.Add(this.shortStory);
            this.sourceTypeGroupBox.Controls.Add(this.editorial);
            this.sourceTypeGroupBox.Controls.Add(this.music);
            this.sourceTypeGroupBox.Controls.Add(this.tvEpisode);
            this.sourceTypeGroupBox.Controls.Add(this.movie);
            this.sourceTypeGroupBox.Controls.Add(this.interview);
            this.sourceTypeGroupBox.Controls.Add(this.blogDiscussion);
            this.sourceTypeGroupBox.Controls.Add(this.onlineEncyclopedia);
            this.sourceTypeGroupBox.Controls.Add(this.onlineNewspaper);
            this.sourceTypeGroupBox.Controls.Add(this.onlineOnlyJournal);
            this.sourceTypeGroupBox.Controls.Add(this.onlinePeriodical);
            this.sourceTypeGroupBox.Controls.Add(this.governmentDocument);
            this.sourceTypeGroupBox.Controls.Add(this.unpublishedDissertation);
            this.sourceTypeGroupBox.Controls.Add(this.publishedDissertation);
            this.sourceTypeGroupBox.Controls.Add(this.encyclopedia);
            this.sourceTypeGroupBox.Controls.Add(this.translated);
            this.sourceTypeGroupBox.Controls.Add(this.book);
            this.sourceTypeGroupBox.Controls.Add(this.review);
            this.sourceTypeGroupBox.Controls.Add(this.letterToEditor);
            this.sourceTypeGroupBox.Controls.Add(this.newspaper);
            this.sourceTypeGroupBox.Controls.Add(this.magazine);
            this.sourceTypeGroupBox.Controls.Add(this.journal);
            this.sourceTypeGroupBox.Location = new System.Drawing.Point(32, 29);
            this.sourceTypeGroupBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.sourceTypeGroupBox.Name = "sourceTypeGroupBox";
            this.sourceTypeGroupBox.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.sourceTypeGroupBox.Size = new System.Drawing.Size(1813, 418);
            this.sourceTypeGroupBox.TabIndex = 0;
            this.sourceTypeGroupBox.TabStop = false;
            this.sourceTypeGroupBox.Text = "Type of Source";
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.Location = new System.Drawing.Point(1510, 357);
            this.email.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(124, 36);
            this.email.TabIndex = 55;
            this.email.Text = "Email";
            this.email.UseVisualStyleBackColor = true;
            this.email.CheckedChanged += new System.EventHandler(this.referenceTypeChange);
            // 
            // shortStory
            // 
            this.shortStory.AutoSize = true;
            this.shortStory.Location = new System.Drawing.Point(16, 153);
            this.shortStory.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.shortStory.Name = "shortStory";
            this.shortStory.Size = new System.Drawing.Size(193, 36);
            this.shortStory.TabIndex = 53;
            this.shortStory.Text = "Short Story";
            this.shortStory.UseVisualStyleBackColor = true;
            this.shortStory.CheckedChanged += new System.EventHandler(this.referenceTypeChange);
            // 
            // editorial
            // 
            this.editorial.AutoSize = true;
            this.editorial.Location = new System.Drawing.Point(1007, 153);
            this.editorial.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.editorial.Name = "editorial";
            this.editorial.Size = new System.Drawing.Size(157, 36);
            this.editorial.TabIndex = 52;
            this.editorial.Text = "Editorial";
            this.editorial.UseVisualStyleBackColor = true;
            this.editorial.CheckedChanged += new System.EventHandler(this.referenceTypeChange);
            // 
            // music
            // 
            this.music.AutoSize = true;
            this.music.Location = new System.Drawing.Point(1510, 257);
            this.music.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.music.Name = "music";
            this.music.Size = new System.Drawing.Size(119, 36);
            this.music.TabIndex = 51;
            this.music.Text = "Song";
            this.music.UseVisualStyleBackColor = true;
            this.music.CheckedChanged += new System.EventHandler(this.referenceTypeChange);
            // 
            // tvEpisode
            // 
            this.tvEpisode.AutoSize = true;
            this.tvEpisode.Location = new System.Drawing.Point(1510, 153);
            this.tvEpisode.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tvEpisode.Name = "tvEpisode";
            this.tvEpisode.Size = new System.Drawing.Size(199, 36);
            this.tvEpisode.TabIndex = 50;
            this.tvEpisode.Text = "TV Episode";
            this.tvEpisode.UseVisualStyleBackColor = true;
            this.tvEpisode.CheckedChanged += new System.EventHandler(this.referenceTypeChange);
            // 
            // movie
            // 
            this.movie.AutoSize = true;
            this.movie.Location = new System.Drawing.Point(1510, 207);
            this.movie.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.movie.Name = "movie";
            this.movie.Size = new System.Drawing.Size(128, 36);
            this.movie.TabIndex = 48;
            this.movie.Text = "Movie";
            this.movie.UseVisualStyleBackColor = true;
            this.movie.CheckedChanged += new System.EventHandler(this.referenceTypeChange);
            // 
            // interview
            // 
            this.interview.AutoSize = true;
            this.interview.Location = new System.Drawing.Point(1510, 98);
            this.interview.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.interview.Name = "interview";
            this.interview.Size = new System.Drawing.Size(285, 36);
            this.interview.TabIndex = 47;
            this.interview.Text = "Personal Interview";
            this.interview.UseVisualStyleBackColor = true;
            this.interview.CheckedChanged += new System.EventHandler(this.referenceTypeChange);
            // 
            // blogDiscussion
            // 
            this.blogDiscussion.AutoSize = true;
            this.blogDiscussion.Location = new System.Drawing.Point(494, 357);
            this.blogDiscussion.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.blogDiscussion.Name = "blogDiscussion";
            this.blogDiscussion.Size = new System.Drawing.Size(442, 36);
            this.blogDiscussion.TabIndex = 42;
            this.blogDiscussion.Text = "Online Discussion or Blog Post";
            this.blogDiscussion.UseVisualStyleBackColor = true;
            this.blogDiscussion.CheckedChanged += new System.EventHandler(this.referenceTypeChange);
            // 
            // onlineEncyclopedia
            // 
            this.onlineEncyclopedia.AutoSize = true;
            this.onlineEncyclopedia.Location = new System.Drawing.Point(494, 307);
            this.onlineEncyclopedia.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.onlineEncyclopedia.Name = "onlineEncyclopedia";
            this.onlineEncyclopedia.Size = new System.Drawing.Size(480, 36);
            this.onlineEncyclopedia.TabIndex = 33;
            this.onlineEncyclopedia.Text = "Online Encyclopedia or Dictionary";
            this.onlineEncyclopedia.UseVisualStyleBackColor = true;
            this.onlineEncyclopedia.CheckedChanged += new System.EventHandler(this.referenceTypeChange);
            // 
            // onlineNewspaper
            // 
            this.onlineNewspaper.AutoSize = true;
            this.onlineNewspaper.Location = new System.Drawing.Point(494, 257);
            this.onlineNewspaper.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.onlineNewspaper.Name = "onlineNewspaper";
            this.onlineNewspaper.Size = new System.Drawing.Size(373, 36);
            this.onlineNewspaper.TabIndex = 28;
            this.onlineNewspaper.Text = "Online Newspaper Article";
            this.onlineNewspaper.UseVisualStyleBackColor = true;
            this.onlineNewspaper.CheckedChanged += new System.EventHandler(this.referenceTypeChange);
            // 
            // onlineOnlyJournal
            // 
            this.onlineOnlyJournal.AutoSize = true;
            this.onlineOnlyJournal.Location = new System.Drawing.Point(494, 98);
            this.onlineOnlyJournal.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.onlineOnlyJournal.Name = "onlineOnlyJournal";
            this.onlineOnlyJournal.Size = new System.Drawing.Size(428, 36);
            this.onlineOnlyJournal.TabIndex = 25;
            this.onlineOnlyJournal.Text = "Online Only Scholarly Journal";
            this.onlineOnlyJournal.UseVisualStyleBackColor = true;
            this.onlineOnlyJournal.CheckedChanged += new System.EventHandler(this.referenceTypeChange);
            // 
            // onlinePeriodical
            // 
            this.onlinePeriodical.AutoSize = true;
            this.onlinePeriodical.Location = new System.Drawing.Point(494, 207);
            this.onlinePeriodical.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.onlinePeriodical.Name = "onlinePeriodical";
            this.onlinePeriodical.Size = new System.Drawing.Size(270, 36);
            this.onlinePeriodical.TabIndex = 24;
            this.onlinePeriodical.Text = "Online Periodical";
            this.onlinePeriodical.UseVisualStyleBackColor = true;
            this.onlinePeriodical.CheckedChanged += new System.EventHandler(this.referenceTypeChange);
            // 
            // governmentDocument
            // 
            this.governmentDocument.AutoSize = true;
            this.governmentDocument.Location = new System.Drawing.Point(1007, 257);
            this.governmentDocument.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.governmentDocument.Name = "governmentDocument";
            this.governmentDocument.Size = new System.Drawing.Size(344, 36);
            this.governmentDocument.TabIndex = 21;
            this.governmentDocument.Text = "Government Document";
            this.governmentDocument.UseVisualStyleBackColor = true;
            this.governmentDocument.CheckedChanged += new System.EventHandler(this.referenceTypeChange);
            // 
            // unpublishedDissertation
            // 
            this.unpublishedDissertation.AutoSize = true;
            this.unpublishedDissertation.Location = new System.Drawing.Point(1007, 98);
            this.unpublishedDissertation.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.unpublishedDissertation.Name = "unpublishedDissertation";
            this.unpublishedDissertation.Size = new System.Drawing.Size(493, 36);
            this.unpublishedDissertation.TabIndex = 20;
            this.unpublishedDissertation.Text = "Unpublished Dissertation or Thesis";
            this.unpublishedDissertation.UseVisualStyleBackColor = true;
            this.unpublishedDissertation.CheckedChanged += new System.EventHandler(this.referenceTypeChange);
            // 
            // publishedDissertation
            // 
            this.publishedDissertation.AutoSize = true;
            this.publishedDissertation.Location = new System.Drawing.Point(1007, 43);
            this.publishedDissertation.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.publishedDissertation.Name = "publishedDissertation";
            this.publishedDissertation.Size = new System.Drawing.Size(460, 36);
            this.publishedDissertation.TabIndex = 19;
            this.publishedDissertation.Text = "Published Dissertation or Thesis";
            this.publishedDissertation.UseVisualStyleBackColor = true;
            this.publishedDissertation.CheckedChanged += new System.EventHandler(this.referenceTypeChange);
            // 
            // encyclopedia
            // 
            this.encyclopedia.AutoSize = true;
            this.encyclopedia.Location = new System.Drawing.Point(16, 207);
            this.encyclopedia.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.encyclopedia.Name = "encyclopedia";
            this.encyclopedia.Size = new System.Drawing.Size(462, 36);
            this.encyclopedia.TabIndex = 17;
            this.encyclopedia.Text = "Encyclopedia or Dictionary Entry";
            this.encyclopedia.UseVisualStyleBackColor = true;
            this.encyclopedia.CheckedChanged += new System.EventHandler(this.referenceTypeChange);
            // 
            // translated
            // 
            this.translated.AutoSize = true;
            this.translated.Location = new System.Drawing.Point(16, 98);
            this.translated.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.translated.Name = "translated";
            this.translated.Size = new System.Drawing.Size(259, 36);
            this.translated.TabIndex = 15;
            this.translated.Text = "Translated Book";
            this.translated.UseVisualStyleBackColor = true;
            this.translated.CheckedChanged += new System.EventHandler(this.referenceTypeChange);
            // 
            // book
            // 
            this.book.AutoSize = true;
            this.book.Checked = true;
            this.book.Location = new System.Drawing.Point(16, 43);
            this.book.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.book.Name = "book";
            this.book.Size = new System.Drawing.Size(117, 36);
            this.book.TabIndex = 14;
            this.book.TabStop = true;
            this.book.Text = "Book";
            this.book.UseVisualStyleBackColor = true;
            this.book.CheckedChanged += new System.EventHandler(this.referenceTypeChange);
            // 
            // review
            // 
            this.review.AutoSize = true;
            this.review.Location = new System.Drawing.Point(1007, 307);
            this.review.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.review.Name = "review";
            this.review.Size = new System.Drawing.Size(145, 36);
            this.review.TabIndex = 13;
            this.review.Text = "Review";
            this.review.UseVisualStyleBackColor = true;
            this.review.CheckedChanged += new System.EventHandler(this.referenceTypeChange);
            // 
            // letterToEditor
            // 
            this.letterToEditor.AutoSize = true;
            this.letterToEditor.Location = new System.Drawing.Point(1007, 207);
            this.letterToEditor.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.letterToEditor.Name = "letterToEditor";
            this.letterToEditor.Size = new System.Drawing.Size(285, 36);
            this.letterToEditor.TabIndex = 12;
            this.letterToEditor.Text = "Letter to the Editor";
            this.letterToEditor.UseVisualStyleBackColor = true;
            this.letterToEditor.CheckedChanged += new System.EventHandler(this.referenceTypeChange);
            // 
            // newspaper
            // 
            this.newspaper.AutoSize = true;
            this.newspaper.Location = new System.Drawing.Point(16, 307);
            this.newspaper.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.newspaper.Name = "newspaper";
            this.newspaper.Size = new System.Drawing.Size(282, 36);
            this.newspaper.TabIndex = 11;
            this.newspaper.Text = "Newspaper Article";
            this.newspaper.UseVisualStyleBackColor = true;
            this.newspaper.CheckedChanged += new System.EventHandler(this.referenceTypeChange);
            // 
            // magazine
            // 
            this.magazine.AutoSize = true;
            this.magazine.Location = new System.Drawing.Point(16, 357);
            this.magazine.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.magazine.Name = "magazine";
            this.magazine.Size = new System.Drawing.Size(263, 36);
            this.magazine.TabIndex = 10;
            this.magazine.Text = "Magazine Article";
            this.magazine.UseVisualStyleBackColor = true;
            this.magazine.CheckedChanged += new System.EventHandler(this.referenceTypeChange);
            // 
            // journal
            // 
            this.journal.AutoSize = true;
            this.journal.Location = new System.Drawing.Point(16, 257);
            this.journal.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.journal.Name = "journal";
            this.journal.Size = new System.Drawing.Size(233, 36);
            this.journal.TabIndex = 9;
            this.journal.Text = "Journal Article";
            this.journal.UseVisualStyleBackColor = true;
            this.journal.CheckedChanged += new System.EventHandler(this.referenceTypeChange);
            // 
            // sourceInfoGroupBox
            // 
            this.sourceInfoGroupBox.Controls.Add(this.sourceInfoPanel);
            this.sourceInfoGroupBox.Location = new System.Drawing.Point(32, 651);
            this.sourceInfoGroupBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.sourceInfoGroupBox.Name = "sourceInfoGroupBox";
            this.sourceInfoGroupBox.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.sourceInfoGroupBox.Size = new System.Drawing.Size(1813, 370);
            this.sourceInfoGroupBox.TabIndex = 1;
            this.sourceInfoGroupBox.TabStop = false;
            this.sourceInfoGroupBox.Text = "Source Information";
            // 
            // sourceInfoPanel
            // 
            this.sourceInfoPanel.BackColor = System.Drawing.SystemColors.Control;
            this.sourceInfoPanel.Location = new System.Drawing.Point(24, 45);
            this.sourceInfoPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sourceInfoPanel.Name = "sourceInfoPanel";
            this.sourceInfoPanel.Size = new System.Drawing.Size(1776, 329);
            this.sourceInfoPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1579, 1276);
            this.button1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(267, 55);
            this.button1.TabIndex = 2;
            this.button1.Text = "Create Citation";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(1296, 1276);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(267, 55);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // quoteContentGroupBox
            // 
            this.quoteContentGroupBox.Controls.Add(this.quoteContent);
            this.quoteContentGroupBox.Location = new System.Drawing.Point(32, 1035);
            this.quoteContentGroupBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.quoteContentGroupBox.Name = "quoteContentGroupBox";
            this.quoteContentGroupBox.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.quoteContentGroupBox.Size = new System.Drawing.Size(1813, 215);
            this.quoteContentGroupBox.TabIndex = 4;
            this.quoteContentGroupBox.TabStop = false;
            this.quoteContentGroupBox.Text = "Content";
            // 
            // quoteContent
            // 
            this.quoteContent.Location = new System.Drawing.Point(24, 45);
            this.quoteContent.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.quoteContent.Name = "quoteContent";
            this.quoteContent.Size = new System.Drawing.Size(1748, 149);
            this.quoteContent.TabIndex = 0;
            this.quoteContent.Text = "";
            // 
            // onlinePrintJournal
            // 
            this.onlinePrintJournal.AutoSize = true;
            this.onlinePrintJournal.Location = new System.Drawing.Point(494, 153);
            this.onlinePrintJournal.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.onlinePrintJournal.Name = "onlinePrintJournal";
            this.onlinePrintJournal.Size = new System.Drawing.Size(483, 36);
            this.onlinePrintJournal.TabIndex = 57;
            this.onlinePrintJournal.Text = "Online and Print Scholarly Journal";
            this.onlinePrintJournal.UseVisualStyleBackColor = true;
            // 
            // website
            // 
            this.website.AutoSize = true;
            this.website.Location = new System.Drawing.Point(494, 43);
            this.website.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.website.Name = "website";
            this.website.Size = new System.Drawing.Size(155, 36);
            this.website.TabIndex = 58;
            this.website.Text = "Website";
            this.website.UseVisualStyleBackColor = true;
            // 
            // presentation
            // 
            this.presentation.AutoSize = true;
            this.presentation.Location = new System.Drawing.Point(1510, 43);
            this.presentation.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.presentation.Name = "presentation";
            this.presentation.Size = new System.Drawing.Size(274, 36);
            this.presentation.TabIndex = 59;
            this.presentation.Text = "Oral Presentation";
            this.presentation.UseVisualStyleBackColor = true;
            // 
            // art
            // 
            this.art.AutoSize = true;
            this.art.Location = new System.Drawing.Point(1007, 357);
            this.art.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.art.Name = "art";
            this.art.Size = new System.Drawing.Size(488, 36);
            this.art.TabIndex = 60;
            this.art.Text = "Painting, Sculpture, or Photograph";
            this.art.UseVisualStyleBackColor = true;
            // 
            // cdSong
            // 
            this.cdSong.AutoSize = true;
            this.cdSong.Location = new System.Drawing.Point(1510, 307);
            this.cdSong.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cdSong.Name = "cdSong";
            this.cdSong.Size = new System.Drawing.Size(205, 36);
            this.cdSong.TabIndex = 61;
            this.cdSong.Text = "Song on CD";
            this.cdSong.UseVisualStyleBackColor = true;
            // 
            // CitationAdder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1851, 1023);
            this.Controls.Add(this.quoteContentGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sourceInfoGroupBox);
            this.Controls.Add(this.sourceTypeGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1883, 1378);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1651, 939);
            this.Name = "CitationAdder";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Add a Quote and Citation";
            this.sourceTypeGroupBox.ResumeLayout(false);
            this.sourceTypeGroupBox.PerformLayout();
            this.sourceInfoGroupBox.ResumeLayout(false);
            this.quoteContentGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox sourceTypeGroupBox;
        private System.Windows.Forms.GroupBox sourceInfoGroupBox;
        private System.Windows.Forms.RadioButton journal;
        private System.Windows.Forms.RadioButton email;
        private System.Windows.Forms.RadioButton shortStory;
        private System.Windows.Forms.RadioButton editorial;
        private System.Windows.Forms.RadioButton music;
        private System.Windows.Forms.RadioButton tvEpisode;
        private System.Windows.Forms.RadioButton movie;
        private System.Windows.Forms.RadioButton interview;
        private System.Windows.Forms.RadioButton blogDiscussion;
        private System.Windows.Forms.RadioButton onlineEncyclopedia;
        private System.Windows.Forms.RadioButton onlineNewspaper;
        private System.Windows.Forms.RadioButton onlineOnlyJournal;
        private System.Windows.Forms.RadioButton onlinePeriodical;
        private System.Windows.Forms.RadioButton governmentDocument;
        private System.Windows.Forms.RadioButton unpublishedDissertation;
        private System.Windows.Forms.RadioButton publishedDissertation;
        private System.Windows.Forms.RadioButton encyclopedia;
        private System.Windows.Forms.RadioButton translated;
        private System.Windows.Forms.RadioButton book;
        private System.Windows.Forms.RadioButton review;
        private System.Windows.Forms.RadioButton letterToEditor;
        private System.Windows.Forms.RadioButton newspaper;
        private System.Windows.Forms.RadioButton magazine;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox quoteContentGroupBox;
        private System.Windows.Forms.RichTextBox quoteContent;
        private System.Windows.Forms.Panel sourceInfoPanel;
        private System.Windows.Forms.RadioButton website;
        private System.Windows.Forms.RadioButton onlinePrintJournal;
        private System.Windows.Forms.RadioButton cdSong;
        private System.Windows.Forms.RadioButton art;
        private System.Windows.Forms.RadioButton presentation;
    }
}
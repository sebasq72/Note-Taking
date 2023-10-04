namespace Note_Taking
{
    partial class NoteForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnSave = new Button();
            BtnDelete = new Button();
            BtnNew = new Button();
            LblTitle = new Label();
            TxtTitle = new TextBox();
            LblNote = new Label();
            TxtNote = new TextBox();
            GrvNotes = new DataGridView();
            BtnRead = new Button();
            ((System.ComponentModel.ISupportInitialize)GrvNotes).BeginInit();
            SuspendLayout();
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(448, 330);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(75, 23);
            BtnSave.TabIndex = 0;
            BtnSave.Text = "Save";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnDelete
            // 
            BtnDelete.Location = new Point(581, 330);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(75, 23);
            BtnDelete.TabIndex = 1;
            BtnDelete.Text = "Delete";
            BtnDelete.UseVisualStyleBackColor = true;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // BtnNew
            // 
            BtnNew.Location = new Point(51, 12);
            BtnNew.Name = "BtnNew";
            BtnNew.Size = new Size(75, 23);
            BtnNew.TabIndex = 2;
            BtnNew.Text = "New";
            BtnNew.UseVisualStyleBackColor = true;
            BtnNew.Click += BtnNew_Click;
            // 
            // LblTitle
            // 
            LblTitle.AutoSize = true;
            LblTitle.Location = new Point(16, 56);
            LblTitle.Name = "LblTitle";
            LblTitle.Size = new Size(29, 15);
            LblTitle.TabIndex = 3;
            LblTitle.Text = "Title";
            // 
            // TxtTitle
            // 
            TxtTitle.Location = new Point(51, 53);
            TxtTitle.Name = "TxtTitle";
            TxtTitle.Size = new Size(288, 23);
            TxtTitle.TabIndex = 4;
            // 
            // LblNote
            // 
            LblNote.AutoSize = true;
            LblNote.Location = new Point(16, 85);
            LblNote.Name = "LblNote";
            LblNote.Size = new Size(33, 15);
            LblNote.TabIndex = 3;
            LblNote.Text = "Note";
            // 
            // TxtNote
            // 
            TxtNote.Location = new Point(51, 82);
            TxtNote.Multiline = true;
            TxtNote.Name = "TxtNote";
            TxtNote.Size = new Size(288, 210);
            TxtNote.TabIndex = 4;
            // 
            // GrvNotes
            // 
            GrvNotes.AllowUserToAddRows = false;
            GrvNotes.AllowUserToDeleteRows = false;
            GrvNotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GrvNotes.Location = new Point(367, 56);
            GrvNotes.Name = "GrvNotes";
            GrvNotes.ReadOnly = true;
            GrvNotes.RowTemplate.Height = 25;
            GrvNotes.Size = new Size(289, 236);
            GrvNotes.TabIndex = 5;
            // 
            // BtnRead
            // 
            BtnRead.Location = new Point(367, 330);
            BtnRead.Name = "BtnRead";
            BtnRead.Size = new Size(75, 23);
            BtnRead.TabIndex = 6;
            BtnRead.Text = "Read";
            BtnRead.UseVisualStyleBackColor = true;
            BtnRead.Click += BtnRead_Click;
            // 
            // NoteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(668, 369);
            Controls.Add(BtnRead);
            Controls.Add(GrvNotes);
            Controls.Add(TxtNote);
            Controls.Add(LblNote);
            Controls.Add(TxtTitle);
            Controls.Add(LblTitle);
            Controls.Add(BtnNew);
            Controls.Add(BtnDelete);
            Controls.Add(BtnSave);
            Name = "NoteForm";
            Text = "Notes";
            FormClosing += NoteForm_FormClosing;
            Load += NoteForm_Load;
            ((System.ComponentModel.ISupportInitialize)GrvNotes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnSave;
        private Button BtnDelete;
        private Button BtnNew;
        private Label LblTitle;
        private TextBox TxtTitle;
        private Label LblNote;
        private TextBox TxtNote;
        private DataGridView GrvNotes;
        private Button BtnRead;
    }
}
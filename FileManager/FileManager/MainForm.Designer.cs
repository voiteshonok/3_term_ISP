namespace FileManager
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.leftListBox = new System.Windows.Forms.ListBox();
            this.rightListBox = new System.Windows.Forms.ListBox();
            this.leftButton = new System.Windows.Forms.Button();
            this.leftTextBox = new System.Windows.Forms.TextBox();
            this.RightButton = new System.Windows.Forms.Button();
            this.rightTextBox = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.openButton = new System.Windows.Forms.Button();
            this.arhiveButton = new System.Windows.Forms.Button();
            this.extractButton = new System.Windows.Forms.Button();
            this.createFolderButton = new System.Windows.Forms.Button();
            this.createFileButton = new System.Windows.Forms.Button();
            this.moveToButton = new System.Windows.Forms.Button();
            this.copyToButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.infoButton = new System.Windows.Forms.Button();
            this.RenameFilebutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // leftListBox
            // 
            this.leftListBox.FormattingEnabled = true;
            this.leftListBox.ItemHeight = 20;
            this.leftListBox.Location = new System.Drawing.Point(12, 146);
            this.leftListBox.Name = "leftListBox";
            this.leftListBox.Size = new System.Drawing.Size(354, 504);
            this.leftListBox.TabIndex = 0;
            this.leftListBox.SelectedIndexChanged += new System.EventHandler(this.leftListBox_SelectedIndexChanged);
            this.leftListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.leftListBox_MouseDoubleClick);
            // 
            // rightListBox
            // 
            this.rightListBox.FormattingEnabled = true;
            this.rightListBox.ItemHeight = 20;
            this.rightListBox.Location = new System.Drawing.Point(566, 146);
            this.rightListBox.Name = "rightListBox";
            this.rightListBox.Size = new System.Drawing.Size(303, 504);
            this.rightListBox.TabIndex = 1;
            this.rightListBox.SelectedIndexChanged += new System.EventHandler(this.rightListBox_SelectedIndexChanged);
            this.rightListBox.DoubleClick += new System.EventHandler(this.rightListBox_DoubleClick);
            // 
            // leftButton
            // 
            this.leftButton.Location = new System.Drawing.Point(12, 95);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(204, 36);
            this.leftButton.TabIndex = 3;
            this.leftButton.Text = "back";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // leftTextBox
            // 
            this.leftTextBox.Location = new System.Drawing.Point(3, 28);
            this.leftTextBox.Name = "leftTextBox";
            this.leftTextBox.Size = new System.Drawing.Size(431, 26);
            this.leftTextBox.TabIndex = 4;
            this.leftTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.leftTextBox_KeyUp);
            // 
            // RightButton
            // 
            this.RightButton.Location = new System.Drawing.Point(566, 95);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(212, 36);
            this.RightButton.TabIndex = 5;
            this.RightButton.Text = "back";
            this.RightButton.UseVisualStyleBackColor = true;
            this.RightButton.Click += new System.EventHandler(this.RightButton_Click);
            // 
            // rightTextBox
            // 
            this.rightTextBox.Location = new System.Drawing.Point(489, 53);
            this.rightTextBox.Name = "rightTextBox";
            this.rightTextBox.Size = new System.Drawing.Size(267, 26);
            this.rightTextBox.TabIndex = 6;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(784, 47);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(107, 38);
            this.SearchButton.TabIndex = 7;
            this.SearchButton.Text = "search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(503, 28);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(0, 20);
            this.label.TabIndex = 8;
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(423, 104);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(80, 38);
            this.openButton.TabIndex = 9;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // arhiveButton
            // 
            this.arhiveButton.Location = new System.Drawing.Point(423, 160);
            this.arhiveButton.Name = "arhiveButton";
            this.arhiveButton.Size = new System.Drawing.Size(80, 38);
            this.arhiveButton.TabIndex = 10;
            this.arhiveButton.Text = "Arhive";
            this.arhiveButton.UseVisualStyleBackColor = true;
            this.arhiveButton.Click += new System.EventHandler(this.arhiveButton_Click);
            // 
            // extractButton
            // 
            this.extractButton.Location = new System.Drawing.Point(423, 215);
            this.extractButton.Name = "extractButton";
            this.extractButton.Size = new System.Drawing.Size(80, 38);
            this.extractButton.TabIndex = 11;
            this.extractButton.Text = "Extract";
            this.extractButton.UseVisualStyleBackColor = true;
            this.extractButton.Click += new System.EventHandler(this.extractButton_Click);
            // 
            // createFolderButton
            // 
            this.createFolderButton.Location = new System.Drawing.Point(409, 270);
            this.createFolderButton.Name = "createFolderButton";
            this.createFolderButton.Size = new System.Drawing.Size(113, 38);
            this.createFolderButton.TabIndex = 12;
            this.createFolderButton.Text = "CreateFolder";
            this.createFolderButton.UseVisualStyleBackColor = true;
            this.createFolderButton.Click += new System.EventHandler(this.createFolderButton_Click);
            // 
            // createFileButton
            // 
            this.createFileButton.Location = new System.Drawing.Point(409, 336);
            this.createFileButton.Name = "createFileButton";
            this.createFileButton.Size = new System.Drawing.Size(113, 38);
            this.createFileButton.TabIndex = 13;
            this.createFileButton.Text = "CreateFile";
            this.createFileButton.UseVisualStyleBackColor = true;
            this.createFileButton.Click += new System.EventHandler(this.createFileButton_Click);
            // 
            // moveToButton
            // 
            this.moveToButton.Location = new System.Drawing.Point(409, 444);
            this.moveToButton.Name = "moveToButton";
            this.moveToButton.Size = new System.Drawing.Size(113, 38);
            this.moveToButton.TabIndex = 14;
            this.moveToButton.Text = "MoveTo";
            this.moveToButton.UseVisualStyleBackColor = true;
            this.moveToButton.Click += new System.EventHandler(this.moveToButton_Click);
            // 
            // copyToButton
            // 
            this.copyToButton.Location = new System.Drawing.Point(409, 488);
            this.copyToButton.Name = "copyToButton";
            this.copyToButton.Size = new System.Drawing.Size(113, 38);
            this.copyToButton.TabIndex = 15;
            this.copyToButton.Text = "CopyTo";
            this.copyToButton.UseVisualStyleBackColor = true;
            this.copyToButton.Click += new System.EventHandler(this.copyToButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(409, 548);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(113, 38);
            this.deleteButton.TabIndex = 16;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // infoButton
            // 
            this.infoButton.Location = new System.Drawing.Point(409, 592);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(113, 38);
            this.infoButton.TabIndex = 17;
            this.infoButton.Text = "Info";
            this.infoButton.UseVisualStyleBackColor = true;
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // RenameFilebutton
            // 
            this.RenameFilebutton.Location = new System.Drawing.Point(409, 391);
            this.RenameFilebutton.Name = "RenameFilebutton";
            this.RenameFilebutton.Size = new System.Drawing.Size(113, 38);
            this.RenameFilebutton.TabIndex = 18;
            this.RenameFilebutton.Text = "RenameFile";
            this.RenameFilebutton.UseVisualStyleBackColor = true;
            this.RenameFilebutton.Click += new System.EventHandler(this.RenameFilebutton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(903, 662);
            this.Controls.Add(this.RenameFilebutton);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.copyToButton);
            this.Controls.Add(this.moveToButton);
            this.Controls.Add(this.createFileButton);
            this.Controls.Add(this.createFolderButton);
            this.Controls.Add(this.extractButton);
            this.Controls.Add(this.arhiveButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.label);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.rightTextBox);
            this.Controls.Add(this.RightButton);
            this.Controls.Add(this.leftTextBox);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.rightListBox);
            this.Controls.Add(this.leftListBox);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox leftListBox;
        private System.Windows.Forms.ListBox rightListBox;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.TextBox leftTextBox;
        private System.Windows.Forms.Button RightButton;
        private System.Windows.Forms.TextBox rightTextBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button arhiveButton;
        private System.Windows.Forms.Button extractButton;
        private System.Windows.Forms.Button createFolderButton;
        private System.Windows.Forms.Button createFileButton;
        private System.Windows.Forms.Button moveToButton;
        private System.Windows.Forms.Button copyToButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button infoButton;
        private System.Windows.Forms.Button RenameFilebutton;
    }
}


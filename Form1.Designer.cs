namespace ToDoProject
{
    partial class mainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.taskTextBox = new System.Windows.Forms.TextBox();
            this.addTaskButton = new System.Windows.Forms.Button();
            this.removeTaskButton = new System.Windows.Forms.Button();
            this.tasksListBox = new System.Windows.Forms.CheckedListBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.stripMenu = new System.Windows.Forms.MenuStrip();
            this.stripMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.stripMenuNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.stripMenuOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.stripMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.stripMenuSaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.stripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // taskTextBox
            // 
            this.taskTextBox.Location = new System.Drawing.Point(12, 38);
            this.taskTextBox.Name = "taskTextBox";
            this.taskTextBox.Size = new System.Drawing.Size(360, 20);
            this.taskTextBox.TabIndex = 0;
            this.taskTextBox.TextChanged += new System.EventHandler(this.taskTextBox_TextChanged);
            // 
            // addTaskButton
            // 
            this.addTaskButton.Location = new System.Drawing.Point(12, 64);
            this.addTaskButton.Name = "addTaskButton";
            this.addTaskButton.Size = new System.Drawing.Size(175, 23);
            this.addTaskButton.TabIndex = 1;
            this.addTaskButton.Text = "Add Task";
            this.addTaskButton.UseVisualStyleBackColor = true;
            this.addTaskButton.Click += new System.EventHandler(this.addTaskButton_Click);
            // 
            // removeTaskButton
            // 
            this.removeTaskButton.Location = new System.Drawing.Point(197, 64);
            this.removeTaskButton.Name = "removeTaskButton";
            this.removeTaskButton.Size = new System.Drawing.Size(175, 23);
            this.removeTaskButton.TabIndex = 2;
            this.removeTaskButton.Text = "Remove Task";
            this.removeTaskButton.UseVisualStyleBackColor = true;
            this.removeTaskButton.Click += new System.EventHandler(this.removeTaskButton_Click);
            // 
            // tasksListBox
            // 
            this.tasksListBox.FormattingEnabled = true;
            this.tasksListBox.Location = new System.Drawing.Point(12, 101);
            this.tasksListBox.Name = "tasksListBox";
            this.tasksListBox.Size = new System.Drawing.Size(360, 349);
            this.tasksListBox.TabIndex = 3;
            this.tasksListBox.SelectedIndexChanged += new System.EventHandler(this.tasksListBox_SelectedIndexChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "saveFileDialog";
            // 
            // stripMenu
            // 
            this.stripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripMenuFile});
            this.stripMenu.Location = new System.Drawing.Point(0, 0);
            this.stripMenu.Name = "stripMenu";
            this.stripMenu.Size = new System.Drawing.Size(384, 24);
            this.stripMenu.TabIndex = 5;
            this.stripMenu.Text = "menuStrip1";
            // 
            // stripMenuFile
            // 
            this.stripMenuFile.BackColor = System.Drawing.SystemColors.Control;
            this.stripMenuFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stripMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripMenuNewFile,
            this.stripMenuOpenFile,
            this.stripMenuSeparator,
            this.stripMenuSaveFile});
            this.stripMenuFile.Name = "stripMenuFile";
            this.stripMenuFile.Size = new System.Drawing.Size(38, 20);
            this.stripMenuFile.Text = "&Plik";
            this.stripMenuFile.Click += new System.EventHandler(this.stripMenuFile_Click);
            // 
            // stripMenuNewFile
            // 
            this.stripMenuNewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stripMenuNewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripMenuNewFile.Name = "stripMenuNewFile";
            this.stripMenuNewFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.stripMenuNewFile.Size = new System.Drawing.Size(180, 22);
            this.stripMenuNewFile.Text = "&Nowy";
            this.stripMenuNewFile.Click += new System.EventHandler(this.stripMenuNewFile_Click);
            // 
            // stripMenuOpenFile
            // 
            this.stripMenuOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stripMenuOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripMenuOpenFile.Name = "stripMenuOpenFile";
            this.stripMenuOpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.stripMenuOpenFile.Size = new System.Drawing.Size(180, 22);
            this.stripMenuOpenFile.Text = "&Otwórz";
            this.stripMenuOpenFile.Click += new System.EventHandler(this.stripMenuOpenFile_Click);
            // 
            // stripMenuSeparator
            // 
            this.stripMenuSeparator.Name = "stripMenuSeparator";
            this.stripMenuSeparator.Size = new System.Drawing.Size(177, 6);
            // 
            // stripMenuSaveFile
            // 
            this.stripMenuSaveFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stripMenuSaveFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripMenuSaveFile.Name = "stripMenuSaveFile";
            this.stripMenuSaveFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.stripMenuSaveFile.Size = new System.Drawing.Size(180, 22);
            this.stripMenuSaveFile.Text = "&Zapisz";
            this.stripMenuSaveFile.Click += new System.EventHandler(this.stripMenuSaveFile_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.stripMenu);
            this.Controls.Add(this.tasksListBox);
            this.Controls.Add(this.removeTaskButton);
            this.Controls.Add(this.addTaskButton);
            this.Controls.Add(this.taskTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "To Do List";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainForm_KeyDown);
            this.stripMenu.ResumeLayout(false);
            this.stripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox taskTextBox;
        private System.Windows.Forms.Button addTaskButton;
        private System.Windows.Forms.Button removeTaskButton;
        private System.Windows.Forms.CheckedListBox tasksListBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.MenuStrip stripMenu;
        private System.Windows.Forms.ToolStripMenuItem stripMenuFile;
        private System.Windows.Forms.ToolStripMenuItem stripMenuNewFile;
        private System.Windows.Forms.ToolStripMenuItem stripMenuOpenFile;
        private System.Windows.Forms.ToolStripSeparator stripMenuSeparator;
        private System.Windows.Forms.ToolStripMenuItem stripMenuSaveFile;
    }
}


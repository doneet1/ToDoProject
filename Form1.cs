using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoProject
{
    public partial class mainForm : Form
    {
        private string lastOpenedFilePath = "";
        private bool isDialogOpen = false;
        public mainForm()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(mainForm_KeyDown);
            this.KeyUp += new KeyEventHandler(mainForm_KeyUp);
            this.KeyPreview = true;
        }
        private void mainForm_Load(object sender, EventArgs e)
        {
            taskTextBox.Focus();
        }
        private void mainForm_KeyUp(object sender, KeyEventArgs e)
        {
            //Create new Task
            if (e.KeyCode == Keys.Return)
            {
                createNewTask();
            }
            //Delete selected Task
            if (e.KeyCode == Keys.Delete)
            {
                deleteTask();
            }
        }
        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //Select a Task
            if (e.Control && e.KeyCode == Keys.Tab)
            {
                if(tasksListBox.Items.Count > 0)
                {
                    tasksListBox.SelectedIndex = 0;
                }
            }
            //Create new File
            if (e.Control && e.KeyCode == Keys.N)
            {
                createNewFile();
            }
            //Open new File
            if (e.Control && e.KeyCode == Keys.O)
            {
                openNewFile();
            }
            //Save File
            if (e.Control && e.KeyCode == Keys.S)
            {
                saveTasksToFile();
            }
        }

        private void addTaskButton_Click(object sender, EventArgs e)
        {
            createNewTask();
        }

        private void removeTaskButton_Click(object sender, EventArgs e)
        {
            deleteTask();
        }
        private void stripMenuNewFile_Click(object sender, EventArgs e)
        {
            createNewFile();
        }

        private void stripMenuOpenFile_Click(object sender, EventArgs e)
        {
            openNewFile();
        }

        private void stripMenuSaveFile_Click(object sender, EventArgs e)
        {
            saveTasksToFile();
        }
        private void createNewTask()
        {
            if (!string.IsNullOrWhiteSpace(taskTextBox.Text))
            {
                tasksListBox.Items.Add(taskTextBox.Text);
                taskTextBox.Text = "";
            }
            taskTextBox.Focus();
        }
        private void deleteTask()
        {
            if (tasksListBox.SelectedIndex != -1)
            {
                tasksListBox.Items.RemoveAt(tasksListBox.SelectedIndex);
                if (tasksListBox.Items.Count > 0)
                {
                    tasksListBox.SelectedIndex = 0;
                }
                taskTextBox.Focus();
            }
        }
        private void createNewFile()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to create a new file?", "New File", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                tasksListBox.Items.Clear();
            }
            lastOpenedFilePath = "";
        }
        private void loadTasksFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            tasksListBox.Items.Clear();
            foreach (string line in lines)
            {
                tasksListBox.Items.Add(line);
            }
        }
        private void openNewFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    loadTasksFromFile(filePath);
                    lastOpenedFilePath = filePath;
                    this.Text = "To Do List " + Path.GetFileName(lastOpenedFilePath);
                }
            }
        }
        private void writeTasksToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var item in tasksListBox.Items)
                {
                    writer.WriteLine(item.ToString());
                }
            }
        }
        private void saveTasksToFile()
        {
            if (lastOpenedFilePath == "")
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.InitialDirectory = "c:\\";
                    saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        writeTasksToFile(filePath);
                        lastOpenedFilePath = filePath;
                        this.Text = "To Do List " + Path.GetFileName(lastOpenedFilePath);
                    }
                }
            }
            else
            {
                writeTasksToFile(lastOpenedFilePath);
                this.Text = "To Do List " + Path.GetFileName(lastOpenedFilePath);
                Cursor.Current = Cursors.WaitCursor;
                Thread.Sleep(50);
                Cursor.Current = Cursors.Default;
            }
        }
        private void taskTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void tasksListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void plikToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void stripMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void stripMenuFile_Click(object sender, EventArgs e)
        {

        }
    }
}

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
using System.Reflection;

namespace ToDoProject
{
    public partial class mainForm : Form
    {
        private string lastOpenedFilePath = "";
        private int editIndex = -1;
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
            //Create new Task or Edit Task
            if (e.KeyCode == Keys.Return)
            {
                if (checkIfTextBoxExists("dynamicTextBox") != null)
                {
                    editTask();
                }
                else
                {
                    createNewTask();
                }
            }
            //Edit a Task
            if (e.Control && e.KeyCode == Keys.E)
            {
                if (checkIfTextBoxExists("dynamicTextBox") == null && tasksListBox.SelectedIndex != -1)
                {
                    createTextBox();
                }
            }
            //Cancel editing a Task
            if (e.KeyCode == Keys.Escape)
            {
                if (checkIfTextBoxExists("dynamicTextBox") != null)
                {
                    checkIfTextBoxExists("dynamicTextBox").Dispose();
                    this.Controls.Remove(checkIfTextBoxExists("dynamicTextBox"));
                }
            }
            //Delete selected Task
            if (e.KeyCode == Keys.Delete)
            {
                if (editIndex != -1)
                {
                    deleteTask();
                }
            }
            //Select next Task
            if(e.KeyCode == Keys.Down)
            {
                if (tasksListBox.SelectedIndex < tasksListBox.Items.Count - 1 && editIndex == -1)
                {
                    tasksListBox.SelectedIndex++;
                }
            }
            //Select previous Task
            if (e.KeyCode == Keys.Up)
            {
                if (tasksListBox.SelectedIndex != 0 && editIndex == -1)
                {
                    tasksListBox.SelectedIndex--;
                }
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
            Control[] foundDynamicTextBox = this.Controls.Find("dynamicTextBox", true);
            if(foundDynamicTextBox.Length == 0)
            {
                if (!string.IsNullOrWhiteSpace(taskTextBox.Text))
                {
                    tasksListBox.Items.Add(taskTextBox.Text);
                    taskTextBox.Text = "";
                }
                taskTextBox.Focus();
            }
        }
        private TextBox checkIfTextBoxExists(string textBoxName)
        {
            Control[] foundDynamicTextBox = this.Controls.Find(textBoxName, true);
            if (foundDynamicTextBox.Length > 0 && foundDynamicTextBox[0] is TextBox)
            {
                return (TextBox)foundDynamicTextBox[0];
            }
            else
            {
                return null;
            }
        }
        private void createTextBox()
        {
            TextBox dynamicTextBox = new TextBox();

            Rectangle itemRectangle = tasksListBox.GetItemRectangle(tasksListBox.SelectedIndex);
            editIndex = tasksListBox.SelectedIndex;
            int x = itemRectangle.X;
            int y = itemRectangle.Y;
            dynamicTextBox.Location = new Point(x + 29, y + 101);
            dynamicTextBox.Size = new Size(343, 30);
            dynamicTextBox.Text = tasksListBox.Items[tasksListBox.SelectedIndex].ToString();
            dynamicTextBox.Name = "dynamicTextBox";

            if (tasksListBox.SelectedIndex != -1)
            {
                this.Controls.Add(dynamicTextBox);
                dynamicTextBox.BringToFront();
                dynamicTextBox.Focus();
            }
        }
        private void editTask()
        {
            if (checkIfTextBoxExists("dynamicTextBox") != null)
            {
                tasksListBox.Items[editIndex] = checkIfTextBoxExists("dynamicTextBox").Text;
                checkIfTextBoxExists("dynamicTextBox").Dispose();
                this.Controls.Remove(checkIfTextBoxExists("dynamicTextBox"));
                editIndex = -1;
            }
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
                if (!string.IsNullOrEmpty(line) || !string.IsNullOrWhiteSpace(line))
                {
                    tasksListBox.Items.Add(line);
                }
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

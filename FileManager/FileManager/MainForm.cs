using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace FileManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            App.InitializingManagers();
            initListBox(App.leftList, leftListBox, leftTextBox);
            initListBox(App.rightList, rightListBox);
        }

        private void initListBox(Manager manager, ListBox listBox, TextBox leftTextBox)
        {
            leftTextBox.Text = manager.CurrentDirectory;
            label.Text = $"search in { manager.CurrentDirectory.Remove(0, manager.CurrentDirectory.LastIndexOf('\\'))}";
            initListBox(manager, listBox);
        }

        private void initListBox(Manager manager, ListBox listBox)
        {
            listBox.Items.Clear();
            foreach (var temp in manager.list)
            {
                if (Directory.Exists(temp))
                {
                    listBox.Items.Add(temp.Remove(0, temp.LastIndexOf('\\')));
                }
                else
                {
                    listBox.Items.Add(Path.GetFileName(temp));
                }
            }
        }

        private void leftButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                App.leftList.Back();
            }
            catch
            {
                MessageBox.Show("Sorry your path is wrong, try once again");
            }
            initListBox(App.leftList, leftListBox, leftTextBox);
        }


        private void leftListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                App.leftList.GoToSelected(leftListBox.SelectedIndex);
            }
            catch
            {
                MessageBox.Show("Sorry your path is wrong, try once again");
            }
            initListBox(App.leftList, leftListBox, leftTextBox);
        }

        private void leftTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Directory.Exists(leftTextBox.Text))
                {
                    App.ChangeCurrentDirectory(leftTextBox.Text);
                }
                else
                {
                    MessageBox.Show("Sorry your path is wrong, try once again");
                }
                initListBox(App.leftList, leftListBox, leftTextBox);
            }
        }

        private void rightListBox_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                App.rightList.GoToSelected(rightListBox.SelectedIndex);
            }
            catch
            {
                MessageBox.Show("Sorry your path is wrong, try once again");
            }
            initListBox(App.rightList, rightListBox);
        }

        private void RightButton_Click(object sender, EventArgs e)
        {
            try
            {
                App.rightList.Back();
            }
            catch
            {
                MessageBox.Show("Sorry your path is wrong, try once again");
            }
            initListBox(App.rightList, rightListBox);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            App.rightList.Search(leftTextBox.Text, rightTextBox.Text);
            initListBox(App.rightList, rightListBox);
        }

        private void leftListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var temp = leftListBox.SelectedIndex;
            rightListBox.SelectedIndex = -1;
            leftListBox.SelectedIndex = temp;
        }

        private void rightListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var temp = rightListBox.SelectedIndex;
            leftListBox.SelectedIndex = -1;
            rightListBox.SelectedIndex = temp;
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (leftListBox.SelectedIndex >=0 && leftListBox.SelectedIndex < App.leftList.list.Count && File.Exists(App.leftList.list[leftListBox.SelectedIndex]))
            {
                new TextForm(App.leftList.list[leftListBox.SelectedIndex]).ShowDialog();
            }
            else if (rightListBox.SelectedIndex >= 0 && rightListBox.SelectedIndex < App.rightList.list.Count && File.Exists(App.rightList.list[rightListBox.SelectedIndex]))
            {
                new TextForm(App.rightList.list[rightListBox.SelectedIndex]).ShowDialog();
            }
        }

        private void arhiveButton_Click(object sender, EventArgs e)
        {
            if (leftListBox.SelectedIndex >= 0 && leftListBox.SelectedIndex < App.leftList.list.Count && Directory.Exists(App.leftList.list[leftListBox.SelectedIndex]))
            {
                ZipFile.CreateFromDirectory(App.leftList.list[leftListBox.SelectedIndex], App.leftList.list[leftListBox.SelectedIndex] + ".zip");
                App.leftList.list.Add(App.leftList.list[leftListBox.SelectedIndex] + ".zip");
                initListBox(App.leftList, leftListBox);
            }
            else if (rightListBox.SelectedIndex >= 0 && rightListBox.SelectedIndex < App.rightList.list.Count && Directory.Exists(App.rightList.list[rightListBox.SelectedIndex]))
            {
                ZipFile.CreateFromDirectory(App.rightList.list[rightListBox.SelectedIndex], App.rightList.list[rightListBox.SelectedIndex] + ".zip");
                App.rightList.list.Add(App.rightList.list[rightListBox.SelectedIndex] + ".zip");
                initListBox(App.rightList, rightListBox);
            }
        }

        private void extractButton_Click(object sender, EventArgs e)
        {
            if (leftListBox.SelectedIndex >= 0 && leftListBox.SelectedIndex < App.leftList.list.Count && App.leftList.list[leftListBox.SelectedIndex].EndsWith(".zip"))
            {
                try
                {
                    ZipFile.ExtractToDirectory(App.leftList.list[leftListBox.SelectedIndex], App.leftList.CurrentDirectory);
                    App.leftList = new Manager(App.leftList.CurrentDirectory);
                }
                catch
                {
                    MessageBox.Show("Unable to extact archive");
                }
                initListBox(App.leftList, leftListBox);
            }
            else if (rightListBox.SelectedIndex >= 0 && rightListBox.SelectedIndex < App.rightList.list.Count && App.rightList.list[rightListBox.SelectedIndex].EndsWith(".zip"))
            {
                try
                {
                    ZipFile.ExtractToDirectory(App.rightList.list[rightListBox.SelectedIndex], App.rightList.CurrentDirectory);
                    App.rightList = new Manager(App.rightList.CurrentDirectory);
                }
                catch
                {
                    MessageBox.Show("Unable to extact archive");
                }
                initListBox(App.rightList, rightListBox);
            }
        }

        private void createFolderButton_Click(object sender, EventArgs e)
        {
            if (leftListBox.SelectedIndex > -1)
            {
                string name = Path.Combine(App.leftList.CurrentDirectory, "NewFolder");

                if (!Directory.Exists(name))
                {
                    Directory.CreateDirectory(name);
                }
                else
                {
                    int i = 1;
                    for (; Directory.Exists(Path.Combine(App.leftList.CurrentDirectory, $"NewFolder{i}")); ++i) { }
                    Directory.CreateDirectory(Path.Combine(App.leftList.CurrentDirectory, $"NewFolder{i}"));
                }
                App.leftList = new Manager(App.leftList.CurrentDirectory);
                initListBox(App.leftList, leftListBox);
            }
            else if (rightListBox.SelectedIndex > -1)
            {
                string name = Path.Combine(App.rightList.CurrentDirectory, "NewFolder");

                if (!Directory.Exists(name))
                {
                    Directory.CreateDirectory(name);
                }
                else
                {
                    int i = 1;
                    for (; Directory.Exists(Path.Combine(App.rightList.CurrentDirectory, $"NewFolder{i}")); ++i) { }
                    Directory.CreateDirectory(Path.Combine(App.rightList.CurrentDirectory, $"NewFolder{i}"));
                }
                App.rightList = new Manager(App.rightList.CurrentDirectory);
                initListBox(App.rightList, rightListBox);
            }
        }

        private void createFileButton_Click(object sender, EventArgs e)
        {
            if (leftListBox.SelectedIndex > -1)
            {
                string name = Path.Combine(App.leftList.CurrentDirectory, "NewFile.txt");

                if (!File.Exists(name))
                {
                    File.Create(name).Close();
                }
                else
                {
                    int i = 1;
                    for (; File.Exists(Path.Combine(App.leftList.CurrentDirectory, $"NewFile{i}.txt")); ++i) { }
                    File.Create(Path.Combine(App.leftList.CurrentDirectory, $"NewFile{i}.txt")).Close();
                }
                App.leftList = new Manager(App.leftList.CurrentDirectory);
                initListBox(App.leftList, leftListBox);
            }
            else if (rightListBox.SelectedIndex > -1)
            {
                string name = Path.Combine(App.rightList.CurrentDirectory, "NewFile.txt");

                if (!File.Exists(name))
                {
                    File.Create(name).Close();
                }
                else
                {
                    int i = 1;
                    for (; File.Exists(Path.Combine(App.rightList.CurrentDirectory, $"NewFile{i}.txt")); ++i) { }
                    File.Create(Path.Combine(App.rightList.CurrentDirectory, $"NewFile{i}.txt")).Close();
                }
                App.rightList = new Manager(App.rightList.CurrentDirectory);
                initListBox(App.rightList, rightListBox);
            }
        }

        private void moveToButton_Click(object sender, EventArgs e)
        {
            if (leftListBox.SelectedIndex > -1)
            {
                string name = App.leftList.list[leftListBox.SelectedIndex];

                if (File.Exists(name))
                {
                    File.Move(name, Path.Combine(App.rightList.CurrentDirectory, Path.GetFileName(name)));
                    App.rightList = new Manager();
                    initListBox(App.rightList, rightListBox);
                    App.leftList = new Manager();
                    initListBox(App.leftList, leftListBox);
                }
            }
            else if (rightListBox.SelectedIndex > -1)
            {
                string name = App.rightList.list[rightListBox.SelectedIndex];

                if (File.Exists(name))
                {
                    File.Move(name, Path.Combine(App.leftList.CurrentDirectory, Path.GetFileName(name)));
                    App.rightList = new Manager();
                    initListBox(App.rightList, rightListBox);
                    App.leftList = new Manager();
                    initListBox(App.leftList, leftListBox);
                }
            }
        }

        private void copyToButton_Click(object sender, EventArgs e)
        {
            if (leftListBox.SelectedIndex > -1)
            {
                string name = App.leftList.list[leftListBox.SelectedIndex];

                if (File.Exists(name))
                {
                    File.Copy(name, Path.Combine(App.rightList.CurrentDirectory, Path.GetFileName(name)), true);
                    App.rightList = new Manager();
                    initListBox(App.rightList, rightListBox);
                }
            }
            else if (rightListBox.SelectedIndex > -1)
            {
                string name = App.rightList.list[rightListBox.SelectedIndex];

                if (File.Exists(name))
                {
                    File.Copy(name, Path.Combine(App.leftList.CurrentDirectory, Path.GetFileName(name)), true);
                    App.leftList = new Manager();
                    initListBox(App.leftList, leftListBox);
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (leftListBox.SelectedIndex > -1)
            {
                string name = App.leftList.list[leftListBox.SelectedIndex];

                if (File.Exists(name))
                {
                    File.Delete(name);
                }
                else if (Directory.Exists(name))
                {
                    Directory.Delete(name, true);
                }
                App.leftList = new Manager();
                initListBox(App.leftList, leftListBox);
            }
            else if (rightListBox.SelectedIndex > -1)
            {
                string name = App.rightList.list[rightListBox.SelectedIndex];

                if (File.Exists(name))
                {
                    File.Delete(name);
                }
                else if (Directory.Exists(name))
                {
                    Directory.Delete(name, true);
                }
                App.rightList = new Manager();
                initListBox(App.rightList, rightListBox);
            }
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            string name="";

            if (leftListBox.SelectedIndex > -1)
            {
                name = App.leftList.list[leftListBox.SelectedIndex];
            }
            else if (rightListBox.SelectedIndex > -1)
            {
                name = App.rightList.list[rightListBox.SelectedIndex];
            }
            if (String.IsNullOrEmpty(name)) return;
            if (Directory.Exists(name))
            {
                MessageBox.Show($"CreationTime:\t{Directory.GetCreationTime(name).ToString()}\n" +
                    $"AccessControl:\t{Directory.GetAccessControl(name).ToString()}\n" +
                    $"LastAccessTime:\t{Directory.GetLastAccessTime(name).ToString()}\n" +
                    $"Name:\t{new DirectoryInfo(name).Name}");
            }
            else if (File.Exists(name))
            {
                MessageBox.Show($"CreationTime:\t{File.GetCreationTime(name).ToString()}\n" +
                    $"AccessControl:\t{File.GetAccessControl(name).ToString()}\n" +
                    $"LastAccessTime:\t{File.GetLastAccessTime(name).ToString()}\n" +
                    $"Length:\t{new FileInfo(name).Length}\n" +
                    $"Name:\t{new FileInfo(name).Name}");
            }
        }

        private void RenameFilebutton_Click(object sender, EventArgs e)
        {
            string newName="";
            string name = "";

            if (leftListBox.SelectedIndex > -1)
            {
                name = App.leftList.list[leftListBox.SelectedIndex];

                if (String.IsNullOrEmpty(name)) return;
                if (File.Exists(name))
                {
                    var temp = new RenameForm();
                    temp.ShowDialog();
                    newName = temp.NewName;
                }
                if (!File.Exists(Path.Combine(App.leftList.CurrentDirectory, newName)))
                {
                    File.Move(name, Path.Combine(App.leftList.CurrentDirectory, newName));
                }
                App.leftList = new Manager();
                initListBox(App.leftList, leftListBox);
            }
            else if (rightListBox.SelectedIndex > -1)
            {
                name = App.rightList.list[rightListBox.SelectedIndex];

                if (String.IsNullOrEmpty(name)) return;
                if (File.Exists(name))
                {
                    var temp = new RenameForm();
                    temp.ShowDialog();
                    newName = temp.NewName;
                }
                if (!File.Exists(Path.Combine(App.rightList.CurrentDirectory, newName)))
                {
                    File.Move(name, Path.Combine(App.rightList.CurrentDirectory, newName));
                }
                App.rightList = new Manager();
                initListBox(App.rightList, rightListBox);
            }
        }
    }
}




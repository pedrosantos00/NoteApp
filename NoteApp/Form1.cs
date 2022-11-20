using NoteApp.Properties;
using System;
using System.Data;
using System.Windows.Forms;

namespace NoteApp
{
    public partial class Form1 : Form
    {
        public DataTable NotesList = new DataTable();
        public List<Notes> listaNotas = new List<Notes>(); // Para futuro database
        public Form1()
        {
            InitializeComponent();
            checkBox1.Checked = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && richTextBox1.Text != "" || textBox1.Text != "")
            {
                string title = textBox1.Text;
                string desc = richTextBox1.Text;
                Button newButton = new Button();
                if (checkBox1.Checked)
                {
                    DateTime data = this.dateTimePicker1.Value.Date;
                    Notes notas = new Notes(title, desc, data);
                    NotesList.Rows.Add(notas.Title, notas.Description, notas.Data.ToString("d"));
                    listaNotas.Add(notas);
                }
                else
                {
                    //notas.Add(new Notes(title, desc));
                    Notes notas = new Notes(title, desc);
                    NotesList.Rows.Add(notas.Title, notas.Description, "-----------");
                    listaNotas.Add(notas);
                }
            }
            else
            {
                MessageBox.Show("Please Insert some Data!");
            }
            ClearAllContents();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                dateTimePicker1.Enabled = false;
            }
            else
            {
                dateTimePicker1.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            NotesList.Columns.Add("Title");
            NotesList.Columns.Add("Description");
            NotesList.Columns.Add("Date");
            NoteList.DataSource = NotesList;

            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.HeaderText = "X";
                button.Width = 2;
                button.FlatStyle = FlatStyle.System;
                button.Text = "X";
                button.UseColumnTextForButtonValue = true; //dont forget this line
                this.NoteList.Columns.Add(button);
            }
            NoteList.Columns[3].Width = 30;
        }   


        private void NoteList_CellContentClick(object sender, DataGridViewCellEventArgs button)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[button.ColumnIndex] is DataGridViewButtonColumn &&
                button.RowIndex >= 0)
            {
                int index = button.RowIndex;
                try
                {
                    NotesList.Rows.RemoveAt(index);
                }
                catch
                {
                }

            }

        }

        public void ClearAllContents()
        {
            textBox1.Text = "";
            richTextBox1.Text = "";
        }
    }
}
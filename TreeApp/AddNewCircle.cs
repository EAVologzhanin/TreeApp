using System;
using System.Windows.Forms;

namespace TreeApp
{
    public partial class AddNewCircle : Form
    {
        public string info;
        public double chance;
        public double price;
        public event EventHandler AddEvent;
        public event EventHandler AddSquare;
        public event EventHandler AddTriangle;
        public event Action closed;
        public event EventHandler ChangeEvent;

        public AddNewCircle()
        {
            InitializeComponent();
            if (Form1.selectedFigure is Square)
            {
                richTextBox1.Text = "1";
                richTextBox1.Enabled = false;
            }
            else
                richTextBox1.Text = "0,";
        }


        private void AddNewCircle_FormClosing(object sender, FormClosingEventArgs e)
        {
            closed?.Invoke();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                price = double.Parse(richTextBox3.Text);
                info = richTextBox2.Text;
                chance = double.Parse(richTextBox1.Text);
                AddEvent?.Invoke(this, null);
                ChangeEvent?.Invoke(this, null);
                AddSquare?.Invoke(this, null);
                AddTriangle?.Invoke(this, null);
                Close();
            }
            catch
            {
                MessageBox.Show("Введите корректные данные");
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox1.Text == "0,") richTextBox1.SelectionStart = richTextBox1.Text.Length;
                if (richTextBox1.SelectionStart < 3) { richTextBox1.Text = "0,"; richTextBox1.SelectionStart = 3; }
                string s = richTextBox1.Text.Substring(2);
                richTextBox1.Text = "0," + s;
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
            }
            catch
            {
                richTextBox1.Text = "0,";
                richTextBox1.SelectionStart = richTextBox1.Text.Length;

            }
        }
    }
}

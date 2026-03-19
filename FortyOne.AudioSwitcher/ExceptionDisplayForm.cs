using System;
using System.Windows.Forms;

namespace FortyOne.AudioSwitcher
{
    public sealed partial class ExceptionDisplayForm : Form
    {
        private readonly Exception exception;

        public ExceptionDisplayForm()
        {
            InitializeComponent();
        }

        public ExceptionDisplayForm(string title, Exception ex)
        {
            InitializeComponent();

            exception = ex;
            Text = title;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ExceptionDisplayForm_Load(object sender, EventArgs e)
        {
            if (exception != null)
                txtError.Text = exception.ToString();
        }
    }
}
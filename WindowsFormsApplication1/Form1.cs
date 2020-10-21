using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmTool : Form
    {
        public frmTool()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogResult resultado = openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "Archivos de texto (*.txt)|*.txt";

            try
            {
                if (resultado == DialogResult.OK)
                {
                    this.txtPathOpen.Text = openFileDialog1.FileName;
                }                
            }
            catch(IOException exception)
            {
                MessageBox.Show("An error ocurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (this.txtPathOpen.Text.Length > 0)
            {
                using (StreamReader reader = new StreamReader(this.txtPathOpen.Text, false))
                {
                    this.txtText.Text = reader.ReadToEnd();
                }
            }
            else
            {
                MessageBox.Show("Please select a valid txt file", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DialogResult result =  folderBrowserDialog1.ShowDialog();

            if(result == DialogResult.OK)
            {
                this.txtPathSelect.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            if (this.txtPathSelect.Text.Length > 0 && this.txtName.Text.Length > 0)
            {
                try
                {
                    string path = string.Format("{0}/{1}.txt", this.txtPathSelect.Text, this.txtName.Text);
                    using (StreamWriter writer = new StreamWriter(path, false))
                    {
                        writer.Write(this.txtText.Text);
                    }
                    MessageBox.Show("The file was succesfully saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(IOException exception)
                {
                    MessageBox.Show("An error ocurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please indicate a valid folder and filename", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmTool_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Developed by Gerson Azabache \r\n https://github.com/GeaSmart \r\n Would you like to visit my GitHub?", "About this", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("https://github.com/GeaSmart");
            }
        }
    }
}

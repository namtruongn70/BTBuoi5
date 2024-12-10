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

namespace Lad03_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (FontFamily font in FontFamily.Families)
            {
                cmbChu.Items.Add(font.Name);
            }
            cmbChu.SelectedItem = "Tahoma"; // Mặc định là Tahoma
            cmbSize.Items.AddRange(new object[] { 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 });
            cmbSize.SelectedItem = 14; // Mặc định là 14
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void tạoVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            cmbChu.SelectedItem = "Tahoma";
            cmbSize.SelectedItem = 14;
        }

        private void mởTệpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Rich Text Format (*.rtf)|*.rtf|Text Files (*.txt)|*.txt",
                Title = "Mở tệp tin"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(openFileDialog.FileName).ToLower() == ".rtf")
                    richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);
                else
                    richTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Rich Text Format (*.rtf)|*.rtf|Text Files (*.txt)|*.txt",
                Title = "Lưu tệp tin"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(saveFileDialog.FileName).ToLower() == ".rtf")
                    richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                else
                    File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text);
            }
        }

        private void cmbChu_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog
            {
                ShowColor = true,
                Font = richTextBox1.SelectionFont,
                Color = richTextBox1.SelectionColor
            };

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog.Font;
                richTextBox1.SelectionColor = fontDialog.Color;

                FontDialog fontDlg = new FontDialog();
                fontDlg.ShowColor = true;
                fontDlg.ShowApply = true;
                fontDlg.ShowEffects = true;
                fontDlg.ShowHelp = true;
                if (fontDlg.ShowDialog() != DialogResult.Cancel)
                {
                    cmbChu.ForeColor = fontDlg.Color;
                    cmbChu.Font = fontDlg.Font;
                }
            }
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cmbSize_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                float selectedSize = float.Parse(cmbSize.SelectedItem.ToString());
                string currentFont = richTextBox1.SelectionFont.Name;
                richTextBox1.SelectionFont = new Font(currentFont, selectedSize);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle style = richTextBox1.SelectionFont.Style;
                style = richTextBox1.SelectionFont.Bold ? style & ~FontStyle.Bold : style | FontStyle.Bold;
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle style = richTextBox1.SelectionFont.Style;
                style = richTextBox1.SelectionFont.Italic ? style & ~FontStyle.Italic : style | FontStyle.Italic;
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle style = richTextBox1.SelectionFont.Style;
                style = richTextBox1.SelectionFont.Underline ? style & ~FontStyle.Underline : style | FontStyle.Underline;
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}

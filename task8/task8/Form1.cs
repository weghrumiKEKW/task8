namespace task8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Text Files (.txt)|.txt|All files (.)|.";
            sv.FileName = "Document";

            if (sv.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sv.FileName, richTextBox1.Text);
                MessageBox.Show("Fayl uğurla yaradıldı və yadda saxlanıldı.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Text Files (.txt)|.txt|All files (.)|.";

            if (op.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(op.FileName))
                {
                    File.AppendAllText(op.FileName, richTextBox1.Text);
                    MessageBox.Show("Mətn fayla əlavə edildi.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "All files (.)|.|Text Files (.txt)|.txt";

            if (op.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(op.FileName) || !File.Exists(op.FileName))
                {
                    MessageBox.Show("Fayl adı yoxdur və ya fayl mövcud deyil", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    DialogResult d = MessageBox.Show("Fayl silinsinmi?", "Sual", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        File.Delete(op.FileName);
                        richTextBox1.Text = "Fayl silindi";
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Text Files (.txt)|.txt|All files (.)|.";

            if (op.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(op.FileName))
                {
                    richTextBox1.Text = File.ReadAllText(op.FileName);
                }
                else
                {
                    MessageBox.Show("Seçilən fayl tapılmadı.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
    }
}
    


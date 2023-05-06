using System;

namespace summer_practic1
{

    public partial class Form1 : Form
    {
        /*
         * Ввести класс матриц третьего порядка,
         * содержащий как поля - элементы,
         * как методы - действия над
         * матрицами. Вычислить|AB|/|BC|
         */

        List<Matrix> matrix_mas = new List<Matrix>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 3;
            dataGridView1.ColumnCount = 3;

            dataGridView2.RowCount = 3;
            dataGridView2.ColumnCount = 3;

            dataGridView3.RowCount = 3;
            dataGridView3.ColumnCount = 3;

            dataGridView4.RowCount = 3;
            dataGridView4.ColumnCount = 3;

            dataGridView5.RowCount = 3;
            dataGridView5.ColumnCount = 3;

            label2.Text = $"Кол-во матриц: {matrix_mas.Count}";
        }

        private void button1_Click(object sender, EventArgs e) // btn "Создать матрицу"
        {
            Matrix buf = new Matrix(dataGridView1);
            matrix_mas.Add(buf);
            domainUpDown1.Items.Add(matrix_mas.Count);
            domainUpDown2.Items.Add(matrix_mas.Count);
            domainUpDown3.Items.Add(matrix_mas.Count);
            if (domainUpDown1.Items.Count == 1)
            {
                domainUpDown1.SelectedItem = 1;
                domainUpDown2.SelectedItem = 1;
                domainUpDown3.SelectedItem = 1;
            }

            label2.Text = $"Кол-во матриц: {matrix_mas.Count}";
            numericUpDown1.Maximum = matrix_mas.Count;
            numericUpDown2.Maximum = matrix_mas.Count;
            numericUpDown3.Maximum = matrix_mas.Count;


            panel3.Visible = true;
            checkBox2.Visible = true;
            radioButton1.Visible = true;
            radioButton3.Visible = true;
            domainUpDown2.Visible = true;
            domainUpDown3.Visible = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            domainUpDown1_SelectedItemChanged(sender, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button4.Visible = true;
            dataGridView5.Visible = false;
            textBox1.Text = "";
            switch (comboBox1.SelectedItem)
            {
                case "Сложить":
                    label4.Text = "+";
                    label4.Visible = true;
                    panel1.Visible = true;
                    panel2.Visible = true;
                    button4.Location = new Point(626, 255);
                    dataGridView5.Location = new Point(675, 230);
                    break;
                case "Вычесть":
                    label4.Text = "–";
                    label4.Visible = true;
                    panel1.Visible = true;
                    panel2.Visible = true;
                    textBox1.Visible = false;
                    button4.Location = new Point(626, 255);
                    dataGridView5.Location = new Point(675, 230);
                    break;
                case "Умножить на матрицу":
                    label4.Text = "*";
                    label4.Visible = true;
                    panel1.Visible = true;
                    panel2.Visible = true;
                    textBox1.Visible = false;
                    button4.Location = new Point(626, 255);
                    dataGridView5.Location = new Point(675, 230);
                    break;
                case "Умножить на скаляр":
                    label4.Text = "*";
                    label4.Visible = true;
                    panel1.Visible = true;
                    panel2.Visible = false;
                    textBox1.Visible = true;
                    button4.Location = new Point(396, 255);
                    dataGridView5.Location = new Point(445, 230);
                    break;
                case "Транспонировать":
                    label4.Visible = false;
                    panel1.Visible = true;
                    panel2.Visible = false;
                    textBox1.Visible = false;
                    button4.Location = new Point(304, 255);
                    dataGridView5.Location = new Point(353, 230);
                    break;
                case "Вычислить определитель":
                    label4.Visible = false;
                    panel1.Visible = true;
                    panel2.Visible = false;
                    textBox1.Visible = true;
                    textBox1.Location = new Point(353, 262);
                    button4.Location = new Point(304, 255);
                    dataGridView5.Location = new Point(353, 230);
                    break;
            }
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                matrix_mas[domainUpDown1.SelectedIndex].CopyMatr(dataGridView2);
                panel4.Visible = true;
            }

            else
            {
                panel4.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.RowCount = 3;
            dataGridView1.ColumnCount = 3;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            domainUpDown2_SelectedItemChanged(sender, e);
        }

        private void domainUpDown2_SelectedItemChanged(object sender, EventArgs e)
        {
            /*if (radioButton2.Checked)
            {
                dataGridView3.Rows.Clear();
                dataGridView3.RowCount = 3;
                dataGridView3.ColumnCount = 3;
            }*/
            if (radioButton1.Checked)
            {
                matrix_mas[domainUpDown2.SelectedIndex].CopyMatr(dataGridView3);
            }
        }

        private void button3_Click(object sender, EventArgs e) // btn "Удалить"
        {
            if (matrix_mas.Count > 1)
            {
                matrix_mas.Remove(matrix_mas[domainUpDown1.SelectedIndex]);
                if (Convert.ToInt32(domainUpDown1.SelectedItem) == matrix_mas.Count + 1) domainUpDown1.UpButton();
                else domainUpDown1_SelectedItemChanged(sender, e);
                if (Convert.ToInt32(domainUpDown2.SelectedItem) == matrix_mas.Count + 1) domainUpDown2.UpButton();
                else domainUpDown2_SelectedItemChanged(sender, e);
                if (Convert.ToInt32(domainUpDown3.SelectedItem) == matrix_mas.Count + 1) domainUpDown3.UpButton();
                else domainUpDown3_SelectedItemChanged(sender, e);

                domainUpDown1.Items.Remove(matrix_mas.Count + 1);
                domainUpDown2.Items.Remove(matrix_mas.Count + 1);
                domainUpDown3.Items.Remove(matrix_mas.Count + 1);
                label2.Text = $"Кол-во матриц: {matrix_mas.Count}";
            }
            else
            {
                matrix_mas.Remove(matrix_mas[domainUpDown1.SelectedIndex]);
                domainUpDown1.Items.Remove(matrix_mas.Count + 1);
                domainUpDown2.Items.Remove(matrix_mas.Count + 1);
                domainUpDown3.Items.Remove(matrix_mas.Count + 1);

                label2.Text = $"Кол-во матриц: {matrix_mas.Count}";
                panel3.Visible = false;
                panel4.Visible = false;
                radioButton1.Visible = false;
                radioButton3.Visible = false;
                radioButton2.Checked = true;
                radioButton4.Checked = true;
                domainUpDown2.Visible = false;
                domainUpDown3.Visible = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox2.Visible = false;
            }
            numericUpDown1.Maximum = matrix_mas.Count;
            numericUpDown2.Maximum = matrix_mas.Count;
            numericUpDown3.Maximum = matrix_mas.Count;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            domainUpDown3_SelectedItemChanged(sender, e);
        }

        private void domainUpDown3_SelectedItemChanged(object sender, EventArgs e)
        {
            /*if (radioButton4.Checked)
            {
                dataGridView4.Rows.Clear();
                dataGridView4.RowCount = 3;
                dataGridView4.ColumnCount = 3;
            }*/
            if (radioButton3.Checked)
            {
                matrix_mas[domainUpDown3.SelectedIndex].CopyMatr(dataGridView4);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView5.Visible = true;

            Matrix matr1;
            if (radioButton2.Checked)
            {
                matr1 = new Matrix(dataGridView3);
            }
            else
            {
                matr1 = matrix_mas[domainUpDown2.SelectedIndex];
            }

            if (comboBox1.SelectedIndex < 3)
            {
                Matrix matr2;
                if (radioButton4.Checked)
                {
                    matr2 = new Matrix(dataGridView4);
                }
                else
                {
                    matr2 = matrix_mas[domainUpDown3.SelectedIndex];
                }

                if (comboBox1.SelectedIndex == 0)
                {
                    (matr1 + matr2).CopyMatr(dataGridView5);
                }

                if (comboBox1.SelectedIndex == 1)
                {
                    (matr1 - matr2).CopyMatr(dataGridView5);
                }

                if (comboBox1.SelectedIndex == 2)
                {
                    (matr2 * matr1).CopyMatr(dataGridView5);
                }
            }

            if (comboBox1.SelectedIndex == 3)
            {
                (matr1 * Convert.ToDouble(textBox1.Text)).CopyMatr(dataGridView5);
            }

            if (comboBox1.SelectedIndex == 4)
            {
                (matr1.T()).CopyMatr(dataGridView5);
            }

            if (comboBox1.SelectedIndex == 5)
            {
                dataGridView5.Visible = false;

                textBox1.Text = matr1.det().ToString();
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            radioButton2.Checked = true;
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            radioButton4.Checked = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) panel5.Visible = true;
            else panel5.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double res;
            double aDet = matrix_mas[Convert.ToInt32(numericUpDown1.Value) - 1].det();
            double bDet = matrix_mas[Convert.ToInt32(numericUpDown2.Value) - 1].det();
            double cDet = matrix_mas[Convert.ToInt32(numericUpDown3.Value) - 1].det();

            label7.Text = ((aDet * bDet) / (bDet * cDet)).ToString();
            label7.Visible = true;
        }
    }
}
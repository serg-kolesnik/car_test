using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace car_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Car newCar = new Car();
            listBox1.Items.Add(newCar);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Car selectedCar = (Car)listBox1.SelectedItem;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox1.Text = selectedCar.Id.ToString();
                textBox2.Text = selectedCar.Mark;
                textBox3.Text = selectedCar.Color;
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Сначала выберите машину!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Car selectedCar = (Car)listBox1.SelectedItem;
            MessageBox.Show($"Цена машины: {Car.checkPrice(selectedCar)} руб.", "Стоимость");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Сначала выберите машину!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Car selectedCar = (Car)listBox1.SelectedItem;
            if (Car.testDrive(selectedCar))
            {
                MessageBox.Show("Тест-драйв прошёл успешно!", "Проверка двигателя", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Тест-драйв не удался!", "Проверка двигателя", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Сначала выберите машину!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBox1.Text, out int newId))
            {
                MessageBox.Show("Номер машины должен быть числом!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newMark = textBox2.Text.Trim();
            if (string.IsNullOrEmpty(newMark))
            {
                MessageBox.Show("Укажите марку машины!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newColor = textBox3.Text.Trim();
            if (string.IsNullOrEmpty(newColor))
            {
                MessageBox.Show("Укажите цвет машины!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Car newCar = new Car(newId, newMark, newColor);
                listBox1.Items[listBox1.SelectedIndex] = newCar;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

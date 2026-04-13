using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Car selectedCar = (Car)listBox1.SelectedItem;
            if (listBox1.SelectedIndex != -1)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox1.Text = (selectedCar).Id.ToString();
                textBox2.Text = (selectedCar).Mark;
                textBox3.Text = (selectedCar).Color;
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Car selectedCar = (Car)listBox1.SelectedItem;
            MessageBox.Show($"Цена машины: {Car.checkPrice(selectedCar)}.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Car selectedCar = (Car)listBox1.SelectedItem;
            if (Car.testDrive(selectedCar) == true)
            {
                MessageBox.Show("Тест-драйв прошёл успешно!");
            }
            else
            {
                MessageBox.Show("Тест-драйв не удался!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int newId = Convert.ToInt32(textBox1.Text);
            string newMark = textBox2.Text;
            string newColor = textBox3.Text;
            Car newCar = new Car(newId, newMark, newColor);
            listBox1.Items[listBox1.SelectedIndex] = newCar;
        }
    }
}

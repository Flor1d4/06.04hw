using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _06._04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();          
            label1.Visible = false;
            radioButton17.ForeColor = radioButton1.BackColor;
            radioButton18.ForeColor = radioButton2.BackColor;
            radioButton19.ForeColor = radioButton2.BackColor;
            radioButton20.ForeColor = radioButton2.BackColor;
            progressBar1.Value = 0;            
            foreach (RadioButton radioButton in this.Controls.OfType<RadioButton>())
            {
                radioButton.Enabled = false;
                radioButton.TabStop = false;
            }
            radioButton33.Select();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            radioButton17.ForeColor = Color.Black;
            radioButton18.ForeColor = Color.Black;
            radioButton19.ForeColor = Color.Black;
            radioButton20.ForeColor = Color.Black;

            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.BackColor = Color.AliceBlue;
            label2.ForeColor = Color.FromArgb(255, 0, 0);

            label2.Text = "00:05";
            timer1.Tick -= timer1_Tick;
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int minutes = int.Parse(label2.Text.Substring(0, 2));
            int seconds = int.Parse(label2.Text.Substring(3, 2));

            int remainingTime = minutes * 60 + seconds;
            remainingTime--;
            label2.Text = string.Format("{0:00}:{1:00}", remainingTime / 60, remainingTime % 60);

            if (remainingTime == 0)
            {
                timer1.Stop();
                radioButton17.Enabled = false;
                radioButton18.Enabled = false;
                radioButton19.Enabled = false;
                radioButton20.Enabled = false;
                button1.Enabled = false;
                MessageBox.Show("Время вышло :(", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if ((radioButton1.Checked && radioButton == radioButton1) || (radioButton6.Checked && radioButton == radioButton6) || (radioButton12.Checked && radioButton == radioButton12) 
                || (radioButton31.Checked && radioButton == radioButton31) || (radioButton25.Checked && radioButton == radioButton25) || (radioButton23.Checked && radioButton == radioButton3) || (radioButton15.Checked && radioButton == radioButton15))
                progressBar1.Value += 10;

            if (radioButton != null && radioButton.Checked)
            {
                int tagValue = Convert.ToInt32(radioButton.Tag);

                if (tagValue == 1)
                {
                    groupBox1.Enabled = false;
                    return;
                }
                else if (tagValue == 2)
                {
                    groupBox2.Enabled = false;
                    return;
                }
                else if (tagValue == 3)
                {
                    groupBox3.Enabled = false;
                    return;
                }
                else if (tagValue == 5)
                {
                    groupBox8.Enabled = false;
                    return;
                }
                else if (tagValue == 6)
                {
                    groupBox7.Enabled = false;
                    return;
                }
                else if (tagValue == 7)
                {
                    groupBox6.Enabled = false;
                    return;
                }
                else if (tagValue == 9)
                {
                    groupBox9.Enabled = false;
                    return;
                }
                else if (tagValue == 10)
                {
                    groupBox10.Enabled = false;
                    return;
                }
                radioButton33.Select();
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            checkBox.Enabled = false;

            if ((checkBox1.Checked && checkBox2.Checked && !checkBox3.Checked && !checkBox4.Checked))
                progressBar1.Value += 10;
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            checkBox.Enabled = false;
            if (progressBar1.Value != 0)
                progressBar1.Value -= 10;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            checkBox.Enabled = false;

            if ((checkBox8.Checked && !checkBox5.Checked && !checkBox6.Checked && !checkBox7.Checked))
                progressBar1.Value += 10;
        }
    }
}

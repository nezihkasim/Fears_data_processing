using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Midterm_Q3
{
    public partial class Form1 : Form
    {
        List<Person_Information> informationList = new List<Person_Information>();
        string title_line;
        string selection;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = true;
            comboBox1.Enabled = false;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            readCSV("FearStudyData.csv");
            comboBox1.Items.Add("All");

            List<string> fears_List = new List<string>();
            foreach (var information in informationList)
            {
                fears_List.Add(information.Fear);
            }
            List<string> distinct_fears_List = new List<string>();
            distinct_fears_List = fears_List.Distinct().ToList();
            foreach (var fear in distinct_fears_List)
            {
                comboBox1.Items.Add(fear);
            }

            button1.Enabled = false;
            comboBox1.Enabled = true;
            button2.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selection = comboBox1.SelectedItem.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double num_Yes_Overcome = 0;
            double num_element = 0;

            DataTable dt = new DataTable();
            var fields_of_title = title_line.Split(',');
            foreach (var field in fields_of_title)
            {
                dt.Columns.Add(field, typeof(string));
            }

            if (selection == "All")
            {
                foreach (var information in informationList)
                {
                    
                    string Greatest = information.Greatest;
                    string Overcome = information.Overcome;
                    if (Greatest == "")
                    {
                        Greatest = "Not Defined";
                    }
                    if (Overcome == "")
                    {
                        Overcome = "No";
                    }
                    string[] fields = new string[7] { information.Fear, Greatest, information.Impact, information.Past, information.Encounter, Overcome, information.Embarrased };
                    dt.Rows.Add(fields);
                }
            }
            else
            {
                foreach (var information in informationList)
                {
                    if (information.Fear == selection)
                    {
                        num_element++;

                        string Greatest = information.Greatest;
                        string Overcome = information.Overcome;
                        if (Greatest == "")
                        {
                            Greatest = "Not Defined";
                        }

                        if (Overcome == "")
                        {
                            Overcome = "No";
                        }
                        else if (Overcome == "Yes")
                        {
                            num_Yes_Overcome++;
                        }
                        string[] fields = new string[7] { information.Fear, Greatest, information.Impact, information.Past, information.Encounter, Overcome, information.Embarrased };
                        dt.Rows.Add(fields);
                    }
                }
            }
            dataGridView1.DataSource = dt;

            if (selection != "All")
	        {
                label3.Text = "Success of Fear of " + selection + ": ";
                double percentage = (num_Yes_Overcome / num_element)*100;
                label4.Text = "%" + percentage.ToString();
	        }
        }

        public void readCSV(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            {
                Person_Information new_information;
                title_line = sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');
                    new_information = new Person_Information(columns[0], columns[1], columns[2], columns[3], columns[4], columns[5], columns[6]);
                    informationList.Add(new_information);
                }
            }
        }
    }
}

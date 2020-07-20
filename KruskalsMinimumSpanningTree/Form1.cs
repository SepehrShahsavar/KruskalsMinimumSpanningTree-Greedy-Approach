using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KruskalsMinimumSpanningTree
{
    public partial class Form1 : Form
    {
        List<Edge> edges = new List<Edge>();
        List<Vertix> vertices = new List<Vertix>();
        int v = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Int32.Parse(textBox1.Text);
                int y = Int32.Parse(textBox2.Text);
                Point p = new Point(x, y);
                if (!Vertix.isDuplicated(vertices, p))
                {
                    vertices.Add(new Vertix(p, v));
                    v++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("INVALID INPUTS!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                textBox2.Text = "";
                return;
            }

            try
            {
                int src = Int32.Parse(textBox3.Text);
                int dest = Int32.Parse(textBox4.Text);
                int weight = Int32.Parse(textBox5.Text);
                if (!src.Equals("") && !dest.Equals("") && !weight.Equals(""))
                {
                    if (!edges.Contains(new Edge(src, dest, weight)) && !edges.Contains(new Edge(dest, src, weight)))
                    {
                        edges.Add(new Edge(src, dest, weight));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("INVALID INPUTS!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                return;
            }


            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";


        }

        private void button2_Click(object sender, EventArgs e)
        {
            vertices.Clear();
            edges.Clear();
            v = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(vertices.Count == 0)
            {
                MessageBox.Show("Please enter vertices!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Form2 form2 = new Form2(500, 500, vertices, edges , v);
            form2.Show();
        }
    }
}

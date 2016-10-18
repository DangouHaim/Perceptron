using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMGScan
{
    public partial class Form1 : Form
    {
        Neuron[] n;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            n = new Neuron[]
            {
                new Neuron(50, 50, "А"),
                new Neuron(50, 50, "Б"),
                new Neuron(50, 50, "В"),
                new Neuron(50, 50, "Г"),
                new Neuron(50, 50, "Д"),
                new Neuron(50, 50, "Е"),
                new Neuron(50, 50, "Ё"),
                new Neuron(50, 50, "Ж"),
                new Neuron(50, 50, "З"),
                new Neuron(50, 50, "И"),
                new Neuron(50, 50, "Й"),
                new Neuron(50, 50, "К"),
                new Neuron(50, 50, "Л"),
                new Neuron(50, 50, "М"),
                new Neuron(50, 50, "Н"),
                new Neuron(50, 50, "О"),
                new Neuron(50, 50, "П"),
                new Neuron(50, 50, "Р"),
                new Neuron(50, 50, "С"),
                new Neuron(50, 50, "Т"),
                new Neuron(50, 50, "У"),
                new Neuron(50, 50, "Ф"),
                new Neuron(50, 50, "Х"),
                new Neuron(50, 50, "Ц"),
                new Neuron(50, 50, "Ч"),
                new Neuron(50, 50, "Ш"),
                new Neuron(50, 50, "Щ"),
                new Neuron(50, 50, "Ь"),
                new Neuron(50, 50, "Ы"),
                new Neuron(50, 50, "Ъ"),
                new Neuron(50, 50, "Э"),
                new Neuron(50, 50, "Ю"),
                new Neuron(50, 50, "Я")
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < n.Length; i++)
            {
                n[i].Study();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog o = new OpenFileDialog())
            {
                if(o.ShowDialog() == DialogResult.OK)
                {
                    for(int i = 0; i < n.Length; i++)
                    {
                        n[i].LoadFromFile(o.FileName);
                        if (n[i].Outer() > 0)
                        {
                            MessageBox.Show(n[i].Name);
                        }
                    }
                }
            }
        }
    }
}


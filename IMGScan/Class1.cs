using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMGScan
{
    public class Neuron
    {
        public string Name
        {
            get { return _name; }
        }
        private string _name;
        double[][] _in;
        double[][] _w;
        double _out;

        double _max = 1500;
        double _learnSpeed = 0.1;
        double _min = 0;


        public Neuron(int w, int h, string name)
        {
            _name = name;
            _in = new double[w][];
            _w = new double[w][];
            for (int i = 0; i < w; i++)
            {
                _in[i] = new double[h];
                _w[i] = new double[h];
            }

            Init();

        }

        public void Init()
        {
            Random r = new Random();
            for (int i = 0; i < _w.Length; i++)
            {
                for (int j = 0; j < _w[i].Length; j++)
                {
                    _w[i][j] = r.Next(2) * 0.3 + 0.1;
                }
            }
        }

        public double Outer()
        {
            _out = 0;

            for (int i = 0; i < _in.Length; i++)
            {
                for (int j = 0; j < _in[i].Length; j++)
                {
                    if (_in[i][j] < 200)
                    {
                        _out += _w[i][j] * _in[i][j];
                    }
                }
            }

            if (_out > _max)
            {
                _out = 1;
            }
            else
            {
                _out = 0;
            }
            return _out;
        }

        public void Study()
        {
            double ge = 0;
            do
            {
                ge = 0;
                foreach (var v in Directory.GetFiles("Patterns/" + _name))
                {
                    int answer = 0;
                    if (v.IndexOf("true") > -1)
                    {
                        answer = 1;
                    }

                    Bitmap b = (Bitmap)Bitmap.FromFile(v);
                    for (int i = 0; i < b.Width; i++)
                    {
                        for (int j = 0; j < b.Height; j++)
                        {
                            _in[i][j] = (b.GetPixel(i, j).R + b.GetPixel(i, j).G + b.GetPixel(i, j).B) / 3;
                        }
                    }
                    Outer();
                    double le = answer - _out;
                    ge += Math.Abs(le);

                    for (int i = 0; i < b.Width; i++)
                    {
                        for (int j = 0; j < b.Height; j++)
                        {
                            if (_in[i][j] < 200)
                            {
                                _w[i][j] += _learnSpeed * _in[i][j] * le;
                            }
                        }
                    }
                }
            }
            while (ge > _min);
        }

        public void LoadFromFile(string v)
        {
            Bitmap b = (Bitmap)Bitmap.FromFile(v);
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    _in[i][j] = (b.GetPixel(i, j).R + b.GetPixel(i, j).G + b.GetPixel(i, j).B) / 3;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raamatukogu
{
    internal class SuurimaViiviseLeidja : Kontrollija
    {
        private string laenutaja;
        private string teoseKirjeldus;
        private double suurimViivis;
        public SuurimaViiviseLeidja()
        {
            this.suurimViivis = 0;
        }
        public void salvestaViivis(string laenutajaNimi, string teoseKirjeldus, double viiviseSuurus)
        {
            if (viiviseSuurus > suurimViivis)
            {
                this.laenutaja = laenutajaNimi;
                this.teoseKirjeldus = teoseKirjeldus;
                this.suurimViivis = viiviseSuurus;
            }
        }

        public void saadaHoiatus()
        {
            int rowsInFile = File.ReadAllLines(@"..\..\..\data.txt").Count();//считает кол-во строк
            var fromfile = File.ReadAllLines(@"..\..\..\data.txt");
            List<string> nimi = new List<string>();
            List<string> raamat = new List<string>();
            List<int> viise = new List<int>();

            for (int i = 0; i < rowsInFile; i++)
            {
                string[] spliter = fromfile[i].Split("; ");
                nimi.Add(spliter[2]);
                raamat.Add(spliter[0]);
                viise.Add(Convert.ToInt32(spliter[3]));
            }
            int maxValue = viise.Max();
            int maxIndex = viise.IndexOf(maxValue);
            Console.WriteLine("Nimi >>> " + nimi[maxIndex]+ ", raamat >>> " + raamat[maxIndex] + ", viise >>> " + maxValue);

        }
    }
}

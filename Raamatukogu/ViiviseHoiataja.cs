using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Raamatukogu
{
    internal class ViiviseHoiataja : Kontrollija
    {
        double luubatudViise;
        string varv;

        public void salvestaViivis(string laenutajaNimi, string teoseKirjeldus, double viiviseSuurus)
        {
            int rowsInFile = File.ReadAllLines(@"..\..\..\data.txt").Count();//считает кол-во строк
            var fromfile = File.ReadAllLines(@"..\..\..\data.txt");
            List <string> nimed = new List<string>();

            if (luubatudViise==14)
            {
                varv = "puudub";
            }
            else if (luubatudViise == 1)
            {
                varv = "roheline";
            }
            else if (luubatudViise == 30)
            {
                varv = "kollane";
            }
            else if (luubatudViise == 30)
            {
                varv = "sinine";
            }

            for (int i = 0; i < rowsInFile; i++)
            {
                string[] spliter = fromfile[i].Split("; ");
                nimed.Add(spliter[2]);
                //Console.WriteLine("proizvedenije > " + spliter[0]+ " cvet > " + spliter[1] + " Imja Dolznika > " + spliter[2]+ " viiviseSuurus >>> " + spliter[3] );
            }

            double helper;
            helper = viiviseSuurus - luubatudViise;
            if (!nimed.Contains(laenutajaNimi) && helper > 0)
            {
                StreamWriter to_file = new StreamWriter(@"..\..\..\data.txt", true);
                to_file.Write("\n" + teoseKirjeldus + "; " + varv + "; " + laenutajaNimi + "; " + helper);
                to_file.Close();
            }
            
            Console.WriteLine();
        }
        public ViiviseHoiataja(double luubatudViise)
        {
            this.luubatudViise = luubatudViise;
        }

        public List<string> getHoiatatavadLaenutajad()
        {
            List<string> laenutajad = new List<string>();
            int rowsInFile = File.ReadAllLines(@"..\..\..\data.txt").Count();//считает кол-во строк
            var fromfile = File.ReadAllLines(@"..\..\..\data.txt");
            for (int i = 0; i < rowsInFile; i++)
            {
                string[] spliter = fromfile[i].Split("; ");
                int helper = Convert.ToInt32(spliter[3]);
                if (!laenutajad.Contains(spliter[2]) && spliter[1] == "roheline" && helper >= 1)
                {
                    laenutajad.Add(spliter[2]);
                }
                else if (!laenutajad.Contains(spliter[2]) &&  spliter[1] == "puudub" && helper >= 14)
                {
                    laenutajad.Add(spliter[2]);
                }
                else if (!laenutajad.Contains(spliter[2]) && spliter[1] == "kollane" && helper >= 30)
                {
                    laenutajad.Add(spliter[2]);
                }
                else if (!laenutajad.Contains(spliter[2]) && spliter[1] == "sinine" && helper >= 60)
                {
                    laenutajad.Add(spliter[2]);
                }
            }
            //foreach (var item in laenutajad)
            //{
            //    Console.WriteLine(item);
            //}
            return laenutajad;

        }




    }
}

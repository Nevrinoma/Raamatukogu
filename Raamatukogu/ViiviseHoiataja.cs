using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raamatukogu
{
    internal class ViiviseHoiataja : Kontrollija
    {
        public void salvestaViivis(string laenutajaNimi, string teoseKirjeldus, double viiviseSuurus)
        {
            int rowsInFile = File.ReadAllLines(@"..\..\..\data.txt").Count();//считает кол-во строк
            var fromfile = File.ReadAllLines(@"..\..\..\data.txt");
            List <string> dolzniki = new List<string>();
            for (int i = 0; i < rowsInFile; i++)
            {
                string[] spliter = fromfile[i].Split("; ");
                dolzniki.Add(spliter[2]);
                //Console.WriteLine("proizvedenije > " + spliter[0]+ " cvet > " + spliter[1] + " Imja Dolznika > " + spliter[2]+ " viiviseSuurus >>> " + spliter[3] );
            }
            foreach (var item in dolzniki)
            {
                if (item != laenutajaNimi)
                {
                    StreamWriter to_file = new StreamWriter(@"..\..\..\data.txt",true);
                    to_file.WriteLine(teoseKirjeldus+"; "+laenutajaNimi+"; "+viiviseSuurus);
                    to_file.Close();
                    
                }
                
            }
            Console.WriteLine();
        }
        

        private double LuubatudViise(double luubatudViise)
        {
            return luubatudViise;
        }

        
        

    }
}

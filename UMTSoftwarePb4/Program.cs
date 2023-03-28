using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace UMTSoftwarePb4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int changes = 0;
            String s;
            Console.WriteLine($"Insert password: ");
            s=Console.ReadLine();
      
            if(s.Length>=6 && s.Length <= 20) {

                int nrLitereMici = 0;
                int nrLitereMari = 0;
                int nrCifre = 0;

                foreach (char c in s)
                {
                    if (char.IsDigit(c))
                        nrCifre++;
                    if (char.IsUpper(c))
                        nrLitereMari++;

                    if (char.IsLower(c))
                        nrLitereMici++;
                }

                int nrRepetari = RepeatingCharachter(s);
                if (nrLitereMari == 0 || nrLitereMici == 0 || nrCifre == 0)
                {
                    changes = 1;
                }
                if ((nrCifre == 0 && nrLitereMari == 0) || (nrCifre == 0 && nrLitereMici == 0) || (nrLitereMici == 0 && nrLitereMari == 0))
                    changes = 2;
                if (RepeatingCharachter(s) != 0)
                    changes += RepeatingCharachter(s);
            }
            else
            {
         if (s.Length == 1)
                changes = 5;
            if (s.Length == 2)
                changes = 4;
            if(s.Length==3)
                changes = 3; 
       
            

            if (ContainsDigit(s) && ContainsLowerCase(s) && ContainsUpperCase(s) && RepeatingCharachter(s) == 0 && s.Length < 6)
                changes += 6 - s.Length;
            if (ContainsDigit(s) && ContainsLowerCase(s) && ContainsUpperCase(s) && RepeatingCharachter(s) == 0 && s.Length > 20)
                changes +=  s.Length-20;

            if (Check0Change(s))
                changes = 0;
            if (Check1Change(s))
                changes = 1;
            if (Check2Change(s))
                changes = 2;
            }
           


            Console.WriteLine(changes);
            Console.Read();
        }

        public static bool Check0Change(string s) {
           if(ContainsDigit(s) && ContainsLowerCase(s) && ContainsUpperCase(s) && StringCheckLength(s) && RepeatingCharachter(s)==0 )
                return true;
            return false;
        }

        public static bool Check1Change(string s)
        {
            if (ContainsDigit(s) && ContainsLowerCase(s)==false && ContainsUpperCase(s) && StringCheckLength(s) && RepeatingCharachter(s) == 0)
                return true;//daca contine intre 6 si 20 de caractere dar nu are litera mica
            if (ContainsDigit(s)==false && ContainsLowerCase(s) && ContainsUpperCase(s) && StringCheckLength(s) && RepeatingCharachter(s) == 0)
                return true;//daca contine intre 6 si 20 de caractere dar nu are cifra
            if (ContainsDigit(s) && ContainsLowerCase(s) && ContainsUpperCase(s)==false && StringCheckLength(s) && RepeatingCharachter(s) == 0)
                return true;//daca contine intre 6 si 20 de caractere dar nu are litera mare
          
            
            if(RepeatingCharachter(s)==1)
              if(s.Length>=8 && s.Length<=18 && ContainsUpperCase(s) && ContainsLowerCase(s) && ContainsUpperCase(s) )
                    return true; //daca se repeta un sir o singura data


            if (ContainsDigit(s) && ContainsLowerCase(s) == false && ContainsUpperCase(s) && s.Length==5 && RepeatingCharachter(s) == 0)
                return true;//daca contine intre 6 si 20 de caractere dar nu are litera mica
            if (ContainsDigit(s) == false && ContainsLowerCase(s) && ContainsUpperCase(s) && s.Length == 5 && RepeatingCharachter(s) == 0)
                return true;//daca contine intre 6 si 20 de caractere dar nu are cifra
            if (ContainsDigit(s) && ContainsLowerCase(s) && ContainsUpperCase(s) == false && s.Length == 5 && RepeatingCharachter(s) == 0)
                return true;//daca contine intre 6 si 20 de caractere dar nu are litera mare


            return false;
        }
        public static bool Check2Change(string s)
        {
            if (RepeatingCharachter(s) == 2)
                if (s.Length >= 10 && s.Length <= 16 && ContainsUpperCase(s) && ContainsLowerCase(s) && ContainsUpperCase(s))
                    return true; //daca se repeta un sir de doua ori 
            if (StringCheckLength(s) && ContainsUpperCase(s) && ContainsLowerCase(s) == false && ContainsDigit(s) == false && RepeatingCharachter(s)==0)
                return true;

            if (StringCheckLength(s) && ContainsUpperCase(s) == false && ContainsLowerCase(s) && ContainsDigit(s) == false && RepeatingCharachter(s) == 0)
                return true;

            if (StringCheckLength(s) && ContainsUpperCase(s) == false && ContainsLowerCase(s)==false && ContainsDigit(s) && RepeatingCharachter(s) == 0)
                return true;

            if (s.Length == 4 && RepeatingCharachter(s) == 0)
                return true;

           

            return false;
        }

        public static bool StringCheckLength(string s)
        {
            if(s.Length>=6 && s.Length<=20) return true;
            return false;
        }
        public static bool ContainsDigit(string s)
        {
            foreach (char c in s)
            {
                if(char.IsDigit(c))
                    return true;
            }
            return false;
        }
        public static bool ContainsUpperCase(string s)
        {
            foreach (char c in s)
            {
                if (char.IsUpper(c))
                    return true;
            }
            return false;
        }
        public static bool ContainsLowerCase(string s)
        {
            foreach (char c in s)
            {
                if (char.IsLower(c))
                    return true;
            }
            return false;
        }

        public static int RepeatingCharachter(string s)
        {
            int rep = 0;
            int repchar = 0;
            for(int i=1;i<s.Length;i++)
            {
                if (s[i] == s[i - 1])
                {
                    rep++;
                    if(rep >=2)
                    {
                        repchar++;
                        rep = 0;
                    }
                }
                else
                {
                    rep = 0;
                }

            }

            return repchar;
        }

    }
}

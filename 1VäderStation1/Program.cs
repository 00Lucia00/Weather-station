using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1VäderStation1
{
    class Stad // klass med städer o dess temp som objekt
    {
        public string namn;// attrebut
        public int temp;

        //static void Main(string[] args)  Lärarens beskrivning
        // {
        // Console.WriteLine("Here is your information : ");
        // Console.WriteLine(toString("Lucia   ",123456));
        // }
        //public static string toString(string yourName, int yourMobi)
        // {
        //string yourContactInfo = yourName + yourMobi.ToString();
        //return yourContactInfo;
        // }

        public string toString()
        {
            string stadInfo = namn + " " + temp.ToString();
            return stadInfo;
        }

        public string GetNamn()// för att konna återkalla attrebut
        {
            return namn;
        }
        public void SetNamn(string sVärde) // ska lagga in värden i classen
        {
            namn = sVärde;
        }
        public int GetTemp()
        {
            return temp;
        }
        public void SetTemp(int tVärde)
        {
            temp = tVärde;
        }

    }

    internal class Program
    {
        static int LinjärSök(Stad[] list, int sökTemp) // tar in classens objekt och sökta temperatur
        {

            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].GetTemp() == sökTemp) // skilljer ut classens int värden
                {
                    return i;
                }
            }
            return -1;
        }
        static void Bubbolsort(Stad[] sortera) // sorterar städerna efter temperatur
        {

            int max = sortera.Length - 1;

            for (int i = 0; i < max; i++)
            {
                int vänster = max - i;

                for (int j = 0; j < vänster; j++)
                {
                    Stad sortStad = new Stad(); // skapar nytt objekt för att behålla stads namn

                    if (sortera[j].GetTemp() > sortera[j + 1].GetTemp())
                    {
                        sortStad = sortera[j];
                        sortera[j] = sortera[j + 1];
                        sortera[j + 1] = sortStad;
                    }
                }
            }
            for (int i = 0; i < sortera.Length; i++) // skriver ut de objekt som befinner sig i classen 
                Console.WriteLine(sortera[i].toString());

        }
        static void HögstTemp(Stad[] högstTemp)
        {
            int h = högstTemp.Length - 1;
            Console.WriteLine(högstTemp[h].toString()); // en sorterad lista gör de möjligt att polocka ut sista index nr som högst temp
        }
        static void LägstTemp(Stad[] lägstTemp)
        {
            Console.Write(lägstTemp[0].toString()); // eftersom lista nu är sorterad med lägst temp i första index
        }
        static int BinärSök(Stad[] sorteradlista, int vänster, int höger, int sökTemp) //algoritm till binärsökning
        {

            if (höger >= vänster) // höger led ska vara lika med eller större än vänsterled
            {
                int mitten = (vänster + höger) / 2;

                if (sorteradlista[mitten].GetTemp() > sökTemp) // om sökta temp är ett högre värde 
                {
                    return BinärSök(sorteradlista, vänster, mitten - 1, sökTemp); // så leta lägre
                }
                else if (sorteradlista[mitten].GetTemp() < sökTemp)
                {
                    return BinärSök(sorteradlista, mitten + 1, höger, sökTemp);//leta högre
                }
                else
                {
                    return mitten;
                }
            }
            return -1;
        }

        static void Main(string[] args) //Här börjar programmmet
        {

            int tempSök;

            Stad[] stadlist; // Gör en vektor av objekt
            int storlek; // variabel för att bestämma storlek på vektorn från användaren

            Console.WriteLine("Här kan du gemföra städer och dess temperatur"); // välkommst meddelande
            Console.WriteLine("Hur många städer vill du gemföra? ");

            try // ifall användaren inte matar i siffror så fångas de upp och programmet kan fortsätta.
            {
                storlek = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Du kan bra skriva siffror!");
                Console.WriteLine("Hur många städer vill du gemföra? ");
                storlek = Convert.ToInt32(Console.ReadLine());
            }


            if (storlek > 0) // ifall inget matas in börjar inte programmet
            {

                string sökNamn;
                int sökTemp;

                stadlist = new Stad[storlek]; // skapar objekt vektor med valbarstorlek

                for (int iRäkna = 0; iRäkna < stadlist.Length; iRäkna++) // ber användaren skapa objekten som ska tillhöra listan
                {
                    stadlist[iRäkna] = new Stad();// skapar nytt objekt till varje index plasering

                    Console.WriteLine("Skriv i stadens namn: ");
                    sökNamn = Console.ReadLine();

                    Console.WriteLine("och temperatur: ");
                    sökTemp = Convert.ToInt32(Console.ReadLine());

                    if (sökTemp >= -60 && sökTemp <= 60) // enligt uppgiften ska detta kontrolleras
                    {
                        stadlist[iRäkna].SetNamn(sökNamn); // sätter i användarens val i objektets attrebut
                        stadlist[iRäkna].SetTemp(sökTemp);

                    }
                    else
                    {
                        Console.WriteLine("Temperatur ogiltig");
                        Console.WriteLine("Försök igen: ");
                        sökTemp = Convert.ToInt32(Console.ReadLine());
                    }
                }

                Console.ReadKey(); // rensar konsoll
                Console.Clear();

                Console.WriteLine("----- De du har fyllt i ------");
                for (int i = 0; i < stadlist.Length; i++) //skriver ut objekt
                {
                    Console.WriteLine(stadlist[i].toString());
                }
                Console.WriteLine("------------------------------");
                Console.WriteLine(" Kallaste staden till varmaste");
                Bubbolsort(stadlist);
                Console.WriteLine("------------------------------");

                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("vilken temperatur letar du efter? ");
                tempSök = Convert.ToInt32(Console.ReadLine());

                LinjärSök(stadlist, tempSök);
                Console.WriteLine(stadlist[LinjärSök(stadlist, tempSök)].GetTemp() + " grader är temperaturen i " + stadlist[LinjärSök(stadlist, tempSök)].GetNamn());
                Console.WriteLine("Staden befinner sig som nr " + LinjärSök(stadlist, tempSök) + " i index");

                Console.ReadKey();
                Console.Clear();

                Console.Write("Staden med högst temperaturen är ");
                HögstTemp(stadlist);
                Console.WriteLine(" och ");
                Console.Write("Staden med lägst temperaturen är ");
                LägstTemp(stadlist);

                Console.ReadKey();
                Console.Clear();


                Console.WriteLine("Sök upp en temperatur i listan: ");
                tempSök = Convert.ToInt32(Console.ReadLine());

                int hitta = BinärSök(stadlist, 0, stadlist.Length - 1, tempSök);
                Console.WriteLine("Din sökta temperatur ligger som index nr " + hitta);

                Console.WriteLine("De var allt.........Hej Då");

                Console.ReadKey();
                Console.Clear();

            }





        }
    }         
}

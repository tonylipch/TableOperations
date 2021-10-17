
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Sockets;

namespace SortTable
{
    public enum SortFields
    {
        ID, NAME, ADDRESS
    }

    public enum SortOrder
    {
        ASC, DESC
    }



    class TableRow
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }

        public int compareTo(TableRow other, SortFields field, SortOrder order)
        {
            int result = 0;
            switch (field)
            {
                case SortFields.ID:
                    result = this.id.CompareTo(other.id);
                    break;

                case SortFields.NAME:
                    result = this.id.CompareTo(other.name);
                    break;

                case SortFields.ADDRESS:
                    result = this.address.CompareTo(other.address);
                    break;

            }

            if (order == SortOrder.DESC)
            {
                result = result * -1;
            }
            return result;

        }

        public void print()
        {
            Console.WriteLine(id + " - " + name + " - " + address);

          
        }
    }
    class TableDAO
    {

        List<TableRow> r = new List<TableRow>();


        public TableRow createRow(int id, string name, string address)
        {
            TableRow row = new TableRow();


            row.name = name;

            row.address = address;

            row.id = id;


            r.Add(row);

            return row;

        }

        private int findRowIndex(int id)
        {
            TableRow row = new TableRow();
            for (int i = 0; i < r.Count; i++)
            {
                row = r[i];
                if (row.id.Equals(id)) return i;
            }
            return -1;
        }

        public TableRow get(int id)
        {
            int index = findRowIndex(id);
            if (index >= 0)
            {
                return r[index];
            }

            return null;
        }

        List<TableRow> list()
        {
            return r;
        }

        public void update(int id, String name, String address)
        {

            int index = findRowIndex(id);
            if (index >= 0)
            {
                TableRow row = r[index];
                row.name = name;
                row.address = address;

            }
        }

        public void delete(int id)
        {


            int index = findRowIndex(id);

            if (index >= 0)
            {
                r.RemoveAt(index);

            }
        }

        void printRow(SortFields fields) 
        {

            string sep = "" ;

            for (int i =0; i<r.Count; i++)
            {
                switch (fields) 
                {
                    case SortFields.ID:
                        Console.Write(r[i].id);
                        Console.Write(",");
                        break;

                    case SortFields.NAME:
                        Console.Write(r[i].name);
                        Console.Write(",");
                        break;

                    case SortFields.ADDRESS:
                        Console.Write(r[i].address);
                        Console.Write(",");
                        break;



                }
                sep = ",";

            }
            Console.WriteLine();




        }

        public void sortByIncl(SortFields field, SortOrder order)
        {
            TableRow temp;
            printRow(field);

            //Sort Including
            for (int i = 1; i < r.Count; i++)
            {
                temp = r[i];

                int j = i;

                while (j > 0 && r[j - 1].compareTo(temp, field, order) > 0)
                {
                    r[j] = r[j - 1];
                    printRow(field);
                    j--;

                }
                r[j] = temp;



            }
        }
        


            public void sortByShell(SortFields field, SortOrder order)
            {
            //расстояние между элементами, которые сравниваются
            var d = r.Count / 2;
            TableRow temp;
            while (d >= 1)
            {
                for (var i = d; i < r.Count; i++)
                {
                    var j = i;
                    while (j >= d && r[j - d].compareTo(r[j],field,order) > 0 )
                    {
                        temp = r[j];
                        r[j] = r[j-d];
                        r[j - d] = temp;

                        j = j - d;
                    }
                }

                d = d / 2;
            }

           
        }



        public void print()
        {

            for (int i = 0; i < r.Count; i++)
            {
                r[i].print();
            }

        }


        





        class Program
        {



/*
            static void _Main(string[] args)
            {

                string pathToMenu = "menu.txt";

                string menu = File.ReadAllText(pathToMenu);


                TableRow parametres = new TableRow();
                TableDAO dao = new TableDAO();

               

                while (true)
                {
                    Console.WriteLine(menu);
                    int choise = int.Parse(Console.ReadLine());

                    int insID;
                    string name;
                    string address;

                    
                


                    Console.Clear();
                    switch (choise)
                    {
                        case 1:

                             Console.WriteLine(" Please enter your Rows ID->NAME->YOUR ADDRESS");


                             insID = int.Parse(Console.ReadLine());
                             name = Console.ReadLine();
                             address = Console.ReadLine();

                                 Console.WriteLine("\n");


                                 dao.createRow(insID, name , address );
                               
 


                            dao.print();

                               
                                Console.WriteLine("\n");


                            break;

                        case 2:


                            dao.print();

                            Console.WriteLine("\nPlease chose ROW ID which you wanna to upd then enter new parameters");
                            insID = int.Parse(Console.ReadLine());
                            name = Console.ReadLine();
                            address = Console.ReadLine();
                            dao.update(insID, name, address);

                            Console.WriteLine("\n Update has been success \n\n");


                            dao.print();

                            Console.WriteLine("\n");
                            break;

                        case 3:
                            dao.print();

                            Console.WriteLine("\nPlease chose ROW ID which you wanna to remove");

                            insID = int.Parse(Console.ReadLine());

                            dao.delete(insID);

                            Console.WriteLine("\n Row has been deleted\n");


                            dao.print();
                            break;

                        case 4:

                            dao.sortByIncl(SortFields.ID, SortOrder.ASC);

                            Console.WriteLine("\n Table sorted by Asc used  Insertion sort  \n");

                            dao.print();
                            break;


                        case 5:
                            dao.sortByShell(SortFields.ID, SortOrder.DESC);

                            Console.WriteLine("\n Table sorted by DESC used  Shell sort  \n");

                            dao.print();

                            break;

                        case 0: break;
                        default: Console.WriteLine("Wrong enter"); break;
                         


                    }
                }*/

                static void Main(string[] args)
                {
                    TableDAO dao = new TableDAO();


                    dao.createRow(2, "", "");
                    dao.createRow(12, "", "");
                    dao.createRow(46, "", "");
                    dao.createRow(48, "", "");
                    dao.createRow(3, "", "");
                    dao.createRow(6, "", "");
                    dao.createRow(102, "", "");

                    dao.sortByIncl(SortFields.ID, SortOrder.ASC);
                    dao.print();

                Console.ReadKey();

                Console.ReadKey();



            }



        }
             

     
    }


}



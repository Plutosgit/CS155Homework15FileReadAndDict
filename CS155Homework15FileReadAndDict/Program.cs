using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace CS155Homework15FileReadAndDict
{
    class Program
    {
        static void Main(string[] args)
        {
            String filefullpath_boys = "C:\\MyData\\#BVR\\Mira Costa\\C# and .NET\\Projects\\Homework 13\\boynames.txt";
            String filefullpath_girls = "C:\\MyData\\#BVR\\Mira Costa\\C# and .NET\\Projects\\Homework 13\\girlnames.txt";
            StreamReader fstream_boys = new StreamReader(filefullpath_boys);
            StreamReader fstream_girls = new StreamReader(filefullpath_girls);

            Dictionary<string, ValueAndRank> boys = new Dictionary<string, ValueAndRank>(); 
            Dictionary<string, ValueAndRank> girls = new Dictionary<string, ValueAndRank>();

            bool bFound;
            string user_input_name;
            string line = null;
            string[] name_count_split;
            char[] string_delimiters = { ' ' };     //Specify delimiters for the split function to seperate words in a string..
            long count_boys = 0,
                count_girls = 0;


            Console.WriteLine("Hello! Homework 13, file read and Dictionary search");
            Console.WriteLine("---------------------------------------------------\n");

            //now boys..
            using (fstream_boys)      //In C#, it appears the preference is to wrap it in a using statement
            {
                while ((line = fstream_boys.ReadLine()) != null)
                {
                    count_boys++;

                    //line processing
                    name_count_split = line.Split(string_delimiters);

                    ValueAndRank val_rank = new ValueAndRank(long.Parse(name_count_split[1]), count_boys);
                    boys.Add(name_count_split[0], val_rank);

                }
                Console.WriteLine("# of Boys  read from file = " + boys.Count);

            }

            //now girls..
            using (fstream_girls)      //In C#, it appears the preference is to wrap it in a using statement
            {
                while ((line = fstream_girls.ReadLine()) != null)
                {
                    count_girls++;

                    //line processing
                    name_count_split = line.Split(string_delimiters);

                    ValueAndRank val_rank = new ValueAndRank(long.Parse(name_count_split[1]), count_girls);
                    girls.Add(name_count_split[0], val_rank);

                }
                Console.WriteLine("# of Girls read from file = " + girls.Count);

            }


            //Now allow user to specify a name & output the result..
            Console.WriteLine();

            do
            {
                Console.Write("Enter a first name ('quit' to exit): ");
                user_input_name = Console.ReadLine();

                if (user_input_name != "quit")
                {
                    //check boys
                    bFound = false;
                    foreach (string key in boys.Keys)
                    {
                       if (key == user_input_name)
                        {
                            //Output format per question: Walter is ranked 356 in popularity among boys with 775 namings.
                            ValueAndRank val_rank = boys[key];
                            Console.WriteLine(user_input_name + " is ranked " + val_rank.Rank.ToString() + " in popularity among boys with " + val_rank.Value.ToString() + " namings.");
                            bFound = true;
                            break;  //exit the loop, no more checking needed..
                        }

                    }

                    if (!bFound)
                    {
                        //Output format per question: Walter is not ranked among the top 1000 girl names.
                        Console.WriteLine(user_input_name + " is not ranked among the top 1000 boy names.") ;
                    }

                    //check girls
                    bFound = false;
                    foreach (string key in girls.Keys)
                    {
                        if (key == user_input_name)
                        {
                            ValueAndRank val_rank = girls[key];
                            Console.WriteLine(user_input_name + " is ranked " + val_rank.Rank.ToString() + " in popularity among girls with " + val_rank.Value.ToString() + " namings.");
                            bFound = true;
                            break;  //exit the loop, no more checking needed..
                        }

                    }

                    if (!bFound)
                    {
                        //Output format per question: Walter is not ranked among the top 1000 girl names.
                        Console.WriteLine(user_input_name + " is not ranked among the top 1000 girl names.");
                    }


                }

                Console.WriteLine();

            } while (user_input_name != "quit");
            
            Console.ReadKey();
        }
    }

    class ValueAndRank          //This is the user-defined object indicated by the Assignment question ("The key should be the name and value should be a user defined object which is the count and rank of the name.")
    {
        long value;
        long rank;

        public ValueAndRank()
        {
            Value = 0;
            Rank = 0;
        }
        
        public ValueAndRank(long n, long r)
        {
            Value = n;
            Rank = r;
        }

        public long Value { get => value; set => this.value = value; }
        public long Rank { get => rank; set => rank = value; }
    }
}

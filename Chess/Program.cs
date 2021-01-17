using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class MainClass
    {
        public static void Pawns(string selected, string[,] output, int[] rowplacements, int[] colplacements, string move, string colour, int[] Wpawnmovecount, int[] Bpawnmovecount)
        {
            int movecounter = 0;
            int currentrow = 0;
            int currentcol = 0;
                       
            bool validmove = false;
            bool blocker = false;
                        
            selected = "   " + colour + selected + "   ";
                       
            for (int row = 0; row < 41; row++)
            {

                for (int col = 0; col < 17; col++)
                {
                    if (selected == output[row, col])
                    {
                        output[row, col] = "";
                        currentrow = row;
                        currentcol = col;
                    }
                }
            }
            int newrow = 0;
            int newcol = 0;
            do
            {
                Console.WriteLine("Input the position you want to move " + selected + " to: ");
                move = Console.ReadLine();

                byte[] convert = Encoding.ASCII.GetBytes(move.Substring(0));
                int ascii = Convert.ToInt32(convert[0]);

                newrow = Convert.ToInt32(move.Substring(1));
                newrow = rowplacements[newrow - 1];

                newcol = ascii - 65;

                for (int i = 0; i < 7; i++)
                {
                    if (currentrow == rowplacements[i])
                    {
                        currentrow = rowplacements[i];
                    }
                }
                if (currentcol == 3)
                {
                    currentcol = currentcol - 1;
                }
                if (currentcol == 5)
                {
                    currentcol = currentcol - 2;
                }
                if (currentcol == 7)
                {
                    currentcol = currentcol - 3;
                }
                if (currentcol == 9)
                {
                    currentcol = currentcol - 4;
                }
                if (currentcol == 11)
                {
                    currentcol = currentcol - 5;
                }
                if (currentcol == 13)
                {
                    currentcol = currentcol - 6;
                }
                if (currentcol == 15)
                {
                    currentcol = currentcol - 7;
                }

                movecounter = Convert.ToInt32(selected.Substring(6)) - 1;
                Console.WriteLine(currentrow);
                Console.WriteLine(newrow);

                if (colour == "W.")
                {
                    if ((currentrow - newrow) == 4 || (Wpawnmovecount[movecounter] == 0 && currentrow - newrow == 8))
                    {
                        string position = output[rowplacements[newrow], colplacements[newcol]];
                        Console.WriteLine("hello");
                        Console.WriteLine(position);
                        if (position[3] == 'W')
                        {
                            blocker = true;
                        }
                        if (currentcol == (newcol + 1) && blocker == false)
                        {
                            if (output[rowplacements[newrow - 1], colplacements[newcol]] == "          ")
                            {
                                validmove = true;
                                output[rowplacements[newrow - 1], colplacements[newcol]] = selected;
                                Wpawnmovecount[movecounter] = Wpawnmovecount[movecounter] + 1;
                            }
                        }
                    }
                }
                if (colour == "B.")
                {
                    if ((currentrow - newrow) == -4 || (Wpawnmovecount[movecounter] == 0 && currentrow - newrow == -8))
                    {
                        newrow = Convert.ToInt32(move.Substring(1));
                        string position = output[rowplacements[newrow], colplacements[newcol]];
                        if (position[3] == 'B')
                        {
                            blocker = true;
                        }
                        if (currentcol == (newcol + 1) && blocker == false)
                        {
                            if (output[rowplacements[newrow - 1], colplacements[newcol]] == "          ")
                            {
                                validmove = true;
                                output[rowplacements[newrow - 1], colplacements[newcol]] = selected;
                                Wpawnmovecount[movecounter] = Wpawnmovecount[movecounter] + 1;
                            }
                        }
                    }
                    /*  
                       if (currentcol - newcol == 1 && (currentrow - newrow) == 4 && (output[rowplacements[newrow - 1], colplacements[newcol]]).Substring(3) == colour.Substring(0) && colour == "B.")
                       {
                           validmove = true;
                           output[rowplacements[newrow - 1], colplacements[newcol]] = selected;
                           Wpawnmovecount[movecounter] = Wpawnmovecount[movecounter] + 1;
                       }
                       */
                }
            } while (validmove == false);
        }

        public static void Blackmove(string[,] output, int[] rowplacements, int[] colplacements, string colour, int[] Wpawnmovecount, int[] Bpawnmovecount)

        {

            string[] bpieces = { "R1", "R2", "K1", "K1", "K2", "King", "Queen", "P1", "P2", "P3", "P4", "P5", "P6", "P7", "P8" };

            string selected = " ";

            colour = "B.";

            string move = " ";

            Console.WriteLine();

            bool validpiece = false;







            do

            {

                Console.WriteLine("What piece would you like to move: ");

                selected = Console.ReadLine();

                for (int i = 0; i < 15; i++)

                {

                    if (selected == bpieces[i])

                    {

                        validpiece = true;

                    }

                }

            } while (validpiece == false);



            switch (selected[0])

            {

                case 'P':

                    Pawns(selected, output, rowplacements, colplacements, move, colour, Wpawnmovecount, Bpawnmovecount);

                    break;

                default:

                    Console.WriteLine("Error");

                    break;

            }

        }

        public static void Whitemove(string[,] output, int[] rowplacements, int[] colplacements, string colour, int[] Wpawnmovecount, int[] Bpawnmovecount)

        {

            string[] wpieces = { "R1", "R2", "K1", "K1", "K2", "King", "Queen", "P1", "P2", "P3", "P4", "P5", "P6", "P7", "P8" };

            string selected = " ";

            colour = "W.";

            string move = " ";

            Console.WriteLine();

            bool validpiece = false;





            do

            {

                Console.WriteLine("What piece would you like to move: ");

                selected = Console.ReadLine();

                for (int i = 0; i < 15; i++)

                {

                    if (selected == wpieces[i])

                    {

                        validpiece = true;

                    }

                }

            } while (validpiece == false);



            switch (selected[0])

            {

                case 'P':

                    Pawns(selected, output, rowplacements, colplacements, move, colour, Wpawnmovecount, Bpawnmovecount);

                    break;

                default:

                    Console.WriteLine("Error");

                    break;

            }

        }



        public static void Board(string[,] output)

        {

            Console.WriteLine();

            for (int row = 0; row < 41; row++)

            {

                for (int col = 0; col < 17; col++)

                {

                    if (output[row, col] == "")

                    {

                        output[row, col] = "          ";

                    }

                    Console.Write(output[row, col]);

                }

                Console.WriteLine();

            }

            Console.WriteLine();

        }



        static void Main(string[] args)

        {

            int[] Wpawnmovecount = { 0, 0, 0, 0, 0, 0, 0, 0 };

            int[] Bpawnmovecount = { 0, 0, 0, 0, 0, 0, 0, 0 };

            string colour = "";

            int[] rowplacements = { 6, 10, 14, 18, 22, 26, 30, 34 };

            int[] colplacements = { 1, 3, 5, 7, 9, 11, 13, 15 };

            bool checkmate = false;

            string[,] output =

                {

                { "----------","----------", "-", "----------", "-", "----------", "-", "----------", "-", "----------", "-", "----------", "-","----------", "-","----------","----------" },

                { "|        |","          ", " ", "          ", " ", "          ", " ", "          ", " ", "          ", " ", "          ", " ","          ", " ","          ","|        |" },

                { "|        |","     A    ", " ", "     B    ", " ", "     C    ", " ", "     D    ", " ", "     E    ", " ", "    F     ", " ","     G    ", " ","     H    ","|        |" },

                { "|        |","          ", " ", "          ", " ", "          ", " ", "          ", " ", "          ", " ", "          ", " ","          ", " ","          ","|        |" },

                { "|--------|","----------", "-", "----------", "-", "----------", "-", "----------", "-", "----------", "-", "----------", "-","----------", "-","----------","|--------|" },

                { "|        |","          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|","          ", "|","          ","|        |" },

                { "|    1   |","   B.R1   ", "|", "   B.K1   ", "|", "   B.B1   ", "|", "  B.King  ", "|", "  B.Queen ", "|", "   B.B2   ", "|","   B.K2   ", "|","   B.R2   ","|    1   |" },

                { "|        |","          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|","          ", "|","          ","|        |" },

                { "|        |","----------", "-", "----------", "-", "----------", "-", "----------", "-", "----------", "-", "----------", "-","----------", "-","----------","|        |" },

                { "|        |","          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|","          ", "|","          ","|        |" },

                { "|    2   |","   B.P1   ", "|", "   B.P2   ", "|", "   B.P3   ", "|", "   B.P4   ", "|", "   B.P5   ", "|", "   B.P6   ", "|","   B.P7   ", "|","   B.P8   ","|    2   |" },

                { "|        |","          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|","          ", "|","          ","|        |" },

                { "|        |","----------", "-", "----------", "-", "----------", "-", "----------", "-", "----------", "-", "----------", "-","----------", "-","----------","|        |" },

                { "|        |","          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|","          ", "|","          ","|        |" },

                { "|    3   |","          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|","          ", "|","          ","|    3   |" },

                { "|        |","          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|","          ", "|","          ","|        |" },

                { "|        |","----------", "-", "----------", "-", "----------", "-", "----------", "-", "----------", "-", "----------", "-","----------", "-","----------","|        |" },

                { "|        |","          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|","          ", "|","          ","|        |" },

                { "|    4   |","          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|","          ", "|","          ","|    4   |" },

                { "|        |","          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|","          ", "|","          ","|        |" },

                { "|        |","----------", "-", "----------", "-", "----------", "-", "----------", "-", "----------", "-", "----------", "-","----------", "-","----------","|        |" },

                { "|        |","          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|","          ", "|","          ","|        |" },

                { "|    5   |","          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|","          ", "|","          ","|    5   |" },

                { "|        |","          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|","          ", "|","          ","|        |" },

                { "|        |","----------", "-", "----------", "-", "----------", "-", "----------", "-", "----------", "-", "----------", "-","----------", "-","----------","|        |" },

                { "|        |","          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|","          ", "|","          ","|        |" },

                { "|    6   |","          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|","          ", "|","          ","|    6   |" },

                { "|        |","          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|","          ", "|","          ","|        |" },

                { "|        |","----------", "-", "----------", "-", "----------", "-", "----------", "-", "----------", "-", "----------", "-","----------", "-","----------","|        |" },

                { "|        |","          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|","          ", "|","          ","|        |" },

                { "|    7   |","   W.P1   ", "|", "   W.P2   ", "|", "   W.P3   ", "|", "   W.P4   ", "|", "   W.P5   ", "|", "   W.P6   ", "|","   W.P7   ", "|","   W.P8   ","|    7   |" },

                { "|        |","          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|","          ", "|","          ","|        |" },

                { "|        |","----------", "-", "----------", "-", "----------", "-", "----------", "-", "----------", "-", "----------", "-","----------", "-","----------","|        |" },

                { "|        |","          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|","          ", "|","          ","|        |" },

                { "|    8   |","   W.R1   ", "|", "   W.K1   ", "|", "   W.B1   ", "|", "  W.King  ", "|", "  W.Queen ", "|", "   W.B2   ", "|","   W.K2   ", "|","   W.R2   ","|    8   |" },

                { "|        |","          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|", "          ", "|","          ", "|","          ","|        |" },

                { "|--------|","----------", "-", "----------", "-", "----------", "-", "----------", "-", "----------", "-", "----------", "-","----------", "-","----------","|--------|" },

                { "|        |","          ", " ", "          ", " ", "          ", " ", "          ", " ", "          ", " ", "          ", " ","          ", " ","          ","|        |" },

                { "|        |","     A    ", " ", "     B    ", " ", "     C    ", " ", "     D    ", " ", "     E    ", " ", "    F     ", " ","     G    ", " ","     H    ","|        |" },

                { "|        |","          ", " ", "          ", " ", "          ", " ", "          ", " ", "          ", " ", "          ", " ","          ", " ","          ","|        |" },

                { "----------","----------", "-", "----------", "-", "----------", "-", "----------", "-", "----------", "-", "----------", "-","----------", "-","----------","----------" }

                };

            do

            {

                Board(output);

                Whitemove(output, rowplacements, colplacements, colour, Wpawnmovecount, Bpawnmovecount);



                Board(output);

                Blackmove(output, rowplacements, colplacements, colour, Wpawnmovecount, Bpawnmovecount);

                Console.Clear();

            } while (checkmate == false);

        }
    }
}

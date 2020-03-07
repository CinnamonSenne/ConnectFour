using System;
using System.Net.Http.Headers;

namespace VierOpEenRij
{
    public class VierOpEenRij
    {
        // Creating variables and array
        
        const int RIJEN = 6;
        const int KOLOMMEN = 7;
        public int index;
        string[,] Canvas = new string[RIJEN, KOLOMMEN];
        
        // Creating positional property 
        public int Index
        {
            get { return index;}
            set
            {
                if (value < 1 || value > 7)
                {
                    index = 1;
                }
                else
                {
                    index = value;
                }
            } 
        }
        
        // Initiating array
        public VierOpEenRij()
        {
            for (int i = 0; i < RIJEN; i++)
            {
                for (int j = 0; j < KOLOMMEN; j++)
                {
                    Canvas[i, j] = ".";
                }
            }
        }

        public void ShowArray()
        { 
            ShowNumberRow();
            for (int i = 0; i < RIJEN; i++)
            {
                for (int j = 0; j < KOLOMMEN; j++)
                {
                    Console.Write($"{Canvas[i, j]}\t");
                }

                Console.WriteLine();
            }
        }

        public void ShowNumberRow()
        {
            const int numberrowHorizontal = 7;
            int[] numberRow = new int[numberrowHorizontal];

            for (int i = 0; i < numberrowHorizontal; i++)
            {
                numberRow[i] = i+1;
            }
            
            for (int i = 0; i < numberrowHorizontal; i++)
            {
                Console.Write($"{numberRow[i]}\t");
            }
            Console.WriteLine();
            
            
        }
        
        public void AddToCanvasP1()
        {
            Console.Write($"Player 1, where do you want to add x ? ");
            try
            {
                Index = int.Parse(Console.ReadLine());
                int count = RIJEN;
                do
                {
                    // Gaat de geselecteerde rij van onder naar boven afgaan en zien of de plek leeg is
                    count--;
                    if (Canvas[count, Index - 1] == ".")
                    {
                        Canvas[count, Index - 1] = "x";
                        break;
                    }
                } while (count >= 0);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Geef een getal in!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops! Something went wrong!");
                throw;
            }
        }

        public void AddToCanvasP2()
        {
            Console.Write($"Player 2, where do you want to add o ? ");
                try
                {
                    Index = int.Parse(Console.ReadLine());
                    int count = RIJEN;
                    do
                    {
                        // Will check the selected row to see whether it's empty or not
                        count--;
                        if (Canvas[count, Index - 1] == ".")
                        {
                            Canvas[count, Index - 1] = "o";
                            break;
                        }
                    } while (count >= 0);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Enter a number!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oops! Something went wrong!");
                    throw;
                }
            }

        // Will check the grid every turn to see whether or not someone connected 3
            public bool GameOver()
            { 
                int arrayIndex;
            for (int j = 0; j < KOLOMMEN; j++)
            {
                for (int i = 0; i < RIJEN; i++)
                {
                    if (Canvas[i,j] == "x" || Canvas[i,j] == "o")
                    {
                        arrayIndex = j;
                        if (j != 0 && j != KOLOMMEN)
                        {
                            // Horizontally
                            if (Canvas[i, arrayIndex] == Canvas[i, arrayIndex - 1] &&
                                Canvas[i, arrayIndex] == Canvas[i, arrayIndex + 1])
                            {
                                return true; 
                            }
                        }

                        if (i != 0)
                        {
                            // Vertically 
                            if (Canvas[i, arrayIndex] == Canvas[i - 1, arrayIndex] &&
                                  Canvas[i, arrayIndex] == Canvas[i - 2, arrayIndex])
                            {
                                return true;
                            }

                            if (j != KOLOMMEN && i != RIJEN - 1)
                            {
                                // Diagonaly to the right
                                if (Canvas[i, arrayIndex] == Canvas[i - 1, arrayIndex + 1] &&
                                    Canvas[i, arrayIndex] == Canvas[i + 1, arrayIndex - 1])
                                {
                                    return true;
                                }
                            }
                            if (j != 0 && i != RIJEN - 1) 
                            { 
                                // Diagonaly to the left
                                if (Canvas[i, arrayIndex] == Canvas[i - 1, arrayIndex - 1] &&
                                    Canvas[i, arrayIndex] == Canvas[i + 1, arrayIndex + 1])
                                {
                                    
                                    return true; 
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        public void PlayGame()
        {
            while(!GameOver())
            {
                AddToCanvasP1();
                ShowArray();

                Console.Clear();
                ShowArray();
                
                if (GameOver())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Yahtzee!\n Player 1 won! ");
                    break;
                }
                
                AddToCanvasP2();
                ShowArray();
                if (GameOver())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Yahtzee!\n Player 2 won!");
                    break;
                }
                
                Console.Clear();
                ShowArray();
            }
        }
    }
}

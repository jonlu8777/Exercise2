namespace Exercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run();
                
        }

        private static void Run()
        {
          bool eternalLoop = true; 
          
            do
            {
            Console.WriteLine();
            Console.WriteLine("----- MENU:-----");
            Console.WriteLine("-Use integers to navigate-");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Youth / Retired / Standard / Free of charge");
            Console.WriteLine("2. Calculate total ticket price for a group of people (Max 10 people)"); 
            Console.WriteLine("3. Enter TEXT, print 10 times");
            Console.WriteLine("4. Enter a sentence, print the third word");

                uint navigateInt = ConsoleReaduIntParse(); //Method to TryParse uIntegers  

             switch(navigateInt)
                {
                    case 0:
                        {
                            Environment.Exit(0);                      // Shut down program
                            break;
                        }
                    case 1:
                        {
                            EnterAgePrintPrice();                     //Print price depending on age: Youth/Retired/Standard
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("How many tickets do you want: (Max 10)");
                            uint numberOfTickets = 11;
                            while (numberOfTickets > 10)                         //Max 10 people in a group
                            {
                                numberOfTickets = ConsoleReaduIntParse();      //Enter number of tickets
                            }
                            int sum = 0;
                            for (int i = 0; i < numberOfTickets; i++)
                            {
                                sum += EnterAgeReturnPrice(i);               //calculate ticket price sum of a group             
                            }  
                                Console.WriteLine($" Number of tickets: {numberOfTickets}, total price: {sum}"); // Print sum and number of persons
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter any text:");            
                            string text = Console.ReadLine()!;
                            for(int i = 0; i < 10; i++)                     
                            {
                                Console.Write($"{i+1}:{text} ");                // Output: 1.TEXT 2.TEXT 3.TEXT... ...10.TEXT
                            }

                            break;
                        }

                        case 4:
                        {
                             
                            bool runThis = true;
                            do
                            {
                                Console.WriteLine("Enter at minimum a three word sentence:");           
                                string sentence = Console.ReadLine()!;
                                var words = sentence.Split(' ');                        //string array .split on whitespace

                                if (words.Length <= 2)                      
                                {
                                    Console.WriteLine("-too short sentence!-");           
                                }
                                else if(words.Length >=3)
                                {
                                    Console.WriteLine($"Third word in your sentence was: {words[2]}"); // print third word in string array
                                    runThis = false;
                                }
                                
                            
                            } while (runThis);  //execute until sentence contains three or more words
                            break;
                            
                        }

                        default:
                        Console.WriteLine("-Input Error!-");                        //If Input out of switch scope  
                        break;
                }

            }while (eternalLoop);            // Eternal loop until Enviroment.Exit(0); 

        }

        private static uint ConsoleReaduIntParse()
        {
            
            while (true)
            {
                if (uint.TryParse(Console.ReadLine()!, out uint result))
                {
                    return result;   
                }
                Console.WriteLine("-Only integers valid input-");
            }
        } // ReadLine and IntTryParse, return int 

        private static int EnterAgeReturnPrice(int i) //input value "i" is a counter to number of people in group
        {
            
            Console.WriteLine($"{i+1}.Enter age:");
            uint personAge = ConsoleReaduIntParse(); 

            if (personAge <= 5 || personAge >= 100) // check if free of charge 
            {
                return 0;
            }
            else if (personAge < 20) //check if youth 
            {
                
                return 80;
            }
            else if (personAge > 64) //check if retired 
            {
               
                return 90;
            }
            else if (personAge >= 20 && personAge <= 64) //check if standard 
            {
                
                return 120;
            }
            return 1;
        } // Asks for age, return: int price depending on Youth/Retired/Standard

        private static void EnterAgePrintPrice()
        {
            
            Console.WriteLine("Youth / Retired / Standard / Free of charge");
            Console.WriteLine("Enter age:");
            uint personAge = ConsoleReaduIntParse(); 

            if(personAge >= 100 || personAge <= 5) //Print "0kr" if very old or very young
            {
             Console.WriteLine("Free of charge: 0kr"); 
            }
           else if (personAge < 20) //Print if youth
            {
                Console.WriteLine("Youth price: 80kr");
            }
            else if (personAge > 64) //Print if retired 
            {
                Console.WriteLine("Retired price: 90kr");
            }
            else if(personAge >= 20 && personAge <= 64) //Print if standrad 
            {
            Console.WriteLine("Standard price 120kr");
            }

        } // Ask for age and print price depending on Youth/Retired/Standard 
    }
}
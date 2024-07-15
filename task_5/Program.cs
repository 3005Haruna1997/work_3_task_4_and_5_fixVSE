internal class Program
{
    private static void Main(string[] args)
    {
        // блок основных переменных
        string? enteredValue = "";

        // блок вспомогательных переменных
        int technicaIntlValue_1 = 0;
        int minValue = int.MaxValue;
        int currentValue;
        int numberOfOptions;

        string techicalStringValue_1 = "-";

        bool cycleExitСonditions_1 = false;
        bool cycleExitСonditions_2 = false;
        bool tryParse_enterdValue = false;

        string[] searchingIcons = { ".  ", ".. ", "...", };//для анимации

        techicalStringValue_1 = string.Join("-", Enumerable.Repeat(techicalStringValue_1, 35));//для пунктирной строчки 

        void demarcationLine()
        {
            // Разделяющая линия
            Console.WriteLine(techicalStringValue_1);
        }

        void AppExitAnimation()
        {
            for (int j = 3; j > -1; j--)
            {
                foreach (string icon in searchingIcons)
                {
                    Console.Write($"\rExit the application{icon}");
                    Thread.Sleep(350);
                }
                Console.Write($"\r{new string(' ', Console.BufferWidth)}");
            }
        }

        void notEnterANumder()
        {

            demarcationLine();
            Console.WriteLine("You didn't enter a number. " +
            "Please try again.");
        }

        void enteredValueToLower()
        {
            //Метод для определение введеных данных игнорирую регистр. И для устранения проблемы возможного нулевого референса.
            if (enteredValue != null)
            {
                enteredValue = enteredValue.ToLower();
            }
        }

        void tryParseEnteredValue()
        {
            int a = 0;
            if (int.TryParse(enteredValue, out a) == false || enteredValue == "")
            {
                enteredValueToLower();
                tryParse_enterdValue = false;
            }
            else
            {
                technicaIntlValue_1 = Convert.ToInt32(enteredValue);
                tryParse_enterdValue = true;
            }
        }


        Console.WriteLine("Please enter the range of numbers to guess," +
                          " or enter \"exit\" on keyboard to exit the application");
        do
        {
            enteredValue = Console.ReadLine();

            tryParseEnteredValue();
            
            switch (tryParse_enterdValue)
            {
                case (true):

                    numberOfOptions = int.Parse(enteredValue);
                    Random randomHiddenNumber = new Random();
                    int hiddenNumber = randomHiddenNumber.Next(0, numberOfOptions);

                    while (cycleExitСonditions_1 == false)
                    {

                        Console.WriteLine($"Try to guess the number or press \"Enter\" to close the app.");

                        do
                        {

                            enteredValue = Console.ReadLine();

                            tryParseEnteredValue();

                            switch (tryParse_enterdValue)
                            {
                                case (true):

                                    {
                                        currentValue = int.Parse(enteredValue);

                                        if (currentValue < hiddenNumber)
                                        {
                                            Console.WriteLine("The hidden number is GREATER than the value you entered." +
                                                              "\nPlease try again.");
                                        }

                                        else if (currentValue > hiddenNumber)
                                        {
                                            Console.WriteLine("The hidden number is LESS than the value you entered." +
                                                              "\nPlease try again");
                                        }

                                        else 
                                        {
                                            Console.WriteLine("Congratulations, you guessed the number !!!");
                                            Console.ReadKey();
                                            cycleExitСonditions_1 = true;
                                        }
                                    }

                                    break;

                                case (false):

                                    if (enteredValue == "")
                                    {
                                        demarcationLine();
                                        Console.WriteLine($"Hidden number is {hiddenNumber}");
                                        AppExitAnimation();
                                        cycleExitСonditions_1 = true;
                                    }

                                    else
                                    {
                                        notEnterANumder();
                                    }

                                    break;
                            }
                        }
                        while (cycleExitСonditions_1 == false);
                    }

                    cycleExitСonditions_2 = true;

                    break;

                case (false):

                    if (enteredValue == "exit")
                    {
                        demarcationLine();
                        AppExitAnimation();
                        cycleExitСonditions_2 = true;
                    }

                    else
                    {
                        notEnterANumder();
                    }

                    break;
            }
        } while (cycleExitСonditions_2 == false);
    }
}

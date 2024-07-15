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
        int sequenceLength;

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
                    Console.Write($"\rВыходим из приложения{icon}");
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


        Console.WriteLine("Please enter the length of the sequence," +
                        " or enter \"Back\" to exit the application");
        do
        {
            enteredValue = Console.ReadLine();

            tryParseEnteredValue();

            switch (tryParse_enterdValue)
            {
                case (true):

                    sequenceLength = int.Parse(enteredValue);

                    for (int i = 0; i < sequenceLength; i++)
                    {

                        Console.WriteLine($"Enter number № {i + 1}");

                        do
                        {
                            enteredValue = Console.ReadLine();

                            tryParseEnteredValue();

                            switch (tryParse_enterdValue) 
                            {
                                case (true):
                                    
                                    {
                                        currentValue = int.Parse(enteredValue);

                                        if (currentValue < minValue) 
                                        { 
                                            minValue = currentValue;
                                        }
                                        cycleExitСonditions_1 = true;
                                    }

                                break;

                                case (false):

                                    {
                                        notEnterANumder();
                                    }

                                break;
                            }
                        }
                        while (cycleExitСonditions_1 == false);
                    }

                    Console.WriteLine($"Minimum number in the entered sequence is {minValue}");
                    Console.ReadKey();
                    AppExitAnimation();
                    cycleExitСonditions_2 = true;

                    break;

                case (false):

                    if (enteredValue == "back")
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

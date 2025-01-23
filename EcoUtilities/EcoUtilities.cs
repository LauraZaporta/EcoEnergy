namespace Eco
{
    public class EcoUtils
    {
        /// <summary>
        /// Displays the main menu.
        /// </summary>
        public static void DisplayMenu()
        {
            const string MenuTitle = " ECO ENERGY MENU";
            const string MenuSeparation = " ---------------";
            const string MenuEmptySeparation = "\n";
            const string MenuOptionA = " a) [Initiate simulation]";
            const string MenuOptionB = " b) [See simulations report]";
            const string MenuOptionC = " c) [Exit]";
            const string MenuHelpUser = " Press a, b or c to select your option: ";

            Console.WriteLine(MenuEmptySeparation);
            Console.WriteLine(MenuTitle);
            Console.WriteLine(MenuSeparation);
            Console.WriteLine($"{MenuEmptySeparation}{MenuOptionA}");
            Console.WriteLine(MenuOptionB);
            Console.WriteLine(MenuOptionC);
            Console.Write($"{MenuEmptySeparation}{MenuHelpUser}");
        }

        /// <summary>
        /// Displays the simulation menu (lets you choose between 3 energy systems).
        /// </summary>
        public static void DisplaySimulationStartMenu()
        {
            const string MenuTitle = " SIMULATION MENU";
            const string MenuSeparation = " ---------------";
            const string MenuEmptySeparation = "\n";
            const string MenuOptionA = " a) [Solar system]";
            const string MenuOptionB = " b) [Eolic system]";
            const string MenuOptionC = " c) [Hidroelectric system]";
            const string MenuHelpUser = " Press a, b or c to select your option: ";

            Console.WriteLine(MenuEmptySeparation);
            Console.WriteLine(MenuTitle);
            Console.WriteLine(MenuSeparation);
            Console.WriteLine($"{MenuEmptySeparation}{MenuOptionA}");
            Console.WriteLine(MenuOptionB);
            Console.WriteLine(MenuOptionC);
            Console.Write($"{MenuEmptySeparation}{MenuHelpUser}");
        }

        /// <summary>
        /// Displays the report of all previous simulations.
        /// </summary>
        public static void ShowReports(DateTime[] dates, string[] types, double[] energy, int numSimulations)
        {
            const string MsgDates = "Date";
            const string MsgTypes = "Type";
            const string MsgEnergy = "Generated Energy";

            string Separation = new string('-', 60);

            Console.WriteLine();    
            Console.WriteLine($" {MsgDates, -20}| {MsgTypes, -15}| {MsgEnergy, -20}");
            //Els valors negatius dels missatges indiquen alineació a l'esquerra de mida X
            Console.WriteLine($" {Separation}\n");

            for (int i = 0; i < numSimulations; i++)
            {
                Console.WriteLine($" {dates[i], -20}| {types[i], -15}| {energy[i], -20}");
                Console.WriteLine($" {Separation}");
            }
        }

        /// <summary>
        /// Controls whether the input value meets a necessary condition
        /// </summary>
        /// <param name="min">The minimum value. The input needs to be above it.</param>
        /// <param name="num">The number which is being evaluated.</param>
        /// <param name="msgAsk">The message displayed to specify what is needed.</param>
        /// <returns>A value that meets the necessary condition specified.</returns>
        public static double GetValidValue(double min, double num, string msgAsk)
        {
            const string msgError = " The value should be {0} or higher!";
            double newNum = 0;
            if (num < min)
            {
                do
                {
                    Console.WriteLine(msgError, min);
                    newNum = GetValidDouble(msgAsk);
                } while (newNum < min);
                return newNum;
            }
            else { return num; }
        }

        /// <summary>
        /// Controls whether the input is valid or not (It has to be a char 'a', 'b' or 'c'). If it's not the function asks for a new input
        /// </summary>
        /// <returns>A valid char (a, b or c).</returns>
        public static char GetValidInput()
        {
            const string Error = " Type a valid option (a, b or c): ";

            bool valid;
            char output = 'a';

            do
            {
                string? input = Console.ReadLine();
                if (char.TryParse(input, out output))
                {
                    output = Char.ToLower(output);
                    if (output == 'a' || output == 'b' || output == 'c') { valid = true; }
                    else 
                    { 
                        Console.Write(Error);
                        valid = false; 
                    }
                }
                else { Console.Write(Error); valid = false; }
            } while (!valid);

            return output;
        }

        /// <summary>
        /// Returns true or false depending on the input (Y/N) which has to be a valid char (Y/N). If it's not the function asks for a new input
        /// </summary>
        /// <returns>True(Yes - Y) or false(No - N).</returns>
        public static bool GetYesOrNo()
        {
            const string Error = " Type a valid option (Y or N): ";

            bool valid;
            bool functionOutput = false;
            char output = 'a';

            do
            {
                string? input = Console.ReadLine();
                if (char.TryParse(input, out output))
                {
                    output = Char.ToUpper(output);
                    if (output == 'Y'){ functionOutput = true; valid = true; }
                    else if (output == 'N') { functionOutput = false; valid = true; }
                    else {
                        Console.WriteLine(Error);
                        valid = false;
                    }
                } else { valid = false; }
            } while (!valid);

            return functionOutput;
        }

        /// <summary>
        /// Controls whether the input is valid or not (It has to be a double). If it's not the function asks for a new input
        /// </summary>
        /// <param name="msgInfo">The message displayed to specify what is needed.</param>
        /// <returns>A valid double.</returns>
        public static double GetValidDouble(string msgInfo)
        {
            const string Error = " Type a valid number";

            bool valid;
            double output = 0;

            Console.Write(msgInfo);

            do
            {
                string? input = Console.ReadLine();
                if (double.TryParse(input, out output))
                {
                    valid = true;
                }
                else { Console.WriteLine(Error); valid = false; }
            } while (!valid);

            return output;
        }

        /// <summary>
        /// Controls whether the input is valid or not (It has to be an int). If it's not the function asks for a new input
        /// </summary>
        /// <param name="msgInfo">The message displayed to specify what is needed.</param>
        /// <returns>A valid int.</returns>
        public static int GetValidInt(string msgInfo)
        {
            const string Error = " Type a valid number";

            bool valid;
            int output = 0;

            Console.Write(msgInfo);
            do
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out output))
                {
                    valid = true;
                }
                else { Console.WriteLine(Error); valid = false; }
            } while (!valid);

            return output;
        }
    }
}
namespace demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            // validate user
            bool isValid = false;
            string userName = "";

            while (!isValid)
            {
                Console.WriteLine("Enter your name");
                userName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userName))
                {
                    Console.WriteLine("Name cannot be empty. Please enter your name");
                }
                else
                {
                    break;
                }
            }

            //Ask for age

            Console.WriteLine("Enter your age");

            int age = 0;

            // validate age
            while (true)
            {
                string ageString = Console.ReadLine();

                bool isConversionSuccessful = int.TryParse(ageString, out age);

                if (isConversionSuccessful == false || age<=0)
                {
                    Console.WriteLine("Please use numbers");
                }
                else
                {
                    break;
                }
            }

            // Ask to choose ticket type

            Console.WriteLine("Choose a ticket type:");
            Console.WriteLine("1: Child ticket (under 12 years old)");
            Console.WriteLine("2: Adult ticket (12-64 years old)");
            Console.WriteLine("3: Senior ticket (65 years or older)");
            Console.WriteLine("Enter your choice (1, 2, or 3)");

            //validating ticket types

            int ticketType = 0;
            while (true)
            {
                string ticketTypeString = Console.ReadLine();
                if (int.TryParse(ticketTypeString, out ticketType) && ticketType >= 1 && ticketType <= 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice!!!");
                }
            }

            // Displaying ticket price

            double ticketPrice = 0.00;

            switch (ticketType)
            {
                case 1:
                    {
                        ticketPrice = 4.99;
                        break;
                    }
                case 2:
                    {
                        ticketPrice = 9.99;
                        break;
                    }
                case 3:
                    {
                        ticketPrice = 6.99;
                        break;
                    }
            }
            
            //Displaying ticket type

            static string GetTicketType(int ticketType)
            {
                switch (ticketType)
                {
                    case 1:
                        return "Child";
                    case 2:
                        return "Adult";
                    default:
                        return "senior";
                }
            }
            Console.WriteLine($"The {GetTicketType(ticketType)} ticket costs {ticketPrice} euro");

            Console.WriteLine("Do you have discount code? (yes/no):");

            string hasDiscountCode = Console.ReadLine();
            double discountPrice = 0.00;

            // Declaring discount code and giving 20% off

            static bool IsValidDiscountCode(string discountCode)
            {
                return discountCode.ToLower() == "ale20";
            }

            static double CalculateDiscountAmount(double ticketPrice, string discountCode)
            {
                if (discountCode == "ale20")
                {
                    return ticketPrice * 0.20;
                }
                else
                {
                    return 0.0;
                }
            }

            // Checking if discount code matches
            if (hasDiscountCode.ToLower() == "yes")
            {
                string discountCode;
                bool isValidDiscountCode = false;

                
                while (!isValidDiscountCode)
                {
                    Console.WriteLine("Enter the discount code");
                    discountCode = Console.ReadLine();

       
                    if (IsValidDiscountCode(discountCode))
                    {
                        isValidDiscountCode = true;
                        discountPrice = CalculateDiscountAmount(ticketPrice, discountCode);
                        Console.WriteLine("Discount code accepted! You will receive a 20% discount.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid discount code. Please try again.");
                    }
                }
            }

            double finalDiscountPrice = ticketPrice - discountPrice;

            // Displaying last message

            Console.WriteLine($"{userName}, you chose {GetTicketType(ticketType)} ticket. Original price:{ticketPrice}. Discounted Price:{finalDiscountPrice:F2}");
                

        }
    }
}
 


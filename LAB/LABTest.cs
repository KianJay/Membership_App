using System;

// Duyoung Jang
//s4627596
namespace LAB
{
    class Program
    {
        static void Main(string[] args)
        {
            //the number of members we get are 5.
            const int numberOfMembers = 5;
            //user cannot enter month less than 1 more than 60. This is a validation boolean.
            bool monthValid = false;
            bool nameValid = false;
            bool specialValid = false;
            int validatedNumber;

            //for loop will add "x" for every single member depending on the number of months
            string over6Months = ""; 
            string lessor6Months = "";

            //we have multiple members, use an Array.
            Member[] m = new Member[numberOfMembers];

            //First message seen by user.
            Console.WriteLine("\tWelcome to the Sport Membership App\n");

            //For  while loop goes on til the maximum capacity of the array.
            for (int i = 0; i < numberOfMembers; i++)
            {
                //for loop starts from 0.
                m[i] = new Member();

                //name validation to avoid empty or space only entry.
                while (nameValid == false)
                {
                    Console.Write("Enter customer name " + (i + 1) + ": ");
                    m[i].memberName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(m[i].memberName))
                    {
                        Console.Write("\nName CANNOT be empty! \n");
                    }
                    else
                    {
                        nameValid = true;
                    }
                }

                Console.WriteLine();

                //month validation to avoid invalid numbers and characters.
                while (monthValid == false)
                {
                    Console.Write("Enter the number of months: ");
                    string InputMonth = Console.ReadLine();
                    Console.WriteLine();
                    if (Int32.TryParse(InputMonth, out validatedNumber))
                    {
                        m[i].months = validatedNumber;
                        if (m[i].months > 0 && m[i].months < 61)
                        {
                            monthValid = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Number of Months entered. Please try between 1 AND 60...");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You must enter numbers.");
                    }
                }

                // validation to avoid invalid answers.
                while (specialValid == false)
                {
                    Console.Write("Enter yes or no to indicate a special offer : ");

                    string answer = Console.ReadLine();
                    Console.WriteLine();
                    if (answer.Equals("yes", StringComparison.OrdinalIgnoreCase) || answer.Equals("no", StringComparison.OrdinalIgnoreCase))
                    {
                        m[i].CalculateRate(m[i].months);
                        m[i].CalculateTotal(m[i].rate, m[i].months);
                        m[i].CalculateSpecialOffer(answer);
                        specialValid = true;
                    }

                    else
                    {
                        Console.WriteLine("Please enter yes or no.");
                    }

                }

                //resetting the validation variations for next member. without it, next member will be valid automatically. so, we reset them to false.
                specialValid = false;
                monthValid = false;
                nameValid = false;

                //total charge will be provided by this app in the end of each member's entry.
                Console.WriteLine("\tThe membership of fee for " + m[i].memberName + " is $" + m[i].totalCharge + "\n---------------------------------------------------------------");
            }

            //once the first for loop ends. It means the user filled all the capacity of the array. the summary
            Console.WriteLine("\t\tSummary of Membership Fee\n===============================================================");

            Console.WriteLine("  Name\t\tMonths\t\tSpecialOffer\t\tCharge\n---------------------------------------------------------------");
            for (int x = 0; x < numberOfMembers; x++)
            {
                Console.WriteLine( m[x].memberName + "\t\t" + m[x].months + "\t\t" + m[x].specialOffer + "\t\t" + "$" + m[x].totalCharge + "\t");
            } 

            // calling member class to find out max paid member and least paid member.
            Member maxPaidMember = new Member();
            Member leastPaidMember = new Member();

            //set first array as the least member otherwise it will remain 0. For maxPaid we do not need to do this.
            leastPaidMember = m[0];

            //for loop, every single member first member automatically becomes a maxpaid as no other maxpaid entry before. 
            //But for loop goes on. So if the second one is bigger value, it will take over the place and become a new maxPaid. It will go on till the last member. Therefore
            //we will find the maxPaid person.

            //for the least paid person as well.
            for (int x = 0; x < numberOfMembers; x++)
            {

                if (m[x].totalCharge > maxPaidMember.totalCharge)
                {
                    maxPaidMember = m[x];

                }
                if (m[x].totalCharge < leastPaidMember.totalCharge)
                {
                    leastPaidMember = m[x];

                }

            }

            //how many customers are less or more than 6 months. each member with for loop
            // epending on their months value, add "x" to lessthan6Months or over6Months string variables.
            Console.WriteLine("\n\n---------------------------------------------------------------\n\nThe customer spending most is " + maxPaidMember.memberName + " with $" + maxPaidMember.totalCharge);
            Console.WriteLine("\nThe customer spending least is " + leastPaidMember.memberName + " with $" + leastPaidMember.totalCharge+"\n");
            for (int y = 0; y < numberOfMembers; y++)
            {
                if (m[y].months <= 6)
                {
                    lessor6Months += "x";
                }
                else if (m[y].months > 6)
                {
                    over6Months += "x";
                }
            }
            Console.WriteLine("  The number of member with <= 6 months: " + lessor6Months);
            Console.WriteLine("  The number of member with > 6 months: " + over6Months);

        }
    }
}




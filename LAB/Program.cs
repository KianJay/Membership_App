using System;


namespace LAB
{
    // Member class that we will keep the member data, there will be 3 variables
    // entered by the user. (memberName, months, AnswerIn and specialOffer.)
    public class Member
    {
        public string memberName { get; set; }
        public int months { get; set; }
        //the value of the specialOffe depending on the user entry at CalculateSpecialOffer method coming from AnswerIn.
        public string specialOffer;
        //the value of totalCharge will be calculated in the method called CalculateTotal()
        public double totalCharge { get; set; }
        //the value of rate will be calculated in the method called CalculateRate()
        public double rate;

        // constructor. as no need to initialize any value at the beginning, no filled the constructor required.
        public Member()
        {

        }

        //calculating the rate with the months that user enter. With the If-else Condition.
        public void CalculateRate(int monthsIn)
        {
            if (monthsIn > 0 && monthsIn <= 6)
            {

                rate = 30.0;
            }
            else if (monthsIn > 6 && monthsIn < 13)
            {

                rate = 27.5;
            }
            else
            {

                rate = 25.0;
            }
        }

        //calculating the total fee. Simple multiplication opereation.
        public void CalculateTotal(double rateIn, int MonthIn)
        {
            totalCharge = rateIn * MonthIn;
        }

        //calculating the specialOffer. If the user enters yes for the answer (case ignored.), the special offer will be applied, which is 15%.
        public void CalculateSpecialOffer(string answerIn)
        {
            if (answerIn.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                totalCharge = totalCharge - (totalCharge * 0.15);
                specialOffer = "Yes";
            }
            else
            {
                specialOffer = "No";
            }

        }
    }
}

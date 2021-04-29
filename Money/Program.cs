# region Using
using System;
using System.Collections.Generic;
#endregion
namespace Money
{
    class Program
    {
        static void Main()
        {
            IEnumerable<IMoney> monies;
            MoneyCalculator moneyCalc = new MoneyCalculator();
            IMoney max;


            // Initializaton of Test Data - 1
            //Money[] moneyList = new Money[]
            //{
            //    new Money(10, "GBP"),
            //    new Money(20, "GBP"),
            //    new Money(30, "GBP")
            //};

            // Initializaton of Test Data - 2
            Money[] moneyList = new Money[]
            {
                new Money(10, "GBP"),
                new Money(20, "GBP"),
                new Money(30, "EUR")
            };
            //Find the maximum amount
            try
            {

                monies = moneyCalc.GetMoneyEnumList(moneyList);
                Console.WriteLine(moneyCalc.ShowMoneyList("Current List: {", monies));
                max = moneyCalc.Max(monies);
                Console.WriteLine(moneyCalc.ShowMoneyList("Max Amount: {", max));
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine(nre.Message);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            // Find the sum per currency
            try
            {
                monies = moneyCalc.SumPerCurrency(moneyList);
                Console.WriteLine(moneyCalc.ShowMoneyList("Sum Per Currency: {", monies));
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine(nre.Message);
            }
        }
    }
}

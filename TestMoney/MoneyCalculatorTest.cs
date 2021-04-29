#region Using
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Money;
using System;
using System.Collections.Generic;

#endregion


namespace TestMoney
{
    [TestClass]
    public class MoneyCalculatorTest
    {
        #region Test Cases for Max Method
        [TestMethod]
        public void MaxSuccessful()
        {
            IEnumerable<IMoney> monies;
            MoneyCalculator moneyCalc = new MoneyCalculator();
            IMoney max;

            Money.Money[] moneyList = new Money.Money[]
            {
                new Money.Money(10, "GBP"),
                new Money.Money(20, "GBP"),
                new Money.Money(30, "GBP")
            };

            monies = moneyCalc.GetMoneyEnumList(moneyList);
            Console.WriteLine(moneyCalc.ShowMoneyList("Current List: {", monies));
            max = moneyCalc.Max(monies);
            Console.WriteLine(moneyCalc.ShowMoneyList("Max Amount: {", max));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "All monies are not in the same currency.")]
        public void MaxFailArgsException()
        {
            IEnumerable<IMoney> monies;
            MoneyCalculator moneyCalc = new MoneyCalculator();
            IMoney max;

            Money.Money[] moneyList = new Money.Money[]
            {
                new Money.Money(10, "GBP"),
                new Money.Money(20, "EUR"),
                new Money.Money(30, "GBP")
            };

            monies = moneyCalc.GetMoneyEnumList(moneyList);
            Console.WriteLine(moneyCalc.ShowMoneyList("Current List: {", monies));
            max = moneyCalc.Max(monies);
            Console.WriteLine(moneyCalc.ShowMoneyList("Max Amount: {", max));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Empty Money List")]
        public void MaxFailNullRefException()
        {
            IEnumerable<IMoney> monies;
            MoneyCalculator moneyCalc = new MoneyCalculator();
            IMoney max;

            Money.Money[] moneyList = null;

            monies = moneyCalc.GetMoneyEnumList(moneyList);
            Console.WriteLine(moneyCalc.ShowMoneyList("Current List: {", monies));
            max = moneyCalc.Max(monies);
            Console.WriteLine(moneyCalc.ShowMoneyList("Max Amount: {", max));
        }
        #endregion

        #region Test Cases for SumPerCurrency Method
        [TestMethod]
        public void SumPerCurrencySuccessful1()
        {
            IEnumerable<IMoney> monies;
            MoneyCalculator moneyCalc = new MoneyCalculator();
            Money.Money[] moneyList = new Money.Money[]
           {
                new Money.Money(10, "GBP"),
                new Money.Money(20, "GBP"),
                new Money.Money(30, "GBP")
           };

            monies = moneyCalc.GetMoneyEnumList(moneyList);
            Console.WriteLine(moneyCalc.ShowMoneyList("Current List: {", monies));
            monies = moneyCalc.SumPerCurrency(moneyList);
            Console.WriteLine(moneyCalc.ShowMoneyList("Sum Per Currency: {", monies));

        }

        [TestMethod]
        public void SumPerCurrencySuccessful2()
        {
            IEnumerable<IMoney> monies;
            MoneyCalculator moneyCalc = new MoneyCalculator();
            Money.Money[] moneyList = new Money.Money[]
           {
                new Money.Money(10, "GBP"),
                new Money.Money(20, "GBP"),
                new Money.Money(30, "EUR")
           };

            monies = moneyCalc.GetMoneyEnumList(moneyList);
            Console.WriteLine(moneyCalc.ShowMoneyList("Current List: {", monies));
            monies = moneyCalc.SumPerCurrency(moneyList);
            Console.WriteLine(moneyCalc.ShowMoneyList("Sum Per Currency: {", monies));
        }


        [TestMethod]
        public void SumPerCurrencySuccessful3()
        {
            IEnumerable<IMoney> monies;
            MoneyCalculator moneyCalc = new MoneyCalculator();
            Money.Money[] moneyList = new Money.Money[]
           {
                new Money.Money(10, "GBP"),
                new Money.Money(20, "GBP"),
                new Money.Money(30, "EUR"),
                new Money.Money(50, "EUR"),
                new Money.Money(100, "USD")
           };

            monies = moneyCalc.GetMoneyEnumList(moneyList);
            Console.WriteLine(moneyCalc.ShowMoneyList("Current List: {", monies));
            monies = moneyCalc.SumPerCurrency(moneyList);
            Console.WriteLine(moneyCalc.ShowMoneyList("Sum Per Currency: {", monies));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Empty Money List")]
        public void SumPerCurrencyFailNullRefException()
        {
            IEnumerable<IMoney> monies;
            MoneyCalculator moneyCalc = new MoneyCalculator();
            // Failing Condition
            // Money.Money[] moneyList = new Money.Money[]
            //{
            //     new Money.Money(10, "GBP"),
            //     new Money.Money(20, "GBP"),
            //     new Money.Money(30, "EUR")
            //};
            Money.Money[] moneyList = null;
            monies = moneyCalc.GetMoneyEnumList(moneyList);
            Console.WriteLine(moneyCalc.ShowMoneyList("Current List: {", monies));
            monies = moneyCalc.SumPerCurrency(moneyList);
            Console.WriteLine(moneyCalc.ShowMoneyList("Sum Per Currency: {", monies));
        }
        #endregion
    }
}

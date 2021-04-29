#region Using
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

#endregion

namespace Money
{

    /// <summary>
    /// Doing some calculations with Money
    /// </summary>
    public class  MoneyCalculator :IMoneyCalculator
    {
        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MoneyCalculator()
        {

        }
        #endregion

        #region Functions
        /// <summary>
        /// Returns the IEnumerable Money List that needs to be passed to the Interface Methods
        /// </summary>
        /// <param name="monies"></param>
        /// <returns>IEnumerable<IMoney></returns>
        public IEnumerable<IMoney> GetMoneyEnumList(Money [] monies)
        {
            return monies;
        }

        /// <summary>
        /// Show the money list values
        /// </summary>
        /// <param name="message"></param>
        /// <param name="moneyEnum"></param>
        /// <returns>string</returns>
        /// <example> Current List: {GBP10, GBP20, GBP50} </example>
        /// <example> Maximum Amount: {GBP50} </example>
        /// <example> Sum Per Currency: {GBP10, EUR20, USD50} </example>
        public string ShowMoneyList(string message, IEnumerable<IMoney> moneyEnum)
        {
            StringBuilder msg = new StringBuilder();
            msg.Append(message);
            foreach (var obj in moneyEnum)
            {
                msg.Append(obj.Currency);
                msg.Append(" ");
                msg.Append(obj.Amount);
                msg.Append(", ");
            }
            msg.Remove(msg.ToString().LastIndexOf(','), 2); // To remove the extra comma from the list
            msg.Append("}");
            return msg.ToString();
        }

        /// <summary>
        /// Show the Max Money Value
        /// </summary>
        /// <param name="message"></param>
        /// <param name="money"></param>
        /// <returns>string</returns>
        /// <example> Maximum Amount: {GBP50} </example>
        public string ShowMoneyList(string message, IMoney money)
        {
            StringBuilder msg = new StringBuilder();
            msg.Append(message);
            msg.Append(money.Currency);
            msg.Append(" ");
            msg.Append(money.Amount);
            msg.Append("}");
            return msg.ToString();
        }

        #endregion

        #region Implements Interface Methods

        /// <summary>
        /// Find the largest amount of money.
        /// </summary>
        /// <returns>The <see cref="IMoney"/> instance having the largest amount.</returns>
        /// <exception cref="ArgumentException">All monies are not in the same currency.</exception>
        /// <example>{GBP10, GBP20, GBP50} => {GBP50}</example>
        /// <example>{GBP10, GBP20, EUR50} => exception</example>
        public IMoney Max(IEnumerable<IMoney> monies)
        {
            IMoney maxAmount = new Money();
           if (monies != null && monies.Count() >0)
            {
                // Checks if all the money objects are of the same currency
                IEnumerable <string> distinctCurrency =   monies.Select(a => a.Currency.ToUpper()).Distinct();

                if (distinctCurrency.Count() > 1)
                {
                    throw new ArgumentException("All monies are not in the same currency.");
                }
                else
                {
                    maxAmount = new Money(monies.Max(a => a.Amount), monies.Select(a => a.Currency.ToUpper()).Distinct().FirstOrDefault());
                }                    
            }
           else
            {
                throw new NullReferenceException("Empty Money List");
            }
            return maxAmount;
        }

        /// <summary>
        /// Return one <see cref="IMoney"/> per currency with the sum of all monies of the same currency.
        /// </summary>
        /// <example>{GBP10, GBP20, GBP50} => {GBP80}</example>
        /// <example>{GBP10, GBP20, EUR50} => {GBP30, EUR50}</example>
        /// <example>{GBP10, USD20, EUR50} => {GBP10, USD20, EUR50}</example>
        public IEnumerable<IMoney> SumPerCurrency(IEnumerable<IMoney> monies)
        {
            List<Money> result;
            if (monies != null && monies.Count()>0)
            {
                result = monies
               .GroupBy(a => a.Currency)
               .Select(o => new Money
               {
                   Currency = o.First().Currency,
                   Amount = o.Sum(c => c.Amount)
               }).ToList<Money>();
            }
            else
            {
                throw new NullReferenceException("Empty Money List");
            }
            return (IEnumerable < IMoney >) result;
        }
        #endregion
    }
}

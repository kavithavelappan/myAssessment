#region Using
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
#endregion

namespace Money
{
    /// <summary>
    /// An amount of money in a particular currency.
    /// </summary>
    public class Money : IMoney
    {
        #region Private Members
        decimal _amount =0;
        string _currency = null;
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Money()
        {
            _amount = 0;
            _currency = null;
        }


        /// <summary>
        /// Constructor accepting values
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        public Money(decimal amount, string currency)
        {
            _amount = amount;
            _currency = currency;
        }
        #endregion

        #region Implement Interface Properties
        /// <summary>
        /// The amount of money this instance represents.
        /// </summary>
        public decimal Amount 
        { 
            get => _amount; 
            set => _amount = value;
        }

        /// <summary>
        /// The ISO currency code of this instance.
        /// </summary>
        public string Currency
        {
            get => _currency;
            set => _currency = value;
        }
        #endregion
    }
}

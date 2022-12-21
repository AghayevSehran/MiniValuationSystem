using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniValuationSystem.Models
{
    public class Valuation:Transaction
    {
        public double Value { get; set; }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder
                .Append("Ticker = ")
                .Append(Ticker)
                .Append(" TradeType = ")
                .Append(TradeType)
                .Append(" TradeId =")
                .Append(TradeId)
                .Append(" CalcEstimate = ")
                .Append(CalcEstimate)
                .Append(" Value = ")
                .Append(Value)
                .Append(" Quantity = ")
                .AppendLine(Quantity.ToString());
            return stringBuilder.ToString(); 
        }
    }
}

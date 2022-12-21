namespace MiniValuationSystem.Models;

public class Transaction
{
    public string Ticker { get; set; }
    public int TradeId { get; set; }
    public string Counterparty { get; set; }
    public double Quantity { get; set; }
    public double CalcEstimate { get; set; }
    public string TradeType { get; set; }
}

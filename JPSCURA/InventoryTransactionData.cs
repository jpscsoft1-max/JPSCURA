namespace JPSCURA
{
    public class InventoryTransactionData
    {
        public DateTime Date { get; set; }
        public string Particular { get; set; }

        public decimal Receipt { get; set; }
        public decimal Issued { get; set; }

        public decimal Rate { get; set; }
    }
}

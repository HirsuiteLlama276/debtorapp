namespace DebtorCore
{
    public class Borrower
    {
        public string Name { get; set; }
        public decimal Money { get; set; }

        public override string ToString()
        {
            return Name + ";" + Money.ToString();
        }
    }
}

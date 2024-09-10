namespace TerminalMonitoringSolution.Models
{
    public class Enums
    {
        public enum StatusEnum
        {
            Inactive,
            Active
        }

        public enum SignalEnum
        {
            Bad,
            Good,
            Excellent
        }

        public enum CustodianType
        {
            Agent,
            Merchant
        }

        public enum GenderEnum
        {
            NA,
            Male,
            Female,
        }

        public enum TxnSearchEnum
        {
            TransactionReference,
            TerminalId,
            DateLogged,
        }
    }
}
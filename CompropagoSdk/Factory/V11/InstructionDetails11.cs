
using CompropagoSdk.Factory.Abs;

namespace CompropagoSdk.Factory.V11
{
    class InstructionDetails11 : InstructionDetails
    {
        public string amount { get; set; }
        public string store { get; set; }
        public string bank_account_number { get; set; }
        public string bank_name { get; set; }

        public override string getAmount()
        {
            return amount;
        }

        public override string getBankAccountNumber()
        {
            return bank_account_number;
        }

        public override string getBankName()
        {
            return bank_name;
        }

        public override string getStore()
        {
            return store;
        }
    }
}

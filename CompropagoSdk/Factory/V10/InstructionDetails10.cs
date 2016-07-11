using System;
using CompropagoSdk.Factory.Abs;

namespace CompropagoSdk.Factory.V10
{
    class InstructionDetails10 : InstructionDetails
    {
        public string payment_amount { get; set; }
        public string payment_store { get; set; }
        public string bank_account_number { get; set; }
        public string bank_name { get; set; }

        public override string getAmount()
        {
            return payment_amount;
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
            return payment_store;
        }
    }
}

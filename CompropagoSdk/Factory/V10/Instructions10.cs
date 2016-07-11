using CompropagoSdk.Factory.Abs;

namespace CompropagoSdk.Factory.V10
{
    class Instructions10 : Instructions
    {
        public string description { get; set; }
        public string step1 { get; set; }
        public string step2 { get; set; }
        public string step3 { get; set; }
        public string note_extra_comition { get; set; }
        public string note_expiration_date { get; set; }
        public string note_confirmation { get; set; }
        public InstructionDetails10 details { get; set; }

        public override string getDescription()
        {
            return description;
        }

        public override InstructionDetails getDetails()
        {
            return details;
        }

        public override string getNoteConfirmation()
        {
            return note_confirmation;
        }

        public override string getNoteExpirationDate()
        {
            return note_expiration_date;
        }

        public override string getNoteExtraComition()
        {
            return note_extra_comition;
        }

        public override string getStep1()
        {
            return step1;
        }

        public override string getStep2()
        {
            return step2;
        }

        public override string getStep3()
        {
            return step3;
        }
    }
}


namespace CompropagoSdk.Factory.Abs
{
    public abstract class Instructions
    {
        public abstract string getDescription();
        public abstract string getStep1();
        public abstract string getStep2();
        public abstract string getStep3();
        public abstract string getNoteExtraComition();
        public abstract string getNoteExpirationDate();
        public abstract string getNoteConfirmation();
        public abstract InstructionDetails getDetails(); 
    }
}

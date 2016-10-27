
namespace CompropagoSdk.Models
{
    public class Instructions
    {
        public string description { get; set; }
        public string step1 { get; set; }
        public string step2 { get; set; }
        public string step3 { get; set; }
        public string note_extra_comition { get; set; }
        public string note_expiration_date { get; set; }
        public string note_confirmation { get; set; }
        public InstructionDetails details { get; set; }
    }
}

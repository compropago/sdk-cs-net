namespace CompropagoSdk
{
    public class Client
    {
        public static string Version = "3.0.3";

        public static string ApiLiveUri = "https://api.compropago.com/v1/";
        public static string ApiSandboxUri = "https://api.compropago.com/v1/";

        private readonly string _publicKey;
        private readonly string _privateKey;

        public bool Live { get; set; }

        public string DeployUri { get; set; }

        public Service Api { get; set; }

        public Client(string publicKey, string privateKey, bool live)
        {
            _publicKey = publicKey;
            _privateKey = privateKey;
            Live = live;

            DeployUri = live ? ApiLiveUri : ApiSandboxUri;

            Api = new Service(this);
        }

        public string GetUser()
        {
            return _privateKey;
        }

        public string GetPass()
        {
            return _publicKey;
        }
    }
}
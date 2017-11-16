namespace CompropagoSdk
{
    public class Client
    {
        public static string Version = "3.0.3.2";

        public static string ApiLiveUri = "https://api.compropago.com/v1/";
        public static string ApiSandboxUri = "https://api.compropago.com/v1/";

        private readonly string _publicKey;
        private readonly string _privateKey;

        public bool Live { get; set; }

        public string DeployUri { get; set; }

        public Service Api { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CompropagoSdk.Client"/> class.
        /// </summary>
        /// <param name="publicKey">Public key.</param>
        /// <param name="privateKey">Private key.</param>
        /// <param name="live">If set to <c>true</c> live.</param>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public Client(string publicKey, string privateKey, bool live)
        {
            _publicKey = publicKey;
            _privateKey = privateKey;
            Live = live;

            DeployUri = live ? ApiLiveUri : ApiSandboxUri;

            Api = new Service(this);
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <returns>The user.</returns>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public string GetUser()
        {
            return _privateKey;
        }

        /// <summary>
        /// Gets the pass.
        /// </summary>
        /// <returns>The pass.</returns>
        /// 
        /// <remarks>
        /// Author: Eduardo Aguilar <dante.aguilar41@gmail.com>.
        /// </remarks>
        public string GetPass()
        {
            return _publicKey;
        }
    }
}
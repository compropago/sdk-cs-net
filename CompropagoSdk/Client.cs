
namespace CompropagoSdk
{
    class Client
    {
        private static string VERSION = "2.0.2";

        private static string API_LIVE_URI = "http://api.compropago.com/v1/";
        private static string API_SANDBOX_URI = "http://api.compropago.com/v1/";

        private string publickey { get; }
        private string privatekey { get; }
        private bool live { get; }
        private string contained { get; }
        private string deployUri { get; }

        public Service api { get; set; }


        /**
         * @param string publickey     Llave publica correspondiente al modo de la tienda
         * @param string privatekey    Llave privada correspondiente al modo de la tienda
         * @param bool   live          Modo de la tienda (false = Test | true = Live)
         * @param string contained     (optional) App User agent
         */ 
        public Client(string publickey, string privatekey, bool live, string contained = null)
        {
            this.publickey  = publickey;
            this.privatekey = privatekey;
            this.live       = live;

            this.contained  = (contained != null) ? contained : "SDK; cs-sdk "+VERSION;
            this.deployUri  = live ? API_LIVE_URI : API_SANDBOX_URI;

            this.api = new Service(this);
        }

        public string getAuth()
        {
            return this.privatekey + ":";
        }

        public string getFullAuth()
        {
            return this.privatekey + ":" + this.publickey;
        }

        public bool getMode()
        {
            return this.live;
        }

        public string getUri()
        {
            return this.deployUri;
        }

        public string getContained()
        {
            return this.contained;
        }
    }
}

/**
 * @author Eduardo Aguilar <eduardo.aguilar@compropago.com>
 **/
namespace Compropago.Sdk
{
    /**
     * Cliente de servicios de ComproPago
     * 
     * @var version         string
     * @var apiLiveUri      string
     * @var apiSandboxUri   string
     * @var ssl             string 
     * @var deployUri       string
     * @var deployMode      bool
     * @var auth            Compropago.Sdk.Config
     * 
     * @method getAuth        string
     * @method getFullAuth    string
     * @method getVersion     string
     * @method getSsl         string
     * @method getMode        bool
     * @method getUri         string
     * 
     * @construct Compropago.Sdk.Config
     **/
    public class Client
    {
        public const string version = "1.0.0";
        private const string apiLiveUri = "api.compropago.com/v1/";
        private const string apiSandboxUri = "api.compropago.com/v1/";
        private const string ssl = "http://";

        public string deployUri { get; }
        public bool deployMode { get; }

        private Config auth { get; }

        public Client(Config config)
        {
            this.auth = config;

            if (config.live)
            {
                this.deployMode = true;
                this.deployUri = apiLiveUri;
            }
            else
            {
                this.deployMode = false;
                this.deployUri = apiSandboxUri;
            }
        }

        /**
         * Retorna un string de autentificacion debil
         * @return string
         **/
        public string getAuth()
        {
            return this.auth.privatekey;
        }

        /**
         * Retorna un string de autentificacion fuerte
         * @ return string
         */
        public string getFullAuth()
        {
            return this.auth.privatekey + ":" + this.auth.publickey;
        }

        /**
         * Retorna la version actual del SDK
         * @ return string
         */
        public string getVersion()
        {
            return version;
        }

        /**
         * Regresa la cabecera http por defecto
         * @ return string
         */
        public string getSsl()
        {
            return ssl;
        }

        /**
         * Regresa el modo de ejecucion
         * @ return string
         */
        public bool getMode()
        {
            return deployMode;
        }

        /**
         * Regresa la url que se usara para generar las transacciones
         * @ return string
         */
        public string getUri()
        {
            return deployUri;
        }
    }
}

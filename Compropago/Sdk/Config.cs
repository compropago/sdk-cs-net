/**
 * @author Eduardo Aguilar <eduardo.aguilar@compropago.com>
 **/


namespace Compropago.Sdk
{
    /**
     * Clase de configuración para los servicios de ComproPago
     * 
     * @var string publickey    Llave publica de ComproPago
     * @var string privatekey   Llave privada de ComproPago
     * @var bool   live         Modo activo o pruebas (activo = true)
     * @var string contained    Headers for compropago (opcional)
     **/
    public class Config
    {
        public string publickey { get; }
        public string privatekey { get; }
        public bool live { get; }
        public string contained { get; }

        public Config(string publickey, string privatekey, bool live, string contained = null)
        {
            this.publickey = publickey;
            this.privatekey = privatekey;
            this.live = live;
            this.contained = contained;
        }

    }
}


# ComproPago SDK C#.NET v2.0.2

## Descripción

La librería de `ComproPago SDK C#.NET` te permite interactuar con el API de ComproPago en tu aplicación.
También cuenta con los métodos necesarios para facilitar el desarrollo por medio de los servicios
más utilizados (SDK).

Con ComproPago puede recibir pagos en OXXO, 7Eleven y más tiendas en todo México.

[Registrarse en ComproPago](https://compropago.com)

## Índice de Contenidos

- [Ayuda y soporte de ComproPago](#ayuda-y-soporte-de-compropago)
- [Requerimientos](#requerimientos)
- [Instalación ComproPago SDK](#instalación-compropago-sdk)
- [Documentación](#documentación)
- [Guía básica de Uso](#guía-básica-de-uso)
- [Guía de versiones](#guía-de-versiones)


## Ayuda y Soporte de ComproPago

- [Centro de ayuda y soporte](https://compropago.com/ayuda-y-soporte)
- [Solicitar Integración](https://compropago.com/integracion)
- [Guía para Empezar a usar ComproPago](https://compropago.com/ayuda-y-soporte/como-comenzar-a-usar-compropago)
- [Información de Contacto](https://compropago.com/contacto)

## Requerimientos

* NET framework 4.x

### Referencias

* Microsoft.CSharp
* System
* System.Core
* System.Data
* System.Data.DataSetExtensions
* System.Net.Http
* System.Web
* System.Web.Extensions
* System.Xml
* System.Xml.Linq


## Instalación ComproPago SDK C#.NET

### Instalación por GitHub

Puedes descargar alguna de las versiones que hemos publicado:

- [Consultar Versiones Publicadas en GitHub](https://github.com/compropago/compropago-php/releases)

O si o lo deseas puedes obtener el repositorio

```bash
#repositorio en su estado actual (*puede no ser versón estable*)
git clone https://github.com/compropago/sdk-cs-net.git
```

Para poder hacer uso de la librería es necesario que incluyas **Todos** los archivos contenidos en la carpeta
**CompropagoSdk** en su proyecto.

## Documentación

### Documentación ComproPago SDK C#.NET ComproPago

### Documentación de ComproPago

**[API de ComproPago](https://compropago.com/documentacion/api)**

ComproPago te ofrece un API tipo REST para integrar pagos en efectivo en tu comercio electrónico o tus aplicaciones.

**[General](https://compropago.com/documentacion)**

Información de Horarios y Comisiones, como Transferir tu dinero y la Seguridad que proporciona ComproPAgo


**[Herramientas](https://compropago.com/documentacion/boton-pago)**

* Botón de pago
* Modo de pruebas/activo
* WebHooks
* Librerías y Plugins
* Shopify

## Guía básica de Uso

Se debe contar con una cuenta activa de ComproPago.

[Registrarse en ComproPago](https://compropago.com)

### General

Para poder hacer uso de la librería es necesario incluir las librerias principales del Sdk

```CSharp
using CompropagoSdk;
using CompropagoSdk.Models;
using CompropagoSdk.Factory.Abs;
```

Las clase principal del SDK es:

```CSharp
using CompropagoSdk.Client;
```

### Configuración del Cliente

Para poder hacer uso del SDK y llamados al API es necesario que primero configures tus Llaves de conexión y crees
un instancia de Client.
*Sus llaves las encontrara en su Panel de ComproPago en el menú Configuración.*

[Consulte Aquí sus Llaves](https://compropago.com/panel/configuracion)

```CSharp
/**
 * @param string publickey     Llave publica correspondiente al modo de la tienda
 * @param string privatekey    Llave privada correspondiente al modo de la tienda
 * @param bool   live          Modo de la tienda (false = Test | true = Live)
 * @param string contained     (optional) App User agent
 */
var client = new Client(
    "pk_test_xxxxxxxxxxxxxxxxx",  // publickey
    "sk_test_xxxxxxxxxxxxxxxxx",  // privatekey
    false                         // live
);
```

### Uso Básico del SDK

> Consulta la documentación de la librería CS-SDK de ComproPago para conocer más de sus capacidades, configuraciones y métodos.


#### Llamados al los servicios por SDK

Para poder hacer uso de los servicios de ComproPago, solo debes llamar a los métodos contenidos en la propiedad **api**
de la variable **client** como se muestra a continuación.


#### Métodos base del SDK

##### Crear una nueva orden de Pago


```CSharp
/**
 * @param string order_id          Id de la orden
 * @param string order_name        Nombre del producto o productos de la orden
 * @param float  order_price       Monto total de la orden
 * @param string customer_name     Nombre completo del cliente
 * @param string customer_email    Correo electronico del cliente
 * @param string payment_type      (default = OXXO) Valor del atributo internal_name' de un objeto 'Provider'
 * @param string image_url         (optional) Url a la imagen del producto
 */
var order = new PlaceOrderInfo(
    "12",                                // order_id
    "M4 Style",                          // order_name
    1800,                                // order_price
    "Name Lastname",                     // customer_name
    "test@compropago.com",               // customer_email
    "OXXO",                              // payment_type
    "http://cdn.ejemplo.com/image.jpg"   // image_url
);

/**
 * Llamada al metodo 'placeOrder' del API para generar la orden
 */
NewOrderInfo newOrder = client.api.placeOrder(order);
```

###### Prototipo del metodo placeOrder()

```CSharp
/**
 * @param PlaceOrderInfo info   Objeto con la informacion de la orden de compra
 * @return NewOrderInfo
 */
public NewOrderInfo placeOrder(PlaceOrderInfo info);
```

##### Verificar el Estatus de una órden

Para verificar el estatus de una órden generada es necesario llamar al método **verifyOrder** que provee el atributo **api**
del objeto **Client** y el cual regresa una instancia **CpOrderInfo**. Este método recibe como parámetro el ID generado por ComproPago para cada órden. Tambien puede obtener este ID desde un objeto **NewOrderInfo** accediendo al método **getId**.

```CSharp
/**
 * Guardar el ID de la orden
 */
string orderId = "ch_xxxx_xxx_xxx_xxxx";

/**
 * U obtenerlo de un objetdo NewOrderInfo
 */
string orderId = newOrder.getId();


/**
 * Se manda llamar al metodo del API para recuperar la informacion de la orden
 */
CpOrderInfo info = client.api.verifyOrder(orderId);
```

###### Prototipo del metodo verifyOrder()

```CSharp
/**
 * @param string orderId        Id de orden generada por ComproPago
 * @return CpOrderInfo
 */
public CpOrderInfo verifyOrder(string orderId);
```


##### Obtener el listado de las tiendas donde se puede realizar el Pago

Para obtener el listado de Proveedores disponibles para realizar el pago de las ordenes es necesario consutar el metodo
**listProviders** que se encuentra alojado en el atributo **api** del objeto **Client** y el cual regresa una instancia
de tipo **List< Provider >**

```CSharp
var providers = client.api.listProviders();
```

###### Prototipo del metodo listProviders()

```CSharp
/**
 * @param bool  auth  = false   Forzar Autentificación
 * @param float limit = 0       Filtrar por limite de transacción
 * @param bool  fetch = false   Forzar recuperación de proveedores por base de datos
 * @return List<Provider>
 */
public List<Provider> listProviders(bool auth = false, float limit = 0, bool fetch = false);
```

##### Envio de instrucciones SMS

Para realizar el el envio de las instrucciones de compra via SMS es necesario llamar al metodo **sendSmsInstructions** que se
que se encuentra alojado en el atributo **api** del objeto **Client** y el cual regresa una instancia de tipo **SmsInfo**

```CSharp
/**
 * Numero al cual se enviaran las instrucciones
 */
string phoneNumber = "55xxxxxxxx";

/**
 * Id de la orden de compra de cual se enviaran las instrucciones
 */
string orderId = "ch_xxxxx-xxxxx-xxxxx-xxxxx";

/**
 * Llamada al metodo del API para envio de las instrucciones
 */
SmsInfo smsinfo = client.api.sendSmsInstructions(phoneNumber, orderId);
```

###### Prototipo del metodo sendSmsInstructions()

```CSharp
/**
 * @param string number         Numero al que se enviaran las instrucciones (10 digitos)
 * @param string orderId        Id de orden generada por ComproPago
 * @return SmsInfo
 */
public SmsInfo sendSmsInstructions(string number, string orderId);
```

#### Webhooks

Los webhooks son de suma importancia para el proceso las ordenes de ComproPago, ya que estos se encargaran de recibir las notificaciones de el cambio en
los estatus de las ordenes de compra generadas, tambien deberan contener parte de la logica de aprobacion en su tienda en linea. El proceso que siguen
es el siguiente.

1. Cuando una orden cambia su estatus, nuestra plataforma le notificara a cada una de las rutas registradas, dicho cambio con la informacion de la orden
   modificada en formato JSON
2. Debera de recuperar este JSON en una cadena de texto para posterior mente convertirla a un objeto de todpo **CpOrderInfo** haciendo uso de la clase Factory
   que proporciona el SDK de la siguiente forma:

```CSharp
CpOrderInfo info = CompropagoSdk.Factory.Factory.cpOrderInfo( cadenaJson );
```

3. Generar la logica de aprovacion correspondiente al estatus de la orden.

##### Crear un nuevo Webhook

Para crear un nuevo Webhook en la cuenta, se debe de llamar al metodo **createWebhook** que se encuentra alojado en el atributo **api** del objeto **Client**
y el cual regresa una instancia de tipo **Webhook**

```CSharp
/**
 * Se pasa como paramtro la URL al webhook
 */
var webhook = client.api.createWebhook("http://sitio.com/webhook");
```

###### Prototipo del metodo createWebhook()

```CSharp
/**
 * @param string url            Url del webhook a registrar
 * @return Webhook
 */
public Webhook createWebhook(string url);
```

##### Actualizar un Webhook

Para actualizar la url de un webhoo, se debe de llamar al metodo **updateWebhook** que se encuentra alojado en el atributo **api** del objeto **Client**
y el cual regresa una instancia de tipo **Webhook**

```CSharp
var updateWebhook = client.api.updateWebhook(webhookId, newUrl);
```

###### Prototipo del metodo updateWebhook()

```CSharp
/**
 * @param string webhookId       Id del webhook que se desea actualizar
 * @param string url             Url nueva del webhook
 * @return Webhook
 */
public Webhook updateWebhook(string webhookId, string url);
```

##### Eliminar un Webhook

Para eliminar un webhook, se debe de llamar al metodo **deleteWebhook** que se encuentra alojado en el atributo **api** del objeto **Client**
y el cual regresa una instancia de tipo **Webhook**

```CSharp
var updateWebhook = client.api.deleteWebhook(webhookId);
```

###### Prototipo del metodo deleteWebhook()

```CSharp
/**
 * @param string webhookId       Id del webhook registrado
 * @return Webhook
 */
public Webhook deleteWebhook(string webhookId);
```

##### Obtener listado de Webhooks registrados

Para obtener la lista de webhooks registrados den una cuenta, se debe de llamar al metodo **listWebhook** que se encuentra alojado en el atributo **api**
del objeto **Client** y el cual regresa una instancia de tipo **List< Webhook >**

```CSharp
var updateWebhook = client.api.listWebhooks();
```

###### Prototipo del metodo listWebhook()

```CSharp
/**
 * @return List<Webhook>
 */
public List<Webhook> listWebhooks();
```

### Guia de versiones

| Version | Namespace        | Status     | Branch                 |
|---------|------------------|------------|------------------------|
| 1.0.0   | `Compropago.Sdk` | Maintained | [1.0.0][branch-1-0-0]  |
| 2.0.0   | `CompropagoSdk`  | Maintained | [2.0.0][branch-2-0-0]  |
| 2.0.x   | `CompropagoSdk`  | Latest     | [2.0.1][branch-latest] |

[branch-1-0-0]: https://github.com/compropago/sdk-cs-net/tree/1.0.0
[branch-2-0-0]: https://github.com/compropago/sdk-cs-net/tree/2.0.0
[branch-latest]: https://github.com/compropago/sdk-cs-net/

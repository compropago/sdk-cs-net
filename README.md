
# ComproPago SDK C#.NET

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
* Newtonsoft.Json 9.0.1

### Referencias

* Microsoft.CSharp
* Newtonsoft.Json
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

Puede descarga la ultima version estable desde los repositorios de NuGet. El repositorio del SDK es el siguiete:
[https://www.nuget.org/packages/ComproPago/](https://www.nuget.org/packages/ComproPago/). O bien puede instalarlo
desde el Package Manager Console de la siguiente forma:

```bash
PM> Install-Package ComproPago
```

Puede descargar alguna de las versiones que hemos publicado:

- [Consultar Versiones Publicadas en GitHub](https://github.com/compropago/compropago-php/releases)

O si o lo desea puede obtener el repositorio

```bash
#repositorio en su estado actual (*puede no ser versón estable*)
git clone https://github.com/compropago/sdk-cs-net.git
```


## Documentación

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


## Documentación ComproPago SDK C#.NET

Se debe contar con una cuenta activa de ComproPago.

[Registrarse en ComproPago](https://compropago.com)

### General

Para poder hacer uso de la librería es necesario incluir las librerias principales del Sdk

```CSharp
using CompropagoSdk;
using CompropagoSdk.Factory;
```

### Configuración del Cliente

Para poder hacer uso del SDK y llamados al API es necesario que primero configures tus Llaves de conexión y crees
un instancia de Client. *Sus llaves las encontrara en su Panel de ComproPago en el menú Configuración.*

[Consulte Aquí sus Llaves](https://compropago.com/panel/configuracion)

```CSharp
/**
 * @param string publickey     Llave publica correspondiente al modo de la tienda
 * @param string privatekey    Llave privada correspondiente al modo de la tienda
 * @param bool   live          Modo de la tienda (false = Test | true = Live)
 */
var client = new Client(
    "pk_test_xxxxxxxxxxxxxxxxx",  // publickey
    "sk_test_xxxxxxxxxxxxxxxxx",  // privatekey
    false                         // live
);
```

### Uso Básico del SDK

> Consulta la documentación de la librería CS-SDK de ComproPago para conocer más de sus capacidades, configuraciones y 
métodos.


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
 * @param string currency          (default = MXN) Codigo de la moneda con la que se esta creando el cargo
 */
var orderInfo = new Dictionary<string, string>
{
    {"order_id", "123"},
    {"order_name", "M4 sdk CS.NET"},
    {"order_price", "123.45"},
    {"customer_name", "Eduardo"},
    {"customer_email", "eduardo.aguilar@compropago.com"},
    {"payment_type", "OXXO"},
    {"currency", "USD"},
};
/**
 * Creación del objeto PlaceOrderInfo
 */
var order = Factory.PlaceOrderInfo(orderInfo);

/**
 * Llamada al metodo 'PlaceOrder' del API para generar la orden
 */
var newOrder = client.Api.PlaceOrder(order);
```

###### Prototipo del metodo PlaceOrder()

```CSharp
/**
 * @param PlaceOrderInfo info   Objeto con la informacion de la orden de compra
 * @return NewOrderInfo
 */
public NewOrderInfo placeOrder(PlaceOrderInfo info);
```

##### Verificar el Estatus de una órden

Para verificar el estatus de una órden generada es necesario llamar al método **VerifyOrder** que provee el atributo
**Api** del objeto **Client** y el cual regresa una instancia **CpOrderInfo**. Este método recibe como parámetro el ID
generado por ComproPago para cada órden. Tambien puede obtener este ID desde un objeto **NewOrderInfo** accediendo al
atributo **id**.

```CSharp
/**
 * Guardar el ID de la orden
 */
string orderId = "ch_xxxx_xxx_xxx_xxxx";

/**
 * U obtenerlo de un objetdo NewOrderInfo
 */
string orderId = newOrder.id;


/**
 * Se manda llamar al metodo del API para recuperar la informacion de la orden
 */
var info = client.Api.VerifyOrder(orderId);
```

###### Prototipo del metodo VerifyOrder()

```CSharp
/**
 * @param string orderId        Id de orden generada por ComproPago
 * @return CpOrderInfo
 */
public CpOrderInfo verifyOrder(string orderId);
```


##### Obtener el listado de las tiendas donde se puede realizar el Pago

Para obtener el listado de Proveedores disponibles para realizar el pago de las ordenes es necesario consutar el método
**ListProviders** que se encuentra alojado en el atributo **Api** del objeto **Client** y el cual regresa una instancia
de tipo **List<Provider>**

```CSharp
var providers = client.Api.ListProviders();
```

###### Prototipo del metodo listProviders()

```CSharp
/**
 * @param bool  auth  = false   (default = false) Forzar autenficación para obtener proveedores especificos de una tienda
 * @param float limit = 0       (default = 0) limite minimo de transaccion que deberan tener los proveedores a obtener
 * @return List<Provider>
 */
public List<Provider> ListProviders(bool auth = false, double limit = 0);
```

##### Envio de instrucciones SMS

Para realizar el envío de las instrucciones de compra via SMS es necesario llamar al método **sendSmsInstructions** que se
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
var smsinfo = client.Api.SendSmsInstructions(phoneNumber, orderId);
```

###### Prototipo del metodo sendSmsInstructions()

```CSharp
/**
 * @param string number         Numero al que se enviaran las instrucciones (10 digitos)
 * @param string orderId        Id de orden generada por ComproPago
 * @return SmsInfo
 */
public SmsInfo SendSmsInstructions(string number, string orderId);
```

#### Webhooks

Los webhooks son de suma importancia para el proceso de las órdenes de ComproPago, ya que ellos se encargaran de recibir
las notificaciones del cambio en los estatus de las órdenes de compra generadas, tambien deberán contener parte de la 
lógica de aprobación en su tienda en línea. El proceso que siguen es el siguiente.

1. Cuando una órden cambia su estatus, nuestra plataforma le notificará a cada una de las rutas registradas, dicho 
cambio con la información de la orden modificada en formato JSON
2. Deberá recuperar dicho JSON en una cadena de texto para posteriormente convertirla a un objeto de tipo 
**CpOrderInfo** haciendo uso de la clase Factory que proporciona el SDK de la siguiente forma:

```CSharp
CpOrderInfo info = CompropagoSdk.Factory.Factory.cpOrderInfo( cadenaJson );
```

3. Generar la lógica de aprobación correspondiente al estatus de la órden.

##### Crear un nuevo Webhook

Para crear un nuevo Webhook en la cuenta, se debe de llamar al método **CreateWebhook** que se encuentra alojado en el
atributo **Api** del objeto **Client** y el cual regresa una instancia de tipo **Webhook**

```CSharp
/**
 * Se pasa como paramtro la URL al webhook
 */
var webhook = client.Api.CreateWebhook("http://sitio.com/webhook");
```

###### Prototipo del método CreateWebhook()

```CSharp
/**
 * @param string url            Url del webhook a registrar
 * @return Webhook
 */
public Webhook CreateWebhook(string url);
```

##### Actualizar un Webhook

Para actualizar la url de un webhook, se debe de llamar al método **UpdateWebhook** que se encuentra alojado en el 
atributo **Api** del objeto **Client** y el cual regresa una instancia de tipo **Webhook**

```CSharp
var updateWebhook = client.Api.UpdateWebhook(webhookId, newUrl);
```

###### Prototipo del método UpdateWebhook()

```CSharp
/**
 * @param string webhookId       Id del webhook que se desea actualizar
 * @param string url             Url nueva del webhook
 * @return Webhook
 */
public Webhook UpdateWebhook(string webhookId, string url);
```

##### Eliminar un Webhook

Para eliminar un webhook, se debe de llamar al método **DeleteWebhook** que se encuentra alojado en el atributo **Api** 
del objeto **Client** y el cual regresa una instancia de tipo **Webhook**

```CSharp
var updateWebhook = client.Api.DeleteWebhook(webhookId);
```

###### Prototipo del método DeleteWebhook()

```CSharp
/**
 * @param string webhookId       Id del webhook registrado
 * @return Webhook
 */
public Webhook DeleteWebhook(string webhookId);
```

##### Obtener listado de Webhooks registrados

Para obtener la lista de webhooks registrados den una cuenta, se debe de llamar al método **ListWebhook** que se 
encuentra alojado en el atributo **Api** del objeto **Client** y el cual regresa una instancia de tipo 
**List< Webhook >**

```CSharp
var updateWebhook = client.Api.ListWebhooks();
```

###### Prototipo del metodo listWebhook()

```CSharp
/**
 * @return List<Webhook>
 */
public List<Webhook> ListWebhooks();
```

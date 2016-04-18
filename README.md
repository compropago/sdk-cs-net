# ComproPago SDK C#.NET v1.0.0

## Descripción
La librería de `ComproPago SDK C#.NET` le permite interactuar con el API de ComproPago en su aplicación.  
También cuenta con los métodos necesarios para facilitarle su desarrollo por medio de los servicios 
más utilizados (SDK). 

Con ComproPago puede recibir pagos en OXXO, 7Eleven y muchas tiendas más en todo México.

[Registrarse en ComproPago ] (https://compropago.com)

## Índice de Contenidos
- [Ayuda y Soporte de ComproPago] (#ayuda-y-soporte-de-compropago)
- [Requerimientos] (#requerimientos)
- [Instalación ComproPago SDK] (#instalación-compropago-sdk)
- [Documentación] (#documentación)
- [Guía básica de Uso] (#guía-básica-de-uso)
- [Guía de Versiones] (#guía-de-versiones)


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

###Instalación por GitHub

Puede descargar alguna de las versiones que hemos publicado:
- [Consultar Versiones Publicadas en GitHub](https://github.com/compropago/compropago-php/releases)

O si o lo desea puede obtener el repositorio
```bash
#repositorio en su estado actual (*puede no ser versón estable*)
git clone https://github.com/compropago/sdk-cs-net.git
```
Para poder hacer uso de la librería es necesario que incluya **Todos** los archivos contenidos en la carpeta 
**Compropago** en su proyecto.
 
## Documentación
### Documentación ComproPago SDK C#.NET ComproPago

### Documentación de ComproPago
**[API de ComproPago] (https://compropago.com/documentacion/api)**

ComproPago te ofrece un API tipo REST para integrar pagos en efectivo en tu comercio electrónico o tus aplicaciones.


**[General] (https://compropago.com/documentacion)**

Información de Comisiones y Horarios, como Transferir tu dinero y la Seguridad que proporciona ComproPAgo


**[Herramientas] (https://compropago.com/documentacion/boton-pago)**
* Botón de pago
* Modo de pruebas/activo
* WebHooks
* Librerías y Plugins
* Shopify

## Guía básica de Uso
Se debe contar con una cuenta activa de ComproPago. [Registrarse en ComproPago ] (https://compropago.com)

### General

Para poder hacer uso de la librería es necesario incluir las librerias principales del Sdk 
```CSharp
using Compropago.Sdk;
using Compropago.Sdk.JsonStructure;
```
Las tres calses principales del SDK son:
```CSharp
using Compropago.Sdk.Config;  //Configuración de datos de conexión
using Compropago.Sdk.Service; //Llamados al API
using Compropago.Sdk.Client;  //Configuracion para la API
```

### Configuración del Cliente 
Para poder hacer uso del SDK y llamados al API es necesario que primero configure sus Llaves de conexión y crear un instancia de Client.
*Sus llaves las encontrara en su Panel de ComproPago en el menú Configuración.*

[Consulte Aquí sus Llaves] (https://compropago.com/panel/configuracion) 

```CSharp
// Se instancia el objeto de configuracion
Config compropagoConfig = new Config(
    "pk_test_TULLAVEPUBLICA",   //Llave pública
    "sk_test_TULLAVEPRIVADA",   //Llave privada 
    true                        //Esta probando?, utilice  'live'=>false
);

// Instancia del Client
Client compropagoClient = new Client(compropagoConfig);
```
### Uso Básico del SDK

> ###### Consulte la documentación de la librería CS-SDK de ComproPago para conocer más de sus capacidades, configuraciones y métodos. (docs-cs-sdk-link)
 

#### Llamados al los servicios por SDK 
Para utilizar los métodos se necesita tener una instancia de Service. La cual recibe de parámetro el objeto de Client. 
```CSharp
Service compropagoService = new Service(compropagoClient);
```
#### Métodos base del SDK
##### Crear una nueva orden de Pago
```CSharp
// Campos basicos para la creacion de ordenes
PlaceOrderInfo newOrderInfo = new PlaceOrderInfo(
    "testorderid",          // string para identificar la orden 
    123.45,                 // double con el monto de la operación
    "Test Order Name",      // nombre para la orden
    "Compropago Test",      // nombre del cliente
    "test@compropago.com",  // email del cliente
    "OXXO"                  // identificador de la tienda donde realizar el pago (si no se pasa este parametro por defecto se tomara OXXO)
);

//Obtenemos La estructura de la respuesta 
NewOrderInfo neworder = compropagoService.placeOrder(newOrderInfo);
```

##### Verificar el Estatus de una orden

```CSharp
//El número de orden que queremos verificar
string orderId= "ch_xxxxx-xxxxx-xxxxx-xxxxx";

//Obtenemos la estructura de la respuesta 
CompropagoOrderInfo response = compropagoService.verifyOrder( orderId );

```

##### Obtener el listado de las tiendas donde se puede realizar el Pago

```CSharp
//Obtenemos la estructura de la respuesta 
List<Provider> providers = compropagoService.getProviders();
```

##### Envio de instrucciones SMS

```CSharp
// Numero celular del cliente
string phoneNumber = "55xxxxxxxx";
// Numero de orden para las instrucciones
string orderId = "ch_xxxxx-xxxxx-xxxxx-xxxxx";

// Obtenemos la estructura de la respuesta
SmsInfo smsinfo = compropagoService.sendSmsInstructions(phoneNumber, orderId);
```

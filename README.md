# Pagarme SDK para .NET 7

SDK .NET para integração com a API Core v5 da Pagar.me.

## Instalação

Instale o pacote NuGet no seu projeto .NET 7:

```bash
dotnet add package braspin-pagarme-dotnet-sdk --version 7.0.0
```

## Configuração com injeção de dependência

No `Program.cs`:

```csharp
using PagarmeSDK;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPagarMe(
    publicKey: builder.Configuration["Pagarme:PublicKey"],
    secretKey: builder.Configuration["Pagarme:SecretKey"]);

var app = builder.Build();
app.Run();
```

Com `baseUrl` e `userAgent` customizados:

```csharp
builder.Services.AddPagarMe(options =>
{
    options.PublicKey = builder.Configuration["Pagarme:PublicKey"];
    options.SecretKey = builder.Configuration["Pagarme:SecretKey"];
    options.BaseUrl = "https://api.pagar.me/core/v5";
    options.UserAgent = "minha-aplicacao/1.0.0";
});
```

Se `BaseUrl` não for informado, o SDK usa `https://api.pagar.me/core/v5`.
Se `UserAgent` não for informado, o SDK usa `braspin-pagarme-dotnet-sdk 7.0.0`.

## Usando o client

Depois de registrar o SDK, injete `PagarmeClient` onde precisar:

```csharp
using PagarmeSDK;
using PagarmeSDK.Models;

public class CustomerService
{
    private readonly PagarmeClient _pagarme;

    public CustomerService(PagarmeClient pagarme)
    {
        _pagarme = pagarme;
    }

    public GetCustomerResponse CreateCustomer()
    {
        var request = new CreateCustomerRequest
        {
            Name = "Tony Stark",
            Email = "tonystark@avengers.com",
            Type = "individual",
            Document = "93095135270",
            Code = "MY_CUSTOMER_001"
        };

        return _pagarme.Customers.CreateCustomer(request);
    }
}
```

## Uso direto sem DI

```csharp
using PagarmeSDK;

var client = new PagarmeClient(
    publicKey: "sua_public_key",
    secretKey: "sua_secret_key");

var charge = client.Charges.GetCharge("ch_exemplo");
```

## Criar pedido com cartão de crédito

```csharp
using PagarmeSDK;
using PagarmeSDK.Models;

var client = new PagarmeClient("sua_public_key", "sua_secret_key");

var request = new CreateOrderRequest
{
    Customer = new CreateCustomerRequest
    {
        Name = "Tony Stark",
        Email = "tonystark@avengers.com"
    },
    Items = new List<CreateOrderItemRequest>
    {
        new CreateOrderItemRequest
        {
            Amount = 2990,
            Description = "Chaveiro do Tesseract",
            Quantity = 1
        }
    },
    Payments = new List<CreatePaymentRequest>
    {
        new CreatePaymentRequest
        {
            PaymentMethod = "credit_card",
            CreditCard = new CreateCreditCardPaymentRequest
            {
                Card = new CreateCardRequest
                {
                    HolderName = "Tony Stark",
                    Number = "4000000000000010",
                    ExpMonth = 1,
                    ExpYear = 30,
                    Cvv = "123"
                }
            }
        }
    }
};

var response = client.Orders.CreateOrder(request);
```

## Consultar cobrança

```csharp
using PagarmeSDK;

var client = new PagarmeClient("sua_public_key", "sua_secret_key");

var charge = client.Charges.GetCharge("ch_exemplo");
```

## CancellationToken

Todos os métodos assíncronos aceitam `CancellationToken`:

```csharp
using PagarmeSDK;

var client = new PagarmeClient("sua_public_key", "sua_secret_key");

using var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));

var charge = await client.Charges.GetChargeAsync(
    "ch_exemplo",
    cancellationTokenSource.Token);
```

## Tratamento de erros

O SDK lança exceptions específicas por tipo de erro retornado pela API:

```csharp
using PagarmeSDK.Exceptions;

try
{
    var charge = client.Charges.GetCharge("ch_inexistente");
}
catch (PagarmeResourceNotFoundException ex)
{
    Console.WriteLine(ex.ResponseCode);
    Console.WriteLine(ex.Errors);
}
catch (PagarmeException ex)
{
    Console.WriteLine(ex.ResponseCode);
    Console.WriteLine(ex.Errors);
}
```

Principais exceptions:

- `PagarmeInvalidRequestException` para HTTP 400
- `PagarmeInvalidApiKeyException` para HTTP 401
- `PagarmeResourceNotFoundException` para HTTP 404
- `PagarmeBusinessValidationException` para HTTP 412
- `PagarmeContractValidationException` para HTTP 422
- `PagarmeInternalServerErrorException` para HTTP 500

## Mais exemplos

A pasta [examples](examples) contém exemplos para clientes, pedidos, cobranças, cartões, planos, assinaturas e marketplace.

## Publicação no NuGet

O workflow `.github/workflows/publish-nuget.yml` publica versões por target framework:

- `net7.0` deve usar versões `7.0.x`
- `net8.0` deve usar versões `8.0.x`
- `net9.0` deve usar versões `9.0.x`

Para publicar manualmente, execute o workflow no GitHub Actions e informe o target e a versão.

Também é possível publicar via tag:

```bash
git tag v7.0.1
git push origin v7.0.1
```

Uma tag `v8.0.0` publica para `net8.0`, `v9.0.0` publica para `net9.0`, e assim por diante.

# CRUDService - Framework para criar uma API RESTful utilizando Asp.Net Core

 [![Build status](https://souzinha.visualstudio.com/CRUDService/_apis/build/status/CRUDService)](https://souzinha.visualstudio.com/CRUDService/_build/latest?definitionId=7)

## Introdução

O projeto pretende ajudar na criação de uma API RESTful utilizando asp.net core. A proposta é que o desenvolvedor só precise focar no conteúdo e na implementação do serviço deixando com o framework os detalhes necessários para a implementação da API RESTful. 


## Tutorial 

<p align="center" width="100%" style="margin-top:60px">
    <a href="https://youtu.be/ktneQnAzOW4" target="_blank"> <img src="https://img.youtube.com/vi/ktneQnAzOW4/hqdefault.jpg"></a>
</p>

## Modo de Usar

1. Crie um novo projeto asp.net core  

2. Instale o framework no seu projeto asp.net core.  

```powershell
    Install-Package FNS.CRUDService.AspNetCore
```
3. Crie um modelo com o conteúdo da sua api  
```csharp
    public class MinhaEntidade
    {
        [...]
    }
```
4. Crie um serviço que irá implementar a interface IBaseDomainService.

```csharp
    public class MinhaEntidadeServico : IBaseDomainService<MinhaEntidade>
    {
        [...]
    }
```

5. Registre o serviço na classe Startup

```csharp
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            [...]
           services.AddTransient<IBaseDomainService<Modelos.MinhaEntidade>, MinhaEntidadeServico>();
        }
    }
```

5. Crie um controller herdando de CRUDController 

```csharp
    [ApiController]
    [Route("api/[controller]")]
    public class MinhaEntidadeController : CRUDController<MinhaEntidade>
    {
        public MinhaEntidadeController(IBaseDomainService<MinhaEntidade> baseDomainService) : base(baseDomainService)
        {

        }
    }
```
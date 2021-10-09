# CRUDService - A simple CRUD Framework  

 [![Build status](https://souzinha.visualstudio.com/CRUDService/_apis/build/status/CRUDService)](https://souzinha.visualstudio.com/CRUDService/_build/latest?definitionId=7)

## Introdução

O projeto pretende criar um framework simples para criar uma API CRUD (POST, GET, PUT, DELETE) utilizando asp.net core.

## Modo de Usar  

1. Instale o framework no seu projeto asp.net core.  

```powershell
    Install-Package FNS.CRUDService
```
2. Crie um modelo para sua api  
```csharp
    public class MinhaEntidade
    {
        [...]
    }
```
3. Crie um serviço que implemente a interface IBaseDomainService

```csharp
    public class MinhaEntidadeServico : IBaseDomainService<MinhaEntidade>
    {
        [...]
    }
```
4. Faça seu controller herdar de CRUDCOntroller 

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

## Tutorial 


[![Tutorial](https://img.youtube.com/vi/UFCY4Rvv8oQ/hqdefault.jpg)](https://youtu.be/UFCY4Rvv8oQ)
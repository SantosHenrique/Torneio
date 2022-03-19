# Web API .NET 6

A API desenvolvida orinou-se da conclusão de um curso na plataforma desenvolvedor.io. Portanto, objetivou-se, com o desenvolvimento da aplicação, a aplicabilidade de novos conceitos
e prática da tecnologia. Sendo assim, a complexidade do negócio ficou de lado, e a estrutura do banco de dados contêm apenas uma tabela voltada ao negócio; 
as demais são para o controle de acesso, advindas do Identity. Os endpoints permitem as operações básicas (CRUD), além da autenticação por parte do usuário.

## Justificativa

Como mencionado, aprender e praticar conceitos são as principais motivações do desenvolvimento do projeto. Ressalta-se a utilizção do .NET 6, já que o curso disponibiliza até a versão 5, 
até o momento (21/02/21).

## Tecnologias, ferramentas e conceitos

API REST .NET 6, C# 10, SQL Server, Visual Studio 2022 e GIT. Além do REST, Clean Architecture e os princípios SOLID, encontram-se no projeto. Entre os demais recursos utilizados estão: 
Swagger + documentação XML, Identity, EF Core 6, Code First Migrations, Repository Pattern + Unit Of Work, Mapeamento de entidades com o AutoMapper e Record types.  

## Build

Após o clone, o clean e build solution, sempre são bem vindos. Depois disso, necessita-se da string de conexão no appsettings.Development.json. Posto isto, 
atualiza-se o banco (Update-Database).

1. git clone https://github.com/SantosHenrique/dotnet-api-torneio.git
2. Clean e Build Solution
3. "Set as Startup Project" para Torneio.API
4. Ajuste a string de conexão no arquivo appsettings.Development.json (projeto Torneio.API)
5. Update-Database -Context TorneioContext (projeto Torneio.Data)
6. Update-Database -Context TorneioIdentityContext (projeto Torneio.Data)
7. Feito! Basta executar o projeto

## Funcionalidades

Autenticação do usuário e operações básicas (CRUD). 

## Licença

Não se aplica.

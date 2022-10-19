# DEVinCar

Projeto avaliativo **DEVinHouse** desenvolvido com ASP.NET 6 com EntityFramework Core 6, em C#, conectando em base SQL Server.

## Sobre

O projeto desenvolve uma API para vendas de carros. Separados em 3 m�dulos:
1. M�dulo de Cadastro: Respons�vel por manter e gerir o cadastro de usu�rios e produtos; 
2. M�dulo de Vendas: Respons�vel por gerir as vendas de carros e as entregas;
3. M�dulo de Geo-Posicionamento: Respons�vel por gerir o cadastro de cidades, estados e endere�os.


## Como executar

Baixe o projeto para sua m�quina com `git clone https://github.com/DEVin-NDD/M2P2-DEVinCar` ent�o conecte a sua m�quina com um SQL Server local e atualize-o rodando no diret�rio do projeto o comando `dotnet ef database update`. A� voc� ter� o SQL Server atualizado e o projeto est� pronto para ser executado com `dotnet run`. Por padr�o a rota ser�: `https://localhost:7019/` e para acessar o swaggerUI `https://localhost:7019/swagger/index.html`.


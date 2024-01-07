# Backend para compra de produtos 

Esta API Rest consiste de end-points que possibilitam:

#### Cliente
- Cadastrar
- Alterar
- Excluir
- Consultar por Nome

#### Produtos
- Cadastrar
- Alterar
- Excluir
- Consultar por Descrição

#### Compras
- Comprar produto
- Excluir
- Consultar todas as compras
- Consultar por cliente
- Consultar por produto

## Executando a API e banco de dados

### É obrigatório as portas 1433 e 5000 estarem liberadas

1. Fazer pull do projeto
2. Abra um prompt de comando no dirétorio `Infra`
3. Execute o comando `docker-compose build` 
4. Execute o comando `docker-compose up` 
4. Abra um prompt de comando no dirétorio `CMCapital.API`
5. Execute o comando `dotnet ef database update`
6. Cole no navegador o link `http://localhost:5000/swagger/index.html`

## Acesso a base de dados

A base é SQL Server o usuário é `sa` e a senha é `senha@1234` .


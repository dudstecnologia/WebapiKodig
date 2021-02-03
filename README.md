# WebApi - C#, Asp.net Core, Entity Framework

Foi utilizado um banco de dados MySQL, o nome do banco deve ser 'webapi', caso queira utilizar um nome diferente ou queira ver os dados de conexão, basta abrir o arquivo 'appsettings.json'

## Rode as migrations com o comando:
```
dotnet ef database update
```

## Endpoints

### Produtos
VERBO  | URI
------ | ------
GET    | /api/produtos
POST   | /api/produtos
GET    | /api/produtos/{codigo}
PUT    | /api/produtos/{codigo}
DELETE | /api/produtos/{codigo}

### Etiquetas

VERBO  | URI
------ | ------
GET    | /api/etiquetas
POST   | /api/etiquetas
GET    | /api/etiquetas/{codigo}
PUT    | /api/etiquetas/{codigo}
DELETE | /api/etiquetas/{codigo}

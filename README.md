## Cadastro de função e usuário
Você pode criar um cadastro informando um nome de usuário e nome da função.
```csharp
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "O nome deve conter entre 3 e 40 caracteres")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "O perfil é obrigatório")]
    public string RoleName { get; set; }

```
* **Criar, atualizar ou deletar são realizados sem nenhum tipo de autorização** 

* **Leitura é realizado sem nenhum tipo de autorização** 

## Curso
Você pode criar um curso informando um título , a duração do curso e o status.
 ```csharp
    [Required(ErrorMessage = "O título é obrigatório")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "O título do curso deve conter entre 3 e 40 caracteres")]
    public string Title { get; set; }

    [Required(ErrorMessage = "A duração é obrigatório")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "A duração do curso deve conter entre 3 e 40 caracteres")]
    public string Duration { get; set; }

    [Required(ErrorMessage = "O status é obrigatório")]
    [EnumDataType(typeof(EStatus), ErrorMessage = "Digite 1 para Previsto, 2 para Em andamento e 3 para Concluído")]
    public EStatus Status { get; set; }
 ```
* **Criar, atualizar ou deletar são realizados por usuário com função autorizada.**
* **Leitura é realizada sem nenhum tipo de autorização**

# Como usar
* Navegue para o desktop, abra o prompt de cmd e clone o repositório digitando `git clone <url>`
* Abra na sua IDE e digite `dotnet restore` `dotnet clean` `dotnet run`

## Installs

```
dotnet add package Microsoft.EntityframeworkCore.Sqlite

dotnet add package Microsoft.EntityframeworkCore.Design

dotnet add package Microsoft.AspNetCore.Authentication

dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer

```





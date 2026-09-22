# Trabalho de Programação Aplicada em .NET

Repositório desenvolvido para a atividade **Trabalho 1 – Programação Aplicada em .NET**, da disciplina de Programação Aplicada em .NET da **UNIP**.

O trabalho tem como objetivo aplicar conceitos da linguagem **C#** e da plataforma **.NET**, utilizando diferentes recursos apresentados na disciplina.

---

## Informações da Atividade

**Disciplina:** Programação Aplicada em .NET
**Professor:** Prof. Me. Lucas Teodoro dos Santos
**Aluno:** Mateus Antunes
**Tecnologia principal:** C# / .NET
**Tipo de aplicação:** Console
**Entrega:** GitHub

O trabalho é composto por três questões independentes, organizadas em pastas separadas dentro do mesmo repositório.

---

## Repositório

**GitHub:**
https://github.com/Tittozo/Trabalho-Programa-o-Aplicada-.NET

---

# Estrutura do Projeto

O repositório foi organizado separando cada exercício em seu próprio projeto:

```text
Trabalho-Programa-o-Aplicada-.NET
│
├── Questao1-PatternMatching
│   ├── Aluno.cs
│   ├── Professor.cs
│   ├── UsuarioBiblioteca.cs
│   ├── Visitante.cs
│   ├── Program.cs
│   └── Questao1-PatternMatching.csproj
│
├── Questao2-Reflection
│   ├── Equipamento.cs
│   ├── ExibirAttribute.cs
│   ├── Program.cs
│   └── Questao2-Reflection.csproj
│
├── Questao3-DTO
│   ├── Reserva.cs
│   ├── RelatorioReservaDto.cs
│   ├── ReservaMapper.cs
│   ├── Program.cs
│   └── Questao3-DTO.csproj
│
└── README.md
```

Cada questão possui seu próprio projeto Console, facilitando a organização, execução e análise individual de cada exercício.

---

# Questão 1 — Pattern Matching

## Objetivo

A primeira questão trabalha o conceito de **Pattern Matching** em C#, utilizando uma estrutura de usuários de biblioteca.

Foi criada uma classe base chamada `UsuarioBiblioteca` e três classes derivadas:

* `Aluno`
* `Professor`
* `Visitante`

A aplicação verifica, através de Pattern Matching, se determinado usuário pode realizar um empréstimo.

---

## Classe `UsuarioBiblioteca`

A classe `UsuarioBiblioteca` representa a classe base dos usuários.

Ela possui:

```csharp
public string Nome { get; set; }

public int QuantidadeEmprestimosAtivos { get; set; }
```

### Propriedades

**Nome**

Armazena o nome do usuário.

**QuantidadeEmprestimosAtivos**

Armazena a quantidade de empréstimos que o usuário possui atualmente.

---

## Classe `Aluno`

`Aluno` herda de `UsuarioBiblioteca`.

Além das propriedades herdadas, possui:

```csharp
public string Matricula { get; set; }
```

A matrícula identifica o aluno dentro da instituição.

---

## Classe `Professor`

`Professor` também herda de `UsuarioBiblioteca`.

Possui:

```csharp
public string Departamento { get; set; }
```

Essa propriedade identifica o departamento ao qual o professor pertence.

---

## Classe `Visitante`

`Visitante` herda de `UsuarioBiblioteca`.

Possui:

```csharp
public string Documento { get; set; }
```

A propriedade representa o documento do visitante.

---

## Método `VerificarEmprestimo`

A principal parte da questão está no método:

```csharp
public static string VerificarEmprestimo(object obj)
```

O método utiliza uma **switch expression** com **Pattern Matching** para analisar o objeto recebido.

A lógica implementada é:

| Situação                             | Resultado                                     |
| ------------------------------------ | --------------------------------------------- |
| Objeto `null`                        | Usuário inválido                              |
| Aluno com menos de 3 empréstimos     | Empréstimo autorizado para aluno              |
| Aluno com 3 ou mais empréstimos      | Limite de empréstimos atingido para aluno     |
| Professor com menos de 5 empréstimos | Empréstimo autorizado para professor          |
| Professor com 5 ou mais empréstimos  | Limite de empréstimos atingido para professor |
| Visitante                            | Visitantes não podem realizar empréstimos     |
| Outro tipo                           | Usuário não classificado                      |

---

## Recursos de Pattern Matching utilizados

A questão utiliza diferentes padrões da linguagem C#.

### Type Pattern

Permite identificar o tipo do objeto:

```csharp
Visitante => "Visitantes não podem realizar empréstimos"
```

### Property Pattern

Permite analisar uma propriedade do objeto:

```csharp
Aluno { QuantidadeEmprestimosAtivos: < 3 }
```

### Relational Pattern

Permite utilizar operadores relacionais:

```csharp
< 3
```

e:

```csharp
>= 3
```

### Padrão `null`

Identifica quando o objeto recebido é nulo:

```csharp
null => "Usuário inválido"
```

### Padrão `_`

Funciona como uma opção padrão para objetos que não correspondem aos casos anteriores:

```csharp
_ => "Usuário não classificado"
```

---

## Testes realizados

A aplicação foi testada com:

* aluno com limite de empréstimos ultrapassado;
* professor com limite de empréstimos ultrapassado;
* visitante;
* objeto `null`;
* objeto não classificado.

Os resultados retornados corresponderam às regras estabelecidas para a questão.

---

# Questão 2 — Reflection

## Objetivo

A segunda questão trabalha o conceito de **Reflection** em C#.

O programa possui uma classe `Equipamento` e utiliza Reflection para obter informações sobre suas propriedades em tempo de execução.

Foram implementadas duas formas de exibição:

1. Exibição aberta;
2. Exibição controlada.

---

# Classe `ExibirAttribute`

Foi criado um atributo personalizado chamado:

```csharp
ExibirAttribute
```

Ele foi configurado para ser utilizado somente em propriedades:

```csharp
[AttributeUsage(AttributeTargets.Property)]
```

Isso permite marcar quais propriedades devem aparecer na exibição controlada.

---

# Classe `Equipamento`

A classe possui as seguintes propriedades:

```text
Id
Nome
Fabricante
NumeroSerie
Valor
Localizacao
```

Entretanto, apenas algumas propriedades receberam o atributo `[Exibir]`.

Foram marcadas:

```csharp
[Exibir]
public string Nome { get; set; }

[Exibir]
public string Fabricante { get; set; }

[Exibir]
public decimal Valor { get; set; }

[Exibir]
public string Localizacao { get; set; }
```

As propriedades:

```text
Id
NumeroSerie
```

não possuem o atributo `[Exibir]`.

---

# `ExibirDadosAberto`

O método:

```csharp
public static void ExibirDadosAberto(object objeto)
```

utiliza Reflection para obter todas as propriedades públicas do objeto.

São utilizados recursos como:

```csharp
objeto.GetType();
```

para obter o tipo do objeto.

Depois:

```csharp
tipo.GetProperties();
```

para obter suas propriedades.

E:

```csharp
propriedade.GetValue(objeto);
```

para obter o valor de cada propriedade.

Dessa maneira, a exibição aberta apresenta todas as propriedades públicas do equipamento.

---

# `ExibirDadosControlado`

O método:

```csharp
public static void ExibirDadosControlado(object objeto)
```

também utiliza Reflection, porém verifica quais propriedades possuem o atributo `[Exibir]`.

Para isso é utilizado:

```csharp
propriedade.GetCustomAttribute<ExibirAttribute>();
```

Somente quando o atributo é encontrado o valor da propriedade é exibido.

Dessa forma, a exibição controlada apresenta:

```text
Nome
Fabricante
Valor
Localizacao
```

enquanto informações como `Id` e `NumeroSerie` não são exibidas.

---

# Conceitos utilizados na Questão 2

A questão permitiu praticar:

* Reflection;
* `GetType()`;
* `GetProperties()`;
* `GetValue()`;
* atributos personalizados;
* `GetCustomAttribute()`;
* filtragem de propriedades;
* programação dinâmica em C#.

---

# Questão 3 — DTO

## Objetivo

A terceira questão trabalha o conceito de **DTO — Data Transfer Object**.

Foi criada uma entidade `Reserva` contendo informações completas da reserva e um DTO chamado `RelatorioReservaDto`, contendo somente as informações necessárias para apresentação do relatório.

Essa separação evita que informações internas da reserva sejam expostas diretamente.

---

# Classe `Reserva`

A classe `Reserva` representa os dados completos de uma reserva de hotel.

Ela possui:

```text
Id
NomeHospede
NumeroQuarto
QuantidadeDiarias
ValorDiaria
StatusInterno
ObservacaoInterna
```

As informações internas:

```text
StatusInterno
ObservacaoInterna
```

fazem parte da entidade, mas não devem ser apresentadas no relatório.

---

# `RelatorioReservaDto`

Foi criado um `record` chamado:

```csharp
RelatorioReservaDto
```

O DTO possui somente:

```text
NomeHospede
NumeroQuarto
QuantidadeDiarias
ValorTotal
Situacao
```

Dessa maneira, as seguintes informações da entidade `Reserva` não são expostas pelo DTO:

```text
Id
ValorDiaria
StatusInterno
ObservacaoInterna
```

---

# Por que utilizar um DTO?

O DTO permite separar os dados internos da aplicação dos dados que serão apresentados.

Neste projeto:

```text
Reserva
   ↓
Dados completos
   ↓
ReservaMapper
   ↓
RelatorioReservaDto
   ↓
Dados necessários para o relatório
```

Assim, o relatório recebe somente as informações necessárias.

---

# `ReservaMapper`

Foi criada a classe:

```csharp
ReservaMapper
```

Ela possui o método:

```csharp
public static RelatorioReservaDto Mapear(Reserva reserva)
```

Esse método recebe uma `Reserva` e transforma seus dados em um `RelatorioReservaDto`.

---

## Cálculo do valor total

O valor total é calculado através de:

```csharp
decimal valorTotal =
    reserva.QuantidadeDiarias * reserva.ValorDiaria;
```

Por exemplo:

```text
4 diárias × R$ 250,00
=
R$ 1.000,00
```

A situação retornada pelo mapeamento é:

```text
Reserva confirmada
```

---

# Entrada de dados pelo usuário

Como diferencial na implementação, o programa não utiliza somente valores fixos.

O usuário pode informar os dados da reserva diretamente pelo console.

São solicitados:

```text
Nome do hóspede
Número do quarto
Quantidade de diárias
Valor da diária
Status interno
Observação interna
```

O programa também utiliza validação para os valores numéricos através de:

```csharp
int.TryParse()
```

e:

```csharp
decimal.TryParse()
```

Dessa forma, caso o usuário informe um valor inválido, o programa solicita novamente a informação.

---

# Exibição do relatório

Depois que o usuário informa os dados:

```text
Entrada do usuário
        ↓
Criação da Reserva
        ↓
ReservaMapper.Mapear()
        ↓
RelatorioReservaDto
        ↓
ExibirRelatorio()
```

O relatório apresenta:

```text
Nome do hóspede
Número do quarto
Quantidade de diárias
Valor total
Situação
```

As informações internas não aparecem no relatório.

---

# Exemplo de execução

Entrada:

```text
========================================
       SISTEMA DE RESERVA DE HOTEL
========================================

Nome do hóspede: Mateus
Número do quarto: 205
Quantidade de diárias: 4
Valor da diária: R$ 250
Status interno: Confirmada
Observação interna: Quarto silencioso
```

Processamento:

```text
Quantidade de diárias = 4
Valor da diária = R$ 250,00

4 × 250 = R$ 1.000,00
```

Resultado:

```text
========================================
          RELATÓRIO DA RESERVA
========================================
Nome do hóspede: Mateus
Número do quarto: 205
Quantidade de diárias: 4
Valor total: R$ 1000,00
Situação: Reserva confirmada
```

---

# Tecnologias e recursos utilizados

O trabalho utiliza:

* C#
* .NET
* Aplicações Console
* Programação Orientada a Objetos
* Herança
* Pattern Matching
* Switch Expression
* Property Pattern
* Relational Pattern
* Reflection
* Attributes
* `record`
* DTO
* Git
* GitHub

---

# Git e GitHub

O trabalho foi organizado em um único repositório GitHub, contendo uma pasta para cada questão.

Repositório:

https://github.com/Tittozo/Trabalho-Programa-o-Aplicada-.NET

A organização em um único repositório permite acompanhar a evolução de todo o trabalho através do histórico do Git.

---

## Migração para o novo repositório

Inicialmente, a Questão 1 estava sendo desenvolvida separadamente.

Foi criado o repositório:

```text
Tittozo/Trabalho-Programa-o-Aplicada-.NET
```

Depois, o novo repositório foi clonado localmente e as questões foram organizadas dentro dele.

A estrutura passou a ser:

```text
Trabalho-Programa-o-Aplicada-.NET
├── Questao1-PatternMatching
├── Questao2-Reflection
└── Questao3-DTO
```

Foi mantido apenas um repositório Git na raiz do trabalho, evitando repositórios Git aninhados dentro das questões.

---

# Commits realizados

Até o momento, as duas primeiras questões foram adicionadas ao GitHub através do commit:

```text
feat: adiciona questoes 1 e 2
```

Esse commit contém:

```text
Questao1-PatternMatching/
Questão2-Reflection/
```

Posteriormente, a Questão 3 foi desenvolvida localmente e organizada dentro do mesmo repositório.

O próximo commit previsto para registrar essa etapa é:

```text
feat: adiciona questao 3 com dto de reserva
```

---

# Organização do desenvolvimento

O desenvolvimento está sendo realizado de forma incremental.

A sequência utilizada foi:

```text
1. Questão 1
   ↓
2. Testes da Questão 1
   ↓
3. Questão 2
   ↓
4. Testes da Questão 2
   ↓
5. Commit das Questões 1 e 2
   ↓
6. Push para o GitHub
   ↓
7. Questão 3
   ↓
8. Testes da Questão 3
   ↓
9. Commit da Questão 3
```

Essa organização permite acompanhar cada etapa do desenvolvimento através do Git.

---

# Como executar

Cada questão possui seu próprio projeto Console.

Entre na pasta desejada pelo terminal e execute:

```powershell
dotnet run
```

Por exemplo:

```powershell
cd Questao1-PatternMatching
dotnet run
```

ou:

```powershell
cd Questao2-Reflection
dotnet run
```

ou:

```powershell
cd Questao3-DTO
dotnet run
```

---

# Status atual

| Questão   | Tema             | Desenvolvimento |
| --------- | ---------------- | --------------- |
| Questão 1 | Pattern Matching | Concluída       |
| Questão 2 | Reflection       | Concluída       |
| Questão 3 | DTO              | Concluída       |

### Questão 1

Implementação e testes realizados.

### Questão 2

Implementação e testes realizados.

### Questão 3

Implementação realizada, incluindo entrada de dados pelo usuário e cálculo automático do valor total.

---

# Considerações finais

O trabalho reúne diferentes recursos da linguagem C# e da plataforma .NET em aplicações simples de console.

Cada questão foi desenvolvida separadamente, permitindo demonstrar o funcionamento de cada conceito de forma individual:

```text
Questão 1 → Pattern Matching
Questão 2 → Reflection
Questão 3 → DTO
```

Além da implementação dos requisitos, a Questão 3 recebeu uma interação adicional com o usuário, permitindo informar os dados da reserva diretamente pelo console e visualizar o resultado do processamento.

O projeto também utiliza Git e GitHub para controle de versão e acompanhamento da evolução do desenvolvimento.

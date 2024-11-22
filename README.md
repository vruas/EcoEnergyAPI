# EcoEnergy

<p align="center">
  <img src="https://github.com/user-attachments/assets/b7479aa1-dcb1-4c9f-a202-64018a010c66" alt="Golden Data - Logo" width="200"/>
</p>

## Descrição do Projeto
O EcoEnergy é uma solução inovadora que incentiva o consumo responsável de energia, promovendo práticas eficientes 
e o uso de tecnologias renováveis. Através de desafios diários, os usuários são motivados a adotar hábitos que reduzem o 
desperdício de energia, acumulando pontos e sendo recompensados. O sistema de monitoramento analisa o consumo individual
de cada aparelho, fornecendo feedback e dicas para economia de energia. Além disso, oferece conteúdo educativo sobre energias 
renováveis e eficiência energética, capacitando os usuários a tomar decisões conscientes. Com o objetivo de fomentar a transição para fontes 
limpas, o EcoEnergy contribui para um futuro mais sustentável, engajando também a comunidade em ações coletivas.

---

## Integrantes do Projeto

| Nome | Matrícula | Turma |
|------|-----------|-------|
| Gabriel Previ de Oliveira | 98774 | 2TDSPV |
| Gustavo Soares Fosaluza | 97850 | 2TDSPF |
| Mateus Vinicius da Conceição Silva | 551692 | 2TDSPV |
| Pedro Henrique Figueiredo de Oliveira | 552000 | 2TDSPV |
| Vitor da Silva Ruas | 550871 | 2TDSPV |

---

# Projeto Web API .NET Core [ C# ]

## Sistema

A API desenvolvida em .NET atenderá a nossa aplicação mobile EcoEnergy.
## Arquitetura do Sistema

Iniciamos o projeto com uma **arquitetura monolítica** para acelerar o desenvolvimento e validar o produto. No futuro, planeja-se uma **migração para microserviços**, que garantirá escalabilidade e maior flexibilidade para o crescimento da plataforma.

---

## Padrões de Design Utilizados

### Repository Pattern
Utilizado para isolar a lógica de acesso aos dados, facilitando a manutenção e a possibilidade de troca de fontes de dados (como bancos de dados ou APIs externas) sem afetar as demais camadas da aplicação. 

Exemplo: `AppDbContext.cs` gerencia a interação com o banco de dados, e repositórios futuros encapsularão operações CRUD.


### Data Transfer Object (DTO)
Utilizamos DTOs para transferir dados entre camadas de forma segura e eficiente, garantindo integridade e evitando o envio de informações desnecessárias. Exemplo: `CriarUsuarioDto.cs` e `EditarUsuarioDto.cs`.

### Vantagens dos Padrões Utilizados

- **Manutenibilidade**: Separação clara de responsabilidades facilita a manutenção e a expansão de funcionalidades.
- **Testabilidade**: A lógica de negócios isolada facilita a criação de testes unitários e de integração.
- **Escalabilidade**: A estrutura modular permite expandir o sistema com baixo impacto no código existente.

## Princípios Utilizados

### Clean Code

- **Legibilidade**: Nomes descritivos como `ListarDispositivos`, `BuscarDispositivo`, e `CadastrarDispositivo` tornam o código intuitivo.
- **Facilidade de Manutenção**: Métodos com responsabilidade única permitem alterações localizadas.
- **Redução de Erros**: A prática de verificar nulos antes de retornar dados evita exceções.
- **Aumento da Produtividade**: Estrutura clara e organizada facilita a compreensão e o desenvolvimento.
- **Melhor Colaboração**: Interfaces bem definidas promovem trabalho independente entre membros da equipe.

### SOLID

- **Single Responsibility Principle**: Cada método no controller e nos serviços possui uma única responsabilidade.
- **Open/Closed Principle**: O código está aberto a extensões e fechado para modificações, permitindo adicionar novas funcionalidades sem impactar o existente.
- **Liskov Substitution Principle**: O uso de interfaces permite que implementações sejam trocadas sem afetar a lógica do sistema.
- **Interface Segregation Principle**: Interfaces pequenas e focadas garantem que o código seja modular e fácil de entender.
- **Dependency Inversion Principle**: O controller depende de abstrações (interfaces), facilitando a troca de implementações e reduzindo o acoplamento.

## Benefícios

- **Facilidade de Extensão**: Novas funcionalidades podem ser adicionadas sem necessidade de modificar o código existente.
- **Reutilização de Código**: A implementação do padrão de repositório permite que a lógica de acesso a dados seja reutilizada em diferentes partes da aplicação.
- **Flexibilidade e Manutenção**: A separação clara entre camadas promove uma arquitetura que é fácil de modificar.
- **Melhor Testabilidade**: A estrutura modular facilita a criação de testes unitários, aumentando a confiabilidade do sistema.



---

## Guia para Testar a API com Swagger

### Passo 1: Abrir a Interface do Swagger
Após iniciar a API, acesse o **Swagger UI** pelo navegador. A URL será algo como:

https://localhost:7036/swagger/index.html


(O número da porta pode variar conforme o ambiente de execução).

### Passo 2: Explorar os Endpoints
Na interface do **Swagger**, visualize todos os endpoints disponíveis organizados por controladores. Expanda cada endpoint para ver detalhes como método HTTP, parâmetros e respostas.

### Passo 3: Testar um Endpoint
1. Selecione um endpoint e clique para expandir.
2. Preencha os parâmetros necessários.
3. Clique em **Try it out** para enviar uma requisição.
4. O Swagger retorna a resposta, incluindo:
   - **Código de status** (ex.: 200 OK, 404 Not Found).
   - **Corpo da resposta** no formato JSON.
   - **Cabeçalhos da requisição**.

### Passo 4: Revisar a Resposta

- Verifique a resposta retornada e, se necessário, ajuste os parâmetros e tente novamente.
- O **tipo de dados** (string, int, bool, double, etc.) deve ser conferido ao preencher os parâmetros.

--- 

## Machine Learning com ML NET

Utilizando o pacote ML.NET, o modelo de Machine Learning é desenvolvido para prever o valor da conta de luz com base em fatores como histórico de consumo, uso diário de energia, impostos aplicáveis e a quantidade de dias no mês. Para alcançar essa previsão, foi utilizado o algoritmo SDCA (Stochastic Dual Coordinate Ascent), uma abordagem eficiente e escalável para problemas de regressão linear.

## Testes Unitários 

O projeto de testes foi desenvolvido utilizando xUnit e Moq para validar todos os endpoints da API de forma eficiente e confiável. A combinação dessas ferramentas permite testar as funcionalidades sem depender de serviços ou bancos de dados reais, garantindo isolamento e rapidez nos testes.

Estrutura do Projeto
xUnit: Usado como framework de testes, por ser simples, modular e suportar testes parametrizados e de integração.
Moq: Utilizado para criar objetos simulados (mocks), permitindo testar os endpoints isoladamente, simulando cenários reais e controlados.

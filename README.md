# Fluxo de Caixa

Esse projeto demonstra de forma didática, básica e sem fins de produção, um controle simples de Fluxo de Caixa.
Esse controle consiste no lançamento diário de Débitos e Créditos e também na geração de um relatório simples, com os valores consolidados, por dia.
Cada lançamento requer as seguintes informações: Tipo do Lançamento (Crédito ou Débito), Valor, Descrição e Data.

Tecnicamente, optei por utlizar uma abordagem de arquitetura bem simples, somente com o intuito de esboçar a ideia.
Foi criada uma Api única com uma divisão lógica de dois contextos: Lançamentos Financeiros e Relatório Financeiro. Em um cenário real, o ideal é que cada um desses contextos se transforme em um microsserviço.
Para o contexto de Relatório Financeiro, seria interessante definir uma base de dados NOSQL ou Desnormalizada, para garantir performance.
Nessa arquitetura, utilizei algumas ideias básicas do DDD, pensando na independencia do dominio, e também alguns principios do SOLID, como Segeração da Interface.
Optei por não isolar a camada de acesso a Dados, por questões de escopo, mas seria interessante a implementação de um Repostory Pattern e também UoW.
Pela caracteristica do projeto, não implemnentei validações de negocio e nem tratamento de exceções. Em um cenário real, o ideal seria implementar a validação de cada lançamento, para garantir a integridade dos dados e também implementar um tratamento de exceções para um melhor desempenho.

Esse projeto utliza banco de dados em memoria. Sendo assim, todos os dados inseridos na eexeução do projeto, serão perdidos quando o mesmo for abortado.
Para rodar o projeto, basta abrir o mesmo, utilizando o Visual Studio e executar o Build. 
As rotas estão mapeadas e descritas na pagina inicial, com o Swagger.


# Estacionamento Tech

Sistema completo para gestão de estacionamento, desenvolvido em .NET (Framework 4.7.2 e .NET 9), com interface web Razor Pages/MVC e integração com banco de dados MySQL.

## Funcionalidades Principais

- **Cadastro de Clientes:** Gerencie clientes do estacionamento.
- **Cadastro de Veículos:** Associe veículos aos clientes, com informações detalhadas.
- **Histórico de Estacionamentos:** Controle entradas, saídas, valores cobrados, formas de pagamento e status de pagamento.
- **Gestão de Vigências e Tarifas:** Defina períodos de vigência e valores de hora inicial/adicional.
- **Relatórios e Estatísticas:** Média de estacionamentos por cliente, tempo médio de permanência, ranking de clientes, entre outros.
- **Geração de Comprovantes:** Emissão de comprovante de pagamento em formato TXT.

## Estrutura Técnica

- **Backend:** C# (.NET Framework 4.7.2 e .NET 9)
- **Frontend:** Razor Pages/MVC, Bootstrap, jQuery
- **Banco de Dados:** MySQL
- **Arquitetura:** Separação em projetos para dados (`EstacionamentoTech.Data`), modelos (`EstacionamentoTech.Models`), interface web (`EstacionamentoTech.MVC`) e testes unitários.

### Principais Diretórios e Arquivos

- `EstacionamentoTech.Models`: Entidades do sistema (`Cliente`, `Veiculo`, `HistoricoEstacionamentos`, `TabelaValores`).
- `EstacionamentoTech.Data`: Acesso a dados, contexto, utilitários e conexão com MySQL.
- `EstacionamentoTech.MVC`: Controllers, views, validadores, geração de arquivos e filtros de seleção.
- `Estacionamento Tech`: Versão Windows Forms do sistema (legado).

### Banco de Dados

- **Tabelas principais:**
  - `clientes` (Id, Nome)
  - `veiculos` (Id, Cliente, Nome, Ano, Tipo, Placa)
  - `historico_estacionamentos` (Id, Veiculo, Vigencia, Entrada, Saida, ValorCobrado, Pago, FormaPagamento)
  - `tabela_valores` (Id, DataInicio, DataFim, ValorHoraInicial, ValorHoraAdicional)

- **Relacionamentos:**
  - Veículo pertence a um Cliente.
  - Histórico de Estacionamento vinculado a um Veículo e a uma Vigência de valores.

## Como Executar

1. Configure o banco de dados MySQL conforme o arquivo de conexão.
2. Compile e execute o projeto `EstacionamentoTech.MVC`.
3. Acesse via navegador para utilizar a interface web.

## Informações Adicionais

- Código organizado para fácil manutenção e extensibilidade.
- Testes unitários disponíveis em `EstacionamentoTech.TestesUnitarios`.
- Utiliza padrões de validação e filtros para garantir integridade dos dados.

---


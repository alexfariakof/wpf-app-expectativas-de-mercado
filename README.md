# Expectativas de Mercado Mensais fornecidas pelo BACEN

## [IPCA (Índice Nacional de Preços ao Consumidor Amplo)](https://olinda.bcb.gov.br/olinda/servico/Expectativas/versao/v1/odata/ExpectativaMercadoMensais?%24format=json&%24orderby=Data%20desc&%24filter=Indicador%20eq%20'IPCA'&%24top=10000)
O IPCA é o índice oficial de inflação no Brasil, medido pelo Instituto Brasileiro de Geografia e Estatística (IBGE). Ele tem como objetivo medir a variação média de preços de um conjunto de produtos e serviços consumidos pelas famílias com renda mensal entre 1 e 40 salários mínimos.

 * Composição: O IPCA abrange uma cesta de produtos e serviços diversificada, incluindo alimentação, habitação, transporte, saúde, educação, entre outros. A ponderação desses itens reflete os hábitos de consumo da população brasileira.
 * Utilização: O IPCA é amplamente utilizado para reajustar salários, contratos e benefícios governamentais. Ele também serve como referência para a política de metas de inflação estabelecida pelo Banco Central. Manter a inflação dentro das metas é uma das principais responsabilidades do Banco Central para garantir a estabilidade econômica.
 * Cálculo: O IPCA é calculado mensalmente e divulgado pelo IBGE. Ele é obtido a partir da coleta de preços de uma amostra de produtos e serviços em diversas regiões do país.

## [IGP-M (Índice Geral de Preços do Mercado):](https://olinda.bcb.gov.br/olinda/servico/Expectativas/versao/v1/odata/ExpectativaMercadoMensais?%24format=json&%24orderby=Data%20desc&%24filter=Indicador%20eq%20'IGP-M'&%24top=10000)
 O IGP-M é um índice de inflação calculado mensalmente pela Fundação Getulio Vargas (FGV) no Brasil. Ele mede a variação de preços de um conjunto de bens e serviços, abrangendo diferentes setores da economia.

* Composição: O IGP-M é composto por três subíndices:
  
  IPA (Índice de Preços por Atacado): Mede a variação de preços no atacado.
  
  IPC (Índice de Preços ao Consumidor): Avalia a variação de preços para o consumidor final.
  
  INCC (Índice Nacional de Custo da Construção): Acompanha os preços na construção civil.
  
* Utilização: O IGP-M é frequentemente utilizado como referência para contratos de aluguel e reajustes de tarifas públicas, além de ser uma ferramenta para análise de inflação em diferentes setores da economia.

## [Selic (Taxa Selic):](https://olinda.bcb.gov.br/olinda/servico/Expectativas/versao/v1/odata/ExpectativaMercadoMensais?%24format=json&%24orderby=Data%20desc&%24filter=Indicador%20eq%20'Selic'&%24top=10000)
O que é: A Taxa Selic é a taxa básica de juros da economia brasileira. Ela é estabelecida pelo Comitê de Política Monetária (COPOM), que pertence ao Banco Central do Brasil, e é utilizada como referência para diversas operações financeiras no país.

* Composição: A Selic é uma taxa de juros composta por operações de curtíssimo prazo entre instituições financeiras. Ela é ajustada pelo COPOM com base nas condições econômicas do país para controlar a inflação e promover a estabilidade econômica.
  
* Funções: A Selic desempenha um papel fundamental na economia, influenciando as taxas de juros em outros segmentos do mercado financeiro. Além disso, ela é utilizada como referência para o custo do dinheiro no Brasil.


## Model retornado pela API BACEN
```
{
  "@odata.context": "string",
  "value": [
    {
      "Indicador": "string",
      "Data": "string",
      "DataReferencia": "string",
      "Media": 0,
      "Mediana": 0,
      "DesvioPadrao": 0,
      "Minimo": 0,
      "Maximo": 0,
      "numeroRespondentes": 0,
      "baseCalculo": 0
    }
  ]
}
```

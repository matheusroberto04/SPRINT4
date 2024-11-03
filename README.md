#**INTEGRANTES**

98207 - Lucca Rinaldi Valladão de Freitas

98624 - Eduardo Foncesca Finardi

551808 - Ricardo Yuri Gonçalves Domingues

550776 - Angélica Ferreira de Matos Melo

98581 - Matheus Roberto Aparecido de Medeiros Carvalho Pereira de Souza

#**Explicação da arquitetura**

*Monolítica, pois utiliza-se uma abordagem mais simples, além de que existe uma facilidade na manutenção, pois o código esta tudo em um único projeto e também existe uma certa rapidez no desenvolvimento*

#**Explicação da utilização do CLEAN CODE**

*Optei por utilizar o CLEAN CODE, pois essa pratica permite deixar o código limpo e organizado, e permite tambem deixar as frases e linhas de código mais curtas, claras e repetição*

#**Desing Patterns utilizados**

- [ ] Repository Pattern

#**Instruções para rodar a API**

## ENDPOINTS

`GET` /cliente
Listagem de todos os clientes adicionados

`CPF`

`Nome`

`Logradouro`

`Ramo de atuacao`

`Email`

`Senha`

**Códigos de status**

`200` sucesso

`GET` /cliente/{id}

Sistema retorna os detalhes do cliente com o `id` informado.

**Códigos de status**
`200` sucesso

`404` id não encontrado

---

`POST` /cliente

Cadastra um novo cliente
`200` sucesso
`404` id não encontrado

| Campo | Tipo | Obrigatório | Descrição
|-------|------|:-------------:|-----------
|CPF|String|✅|Inserir um CPF para o novo cliente.
|Nome|String|✅|Inserir um nome curto para identificar o novo cliente.
|Logradouro|String|✅|Inserir um endereço.
|Ramo de atuação|String|✅|Inserir o ramo de atuação que o cliente participa.
|Email|String|✅|Adicionar o email.
|Senha|Int|✅|Inserir uma senha.
---
`DELETE` /cliente/{id}

Apaga o cliente através do `id` informado.

**Códigos de status**

`204` Apagado com sucesso

`404` Id não encontrado 

---

`PUT` /cliente/{id} 

Atualiza o cadastro com o `id` informado.

| Campo | Tipo | Obrigatório | Descrição
|-------|------|:-------------:|-----------
|CPF|String|✅|Atualiza o CPF do cliente.
|Nome|String|✅|Atualize o nome do cliente.
|Logradouro|String|✅|Atualiza o endereço.
|Ramo de atuação|String|✅|Atualiza o ramo de atuação do cliente.
|Email|String|✅|Atualiza o email.
|Senha|Int|✅|Atualiza a senha.

**Códigos de status**

`200` Alterado com sucesso.

`404` Id não encontrado.

`400` validação falhou.

---

**Schema**

```js
{
    "clienteId": 1,
    "CPF":"24029345096",
    "nome": "Cleiton Rasta",
    "logradouro": "Rua Cleberson"
    "ramo de atuacao": "games"
    "email": "robeerson@gmail.com"
    "senha": "234"
}
```

### CONSULTORIA

`GET` /consultoria

Lista todas as consultorias

´Consultoria Id´

´Nome da consultoria´

`200` sucesso

---

`GET` /consultoria/{id}

Sistema retorna os detalhes da consultoria com o `id` informado.

**Códigos de status**

`200` sucesso
`404` id não encontrado

---
`POST` /consultoria

Adiciona uma nova consultoria no sistema do Target Customer.

| Campo | Tipo | Obrigatório | Descrição
|-------|------|:-------------:|-----------
|Nome Consultoria|String|✅|Cria uma nova consultoria.

**Códigos de status**

`201` Criado com sucesso
`400` Validação falhou

---

`DELETE` /consultoria/{id}

Apaga a consultoria atraves do `id` informado.

**Códigos de status**

`204` Apagado com sucesso
`404` Id não encontrado 

---

`PUT` /consultoria/{id} 

Altera a consultoria com o `id` informado.

| Campo | Tipo | Obrigatório | Descrição
|-------|------|:-------------:|-----------
|Nome Consultoria|String|✅|Altera o nome da consultoria.

**Códigos de status**

`200` Alterado com sucesso.
`404` Id não encontrado.
`400` validação falhou.

---

**Schema**

```js
{
    "consultoriaId": 1,
    "nomeConsultoria": "Novo game star wars"
}
```





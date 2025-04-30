
# RabbitMQSolution

Este projeto demonstra como implementar um sistema de mensageria com RabbitMQ usando uma solução TRANQUILA, modular composta por três projetos principais: Sender, Validator e Receiver. O objetivo é enviar mensagens de diferentes tipos, validá-las e processá-las em consumidores específicos.

Além disso, o projeto está configurado para ser executado em um ambiente Docker com RabbitMQ, incluindo a interface de gerenciamento.

---

## **Estrutura do Projeto **

A solução é composta pelos seguintes projetos:

```
RabbitMQSolution
├── checkpoint5
│   ├── Program.cs
│   ├── RabbitMQConfig.cs
│   ├── Sender1.cs
│   ├── Sender2.cs
├── checkpoint5-receiver
│   ├── Program.cs
│   ├── RabbitMQConfig.cs
│   ├── Validator.cs
│   ├── Models
│   │   ├── Fruta.cs
│   │   ├── Usuario.cs
├── checkpoint5-validator
│   ├── Program.cs
│   ├── RabbitMQConfig.cs
│   ├── Receiver1.cs
│   ├── Receiver2.cs
```

### **1. checkpoint5 | Sender**
Responsável por enviar mensagens para o RabbitMQ:
- `Sender1`: Envia mensagens relacionadas a frutas da época (`routingKey: frutas.epoca`).
- `Sender2`: Envia mensagens relacionadas a dados do usuário (`routingKey: usuario.dados`).

### **2. checkpoint5-validator | Validator **
Middleware que valida as mensagens recebidas e as redireciona para os Receivers apropriados:
- Consome mensagens da fila `validation_queue`.
- Redireciona mensagens validadas para:
    - `receiver1.queue` (para frutas).
    - `receiver2.queue` (para usuários).

### **3.  checkpoint5-receiver | Receiver**
Consumidores que processam as mensagens validadas:
- `Receiver1`: Consome mensagens de `receiver1.queue` relacionadas a frutas.
- `Receiver2`: Consome mensagens de `receiver2.queue` relacionadas a usuários.

---

## **Configuração do Ambiente**

### **1. Configurar RabbitMQ com Docker**
Para configurar e executar o RabbitMQ com o Docker, utilize o arquivo `docker-compose.yml`:

```yaml name=docker-compose.yml
version: '3.8'
services:
  rabbitmq:
    image: rabbitmq:3-management
    container_name: rabbit-mq-dotnet
    hostname: my-rabbit
    environment:
      RABBITMQ_DEFAULT_USER: user
      RABBITMQ_DEFAULT_PASS: password
    ports:
      - "5672:5672" # Porta para conexões de aplicativos
      - "15672:15672" # Porta para interface de gerenciamento
```

#### **Comandos para Docker**
- Subir o RabbitMQ:
  ```bash
  docker-compose up -d
  ```
- Acessar a interface de gerenciamento:
    - URL: [http://localhost:15672](http://localhost:15672)
    - Credenciais:
        - Usuário: `user`
        - Senha: `password`
- Parar e remover os contêineres:
  ```bash
  docker-compose down
  ```

---

## **Etapas de Desenvolvimento**

### **1. checkpoint5 | Sender**
Este projeto contém os senders para publicar mensagens no RabbitMQ.

#### **Sender1**
- Envia mensagens sobre frutas da época para a exchange `topic_exchange` com a `routingKey: frutas.epoca`.

Exemplo de mensagem enviada:
```json
{
    "Nome": "Manga",
    "Descricao": "Fruta tropical, doce e suculenta.",
    "DataHora": "2025-05-14T01:15:00"
}
```

#### **Sender2**
- Envia mensagens sobre usuários para a exchange `topic_exchange` com a `routingKey: usuario.dados`.

Exemplo de mensagem enviada:
```json
{
    "NomeCompleto": "Andre Alves",
    "Endereco": "Rua da computacao, 64",
    "RG": "12.345.678-9",
    "CPF": "123.456.789-00",
    "DataRegistro": "2025-05-14T01:15:00"
}
```

**Execução:**
Para executar o Sender:
```bash
dotnet run --project checkpoint5
```

---

### **2. checkpoint5-validator | Validator**
Este projeto consome mensagens da fila `validation_queue`, valida o conteúdo e redireciona as mensagens para as filas apropriadas.

#### **Validação**
- `frutas.epoca`: Verifica se os campos `Nome` e `Descricao` estão presentes.
- `usuario.dados`: Verifica se os campos `NomeCompleto` e `CPF` estão presentes.

#### **Redirecionamento**
- Mensagens validadas de `frutas.epoca` são enviadas para `receiver1.queue`.
- Mensagens validadas de `usuario.dados` são enviadas para `receiver2.queue`.

**Execução:**
Para executar o Validator:
```bash
dotnet run --project checkpoint5-validator
```

---

### **3. checkpoint5-receiver | Receiver**
Este projeto contém os Receivers para processar as mensagens validadas.

#### **Receiver1**
- Consome mensagens de `receiver1.queue`.

Exemplo de processamento:
```plaintext
[Receiver1] Mensagem recebida:
{
    "Nome": "Manga",
    "Descricao": "Fruta tropical, doce e suculenta.",
    "DataHora": "2025-05-14T01:15:00"
}
```

#### **Receiver2**
- Consome mensagens de `receiver2.queue`.

Exemplo de processamento:
```plaintext
[Receiver2] Mensagem recebida:
{
    "NomeCompleto": "Andre Alves",
    "Endereco": "Rua da computacao, 64",
    "RG": "12.345.678-9",
    "CPF": "123.456.789-00",
    "DataRegistro": "2025-05-14T01:15:00"
}
```

**Execução:**
Para executar os Receivers:
```bash
dotnet run --project checkpoint5-receiver
```

---

## **Exemplo de Fluxo Completo**

1. **Sender envia mensagens**:
    - `Sender1` publica uma mensagem com `routingKey: frutas.epoca`.
    - `Sender2` publica uma mensagem com `routingKey: usuario.dados`.

2. **Validator processa mensagens**:
    - Mensagens são consumidas da fila `validation_queue`.
    - São validadas e redirecionadas para as filas `receiver1.queue` ou `receiver2.queue`.

3. **Receivers consomem mensagens**:
    - `Receiver1` consome mensagens de `receiver1.queue`.
    - `Receiver2` consome mensagens de `receiver2.queue`.

---

## **Testes**

### **Testando Sender/Receiver para Frutas**
1. Execute o `Sender1` para enviar uma mensagem sobre frutas.
2. O `Validator` consumirá a mensagem, validará e redirecionará para `receiver1.queue`.
3. O `Receiver1` consumirá a mensagem da fila e processará os dados.

### **Testando Sender/Receiver para Usuários**
1. Execute o `Sender2` para enviar uma mensagem sobre usuários.
2. O `Validator` consumirá a mensagem, validará e redirecionará para `receiver2.queue`.
3. O `Receiver2` consumirá a mensagem da fila e processará os dados.

---


## **Considerações Finais**

Este projeto demonstra a modularidade e o poder do RabbitMQ para sistemas de mensageria, permitindo a validação e o roteamento dinâmico de mensagens. TRANQUILO!

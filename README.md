# AthosApp1
Teste de App

## Estrutura e Como utilizar o sistema

O sistema utiliza MVC C# com Javascript/jquery e REST, utilizando um sistema de NoSQL chamado LiteDB para registar os dados. Ele também contem testes unitários para cada controller do sistema.

A arquitetura das telas é bem simples, utilizando Jquery para comunicar com a API.

Para rodar o sistema, abra a Solution (.sln) no Visual studio e clique Executar (F5) para o sistema abrir uma página nova no navegador

Dentro da página há 4 botões, cada um responsável por uma parte do sistema. Vou explicar cada uma delas em detalhe


### Condominio

A página de Condomínio mostra os condominios já cadastrados para editar e deletar, e também possui a opção de Criar. 

Dentro das páginas de criar/editar, é necessário preencher os campos e enviar o formulário com o botão no fim da tela.

Finalmente, caso clique no botão de deletar, o registro será removido.

### Usuário


A página de Usuario mostra os usuários já cadastrados para editar e deletar, e também possui a opção de Criar. 

Dentro das páginas de criar/editar, é necessário preencher os campos e enviar o formulário com o botão no fim da tela.

Fique atento ao campo de email, é necessário preenche-lo (quase) corretamente.

Finalmente, caso clique no botão de deletar, o registro será removido.

### Assunto

Essa tela não contem outras telas nem lista os assuntos. Ela só existe para testes.

### Envio de email

Essa tela contém a opção de enviar emails ao responsável do condominio pelo morador selecionado. Há uma opção para selecionar os emails de usuarios que são do tipo morador, outra para o assunto do email, e uma caixa para colocar o corpo do email. Finalmente há o botão de envio, que enviará o email ao responsável do condominio do usuário selecionado.

O email será registrado no banco de dados para envios futuros.

### Cadastrando Assuntos/Administradores
Caso não existam assuntos ou administradores, há maneiras de inserir no sistema. Há um botão escondido na tela de Condominio que cria uma Administradora com o nome digitado na caixa de Nome, e duas linhas comentadas na controller de envio que criará dois assuntos para teste. Basta descomentar a linha e abrir a tela de envio novamente. Lembre de comentar novamente as linhas, para que não fique criando assuntos desnecessários.

### Testes
Essas são todas as funcionalidades do sistema. Há também a parte de testes para cada função do sistema que é utilizada. 



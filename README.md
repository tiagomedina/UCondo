# UCondo
Teste para a UCondo

# Passo a passo para executar o projeto.
1 - Instalar o Docker na máquina local.
2 - Após a instalação executar o seguinte comando para iniciar o conteiner do RabbitMQ:  docker run --name rabbit1 -h rabbit -p 5672:5672 -p 15672:15672 -d rabbitmq:3-management 
3 - Instalar o Sql Server 2019 ou o Sql Server Express com o módulo do LocalDB.
4 - Ao abrir o projeto selecionar no Solution Explorer a salução UCondo e clicar com o botão direito em Properties ou apertar o atalho Alt + Enter.
5 - Na guia do lado esquerdo dentro de Common Properties / Startup Project Selecionar a opção Multiple Startup projects.
6 - Marcar os projetos com a Action Start UCondo.Bff.Gateway e UCondo.Entries.API e clicar em OK.
7 - Iniciar o projeto através do botão Start ou F5.
8 - Utilizar o endpoint: https://localhost:5451/swagger/index.html para executar as consultas.
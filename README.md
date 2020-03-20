<h2>Configuração do ambiente</h2>

<h4>SQL SERVER</h4>
<li>Instalação padrão do SQLServer 2017</li>

<h4>.NET CORE</h4>
<ul>
<li>Download da SDK do .NET Core 3.1 <a href="https://dotnet.microsoft.com/download/dotnet-core/3.1">AQUI</a></li>
<li>A SDK vai permitir executar, debuggar e realizar deploy de aplicações .NET Core Desktop, Web e UWP.</li>
<li>Instalação padrão</li>
<li>Após finalizar a instalação, verificar se através do comando dotnet --version no terminal, é possível verificar a versão instalada do .net core</li>
</ul>
  
<h4>VS CODE</h4>
<ul>
<li>Download do VS Code AQUI <a href="https://code.visualstudio.com/download">AQUI</a></li>
<li>Instalação padrão</li>
<li>Após a instalação abrir o VS Code e instalar as extensões necessárias a seguir</li>
<ol>
  <li>Path Intellisense</li> 
  <li>C#</li> 
  <li>C# Extensions</li> 
  <li>ASP.NET Core Snippets</li> 
</ol>
</ul>
  
 <h2>VERIFICAÇÃO FINAL</h2>
 <ul>
  <li>Criar uma pasta para conter o projeto teste</li>
  <li>Abrir a pasta pelo terminal. Pode-se utilizar o terminal integrado do VSCODE</li>
  <li>No terminal, criar um novo projeto pela linha de comando, através do comando: dotnet new webapi -n [NOME_DO_PROJETO]</li>
  <li>O projeto criado é uma estrutura inicial de uma Restful API em ASP .NET Core, contendo um
  endpoint disponível para testar se o ambiente está correto</li>
  <li>Abrir a pasta no VSCode por meio de File > Open Folder</li>
  <li>Executar o Debug and Run por meio de Execute > Debug and Run</li>
  <li>Adicionar a configuração .NET Core Launch e executar</li>
  <li>Após isso se não ocorreu nenhum erro no terminal o endpoint http://localhost:5000/WeatherForecast deve estar disponível para ser acessado pelo navegador, retornando um JSON com alguns dados teste</li>
</ul>
  

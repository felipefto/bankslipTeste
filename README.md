# bankslipTeste

Executar API tem duas maneiras:

1 - Abrir a solução via Visual Studio 2017, importante ter instalado a versão mais recente e executar a aplicação via degub ou release. Isso irá executar o IIS Express e a partir disso usar a aplicação.

2 - Abrir a solução via Visual Studio 2017, importante ter instalado a versão mais recente e usar o Publish do VS2017 publicar em um servidor ou maquina local que possua IIS com .NET Core Windows Server Hosting:
  -Download: (https://www.microsoft.com/net/download) clique em Dowload .NET Core Runtime.
  
    -Após isso, abra o cmd e execute o comando "iisreset".
  
    -Abra o IIS crie um Pool de aplicação com o Versão .NET  CLR "No Managed Code".
  
    -Crie o um novo site no IIS, aponte para a pasta "C:\inetpub\wwwroot\bankslip" (/bankslip é a pasta que você criará manualmente para seu projeto). Atribua o Pool criado no passo a cima ao site novo.  
  
    -No VS2017 Crie um publish para o diretório do site criado no IIS.
  
    -Execute a publicação.
  

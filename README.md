# SGVE

<p>
  Projeto de Conclusão de Curso migrado para .Net Core 6.0. 
  Anteriormente foi apresentado em .Net Framework em 2022 à banca da Faculdade de Tecnologia - FATEC.
</p>

<p>
  Execute os comandos abaixo na ferramenta PowerShell (Ferramenta encontrada na área de tarefas do Windowns):
  </br>
  
  1. Instala na sua máquina o dotnet-ef:
<pre>dotnet tool install --global dotnet-ef</pre>
  2. Atualiza para a versão mais recente:
<pre>dotnet tool update --global dotnet-ef</pre>
</p>


<p>
  Ferramentas necessárias:
  </br>
  <pre>- Visual Studio 2022;<br/>- Sql Server 2019 ou versão recente;</pre>
<p>

<p>
  Para rodar o projeto, é necessário que já tenha criado um banco de dados com o nome: "SGVE" (conforme imagem abaixo):
  
  ![image](https://github.com/brunafreit4s/SGVE/assets/32462617/220536ed-0d45-4c41-ac61-920176abad7d)

  Obs: <b>não é necessário criar as tabelas manualmente!!</b>
  </br>
  <h3>Para importar as configurações de acesso e estrutura das tabelas na base de dados</h3>
  
  No terminal do projeto digite os seguintes comandos:
  </br>

1. Cria uma migration para estruturar as tabelas
  <pre>dotnet ef migrations add SeedDataTableOnDb</pre>
2. Atualiza a base de dados
  <pre>dotnet ef database update</pre>
<p>

<p>
  <h3>Tecnologias utilizadas: </h3><hr/>
  <p>- .Net Core 6</p>
  <p>- Entity Framework;</p>
  <p>- Bootstrap;</p>  
  <p>- JavaScript;</p>
  <p>- Google Chart;</p>
  <p>- SQL.</p>
</p>

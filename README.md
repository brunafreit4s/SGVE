# SGVE

>  Projeto de Conclusão de Curso migrado para .Net Core 6.0. 
  Anteriormente foi apresentado em .Net Framework em 2022 à banca da Faculdade de Tecnologia - FATEC.
<hr>

<h4> Como Usar:</h4>
<p>
  Execute os comandos abaixo na ferramenta PowerShell (Ferramenta encontrada na área de tarefas do Windowns):
  </br>
  
  1. Instala na sua máquina o dotnet-ef:
<pre>dotnet tool install --global dotnet-ef</pre>
  2. Atualiza para a versão mais recente:
<pre>dotnet tool update --global dotnet-ef</pre>
</p>
<hr>
<p>
 <h4> Ferramentas necessárias:</h4>
  <pre>- Visual Studio 2022;<br/>- Sql Server 2019 ou versão recente;</pre>
<p>
<hr>
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
  
  ![image](https://github.com/brunafreit4s/SGVE/assets/32462617/3a93cc5d-f56f-4218-92b5-a20a2c622cc0)
  ![image](https://github.com/brunafreit4s/SGVE/assets/32462617/75c036bf-ce10-4880-b3d9-b895124a0b85)
  ![image](https://github.com/brunafreit4s/SGVE/assets/32462617/cf151ad7-8bb3-4ec9-a72d-eb3739fd489e)
  
  ![image](https://github.com/brunafreit4s/SGVE/assets/32462617/8b9d997d-9afa-40b9-ae57-be2e815597a4)
  ![image](https://github.com/brunafreit4s/SGVE/assets/32462617/de34452c-3fcc-4354-a02f-07704680e234)
  ![image](https://github.com/brunafreit4s/SGVE/assets/32462617/ad33cd9a-8afb-43cf-8dfb-82b17cfa2e7f)
</p>

/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/*
===============================================================================================
-- Informe abaixo os scripts que serão rodados no Release do TFS 
-- Caso o script deve ser rodado apenas 1 vez, deve ser retirado do código posteriormente
-- Ou tratado o script para garantir que seja executado apenas 1 vez
===============================================================================================
*/

--:r .\ScriptsTemporarios\Exemplo\ScriptExemplo.sql


/*
===============================================================================================
-- Informações Basicas para inicialização do Sistema
===============================================================================================
*/

:r .\DadosBase\Tipo\Inclusao_StatusRegistro.sql



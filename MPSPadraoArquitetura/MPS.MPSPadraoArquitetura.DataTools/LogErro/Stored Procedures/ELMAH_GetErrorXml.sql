-- ========================================================================================================================
-- Author:		Daniel S. Moreira
-- Create date: 27/07/2017
-- Description: Proc do pacote ELMH para gerar logs de erros
-- Obs:. Estas procedures não estão no padrão utilizando o Schema [LogsErro] pois a dll forneceida pelo ELMAH efetua a chamada
-- Direto desta procedure, desta forma seria necessario alterar o Fonte do pacote. 
-- =========================================================================================================================


CREATE PROCEDURE [dbo].[ELMAH_GetErrorXml]
(
    @Application NVARCHAR(60),
    @ErrorId UNIQUEIDENTIFIER
)
AS

    SET NOCOUNT ON

    SELECT 
        [AllXml]
    FROM 
        [LogsErro].[ELMAH_Error]
    WHERE
        [ErrorId] = @ErrorId
    AND
        [Application] = @Application
-- ========================================================================================================================
-- Author:		Daniel S. Moreira
-- Create date: 27/07/2017
-- Description: Proc do pacote ELMH para gerar logs de erros
-- Obs:. Estas procedures não estão no padrão utilizando o Schema [LogsErro] pois a dll forneceida pelo ELMAH efetua a chamada
-- Direto desta procedure, desta forma seria necessario alterar o Fonte do pacote. 
-- =========================================================================================================================

CREATE PROCEDURE [dbo].[ELMAH_LogError]
(
    @ErrorId UNIQUEIDENTIFIER,
    @Application NVARCHAR(60),
    @Host NVARCHAR(30),
    @Type NVARCHAR(100),
    @Source NVARCHAR(60),
    @Message NVARCHAR(500),
    @User NVARCHAR(50),
    @AllXml NVARCHAR(MAX),
    @StatusCode INT,
    @TimeUtc DATETIME
)
AS

    SET NOCOUNT ON

    INSERT
    INTO
        [LogsErro].[ELMAH_Error]
        (
            [ErrorId],
            [Application],
            [Host],
            [Type],
            [Source],
            [Message],
            [User],
            [AllXml],
            [StatusCode],
            [TimeUtc]
        )
    VALUES
        (
            @ErrorId,
            @Application,
            @Host,
            @Type,
            @Source,
            @Message,
            @User,
            @AllXml,
            @StatusCode,
            @TimeUtc
        )
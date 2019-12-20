-- ========================================================================================================================
-- Author:		Daniel S. Moreira
-- Create date: 27/07/2017
-- Description: Proc do pacote ELMH para gerar logs de erros
-- Obs:. Estas procedures não estão no padrão utilizando o Schema [LogsErro] pois a dll forneceida pelo ELMAH efetua a chamada
-- Direto desta procedure, desta forma seria necessario alterar o Fonte do pacote. 
-- =========================================================================================================================

CREATE PROCEDURE [dbo].[ELMAH_GetErrorsXml]
(
    @Application NVARCHAR(60),
    @PageIndex INT = 0,
    @PageSize INT = 15,
    @TotalCount INT OUTPUT
)
AS 

    SET NOCOUNT ON

    DECLARE @FirstTimeUTC DATETIME
    DECLARE @FirstSequence INT
    DECLARE @StartRow INT
    DECLARE @StartRowIndex INT

    SELECT 
        @TotalCount = COUNT(1) 
    FROM 
        [LogsErro].[ELMAH_Error]
    WHERE 
        [Application] = @Application

    -- Get the ID of the first error for the requested page

    SET @StartRowIndex = @PageIndex * @PageSize + 1

    IF @StartRowIndex <= @TotalCount
    BEGIN

        SET ROWCOUNT @StartRowIndex

        SELECT  
            @FirstTimeUTC = [TimeUtc],
            @FirstSequence = [Sequence]
        FROM 
            [LogsErro].[ELMAH_Error]
        WHERE   
            [Application] = @Application
        ORDER BY 
            [TimeUtc] DESC, 
            [Sequence] DESC

    END
    ELSE
    BEGIN

        SET @PageSize = 0

    END

    -- Now set the row count to the requested page size and get
    -- all records below it for the pertaining application.

    SET ROWCOUNT @PageSize

    SELECT 
        [errorId]     = [ErrorId], 
        [application] = [Application],
        [host]        = [Host], 
        [type]        = [Type],
        [source]      = [Source],
        [message]     = [Message],
        [user]      = [User],
        [statusCode]  = [StatusCode], 
        [time]        = CONVERT(VARCHAR(50), [TimeUtc], 126) + 'Z'
    FROM 
        [LogsErro].[ELMAH_Error] error
    WHERE
        [Application] = @Application
    AND
        [TimeUtc] <= @FirstTimeUTC
    AND 
        [Sequence] <= @FirstSequence
    ORDER BY
        [TimeUtc] DESC, 
        [Sequence] DESC
    FOR
        XML AUTO
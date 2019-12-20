CREATE TABLE [Eventos].[NotificacoesDominio]
(
	[IdNotificacaoDominio] UNIQUEIDENTIFIER NOT NULL, 
    [Chave] VARCHAR(100) NOT NULL, 
    [Valor] VARCHAR(750) NOT NULL, 
    [TipoObjeto] VARCHAR(50) NOT NULL, 
	[EventType] VARCHAR(50) NOT NULL, 
	[Erro] BIT NOT NULL, 
    [ExceptionAplication] VARCHAR(MAX) NULL, 
	[DateOccurred] DATETIME2(2) NOT NULL DEFAULT GETDATE(), 
    
    CONSTRAINT [PK_NotificacoesDominio] PRIMARY KEY ([IdNotificacaoDominio]) 
)

CREATE TABLE [Tipo].[StatusRegistro]
(
	[StatusId] TINYINT NOT NULL  IDENTITY(0, 1), 
    [Descricao] VARCHAR(10) NOT NULL, 
    CONSTRAINT [PK_StatusRegistro] PRIMARY KEY ([StatusId])
)

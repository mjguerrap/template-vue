-- ========================================================================================================================
-- Author:		Daniel S. Moreira
-- Create date: 01/06/2017
-- Description:Popular a tabela de status de registro
-- =========================================================================================================================

DECLARE @TableStatus Table 
(		 
	StatusId tinyint
   ,Descricao varchar(10)
)
						
/*
=================================================================================================================
-- Declaração da tabela temporaria com as informações que devem ser inseridas na tabela real
=================================================================================================================
*/

INSERT INTO @TableStatus ([StatusId],[Descricao])
VALUES (0,'Inativo'),
	   (1,'Ativo'),
	   (2,'Excluido')

--SET Identity_Insert [Tipo].[StatusRegistro] ON

MERGE [Tipo].[StatusRegistro]
USING @TableStatus as tmp

-- Condição
ON tmp.StatusId = [Tipo].[StatusRegistro].[StatusId] 

-- Caso a condição seja verdadeira
WHEN MATCHED THEN
	UPDATE SET 
	[Tipo].[StatusRegistro].[Descricao] = tmp.[Descricao]
	
-- Quando a condição for false
WHEN NOT MATCHED THEN
	INSERT ([Descricao])
	VALUES (tmp.[Descricao])

-- Quando Existir registra na tabela Original que não tem na @Table variavel Opcional
WHEN NOT MATCHED BY SOURCE THEN
    DELETE;

--SET Identity_Insert [Tipo].[StatusRegistro] OFF
/*
Post-Deployment Script Template							
-------------------------------------------------------------------------------------------------------------------------
 Script de exemplo com trasação caso ocorra algum erro, não executa o script.

 OBS: Os select's do ROLLBACK não irão sair no log do TFS, mas caso seja preciso pedir para a STI 4 rodar o script, 
 será possível solicitar o mesmo.
 
-------------------------------------------------------------------------------------------------------------------------
*/


BEGIN TRANSACTION

	BEGIN TRY
		
		UPDATE Tabela
		SET	Coluna1 = 0
		   ,Coluna2 = NULL
		WHERE Coluna3 IN (SELECT Coluna4 FROM @TmpAtualizar)
		

		
		COMMIT TRANSACTION

	END TRY

BEGIN CATCH

	ROLLBACK TRANSACTION
	
	SELECT
		'Erro ao executar script' AS Descricao
		,ERROR_NUMBER() AS ErrorNumber
		,ERROR_SEVERITY() AS ErrorSeverity
		,ERROR_STATE() AS ErrorState
		,ERROR_PROCEDURE() AS ErrorProcedure
		,ERROR_LINE() AS ErrorLine
		,ERROR_MESSAGE() AS ErrorMessage;

END CATCH
﻿CREATE PROCEDURE [dbo].[spDeleteOrders]
	@Year INTEGER = NULL,
	@Month INTEGER = NULL,
	@Status nvarchar(20) = NULL,
	@Product INTEGER = NULL
AS
BEGIN
	SET NOCOUNT ON
	BEGIN TRANSACTION
		BEGIN TRY

			DELETE FROM Orders
			WHERE (@Year IS NULL OR YEAR(Orders.createdDate) = @Year)
			AND (@Month IS NULL OR Month(Orders.createdDate) = @Month)
			AND (@Status IS NULL OR Orders.status = @Status)
			AND (@Product IS NULL OR Orders.productId = @Product)

			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			PRINT 'Error occurred during delete operation.'
		END CATCH
END
GO

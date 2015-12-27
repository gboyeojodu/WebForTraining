USE [tdo]
GO
/****** Object:  StoredProcedure [systems].[uspDelTruckType]    Script Date: 26/12/2015 2:59:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[uspDelTruckType] -- [dbo].[uspDelTruckType] 61
@truckTypeID INT

AS

SET NOCOUNT ON

	DECLARE @response VARCHAR(100) = '', @isSuccess BIT = 0;


BEGIN
BEGIN TRY
BEGIN TRANSACTION

	IF EXISTS (SELECT 1 FROM dbo.TRUT WHERE truckTypeID = @truckTypeID)
	BEGIN
		DELETE FROM dbo.TRUT WHERE truckTypeID = @truckTypeID	
		SET @response = 'Successful.'
		SET @isSuccess = 1
		EXEC dbo.uspSystemReturnValues @truckTypeID, @isSuccess, @response
	END
ELSE 
	BEGIN
		SET @response = 'Truck Type does not exist'
		SET @isSuccess = 0; 
		EXEC dbo.uspSystemReturnValues @truckTypeID, @isSuccess, @response
	END

	COMMIT TRANSACTION
END TRY

	 BEGIN CATCH
	 ROLLBACK TRANSACTION

		SET @response = 'Truck Type does not exist'

	END CATCH
 
END


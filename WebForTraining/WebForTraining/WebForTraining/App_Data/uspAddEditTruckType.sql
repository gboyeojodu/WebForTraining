USE [tdo]
GO

/****** Object:  StoredProcedure [dbo].[uspAddEditTruckType]    Script Date: 23/12/2015 3:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[uspAddEditTruckType] -- [dbo].[uspAddEditTruckType] 39, '57FT', 1
(@truckTypeID INT = 0,
@truckTypeName VARCHAR(50),
@createdByID INT,
@sessionID UNIQUEIDENTIFIER
)

AS

SET NOCOUNT ON

BEGIN 

	DECLARE @response VARCHAR(MAX) = '', @isSuccess BIT = 0;
	IF @truckTypeID=0 AND EXISTS((SELECT 1 FROM dbo.TRUT WHERE (truckTypeName=@truckTypeName)))
		BEGIN 
			SET @response='Truck type already exists.'
			EXEC dbo.uspSystemReturnValues @truckTypeID, @isSuccess, @response
			RETURN
		END
	IF @truckTypeID<>0 AND EXISTS(SELECT 1 FROM dbo.TRUT WHERE truckTypeName=@truckTypeName AND truckTypeID <> @truckTypeID )
		BEGIN 
			SET @response='Truck type already exists.'
			exec dbo.uspSystemReturnValues @truckTypeID, @isSuccess, @response
			RETURN
		END

	BEGIN TRY
		BEGIN TRANSACTION
			MERGE dbo.TRUT AS TGT
			USING (SELECT @truckTypeID, @truckTypeName, @createdByID, @sessionID)
			AS SRC (truckTypeID, truckTypeName, createdByID, sessionID)
			ON TGT.truckTypeID = SRC.truckTypeID
			WHEN MATCHED THEN 
			UPDATE SET 
				TGT.truckTypeName = SRC.truckTypeName,
				TGT.dateModified = GETDATE(),
				TGT.modifiedByID = SRC.createdByID,
				TGT.sessionID = SRC.sessionID
			WHEN NOT MATCHED THEN
			INSERT (truckTypeName, createdByID, modifiedByID, sessionID)
			VALUES (@truckTypeName, @createdByID, @createdByID, @sessionID);

			SET		@response= 'Record updated successfully.';
			SET		@isSuccess = 1;

		COMMIT TRANSACTION

		IF ISNULL(@truckTypeID,0)=0
			BEGIN
				SET	@truckTypeID = SCOPE_IDENTITY()
				SET	@response= 'Record inserted successfully.';
			END
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @response = dbo.ufnSystemGetErrorInfo(); 
		SET @isSuccess = 0; 
	END CATCH
		EXEC dbo.uspSystemReturnValues @truckTypeID, @isSuccess, @response
END
SET NOCOUNT OFF;


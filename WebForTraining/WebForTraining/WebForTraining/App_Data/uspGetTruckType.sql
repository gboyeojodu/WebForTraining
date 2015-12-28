USE [tdo]
GO
/****** Object:  StoredProcedure [dbo].[uspGetTruckType]    Script Date: 23/12/2015 4:40:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspGetTruckType] -- [dbo].[uspGetTruckType] 5
--@truckTypeID INT = 0
AS
BEGIN
	
	SET NOCOUNT ON;
	SELECT 
		T0.truckTypeID
		,T0.truckTypeName
		,T0.dateCreated
		,T0.dateModified
		,T0.modifiedByID
		,T0.createdByID
		,T0.sessionID
		,T1.userName
	FROM 
		dbo.TRUT T0
		INNER JOIN dbo.USET T1
		ON T0.createdByID = T1.userID
	--WHERE T0.truckTypeID = IIF(@truckTypeID=0,truckTypeID,@truckTypeID)
END







----PROBLEM 3---
---VALIDATE ORDER STATUS---
GO
CREATE TRIGGER trg_ValidateOderStatus
ON orders
AFTER UPDATE
AS
BEGIN
BEGIN TRY
---check if any update has status=4 but shipped_date is null
IF EXISTS(
SELECT 1
FROM inserted
WHERE order_status=4
AND shipped_date IS NULL
)
BEGIN
RAISERROR('Order cannot be marked as completed when shipped_date is null.',16,1);
ROLLBACK TRANSACTION;
RETURN
END
END TRY

BEGIN CATCH
DECLARE @ErrorMessage NVARCHAR(4000);
SET @ErrorMessage=ERROR_MESSAGE();

RAISERROR(@ErrorMessage,16,1);
ROLLBACK TRANSACTION;
END CATCH
END
GO

UPDATE orders
SET order_status=1
WHERE order_id=1001

SELECT * FROM orders WHERE order_id=1001
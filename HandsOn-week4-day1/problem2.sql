---PROBLEM 2----
--AUTO-UPDATE STOCK AFTER ODER INSERT---
GO
CREATE TRIGGER trg_UpdateStockAfterOrder
ON order_items
AFTER INSERT
AS
BEGIN
BEGIN TRY
--check if stock is sufficient
IF EXISTS(
SELECT 1
FROM inserted i
JOIN stocks s
ON i.product_id=s.product_id
WHERE s.quantity<i.quantity
)
BEGIN
RAISERROR('Stock is insufficient for this order.',16,1);
ROLLBACK TRANSACTION;
RETURN;
END
--reduce stock quantity
UPDATE s
SET s.quantity=s.quantity-i.quantity
FROM stocks s
JOIN inserted i
ON s.product_id=i.product_id;
END TRY
BEGIN CATCH
---hnadle unexpected errors
DECLARE @ErrorMessage NVARCHAR(4000);
SET @ErrorMessage=ERROR_MESSAGE();
 
 RAISERROR(@ErrorMessage,16,1);
 ROLLBACK TRANSACTION;
 END CATCH
 END;
 GO

 SELECT * FROM order_items
 SELECT order_id,item_id FROM order_items

 INSERT INTO order_items(order_id,item_id,product_id,quantity,list_price,discount)
VALUES(4,3,10,1,500,0);

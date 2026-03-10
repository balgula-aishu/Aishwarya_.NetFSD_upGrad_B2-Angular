----PROBLEM 1----
---TOTAL SALES AMOUNT PER STORE---
USE EcommAppDb
GO
CREATE PROCEDURE sp_TotalSalesPerStore
AS
BEGIN
 SELECT
 s.store_id,
 s.store_name,
 SUM(oi.quantity * oi.list_price) AS total_sales
 FROM stores s
 JOIN orders o
 ON s.store_id=o.store_id
 JOIN order_items oi
 ON o.order_id=oi.order_id
 GROUP BY s.store_id,s.store_name
 ORDER BY total_sales DESC;
END;
GO

EXEC sp_TotalSalesPerStore

----RETRIEVE ORDERS BY DATE RANGE---
GO
CREATE PROCEDURE sp_GetOrdersByDateRange
@StartDate DATE,
@EndDate DATE
AS
BEGIN
   SELECT
   order_id,
   customer_id,
   store_id,
   order_date,
   order_status
   FROM orders
   WHERE order_date BETWEEN @StartDate AND @EndDate
   ORDER BY order_date;
END
GO
EXEC sp_GetOrdersByDateRange '2018-02-01','2018-02-11';

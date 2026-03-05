USE EcommAppDb

-----PROBLEM 4------
---CREATING ARCHIVES ORDERS TABLE----
CREATE TABLE archived_orders
(
    order_id INT,
    customer_id INT,
    order_status INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE,
    store_id INT,
    staff_id INT
);
---INSERT DATA INTO ARCHIVED RECORDS----
INSERT INTO archived_orders
SELECT *
FROM orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR,-1,GETDATE());

SELECT * FROM archived_orders

------DELETING REJECTED ORDERS----
DELETE FROM orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR,-1,GETDATE());

-----ALL ORDERS COMPLETED CUSTOMERS---
SELECT customer_id
FROM orders
GROUP BY customer_id
HAVING COUNT(*) =
(
    SELECT COUNT(*)
    FROM orders o2
    WHERE o2.customer_id = orders.customer_id
    AND o2.order_status = 4
);

-----DISPLAY ORDER PROCESSING DELAY---
SELECT 
order_id,
order_date,
shipped_date,
DATEDIFF(DAY, order_date, shipped_date) AS processing_delay
FROM orders;

---MARKING ORDER DELAY OR ON TIME---
SELECT 
order_id,
order_date,
required_date,
shipped_date,
CASE
    WHEN shipped_date > required_date THEN 'Delayed'
    ELSE 'On Time'
END AS delivery_status
FROM orders;


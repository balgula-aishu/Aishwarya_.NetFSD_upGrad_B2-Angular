USE EcommAppDb

------PROBLEM 3----------
SELECT 
    c.first_name + ' ' + c.last_name AS CustomerName,
    ISNULL(t.TotalAmount,0) AS TotalOrderValue,
    CASE 
        WHEN ISNULL(t.TotalAmount,0) > 10000 THEN 'Premium'
        WHEN ISNULL(t.TotalAmount,0) BETWEEN 5000 AND 10000 THEN 'Regular'
        ELSE 'Basic'
    END AS CustomerType
FROM customers c
LEFT JOIN
(
    SELECT 
        o.customer_id,
        SUM(oi.quantity * oi.list_price) AS TotalAmount
    FROM orders o
    JOIN order_items oi ON o.order_id = oi.order_id
    GROUP BY o.customer_id
) t
ON c.customer_id = t.customer_id

UNION

SELECT 
    first_name + ' ' + last_name,
    0,
    'Basic'
FROM customers
WHERE customer_id NOT IN
(
    SELECT customer_id FROM orders
);

-----UPDATING STOCK QUANTITY TO 0----------
UPDATE stocks
SET quantity = 0
WHERE product_id IN
(
    SELECT product_id
    FROM products
    WHERE model_year < 2017
);
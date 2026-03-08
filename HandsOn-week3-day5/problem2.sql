
---PROBLEM 2---
---CREATING PRODUCT VIEW----
CREATE VIEW vw_productSummary
AS
SELECT 
p.product_name,
b.brand_name,
c.category_name,
p.model_year,
p.list_price
FROM products p
JOIN brands b
ON p.brand_id=b.brand_id
JOIN categories c
ON p.category_id=c.category_id

SELECT * FROM vw_productSummary

----CREATE ORDER SUMMARY VIEW---
GO
CREATE VIEW vw_orderSummary
AS
SELECT
o.order_id,
c.first_name+''+c.last_name AS customer_name,
s.store_name,
st.first_name+''+st.last_name AS staff_name,
o.order_date
FROM orders o
JOIN customers c
ON o.customer_id=c.customer_id
JOIN stores s
ON o.store_id=s.store_id
JOIN staffs st
ON o.staff_id=st.staff_id
GO

SELECT * FROM vw_orderSummary

-----CREATE INDEXES ON FOREIGN KEYS---
CREATE INDEX idx_product_brand
ON products(brand_id);
CREATE INDEX idx_products_category
ON products(category_id);
CREATE INDEX idx_orders_customer
ON orders(customer_id)
CREATE INDEX idx_orders_store
ON orders(store_id);

EXEC sp_helpindex 'products';
EXEC sp_helpindex 'customers';
EXEC sp_helpindex 'stores';

---CHECK PERFORMANCE USING EXECUTION PLAN---
SET STATISTICS IO ON;
SELECT *
FROM products
WHERE brand_id=1;



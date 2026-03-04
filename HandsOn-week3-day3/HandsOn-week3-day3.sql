---CREATE DATABASE----
CREATE DATABASE StoreDb;
USE StoreDb;

----CREATE CUSTOMERS TABLE--
CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(100)
)
---INSERTING DATA INTO CUSTOMER TABLE--
INSERT INTO customers VALUES
(1,'Ravi','Kumar','ravi@gmail.com'),
(2,'Anita','Sharma','anita@gmail.com');

SELECT * FROM customers

----CREATE ORDERS TABLE--
CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT NOT NULL,
    order_date DATE NOT NULL,
    order_status INT NOT NULL, 
    store_id INT NOT NULL,

    FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
)
---INSERT VALUES INTO ODERS TABLE--
INSERT INTO orders VALUES
(101,1,'2026-03-01',1,1),
(102,2,'2026-03-02',4,2);

SELECT * FROM orders

---CREATE BRANDS TABLE---
CREATE TABLE brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(100) NOT NULL
)

---INSERRT DATA INTO BRANDS TABLE--
INSERT INTO brands VALUES
(1,'Nike'),
(2,'Adidas');

SELECT * FROM brands


---CREATE CATEGORIES TABLE--
CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(100) NOT NULL
)

---INSERT INTO CATEGORIES TABLE--
INSERT INTO categories VALUES
(1,'Shoes'),
(2,'Clothing');

SELECT * FROM  categories



---CREATE PRODUCT TABLE---
CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100) NOT NULL,
    brand_id INT NOT NULL,
    category_id INT NOT NULL,
    model_year INT,
    list_price DECIMAL(10,2) NOT NULL,

    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
)

---INSERT DATA INTO PRODUCTS TABLE--
INSERT INTO products VALUES
(1,'Running Shoes',1,1,2024,800),
(2,'T-Shirt',2,2,2025,600);

SELECT * FROM products


---CREATE STORES TABLE--
CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100) NOT NULL
)
----INSERT DATA INTO STORES TABLE--
INSERT INTO stores VALUES
(1,'Hyderabad Store'),
(2,'Mumbai Store');

SELECT * FROM stores

----CREATE ORDER ITEMS TABLE---
CREATE TABLE order_items (
    order_id INT,
    product_id INT,
    quantity INT NOT NULL,
    list_price DECIMAL(10,2) NOT NULL,

    PRIMARY KEY (order_id, product_id),

    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
)

---INSERT DATA INTO ORDER ITEMS--
INSERT INTO order_items VALUES
(101,1,2,800),
(102,2,1,600);

SELECT * FROM order_items

---CREATE STOCKS TABLE--
CREATE TABLE stocks (
    store_id INT,
    product_id INT,
    quantity INT NOT NULL,

    PRIMARY KEY (store_id, product_id),

    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
)

---INSERT DATA INTO STOCKS TABLE--
INSERT INTO stocks VALUES
(1,1,50),
(2,2,30);

SELECT * FROM stocks


--SELECT DB_NAME() AS CurrentDatabase;
--SELECT COUNT(*) FROM customers; 
--SELECT COUNT(*) FROM orders; 
--SELECT COUNT(*) FROM brands;
--SELECT COUNT(*) FROM products;
--SELECT COUNT(*) FROM stores;

---LEVEL 1 PROBLEM 1-----
SELECT 
    c.first_name,
    c.last_name,
    o.order_id,
    o.order_date,
    o.order_status
FROM customers c
INNER JOIN orders o
    ON c.customer_id = o.customer_id
WHERE o.order_status = 1  -----PENDNG
   OR o.order_status = 4 ----COMPLETED
ORDER BY o.order_date DESC;

-----LEVEL 1 PROBLEM 2----
SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM products p
INNER JOIN brands b
    ON p.brand_id = b.brand_id
INNER JOIN categories c
    ON p.category_id = c.category_id
WHERE p.list_price > 500
ORDER BY p.list_price ASC;

----LEVEL 2 PROBLEM 1----
SELECT 
    s.store_name,
    SUM(oi.quantity * oi.list_price) AS total_sales
FROM stores s
INNER JOIN orders o
    ON s.store_id = o.store_id
INNER JOIN order_items oi
    ON o.order_id = oi.order_id
WHERE o.order_status = 4
GROUP BY s.store_name
ORDER BY total_sales DESC;

-----LEVEL 2 PROBLEM 2---
SELECT 
    p.product_name,
    s.store_name,
    st.quantity AS available_stock,
    ISNULL(SUM(oi.quantity), 0) AS total_quantity_sold
FROM stocks st
INNER JOIN products p
    ON st.product_id = p.product_id
INNER JOIN stores s
    ON st.store_id = s.store_id
LEFT JOIN order_items oi
    ON st.product_id = oi.product_id
GROUP BY 
    p.product_name,
    s.store_name,
    st.quantity
ORDER BY p.product_name;

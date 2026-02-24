// productCartSummary.js

// Store product objects in an array
const cart = [
  { name: "Laptop", price: 50000, quantity: 1 },
  { name: "Mouse", price: 500, quantity: 2 },
  { name: "Keyboard", price: 1500, quantity: 1 }
];

// Arrow function to calculate total cart value using reduce()
const calculateTotal = (cartItems) =>
  cartItems.reduce(
    (total, product) => total + product.price * product.quantity,
    0
  );

// Use map() to format each product line
const formattedItems = cart.map(
  (product, index) =>
    `${index + 1}. ${product.name} - ₹${product.price} x ${product.quantity} = ₹${product.price * product.quantity}`
);

// Calculate total
const totalAmount = calculateTotal(cart);

// Display formatted invoice using template literals
console.log(`
Shopping Cart Invoice
-------------------------
${formattedItems.join("\n")}

Total Cart Value: ₹${totalAmount}
`);
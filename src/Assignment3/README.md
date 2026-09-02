# Inventory Management Console Application

This application helps to manage your product inventory through a simple, menu-driven console interface. You can add new products, update existing ones, remove products, search for products, and sort your inventory.

---

## Main Menu

1. Add a Product
2. View all product
3. Edit Product
4. Delete Product
5. Search Product
6. Sort Products
7. Exit

Select an operation from the main menu to continue with an operation

---

### Add Product

Use this option to add a new product to the inventory.
User will be prompted to enter:

* Product Name
* Product Price
* Product Quantity

The application automatically assigns a unique Product ID.

---

### View Products

Displays all products currently available in the inventory in a tabular form.
Each product includes:

* Product ID
* Product Name
* Price
* Quantity

If no products have been added, a message `INVENTORY IS EMPTY` is displayed.

---

### Update Product

Modify the details of an existing product.
Steps:

1. Enter the Product ID.
2. Enter the product details that you only want to edit and skip the field if it is empty.
3. Updated product information is displayed.

If the Product ID does not exist, an error message is displayed.

---

### Delete Product

Remove a product from the inventory.
Steps:

1. Enter the Product ID.
2. If the product exists, it is deleted.

If the Product ID does not exist, an error message is displayed.

---

### Search Products

Search for products using name of the product or product id.

The application will display all products whose names or id match the entered search text.

---

### Sort Products

Sort product by using these options

* Product Name
* Product Price
* product Quantity

Display products in a sorted order
Sorting helps organize the inventory for easier viewing.

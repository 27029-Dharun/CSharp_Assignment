# Expense Tracker Console Application

The project implements an **Expense Tracker Console Application**. This application helps to manage your expense through a simple, menu-driven console interface. You can add your transaction, update existing ones, delete transaction, view your transaction summary and view your history of transaction.

---
# Main Menu

1. Add transaction (Income/Expense)
2. Edit transaction
3. Delete transaction
4. View financial summary
5. View transactions
6. Exit application
 
Select an option to continue with an operation

---
# Features
## Add new transaction (Income/Expense)
Use this option to add a new transaction.
User will be prompted to enter:
- Transaction Type (expense/income)
- Transaction Category
- Transaction Amount
- Transaction Date
- Transaction Description

The application automatically assigns a unique Transaction ID.
If the transaction is added you will be displayed with a success message

---
## Edit Transaction
Modify the details of an existing transaction.

Steps:
1. Enter the Transaction ID.
2. Enter the updated transaction details.
3. The application updates the transaction information.

If the Transaction ID does not exist, an error message is displayed.

---
## Delete Transaction
Remove a recorded transaction.

Steps:
1. Enter the Transaction ID.
2. If the transaction exists, it is deleted.

If the Transaction ID does not exist, an error message is displayed.

---
## View Financial Summary

Displays the summary of transactions recorded
The summary includes:

- Total income
- Total expense
- Balance
- Monthly Income
- Monthly Expense
- Category wise income
- Category wise expense

---

## View Transaction

User will be prompted to select an option:
1. Expense  
2. Income  
3. All Transaction  

Based on the selected option you will be displayed all the recorded transactions

Each transaction includes:
- Transaction Id
- Transaction Type (expense/income)
- Transaction Category
- Transaction Amount
- Transaction Date
- Transaction Description

If no transactions have been added, an appropriate message is displayed.

## Search Transaction

Search the transaction using date and category

User will be prompted to select an option to search with
1. Date
2. Category

Enter the query to search
All the transactions with the matching Date/Category will be display.

## Sort Transaction

Display the transaction in sort order by amount

User will be prompted to select the option
1. Ascending
2. Descending

And the transaction will be sorted in the requested order.
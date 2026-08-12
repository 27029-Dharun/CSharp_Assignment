# Object-Oriented Programming Application

This application contains three main module:

1. Shape Hierarchy
2. Employee Management
3. Banking System

---

## Getting Started

1. Run the application.
2. The main menu will be displayed.
3. Select the module you want to use.
4. Follow the instructions shown on the screen.
5. Enter the required information when prompted.
6. View the calculated results.
7. Return to the main menu to use another module or exit the application.

---

### Main Menu

When the application starts, you will see a menu similar to the following:

1. Shape hierarchy
2. Employee hierarchy
3. Banking system
4. Exit

Enter your choice:

Choose the required option by entering the corresponding number.

---

## Module 1 Shape Hierarchy

The Shape Hierarchy module allows you to calculate the area of different shapes.

Available Shapes

- Rectangle
- Circle

---

### Using the Rectangle Option

Select Rectangle from the Shape menu.

The application will ask you to enter:

- Color
- Length
- Width

Example

Enter Shape Color : Blue
Enter Length      : 15
Enter Width       : 8

After entering the values, the application calculates the area automatically and displays:

- Shape Type
- Color
- Calculated Area

Example Output

Shape Type : Rectangle
Color      : Blue
Area       : 120

---

### Using the Circle Option

Select Circle from the Shape menu.

Enter:

- Color
- Radius

Example

Enter Shape Color : Red
Enter Radius      : 7

The application calculates the area and displays:

- Shape Type
- Color
- Area

Example Output

Shape Type : Circle
Color      : Red
Area       : 153.94

---

### Module 2 Employee Management

This module helps calculate bonuses for different employee positions.

Available Employee Types

- Manager
- Developer

---

### Creating a Manager

Choose Manager from the Employee menu.

Enter:

- Employee Name
- Monthly Salary

Example

Enter Employee Name : Rahul
Enter Salary        : 85000

The application automatically calculates the manager bonus which is 15% of the salary.

It then displays:

- Employee Name
- Position
- Salary
- Bonus Amount

Example Output

Name      : Rahul
Position  : Manager
Salary    : 85000
Bonus     : 17000

---

### Creating a Developer

Choose Developer from the Employee menu.

Enter:

- Employee Name
- Salary

Example

Enter Employee Name : Priya
Enter Salary        : 65000

The application calculates the developer bonus which is 10% of the salary.

It then displays:

- Employee Name
- Position
- Salary
- Bonus

Example Output

Name      : Priya
Position  : Developer
Salary    : 65000
Bonus     : 9750

---

## Module 3 Banking System

This module simulates basic banking operations.

Users can:

- Create an account
- Deposit money
- Withdraw money
- View updated balance

There are two account types available.

- Savings Account
- Checking Account

---

### Savings Account

The Savings Account maintains a minimum balance of Rs.1000.

### Creating an Account

Enter

- Account Holder Name
- Initial balance

Example

Account Holder Name : Dharun
Balance        : 15000

---

### Deposit Money

Select Deposit.
Enter the amount.

Example

Deposit Amount : 5000

The balance will be updated.
Current Balance : 20000

---

### Withdraw Money

Select Withdraw.
Enter the amount.

Withdraw Amount : 3000

If the withdrawal keeps the balance above the minimum required amount, the transaction is successful.
If not, the application displays an error message such as:

Insufficient balance.

This prevents the account balance from going below the allowed limit.

---

### Checking Account

Checking Accounts do not have a minimum balance restriction.

### Create an account by entering

- Account Holder Name
- Initial balance

Example

Account Holder Name : Dharun
Balance        : 15000

---

### Deposit

Enter the deposit amount.
Deposit Amount : 2500

Updated Balance
Current Balance : 17500

---

### Withdraw

Enter the withdrawal amount.
Withdraw Amount : 10000

Since Checking Accounts have no minimum balance restriction, the transaction is processed.

Updated Balance
Current Balance : 7500

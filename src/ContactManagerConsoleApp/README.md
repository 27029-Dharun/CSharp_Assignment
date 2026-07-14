# Assignment 1 - Task 5: Contact Manager

## C# console-based program that allows users to store and manage their contacts.

### Available Opeartions in Contact Manager

    1. Add the contact
    2. View the contact
    3. Edit the contact
    4. Delete the contact
    5. Search contact
    6. Sort Contact
    7. Type [Exit] to Exit


### The contact are stored as List of List
`
            List<List<string>> contacts = new List<List<string>>();
`

### Add new contacts with

	1. Name
	2. Phone number
	3. Email address

Phone number validation is done by checking all are digits and length of the number


### View Contacts 
Displays all the contacts from the contact 


### Edit existing contacts
Edit the contact by selecting the contact by the number


### Delete contacts
Edit the contact by selecting the contact by the number
And used RemoveAt(index) to remove the contact


### Search contacts 
Search by name or phone or email and display all the results
If it is not present displayed Not found



### Sort contacts
Done using Alphabetical order of Name

`
contacts.Sort((a, b) => string.Compare(a[0], b[0]));
`

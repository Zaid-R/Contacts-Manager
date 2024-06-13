# Contacts-Manager

## Overview
This project is a console application that functions as a contact manager, developed using Test Driven Development (TDD). The application allows users to add, remove, view, and search for contacts within different categories.

## Features
- **Add Contact**: Adds a new contact to the list.
- **Remove Contact**: Removes an existing contact from the list.
- **View All Contacts**: Displays all contacts in the list.
- **Search Contact**: Finds a contact by name or phone number.
- **Categorized Contacts**: Groups contacts by category (Family, Friend, Work).

## Program Structure
- **ContactManager/Program.cs**: Contains the main logic for managing contacts.
- **ContactManagerTests/**: Contains unit tests for verifying the functionality of the contact management methods using Xunit.

## Methods
- **AddContact(Contact contact)**: Adds a new contact to the list. Returns the updated list of contacts or an error message if the contact is invalid or already exists.
- **RemoveContact(string name)**: Removes a contact by name. Returns the updated list of contacts.
- **ViewAllContacts()**: Returns a list of all contacts.
- **Search(string property, bool isNameProperty)**: Searches for a contact by name or phone number. Returns contact details if found.
- **GetByCategory(ContactType category)**: Retrieves contacts by category.

## Usage
1. Clone the repository:
   ```sh
   git clone git@github.com:Zaid-R/Contacts-Manager.git
2. Navigate to the project directory:

	 `cd Contacts-Manager `
3. Build and run the application:

	` dotnet run --project ContactManager ` 

## Unit Tests
To run the unit tests, use the following command:
` dotnet test`

The tests cover the following scenarios:
 - Adding a new contact
 - Removing a contact
 - Viewing all contacts
 - Preventing duplicate contacts
 - Handling empty contact inputs
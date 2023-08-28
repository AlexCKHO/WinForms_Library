# Library Application

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)


## Overview

The Library Application is a desktop application built using C# and WF for the UI. It allows users to manage books across different branches of a library.

## Features

- User Authentication: Sign in or sign up to access the library.
- Book Management: Add, read, remove, or edit books.
- Search Engine: Search for books by their names and check their availability.
- Exception Handling: Logs exceptions reports them back to the user in the UI.
  
## Technologies Used

- C# (WindowsForm for UI)
- MySQL
- Entity Framework (EF)
- Design pattern: MVVM
- NUnit, Moq, In-Memory database

## Getting Started

### Prerequisites

- .NET Framework 7.0
- MySQL database

### Installation

1. Clone the repository
```
git clone https://github.com/your-username/LibraryApplication.git
```
2. Open the solution file in Visual Studio.
3. In Package Manager: `update-database`
4. Build and run the application.

## Usage

1. Start the application.
2. Log in with `(UserName: 1, P/W: 1)` for simplicity sake or sign up. 
3. Use the main interface to manage books and branches.
4. Use the search engine to find specific books.

## Testing

The project includes a suite of unit tests that ensure its behaviour and reliability. The tests are written using NUnit and Moq, and used in-memory database for mocking dependencies.

### Test Files

The test repo can be find the Github: `https://github.com/AlexCKHO/EI_Task_Testing`

1. **AccountServiceShould.cs**: Tests related to account services like login and registration.
2. **BookManagerServiceShould.cs**: Tests for book management features.
3. **LibraryRepositoryTests.cs**: Tests for CRUD operations in the library repository.
4. **UserManagerServiceShould.cs**: Tests related to user management.
5. **ValidationServiceShould.cs**: Tests for various validation services like password and email validation.

### Running the Tests

To run the tests, follow these steps:

1. Open the solution in Visual Studio.
2. Go to `Test` > `Run All Tests`.

You can also run individual tests by right-clicking on the test method and selecting `Run Test`.

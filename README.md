# One World Academy Management System

A desktop-based institute management system developed using **C# Windows Forms**, **.NET Framework**, **SQL Server**, and **ADO.NET**.

The application provides a simple administrative interface for managing students, lecturers, courses, and related academic records.

---

## Overview

The **One World Academy Management System** was developed as a desktop application to simplify common administrative tasks within an educational institute.

The system provides an admin dashboard with functionality for:

- Student registration and management
- Lecturer management
- Course management
- Searching and filtering records
- Updating existing records
- Deleting records
- Database-driven data management
- User authentication

---

## Features

### Authentication

- Admin login interface
- Username and password validation
- Show / hide password functionality
- Login error handling
- Logout functionality

### Student Management

- Register new students
- View registered students
- Update student information
- Delete student records
- Search and filter students
- Automatically retrieve student information using registration numbers

### Lecturer Management

- Register lecturers
- View lecturer records
- Search and filter lecturers
- Update lecturer information
- Delete lecturer records

### Course Management

- Add new courses
- View available courses
- Edit course information
- Remove courses
- Display updated course information in the interface

### Dashboard

- Central administration dashboard
- Student overview
- Lecturer management access
- Course management access
- Search and filtering functionality

---

## Technologies Used

| Technology | Purpose |
|---|---|
| C# | Application development |
| Windows Forms | Desktop user interface |
| .NET Framework 4.7.2 | Application framework |
| SQL Server | Database management |
| ADO.NET | Database connectivity |
| Visual Studio | Development environment |
| Krypton Toolkit | UI components |

---

## Application Structure

```text
OneWorldAcademy/
│
├── fp.sln
├── fp.csproj
├── App.config
├── Program.cs
│
├── Form1.cs
├── Form1.Designer.cs
├── Form1.resx
│
├── Form2.cs
├── Form2.Designer.cs
├── Form2.resx
│
├── Form3.cs
├── Form4.cs
├── Form5.cs
├── Form6.cs
│
├── Properties/
├── Resources/
│
├── README.md
└── .gitignore

# One World Academy Management System

A Windows Forms desktop application developed in C# for managing students, lecturers and courses at an educational institute.

## Tech Stack
- C# / Windows Forms
- .NET Framework 4.7.2
- SQL Server / ADO.NET
- Krypton Toolkit UI components

## Main Features
- Admin login
- Student registration, update, delete and search
- Lecturer registration and search
- Course creation and update
- Dashboard-based navigation

## Setup
1. Open `fp.sln` using Visual Studio 2022 with **.NET desktop development** installed.
2. Ensure SQL Server Express is available as `.\SQLEXPRESS`.
3. Create/restore a database named `OneWorldAcademy` with the tables required by the application.
4. Build and run the solution.

> Note: The original database backup/schema was not included in the source archive, so a compatible `OneWorldAcademy` database is required for full runtime functionality.

## Maintenance fixes in this repository
- Made the SQL Server connection configurable through application settings instead of hard-coded form-level server names.
- Corrected course insert/update SQL issues.
- Corrected lecturer search queries to use `Lecture_table`.
- Fixed course-grid field mapping.
- Moved student deletion confirmation before the delete operation.
- Parameterized several insert/delete queries to reduce SQL errors and injection risk.
- Updated the Krypton Toolkit reference to a repository-relative path.

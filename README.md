# Student Management System

A web-based Student Management System built with ASP.NET Core MVC.

The project is designed to manage students, courses, course enrollments, and grades while following a clean and maintainable application structure.

> **Project Status:** In Development

---

## Features

### Student Management
- Create students
- View student details
- Edit student information
- Soft delete students
- Student status management:
  - Active
  - Inactive
  - Graduated

### Course Management
- Create courses
- View course details
- Edit courses
- Soft delete courses
- Define a maximum grade for each course

### Enrollment Management
- Enroll students in courses
- View student-course enrollments
- Prevent duplicate enrollments
- Remove enrollments using soft delete
- Restore a previously removed relationship when the student is enrolled again

### Grade Management
- Assign grades to student-course enrollments
- Edit grades
- Soft delete grades
- Prevent multiple active grades for the same enrollment
- Validate grades against the course maximum grade
- Automatically calculate grade percentages
- Visual grade indicators based on percentage

---

## Technologies

- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server
- AutoMapper
- Razor Views
- Bootstrap
- HTML
- CSS
- JavaScript

---

## Application Structure

The project separates responsibilities between controllers, services, entities, and view models.

```text
Controllers
    ↓
Service Interfaces
    ↓
Services
    ↓
Entity Framework Core
    ↓
SQL Server
```

The application also uses dedicated ViewModels for different operations such as:

```text
Create
Edit
List
Details
Delete
```

This helps prevent unnecessary data exposure and keeps each page focused on the information it requires.

---

## Database Structure

The main entities are:

```text
Student
Course
StudentCourse
Grade
```

### Relationships

```text
Student
   │
   │
   └──── StudentCourse ──── Course
                │
                │
              Grade
```

`StudentCourse` represents the enrollment of a student in a specific course.

Each enrollment can have one grade.

A unique constraint is used to prevent the same student from being enrolled in the same course more than once.

---

## Soft Delete

Instead of permanently deleting records, the project uses soft delete.

Entities contain fields such as:

```text
IsDeleted
DeletedAt
CreatedAt
UpdatedAt
```

Entity Framework Core Global Query Filters automatically hide soft-deleted records from normal queries.

This allows deleted records to remain in the database and makes future restoration possible.

---

## UI

The application includes a responsive administrative interface with:

- Collapsible sidebar navigation
- Responsive layouts
- Styled table cards
- Form cards
- Active navigation indicators
- Grade percentage highlighting
- Success notifications
- Responsive tables

---

## Validation

The application performs validation at both the ViewModel and service layers.

Examples include:

- Required student information
- Email validation
- Student and course selection validation
- Duplicate enrollment prevention
- Duplicate grade prevention
- Grade values cannot exceed the course maximum grade

---

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/mahyarbehnamrad/StudentManagementSystem.git
```

### 2. Navigate to the project

```bash
cd StudentManagementSystem
```

### 3. Restore dependencies

```bash
dotnet restore
```

### 4. Configure the database

Update the connection string in:

```text
appsettings.json
```

to match your SQL Server environment.

### 5. Apply migrations

```bash
dotnet ef database update
```

### 6. Run the application

```bash
dotnet run
```

---

## Screenshots

Screenshots will be added as the user interface is finalized.

---

## Planned Features

The following improvements are planned:

- Recycle Bin
- Restore soft-deleted records
- Dashboard statistics
- Student search
- Filtering
- Improved error pages
- Additional UI improvements
- Final responsive design improvements

---

## Privacy

This project is intended for educational and portfolio purposes.

Users should not enter real or sensitive personal information into the demonstration application.

---

## Author

**Mahyar Behnamrad**

GitHub: [mahyarbehnamrad](https://github.com/mahyarbehnamrad)

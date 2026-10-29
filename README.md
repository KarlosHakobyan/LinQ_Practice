# C# LINQ Practice

A practical C# project focused on learning and practicing **LINQ (Language Integrated Query)**, lambda expressions, and collection manipulation.

## 📚 About the Project

This project contains hands-on exercises for working with collections of objects using LINQ. It uses a student management scenario to demonstrate filtering, sorting, projection, aggregation, grouping, and querying data.

The goal is to understand how to write clean, readable, and efficient C# code using LINQ.

## 🛠️ Technologies

- C#
- .NET
- LINQ
- Lambda Expressions
- `List<T>` and `IEnumerable<T>`

## 📂 Topics Covered

### 1. Filtering
- `Where()`
- Filtering students by activity status and grades

### 2. Sorting
- `OrderBy()`
- `OrderByDescending()`
- Sorting students by grades

### 3. Projection
- `Select()`
- Creating new objects using `StudentModel`
- Selecting specific properties from objects

### 4. Condition Checking
- `Any()`
- `All()`
- Checking conditions across collections

### 5. Element Retrieval
- `FirstOrDefault()`
- Finding students by group and grade

### 6. Aggregation
- `Count()`
- `Average()`
- `Max()`
- `Min()`

### 7. Grouping
- `GroupBy()`
- Grouping students by department or study group
- Calculating the number of students and average grades per group

### 8. Combining LINQ Methods
- `Take()`
- Chaining multiple LINQ operators
- Finding the top three active students by grade

## 🧑‍🎓 Student Model

The project uses a `Student` class with the following properties:

| Property | Type | Description |
|---|---|---|
| `Id` | `int` | Student identifier |
| `Name` | `string` | Student name |
| `Age` | `int` | Student age |
| `Group` | `string` | Study group |
| `Grade` | `double` | Student grade |
| `IsActive` | `bool` | Indicates whether the student is active |

## 💻 Example

Retrieve the top three active students with grades of at least 70:

```csharp
var topStudents = students
    .Where(s => s.IsActive && s.Grade >= 70)
    .OrderByDescending(s => s.Grade)
    .Take(3)
    .Select(s => new
    {
        s.Name,
        s.Group,
        s.Grade
    })
    .ToList();

foreach (var student in topStudents)
{
    Console.WriteLine(
        $"{student.Name} - {student.Group} - {student.Grade}");
}
```

This example demonstrates how multiple LINQ operators can be chained to filter, sort, limit, and transform a collection.

## 🚀 Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- A C# IDE, such as Visual Studio, Visual Studio Code, or JetBrains Rider

### Run the Project

1. Clone the repository:

   ```bash
   git clone <repository-url>
   ```

2. Navigate to the project directory:

   ```bash
   cd LinQ
   ```

3. Run the application:

   ```bash
   dotnet run
   ```

## 🎯 Learning Goals

- Understand LINQ query and method syntax.
- Practice lambda expressions and delegates.
- Learn to filter, sort, group, and transform collections.
- Understand deferred and immediate execution.
- Write readable and maintainable C# code.
- Apply LINQ concepts to practical programming tasks.

## 📈 Progress

This is an ongoing learning project. New exercises and LINQ techniques will be added as the learning process continues.

---

**Author:** Karlos Hakobyan

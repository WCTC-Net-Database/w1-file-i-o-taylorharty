# Week 1: File I/O Basics

> **Template Purpose:** This is the starting template for the semester. Use this to begin your Console RPG project.

---

## Your Repository for the Semester

**This template becomes YOUR repository for the entire semester.**

When you accept the GitHub Classroom assignment:

1. A copy of this template is created as YOUR personal repository
2. You'll continue building on this SAME repository each week
3. By Week 15 (final), this will have grown into a complete RPG game

**DO NOT** clone a new template each week. Instead:

- Continue working in YOUR repository
- Use future templates as REFERENCE MATERIAL
- Only use a template as a "fresh start" if you've fallen behind

See the **"How This Course Works"** section in
the [w00-git-intro README](https://github.com/WCTC-Net-Database/w00-git-intro) for the full guide.

---

## Overview

This week you'll build a console application that handles RPG character data using file input/output operations. You'll
practice reading from and writing to CSV files - a fundamental skill that prepares you for working with interfaces and
databases later in the semester.

## Learning Objectives

By completing this assignment, you will:

- [ ] Read character data from a CSV file
- [ ] Write updated character data back to a CSV file
- [ ] Create a simple menu-driven console application
- [ ] Handle basic string parsing

## Prerequisites

Before starting, ensure you have:

- [ ] Completed Week 0 Git assignment (you can clone and push)
- [ ] Visual Studio or VS Code installed
- [ ] Basic C# knowledge from your intro programming course

## What's New This Week

| Concept                | Description                                   |
|------------------------|-----------------------------------------------|
| `File.ReadAllLines()`  | Read all lines from a text file into an array |
| `File.WriteAllLines()` | Write an array of strings to a text file      |
| `String.Split()`       | Parse CSV data by splitting on commas         |

---

## Assignment Tasks

### Task 1: Review the Starter Code

**What to do:**

- Open the provided template in Visual Studio
- Review the existing `Program.cs` structure - the menu loop is complete
- Run the application to see the menu in action
- Read the comments in each method to understand what you need to implement

**What's Already Done For You:**

- Menu loop structure (switch statement)
- `DisplayMenu()` method
- Basic file reading in `DisplayAllCharacters()` (but not parsing)
- Method stubs with TODO comments

**Files:** `Program.cs`, `input.csv`

### Task 2: Implement Character Display

**What to do:**

- Read character data from `input.csv`
- Parse each line to extract Name, Class, Level, HP
- Display all characters in a formatted list

**Example:**

```csharp
string[] lines = File.ReadAllLines("input.csv");
foreach (string line in lines)
{
    string[] parts = line.Split(',');
    Console.WriteLine($"Name: {parts[0]}, Class: {parts[1]}, Level: {parts[2]}");
}
```

### Task 3: Implement Add Character

**What to do:**

- Prompt the user for character details (Name, Class, Level, HP)
- Format as a CSV line
- Append to the existing file

### Task 4: Implement Level Up

**What to do:**

- Display numbered list of characters
- Let user select a character by number
- Increment their level
- Save all characters back to the file

---

## Stretch Goal (+10%)

**Use the CsvHelper Library**

Install the CsvHelper NuGet package and refactor your file operations to use it. This library handles edge cases (commas
in values, quotes, etc.) automatically.

```bash
dotnet add package CsvHelper
```

See [CsvHelper Documentation](https://joshclose.github.io/CsvHelper/) for examples.

---

## Menu Structure

After completing this assignment, your menu should look like:

```
1. Display Characters
2. Add Character
3. Level Up Character
0. Exit
```

---

## Project Structure

```
YourProjectName/
├── Program.cs          # Main C# file containing all the logic
└── input.csv           # Text file containing character data
```

---

## Grading Rubric

| Criteria               | Points  | Description                                           |
|------------------------|---------|-------------------------------------------------------|
| File Reading           | 30      | Successfully reads and parses character data from CSV |
| File Writing           | 30      | Successfully writes updated data back to CSV          |
| Menu Implementation    | 20      | All menu options work correctly                       |
| Error Handling         | 10      | Handles missing file, invalid input gracefully        |
| Code Quality           | 10      | Clean, readable, well-commented                       |
| **Total**              | **100** |                                                       |
| **Stretch: CsvHelper** | **+10** | Successfully uses CsvHelper library                   |

---

## How This Connects to the Final Project

- The Character data structure you create here will evolve into your Player entity
- File I/O patterns will help you understand the interface abstraction in Week 4
- The menu structure will remain consistent throughout the semester
- Think of this as the foundation your RPG world is built on

---

## Tips

- Start by getting file reading working before tackling writing
- Test with a simple input.csv file (2-3 characters)
- Use `Console.WriteLine()` to debug your parsing
- Remember: CSV = Comma Separated Values
- Don't worry about handling commas inside values yet (Week 2 covers that)

---

## Submission

1. Commit your changes with a meaningful message (e.g., "Add character display and level up features")
2. Push to your GitHub Classroom repository
3. Submit the repository URL in Canvas

---

## Resources

- [File.ReadAllLines Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.readalllines)
- [String.Split Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.string.split)
- [CsvHelper Documentation](https://joshclose.github.io/CsvHelper/)

---

## Need Help?

- Post questions in the Canvas discussion board
- Attend office hours
- Review the in-class repository for additional examples

#  ADVANCED BUSINESS DEVELOPMENT WITH .NET - Checkpoint 1
# 1. Age Calculator 

## Description

The Age Calculator is a simple console application written in C#. It allows users to input their full name and date of birth in a specified format, and it calculates and displays their age based on the current date.

## Features

- Prompts the user for their full name.
- Accepts the date of birth in the format `dd/MM/yyyy`.
- Validates the date input to ensure it is correctly formatted.
- Calculates the age of the user based on the date of birth provided.
- Displays the result in a user-friendly message.
- Loops to allow re-entry in case of invalid date input.


### Main Method

The `Main` method is the entry point of the application. It contains a loop that repeatedly prompts the user for their name and birth date until valid input is provided. 

### Input Handling

- **Name Input**: Asks the user to enter their full name.
- **Date of Birth Input**: Asks the user to enter their birth date in the specified format.
- **Date Validation**: Utilizes `DateTime.TryParseExact` to validate the date format. If the input is invalid, an error message is displayed, and the user is prompted to try again.

### Age Calculation

The `CalculateAge` method computes the age based on the birth date:

1. Subtracts the birth year from the current year.
2. Checks if the current date is before the birthday in the current year. If so, decrements the age by one.

### Output

Once a valid date is entered, the application outputs the user's name along with their calculated age and indicates the end of the program.

# 2. Windows Forms Calculator 


## Description

The Windows Forms Calculator is a C# application designed to perform basic arithmetic operations. It provides a graphical user interface (GUI) that allows users to input numbers and operations, calculate results, and display them in real-time.

## Features

- User-friendly interface for basic calculations.
- Supports operations: addition, subtraction, multiplication, division, and percentage.
- Allows the user to input decimal points.
- Includes functionality to clear input fields and invert the sign of the current number.
- Implements the Command design pattern for better code organization and flexibility.


### Main Method

The `Main` method serves as the entry point of the application. It initializes the application, enabling visual styles and setting the default text rendering before launching the main form.

### Form1 Class

The `Form1` class represents the main form of the calculator:

- **Initialization**: Sets up the calculator and display components. It also initializes the `CalculatorInvoker` to handle command execution.
- **Button Click Event**: Each button on the calculator is wired to a click event that creates and executes the corresponding command using the `CalculatorCommandFactory`.

### Command Pattern Implementation

The application uses the Command design pattern to handle operations:

- **CalculatorCommandFactory**: This factory class creates instances of commands based on the button clicked. It determines the appropriate command to execute based on the button's text (e.g., operator, operand, or special functions).
  
- **Commands**: Various command classes (e.g., `SetOperatorCommand`, `AddDotCommand`, `ClearFieldCommand`, etc.) encapsulate the actions corresponding to different buttons, promoting separation of concerns and enhancing maintainability.

### Example Usage

When the user clicks buttons to input values and operations, the application processes these actions through the command pattern. For instance:

1. User clicks `5`.
2. User clicks `+`.
3. User clicks `3`.
4. User clicks `=`.

The application executes the appropriate commands, and the result (in this case, `8`) is displayed in the text box.





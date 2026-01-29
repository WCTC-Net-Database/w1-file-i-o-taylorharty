using Microsoft.VisualBasic.FileIO;

/// <summary>
///     Week 1: File I/O Basics - Console RPG Character Manager
///     This program teaches fundamental file operations in C#:
///     - Reading data from CSV files using File.ReadAllLines()
///     - Parsing comma-separated values using String.Split()
///     - Writing data back to files using File.WriteAllLines()
///     The menu structure is provided for you to review and understand.
///     Your tasks are marked with comments throughout the code.
/// </summary>
internal class Program
{
    // The path to our data file - we'll read and write character data here
    private static readonly string filePath = "input.csv";

    private static void Main()
    {
        // Welcome message
        Console.WriteLine("=== Console RPG Character Manager ===");
        Console.WriteLine("Week 1: File I/O Basics\n");

        // Main program loop - keeps running until user chooses to exit
        var running = true;
        while (running)
        {
            // Display the menu options
            DisplayMenu();

            // Get user's choice
            Console.Write("\nEnter your choice: ");
            var choice = Console.ReadLine();

            // Process the user's choice using a switch statement
            switch (choice)
            {
                case "1":
                    DisplayAllCharacters();
                    break;
                case "2":
                    AddCharacter();
                    break;
                case "3":
                    LevelUpCharacter();
                    break;
                case "0":
                    running = false;
                    Console.WriteLine("\nGoodbye! Thanks for playing.");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    break;
            }

            // Add a blank line for readability between menu displays
            if (running)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    /// <summary>
    ///     Displays the main menu options to the user.
    ///     This is complete - review it to understand the structure.
    /// </summary>
    private static void DisplayMenu()
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Display All Characters");
        Console.WriteLine("2. Add New Character");
        Console.WriteLine("3. Level Up Character");
        Console.WriteLine("0. Exit");
    }
    
    private static void DisplayAllCharacters()
    {
        Console.WriteLine("\n=== All Characters ===");

        // Step 1: Read all lines from the file
        // File.ReadAllLines() returns a string array where each element is one line
        var lines = File.ReadAllLines(filePath);

        // Step 2: Loop through each line and display it
        //
        // HINTS:
        // - Use line.Split(',') to separate the fields
        // - The fields are: Name (index 0), Class (1), Level (2), HP (3), Equipment (4)
        // - Equipment contains multiple items separated by '|'
        // - You can split equipment with: equipmentField.Split('|')
        //
        // Example output format:
        // Name: John
        // Class: Fighter
        // Level: 1
        // HP: 10
        // Equipment: sword, shield, potion
        // -------------------------

        foreach (var line in lines)
        {
            var cols = line.Split(",");

            var name = cols[0];
            var profession = cols[1];
            var level = cols[2];
            var hitPoints = cols[3];
            var equipment = "";
            if (cols.Length > 4)
            {
                equipment = cols[4];
            }
            var items = equipment.Split("|");

            Console.WriteLine();
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Class: {profession}");
            Console.WriteLine($"Level: {level}");
            Console.WriteLine($"Hit Points: {hitPoints}");
            if (equipment != "")
            {
                Console.WriteLine("Equipment:");
                foreach (var item in items) Console.WriteLine($" - {item}");
            }
            else Console.WriteLine("Nothing Equipped.");
        }
    }
    
    private static void AddCharacter()
    {
        Console.WriteLine("\n=== Add New Character ===\n");

        // TODO: Prompt for character details
        // Example:
        // Console.Write("Enter character name: ");
        // string name = Console.ReadLine();
        // ... continue for other fields ...
        var name = "";
        var profession = "";
        var level = 0;
        var hitPoints = 0;
        var equipment = "";

        //Get name and validate it, could be simplified with a method
        Console.Write("Enter Character Name: ");
        while (name is null || name.IsWhiteSpace())
        {
            name = Console.ReadLine();
            if (name is null || name.IsWhiteSpace())
                Console.Write("Try entering a valid name: ");
            else
                Console.WriteLine("\nName Saved!\n");
        }

        //get job and validate it, again could be simplified with a generic method
        Console.Write("Enter Character Class: ");
        while (profession is null || profession.IsWhiteSpace())
        {
            profession = Console.ReadLine();
            if (profession is null || profession.IsWhiteSpace())
                Console.Write("Try entering a valid character class: ");
            else
                Console.WriteLine("\nClass Saved!\n");
        }

        //continue to take level values until an int from 1-100 is picked
        Console.Write("Enter Character Level (1-100): ");
        var levelString = Console.ReadLine();
        var canConvert = int.TryParse(levelString, out level);
        while (!canConvert || level < 1 || level > 100)
        {
            Console.Write("Try entering a valid level (1-100): ");
            levelString = Console.ReadLine();
            canConvert = int.TryParse(levelString, out level);
        }

        Console.WriteLine("\nLevel Saved!\n");

        //continue to take hitPoints values until the number is between 10-1000
        Console.Write("Enter Character Hit Points (1-100): ");
        var hitPointsString = Console.ReadLine();
        canConvert = int.TryParse(hitPointsString, out hitPoints);
        while (!canConvert || hitPoints < 1 || hitPoints > 100)
        {
            Console.Write("Try entering a valid amount of hit points (1-100): ");
            hitPointsString = Console.ReadLine();
            canConvert = int.TryParse(hitPointsString, out hitPoints);
        }

        Console.WriteLine("\nHit Points Saved!\n");

        //ask user if the character has any items, and if so, adds them to an array of items, one by one
        Console.Write("Does the character have equipment? (yes or no): ");
        var answer = Console.ReadLine();
        while (answer.ToUpper() != "YES" && answer.ToUpper() != "NO")
        {
            Console.Write("I didn't get that. Does the character have equipment? (yes or no): ");
            answer = Console.ReadLine();
        }
        // if the user confirms that this character has equipment, proceed with adding it
        // so long as proceed is YES, it will keep adding items to the equipment variable, spaced with "|"
        if (answer.ToUpper() == "YES")
        {
            var proceed = "YES";
            while (proceed.ToUpper() == "YES")
            {
                Console.Write("\nEnter an item: ");
                var item = Console.ReadLine();
                while (item is null || item.IsWhiteSpace())
                {
                    Console.Write("Enter a valid item name: ");
                    item = Console.ReadLine();
                }

                if (equipment is null || equipment.IsWhiteSpace())
                {
                    equipment = item;
                }
                else
                {
                    equipment = equipment + $"|{item}";
                }
                
                Console.Write("\nItem Saved! Add another item? (yes or no): ");
                proceed = Console.ReadLine();
                
                while (proceed.ToUpper() != "YES" && proceed.ToUpper() != "NO")
                {
                    Console.Write("I didn't get that. Add another item? (yes or no): ");
                    proceed = Console.ReadLine();
                }
            }
        }
        else if (answer.ToUpper() == "NO")
        {
            equipment = "";
        }
        else
        {
            Console.WriteLine("I didn't get that. Does this character have items? (yes or no)");
        }

        // string newLine = $"{name},{characterClass},{level},{hp},{equipment}";
        // formatting this differently, based on whether or not user has equipment, so to not append comma which will
        // break line  if (parts.Length > 4)  in the LevelUpCharacter function
        string newLine = "";
        if (equipment == "")
        {
            newLine = $"{name},{profession},{level},{hitPoints}"; 
        }
        else
        {
            newLine = $"{name},{profession},{level},{hitPoints},{equipment}"; 
        }
        Console.WriteLine(newLine);

        // TODO: Append to file
        // File.AppendAllText(filePath, newLine + "\n");
        File.AppendAllText(filePath, $"{newLine}\n");

    }
    
    private static void LevelUpCharacter()
    {
        Console.WriteLine("\n=== Level Up Character ===\n");

        // ask player which character they want to level up
        Console.Write("Enter character name to level up: ");
        var nameToFind = Console.ReadLine();

        // read all lines from a file
        string[] lines = File.ReadAllLines(filePath);

        // looping through the characters and saving the line that has the character name to input
        // and that index to index
        var input = "";
        var output = "";
        var index = 0;
        foreach (string line in lines)
        {
            var character = line.Substring(0, line.IndexOf(','));
            if (character.ToUpper() == nameToFind.ToUpper())
            {
                input = line;
                index = lines.IndexOf(line);
            }
        }
        
        // this validates that something was actually found
        if (input != "")
        {
            string[] parts = input.Split(',');
            int level = int.Parse(parts[2]);
            level++;
            output = $"{parts[0]},{parts[1]},{level},{parts[3]}";
            if (parts.Length > 4)
            {
                output = output + $",{parts[4]}";
            }

            lines[index] = output;
            File.WriteAllLines(filePath, lines);
            Console.WriteLine($"\n{nameToFind} has leveled up! They are now level {level}!\n");
        }
        else
        {
            Console.WriteLine("\nThis character could not be found!\n");
        }
        
    }
}
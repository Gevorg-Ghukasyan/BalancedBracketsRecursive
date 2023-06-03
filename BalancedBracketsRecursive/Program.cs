// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

public class BalancedBrackets
{
    public static bool CheckBalance(string input)
    {
        return CheckBalanceRecursive(input, 0, 0);
    }

    private static bool CheckBalanceRecursive(string input, int index, int balance)
    {
        if (index == input.Length)
        {
            return balance == 0;
        }

        char currentChar = input[index];
        if (IsOpeningBracket(currentChar))
        {
            return CheckBalanceRecursive(input, index + 1, balance + 1);
        }
        else if (IsClosingBracket(currentChar))
        {
            if (balance == 0)
            {
                return false;
            }
            else if (!IsMatchingBracket(input[index - 1], currentChar))
            {
                return false;
            }
            else
            {
                return CheckBalanceRecursive(input, index + 1, balance - 1);
            }
        }
        else
        {
            return CheckBalanceRecursive(input, index + 1, balance);
        }
    }

    private static bool IsOpeningBracket(char c)
    {
        return c == '(' || c == '[' || c == '{';
    }

    private static bool IsClosingBracket(char c)
    {
        return c == ')' || c == ']' || c == '}';
    }

    private static bool IsMatchingBracket(char opening, char closing)
    {
        return (opening == '(' && closing == ')') ||
               (opening == '[' && closing == ']') ||
               (opening == '{' && closing == '}');
    }


    public static void Main(string[] args)
    {
        string input = "({[()]})";
        bool isBalanced = CheckBalance(input);
        Console.WriteLine("The input string is balanced: " + isBalanced);
    }
}

using HtmlMuse.Tokenizer;

namespace HtmlMuseConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        string htmlCode = "<!DOCTYPE html><html><body><!-- HTML MUSE --><h1>Happy, <br/>Tokenizing!</h1></body></html>";

        // Create an HtmlTokenizer instance
        HtmlTokenizer tokenizer = new HtmlTokenizer(htmlCode);

        // Retrieve all tokens
        List<Token> tokens = tokenizer.GetAllTokens();

        // Iterate through the tokens
        foreach (Token token in tokens)
        {
            Console.WriteLine($"{token}");
        }
    }
}
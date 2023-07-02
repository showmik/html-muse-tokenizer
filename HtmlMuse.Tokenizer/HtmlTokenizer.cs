using HtmlMuse.Tokenizer.States;
using HtmlMuse.Tokenizer.Tokens;

namespace HtmlMuse.Tokenizer;

public class HtmlTokenizer
{
    private readonly string _htmlText;
    private bool _hasEmittedEndOfFileToken;
    private bool _hasEmittedToken;

    public bool HasEmittedEndOfFileToken => _hasEmittedEndOfFileToken;
    public bool IsAtEndOfFile => CodePoint.Index >= _htmlText.Length;
    public CodePoint CodePoint { get; }
    public Token? CurrentToken { get; set; }
    public List<Token> EmittedTokens { get; }
    public StateMachine<HtmlTokenizer> FSM { get; }

    /// <summary>
    /// Initializes a new instance of the HtmlTokenizer class with the specified HTML text.
    /// </summary>
    /// <param name="htmlText">The HTML text to tokenize.</param>
    public HtmlTokenizer(string htmlText)
    {
        _htmlText = htmlText;
        CodePoint = new CodePoint();
        if (htmlText.Length > 0) { CodePoint.Value = htmlText[0]; }
        EmittedTokens = new List<Token>();
        FSM = new StateMachine<HtmlTokenizer>(this);
        FSM.SetCurrentState(DataState.Instance);
    }

    /// <summary>
    /// Retrieves the next token from the input HTML text.
    /// </summary>
    /// <returns>The next token if available; otherwise, null.</returns>
    public Token? GetNextToken()
    {
        while (!_hasEmittedToken)
        {
            FSM.Run();
            MoveToNextCodePoint();
        }
        _hasEmittedToken = false;
        return CurrentToken;
    }

    /// <summary>
    /// Retrieves all the tokens from the input HTML text.
    /// </summary>
    /// <returns>A list of all the emitted tokens.</returns>
    public List<Token> GetAllTokens()
    {
        Reset();
        while (!_hasEmittedEndOfFileToken)
        {
            FSM.Run();
            MoveToNextCodePoint();
        }
        _hasEmittedToken = false;
        return EmittedTokens;
    }

    /// <summary>
    /// Resets the tokenizer.
    /// </summary>
    public void Reset()
    {
        CodePoint.Index = 0;
        _hasEmittedToken = false;
        _hasEmittedEndOfFileToken = false;
        CurrentToken = null;
        EmittedTokens.Clear();
        FSM.SetCurrentState(DataState.Instance);
    }

    /// <summary>
    /// Creates a Token which becomes the CurrentToken.
    /// </summary>
    /// <param name="token">The token being created.</param>
    public void CreateToken(Token token)
    {
        CurrentToken = token;
    }

    /// <summary>
    /// Emits the specified token by updating the current token, adding it to the list of emitted tokens, and indicating that a token has been emitted.
    /// </summary>
    /// <param name="token">The token to emit.</param>
    public void EmitToken(Token token)
    {
        CurrentToken = token;
        EmittedTokens.Add(token);
        _hasEmittedToken = true;

        if (token is EOFToken)
        {
            _hasEmittedEndOfFileToken = true;
            return;
        }
    }

    /// <summary>
    ///  Emits the current token by adding it to the list of emitted tokens and indicating that a token has been emitted.
    /// </summary>
    public void EmitCurrentToken()
    {
        if (CurrentToken != null) { EmittedTokens.Add(CurrentToken); }
        _hasEmittedToken = true;
    }

    /// <summary>
    /// Moves the code point index to the next position and updates the code point value.
    /// </summary>
    public void MoveToNextCodePoint()
    {
        if (!_hasEmittedEndOfFileToken)
        {
            CodePoint.Index++;
            try { CodePoint.Value = _htmlText[CodePoint.Index]; }
            catch (IndexOutOfRangeException)
            {
                CodePoint.Value = null;
            }
        }
    }

    /// <summary>
    /// Reconsumes the current charcter in the specified state.
    /// </summary>
    /// <param name="state">The state where the current character will be consumed.</param>
    public void ReconsumeCharacter(State<HtmlTokenizer> state)
    {
        CodePoint.Index--;
        try { CodePoint.Value = _htmlText[CodePoint.Index]; }
        catch (IndexOutOfRangeException)
        {
            CodePoint.Value = null;
        }
        FSM.SwitchState(state);
    }

    /// <summary>
    /// Consumes the specified characters, advancing the code point index accordingly.
    /// </summary>
    /// <param name="characters">The characters to consume.</param>
    public void ConsumeCharacters(string characters)
    {
        CodePoint.Index += characters.Length - 1;
        try { CodePoint.Value = _htmlText[CodePoint.Index]; }
        catch (IndexOutOfRangeException)
        {
            CodePoint.Value = null;
        }
    }

    /// <summary>
    /// Checks if the specified string is present at the current position in the HTML text.
    /// </summary>
    /// <param name="checkString">The string to check for.</param>
    /// <param name="isCaseSensitive">Specifies whether the check should be case-sensitive.</param>
    /// <returns>True if the check string is found at the current position; otherwise, false.</returns>
    public bool CheckFor(string checkString, bool isCaseSensitive)
    {
        string text = string.Empty;
        for (int i = CodePoint.Index; i < CodePoint.Index + checkString.Length; i++)
        {
            try { text += _htmlText[i]; }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }
        return text == checkString && isCaseSensitive || text.ToLower() == checkString.ToLower();
    }
}
namespace HtmlMuse;

public class CodePoint
{
    public char? Value { get; set; }
    public int Index { get; set; } = 0;

    public bool IsUpperAlpha => Value >= 'A' && Value <= 'Z';
    public bool IsWhiteSpace => Value == '\u0009' || Value == '\u000A' || Value == '\u000C' || Value == '\u0020';
    public bool IsAlpha => (Value >= 'A' && Value <= 'Z') || (Value >= 'a' && Value <= 'z');
    public bool IsNullCharacter => Value == '\u0000';

    public char? ToUpper() => Value >= 'a' && Value <= 'z' ? (char)(Value - 32) : Value;

    public char? ToLower() => Value >= 'A' && Value <= 'Z' ? (char)(Value + 32) : Value;
}
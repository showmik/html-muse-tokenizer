# HtmlMuse.Tokenizer (Work in Progress)

**HtmlMuse.Tokenizer** is a lightweight HTML tokenizer library written in C#. It provides functionality to tokenize HTML code and extract individual tokens. The tokenizer serves as a fundamental building block for parsing and analyzing HTML documents, paving the way for the creation of a comprehensive Document Object Model (DOM) or parse tree.

## </> HTML Living Standard

This tokenizer follows the **HTML Living Standard** specification. The **HTML Living Standard** is a comprehensive specification that defines the syntax and parsing rules for HTML. It provides a set of states and behaviors that the tokenizer must adhere to when tokenizing HTML code. You can find the complete **HTML Living Standard** specification [here](https://html.spec.whatwg.org/multipage/parsing.html).

## 🔎 Project Overview

The goal of this project is to build a robust HTML tokenizer using C#. The tokenizer acts as a state machine, consuming input characters and transitioning between different states according to the HTML specification.

The project is currently a work in progress, and the following tasks are planned:

- ☐ Implement all the tokenizing states defined in the HTML Living Standard specification.
- ☐ Develop unit tests to ensure correct behavior.
- ☐ Refine and optimize the tokenizer algorithm.
- ☐ Utilize the tokenizer to build a robust and feature-rich HTML parser

## ⚙️ Usage

Here's a simple example that demonstrates how to use HtmlMuse.Tokenizer to tokenize an HTML document:

```csharp
using HtmlMuse.Tokenizer;

string htmlCode = "<!DOCTYPE html><html><body><!-- HTML MUSE --><h1>Happy, <br/>Tokenizing!</h1></body></html>";

// Create an HtmlTokenizer instance
HtmlTokenizer tokenizer = new HtmlTokenizer(htmlCode);

// Retrieve all tokens
List<Token> tokens = tokenizer.GetAllTokens();

// Iterate through the tokens
foreach (Token token in tokens)
{
    Console.WriteLine(token);
}

```

#### Output:

```shell
(DOCTYPE) -> Name: html,  PublicID: ,  SystemID: ,   ForceQuirks: False
(StartTag) -> TagName: html,  SelfClosing: False,  Attributes: 0
(StartTag) -> TagName: body,  SelfClosing: False,  Attributes: 0
(Comment) -> Data:  HTML MUSE
(StartTag) -> TagName: h1,  SelfClosing: False,  Attributes: 0
(Character) -> Data: H
(Character) -> Data: a
(Character) -> Data: p
(Character) -> Data: p
(Character) -> Data: y
(Character) -> Data: ,
(Character) -> Data:
(StartTag) -> TagName: br,  SelfClosing: True,  Attributes: 0
(Character) -> Data: T
(Character) -> Data: o
(Character) -> Data: k
(Character) -> Data: e
(Character) -> Data: n
(Character) -> Data: i
(Character) -> Data: z
(Character) -> Data: i
(Character) -> Data: n
(Character) -> Data: g
(Character) -> Data: !
(StartTag) -> TagName: h1,  SelfClosing: False,  Attributes: 0
(StartTag) -> TagName: body,  SelfClosing: False,  Attributes: 0
(StartTag) -> TagName: html,  SelfClosing: False,  Attributes: 0
(End Of File)
```

## 🤝 Contributions

Contributions to this project are welcome! Since it's a work in progress, you can contribute by implementing the planned tasks, improving existing code, or suggesting new features. Please open an issue or submit a pull request on GitHub to contribute.

## 📑 License

This project is licensed under the [MIT License](LICENSE). Feel free to use, modify, and distribute the code for both personal and commercial projects.

## ✨ Acknowledgements

**HtmlMuse.Tokenizer** is inspired by the **HTML Living Standard** specification and aims to provide a reliable and compliant tokenizer implementation in C#. Special thanks to the contributors and maintainers of the **HTML Living Standard** for their valuable work.

## 📧 Contact

For any questions or inquiries, please contact [intisarbnaim@gmail.com](mailto:intisarbnaim@gmail.com).

Happy tokenizing!

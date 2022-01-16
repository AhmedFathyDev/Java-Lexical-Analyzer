using System;
using System.Collections.Generic;
using static Analyzer.Helper;

namespace Analyzer
{
    static class Scanner
    {
        static String[] keywords = {"abstract", "assert", "boolean", "break",
                "byte", "case", "catch", "char", "class", "const", "continue",
                "default", "do", "double", "else", "enum", "extends", "final",
                "finally", "float", "for", "goto", "if", "implements", "import",
                "instanceof", "int", "interface", "long", "native", "new", "package",
                "private", "protected", "public", "return", "short", "static", "strictfp",
                "super", "switch", "synchronized", "this", "throw", "throws",
                "transient", "try", "void", "volatile", "while"};
        static String[] Separators = {
            "(", ")", "{", "}", "[", "]", ";", ",", ".", "...", "@", "::"
        };
        static String[] Oparators = {
                "=",">","<","!","~","?",":","->","==",">=","<=","!=","&&",",,","++",
                "--","+","-","*","/","&",",","^","%","<<",">>",
                "+=","-=","*=","/=","&=",",=","^=","%=","|","||","|="
            };

        static string code;
        static int Cursor;
        static int line, position_in_line;

        public static List<Token> Scan(string source)
        {
            code = source;
            Cursor = 0;
            line = 1;
            position_in_line = 1;

            List<Token> Tokens = new List<Token>();
            List<Func<Token>> methods = new List<Func<Token>>();
            {
                methods.Add(ReadComment);
                methods.Add(ReadLineComment);
                methods.Add(ReadKeyword);
                methods.Add(ReadBoolean);
                methods.Add(ReadSeparator);
                methods.Add(ReadOparator);
                methods.Add(ReadIdentifier);
                methods.Add(ReadBinaryNumber);
                methods.Add(ReadOctaNumber);
                methods.Add(ReadHexaNumber);
                methods.Add(ReadFloatingNumber);
                methods.Add(ReadNumber);
                methods.Add(ReadTextBlock);
                methods.Add(ReadChar);
                methods.Add(ReadString);
            }

            while (Cursor < code.Length)
            {
                //skip whiteSpcaces
                if (Char.IsWhiteSpace(code[Cursor]))
                {
                    moveCursorTo(Cursor + 1);
                    continue;
                }
                bool IsReadDone = false;
                foreach (Func<Token> f in methods)
                {
                    Token res = f();
                    if (res != null)
                    {
                        Tokens.Add(res);
                        moveCursorTo(Cursor + res.word.Length);
                        IsReadDone = true;
                        break;
                    }
                }

                //can't specify type of the current character
                if (!IsReadDone)
                {
                    //check if current character connected with (directed after) the previous SYNTEX_ERROR
                    if (Tokens.Count > 0 && Tokens[Tokens.Count - 1].type == Tag.SYNTEX_ERROR
                        && Tokens[Tokens.Count - 1].line == line
                        && Tokens[Tokens.Count - 1].postion + Tokens[Tokens.Count - 1].word.Length
                        == position_in_line)
                    {
                        Tokens[Tokens.Count - 1].word += code[Cursor];
                    }
                    else
                    {
                        string word = "";
                        word += code[Cursor];
                        Tokens.Add(new Token(Tag.SYNTEX_ERROR, line, position_in_line, word));
                    }
                    moveCursorTo(Cursor + 1);
                }
            }

            return Tokens;
        }
        static void moveCursorTo(int target)
        {
            while (Cursor < target)
            {
                if (code[Cursor] == '\n')
                {
                    line++;
                    position_in_line = 1;
                }
                else
                {
                    position_in_line++;
                }
                Cursor++;
            }
        }
        //check if the next characters in code equal word
        static bool IsNextSequenceEqual(string word)
        {
            if (Cursor + word.Length > code.Length)
                return false;
            for (int i = 0; i < word.Length; i++)
                if (code[Cursor + i] != word[i])
                    return false;
            return true;
        }

        //check if the next word in code equal keyword, and doesn't have any Letter after
        //use this to check keywords
        static bool IsNextWordEqual(string keyword)
        {
            if (!IsNextSequenceEqual(keyword))
                return false;
            return (Cursor + keyword.Length >= code.Length
                    || !IsJavaLetter(code[Cursor + keyword.Length])
                    || !Char.IsDigit(code[Cursor + keyword.Length]));
        }

        // regex : "/*"[^\0]*"*/"
        static Token ReadComment()
        {
            if (!IsNextSequenceEqual("/*"))//if not start with /*
                return null;
            string word = "/*";

            //Cursor+2, skip first two chars ("/*")
            for (int i = Cursor + 2; i < code.Length; i++)
            {
                word = word + code[i];
                if (code[i - 1] == '*' && code[i] == '/')
                {
                    break;
                }
            }
            return new Token(Tag.COMMENT, line, position_in_line, word);
        }
        //regex: "//".*
        static Token ReadLineComment()
        {
            if (!IsNextSequenceEqual("//"))
                return null;
            int i = Cursor;
            string word = ReadWhileMatch(code, ref i, (char ch) => ch != '\r' && ch != '\n');
            return new Token(Tag.LINE_COMMENT, line, position_in_line, word);
        }
        static Token ReadKeyword()
        {
            foreach (string word in keywords)
            {
                if (IsNextWordEqual(word))
                {
                    return new Token(Tag.KEYWORD, line, position_in_line, word);
                }
            }
            return null;
        }
        static Token ReadBoolean()
        {
            if (IsNextWordEqual("true"))
            {
                return new Token(Tag.BOOLEAN, line, position_in_line, "true");
            }

            if (IsNextWordEqual("false"))
            {
                return new Token(Tag.BOOLEAN, line, position_in_line, "false");
            }
            return null;
        }
        static Token ReadSeparator()
        {
            foreach (string word in Separators)
            {
                if (IsNextSequenceEqual(word))
                {
                    return new Token(Tag.SEPARATOR, line, position_in_line, word);
                }
            }
            return null;
        }
        static Token ReadOparator()
        {
            foreach (string word in Oparators)
            {
                if (IsNextSequenceEqual(word))
                {
                    return new Token(Tag.OPARATOR, line, position_in_line, word);
                }
            }
            return null;
        }
        static Token ReadIdentifier()
        {
            if (!IsJavaLetter(code[Cursor]))
                return null;
            int i = Cursor;
            string word = ReadWhileMatch(code, ref i, (char ch) => IsJavaLetter(ch) || Char.IsDigit(ch));
            return new Token(Tag.IDENTIFIER, line, position_in_line, word);
        }
        //regex => 0[bB]{binaryDigit}+
        static Token ReadBinaryNumber()
        {
            if (!IsNextSequenceEqual("0b") && !IsNextSequenceEqual("0B"))
            {
                return null;
            }
            string word = "0" + code[Cursor + 1];
            int i = Cursor + 2;
            word += ReadWhileMatch(code, ref i, IsBinaryDigit);
            if (word.Length == 2)//can't find any digits after "0b"
                return null;
            if (i < Cursor && IsIntgerTypeSuffix(code[i]))
            {
                word += code[i];
                i++;
            }
            return new Token(Tag.BINARY_NUMBER, line, position_in_line, word);
        }
        //regex => 0[Oo]{ocatDigit}+
        static Token ReadOctaNumber()
        {
            if (!IsNextSequenceEqual("0O") && !IsNextSequenceEqual("0o"))
            {
                return null;
            }
            string word = "0" + code[Cursor + 1];
            int i = Cursor + 2;
            word += ReadWhileMatch(code, ref i, IsOctaDigit);
            if (word.Length == 2)//can't find any digits after "0O"
                return null;
            if (i < Cursor && IsIntgerTypeSuffix(code[i]))
            {
                word += code[i];
                i++;
            }
            return new Token(Tag.OCTA_NUMBER, line, position_in_line, word);
        }
        //regex => 0[Xx]{HexaDigit}+
        static Token ReadHexaNumber()
        {
            if (!IsNextSequenceEqual("0X") && !IsNextSequenceEqual("0x"))
            {
                return null;
            }
            string word = "0" + code[Cursor + 1];
            int i = Cursor + 2;
            word += ReadWhileMatch(code, ref i, IsHexaDigit);
            if (word.Length == 2)//can't find any digits after "0x"
                return null;
            if (i < Cursor && IsIntgerTypeSuffix(code[i]))
            {
                word += code[i];
                i++;
            }
            return new Token(Tag.HEXA_NUMBER, line, position_in_line, word);
        }
        static Token ReadNumber()
        {
            if (!Char.IsDigit(code[Cursor]))
                return null;
            int i = Cursor;
            string word = ReadWhileMatch(code, ref i, Char.IsDigit);
            if (i < Cursor && IsIntgerTypeSuffix(code[i]))
            {
                word += code[i];
                i++;
            }
            return new Token(Tag.NUMBER, line, position_in_line, word);
        }
        static Token ReadFloatingNumber()
        {
            string word = "", digits;
            int i = Cursor;
            digits = ReadWhileMatch(code, ref i, Char.IsDigit);
            word += digits;

            /*
             * if entered any condtion of the next condtions then the number is real Number
             * otherwise is just a intger number
             */
            bool isFloatingNumber = false;
            if (i < code.Length && code[i] == '.')
            {
                isFloatingNumber = true;
                word += '.';
                i++;
                digits = ReadWhileMatch(code, ref i, Char.IsDigit);
                //must be atmost 1 digit after '.'
                if (digits.Length == 0)
                {
                    return null;
                }
                word += digits;
            }
            if (i < code.Length && IsExponentIndicator(code[i]))
            {
                isFloatingNumber = true;
                word += code[i];
                i++;
                if (i < code.Length && IsSignOperator(code[i]))
                {
                    word += code[i];
                    i++;
                }
                digits = ReadWhileMatch(code, ref i, Char.IsDigit);
                //must be atmost 1 digit after the Exponent Indicator
                if (digits.Length == 0)
                {
                    return null;
                }
                word += digits;
            }
            if (i < code.Length && IsFloatTypeSuffix(code[i]))
            {
                isFloatingNumber = true;
                word += code[i];
                i++;
            }
            if (word.Length == 0 || !isFloatingNumber)
                return null;
            return new Token(Tag.FLOATING_NUMBER, line, position_in_line, word);
        }
        static Token ReadChar()
        {
            if (code[Cursor] != '\'')
                return null;
            int last = code.IndexOf('\'', Cursor + 1);
            if (last == -1)//not found second quotes
                return null;
            //take the sequance of characters between quotes
            string word = code.Substring(Cursor + 1, last - Cursor - 1);
            if (!IsValidCharacter(word))
                return null;
            word = "\'" + word + "\'";
            return new Token(Tag.CHAR, line, position_in_line, word);
        }
        static Token ReadTextBlock()
        {
            if (!IsNextSequenceEqual("\"\"\""))
                return null;
            string word = "\"\"\"", curChar = "";
            int i = Cursor + 3;
            while (i < code.Length)
            {
                curChar += code[i];

                if (IsValidCharacter(curChar))
                {
                    word += curChar;
                    string last = word.Substring(word.Length - 3, 3);

                    if (last == "\"\"\"")
                    {
                        break;
                    }
                    curChar = "";
                }
                i++;
            }
            return new Token(Tag.TEXTBLOCK, line, position_in_line, word);
        }
        static Token ReadString()
        {
            if (code[Cursor] != '\"')
                return null;
            string word = "\"", curChar = "";
            int i = Cursor + 1;
            while (i < code.Length)
            {
                if (code[i] == '\n')//string must be in singal line
                    break;
                curChar += code[i];
                if (IsValidCharacter(curChar))
                {
                    word += curChar;
                    if (curChar == "\"")
                    {
                        break;
                    }
                    curChar = "";
                }
                i++;
            }
            return new Token(Tag.STRING, line, position_in_line, word);
        }
    }
}

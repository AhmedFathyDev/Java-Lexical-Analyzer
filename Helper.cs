using System;
using static System.Char;

namespace Analyzer
{
    static class Helper
    {
        static String[] EscapeSequence = {
            "\\b","\\t","\\n","\\f","\\r","\\\"","\\\'","\\\\","\\0"
        };
        public static bool IsExponentIndicator(char ch)
        {
            return (ch == 'e' || ch == 'E');
        }
        public static bool IsFloatTypeSuffix(char ch)
        {
            return (ch == 'f' || ch == 'F' || ch == 'd' || ch == 'D');
        }
        public static bool IsIntgerTypeSuffix(char ch)
        {
            return (ch == 'l' || ch == 'L');
        }
        public static bool IsSignOperator(char ch)
        {
            return (ch == '+' || ch == '-');
        }
        public static bool IsJavaLetter(char ch)
        {
            return (IsLower(ch) || IsUpper(ch) || ch == '_');
        }
        public static bool IsBinaryDigit(char ch)
        {
            return (ch == '0' || ch == '1');
        }
        public static bool IsOctaDigit(char ch)
        {
            return ('0' <= ch && ch <= '8');
        }
        public static bool IsHexaDigit(char ch)
        {
            return IsDigit(ch) || ('a' <= ch && ch <= 'f') || ('A' <= ch && ch <= 'F');
        }
        public static bool IsEscapeSequence(string s)
        {
            return Array.Exists(EscapeSequence, (string sequence) => sequence == s);
        }
        public static bool IsUnicodeCharacter(string s)
        {
            if (s.Length != 6 || s[0] != '\\' || s[1] != 'u')
                return false;
            for (int i = 2; i < s.Length; i++)
                if (!IsHexaDigit(s[i]))
                    return false;
            return true;
        }
        //check if this string can be Character
        //passing without quotes
        public static bool IsValidCharacter(string s)
        {
            if (IsUnicodeCharacter(s) || IsEscapeSequence(s))
                return true;
            //if char is not unicode or esace sequnce it must have exacly 1 letter
            return s.Length == 1 && s[0] != '\\';
        }
        public static string ReadWhileMatch(string code, ref int startPos, Func<char, bool> valid)
        {
            string word = "";
            while (startPos < code.Length && valid(code[startPos]))
            {
                word += code[startPos];
                startPos++;
            }
            return word;
        }

    }
}

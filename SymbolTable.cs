using System;
using System.Collections.Generic;
using System.Linq;

namespace Analyzer
{
    class Node
    {
        public string identifier;
        string type;
        int line;
        public Node(string identifier, string type, int line)
        {
            this.identifier = identifier;
            this.type = type;
            this.line = line;
        }
        override public string ToString()
        {
            return $"identifier [{identifier}] of type [{type}] apper in line {line}";
        }
    }
    class SymbolTable
    {
        public List<Node> table;
        public void BuildFromTokens(List<Token> Tokens)
        {
            table = new List<Node>();
            for (int i = 0; i < Tokens.Count; i++)
            {
                if (Tokens[i].type == Tag.IDENTIFIER)
                {
                    //this identifier already exists
                    if (table.Any((Node x) => x.identifier == Tokens[i].word))
                        continue;

                    string datatype = "";
                    int line = Tokens[i].line;
                    int j = i - 1;
                    while (j >= 0 && Tokens[j].type == Tag.KEYWORD
                        && IsValidType(Tokens[j].word))
                    {
                        datatype = Tokens[j].word + " " + datatype;
                        line = Tokens[j].line;
                        j--;
                    }
                    datatype = datatype.Trim();
                    if (i + 1 < Tokens.Count && Tokens[i + 1].word == "(")
                    {
                        datatype += " function";
                    }
                    table.Add(new Node(Tokens[i].word, datatype, line));
                }
            }
        }

        static String[] TypeKeywords = { "boolean", "byte", "char",
            "class", "const", "double", "enum", "final", "float",
            "int", "interface", "long", "short", "String", "void"};
        static public bool IsValidType(string type)
        {
            return Array.Exists(TypeKeywords, (string s) => s == type);
        }
    }
}

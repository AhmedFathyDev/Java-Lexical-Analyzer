namespace Analyzer
{
    enum Tag
    {
        COMMENT, LINE_COMMENT, KEYWORD, FLOATING_NUMBER, NUMBER, BINARY_NUMBER, OCTA_NUMBER,
        HEXA_NUMBER, BOOLEAN, CHAR, STRING, TEXTBLOCK, SEPARATOR, OPARATOR, IDENTIFIER, SYNTEX_ERROR
    }

    class Token
    {
        public string word;
        public int line, postion;//store # of line and # of position where that word begin appear
        public Tag type;

        public Token(Tag type, int line, int position, string word)
        {
            this.type = type;
            this.line = line;
            this.postion = position;
            this.word = word;
        }
        override public string ToString()
        {
            return $"{word}\t ==> {type} apper in line {line}:{postion}";
        }

    }
}

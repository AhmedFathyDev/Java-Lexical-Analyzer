using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Analyzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Analysis_Click(object sender, EventArgs e)
        {
            string code = Input.Text;
            List<Token> Tokens = Scanner.Scan(code);
            string res = "";
            foreach (Token t in Tokens)
                res += t.ToString() + "\r\n";
            Output.Text = res;
        }

        private void Symbols_Click(object sender, EventArgs e)
        {
            string code = Input.Text;
            List<Token> Tokens = Scanner.Scan(code);
            SymbolTable smtable = new SymbolTable();
            smtable.BuildFromTokens(Tokens);

            string res = "";
            foreach (var t in smtable.table)
                res += t.ToString() + "\r\n";
            Output.Text = res;
        }
    }
}

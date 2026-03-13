using System;
using System.Collections.Generic;

namespace Aspose.ThreeD.Formats
{
    internal class FbxTokenizer
    {
        private readonly string _data;
        private readonly List<Token> _tokens = new List<Token>();

        public FbxTokenizer(string data)
        {
            _data = data;
        }

        public List<Token> Tokenize()
        {
            int line = 1;
            int column = 1;
            bool inComment = false;
            bool inDoubleQuotes = false;
            bool pendingData = false;
            int? tokenStart = null;
            int? tokenEnd = null;

            for (int i = 0; i < _data.Length; i++)
            {
                char c = _data[i];

                if (c == '\n')
                {
                    column = 0;
                    line++;
                    inComment = false;
                    // Don't increment i - the for loop will do it
                    continue;
                }

                if (!inComment)
                {
                    if (inDoubleQuotes)
                    {
                        if (c == '"')
                        {
                            inDoubleQuotes = false;
                            tokenEnd = i;
                            _processDataToken(ref tokenStart, ref tokenEnd, TokenType.DATA, line, column);
                            pendingData = false;
                            tokenStart = null;
                            tokenEnd = null;
                        }
                        continue;
                    }

                    if (c == '"')
                    {
                        tokenStart = i;
                        inDoubleQuotes = true;
                        continue;
                    }

                    if (c == ';')
                    {
                        _processDataToken(ref tokenStart, ref tokenEnd, TokenType.DATA, line, column);
                        tokenStart = null;
                        tokenEnd = null;
                        inComment = true;
                        continue;
                    }

                    if (c == '{')
                    {
                        _processDataToken(ref tokenStart, ref tokenEnd, TokenType.KEY, line, column);
                        tokenStart = null;
                        tokenEnd = null;
                        _tokens.Add(new Token("{", TokenType.OPEN_BRACKET));
                        continue;
                    }

                    if (c == '}')
                    {
                        _processDataToken(ref tokenStart, ref tokenEnd, TokenType.DATA, line, column);
                        tokenStart = null;
                        tokenEnd = null;
                        _tokens.Add(new Token("}", TokenType.CLOSE_BRACKET));
                        continue;
                    }

                    if (c == ',')
                    {
                        if (pendingData)
                        {
                            _processDataToken(ref tokenStart, ref tokenEnd, TokenType.DATA, line, column, true);
                            tokenStart = null;
                            tokenEnd = null;
                        }
                        _tokens.Add(new Token(",", TokenType.COMMA));
                        continue;
                    }

                    if (c == ':')
                    {
                        if (pendingData)
                        {
                            _processDataToken(ref tokenStart, ref tokenEnd, TokenType.KEY, line, column, true);
                            tokenStart = null;
                            tokenEnd = null;
                        }
                        else
                        {
                            throw new InvalidOperationException($"Unexpected colon at line {line}, column {column}");
                        }
                        continue;
                    }

                    if (char.IsWhiteSpace(c))
                    {
                        if (tokenStart.HasValue)
                        {
                            int peekPos = i + 1;
                            while (peekPos < _data.Length && char.IsWhiteSpace(_data[peekPos]) && _data[peekPos] != '\n')
                            {
                                peekPos++;
                            }

                            TokenType tokenType = TokenType.DATA;
                            if (peekPos < _data.Length && _data[peekPos] == ':')
                            {
                                tokenType = TokenType.KEY;
                            }

                            _processDataToken(ref tokenStart, ref tokenEnd, tokenType, line, column);
                            tokenStart = null;
                            tokenEnd = null;
                        }
                        pendingData = false;
                        // Don't increment i here - the for loop will handle it
                    }
                    else
                    {
                        tokenEnd = i;
                        if (!tokenStart.HasValue)
                        {
                            tokenStart = i;
                        }
                        pendingData = true;
                        // Don't increment i here - the for loop will do it
                    }
                }
                else
                {
                    // in comment, just skip the character (for loop will increment i)
                }

                column++;
            }

            return _tokens;
        }

        private void _processDataToken(ref int? start, ref int? end, TokenType tokenType, int line, int column, bool mustHave = false)
        {
            if (start.HasValue && end.HasValue)
            {
                string tokenText = _data.Substring(start.Value, end.Value - start.Value + 1);
                _tokens.Add(new Token(tokenText, tokenType));
            }
            else if (mustHave)
            {
                throw new InvalidOperationException($"Unexpected character at line {line}, column {column}, expected data token");
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace Aspose.ThreeD.Formats
{
    internal class FbxParser
    {
        private readonly List<Token> _tokens;
        private int _position;
        private FbxScope _rootScope;

        public FbxScope RootScope => _rootScope;

        public FbxParser(List<Token> tokens)
        {
            _tokens = tokens;
            _position = 0;
            _rootScope = ParseScope(topLevel: true);
        }

        private Token CurrentToken()
        {
            if (_position < _tokens.Count)
                return _tokens[_position];
            return null;
        }

        private Token Advance()
        {
            if (_position < _tokens.Count)
                return _tokens[_position++];
            return null;
        }

        private FbxScope ParseScope(bool topLevel = false)
        {
            var scope = new FbxScope();

            if (!topLevel)
            {
                var token = CurrentToken();
                if (token == null || token.Type != TokenType.OPEN_BRACKET)
                    throw new InvalidOperationException($"Expected OPEN_BRACKET, got {token?.Text}");
                Advance();
            }

            while (true)
            {
                var token = CurrentToken();
                if (token == null)
                {
                    if (topLevel)
                        break;
                    throw new InvalidOperationException("Unexpected end of file, expected closing bracket");
                }

                if (token.Type == TokenType.CLOSE_BRACKET)
                {
                    if (topLevel)
                        break;
                    Advance();
                    return scope;
                }

                if (token.Type == TokenType.KEY)
                {
                    var element = ParseElement();
                    scope.AddElement(element);
                }
                else
                {
                    throw new InvalidOperationException($"Unexpected token type {token.Type}, expected KEY or CLOSE_BRACKET");
                }
            }

            return scope;
        }

        private FbxElement ParseElement()
        {
            var currentToken = CurrentToken();
            if (currentToken == null || currentToken.Type != TokenType.KEY)
                throw new InvalidOperationException($"Expected KEY token, got {currentToken?.Text}");

            var element = new FbxElement(currentToken);
            Advance();

            while (true)
            {
                currentToken = CurrentToken();
                if (currentToken == null)
                    throw new InvalidOperationException("Unexpected end of file, expected closing bracket or key");

                if (currentToken.Type == TokenType.DATA)
                {
                    element.AddToken(currentToken);
                    Advance();

                    var nextToken = CurrentToken();
                    if (nextToken == null)
                        throw new InvalidOperationException("Unexpected end of file, expected bracket, comma or key");

                    if (nextToken.Type == TokenType.OPEN_BRACKET)
                    {
                        var childScope = ParseScope();
                        element.Compound = childScope;
                        return element;
                    }
                    else if (nextToken.Type == TokenType.CLOSE_BRACKET || nextToken.Type == TokenType.KEY)
                    {
                        return element;
                    }
                    else if (nextToken.Type == TokenType.COMMA)
                    {
                        Advance();
                    }
                }
                else if (currentToken.Type == TokenType.OPEN_BRACKET)
                {
                    var childScope = ParseScope();
                    element.Compound = childScope;
                    return element;
                }
                else if (currentToken.Type == TokenType.KEY || currentToken.Type == TokenType.CLOSE_BRACKET)
                {
                    return element;
                }
                else if (currentToken.Type == TokenType.COMMA)
                {
                    Advance();
                }
                else
                {
                    Advance();
                }
            }
        }

        public object ParseValue(Token token)
        {
            var text = token.Text.Trim('"');

            if (text.StartsWith("a:"))
            {
                return ParseArray(text.Substring(2));
            }

            if (int.TryParse(text, out int intVal))
                return intVal;

            if (double.TryParse(text, out double doubleVal))
                return doubleVal;

            return text;
        }

        private object ParseArray(string data)
        {
            var values = new List<object>();
            var parts = data.Split(',');
            foreach (var part in parts)
            {
                var trimmed = part.Trim();
                if (string.IsNullOrEmpty(trimmed))
                    continue;

                if (int.TryParse(trimmed, out int intVal))
                {
                    values.Add(intVal);
                }
                else if (double.TryParse(trimmed, out double doubleVal))
                {
                    values.Add(doubleVal);
                }
                else
                {
                    values.Add(trimmed.Trim('"'));
                }
            }
            return values;
        }
    }

    internal class FbxScope
    {
        private readonly Dictionary<string, List<FbxElement>> _elements = new Dictionary<string, List<FbxElement>>();

        public IReadOnlyDictionary<string, List<FbxElement>> Elements => _elements;

        public void AddElement(FbxElement element)
        {
            var key = element.Key;
            if (!_elements.ContainsKey(key))
                _elements[key] = new List<FbxElement>();
            _elements[key].Add(element);
        }

        public List<FbxElement> GetElements(string key)
        {
            return _elements.ContainsKey(key) ? _elements[key] : new List<FbxElement>();
        }

        public FbxElement GetFirstElement(string key)
        {
            var elements = GetElements(key);
            return elements.Count > 0 ? elements[0] : null;
        }
    }

    internal class FbxElement
    {
        private readonly Token _keyToken;
        private readonly List<Token> _tokens = new List<Token>();
        private FbxScope _compound;

        public string Key => _keyToken.Text;
        public IReadOnlyList<Token> Tokens => _tokens;
        public FbxScope Compound { get => _compound; set => _compound = value; }

        public FbxElement(Token keyToken)
        {
            _keyToken = keyToken;
        }

        public void AddToken(Token token)
        {
            _tokens.Add(token);
        }
    }
}

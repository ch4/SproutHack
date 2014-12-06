using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Documents;
using System.Windows.Media;
using HP.PC.Presentation;

namespace WpfCsSample.SourcePreview
{
    class SourceCodeFormatter
    {
        public FlowDocument Format(string fileName, byte[] content)
        {
            if (fileName.EndsWith(".xaml", StringComparison.InvariantCultureIgnoreCase))
            {
                return FormatXaml(Encoding.UTF8.GetString(content));
            }
            if (fileName.EndsWith(".cs", StringComparison.InvariantCultureIgnoreCase))
            {
                return FormatCSharp(Encoding.UTF8.GetString(content));
            }
            return FormatUnknown(fileName);
        }


        private static readonly Regex SplitSpacesRegex = new Regex(@"([\S]*)([\s]*)");
        private static readonly Regex SplitQuotesRegex = new Regex(@"((""[^""]*"")*)([^""]*)");
        private static readonly Regex SplitIdentifiersRegex = new Regex(@"([A-z0-9]*)([^A-z0-9]*)");

        private static readonly string[] KnownPrefixes =
        {
            "get_",
            "set_",
            "add_",
            "remove_",
        };

        private static readonly char[] WhiteSpaceCharacters = { '\t', ' ' };


        private static readonly HashSet<string> HpPcInterfaces = GetHpPcInterfaces();
        private static readonly HashSet<string> HpPcMethods = GetHpPcMethods();

        private FlowDocument FormatXaml(String text)
        {
            var root = new Paragraph();
            root.Inlines.Add(new Run(text) { Foreground = Brushes.Black });
            var document = new FlowDocument(root);
            return document;
        }

        private FlowDocument FormatUnknown(string fileName)
        {
            var root = new Paragraph();
            root.Inlines.Add(new Run("Binary file: ") { Foreground = Brushes.Black });
            root.Inlines.Add(new Run(fileName) { Foreground = Brushes.Green });
            var document = new FlowDocument(root);
            return document;
        }

        private FlowDocument FormatCSharp(String text)
        {
            var root = new Paragraph();
            bool skipUsings = false;
            using (var reader = new StringReader(text))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string trimStart = line.TrimStart(WhiteSpaceCharacters);
                    if (trimStart.StartsWith("//"))
                    {
                        root.Inlines.Add(new Run(line) { Foreground = Brushes.Green });
                    }
                    else
                    {
                        skipUsings = skipUsings || trimStart.StartsWith("namespace");
                        HandleContent(line, skipUsings, root);
                    }
                    root.Inlines.Add(new LineBreak());
                }
            }
            var document = new FlowDocument(root);
            return document;
        }

        private static void HandleContent(string line, bool skipUsings, Paragraph root)
        {
            bool theRestIsComment = false;
            bool isUsingStatement = false;

            Match quotesMatch = SplitQuotesRegex.Match(line);
            while (quotesMatch.Success)
            {
                var text = quotesMatch.Groups[1].Captures[0].Value;
                var nonText = quotesMatch.Groups[3].Captures[0].Value;

                if (theRestIsComment)
                {
                    root.Inlines.Add(new Run(text) { Foreground = Brushes.Green });
                }
                else
                {
                    root.Inlines.Add(new Run(text) { Foreground = Brushes.SteelBlue });
                }

                HandleProgram(nonText, skipUsings, root, ref theRestIsComment, ref isUsingStatement);
                quotesMatch = quotesMatch.NextMatch();
            }
        }

        private static void HandleProgram(string line, bool skipUsings, Paragraph root, ref bool theRestIsComment, ref bool isUsingStatement)
        {
            Match spaceMatch = SplitSpacesRegex.Match(line);
            while (spaceMatch.Success)
            {
                var word = spaceMatch.Groups[1].Captures[0].Value;
                var space = spaceMatch.Groups[2].Captures[0].Value;

                if (theRestIsComment || word.StartsWith("//"))
                {
                    theRestIsComment = true;
                    root.Inlines.Add(new Run(word) { Foreground = Brushes.Green });
                }
                else
                {
                    Match identifierMatch = SplitIdentifiersRegex.Match(word);
                    if (identifierMatch.Success)
                    {
                        while (identifierMatch.Success)
                        {
                            var identifier = identifierMatch.Groups[1].Captures[0].Value;
                            var separator = identifierMatch.Groups[2].Captures[0].Value;

                            if (!skipUsings && identifier == "using" || identifier == "namespace")
                            {
                                isUsingStatement = true;
                                root.Inlines.Add(new Run(identifier) { Foreground = Brushes.Blue });
                            }
                            else if (Keywords.Contains(identifier))
                            {
                                root.Inlines.Add(new Run(identifier) { Foreground = Brushes.Blue });
                            }
                            else if (isUsingStatement)
                            {
                                // do not highlight namespaces from using statement
                                root.Inlines.Add(new Run(identifier) { Foreground = Brushes.Black });
                            }
                            else if (Specials.Contains(identifier))
                            {
                                root.Inlines.Add(new Run(identifier) { Foreground = Brushes.Purple });

                            }
                            else if (HpPcInterfaces.Contains(identifier))
                            {
                                root.Inlines.Add(new Run(identifier) { Foreground = Brushes.DarkRed });
                            }
                            else if (HpPcMethods.Contains(identifier))
                            {
                                root.Inlines.Add(new Run(identifier) { Foreground = Brushes.DarkRed });
                            }
                            else
                            {
                                root.Inlines.Add(new Run(identifier) { Foreground = Brushes.Black });
                            }

                            root.Inlines.Add(new Run(separator) { Foreground = Brushes.Black });
                            identifierMatch = identifierMatch.NextMatch();
                        }
                    }
                    else
                    {
                        root.Inlines.Add(new Run(word) { Foreground = Brushes.Black });
                    }
                }

                root.Inlines.Add(new Run(space) { Foreground = Brushes.Black });
                spaceMatch = spaceMatch.NextMatch();
            }
        }


        private static HashSet<string> GetHpPcInterfaces()
        {
            var collection = Assembly.GetAssembly(typeof(IPcLink))
                .GetTypes()
                .Select(m => m.Name)
                ;

            var result = new HashSet<string>(collection);
            return result;
        }

        private static HashSet<string> GetHpPcMethods()
        {
            var collection = Assembly.GetAssembly(typeof(IPcLink))
                .GetTypes()
                .SelectMany(x => x.GetMethods().Where(y => y.IsPublic))
                .Select(m => m.Name)
                .Select(RemovePrefixes)
                ;

            var result = new HashSet<string>(collection);
            return result;
        }

        private static string RemovePrefixes(string name)
        {
            foreach (string knownPrefix in KnownPrefixes)
            {
                if (name.StartsWith(knownPrefix))
                {
                    return name.Substring(knownPrefix.Length);
                }
            }
            return name;
        }

        private static readonly HashSet<string> Specials = new HashSet<string>
        {
            "object",
            "Object",
            "string",
            "String",
            "bool",
            "Boolean",
            "byte",
            "Byte",
            "decimal",
            "Decimal",
            "double",
            "Double",
            "float",
            "Float",
            "long",
            "Int64",
            "sbyte",
            "SByte",
            "short",
            "Int16",
            "uint",
            "ulong",
            "ushort",
            "int",
            "Int32",
            "char",
            "Char",
            "Exception",
            "EventArgs",
            "RoutedEventArgs",
            "BitmapSource",
            "false",
            "null",
            "true",
        };

        private static readonly HashSet<string> Keywords = new HashSet<string>
        {
            "abstract",
            "as",
            "base",
            "break",
            "case",
            "catch",
            "checked",
            "class",
            "const",
            "continue",
            "default",
            "delegate",
            "do",
            "else",
            "enum",
            "event",
            "explicit",
            "extern",
            "finally",
            "fixed",
            "for",
            "foreach",
            "goto",
            "if",
            "implicit",
            "in",
            "interface",
            "internal",
            "is",
            "lock",
            "namespace",
            "new",
            "operator",
            "out",
            "override",
            "params",
            "private",
            "protected",
            "public",
            "readonly",
            "ref",
            "return",
            "sealed",
            "sizeof",
            "stackalloc",
            "static",
            "struct",
            "switch",
            "this",
            "throw",
            "try",
            "typeof",
            "unchecked",
            "unsafe",
            "using",
            "virtual",
            "void",
            "volatile",
            "while",
            "add",
            "alias",
            "ascending",
            "async",
            "await",
            "descending",
            "dynamic",
            "from",
            "get",
            "global",
            "group",
            "into",
            "join",
            "let",
            "orderby",
            "partial",
            "remove",
            "select",
            "set",
            "value",
            "var",
            "where",
            "yield",
        };
    }
}

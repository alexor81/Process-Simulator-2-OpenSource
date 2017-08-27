// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using FastColoredTextBoxNS;
using System;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Utils
{
    public static class FCTBUtils
    {
        private static int      fold(FastColoredTextBox aFCTB, int aStartLine)
        {
            for (int i = aStartLine; i < aFCTB.LinesCount; i++)
            {
                if (String.IsNullOrWhiteSpace(aFCTB[i].FoldingEndMarker) == false)
                {
                    return i;
                }

                if (String.IsNullOrWhiteSpace(aFCTB[i].FoldingStartMarker) == false)
                {
                    int lEnd = fold(aFCTB, i + 1);
                    aFCTB.CollapseFoldingBlock(i);
                    i = lEnd;
                }
            }

            return aFCTB.LinesCount;
        }

        public static void      fold(FastColoredTextBox aFCTB)
        {
            aFCTB.SuspendLayout();
            aFCTB.SyntaxHighlighter.HighlightSyntax(aFCTB.Language, aFCTB.Range);
            aFCTB.ResumeLayout();

            fold(aFCTB, 0);
        }

        public static string    xmlPretty(string aXML)
        {
            var lResult     = new StringBuilder();
            var lElement    = XElement.Parse(aXML);
            var lSettings   = new XmlWriterSettings();
            lSettings.OmitXmlDeclaration    = true;
            lSettings.Indent                = true;
            lSettings.NewLineOnAttributes   = false;

            using (var xmlWriter = XmlWriter.Create(lResult, lSettings))
            {
                lElement.Save(xmlWriter);
            }

            return lResult.ToString();
        }
    }
}

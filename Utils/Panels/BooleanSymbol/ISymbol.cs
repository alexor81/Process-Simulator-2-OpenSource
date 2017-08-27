// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Utils.Panels.BooleanSymbol
{
    public interface ISymbol: IDisposable
    {
        string  Name { get; }

        void    setupByForm(IWin32Window aOwner, IRedraw aRedraw);

        void    loadFromXML(XmlTextReader aXMLTextReader);

        void    saveToXML(XmlTextWriter aXMLTextWriter);

        Bitmap  draw(int aWidth, int aHeight);
    }
}

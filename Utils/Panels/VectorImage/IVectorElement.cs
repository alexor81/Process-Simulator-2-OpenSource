// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Utils.Panels.VectorImage
{
    public interface IVectorElement: IDisposable
    {
        string          Name { get; }

        IVectorElement  Clone { get; }

        void            loadFromXML(XmlTextReader aXMLTextReader);

        void            saveToXML(XmlTextWriter aXMLTextWriter);

        void            draw(Graphics aGraphics);

        void            drawSelected(Graphics aGraphics);

        bool            testHit(Point aPoint);

        void            move(int aDx, int aDy);

        void            resize(int aWidth, int aHeight, bool aShift);

        void            centerHorizantally(int aX);

        void            centerVertically(int aY);

        void            alignLeft(int aX);

        void            alignRight(int aX);

        void            alignTop(int aY);

        void            alignBottom(int aY);

        Rectangle       coverRect { get; }

        Form            getSetupForm(IRedraw aRedraw);
    }
}

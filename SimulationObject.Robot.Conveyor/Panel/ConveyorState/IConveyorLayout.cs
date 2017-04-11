// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Drawing;

namespace SimulationObject.Robot.Conveyor.Panel
{
    public interface IConveyorLayout: IDisposable
    {
        void drawBackground(Bitmap aBackground);

        void drawControl(Bitmap aControl, Bitmap aBackground, bool aMoving, bool aForward, bool aAlarm);

        void draw(long aMSFromLast, Graphics aGraphics, Bitmap aControl, bool aMoving, double aSpeed, bool aForward);
    }
}

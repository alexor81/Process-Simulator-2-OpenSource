// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;

namespace Utils
{
    [Flags]
    public enum EDataFlow
    {
        FROM    = 1,
        TO      = 2,
        BOTH    = FROM | TO
    }
}

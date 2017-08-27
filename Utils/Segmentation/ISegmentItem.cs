// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Segmentation
{
    public interface ISegmentItem
    {
        int SegID       {get; set;}
        int SegAddress  {get;}
        int SegLength   {get;}
    }
}

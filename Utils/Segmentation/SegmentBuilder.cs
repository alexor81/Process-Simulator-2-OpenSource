// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils.Segmentation
{
    public class SegmentBuilder
    {
        private uint                                            mFrameSize;
        public bool                                             Enabled
        {
            get { return mFrameSize > 0; }
        }

        private bool                                            mExcludeSingle;

        private 
            SortedList<string, 
                       SortedDictionary<int, 
                                        List<ISegmentItem>>>    mAreas;

        private SortedList<string, int>                         mCount;
        private SortedList<string, int>                         mMax;

        public                                                  SegmentBuilder(uint aFrameSize, bool aExcludeSingle)
        {
            mFrameSize = aFrameSize;

            if (Enabled)
            {
                mAreas      = new SortedList<string, SortedDictionary<int, List<ISegmentItem>>>(StringComparer.Ordinal);
                mCount      = new SortedList<string, int>(StringComparer.Ordinal);
                mMax        = new SortedList<string, int>(StringComparer.Ordinal);

                mExcludeSingle = aExcludeSingle;
            }
        }
    
        public void                                             addItem(string aArea, ISegmentItem aItem)
        {
            if (Enabled == false) return;    

            int lStart  = aItem.SegAddress;
            int lLength = aItem.SegLength;
            int lMax    = lStart + lLength - 1;

            if (mAreas.ContainsKey(aArea) == false)
            {
                mAreas.Add(aArea, new SortedDictionary<int, List<ISegmentItem>>());
                mCount.Add(aArea, 0);
                mMax.Add(aArea, lMax);
            }

            if (mAreas[aArea].ContainsKey(lStart) == false)
            {
                mAreas[aArea].Add(lStart, new List<ISegmentItem>());
            }

            mAreas[aArea][lStart].Add(aItem);
            mCount[aArea] = mCount[aArea] + 1;
            if (mMax[aArea] < lMax)
            {
                mMax[aArea] = lMax;
            }
        }
        
        private int                                             calcLength(ISegmentItem aItem, int aMax, int aStart, int aLength)
        {
            int lResult = aItem.SegAddress - aStart + aItem.SegLength;
            int lDiv    = lResult / (int)mFrameSize;
            if ((lResult % mFrameSize) > 0)
            {
                lDiv = lDiv + 1;
            }

            lResult = (int)mFrameSize * lDiv;

            if (aStart + lResult - 1 > aMax)
            {
                lResult = aMax - aStart + 1;
            }

            return lResult;
        }

        public Tuple<int[], int[], List<ISegmentItem>[]>        getSegments()
        {
            if (Enabled == false) return new Tuple<int[], int[], List<ISegmentItem>[]>(new int[0], new int[0], new List<ISegmentItem>[0]);

            SortedDictionary<int, List<ISegmentItem>> lArea;      
            int lSegmentID  = -1;
            var lSegStart   = new List<int>();
            var lSegLength  = new List<int>();
            var lSegMax     = new Dictionary<int, int>();
            var lAllSeg     = new Dictionary<int, List<ISegmentItem>>();
            
            bool lFirstSegOfArea;
            int lSegLastAddress;
            int lItemLastAddress;
            
            foreach (var lAreaName in mAreas.Keys)
            {
                lArea           = mAreas[lAreaName];
                lFirstSegOfArea = true;

                if (mExcludeSingle == false || mCount[lAreaName] > 1)
                {
                    foreach (int lStart in lArea.Keys)
                    {
                        foreach (ISegmentItem lItem in lArea[lStart])
                        {
                            if (lFirstSegOfArea)
                            {
                                lFirstSegOfArea = false;
                                lSegmentID      = lSegmentID + 1;
                                lSegStart.Add(lItem.SegAddress);
                                lSegLength.Add(calcLength(lItem, mMax[lAreaName], lSegStart[lSegmentID], 0));        
                            }

                            lSegLastAddress     = lSegStart[lSegmentID] + lSegLength[lSegmentID] - 1;
                            lItemLastAddress    = lItem.SegAddress + lItem.SegLength - 1;

                            if (lSegLastAddress < lItemLastAddress)
                            {
                                if (lItem.SegAddress <= lSegLastAddress)
                                {
                                    lSegLength[lSegmentID] = calcLength(lItem, mMax[lAreaName], lSegStart[lSegmentID], lSegLength[lSegmentID]);
                                }
                                else
                                {
                                    lSegmentID = lSegmentID + 1;
                                    lSegStart.Add(lItem.SegAddress);
                                    lSegLength.Add(calcLength(lItem, mMax[lAreaName], lSegStart[lSegmentID], 0));   
                                }
                            }

                            if (lAllSeg.ContainsKey(lSegmentID) == false)
                            {
                                lAllSeg.Add(lSegmentID, new List<ISegmentItem>());
                            }
                            lAllSeg[lSegmentID].Add(lItem); 

                            if (lSegMax.ContainsKey(lSegmentID))
                            {
                                if (lSegMax[lSegmentID] < lItemLastAddress)
                                {
                                    lSegMax[lSegmentID] = lItemLastAddress;
                                }
                            }
                            else
                            {
                                lSegMax.Add(lSegmentID, lItemLastAddress);
                            }
                        }
                    }
                }
            }

            if (mExcludeSingle)
            {
                var lKeys = lAllSeg.Keys.ToArray();
                for (int i = 0; i < lKeys.Length; i++)
                {
                    if (lAllSeg[lKeys[i]].Count < 2)
                    {
                        lAllSeg.Remove(lKeys[i]);
                    }
                }
            }

            var lResultStart    = new int[lAllSeg.Count];
            var lResultLength   = new int[lAllSeg.Count];
            var lResultItems    = new List<ISegmentItem>[lAllSeg.Count];
            lSegmentID          = 0;
            foreach (var lSeg in lAllSeg.Keys)
            {
                lResultStart[lSegmentID]    = lSegStart[lSeg];
                lResultLength[lSegmentID]   = lSegMax[lSeg] - lSegStart[lSeg] + 1;
                lResultItems[lSegmentID]    = lAllSeg[lSeg];

                foreach(var lItem in lAllSeg[lSeg])
                {
                    lItem.SegID = lSegmentID;
                }
                lSegmentID = lSegmentID + 1;
            }

            return new Tuple<int[], int[], List<ISegmentItem>[]>(lResultStart, lResultLength, lResultItems);
        }
    }
}

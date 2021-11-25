//****************************************************************************************************************************************************
//* BSD 3-Clause License
//*
//* Copyright (c) 2019, Mana Battery
//* All rights reserved.
//*
//* Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
//*
//* 1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//* 2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the
//*    documentation and/or other materials provided with the distribution.
//* 3. Neither the name of the copyright holder nor the names of its contributors may be used to endorse or promote products derived from this
//*    software without specific prior written permission.
//*
//* THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO,
//* THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
//* CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
//* PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
//* LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE,
//* EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//****************************************************************************************************************************************************

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

//----------------------------------------------------------------------------------------------------------------------------------------------------

namespace MB.Base.MathEx.Pixel
{
  public static class PxAvailableSizeUtil
  {
    // We use a range of positive numbers to simulate infinity and the infinity value we supply will be in the middle of this range.
    // As the range is fairly big and the expected numbers we work with are fairly small it should allow for code with slight errors
    // in the infinity handling to still produce a 'infinity' value when adding or subtracting from infinity.
    // (unless they subtract infinity or nan)
    public const Int64 InfiniteSpaceBeginPx = ((Int64)Int32.MaxValue) + 1;
    public const Int64 InfiniteSpaceEndPx = Int64.MaxValue;
    public const Int64 InfiniteSpacePx = InfiniteSpaceBeginPx + ((InfiniteSpaceEndPx - InfiniteSpaceBeginPx) / 2);

    /// <summary>
    /// lowest valid size value
    /// </summary>
    public const Int64 MinPx = 0;
    /// <summary>
    /// highest valid size value (the max value of a Int32)
    /// </summary>
    public const Int64 MaxPx = Int32.MaxValue;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Check if the given layout available space value is considered to be infinite space.
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsConsideredInfiniteSpace(Int64 x)
    {
      return x >= InfiniteSpaceBeginPx;
    }

    /// <summary>
    /// Check that the value is inside the normal value range
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNormalValue(Int64 x)
    {
      return x >= MinPx && x <= MaxPx;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int64 AddLayoutSizeNumber(Int64 sizePx, Int32 valuePx)
    {
      Debug.Assert(!IsNormalValue(sizePx) || ((sizePx + valuePx) < InfiniteSpaceBeginPx));
      return IsNormalValue(sizePx) ? Math.Max(sizePx + valuePx, 0) : sizePx;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int64 SubLayoutSizeNumber(Int64 sizePx, Int32 valuePx)
    {
      Debug.Assert(!IsNormalValue(sizePx) || ((sizePx + valuePx) < InfiniteSpaceBeginPx));
      return IsNormalValue(sizePx) ? Math.Max(sizePx - valuePx, 0) : sizePx;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int64 AddLayoutSizeLayoutSize(Int64 sizePx, Int64 valuePx)
    {
      if (IsNormalValue(sizePx))
      {
        if (IsNormalValue(valuePx))
        {
          Debug.Assert((sizePx + valuePx) < InfiniteSpaceBeginPx);
          return Math.Max(sizePx + valuePx, 0);
        }
        return valuePx;
      }
      // Size must be infinity, so it does not matter what the other value is
      return sizePx;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int64 SubLayoutSizeLayoutSize(Int64 sizePx, Int64 valuePx)
    {
      if (IsNormalValue(sizePx))
      {
        if (IsNormalValue(valuePx))
        {
          Debug.Assert((sizePx + valuePx) < InfiniteSpaceBeginPx);
          return Math.Max(sizePx - valuePx, 0);
        }
        return valuePx;
      }
      // Size must be infinity, so it does not matter what the other value is
      return sizePx;
    }
  }
}

//****************************************************************************************************************************************************

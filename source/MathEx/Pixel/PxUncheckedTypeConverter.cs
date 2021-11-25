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

using System.Diagnostics;
using System.Runtime.CompilerServices;

//----------------------------------------------------------------------------------------------------------------------------------------------------

namespace MB.Base.MathEx.Pixel
{
  public static class PxUncheckedTypeConverter
  {
    //------------------------------------------------------------------------------------------------------------------------------------------------
    #region ToPxAreaRectangleF

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxAreaRectangleF ToPxAreaRectangleF(PxRectangleU value)
      => new PxAreaRectangleF((float)value.Left, (float)value.Top, (float)value.Width, (float)value.Height);

    #endregion
    //------------------------------------------------------------------------------------------------------------------------------------------------
    #region ToPxClipRectangle

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxClipRectangle ToPxClipRectangle(PxRectangle value) => new PxClipRectangle(value.Left, value.Top, value.Width, value.Height);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxClipRectangle ToPxClipRectangle(PxRectangleU value)
      => new PxClipRectangle(UncheckedNumericCast.ToInt32(value.Left), UncheckedNumericCast.ToInt32(value.Top),
                             UncheckedNumericCast.ToInt32(value.Width), UncheckedNumericCast.ToInt32(value.Height));

    #endregion
    //------------------------------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------------------------------------------------------------
    #region ToPxExtent2D

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxExtent2D ToPxExtent2D(PxPoint2 value)
      => new PxExtent2D(UncheckedNumericCast.ToUInt32(value.X), UncheckedNumericCast.ToUInt32(value.Y));

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxExtent2D ToPxExtent2D(PxSize2D value)
      => new PxExtent2D(UncheckedNumericCast.ToUInt32(value.Width), UncheckedNumericCast.ToUInt32(value.Height));

    #endregion
    //------------------------------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------------------------------------------------------------
    #region ToPxPoint2

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2 ToPxPoint2(PxExtent2D value)
      => new PxPoint2(UncheckedNumericCast.ToInt32(value.Width), UncheckedNumericCast.ToInt32(value.Height));

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2 ToPxPoint2(PxPoint2U value) => new PxPoint2(UncheckedNumericCast.ToInt32(value.X), UncheckedNumericCast.ToInt32(value.Y));

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2 ToPxPoint2(PxSize2D value) => new PxPoint2(value.Width, value.Height);

    #endregion
    //------------------------------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------------------------------------------------------------
    #region ToPxPoint2U

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2U ToPxPoint2U(PxExtent2D value) => new PxPoint2U(value.Width, value.Height);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2U ToPxPoint2U(PxPoint2 value)
      => new PxPoint2U(UncheckedNumericCast.ToUInt32(value.X), UncheckedNumericCast.ToUInt32(value.Y));

    #endregion
    //------------------------------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------------------------------------------------------------
    #region ToPxSize2D

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize2D ToPxSize2D(PxPoint2 value)
    {
      Debug.Assert(value.X >= 0);
      Debug.Assert(value.Y >= 0);
      return new PxSize2D(value.X, value.Y, OptimizationCheckFlag.NoCheck);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize2D ToPxSize2D(PxExtent2D value)
      => new PxSize2D(UncheckedNumericCast.ToInt32(value.Width), UncheckedNumericCast.ToInt32(value.Height), OptimizationCheckFlag.NoCheck);

    #endregion
    //------------------------------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------------------------------------------------------------
    #region ToPxRectangle

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxRectangle ToPxRectangle(in PxRectangleU value)
      => new PxRectangle(UncheckedNumericCast.ToInt32(value.X), UncheckedNumericCast.ToInt32(value.Y),
                         UncheckedNumericCast.ToInt32(value.Width), UncheckedNumericCast.ToInt32(value.Height));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxRectangle ToPxRectangle(PxRectangleM value)
      => new PxRectangle(value.X, value.Y, value.Width, value.Height);

    #endregion
    //------------------------------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------------------------------------------------------------
    #region ToPxRectangleU

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxRectangleU ToPxRectangleU(in PxRectangle value)
      => new PxRectangleU(UncheckedNumericCast.ToUInt32(value.X), UncheckedNumericCast.ToUInt32(value.Y),
                          UncheckedNumericCast.ToUInt32(value.Width), UncheckedNumericCast.ToUInt32(value.Height));


    #endregion
    //------------------------------------------------------------------------------------------------------------------------------------------------


    //------------------------------------------------------------------------------------------------------------------------------------------------
    #region ToPxThickness

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxThickness ToPxThickness(in PxThicknessU value)
      => new PxThickness(UncheckedNumericCast.ToInt32(value.Left), UncheckedNumericCast.ToInt32(value.Top),
                         UncheckedNumericCast.ToInt32(value.Right), UncheckedNumericCast.ToInt32(value.Bottom));

    #endregion
    //------------------------------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------------------------------------------------------------
    #region ToPxThicknessU

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxThicknessU ToPxThicknessU(in PxThickness value)
      => new PxThicknessU(UncheckedNumericCast.ToUInt32(value.Left), UncheckedNumericCast.ToUInt32(value.Top),
                          UncheckedNumericCast.ToUInt32(value.Right), UncheckedNumericCast.ToUInt32(value.Bottom));

    #endregion
    //------------------------------------------------------------------------------------------------------------------------------------------------
  }

}

//****************************************************************************************************************************************************

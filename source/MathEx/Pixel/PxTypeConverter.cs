#nullable enable
//****************************************************************************************************************************************************
//* BSD 3-Clause License
//*
//* Copyright (c) 2019-2024, Mana Battery
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

using MB.Base.Exceptions;
using System.Runtime.CompilerServices;

//----------------------------------------------------------------------------------------------------------------------------------------------------

namespace MB.Base.MathEx.Pixel
{
  public static class PxTypeConverter
  {
    //------------------------------------------------------------------------------------------------------------------------------------------------
    // ToPxAreaRectangleF
    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxAreaRectangleF ToPxAreaRectangleF(in PxRectangle value)
      => new PxAreaRectangleF((float)value.Left, (float)value.Top, (float)value.Width, (float)value.Height);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxAreaRectangleF ToPxAreaRectangleF(in PxRectangleU value)
      => new PxAreaRectangleF((float)value.Left, (float)value.Top, (float)value.Width, (float)value.Height);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxAreaRectangleF ToPxAreaRectangleF(in PxClipRectangle value)
      => PxAreaRectangleF.FromLeftTopRightBottom((float)value.Left, (float)value.Top, (float)value.Right, (float)value.Bottom, OptimizationCheckFlag.NoCheck);

    //------------------------------------------------------------------------------------------------------------------------------------------------
    // ToPxClipRectangle
    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxClipRectangle ToPxClipRectangle(in PxRectangle value) => new PxClipRectangle(value.Left, value.Top, value.Width, value.Height);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxClipRectangle ToPxClipRectangle(in PxRectangleU value)
      => new PxClipRectangle(NumericCast.ToInt32(value.Left), NumericCast.ToInt32(value.Top),
                             NumericCast.ToInt32(value.Width), NumericCast.ToInt32(value.Height));

    //------------------------------------------------------------------------------------------------------------------------------------------------
    // ToPxExtent2D
    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxExtent2D ToPxExtent2D(PxPoint2 value) => new PxExtent2D(NumericCast.ToUInt32(value.X), NumericCast.ToUInt32(value.Y));

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxExtent2D ToPxExtent2D(PxSize2D value) => new PxExtent2D(NumericCast.ToUInt32(value.Width), NumericCast.ToUInt32(value.Height));

    //------------------------------------------------------------------------------------------------------------------------------------------------
    // ToPxFloat2
    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxFloat2 ToPxFloat2(PxPoint2 value) => new PxFloat2(value.X, value.Y);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxFloat2 ToPxFloat2(PxSize2D value) => new PxFloat2(value.Width, value.Height);

    //------------------------------------------------------------------------------------------------------------------------------------------------
    // ToPxPoint2
    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2 ToPxPoint2(PxExtent2D value) => new PxPoint2(NumericCast.ToInt32(value.Width), NumericCast.ToInt32(value.Height));

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2 ToPxPoint2(PxPoint2U value) => new PxPoint2(NumericCast.ToInt32(value.X), NumericCast.ToInt32(value.Y));

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2 ToPxPoint2(PxSize2D value) => new PxPoint2(value.Width, value.Height);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2 ToRoundedPxPoint2(PxFloat2 value) => new PxPoint2(MathUtil.RoundToInt32(value.X), MathUtil.RoundToInt32(value.Y));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize2D ToRoundedPxSize2D(PxFloat2 value) => new PxSize2D(MathUtil.RoundToInt32(value.X), MathUtil.RoundToInt32(value.Y));


    //------------------------------------------------------------------------------------------------------------------------------------------------
    // ToPxPoint2U
    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2U ToPxPoint2U(PxExtent2D value) => new PxPoint2U(value.Width, value.Height);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2U ToPxPoint2U(PxPoint2 value) => new PxPoint2U(NumericCast.ToUInt32(value.X), NumericCast.ToUInt32(value.Y));

    //------------------------------------------------------------------------------------------------------------------------------------------------
    // ToPxSize1D
    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1D ToPxSize1D(PxSize1DF value) => PxSize1D.UncheckedCreate(MathUtil.RoundToInt32(value.RawValue));

    //------------------------------------------------------------------------------------------------------------------------------------------------
    // ToPxSize2D
    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize2D ToPxSize2D(PxPoint2 value)
    {
      if (value.X < 0 || value.Y < 0)
        throw new ConversionUnderflowException("PxSize2D can not contain negative values");
      return new PxSize2D(value.X, value.Y, OptimizationCheckFlag.NoCheck);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize2D ToPxSize2D(PxExtent2D value)
      => new PxSize2D(NumericCast.ToInt32(value.Width), NumericCast.ToInt32(value.Height), OptimizationCheckFlag.NoCheck);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize2D ToPxSize2D(PxSize2DF value)
      => new PxSize2D(MathUtil.RoundToInt32(value.Width), MathUtil.RoundToInt32(value.Height), OptimizationCheckFlag.NoCheck);

    //------------------------------------------------------------------------------------------------------------------------------------------------
    // ToPxSize2DF
    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize2DF ToPxSize2DF(PxPoint2 value)
    {
      if (value.X < 0 || value.Y < 0)
        throw new ConversionUnderflowException("PxSize2DF can not contain negative values");
      return new PxSize2DF(value.X, value.Y, OptimizationCheckFlag.NoCheck);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize2DF ToPxSize2DF(PxSize2D value)
      => new PxSize2DF(value.Width, value.Height, OptimizationCheckFlag.NoCheck);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize2DF ToPxSize2DF(PxExtent2D value)
      => new PxSize2DF(value.Width, value.Height, OptimizationCheckFlag.NoCheck);

    //------------------------------------------------------------------------------------------------------------------------------------------------
    // ToPxRectangle
    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxRectangle ToPxRectangle(in PxRectangleU value)
      => new PxRectangle(NumericCast.ToInt32(value.X), NumericCast.ToInt32(value.Y), NumericCast.ToInt32(value.Width),
                         NumericCast.ToInt32(value.Height));

    //------------------------------------------------------------------------------------------------------------------------------------------------
    // ToPxRectangleF
    //------------------------------------------------------------------------------------------------------------------------------------------------

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static PxRectangleF ToPxRectangleF(in PxRectangle value)
    //  => new PxRectangleF(value.X, value.Y, value.Width, value.Height);

    //------------------------------------------------------------------------------------------------------------------------------------------------
    // ToPxRectangleU
    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxRectangleU ToPxRectangleU(in PxRectangle value)
      => new PxRectangleU(NumericCast.ToUInt32(value.X), NumericCast.ToUInt32(value.Y), NumericCast.ToUInt32(value.Width),
                          NumericCast.ToUInt32(value.Height));

    //------------------------------------------------------------------------------------------------------------------------------------------------
    // ToPxThickness
    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxThickness ToPxThickness(in PxThicknessU value)
      => new PxThickness(NumericCast.ToInt32(value.Left), NumericCast.ToInt32(value.Top), NumericCast.ToInt32(value.Right),
                         NumericCast.ToInt32(value.Bottom));

    //------------------------------------------------------------------------------------------------------------------------------------------------
    // ToPxThicknessF
    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxThicknessF ToPxThicknessF(in PxThickness value)
      => new PxThicknessF(value.Left, value.Top, value.Right, value.Bottom);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxThicknessF ToPxThicknessF(in PxThicknessU value)
      => new PxThicknessF(value.Left, value.Top, value.Right, value.Bottom);

    //------------------------------------------------------------------------------------------------------------------------------------------------
    // ToPxThicknessU
    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxThicknessU ToPxThicknessU(in PxThickness value)
      => new PxThicknessU(NumericCast.ToUInt32(value.Left), NumericCast.ToUInt32(value.Top), NumericCast.ToUInt32(value.Right),
                          NumericCast.ToUInt32(value.Bottom));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxThicknessU16 ToPxThicknessU16(in PxThickness value)
      => new PxThicknessU16(NumericCast.ToUInt16(value.Left), NumericCast.ToUInt16(value.Top),
                            NumericCast.ToUInt16(value.Right), NumericCast.ToUInt16(value.Bottom));

  }

}

//****************************************************************************************************************************************************

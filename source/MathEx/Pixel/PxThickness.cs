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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

//----------------------------------------------------------------------------------------------------------------------------------------------------

namespace MB.Base.MathEx.Pixel
{
  [Serializable]
  public readonly struct PxThickness : IEquatable<PxThickness>
  {
    public readonly Int32 Left;
    public readonly Int32 Top;
    public readonly Int32 Right;
    public readonly Int32 Bottom;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxThickness(Int32 lengthPx)
      : this(lengthPx, lengthPx, lengthPx, lengthPx)
    {
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxThickness(Int32 leftPx, Int32 topPx, Int32 rightPx, Int32 bottomPx)
    {
      Left = Math.Max(leftPx, 0);
      Top = Math.Max(topPx, 0);
      Right = Math.Max(rightPx, 0);
      Bottom = Math.Max(bottomPx, 0);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter",
                                                     Justification = "Used to select this constructor variant")]
    public PxThickness(Int32 leftPx, Int32 topPx, Int32 rightPx, Int32 bottomPx, OptimizationCheckFlag optimizationFlag)
    {
      Debug.Assert(leftPx >= 0);
      Debug.Assert(topPx >= 0);
      Debug.Assert(rightPx >= 0);
      Debug.Assert(bottomPx >= 0);
      Debug.Assert(optimizationFlag == OptimizationCheckFlag.NoCheck);    // remove warning

      Left = leftPx;
      Top = topPx;
      Right = rightPx;
      Bottom = bottomPx;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public PxPoint2 TopLeft => new PxPoint2(Left, Top);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public PxPoint2 TopRight => new PxPoint2(Right, Top);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public PxPoint2 BottomLeft => new PxPoint2(Left, Bottom);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public PxPoint2 BottomRight => new PxPoint2(Right, Bottom);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public Int32 SumX => Left + Right;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public Int32 SumY => Top + Bottom;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public PxSize2D Sum => new PxSize2D(Left + Right, Top + Bottom);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public bool IsEmpty => Left == 0 && Top == 0 && Right == 0 && Bottom == 0;



    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Add two PxPoint2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxThickness operator +(in PxThickness lhs, in PxThickness rhs)
    {
      Debug.Assert(lhs.Left <= (Int32.MaxValue - rhs.Left));
      Debug.Assert(lhs.Top <= (Int32.MaxValue - rhs.Top));
      Debug.Assert(lhs.Right <= (Int32.MaxValue - rhs.Right));
      Debug.Assert(lhs.Bottom <= (Int32.MaxValue - rhs.Bottom));
      return new PxThickness(lhs.Left + rhs.Left, lhs.Top + rhs.Top, lhs.Right + rhs.Right, lhs.Bottom + rhs.Bottom);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]

    public static PxThickness Multiply(PxThickness sizePx, UInt16 value)
    {
      return new PxThickness(sizePx.Left * value, sizePx.Top * value, sizePx.Right * value, sizePx.Bottom * value, OptimizationCheckFlag.NoCheck);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]

    public static PxThickness Divide(PxThickness sizePx, Int32 value)
    {
      Debug.Assert(value != 0);
      return new PxThickness(sizePx.Left / value, sizePx.Top / value, sizePx.Right / value, sizePx.Bottom / value, OptimizationCheckFlag.NoCheck);
    }


    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Check if a thickness is equal to another thickness
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(in PxThickness v1, in PxThickness v2)
      => (v1.Left == v2.Left) && (v1.Top == v2.Top) && (v1.Right == v2.Right) && (v1.Bottom == v2.Bottom);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Check if a thickness is not equal to another thickness
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(in PxThickness v1, in PxThickness v2) => !(v1 == v2);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is PxThickness other && this == other;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => (Left ^ Top ^ Right ^ Bottom).GetHashCode();

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"Left:{Left} Top:{Top} Right:{Right} Bottom:{Bottom}";

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxThickness Min(in PxThickness val0, in PxThickness val1)
      => new PxThickness(Math.Min(val0.Left, val1.Left), Math.Min(val0.Top, val1.Top), Math.Min(val0.Right, val1.Right),
                         Math.Min(val0.Bottom, val1.Bottom), OptimizationCheckFlag.NoCheck);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxThickness Max(in PxThickness val0, in PxThickness val1)
      => new PxThickness(Math.Max(val0.Left, val1.Left), Math.Max(val0.Top, val1.Top), Math.Max(val0.Right, val1.Right),
                         Math.Max(val0.Bottom, val1.Bottom), OptimizationCheckFlag.NoCheck);

    //------------------------------------------------------------------------------------------------------------------------------------------------
    #region IEquatable<PxThickness> Members
    //------------------------------------------------------------------------------------------------------------------------------------------------

    public bool Equals(PxThickness other)
      => (Left == other.Left) && (Top == other.Top) && (Right == other.Right) && (Bottom == other.Bottom);

    //------------------------------------------------------------------------------------------------------------------------------------------------
    #endregion
    //------------------------------------------------------------------------------------------------------------------------------------------------
  }

}

//****************************************************************************************************************************************************

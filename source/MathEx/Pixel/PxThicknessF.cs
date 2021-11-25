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
  public readonly struct PxThicknessF : IEquatable<PxThicknessF>
  {
    public readonly float Left;
    public readonly float Top;
    public readonly float Right;
    public readonly float Bottom;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxThicknessF(float lengthPx)
      : this(lengthPx, lengthPx, lengthPx, lengthPx)
    {
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxThicknessF(float leftPx, float topPx, float rightPx, float bottomPx)
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
    public PxThicknessF(float leftPx, float topPx, float rightPx, float bottomPx, OptimizationCheckFlag optimizationFlag)
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

    public PxFloat2 TopLeft => new PxFloat2(Left, Top);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public PxFloat2 TopRight => new PxFloat2(Right, Top);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public PxFloat2 BottomLeft => new PxFloat2(Left, Bottom);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public PxFloat2 BottomRight => new PxFloat2(Right, Bottom);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public float SumX => Left + Right;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public float SumY => Top + Bottom;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public PxSize2DF Sum => new PxSize2DF(Left + Right, Top + Bottom);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public bool IsEmpty => Left == 0 && Top == 0 && Right == 0 && Bottom == 0;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Check if a thickness is equal to another thickness
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(in PxThicknessF v1, in PxThicknessF v2)
      => (v1.Left == v2.Left) && (v1.Top == v2.Top) && (v1.Right == v2.Right) && (v1.Bottom == v2.Bottom);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Check if a thickness is not equal to another thickness
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(in PxThicknessF v1, in PxThicknessF v2) => !(v1 == v2);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is PxThicknessF other && this == other;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => Left.GetHashCode() ^ Top.GetHashCode() ^ Right.GetHashCode() ^ Bottom.GetHashCode();

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString()
    {
      return $"Left:{Left} Top:{Top} Right:{Right} Bottom:{Bottom}";
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxThicknessF Min(in PxThicknessF val0, in PxThicknessF val1)
      => new PxThicknessF(Math.Min(val0.Left, val1.Left), Math.Min(val0.Top, val1.Top), Math.Min(val0.Right, val1.Right),
                         Math.Min(val0.Bottom, val1.Bottom), OptimizationCheckFlag.NoCheck);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxThicknessF Max(in PxThicknessF val0, in PxThicknessF val1)
      => new PxThicknessF(Math.Max(val0.Left, val1.Left), Math.Max(val0.Top, val1.Top), Math.Max(val0.Right, val1.Right),
                         Math.Max(val0.Bottom, val1.Bottom), OptimizationCheckFlag.NoCheck);

    //------------------------------------------------------------------------------------------------------------------------------------------------
    #region IEquatable<PxThicknessF> Members
    //------------------------------------------------------------------------------------------------------------------------------------------------

    public bool Equals(PxThicknessF other)
      => (Left == other.Left) && (Top == other.Top) && (Right == other.Right) && (Bottom == other.Bottom);

    //------------------------------------------------------------------------------------------------------------------------------------------------
    #endregion
    //------------------------------------------------------------------------------------------------------------------------------------------------
  }

}

//****************************************************************************************************************************************************

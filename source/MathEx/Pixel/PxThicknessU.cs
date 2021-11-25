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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

//----------------------------------------------------------------------------------------------------------------------------------------------------

namespace MB.Base.MathEx.Pixel
{
  [Serializable]
  public readonly struct PxThicknessU : IEquatable<PxThicknessU>
  {
    public readonly UInt32 Left;
    public readonly UInt32 Top;
    public readonly UInt32 Right;
    public readonly UInt32 Bottom;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxThicknessU(UInt32 lenPx)
      : this(lenPx, lenPx, lenPx, lenPx)
    {
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxThicknessU(UInt32 leftPx, UInt32 topPx, UInt32 rightPx, UInt32 bottomPx)
    {
      Left = leftPx;
      Top = topPx;
      Right = rightPx;
      Bottom = bottomPx;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public UInt32 SumX => Left + Right;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public UInt32 SumY => Top + Bottom;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public PxExtent2D Sum => new PxExtent2D(Left + Right, Top + Bottom);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public bool IsEmpty => Left == 0 && Top == 0 && Right == 0 && Bottom == 0;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public PxExtent2D TopLeft => new PxExtent2D(Left, Top);
    public PxExtent2D TopRight => new PxExtent2D(Right, Top);
    public PxExtent2D BottomLeft => new PxExtent2D(Left, Bottom);
    public PxExtent2D BottomRight => new PxExtent2D(Right, Bottom);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Check if a thickness is equal to another thickness
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(in PxThicknessU v1, in PxThicknessU v2) => (v1.Left == v2.Left) && (v1.Top == v2.Top) && (v1.Right == v2.Right) && (v1.Bottom == v2.Bottom);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Check if a thickness is not equal to another thickness
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(in PxThicknessU v1, in PxThicknessU v2) => !(v1 == v2);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is PxThicknessU other && this == other;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => (Left ^ Top ^ Right ^ Bottom).GetHashCode();

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"Left:{Left} Top:{Top} Right:{Right} Bottom:{Bottom}";


    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxThicknessU Min(in PxThicknessU val0, in PxThicknessU val1)
      => new PxThicknessU(Math.Min(val0.Left, val1.Left), Math.Min(val0.Top, val1.Top), Math.Min(val0.Right, val1.Right),
                          Math.Min(val0.Bottom, val1.Bottom));

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxThicknessU Max(in PxThicknessU val0, in PxThicknessU val1)
      => new PxThicknessU(Math.Max(val0.Left, val1.Left), Math.Max(val0.Top, val1.Top), Math.Max(val0.Right, val1.Right),
                          Math.Max(val0.Bottom, val1.Bottom));

    //------------------------------------------------------------------------------------------------------------------------------------------------
    #region IEquatable < PxThicknessU> Members
    //------------------------------------------------------------------------------------------------------------------------------------------------

    public bool Equals(PxThicknessU other)
    {
      return (Left == other.Left) && (Top == other.Top) && (Right == other.Right) && (Bottom == other.Bottom);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------
    #endregion
    //------------------------------------------------------------------------------------------------------------------------------------------------
  }

}

//****************************************************************************************************************************************************

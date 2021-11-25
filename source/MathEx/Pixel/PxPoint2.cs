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
  public struct PxPoint2 : IEquatable<PxPoint2>
  {
    public Int32 X;
    public Int32 Y;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxPoint2(Int32 xPx, Int32 yPx)
    {
      X = xPx;
      Y = yPx;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    #region Operators

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Add
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2 operator +(PxPoint2 lhs, PxPoint2 rhs) => new PxPoint2(lhs.X + rhs.X, lhs.Y + rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Add
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2 operator +(PxPoint2 lhs, PxSize2D rhs) => new PxPoint2(lhs.X + rhs.Width, lhs.Y + rhs.Height);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Add
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2 operator +(PxSize2D lhs, PxPoint2 rhs) => new PxPoint2(lhs.Width + rhs.X, lhs.Height + rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Substract
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2 operator -(PxPoint2 lhs, PxPoint2 rhs) => new PxPoint2(lhs.X - rhs.X, lhs.Y - rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Substract
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2 operator -(PxPoint2 lhs, PxSize2D rhs) => new PxPoint2(lhs.X - rhs.Width, lhs.Y - rhs.Height);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Substract
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2 operator -(PxSize2D lhs, PxPoint2 rhs) => new PxPoint2(lhs.Width - rhs.X, lhs.Height - rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Multiply two PxPoint2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2 operator *(PxPoint2 lhs, PxPoint2 rhs) => new PxPoint2(lhs.X * rhs.X, lhs.Y * rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Multiply two PxPoint2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2 operator *(PxPoint2 lhs, PxSize2D rhs) => new PxPoint2(lhs.X * rhs.Width, lhs.Y * rhs.Height);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Multiply two PxPoint2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2 operator *(PxSize2D lhs, PxPoint2 rhs) => new PxPoint2(lhs.Width * rhs.X, lhs.Height * rhs.Y);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Multiply PxPoint2 by scalar
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2 operator *(PxPoint2 lhs, Int32 rhs) => new PxPoint2(lhs.X * rhs, lhs.Y * rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Multiply scalar by PxPoint2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2 operator *(Int32 lhs, PxPoint2 rhs) => new PxPoint2(lhs * rhs.X, lhs * rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Divide two PxPoint2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2 operator /(PxPoint2 lhs, PxPoint2 rhs) => new PxPoint2(lhs.X / rhs.X, lhs.Y / rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Divide PxPoint2 by scalar
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2 operator /(PxPoint2 lhs, Int32 rhs) => new PxPoint2(lhs.X / rhs, lhs.Y / rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Invert
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2 operator -(PxPoint2 value) => new PxPoint2(-value.X, -value.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PxPoint2 lhs, PxPoint2 rhs) => (lhs.X == rhs.X && lhs.Y == rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PxPoint2 lhs, PxPoint2 rhs) => !(lhs == rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is PxPoint2 other && (this == other);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode();

    //------------------------------------------------------------------------------------------------------------------------------------------------


    public bool Equals(PxPoint2 other) => X == other.X && Y == other.Y;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"X:{X} Y:{Y}";

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2 Min(PxPoint2 val0, PxPoint2 val1) => new PxPoint2(Math.Min(val0.X, val1.X), Math.Min(val0.Y, val1.Y));

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2 Max(PxPoint2 val0, PxPoint2 val1) => new PxPoint2(Math.Max(val0.X, val1.X), Math.Max(val0.Y, val1.Y));

    #endregion
  }
}

//****************************************************************************************************************************************************

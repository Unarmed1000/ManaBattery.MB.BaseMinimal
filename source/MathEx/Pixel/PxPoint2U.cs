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

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

//----------------------------------------------------------------------------------------------------------------------------------------------------

namespace MB.Base.MathEx.Pixel
{
  [Serializable]
  public struct PxPoint2U : IEquatable<PxPoint2U>
  {
    public UInt32 X;
    public UInt32 Y;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxPoint2U(UInt32 xPx, UInt32 yPx)
    {
      X = xPx;
      Y = yPx;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------
    // Operators
    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Add two PxPoint2U
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2U operator +(PxPoint2U lhs, PxPoint2U rhs) => new PxPoint2U(lhs.X + rhs.X, lhs.Y + rhs.Y);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Substract two PxPoint2U
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2U operator -(PxPoint2U lhs, PxPoint2U rhs)
    {
      Debug.Assert(lhs.X >= rhs.X);
      Debug.Assert(lhs.Y >= rhs.Y);
      return new PxPoint2U(lhs.X - rhs.X, lhs.Y - rhs.Y);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Multiply two PxPoint2U
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2U operator *(PxPoint2U lhs, PxPoint2U rhs) => new PxPoint2U(lhs.X * rhs.X, lhs.Y * rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Multiply PxPoint2U by scalar
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2U operator *(PxPoint2U lhs, UInt32 rhs) => new PxPoint2U(lhs.X * rhs, lhs.Y * rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Multiply scalar by PxPoint2U
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2U operator *(UInt32 lhs, PxPoint2U rhs) => new PxPoint2U(lhs * rhs.X, lhs * rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Divide two PxPoint2U
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2U operator /(PxPoint2U lhs, PxPoint2U rhs) => new PxPoint2U(lhs.X / rhs.X, lhs.Y / rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Divide PxPoint2U by scalar
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2U operator /(PxPoint2U lhs, UInt32 rhs) => new PxPoint2U(lhs.X / rhs, lhs.Y / rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PxPoint2U lhs, PxPoint2U rhs) => (lhs.X == rhs.X && lhs.Y == rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PxPoint2U lhs, PxPoint2U rhs) => !(lhs == rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is PxPoint2U other && (this == other);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode();

    //------------------------------------------------------------------------------------------------------------------------------------------------


    public bool Equals(PxPoint2U other) => X == other.X && Y == other.Y;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"X:{X} Y:{Y}";

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2U Min(PxPoint2U val0, PxPoint2U val1) => new PxPoint2U(Math.Min(val0.X, val1.X), Math.Min(val0.Y, val1.Y));

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxPoint2U Max(PxPoint2U val0, PxPoint2U val1) => new PxPoint2U(Math.Max(val0.X, val1.X), Math.Max(val0.Y, val1.Y));
  }
}

//****************************************************************************************************************************************************

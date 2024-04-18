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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

//----------------------------------------------------------------------------------------------------------------------------------------------------

namespace MB.Base.MathEx.Pixel
{
  /// <summary>
  /// Since the sizeof(PxFloat2) is 8 it will be &lt;= IntPtr.Size, so we dont use "in" on parameters
  /// </summary>
  [Serializable]
  public struct PxFloat2 : IEquatable<PxFloat2>
  {
    public float X;
    public float Y;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxFloat2(float xPx, float yPx)
    {
      X = xPx;
      Y = yPx;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Calculate the length of a Float2
    /// </summary>
    /// <returns></returns>
    public readonly float Length => (float)Math.Sqrt((X * X) + (Y * Y));

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Calculate the squared length of a Float2
    /// </summary>
    /// <returns></returns>

    public readonly float LengthSquared => (X * X) + (Y * Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Normalize a float 2
    /// </summary>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxFloat2 Normalize(PxFloat2 input)
    {
      float val = 1.0f / (float)Math.Sqrt((input.X * input.X) + (input.Y * input.Y));
      return new PxFloat2(input.X * val, input.Y * val);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Invert the float2
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxFloat2 operator -(PxFloat2 value) => new PxFloat2(-value.X, -value.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Add two float2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxFloat2 operator +(PxFloat2 lhs, PxFloat2 rhs) => new PxFloat2(lhs.X + rhs.X, lhs.Y + rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Add two float2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxFloat2 operator +(PxFloat2 lhs, PxExtent2D rhs) => new PxFloat2(lhs.X + rhs.Width, lhs.Y + rhs.Height);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Add two float2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxFloat2 operator +(PxExtent2D lhs, PxFloat2 rhs) => new PxFloat2(lhs.Width + rhs.X, lhs.Height + rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Add
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxFloat2 operator +(PxFloat2 lhs, PxSize2DF rhs) => new PxFloat2(lhs.X + rhs.Width, lhs.Y + rhs.Height);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Add
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxFloat2 operator +(PxSize2DF lhs, PxFloat2 rhs) => new PxFloat2(lhs.Width + rhs.X, lhs.Height + rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Substract two float2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxFloat2 operator -(PxFloat2 lhs, PxFloat2 rhs) => new PxFloat2(lhs.X - rhs.X, lhs.Y - rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Multiply two float2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxFloat2 operator *(PxFloat2 lhs, PxFloat2 rhs) => new PxFloat2(lhs.X * rhs.X, lhs.Y * rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Multiply float2 by scalar
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxFloat2 operator *(PxFloat2 lhs, float rhs) => new PxFloat2(lhs.X * rhs, lhs.Y * rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Multiply scalar by float2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxFloat2 operator *(float lhs, PxFloat2 rhs) => new PxFloat2(rhs.X * lhs, rhs.Y * lhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Divide two float2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxFloat2 operator /(PxFloat2 lhs, PxFloat2 rhs) => new PxFloat2(lhs.X / rhs.X, lhs.Y / rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Divide float2 by scalar
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxFloat2 operator /(PxFloat2 lhs, float rhs) => new PxFloat2(lhs.X / rhs, lhs.Y / rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PxFloat2 lhs, PxFloat2 rhs) => (lhs.X == rhs.X && lhs.Y == rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PxFloat2 lhs, PxFloat2 rhs) => !(lhs == rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is PxFloat2 other && (this == other);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode();

    //------------------------------------------------------------------------------------------------------------------------------------------------


    public bool Equals(PxFloat2 other) => X == other.X && Y == other.Y;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"{{X:{X} Y:{Y}}}";

    //------------------------------------------------------------------------------------------------------------------------------------------------
  }
}

//****************************************************************************************************************************************************

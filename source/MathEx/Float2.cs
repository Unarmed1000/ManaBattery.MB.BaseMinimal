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

namespace MB.Base.MathEx
{
  /// <summary>
  /// Represents a single float point
  /// </summary>
  [Serializable]
  [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
  public struct Float2 : IEquatable<Float2>
  {
    public float X;
    public float Y;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Float2(float x, float y)
    {
      X = x;
      Y = y;
    }

    // Swizzle the components
    public readonly Float2 YX => new Float2(Y, X);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Invert the float2
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Float2 operator -(Float2 value) => new Float2(-value.X, -value.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Add two float2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Float2 operator +(Float2 lhs, Float2 rhs) => new Float2(lhs.X + rhs.X, lhs.Y + rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Add two float2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Float2 operator +(Float2 lhs, Point2 rhs) => new Float2(lhs.X + rhs.X, lhs.Y + rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Add two float2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Float2 operator +(Float2 lhs, Point2U rhs) => new Float2(lhs.X + rhs.X, lhs.Y + rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Add two float2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Float2 operator +(Float2 lhs, Extent2D rhs) => new Float2(lhs.X + rhs.Width, lhs.Y + rhs.Height);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Add two float2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Float2 operator +(Extent2D lhs, Float2 rhs) => new Float2(lhs.Width + rhs.X, lhs.Height + rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Substract two float2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Float2 operator -(Float2 lhs, Float2 rhs) => new Float2(lhs.X - rhs.X, lhs.Y - rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Multiply two float2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Float2 operator *(Float2 lhs, Float2 rhs) => new Float2(lhs.X * rhs.X, lhs.Y * rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Multiply float2 by scalar
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Float2 operator *(Float2 lhs, float rhs) => new Float2(lhs.X * rhs, lhs.Y * rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Multiply scalar by float2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Float2 operator *(float lhs, Float2 rhs) => new Float2(lhs * rhs.X, lhs * rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Divide two float2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Float2 operator /(Float2 lhs, Float2 rhs) => new Float2(lhs.X / rhs.X, lhs.Y / rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Divide float2 by scalar
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Float2 operator /(Float2 lhs, float rhs) => new Float2(lhs.X / rhs, lhs.Y / rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Float2 lhs, Float2 rhs) => (lhs.X == rhs.X && lhs.Y == rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Float2 lhs, Float2 rhs) => !(lhs == rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [ObsoleteAttribute]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Add(ref Float2 lhs, ref Float2 rhs, out Float2 rResult)
    {
      rResult.X = lhs.X + rhs.X;
      rResult.Y = lhs.Y + rhs.Y;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [ObsoleteAttribute]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref Float2 lhs, ref Float2 rhs, out Float2 rResult)
    {
      rResult.X = lhs.X / rhs.X;
      rResult.Y = lhs.Y / rhs.Y;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [ObsoleteAttribute]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Multiply(ref Float2 lhs, ref Float2 rhs, out Float2 rResult)
    {
      rResult.X = lhs.X * rhs.X;
      rResult.Y = lhs.Y * rhs.Y;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [ObsoleteAttribute]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Substract(ref Float2 lhs, ref Float2 rhs, out Float2 rResult)
    {
      rResult.X = lhs.X - rhs.X;
      rResult.Y = lhs.Y - rhs.Y;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Dot(Float2 value1, Float2 value2) => (value1.X * value2.X) + (value1.Y * value2.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is Float2 other && (this == other);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode();

    //------------------------------------------------------------------------------------------------------------------------------------------------


    public bool Equals(Float2 other) => X == other.X && Y == other.Y;

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
    public void Normalize()
    {
      float val = 1.0f / (float)Math.Sqrt((X * X) + (Y * Y));
      X *= val;
      Y *= val;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Normalize a float 2
    /// </summary>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Float2 Normalize(Float2 input)
    {
      float val = 1.0f / (float)Math.Sqrt((input.X * input.X) + (input.Y * input.Y));
      return new Float2(input.X * val, input.Y * val);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"{{X:{X} Y:{Y}}}";

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Float2 Min(Float2 val0, Float2 val1) => new Float2(Math.Min(val0.X, val1.X), Math.Min(val0.Y, val1.Y));

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Float2 Max(Float2 val0, Float2 val1) => new Float2(Math.Max(val0.X, val1.X), Math.Max(val0.Y, val1.Y));
  }
}

//****************************************************************************************************************************************************

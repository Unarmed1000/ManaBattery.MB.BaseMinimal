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
  public struct Float4 : IEquatable<Float4>
  {
    public float X;
    public float Y;
    public float Z;
    public float W;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Float4(float x, float y, float z, float w)
    {
      X = x;
      Y = y;
      Z = z;
      W = w;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    // Swizzle the components
    public readonly Float4 WZYX => new Float4(W, Z, Y, X);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Invert the float4
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Float4 operator -(in Float4 value) => new Float4(-value.X, -value.Y, -value.Z, -value.W);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Add two float4
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Float4 operator +(in Float4 lhs, in Float4 rhs) => new Float4(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z, lhs.W + rhs.W);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Substract two float4
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Float4 operator -(in Float4 lhs, in Float4 rhs) => new Float4(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z, lhs.W - rhs.W);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Multiply two float4
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Float4 operator *(in Float4 lhs, in Float4 rhs) => new Float4(lhs.X * rhs.X, lhs.Y * rhs.Y, lhs.Z * rhs.Z, lhs.W * rhs.W);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Multiply float4 by scalar
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Float4 operator *(in Float4 lhs, float rhs) => new Float4(lhs.X * rhs, lhs.Y * rhs, lhs.Z * rhs, lhs.W * rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Multiply scalar by float4
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Float4 operator *(float lhs, in Float4 rhs) => new Float4(lhs * rhs.X, lhs * rhs.Y, lhs * rhs.Z, lhs * rhs.W);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Divide two float4
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Float4 operator /(in Float4 lhs, in Float4 rhs) => new Float4(lhs.X / rhs.X, lhs.Y / rhs.Y, lhs.Z / rhs.Z, lhs.W / rhs.W);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Divide float4 by scalar
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Float4 operator /(in Float4 lhs, float rhs) => new Float4(lhs.X / rhs, lhs.Y / rhs, lhs.Z / rhs, lhs.W / rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(in Float4 lhs, in Float4 rhs) => (lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z && lhs.W == rhs.W);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(in Float4 lhs, in Float4 rhs) => !(lhs == rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [ObsoleteAttribute]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Add(ref Float4 lhs, ref Float4 rhs, out Float4 rResult)
    {
      rResult.X = lhs.X + rhs.X;
      rResult.Y = lhs.Y + rhs.Y;
      rResult.Z = lhs.Z + rhs.Z;
      rResult.W = lhs.W + rhs.W;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [ObsoleteAttribute]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref Float4 lhs, ref Float4 rhs, out Float4 rResult)
    {
      rResult.X = lhs.X / rhs.X;
      rResult.Y = lhs.Y / rhs.Y;
      rResult.Z = lhs.Z / rhs.Z;
      rResult.W = lhs.W / rhs.W;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [ObsoleteAttribute]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Multiply(ref Float4 lhs, ref Float4 rhs, out Float4 rResult)
    {
      rResult.X = lhs.X * rhs.X;
      rResult.Y = lhs.Y * rhs.Y;
      rResult.Z = lhs.Z * rhs.Z;
      rResult.W = lhs.W * rhs.W;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [ObsoleteAttribute]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Substract(ref Float4 lhs, ref Float4 rhs, out Float4 rResult)
    {
      rResult.X = lhs.X - rhs.X;
      rResult.Y = lhs.Y - rhs.Y;
      rResult.Z = lhs.Z - rhs.Z;
      rResult.W = lhs.W - rhs.W;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Dot(in Float4 vector1, in Float4 vector2)
      => vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z + vector1.W * vector2.W;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is Float4 other && (this == other);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode() ^ W.GetHashCode() ^ Z.GetHashCode();

    //------------------------------------------------------------------------------------------------------------------------------------------------


    public bool Equals(Float4 other) => X == other.X && Y == other.Y && Z == other.Z;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Calculate the length of a Float4
    /// </summary>
    /// <returns></returns>
    public readonly float Length => (float)Math.Sqrt((X * X) + (Y * Y) + (Z * Z) + (W * W));

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Calculate the squared length of a Float4
    /// </summary>
    /// <returns></returns>
    public readonly float LengthSquared => (X * X) + (Y * Y) + (Z * Z) + (W * W);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Normalize a float4
    /// </summary>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Normalize()
    {
      float val = 1.0f / (float)Math.Sqrt((X * X) + (Y * Y) + (Z * Z) + (W * W));
      X *= val;
      Y *= val;
      Z *= val;
      W *= val;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"{{X:{X} Y:{Y} Z:{Z} W:{W}}}";

  }
}

//****************************************************************************************************************************************************

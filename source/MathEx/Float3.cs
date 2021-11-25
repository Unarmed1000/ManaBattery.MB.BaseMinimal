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

namespace MB.Base.MathEx
{
  /// <summary>
  /// Represents a single float point
  /// </summary>
  [Serializable]
  [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
  public struct Float3 : IEquatable<Float3>
  {
    public float X;
    public float Y;
    public float Z;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public Float3(float x, float y, float z)
    {
      X = x;
      Y = y;
      Z = z;
    }

    // Swizzle the components
    public Float2 XY => new Float2(X, Y);


    // Swizzle the components
    public Float3 ZYX => new Float3(Z, Y, X);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    #region Operators

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Invert the float3
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Float3 operator -(in Float3 value) => new Float3(-value.X, -value.Y, -value.Z);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Add two float3
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Float3 operator +(in Float3 lhs, in Float3 rhs) => new Float3(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Substract two float3
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Float3 operator -(in Float3 lhs, in Float3 rhs) => new Float3(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Multiply two float3
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Float3 operator *(in Float3 lhs, in Float3 rhs) => new Float3(lhs.X * rhs.X, lhs.Y * rhs.Y, lhs.Z * rhs.Z);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Multiply float3 by scalar
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Float3 operator *(in Float3 lhs, float rhs) => new Float3(lhs.X * rhs, lhs.Y * rhs, lhs.Z * rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Multiply scalar by float3
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Float3 operator *(float lhs, in Float3 rhs) => new Float3(lhs * rhs.X, lhs * rhs.Y, lhs * rhs.Z);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Divide two float3
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Float3 operator /(in Float3 lhs, in Float3 rhs) => new Float3(lhs.X / rhs.X, lhs.Y / rhs.Y, lhs.Z / rhs.Z);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Divide float3 by scalar
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Float3 operator /(in Float3 lhs, float rhs) => new Float3(lhs.X / rhs, lhs.Y / rhs, lhs.Z / rhs);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static bool operator ==(in Float3 lhs, in Float3 rhs) => (lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static bool operator !=(in Float3 lhs, in Float3 rhs) => !(lhs == rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    #endregion

    //------------------------------------------------------------------------------------------------------------------------------------------------

    #region Methods

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [ObsoleteAttribute]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Add(ref Float3 lhs, ref Float3 rhs, out Float3 rResult)
    {
      rResult.X = lhs.X + rhs.X;
      rResult.Y = lhs.Y + rhs.Y;
      rResult.Z = lhs.Z + rhs.Z;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [ObsoleteAttribute]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Divide(ref Float3 lhs, ref Float3 rhs, out Float3 rResult)
    {
      rResult.X = lhs.X / rhs.X;
      rResult.Y = lhs.Y / rhs.Y;
      rResult.Z = lhs.Z / rhs.Z;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [ObsoleteAttribute]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Multiply(ref Float3 lhs, ref Float3 rhs, out Float3 rResult)
    {
      rResult.X = lhs.X * rhs.X;
      rResult.Y = lhs.Y * rhs.Y;
      rResult.Z = lhs.Z * rhs.Z;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [ObsoleteAttribute]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Substract(ref Float3 lhs, ref Float3 rhs, out Float3 rResult)
    {
      rResult.X = lhs.X - rhs.X;
      rResult.Y = lhs.Y - rhs.Y;
      rResult.Z = lhs.Z - rhs.Z;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Dot(in Float3 vector1, in Float3 vector2) => vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is Float3 other && (this == other);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();

    //------------------------------------------------------------------------------------------------------------------------------------------------


    public bool Equals(Float3 other) => X == other.X && Y == other.Y && Z == other.Z;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Calculate the length of a Float3
    /// </summary>
    /// <returns></returns>
    public float Length => (float)Math.Sqrt((X * X) + (Y * Y) + (Z * Z));

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Calculate the squared length of a Float3
    /// </summary>
    /// <returns></returns>

    public float LengthSquared => (X * X) + (Y * Y) + (Z * Z);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Normalize a float3
    /// </summary>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Normalize()
    {
      float val = 1.0f / (float)Math.Sqrt((X * X) + (Y * Y) + (Z * Z));
      X *= val;
      Y *= val;
      Z *= val;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"{{X:{X} Y:{Y} Z:{Z}}}";

    //------------------------------------------------------------------------------------------------------------------------------------------------

    #endregion
  }
}

//****************************************************************************************************************************************************

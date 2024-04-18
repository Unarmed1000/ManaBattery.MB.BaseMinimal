#nullable enable
//****************************************************************************************************************************************************
//* BSD 3-Clause License
//*
//* Copyright (c) 2015-2024, Mana Battery
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
  /// Represents a single integer point
  /// </summary>
  [Serializable]
  public struct Point2U : IEquatable<Point2U>
  {
    public UInt32 X;
    public UInt32 Y;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Construct a poitn
    /// </summary>
    /// <param name="x">x value</param>
    /// <param name="y">y value</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Point2U(UInt32 x, UInt32 y)
    {
      X = x;
      Y = y;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Point2U lhs, Point2U rhs) => (lhs.X == rhs.X && lhs.Y == rhs.Y);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Point2U lhs, Point2U rhs) => !(lhs == rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is Point2U other && (this == other);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => (X ^ Y).GetHashCode();

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public bool Equals(Point2U other) => X == other.X && Y == other.Y;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"{{X:{X} Y:{Y}}}";
  }
}

//****************************************************************************************************************************************************

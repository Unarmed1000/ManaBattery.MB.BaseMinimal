//****************************************************************************************************************************************************
//* BSD 3-Clause License
//*
//* Copyright (c) 2010, Mana Battery
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

namespace MB.Base.MathEx
{
  /// <summary>
  /// Represents a span
  /// </summary>
  [Serializable]
  public readonly struct SpanRange : IEquatable<SpanRange>
  {
    public readonly int Start;
    public readonly int Length;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public int End => Start + Length;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SpanRange(int start, int length)
    {
      Start = start;
      Length = length;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Check if a span is equal to another span
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(SpanRange lhs, SpanRange rhs) => (lhs.Start == rhs.Start && lhs.Length == rhs.Length);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Check if a span is not equal to another span
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(SpanRange lhs, SpanRange rhs) => !(lhs == rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is SpanRange other && (this == other);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => Start ^ Length;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"({Start}:{Length})";

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(SpanRange other) => (Start == other.Start && Length == other.Length);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SpanRange FromStartToEnd(int startIndex, int endIndex)
    {
      if (startIndex > endIndex)
        throw new ArgumentException($"{nameof(startIndex)} must be <= {nameof(endIndex)}");
      return new SpanRange(startIndex, endIndex - startIndex);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SpanRange FromStartToEnd(int startIndex, int endIndex, OptimizationCheckFlag checkFlag)
    {
      Debug.Assert(startIndex <= endIndex);
      return new SpanRange(startIndex, endIndex - startIndex);
    }
  }
}

//****************************************************************************************************************************************************

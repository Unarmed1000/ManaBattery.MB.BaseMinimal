#nullable enable
//****************************************************************************************************************************************************
//* BSD 3-Clause License
//*
//* Copyright (c) 2010-2024, Mana Battery
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
  public readonly struct SpanRangeU : IEquatable<SpanRangeU>
  {
    public readonly UInt32 Start;
    public readonly UInt32 Length;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public UInt32 End => Start + Length;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SpanRangeU(UInt32 start, UInt32 length)
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
    public static bool operator ==(SpanRangeU lhs, SpanRangeU rhs) => (lhs.Start == rhs.Start && lhs.Length == rhs.Length);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Check if a span is not equal to another span
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(SpanRangeU lhs, SpanRangeU rhs) => !(lhs == rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is SpanRangeU other && (this == other);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => (int)(Start ^ Length);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"({Start}:{Length})";

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(SpanRangeU other) => (Start == other.Start && Length == other.Length);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SpanRangeU FromStartToEnd(UInt32 startIndex, UInt32 endIndex)
    {
      if (startIndex > endIndex)
        throw new ArgumentException($"{nameof(startIndex)} must be <= {nameof(endIndex)}");
      return new SpanRangeU(startIndex, endIndex - startIndex);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SpanRangeU FromStartToEnd(UInt32 startIndex, UInt32 endIndex, OptimizationCheckFlag checkFlag)
    {
      Debug.Assert(startIndex <= endIndex);
      return new SpanRangeU(startIndex, endIndex - startIndex);
    }
  }
}

//****************************************************************************************************************************************************

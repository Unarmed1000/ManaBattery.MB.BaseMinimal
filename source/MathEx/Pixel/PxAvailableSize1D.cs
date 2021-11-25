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
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

//----------------------------------------------------------------------------------------------------------------------------------------------------

namespace MB.Base.MathEx.Pixel
{
  public readonly struct PxAvailableSize1D : IEquatable<PxAvailableSize1D>
  {
    public const Int32 MinValue = Int32.MinValue;
    public const Int32 MaxValue = Int32.MaxValue;

    public static readonly PxAvailableSize1D Infinity = new PxAvailableSize1D(PxAvailableSizeUtil.InfiniteSpacePx);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public readonly Int64 Value;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxAvailableSize1D(Int64 valuePx)
    {
      // If this fires the available space has become invalid (someone is doing math on infinity)
      Debug.Assert(valuePx <= MaxValue || valuePx == PxAvailableSizeUtil.InfiniteSpacePx);
      Value = PxAvailableSizeUtil.IsNormalValue(valuePx) ? Math.Max(valuePx, 0) : valuePx;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public PxAvailableSize1D(Int64 valuePx, OptimizationCheckFlag flag)
    {
      // If this fires the available space has become invalid (someone is doing math on infinity)
      Debug.Assert(valuePx <= MaxValue || valuePx == PxAvailableSizeUtil.InfiniteSpacePx);
      Debug.Assert(valuePx >= 0);
      Debug.Assert(flag == OptimizationCheckFlag.NoCheck);
      Value = valuePx;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public bool IsInfinity => PxAvailableSizeUtil.IsConsideredInfiniteSpace(Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public bool IsNormal => PxAvailableSizeUtil.IsNormalValue(Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Int32 AsInt32()
    {
      Debug.Assert(IsNormal);
      return UncheckedNumericCast.ToInt32(Value);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxAvailableSize1D operator +(PxAvailableSize1D lhs, Int32 rhs)
      => !lhs.IsInfinity ? new PxAvailableSize1D(lhs.Value + rhs) : PxAvailableSize1D.Infinity;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxAvailableSize1D operator -(PxAvailableSize1D lhs, Int32 rhs)
      => !lhs.IsInfinity ? new PxAvailableSize1D(lhs.Value - rhs) : PxAvailableSize1D.Infinity;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PxAvailableSize1D lhs, PxAvailableSize1D rhs) => (lhs.Value == rhs.Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PxAvailableSize1D lhs, PxAvailableSize1D rhs) => !(lhs == rhs);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxAvailableSize1D Min(PxAvailableSize1D val0, PxAvailableSize1D val1)
      => new PxAvailableSize1D(Math.Min(val0.Value, val1.Value));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxAvailableSize1D Max(PxAvailableSize1D val0, PxAvailableSize1D val1)
      => new PxAvailableSize1D(Math.Max(val0.Value, val1.Value));

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is PxAvailableSize1D other && (this == other);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => Value.GetHashCode();

    //------------------------------------------------------------------------------------------------------------------------------------------------


    public bool Equals(PxAvailableSize1D other) => Value == other.Value;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"Value:{Value}";
  }
}

//****************************************************************************************************************************************************

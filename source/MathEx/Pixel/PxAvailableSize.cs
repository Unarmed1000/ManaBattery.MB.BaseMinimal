

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
  public readonly struct PxAvailableSize : IEquatable<PxAvailableSize>
  {
    public const Int32 MinValue = Int32.MinValue;
    public const Int32 MaxValue = Int32.MaxValue;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static readonly PxAvailableSize1D Infinity = new PxAvailableSize1D(PxAvailableSizeUtil.InfiniteSpacePx);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public readonly PxAvailableSize1D Width;
    public readonly PxAvailableSize1D Height;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxAvailableSize(PxAvailableSize1D widthPx, PxAvailableSize1D heightPx)
    {
      Width = widthPx;
      Height = heightPx;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// When using this constructor we expect a normal value this is not in the magic NaN or Infinity ranges!
    /// </summary>
    public PxAvailableSize(PxPoint2 value)
    {
      Width = new PxAvailableSize1D(value.X);
      Height = new PxAvailableSize1D(value.Y);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// When using this constructor we expect a normal value this is not in the magic NaN or Infinity ranges!
    /// </summary>
    public PxAvailableSize(PxSize2D value)
    {
      Width = new PxAvailableSize1D(value.Width);
      Height = new PxAvailableSize1D(value.Height);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public bool IsInfinityWidth => PxAvailableSizeUtil.IsConsideredInfiniteSpace(Width.Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public bool IsInfinityHeight => PxAvailableSizeUtil.IsConsideredInfiniteSpace(Height.Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public bool IsNormalWidth => PxAvailableSizeUtil.IsNormalValue(Width.Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public bool IsNormalHeight => PxAvailableSizeUtil.IsNormalValue(Height.Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public bool IsNormal => IsNormalWidth && IsNormalHeight;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public bool ContainsInfinity => IsInfinityWidth || IsInfinityHeight;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxSize2D AsPxSize2D()
    {
      return new PxSize2D(Width.AsInt32(), Height.AsInt32(), OptimizationCheckFlag.NoCheck);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Int32 AsWidth() => Width.AsInt32();

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Int32 AsHeight() => Height.AsInt32();


    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxAvailableSize operator +(PxAvailableSize lhs, PxSize2D rhs)
      => new PxAvailableSize(lhs.Width + rhs.Width, lhs.Height + rhs.Height);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxAvailableSize operator -(PxAvailableSize lhs, PxSize2D rhs)
      => new PxAvailableSize(lhs.Width - rhs.Width, lhs.Height - rhs.Height);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxAvailableSize Min(in PxAvailableSize val0, in PxAvailableSize val1)
      => new PxAvailableSize(PxAvailableSize1D.Min(val0.Width, val1.Width), PxAvailableSize1D.Min(val0.Height, val1.Height));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxAvailableSize Max(in PxAvailableSize val0, in PxAvailableSize val1)
      => new PxAvailableSize(PxAvailableSize1D.Max(val0.Width, val1.Width), PxAvailableSize1D.Max(val0.Height, val1.Height));

    //------------------------------------------------------------------------------------------------------------------------------------------------


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize2D MinPxSize2D(in PxAvailableSize val0, PxSize2D val1)
      => new PxSize2D(UncheckedNumericCast.ToInt32(Math.Min(val0.Width.Value, (Int64)val1.Width)),
                      UncheckedNumericCast.ToInt32(Math.Min(val0.Height.Value, (Int64)val1.Height)));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize2D MinPxSize2D(PxSize2D val0, in PxAvailableSize val1)
      => new PxSize2D(UncheckedNumericCast.ToInt32(Math.Min((Int64)val0.Width, val1.Width.Value)),
                      UncheckedNumericCast.ToInt32(Math.Min((Int64)val0.Height, val1.Height.Value)));

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize2D MaxPxSize2D(PxSize2D val0, in PxAvailableSize val1) => PxSize2D.Max(val0, val1.AsPxSize2D());

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize2D MaxPxSize2D(in PxAvailableSize val0, PxSize2D val1) => PxSize2D.Max(val0.AsPxSize2D(), val1);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(in PxAvailableSize lhs, in PxAvailableSize rhs)
      => (lhs.Width.Value == rhs.Width.Value && lhs.Height.Value == rhs.Height.Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(in PxAvailableSize lhs, in PxAvailableSize rhs) => !(lhs == rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is PxAvailableSize other && (this == other);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => Width.Value.GetHashCode() ^ Height.Value.GetHashCode();

    //------------------------------------------------------------------------------------------------------------------------------------------------


    public bool Equals(PxAvailableSize other) => Width.Value == other.Width.Value && Height.Value == other.Height.Value;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"Width:{Width.Value} Height:{Height.Value}";
  }
}

//****************************************************************************************************************************************************

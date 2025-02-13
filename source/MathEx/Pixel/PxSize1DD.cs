#nullable enable
//****************************************************************************************************************************************************
//* BSD 3-Clause License
//*
//* Copyright (c) 2025, Mana Battery
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
  public readonly struct PxSize1DD : IEquatable<PxSize1DD>
  {
    public static readonly PxSize1DD MinValue = new PxSize1DD();
    public static readonly PxSize1DD MaxValue = Create(double.MaxValue);

    public static readonly PxSize1DD Zero = new PxSize1DD();
    public static readonly PxSize1DD NaN = Create(double.NaN);
    public static readonly PxSize1DD PositiveInfinity = Create(double.PositiveInfinity);

    //------------------------------------------------------------------------------------------------------------------------------------------------
    public bool IsNaN => double.IsNaN(Value.Value);
    public bool IsInfinity => double.IsInfinity(Value.Value);
    public bool IsPositiveInfinity => double.IsPositiveInfinity(Value.Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public readonly PxValueD Value;


    public double RawValue => Value.Value;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxSize1DD(PxValueD valuePx)
    {
      Value = PxValueD.Max(valuePx, new PxValueD());
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter",
                                                     Justification = "Used to select this constructor variant")]
    public PxSize1DD(PxValueD valuePx, OptimizationCheckFlag optimizationFlag)
    {
      Debug.Assert(valuePx >= new PxValueD());
      Debug.Assert(optimizationFlag == OptimizationCheckFlag.NoCheck);    // remove warning
      Value = valuePx;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1DD Add(PxSize1DD lhs, PxSize1DD rhs) => new PxSize1DD(lhs.Value + rhs.Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueD Add(PxValueD lhs, PxSize1DD rhs) => lhs + rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueD Add(PxSize1DD lhs, PxValueD rhs) => lhs.Value + rhs;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueD Subtract(PxSize1DD sizePx, PxSize1DD valuePx) => sizePx.Value - valuePx.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueD Subtract(PxValueD sizePx, PxSize1DD valuePx) => sizePx - valuePx.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueD Subtract(PxSize1DD sizePx, PxValueD valuePx) => sizePx.Value - valuePx;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]

    public static PxSize1DD Divide(PxSize1DD sizePx, PxSize1DD value) => new PxSize1DD(sizePx.Value / value, OptimizationCheckFlag.NoCheck);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]

    public static PxValueD Divide(PxValueD sizePx, PxSize1DD value) => sizePx / value.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]

    public static PxValueD Divide(PxSize1DD sizePx, PxValueD value) => sizePx.Value / value;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1DD operator +(PxSize1DD lhs, PxSize1DD rhs) => new PxSize1DD(lhs.Value + rhs.Value, OptimizationCheckFlag.NoCheck);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueD operator +(PxSize1DD lhs, PxValueD rhs) => lhs.Value + rhs;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueD operator +(PxValueD lhs, PxSize1DD rhs) => lhs + rhs.Value;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueD operator -(PxSize1DD lhs, PxSize1DD rhs) => lhs.Value - rhs.Value;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueD operator -(PxValueD lhs, PxSize1DD rhs) => lhs - rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueD operator -(PxSize1DD lhs, PxValueD rhs) => lhs.Value - rhs;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1DD operator *(PxSize1DD lhs, PxSize1DD rhs) => new PxSize1DD(lhs.Value * rhs.Value, OptimizationCheckFlag.NoCheck);


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueD operator *(PxValueD lhs, PxSize1DD rhs) => lhs * rhs.Value;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueD operator *(PxSize1DD lhs, PxValueD rhs) => lhs.Value * rhs;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1DD operator /(PxSize1DD lhs, PxSize1DD rhs) => new PxSize1DD(lhs.Value / rhs.Value, OptimizationCheckFlag.NoCheck);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueD operator /(PxValueD lhs, PxSize1DD rhs) => lhs / rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueD operator /(PxSize1DD lhs, PxValueD rhs) => lhs.Value / rhs;


    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PxSize1DD lhs, PxSize1DD rhs) => (lhs.Value == rhs.Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PxValueD lhs, PxSize1DD rhs) => (lhs == rhs.Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PxSize1DD lhs, PxValueD rhs) => (lhs.Value == rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PxSize1DD lhs, PxSize1DD rhs) => !(lhs == rhs);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PxValueD lhs, PxSize1DD rhs) => !(lhs == rhs);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PxSize1DD lhs, PxValueD rhs) => !(lhs == rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(PxSize1DD lhs, PxSize1DD rhs) => lhs.Value < rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(PxValueD lhs, PxSize1DD rhs) => lhs < rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(PxSize1DD lhs, PxValueD rhs) => lhs.Value < rhs;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(PxSize1DD lhs, PxSize1DD rhs) => lhs.Value <= rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(PxValueD lhs, PxSize1DD rhs) => lhs <= rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(PxSize1DD lhs, PxValueD rhs) => lhs.Value <= rhs;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(PxSize1DD lhs, PxSize1DD rhs) => lhs.Value > rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(PxValueD lhs, PxSize1DD rhs) => lhs > rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(PxSize1DD lhs, PxValueD rhs) => lhs.Value > rhs;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(PxSize1DD lhs, PxSize1DD rhs) => lhs.Value >= rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(PxValueD lhs, PxSize1DD rhs) => lhs >= rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(PxSize1DD lhs, PxValueD rhs) => lhs.Value >= rhs;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is PxSize1DD && (this == (PxSize1DD)obj);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => Value.GetHashCode();

    //------------------------------------------------------------------------------------------------------------------------------------------------


    public bool Equals(PxSize1DD other) => Value == other.Value;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"Value:{Value}";

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1DD Min(PxSize1DD val0, PxSize1DD val1)
      => new PxSize1DD(PxValueD.Min(val0.Value, val1.Value), OptimizationCheckFlag.NoCheck);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1DD Min(PxValueD val0, PxSize1DD val1)
      => new PxSize1DD(PxValueD.Min(val0, val1.Value));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1DD Min(PxSize1DD val0, PxValueD val1)
      => new PxSize1DD(PxValueD.Min(val0.Value, val1));

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1DD Max(PxSize1DD val0, PxSize1DD val1)
      => new PxSize1DD(PxValueD.Max(val0.Value, val1.Value), OptimizationCheckFlag.NoCheck);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1DD Max(PxValueD val0, PxSize1DD val1)
      => new PxSize1DD(PxValueD.Max(val0, val1.Value), OptimizationCheckFlag.NoCheck);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1DD Max(PxSize1DD val0, PxValueD val1)
      => new PxSize1DD(PxValueD.Max(val0.Value, val1), OptimizationCheckFlag.NoCheck);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1DD Create(double valuePx)
    {
      return new PxSize1DD(new PxValueD(valuePx));
    }
  }
}

//****************************************************************************************************************************************************

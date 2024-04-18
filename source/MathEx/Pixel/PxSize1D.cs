#nullable enable
//****************************************************************************************************************************************************
//* BSD 3-Clause License
//*
//* Copyright (c) 2022-2024, Mana Battery
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
  public readonly struct PxSize1D : IEquatable<PxSize1D>
  {
    public static readonly PxSize1D MinValue = new PxSize1D();
    public static readonly PxSize1D MaxValue = Create(Int32.MaxValue);

    public static readonly PxSize1D Zero = new PxSize1D();

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public readonly PxValue Value;


    public Int32 RawValue => Value.Value;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxSize1D(PxValue valueDp)
    {
      Value = PxValue.Max(valueDp, new PxValue());
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter",
                                                     Justification = "Used to select this constructor variant")]
    public PxSize1D(PxValue valueDp, OptimizationCheckFlag optimizationFlag)
    {
      Debug.Assert(valueDp >= new PxValue());
      Debug.Assert(optimizationFlag == OptimizationCheckFlag.NoCheck);    // remove warning
      Value = valueDp;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1D Add(PxSize1D lhs, PxSize1D rhs) => new PxSize1D(lhs.Value + rhs.Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValue Add(PxValue lhs, PxSize1D rhs) => lhs + rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValue Add(PxSize1D lhs, PxValue rhs) => lhs.Value + rhs;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValue Subtract(PxSize1D sizeDp, PxSize1D valueDp) => sizeDp.Value - valueDp.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValue Subtract(PxValue sizeDp, PxSize1D valueDp) => sizeDp - valueDp.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValue Subtract(PxSize1D sizeDp, PxValue valueDp) => sizeDp.Value - valueDp;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]

    public static PxSize1D Divide(PxSize1D sizeDp, PxSize1D value) => new PxSize1D(sizeDp.Value / value, OptimizationCheckFlag.NoCheck);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]

    public static PxValue Divide(PxValue sizeDp, PxSize1D value) => sizeDp / value.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]

    public static PxValue Divide(PxSize1D sizeDp, PxValue value) => sizeDp.Value / value;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1D operator +(PxSize1D lhs, PxSize1D rhs) => new PxSize1D(lhs.Value + rhs.Value, OptimizationCheckFlag.NoCheck);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValue operator +(PxSize1D lhs, PxValue rhs) => lhs.Value + rhs;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValue operator +(PxValue lhs, PxSize1D rhs) => lhs + rhs.Value;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValue operator -(PxSize1D lhs, PxSize1D rhs) => lhs.Value - rhs.Value;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValue operator -(PxValue lhs, PxSize1D rhs) => lhs - rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValue operator -(PxSize1D lhs, PxValue rhs) => lhs.Value - rhs;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1D operator *(PxSize1D lhs, PxSize1D rhs) => new PxSize1D(lhs.Value * rhs.Value, OptimizationCheckFlag.NoCheck);


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValue operator *(PxValue lhs, PxSize1D rhs) => lhs * rhs.Value;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValue operator *(PxSize1D lhs, PxValue rhs) => lhs.Value * rhs;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1D operator /(PxSize1D lhs, PxSize1D rhs) => new PxSize1D(lhs.Value / rhs.Value, OptimizationCheckFlag.NoCheck);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValue operator /(PxValue lhs, PxSize1D rhs) => lhs / rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValue operator /(PxSize1D lhs, PxValue rhs) => lhs.Value / rhs;


    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PxSize1D lhs, PxSize1D rhs) => (lhs.Value == rhs.Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PxValue lhs, PxSize1D rhs) => (lhs == rhs.Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PxSize1D lhs, PxValue rhs) => (lhs.Value == rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PxSize1D lhs, PxSize1D rhs) => !(lhs == rhs);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PxValue lhs, PxSize1D rhs) => !(lhs == rhs);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PxSize1D lhs, PxValue rhs) => !(lhs == rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(PxSize1D lhs, PxSize1D rhs) => lhs.Value < rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(PxValue lhs, PxSize1D rhs) => lhs < rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(PxSize1D lhs, PxValue rhs) => lhs.Value < rhs;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(PxSize1D lhs, PxSize1D rhs) => lhs.Value <= rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(PxValue lhs, PxSize1D rhs) => lhs <= rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(PxSize1D lhs, PxValue rhs) => lhs.Value <= rhs;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(PxSize1D lhs, PxSize1D rhs) => lhs.Value > rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(PxValue lhs, PxSize1D rhs) => lhs > rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(PxSize1D lhs, PxValue rhs) => lhs.Value > rhs;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(PxSize1D lhs, PxSize1D rhs) => lhs.Value >= rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(PxValue lhs, PxSize1D rhs) => lhs >= rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(PxSize1D lhs, PxValue rhs) => lhs.Value >= rhs;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is PxSize1D other && (this == other);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => Value.GetHashCode();

    //------------------------------------------------------------------------------------------------------------------------------------------------


    public bool Equals(PxSize1D other) => Value == other.Value;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => Value.ToString();

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1D Min(PxSize1D val0, PxSize1D val1)
      => new PxSize1D(PxValue.Min(val0.Value, val1.Value), OptimizationCheckFlag.NoCheck);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1D Min(PxValue val0, PxSize1D val1)
      => new PxSize1D(PxValue.Min(val0, val1.Value));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1D Min(PxSize1D val0, PxValue val1)
      => new PxSize1D(PxValue.Min(val0.Value, val1));

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1D Max(PxSize1D val0, PxSize1D val1)
      => new PxSize1D(PxValue.Max(val0.Value, val1.Value), OptimizationCheckFlag.NoCheck);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1D Max(PxValue val0, PxSize1D val1)
      => new PxSize1D(PxValue.Max(val0, val1.Value), OptimizationCheckFlag.NoCheck);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1D Max(PxSize1D val0, PxValue val1)
      => new PxSize1D(PxValue.Max(val0.Value, val1), OptimizationCheckFlag.NoCheck);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1D Create(Int32 valueDp)
    {
      return new PxSize1D(new PxValue(valueDp));
    }
  }
}

//****************************************************************************************************************************************************

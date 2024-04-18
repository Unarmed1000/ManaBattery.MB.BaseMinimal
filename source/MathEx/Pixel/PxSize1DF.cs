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
  public readonly struct PxSize1DF : IEquatable<PxSize1DF>
  {
    public static readonly PxSize1DF MinValue = new PxSize1DF();
    public static readonly PxSize1DF MaxValue = Create(float.MaxValue);

    public static readonly PxSize1DF Zero = new PxSize1DF();
    public static readonly PxSize1DF NaN = Create(float.NaN);
    public static readonly PxSize1DF PositiveInfinity = Create(float.PositiveInfinity);

    //------------------------------------------------------------------------------------------------------------------------------------------------
    public bool IsNaN => float.IsNaN(Value.Value);
    public bool IsInfinity => float.IsInfinity(Value.Value);
    public bool IsPositiveInfinity => float.IsPositiveInfinity(Value.Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public readonly PxValueF Value;


    public float RawValue => Value.Value;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxSize1DF(PxValueF valueDp)
    {
      Value = PxValueF.Max(valueDp, new PxValueF());
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter",
                                                     Justification = "Used to select this constructor variant")]
    public PxSize1DF(PxValueF valueDp, OptimizationCheckFlag optimizationFlag)
    {
      Debug.Assert(valueDp >= new PxValueF());
      Debug.Assert(optimizationFlag == OptimizationCheckFlag.NoCheck);    // remove warning
      Value = valueDp;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1DF Add(PxSize1DF lhs, PxSize1DF rhs) => new PxSize1DF(lhs.Value + rhs.Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueF Add(PxValueF lhs, PxSize1DF rhs) => lhs + rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueF Add(PxSize1DF lhs, PxValueF rhs) => lhs.Value + rhs;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueF Subtract(PxSize1DF sizeDp, PxSize1DF valueDp) => sizeDp.Value - valueDp.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueF Subtract(PxValueF sizeDp, PxSize1DF valueDp) => sizeDp - valueDp.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueF Subtract(PxSize1DF sizeDp, PxValueF valueDp) => sizeDp.Value - valueDp;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]

    public static PxSize1DF Divide(PxSize1DF sizeDp, PxSize1DF value) => new PxSize1DF(sizeDp.Value / value, OptimizationCheckFlag.NoCheck);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]

    public static PxValueF Divide(PxValueF sizeDp, PxSize1DF value) => sizeDp / value.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]

    public static PxValueF Divide(PxSize1DF sizeDp, PxValueF value) => sizeDp.Value / value;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1DF operator +(PxSize1DF lhs, PxSize1DF rhs) => new PxSize1DF(lhs.Value + rhs.Value, OptimizationCheckFlag.NoCheck);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueF operator +(PxSize1DF lhs, PxValueF rhs) => lhs.Value + rhs;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueF operator +(PxValueF lhs, PxSize1DF rhs) => lhs + rhs.Value;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueF operator -(PxSize1DF lhs, PxSize1DF rhs) => lhs.Value - rhs.Value;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueF operator -(PxValueF lhs, PxSize1DF rhs) => lhs - rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueF operator -(PxSize1DF lhs, PxValueF rhs) => lhs.Value - rhs;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1DF operator *(PxSize1DF lhs, PxSize1DF rhs) => new PxSize1DF(lhs.Value * rhs.Value, OptimizationCheckFlag.NoCheck);


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueF operator *(PxValueF lhs, PxSize1DF rhs) => lhs * rhs.Value;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueF operator *(PxSize1DF lhs, PxValueF rhs) => lhs.Value * rhs;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1DF operator /(PxSize1DF lhs, PxSize1DF rhs) => new PxSize1DF(lhs.Value / rhs.Value, OptimizationCheckFlag.NoCheck);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueF operator /(PxValueF lhs, PxSize1DF rhs) => lhs / rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueF operator /(PxSize1DF lhs, PxValueF rhs) => lhs.Value / rhs;


    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PxSize1DF lhs, PxSize1DF rhs) => (lhs.Value == rhs.Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PxValueF lhs, PxSize1DF rhs) => (lhs == rhs.Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PxSize1DF lhs, PxValueF rhs) => (lhs.Value == rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PxSize1DF lhs, PxSize1DF rhs) => !(lhs == rhs);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PxValueF lhs, PxSize1DF rhs) => !(lhs == rhs);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PxSize1DF lhs, PxValueF rhs) => !(lhs == rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(PxSize1DF lhs, PxSize1DF rhs) => lhs.Value < rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(PxValueF lhs, PxSize1DF rhs) => lhs < rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(PxSize1DF lhs, PxValueF rhs) => lhs.Value < rhs;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(PxSize1DF lhs, PxSize1DF rhs) => lhs.Value <= rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(PxValueF lhs, PxSize1DF rhs) => lhs <= rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(PxSize1DF lhs, PxValueF rhs) => lhs.Value <= rhs;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(PxSize1DF lhs, PxSize1DF rhs) => lhs.Value > rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(PxValueF lhs, PxSize1DF rhs) => lhs > rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(PxSize1DF lhs, PxValueF rhs) => lhs.Value > rhs;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(PxSize1DF lhs, PxSize1DF rhs) => lhs.Value >= rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(PxValueF lhs, PxSize1DF rhs) => lhs >= rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(PxSize1DF lhs, PxValueF rhs) => lhs.Value >= rhs;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is PxSize1DF && (this == (PxSize1DF)obj);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => Value.GetHashCode();

    //------------------------------------------------------------------------------------------------------------------------------------------------


    public bool Equals(PxSize1DF other) => Value == other.Value;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"Value:{Value}";

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1DF Min(PxSize1DF val0, PxSize1DF val1)
      => new PxSize1DF(PxValueF.Min(val0.Value, val1.Value), OptimizationCheckFlag.NoCheck);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1DF Min(PxValueF val0, PxSize1DF val1)
      => new PxSize1DF(PxValueF.Min(val0, val1.Value));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1DF Min(PxSize1DF val0, PxValueF val1)
      => new PxSize1DF(PxValueF.Min(val0.Value, val1));

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1DF Max(PxSize1DF val0, PxSize1DF val1)
      => new PxSize1DF(PxValueF.Max(val0.Value, val1.Value), OptimizationCheckFlag.NoCheck);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1DF Max(PxValueF val0, PxSize1DF val1)
      => new PxSize1DF(PxValueF.Max(val0, val1.Value), OptimizationCheckFlag.NoCheck);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1DF Max(PxSize1DF val0, PxValueF val1)
      => new PxSize1DF(PxValueF.Max(val0.Value, val1), OptimizationCheckFlag.NoCheck);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize1DF Create(float valueDp)
    {
      return new PxSize1DF(new PxValueF(valueDp));
    }
  }
}

//****************************************************************************************************************************************************

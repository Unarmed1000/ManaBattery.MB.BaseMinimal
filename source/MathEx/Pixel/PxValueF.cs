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

namespace MB.Base.MathEx.Pixel
{
  [Serializable]
  public readonly struct PxValueF : IEquatable<PxValueF>
  {
    public static readonly PxValueF MinValue = new PxValueF(float.MinValue);
    public static readonly PxValueF MaxValue = new PxValueF(float.MaxValue);

    public static readonly PxValueF Zero = new PxValueF();
    public static readonly PxValueF NaN = new PxValueF(float.NaN);
    public static readonly PxValueF NegativeInfinity = new PxValueF(float.NegativeInfinity);
    public static readonly PxValueF PositiveInfinity = new PxValueF(float.PositiveInfinity);

    public readonly float Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxValueF(float xDp)
    {
      Value = xDp;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------
    // Operators
    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Add
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueF operator +(PxValueF lhs, PxValueF rhs) => new PxValueF(lhs.Value + rhs.Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Substract
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueF operator -(PxValueF lhs, PxValueF rhs) => new PxValueF(lhs.Value - rhs.Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueF operator *(PxValueF lhs, PxValueF rhs) => new PxValueF(lhs.Value * rhs.Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueF operator /(PxValueF lhs, PxValueF rhs) => new PxValueF(lhs.Value / rhs.Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Invert
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueF operator -(PxValueF value) => new PxValueF(-value.Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PxValueF lhs, PxValueF rhs) => (lhs.Value == rhs.Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PxValueF lhs, PxValueF rhs) => !(lhs == rhs);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(PxValueF lhs, PxValueF rhs) => lhs.Value < rhs.Value;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(PxValueF lhs, PxValueF rhs) => lhs.Value <= rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(PxValueF lhs, PxValueF rhs) => lhs.Value > rhs.Value;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(PxValueF lhs, PxValueF rhs) => lhs.Value >= rhs.Value;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public bool IsNaN => float.IsNaN(Value);
    public bool IsInfinity => float.IsInfinity(Value);
    public bool IsPositiveInfinity => float.IsPositiveInfinity(Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is PxValueF && (this == (PxValueF)obj);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => Value.GetHashCode();

    //------------------------------------------------------------------------------------------------------------------------------------------------


    public bool Equals(PxValueF other) => Value == other.Value;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"{Value}dp";

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueF Min(PxValueF val0, PxValueF val1) => new PxValueF(Math.Min(val0.Value, val1.Value));

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueF Max(PxValueF val0, PxValueF val1) => new PxValueF(Math.Max(val0.Value, val1.Value));
  }
}

//****************************************************************************************************************************************************

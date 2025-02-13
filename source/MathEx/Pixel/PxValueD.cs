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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

//----------------------------------------------------------------------------------------------------------------------------------------------------

namespace MB.Base.MathEx.Pixel
{
  [Serializable]
  public readonly struct PxValueD : IEquatable<PxValueD>
  {
    public static readonly PxValueD MinValue = new PxValueD(double.MinValue);
    public static readonly PxValueD MaxValue = new PxValueD(double.MaxValue);

    public static readonly PxValueD Zero = new PxValueD();
    public static readonly PxValueD NaN = new PxValueD(double.NaN);
    public static readonly PxValueD NegativeInfinity = new PxValueD(double.NegativeInfinity);
    public static readonly PxValueD PositiveInfinity = new PxValueD(double.PositiveInfinity);

    public readonly double Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxValueD(double xPxf)
    {
      Value = xPxf;
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
    public static PxValueD operator +(PxValueD lhs, PxValueD rhs) => new PxValueD(lhs.Value + rhs.Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Substract
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueD operator -(PxValueD lhs, PxValueD rhs) => new PxValueD(lhs.Value - rhs.Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueD operator *(PxValueD lhs, PxValueD rhs) => new PxValueD(lhs.Value * rhs.Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueD operator /(PxValueD lhs, PxValueD rhs) => new PxValueD(lhs.Value / rhs.Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Invert
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueD operator -(PxValueD value) => new PxValueD(-value.Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PxValueD lhs, PxValueD rhs) => (lhs.Value == rhs.Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PxValueD lhs, PxValueD rhs) => !(lhs == rhs);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(PxValueD lhs, PxValueD rhs) => lhs.Value < rhs.Value;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(PxValueD lhs, PxValueD rhs) => lhs.Value <= rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(PxValueD lhs, PxValueD rhs) => lhs.Value > rhs.Value;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(PxValueD lhs, PxValueD rhs) => lhs.Value >= rhs.Value;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public bool IsNaN => double.IsNaN(Value);
    public bool IsInfinity => double.IsInfinity(Value);
    public bool IsPositiveInfinity => double.IsPositiveInfinity(Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is PxValueD && (this == (PxValueD)obj);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => Value.GetHashCode();

    //------------------------------------------------------------------------------------------------------------------------------------------------


    public bool Equals(PxValueD other) => Value == other.Value;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"{Value}px";

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueD Min(PxValueD val0, PxValueD val1) => new PxValueD(Math.Min(val0.Value, val1.Value));

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValueD Max(PxValueD val0, PxValueD val1) => new PxValueD(Math.Max(val0.Value, val1.Value));
  }
}

//****************************************************************************************************************************************************

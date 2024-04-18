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
  public readonly struct PxValue : IEquatable<PxValue>
  {
    public static readonly PxValue MinValue = new PxValue(Int32.MinValue);
    public static readonly PxValue MaxValue = new PxValue(Int32.MaxValue);

    public readonly Int32 Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxValue(Int32 xDp)
    {
      Value = xDp;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Add
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValue operator +(PxValue lhs, PxValue rhs) => new PxValue(lhs.Value + rhs.Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Substract
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValue operator -(PxValue lhs, PxValue rhs) => new PxValue(lhs.Value - rhs.Value);
    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValue operator *(PxValue lhs, PxValue rhs) => new PxValue(lhs.Value * rhs.Value);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValue operator /(PxValue lhs, PxValue rhs) => new PxValue(lhs.Value / rhs.Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Invert
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValue operator -(PxValue value) => new PxValue(-value.Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PxValue lhs, PxValue rhs) => (lhs.Value == rhs.Value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PxValue lhs, PxValue rhs) => !(lhs == rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(PxValue lhs, PxValue rhs) => lhs.Value < rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(PxValue lhs, PxValue rhs) => lhs.Value <= rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(PxValue lhs, PxValue rhs) => lhs.Value > rhs.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(PxValue lhs, PxValue rhs) => lhs.Value >= rhs.Value;


    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is PxValue value && (Value == value.Value);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => Value.GetHashCode();

    //------------------------------------------------------------------------------------------------------------------------------------------------


    public bool Equals(PxValue other) => Value == other.Value;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"{Value}dp";

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValue Min(PxValue val0, PxValue val1) => new PxValue(Math.Min(val0.Value, val1.Value));

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxValue Max(PxValue val0, PxValue val1) => new PxValue(Math.Max(val0.Value, val1.Value));
  }
}

//****************************************************************************************************************************************************

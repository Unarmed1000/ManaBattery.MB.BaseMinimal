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
using System.Diagnostics;
using System.Runtime.CompilerServices;

//----------------------------------------------------------------------------------------------------------------------------------------------------


namespace MB.Base
{
  public static class UncheckedNumericCast
  {
    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int64 ToInt64(byte value) => (Int64)value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int64 ToInt64(sbyte value) => (Int64)value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int64 ToInt64(Int16 value) => (Int64)value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int64 ToInt64(UInt16 value) => (Int64)value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int64 ToInt64(UInt32 value) => (Int64)value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int64 ToInt64(Int32 value) => (Int64)value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int64 ToInt64(Int64 value) => value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int64 ToInt64(UInt64 value)
    {
      Debug.Assert(value <= (UInt64)Int64.MaxValue);
      return (Int64)value;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int32 ToInt32(byte value) => (Int32)value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int32 ToInt32(UInt16 value) => (Int32)value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int32 ToInt32(UInt32 value)
    {
      Debug.Assert(value <= (UInt32)Int32.MaxValue);
      return (Int32)value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int32 ToInt32(Int64 value)
    {
      Debug.Assert(value >= Int32.MinValue);
      Debug.Assert(value <= Int32.MaxValue);
      return (Int32)value;
    }


    //------------------------------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------------------------------------------------------------


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte ToUInt8(Int16 value)
    {
      Debug.Assert(value >= 0);
      Debug.Assert(value <= byte.MaxValue);
      return (byte)value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte ToUInt8(Int32 value)
    {
      Debug.Assert(value >= 0);
      Debug.Assert(value <= byte.MaxValue);
      return (byte)value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte ToUInt8(Int64 value)
    {
      Debug.Assert(value >= 0);
      Debug.Assert(value <= byte.MaxValue);
      return (byte)value;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt32 ToUInt16(sbyte value)
    {
      Debug.Assert(value >= 0);
      return (UInt32)value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt16 ToUInt16(Int16 value)
    {
      Debug.Assert(value >= 0);
      return (UInt16)value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt16 ToUInt16(Int32 value)
    {
      Debug.Assert(value >= 0);
      Debug.Assert(value <= UInt16.MaxValue);
      return (UInt16)value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt16 ToUInt16(UInt32 value)
    {
      Debug.Assert(value <= UInt16.MaxValue);
      return (UInt16)value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt16 ToUInt16(Int64 value)
    {
      Debug.Assert(value >= 0);
      Debug.Assert(value <= UInt16.MaxValue);
      return (UInt16)value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt16 ToUInt16(UInt64 value)
    {
      Debug.Assert(value <= UInt16.MaxValue);
      return (UInt16)value;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt32 ToUInt32(sbyte value)
    {
      Debug.Assert(value >= 0);
      return (UInt32)value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt32 ToUInt32(Int16 value)
    {
      Debug.Assert(value >= 0);
      return (UInt32)value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt32 ToUInt32(Int32 value)
    {
      Debug.Assert(value >= 0);
      return (UInt32)value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt32 ToUInt32(Int64 value)
    {
      Debug.Assert(value >= 0);
      Debug.Assert(value <= UInt32.MaxValue);
      return (UInt32)value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt32 ToUInt32(UInt64 value)
    {
      Debug.Assert(value <= UInt32.MaxValue);
      return (UInt32)value;
    }


    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt64 ToUInt64(sbyte value)
    {
      Debug.Assert(value >= 0);
      return (UInt64)value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt64 ToUInt64(Int16 value)
    {
      Debug.Assert(value >= 0);
      return (UInt64)value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt64 ToUInt64(Int32 value)
    {
      Debug.Assert(value >= 0);
      return (UInt64)value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt64 ToUInt64(Int64 value)
    {
      Debug.Assert(value >= 0);
      return (UInt64)value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt64 ToUInt64(UInt32 value) => value;
  }
}

//****************************************************************************************************************************************************

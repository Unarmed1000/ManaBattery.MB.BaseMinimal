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

using MB.Base.Exceptions;
using System;
using System.Runtime.CompilerServices;

//----------------------------------------------------------------------------------------------------------------------------------------------------


namespace MB.Base
{
  public static class NumericCast
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int16 ToInt16(Int32 value)
    {
      if (value >= Int16.MinValue && value <= Int16.MaxValue)
        return (Int16)value;

      if (value < 0)
        throw new ConversionUnderflowException();
      throw new ConversionOverflowException();
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int32 ToInt32(byte value) => (Int32)value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int32 ToInt32(UInt16 value) => (Int32)value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int32 ToInt32(UInt32 value)
    {
      if (value <= (UInt32)int.MaxValue)
        return (Int32)value;
      throw new ConversionOverflowException();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int32 ToInt32(float value)
    {
      var res = MathEx.MathUtil.RoundToInt32(value);
      if (res < (float)Int32.MinValue)
        throw new ConversionUnderflowException();
      if (res > (float)Int32.MaxValue)
        throw new ConversionOverflowException();
      return res;
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int32 ToInt32(double value)
    {
      var res = MathEx.MathUtil.RoundToInt32(value);
      if (res < (double)Int32.MinValue)
        throw new ConversionUnderflowException();
      if (res > (double)Int32.MaxValue)
        throw new ConversionOverflowException();
      return res;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------------------------------------------------


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte ToUInt8(sbyte value)
    {
      if (value >= 0)
        return (byte)value;
      throw new ConversionUnderflowException();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte ToUInt8(Int16 value)
    {
      if (value >= 0)
        return (byte)value;
      throw new ConversionUnderflowException();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte ToUInt8(Int32 value)
    {
      if (value >= 0 && value <= byte.MaxValue)
        return (byte)value;

      if (value < 0)
        throw new ConversionUnderflowException();
      throw new ConversionOverflowException();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte ToUInt8(UInt16 value)
    {
      if (value <= byte.MaxValue)
        return (byte)value;
      throw new ConversionOverflowException();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte ToUInt8(UInt32 value)
    {
      if (value <= byte.MaxValue)
        return (byte)value;
      throw new ConversionOverflowException();
    }


    //------------------------------------------------------------------------------------------------------------------------------------------------


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt16 ToUInt16(sbyte value)
    {
      if (value >= 0)
        return (UInt16)value;
      throw new ConversionUnderflowException();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt16 ToUInt16(Int16 value)
    {
      if (value >= 0)
        return (UInt16)value;
      throw new ConversionUnderflowException();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt16 ToUInt16(Int32 value)
    {
      if (value >= 0 && value <= UInt16.MaxValue)
        return (UInt16)value;

      if (value < 0)
        throw new ConversionUnderflowException();
      throw new ConversionOverflowException();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt16 ToUInt16(Int64 value)
    {
      if (value >= 0 && value <= UInt16.MaxValue)
        return (UInt16)value;

      if (value < 0)
        throw new ConversionUnderflowException();
      throw new ConversionOverflowException();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt16 ToUInt16(byte value)
    {
      return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt16 ToUInt16(UInt32 value)
    {
      if (value <= UInt16.MaxValue)
        return (UInt16)value;
      throw new ConversionOverflowException();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt16 ToUInt16(UInt64 value)
    {
      if (value <= UInt16.MaxValue)
        return (UInt16)value;
      throw new ConversionOverflowException();
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt32 ToUInt32(sbyte value)
    {
      if (value >= 0)
        return (UInt32)value;

      throw new ConversionUnderflowException();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt32 ToUInt32(Int16 value)
    {
      if (value >= 0)
        return (UInt32)value;
      throw new ConversionUnderflowException();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt32 ToUInt32(Int32 value)
    {
      if (value >= 0)
        return (UInt32)value;
      throw new ConversionUnderflowException();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt32 ToUInt32(UInt64 value)
    {
      if (value <= UInt32.MaxValue)
        return (UInt32)value;
      throw new ConversionOverflowException();
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt64 ToUInt64(Int64 value)
    {
      if (value >= 0)
        return (UInt64)value;
      throw new ConversionUnderflowException();
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int64 ToInt64(UInt64 value)
    {
      if (value <= (UInt64)Int64.MaxValue)
        return (Int64)value;
      throw new ConversionOverflowException();
    }
  }
}

//****************************************************************************************************************************************************

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
using System.Runtime.CompilerServices;

//----------------------------------------------------------------------------------------------------------------------------------------------------

namespace MB.Base.Bits
{
  /// <summary>
  /// Various helper methods to read bytes as little or big endian values in a safe way.
  /// Here we trade performance for correctness.
  /// </summary>
  public static class ByteSpanUtil
  {
    /// <summary>
    /// Read little endian int8 (just for completeness).
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="rValue"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ReadLE(ReadOnlySpan<byte> span, out bool rValue)
    {
      Debug.Assert(span.Length >= 1);
      rValue = (span[0] != 0 ? true : false);
      return 1;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Read a int8 from the byte array in little endian format (just for completeness).
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="rValue"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ReadLE(ReadOnlySpan<byte> span, out sbyte rValue)
    {
      Debug.Assert(span.Length >= 1);
      rValue = (sbyte)span[0];
      return 1;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Read a uint8 from the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="rValue"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ReadLE(ReadOnlySpan<byte> span, out byte rValue)
    {
      Debug.Assert(span.Length >= 1);
      rValue = span[0];
      return 1;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Read a int16 from the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="rValue"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ReadLE(ReadOnlySpan<byte> span, out Int16 rValue)
    {
      Debug.Assert(span.Length >= 2);
      rValue = (Int16)(((UInt32)span[0]) | (((UInt32)span[1]) << 8));
      return 2;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Read a uint16 from the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="rValue"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ReadLE(ReadOnlySpan<byte> span, out UInt16 rValue)
    {
      Debug.Assert(span.Length >= 2);
      rValue = (UInt16)(((UInt32)span[0]) | (((UInt32)span[1]) << 8));
      return 2;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Read a int32 from the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="rValue"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ReadLE(ReadOnlySpan<byte> span, out Int32 rValue)
    {
      Debug.Assert(span.Length >= 4);
      rValue = (Int32)(((UInt32)span[0]) | (((UInt32)span[1]) << 8) | (((UInt32)span[2]) << 16) | (((UInt32)span[3]) << 24));
      return 4;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Read a uint32 from the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="rValue"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ReadLE(ReadOnlySpan<byte> span, out UInt32 rValue)
    {
      Debug.Assert(span.Length >= 4);
      rValue = (((UInt32)span[0]) | (((UInt32)span[1]) << 8) | (((UInt32)span[2]) << 16) | (((UInt32)span[3]) << 24));
      return 4;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Read a int32 from the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="rValue"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ReadLE(ReadOnlySpan<byte> span, out Int64 rValue)
    {
      Debug.Assert(span.Length >= 8);
      rValue = (Int64)(((UInt64)span[0]) | (((UInt64)span[1]) << 8) | (((UInt64)span[2]) << 16) |
                       (((UInt64)span[3]) << 24) | (((UInt64)span[4]) << 32) | (((UInt64)span[5]) << 40) |
                       (((UInt64)span[6]) << 48) | (((UInt64)span[7]) << 56));
      return 8;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Read a uint64 from the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="rValue"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ReadLE(ReadOnlySpan<byte> span, out UInt64 rValue)
    {
      Debug.Assert(span.Length >= 8);
      rValue = (((UInt64)span[0]) | (((UInt64)span[1]) << 8) | (((UInt64)span[2]) << 16) |
                (((UInt64)span[3]) << 24) | (((UInt64)span[4]) << 32) | (((UInt64)span[5]) << 40) |
                (((UInt64)span[6]) << 48) | (((UInt64)span[7]) << 56));
      return 8;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

#if !MB_UNITY

    /// <summary>
    /// Read a uint128 from the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="rValue"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ReadLE(ReadOnlySpan<byte> span, out Int128 rValue)
    {
      Debug.Assert(span.Length >= 16);
      rValue = (Int128)((((UInt128)span[0]) | (((UInt128)span[1]) << 8) | (((UInt128)span[2]) << 16) |
                        (((UInt128)span[3]) << 24) | (((UInt128)span[4]) << 32) | (((UInt128)span[5]) << 40) |
                        (((UInt128)span[6]) << 48) | (((UInt128)span[7]) << 56) |
                        (((UInt128)span[8]) << 64) | (((UInt128)span[9]) << 72) | (((UInt128)span[10]) << 80) | (((UInt128)span[11]) << 88) |
                        (((UInt128)span[12]) << 96) | (((UInt128)span[13]) << 104) | (((UInt128)span[14]) << 112) | (((UInt128)span[15]) << 120)));
      return 16;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Read a uint128 from the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="rValue"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ReadLE(ReadOnlySpan<byte> span, out UInt128 rValue)
    {
      Debug.Assert(span.Length >= 16);
      rValue = (((UInt128)span[0]) | (((UInt128)span[1]) << 8) | (((UInt128)span[2]) << 16) |
                (((UInt128)span[3]) << 24) | (((UInt128)span[4]) << 32) | (((UInt128)span[5]) << 40) |
                (((UInt128)span[6]) << 48) | (((UInt128)span[7]) << 56) |
                (((UInt128)span[8]) << 64) | (((UInt128)span[9]) << 72) | (((UInt128)span[10]) << 80) | (((UInt128)span[11]) << 88) |
                (((UInt128)span[12]) << 96) | (((UInt128)span[13]) << 104) | (((UInt128)span[14]) << 112) | (((UInt128)span[15]) << 120));
      return 16;
    }

#endif

    /// <summary>
    /// Read a float from the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="rValue"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static int ReadLE(ReadOnlySpan<byte> span, out float rValue)
    {
      Debug.Assert(span.Length >= 4);
      if (BitConverter.IsLittleEndian)
      {
        rValue = BitConverter.ToSingle(span);
        return 4;
      }

      Span<byte> tmp = stackalloc byte[4];
      span.Slice(0, 4).CopyTo(tmp);
      ReverseBytes(tmp);
      rValue = BitConverter.ToSingle(tmp);
      return 4;
    }

    /// <summary>
    /// Read a double from the byte array in little endian format.
    /// BEWARE the supplied array can be modified by this method!!!!!
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="rValue"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static int ReadLE(ReadOnlySpan<byte> span, out double rValue)
    {
      Debug.Assert(span.Length >= 8);
      if (BitConverter.IsLittleEndian)
      {
        rValue = BitConverter.ToDouble(span);
        return 8;
      }

      Span<byte> tmp = stackalloc byte[8];
      span.Slice(0, 8).CopyTo(tmp);
      ReverseBytes(tmp);
      rValue = BitConverter.ToDouble(tmp);
      return 8;
    }

    /// <summary>
    /// Read a float from the byte array in little endian format.
    /// BEWARE the supplied array can be modified by this method!!!!!
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="rValue"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static int ReadLEArrayCanBeModified(Span<byte> span, out float rValue)
    {
      Debug.Assert(span.Length >= 4);
      if (!BitConverter.IsLittleEndian)
        ReverseBytes(span.Slice(0, 4));
      rValue = BitConverter.ToSingle(span);
      return 4;
    }

    /// <summary>
    /// Read a double from the byte array in little endian format.
    /// BEWARE the supplied array can be modified by this method!!!!!
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="rValue"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static int ReadLEArrayCanBeModified(Span<byte> span, out double rValue)
    {
      Debug.Assert(span.Length >= 8);
      if (!BitConverter.IsLittleEndian)
        ReverseBytes(span.Slice(0, 8));
      rValue = BitConverter.ToDouble(span);
      return 8;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Read a little endian bool
    /// This just exist for parity.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="size"></param>
    /// <param name="offset"></param>
    /// <returns>the Int16 value</returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ReadBoolLE(ReadOnlySpan<byte> span)
    {
      Debug.Assert(span.Length >= 1);
      return span[0] != 0;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Read a little endian Int8
    /// This just exist for parity.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="size"></param>
    /// <param name="offset"></param>
    /// <returns>the Int16 value</returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static sbyte ReadInt8LE(ReadOnlySpan<byte> span)
    {
      Debug.Assert(span.Length >= 1);
      return (sbyte)span[0];
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Read a little endian UInt8
    /// This just exist for parity.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="size"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte ReadUInt8LE(ReadOnlySpan<byte> span)
    {
      Debug.Assert(span.Length >= 1);
      return span[0];
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Read a little endian Int16
    /// </summary>
    /// <param name="array"></param>
    /// <param name="size"></param>
    /// <param name="offset"></param>
    /// <returns>the Int16 value</returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int16 ReadInt16LE(ReadOnlySpan<byte> span)
    {
      Debug.Assert(span.Length >= 2);
      return (Int16)(((UInt32)span[0]) | (((UInt32)span[1]) << 8));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Read a little endian UInt16
    /// </summary>
    /// <param name="array"></param>
    /// <param name="size"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt16 ReadUInt16LE(ReadOnlySpan<byte> span)
    {
      Debug.Assert(span.Length >= 2);
      return (UInt16)(((UInt32)span[0]) | (((UInt32)span[1]) << 8));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Read a little endian Int32
    /// </summary>
    /// <param name="array"></param>
    /// <param name="size"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int32 ReadInt32LE(ReadOnlySpan<byte> span)
    {
      Debug.Assert(span.Length >= 4);
      return (Int32)(((UInt32)span[0]) | (((UInt32)span[1]) << 8) | (((UInt32)span[2]) << 16) | (((UInt32)span[3]) << 24));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt32 ReadUInt32LE(ReadOnlySpan<byte> span)
    {
      Debug.Assert(span.Length >= 4);
      return (((UInt32)span[0]) | (((UInt32)span[1]) << 8) | (((UInt32)span[2]) << 16) | (((UInt32)span[3]) << 24));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Read a little endian Int64
    /// </summary>
    /// <param name="array"></param>
    /// <param name="size"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int64 ReadInt64LE(ReadOnlySpan<byte> span)
    {
      Debug.Assert(span.Length >= 4);
      return (Int64)(((UInt64)span[0]) | (((UInt64)span[1]) << 8) | (((UInt64)span[2]) << 16) | (((UInt64)span[3]) << 24) |
                    (((UInt64)span[4]) << 32) | (((UInt64)span[5]) << 40) | (((UInt64)span[6]) << 48) | (((UInt64)span[7]) << 56));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt64 ReadUInt64LE(ReadOnlySpan<byte> span)
    {
      Debug.Assert(span.Length >= 8);
      return (((UInt64)span[0]) | (((UInt64)span[1]) << 8) | (((UInt64)span[2]) << 16) | (((UInt64)span[3]) << 24) |
             (((UInt64)span[4]) << 32) | (((UInt64)span[5]) << 40) | (((UInt64)span[6]) << 48) | (((UInt64)span[7]) << 56));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

#if !MB_UNITY

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int128 ReadInt128LE(ReadOnlySpan<byte> span)
    {
      Debug.Assert(span.Length >= 16);
      return (Int128)((((UInt128)span[0]) | (((UInt128)span[1]) << 8) | (((UInt128)span[2]) << 16) | (((UInt128)span[3]) << 24) |
                      (((UInt128)span[4]) << 32) | (((UInt128)span[5]) << 40) | (((UInt128)span[6]) << 48) | (((UInt128)span[7]) << 56) |
                      (((UInt128)span[8]) << 64) | (((UInt128)span[9]) << 72) | (((UInt128)span[10]) << 80) | (((UInt128)span[11]) << 88) |
                      (((UInt128)span[12]) << 96) | (((UInt128)span[13]) << 104) | (((UInt128)span[14]) << 112) | (((UInt128)span[15]) << 120)));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt128 ReadUInt128LE(ReadOnlySpan<byte> span)
    {
      Debug.Assert(span.Length >= 16);
      return (((UInt128)span[0]) | (((UInt128)span[1]) << 8) | (((UInt128)span[2]) << 16) | (((UInt128)span[3]) << 24) |
             (((UInt128)span[4]) << 32) | (((UInt128)span[5]) << 40) | (((UInt128)span[6]) << 48) | (((UInt128)span[7]) << 56) |
             (((UInt128)span[8]) << 64) | (((UInt128)span[9]) << 72) | (((UInt128)span[10]) << 80) | (((UInt128)span[11]) << 88) |
             (((UInt128)span[12]) << 96) | (((UInt128)span[13]) << 104) | (((UInt128)span[14]) << 112) | (((UInt128)span[15]) << 120));
    }

#endif

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static float ReadFloatLE(ReadOnlySpan<byte> span)
    {
      Debug.Assert(span.Length >= 4);
      if (BitConverter.IsLittleEndian)
        return BitConverter.ToSingle(span);

      Span<byte> tmp = stackalloc byte[4];
      span.Slice(0, 4).CopyTo(tmp);
      ReverseBytes(tmp);
      return BitConverter.ToSingle(tmp);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static double ReadDoubleLE(ReadOnlySpan<byte> span)
    {
      Debug.Assert(span.Length >= 8);
      if (BitConverter.IsLittleEndian)
        return BitConverter.ToDouble(span);

      Span<byte> tmp = stackalloc byte[8];
      span.Slice(0, 8).CopyTo(tmp);
      ReverseBytes(tmp);
      return BitConverter.ToDouble(tmp);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ReadBoolLE(ref ReadOnlySpan<byte> rSpan)
    {
      var value = ReadBoolLE(rSpan);
      rSpan = rSpan.Slice(sizeof(byte));
      return value;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static sbyte ReadInt8LE(ref ReadOnlySpan<byte> rSpan)
    {
      var value = ReadInt8LE(rSpan);
      rSpan = rSpan.Slice(sizeof(sbyte));
      return value;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte ReadUInt8LE(ref ReadOnlySpan<byte> rSpan)
    {
      var value = ReadUInt8LE(rSpan);
      rSpan = rSpan.Slice(sizeof(byte));
      return value;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int16 ReadInt16LE(ref ReadOnlySpan<byte> rSpan)
    {
      var value = ReadInt16LE(rSpan);
      rSpan = rSpan.Slice(sizeof(Int16));
      return value;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt16 ReadUInt16LE(ref ReadOnlySpan<byte> rSpan)
    {
      var value = ReadUInt16LE(rSpan);
      rSpan = rSpan.Slice(sizeof(UInt16));
      return value;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int32 ReadInt32LE(ref ReadOnlySpan<byte> rSpan)
    {
      var value = ReadInt32LE(rSpan);
      rSpan = rSpan.Slice(sizeof(Int32));
      return value;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt32 ReadUInt32LE(ref ReadOnlySpan<byte> rSpan)
    {
      var value = ReadUInt32LE(rSpan);
      rSpan = rSpan.Slice(sizeof(UInt32));
      return value;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int64 ReadInt64LE(ref ReadOnlySpan<byte> rSpan)
    {
      var value = ReadInt64LE(rSpan);
      rSpan = rSpan.Slice(sizeof(Int64));
      return value;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt64 ReadUInt64LE(ref ReadOnlySpan<byte> rSpan)
    {
      var value = ReadUInt64LE(rSpan);
      rSpan = rSpan.Slice(sizeof(UInt64));
      return value;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

#if ! MB_UNITY

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int128 ReadInt128LE(ref ReadOnlySpan<byte> rSpan)
    {
      var value = ReadInt128LE(rSpan);
      //rSpan = rSpan.Slice(sizeof(Int128));
      rSpan = rSpan.Slice(16);
      return value;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt128 ReadUInt128LE(ref ReadOnlySpan<byte> rSpan)
    {
      var value = ReadUInt128LE(rSpan);
      //rSpan = rSpan.Slice(sizeof(UInt128));
      rSpan = rSpan.Slice(16);
      return value;
    }

#endif

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float ReadFloatLE(ref ReadOnlySpan<byte> rSpan)
    {
      var value = ReadFloatLE(rSpan);
      rSpan = rSpan.Slice(sizeof(float));
      return value;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double ReadDoubleLE(ref ReadOnlySpan<byte> rSpan)
    {
      var value = ReadDoubleLE(rSpan);
      rSpan = rSpan.Slice(sizeof(double));
      return value;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteBoolLE(Span<byte> dst, bool value)
    {
      Debug.Assert(dst.Length >= 1);

      dst[0] = (byte)(value ? 1 : 0);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteInt8LE(Span<byte> dst, sbyte value)
    {
      Debug.Assert(dst.Length >= 1);

      dst[0] = (byte)(value & 0xFF);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteUInt8LE(Span<byte> dst, byte value)
    {
      Debug.Assert(dst.Length >= 1);

      dst[0] = (byte)(value & 0xFF);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteInt16LE(Span<byte> dst, Int16 value)
    {
      Debug.Assert(dst.Length >= 2);

      dst[0] = (byte)(value & 0xFF);
      dst[1] = (byte)((value >> 8) & 0xFF);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteUInt16LE(Span<byte> dst, UInt16 value)
    {
      Debug.Assert(dst.Length >= 2);

      dst[0] = (byte)(value & 0xFF);
      dst[1] = (byte)((value >> 8) & 0xFF);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteInt32LE(Span<byte> dst, Int32 value)
    {
      Debug.Assert(dst.Length >= 4);

      dst[0] = (byte)(value & 0xFF);
      dst[1] = (byte)((value >> 8) & 0xFF);
      dst[2] = (byte)((value >> 16) & 0xFF);
      dst[3] = (byte)((value >> 24) & 0xFF);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteUInt32LE(Span<byte> dst, UInt32 value)
    {
      Debug.Assert(dst.Length >= 4);

      dst[0] = (byte)(value & 0xFF);
      dst[1] = (byte)((value >> 8) & 0xFF);
      dst[2] = (byte)((value >> 16) & 0xFF);
      dst[3] = (byte)((value >> 24) & 0xFF);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteInt64LE(Span<byte> dst, Int64 value)
    {
      Debug.Assert(dst.Length >= 8);

      UInt64 valueEx = (UInt64)value;
      dst[0] = (byte)(valueEx & 0xFF);
      dst[1] = (byte)((valueEx >> 8) & 0xFF);
      dst[2] = (byte)((valueEx >> 16) & 0xFF);
      dst[3] = (byte)((valueEx >> 24) & 0xFF);
      dst[4] = (byte)((valueEx >> 32) & 0xFF);
      dst[5] = (byte)((valueEx >> 40) & 0xFF);
      dst[6] = (byte)((valueEx >> 48) & 0xFF);
      dst[7] = (byte)((valueEx >> 56) & 0xFF);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteUInt64LE(Span<byte> dst, UInt64 value)
    {
      Debug.Assert(dst.Length >= 8);

      dst[0] = (byte)(value & 0xFF);
      dst[1] = (byte)((value >> 8) & 0xFF);
      dst[2] = (byte)((value >> 16) & 0xFF);
      dst[3] = (byte)((value >> 24) & 0xFF);
      dst[4] = (byte)((value >> 32) & 0xFF);
      dst[5] = (byte)((value >> 40) & 0xFF);
      dst[6] = (byte)((value >> 48) & 0xFF);
      dst[7] = (byte)((value >> 56) & 0xFF);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

#if !MB_UNITY

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteInt128LE(Span<byte> dst, Int128 value)
    {
      Debug.Assert(dst.Length >= 16);

      UInt128 valueEx = (UInt128)value;
      dst[0] = (byte)(valueEx & 0xFF);
      dst[1] = (byte)((valueEx >> 8) & 0xFF);
      dst[2] = (byte)((valueEx >> 16) & 0xFF);
      dst[3] = (byte)((valueEx >> 24) & 0xFF);
      dst[4] = (byte)((valueEx >> 32) & 0xFF);
      dst[5] = (byte)((valueEx >> 40) & 0xFF);
      dst[6] = (byte)((valueEx >> 48) & 0xFF);
      dst[7] = (byte)((valueEx >> 56) & 0xFF);
      // write the second half
      dst[8] = (byte)((valueEx >> 64) & 0xFF);
      dst[9] = (byte)((valueEx >> 72) & 0xFF);
      dst[10] = (byte)((valueEx >> 80) & 0xFF);
      dst[11] = (byte)((valueEx >> 88) & 0xFF);
      dst[12] = (byte)((valueEx >> 96) & 0xFF);
      dst[13] = (byte)((valueEx >> 104) & 0xFF);
      dst[14] = (byte)((valueEx >> 112) & 0xFF);
      dst[15] = (byte)((valueEx >> 120) & 0xFF);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteUInt128LE(Span<byte> dst, UInt128 value)
    {
      Debug.Assert(dst.Length >= 16);

      dst[0] = (byte)(value & 0xFF);
      dst[1] = (byte)((value >> 8) & 0xFF);
      dst[2] = (byte)((value >> 16) & 0xFF);
      dst[3] = (byte)((value >> 24) & 0xFF);
      dst[4] = (byte)((value >> 32) & 0xFF);
      dst[5] = (byte)((value >> 40) & 0xFF);
      dst[6] = (byte)((value >> 48) & 0xFF);
      dst[7] = (byte)((value >> 56) & 0xFF);
      // write the second half
      dst[8] = (byte)((value >> 64) & 0xFF);
      dst[9] = (byte)((value >> 72) & 0xFF);
      dst[10] = (byte)((value >> 80) & 0xFF);
      dst[11] = (byte)((value >> 88) & 0xFF);
      dst[12] = (byte)((value >> 96) & 0xFF);
      dst[13] = (byte)((value >> 104) & 0xFF);
      dst[14] = (byte)((value >> 112) & 0xFF);
      dst[15] = (byte)((value >> 120) & 0xFF);
    }

#endif

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Write a float to the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static void WriteFloatLE(Span<byte> span, float value)
    {
      Debug.Assert(span.Length >= 4);
      if (!BitConverter.TryWriteBytes(span, value))
        throw new Exception("Failed to convert float to bytes");
      if (!BitConverter.IsLittleEndian)
        ByteArrayUtil.ReverseBytes(span.Slice(0, 4));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Write a double to the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static void WriteDoubleLE(Span<byte> span, double value)
    {
      Debug.Assert(span.Length >= 8);
      if (!BitConverter.TryWriteBytes(span, value))
        throw new Exception("Failed to convert double to bytes");
      if (!BitConverter.IsLittleEndian)
        ByteArrayUtil.ReverseBytes(span.Slice(0, 8));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteUInt64BE(Span<byte> dst, UInt64 value)
    {
      Debug.Assert(dst.Length >= 8);

      dst[0] = (byte)((value >> 56) & 0xFF);
      dst[1] = (byte)((value >> 48) & 0xFF);
      dst[2] = (byte)((value >> 40) & 0xFF);
      dst[3] = (byte)((value >> 32) & 0xFF);
      dst[4] = (byte)((value >> 24) & 0xFF);
      dst[5] = (byte)((value >> 16) & 0xFF);
      dst[6] = (byte)((value >> 8) & 0xFF);
      dst[7] = (byte)(value & 0xFF);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------------------------------------------------

    ///// <summary>
    ///// Read a int32 from the byte array in little endian format.
    ///// </summary>
    ///// <param name="array"></param>
    ///// <param name="rOffset"></param>
    ///// <param name="value"></param>
    //public static void ReadLE(ReadOnlySpan<byte> span, ref int rOffset, out Int32 rValue)
    //{
    //  rOffset += ReadLE(array, rOffset, out rValue);
    //}

    ////------------------------------------------------------------------------------------------------------------------------------------------------

    ///// <summary>
    ///// Read a uint32 from the byte array in little endian format.
    ///// </summary>
    ///// <param name="array"></param>
    ///// <param name="rOffset"></param>
    ///// <param name="value"></param>
    //public static void ReadLE(ReadOnlySpan<byte> span, ref int rOffset, out UInt32 rValue)
    //{
    //  rOffset += ReadLE(array, rOffset, out rValue);
    //}

    //------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Write a int8 to the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int WriteLE(Span<byte> span, bool value)
    {
      span[0] = (byte)(value ? 1 : 0);
      return 1;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Write a int8 to the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int WriteLE(Span<byte> span, sbyte value)
    {
      Debug.Assert(span.Length >= 1);
      span[0] = (byte)value;
      return 1;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Write a uint8 to the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int WriteLE(Span<byte> span, byte value)
    {
      Debug.Assert(span.Length >= 1);
      span[0] = value;
      return 1;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Write a int16 to the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int WriteLE(Span<byte> span, Int16 value)
    {
      Debug.Assert(span.Length >= 2);
      UInt16 valueEx = (UInt16)value;
      span[0] = (byte)(valueEx & 0xFF);
      span[1] = (byte)((valueEx >> 8) & 0xFF);
      return 2;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Write a uint16 to the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int WriteLE(Span<byte> span, UInt16 value)
    {
      Debug.Assert(span.Length >= 2);
      span[0] = (byte)(value & 0xFF);
      span[1] = (byte)((value >> 8) & 0xFF);
      return 2;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Write a int32 to the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int WriteLE(Span<byte> span, Int32 value)
    {
      Debug.Assert(span.Length >= 4);
      UInt32 valueEx = (UInt32)value;
      span[0] = (byte)(valueEx & 0xFF);
      span[1] = (byte)((valueEx >> 8) & 0xFF);
      span[2] = (byte)((valueEx >> 16) & 0xFF);
      span[3] = (byte)((valueEx >> 24) & 0xFF);
      return 4;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Write a uint32 to the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int WriteLE(Span<byte> span, UInt32 value)
    {
      Debug.Assert(span.Length >= 4);
      span[0] = (byte)(value & 0xFF);
      span[1] = (byte)((value >> 8) & 0xFF);
      span[2] = (byte)((value >> 16) & 0xFF);
      span[3] = (byte)((value >> 24) & 0xFF);
      return 4;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Write a int64 to the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int WriteLE(Span<byte> span, Int64 value)
    {
      Debug.Assert(span.Length >= 8);
      UInt64 valueEx = (UInt64)value;
      span[0] = (byte)(valueEx & 0xFF);
      span[1] = (byte)((valueEx >> 8) & 0xFF);
      span[2] = (byte)((valueEx >> 16) & 0xFF);
      span[3] = (byte)((valueEx >> 24) & 0xFF);
      span[4] = (byte)((valueEx >> 32) & 0xFF);
      span[5] = (byte)((valueEx >> 40) & 0xFF);
      span[6] = (byte)((valueEx >> 48) & 0xFF);
      span[7] = (byte)((valueEx >> 56) & 0xFF);
      return 8;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Write a uint64 to the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int WriteLE(Span<byte> span, UInt64 value)
    {
      Debug.Assert(span.Length >= 8);
      span[0] = (byte)(value & 0xFF);
      span[1] = (byte)((value >> 8) & 0xFF);
      span[2] = (byte)((value >> 16) & 0xFF);
      span[3] = (byte)((value >> 24) & 0xFF);
      span[4] = (byte)((value >> 32) & 0xFF);
      span[5] = (byte)((value >> 40) & 0xFF);
      span[6] = (byte)((value >> 48) & 0xFF);
      span[7] = (byte)((value >> 56) & 0xFF);
      return 8;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

#if ! MB_UNITY

    /// <summary>
    /// Write a int64 to the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int WriteLE(Span<byte> span, Int128 value)
    {
      Debug.Assert(span.Length >= 16);
      UInt128 valueEx = (UInt128)value;
      span[0] = (byte)(valueEx & 0xFF);
      span[1] = (byte)((valueEx >> 8) & 0xFF);
      span[2] = (byte)((valueEx >> 16) & 0xFF);
      span[3] = (byte)((valueEx >> 24) & 0xFF);
      span[4] = (byte)((valueEx >> 32) & 0xFF);
      span[5] = (byte)((valueEx >> 40) & 0xFF);
      span[6] = (byte)((valueEx >> 48) & 0xFF);
      span[7] = (byte)((valueEx >> 56) & 0xFF);

      span[8] = (byte)((valueEx >> 64) & 0xFF);
      span[9] = (byte)((valueEx >> 72) & 0xFF);
      span[10] = (byte)((valueEx >> 80) & 0xFF);
      span[11] = (byte)((valueEx >> 88) & 0xFF);
      span[12] = (byte)((valueEx >> 96) & 0xFF);
      span[13] = (byte)((valueEx >> 104) & 0xFF);
      span[14] = (byte)((valueEx >> 112) & 0xFF);
      span[15] = (byte)((valueEx >> 120) & 0xFF);
      return 8;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Write a uint64 to the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int WriteLE(Span<byte> span, UInt128 value)
    {
      Debug.Assert(span.Length >= 8);
      span[0] = (byte)(value & 0xFF);
      span[1] = (byte)((value >> 8) & 0xFF);
      span[2] = (byte)((value >> 16) & 0xFF);
      span[3] = (byte)((value >> 24) & 0xFF);
      span[4] = (byte)((value >> 32) & 0xFF);
      span[5] = (byte)((value >> 40) & 0xFF);
      span[6] = (byte)((value >> 48) & 0xFF);
      span[7] = (byte)((value >> 56) & 0xFF);

      span[8] = (byte)((value >> 64) & 0xFF);
      span[9] = (byte)((value >> 72) & 0xFF);
      span[10] = (byte)((value >> 80) & 0xFF);
      span[11] = (byte)((value >> 88) & 0xFF);
      span[12] = (byte)((value >> 96) & 0xFF);
      span[13] = (byte)((value >> 104) & 0xFF);
      span[14] = (byte)((value >> 112) & 0xFF);
      span[15] = (byte)((value >> 120) & 0xFF);
      return 8;
    }

#endif
    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Write a uint64 to the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static int WriteLE(Span<byte> span, float value)
    {
      Debug.Assert(span.Length >= 4);
      if (!BitConverter.TryWriteBytes(span, value))
        throw new Exception("Failed to convert float to bytes");
      if (!BitConverter.IsLittleEndian)
        ByteArrayUtil.ReverseBytes(span.Slice(0, 4));
      return 4;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Write a uint64 to the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static int WriteLE(Span<byte> span, double value)
    {
      Debug.Assert(span.Length >= 8);
      if (!BitConverter.TryWriteBytes(span, value))
        throw new Exception("Failed to convert double to bytes");
      if (!BitConverter.IsLittleEndian)
        ByteArrayUtil.ReverseBytes(span.Slice(0, 8));
      return 8;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------------------------------------------------

    ///// <summary>
    ///// Write a int32 to the byte array in little endian format.
    ///// </summary>
    ///// <param name="array"></param>
    ///// <param name="rOffset"></param>
    ///// <param name="value"></param>
    //public static void WriteLE(ReadOnlySpan<byte> span, ref int rOffset, Int32 value)
    //{
    //  rOffset += WriteLE(array, rOffset, value);
    //}

    ////------------------------------------------------------------------------------------------------------------------------------------------------

    ///// <summary>
    ///// Write a uint32 to the byte array in little endian format.
    ///// </summary>
    ///// <param name="array"></param>
    ///// <param name="rOffset"></param>
    ///// <param name="value"></param>
    //public static void WriteLE(ReadOnlySpan<byte> span, ref int rOffset, UInt32 value)
    //{
    //  rOffset += WriteLE(array, rOffset, value);
    //}

    //------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ReadBoolLE(ReadOnlySpan<byte> span, out int rBytesRead)
    {
      rBytesRead = sizeof(byte);
      return ReadBoolLE(span);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static sbyte ReadInt8LE(ReadOnlySpan<byte> span, out int rBytesRead)
    {
      rBytesRead = sizeof(sbyte);
      return ReadInt8LE(span);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte ReadUInt8LE(ReadOnlySpan<byte> span, out int rBytesRead)
    {
      rBytesRead = sizeof(byte);
      return ReadUInt8LE(span);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int16 ReadInt16LE(ReadOnlySpan<byte> span, out int rBytesRead)
    {
      rBytesRead = sizeof(Int16);
      return ReadInt16LE(span);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt16 ReadUInt16LE(ReadOnlySpan<byte> span, out int rBytesRead)
    {
      rBytesRead = sizeof(UInt16);
      return ReadUInt16LE(span);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int32 ReadInt32LE(ReadOnlySpan<byte> span, out int rBytesRead)
    {
      rBytesRead = sizeof(Int32);
      return ReadInt32LE(span);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt32 ReadUInt32LE(ReadOnlySpan<byte> span, out int rBytesRead)
    {
      rBytesRead = sizeof(UInt32);
      return ReadUInt32LE(span);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int64 ReadInt64LE(ReadOnlySpan<byte> span, out int rBytesRead)
    {
      rBytesRead = sizeof(Int64);
      return ReadInt64LE(span);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt64 ReadUInt64LE(ReadOnlySpan<byte> span, out int rBytesRead)
    {
      rBytesRead = sizeof(UInt64);
      return ReadUInt64LE(span);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

#if ! MB_UNITY


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int128 ReadInt128LE(ReadOnlySpan<byte> span, out int rBytesRead)
    {
      rBytesRead = 16;
      return ReadInt128LE(span);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt128 ReadUInt128LE(ReadOnlySpan<byte> span, out int rBytesRead)
    {
      rBytesRead = 16;
      return ReadUInt128LE(span);
    }

#endif

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float ReadFloatLE(ReadOnlySpan<byte> span, out int rBytesRead)
    {
      rBytesRead = sizeof(float);
      return ReadFloatLE(span);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double ReadDoubleLE(ReadOnlySpan<byte> span, out int rBytesRead)
    {
      rBytesRead = sizeof(double);
      return ReadDoubleLE(span);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static void ReverseBytes(Span<byte> inSpan)
    {
      Debug.Assert(inSpan.Length >= 0);

      byte temp;
      int highCtr = inSpan.Length - 1;

      for (int ctr = 0; ctr < inSpan.Length / 2; ctr++)
      {
        temp = inSpan[ctr];
        inSpan[ctr] = inSpan[highCtr];
        inSpan[highCtr] = temp;
        highCtr -= 1;
      }
    }
  }
}

//****************************************************************************************************************************************************

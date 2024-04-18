#nullable enable
//****************************************************************************************************************************************************
//* BSD 3-Clause License
//*
//* Copyright (c) 2015-2024, Mana Battery
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

//----------------------------------------------------------------------------------------------------------------------------------------------------

namespace MB.Base.Compression
{

  // https://developers.google.com/protocol-buffers/docs/encoding?hl=en
  // Inspired by this
  // We use a slightly differnet format for encoding the values
  // But we do use ZigZag encoding for signed values

  public static class ValueCompression
  {
    public const int MaxSimpleInt16ByteSize = 3;
    public const int MaxSimpleUInt16ByteSize = 3;
    public const int MaxSimpleInt32ByteSize = 5;
    public const int MaxSimpleUInt32ByteSize = 5;
    public const int MaxSimpleInt64ByteSize = 9;
    public const int MaxSimpleUInt64ByteSize = 9;

    //------------------------------------------------------------------------------------------------------------------------------------------------
    // 16 bit support
    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static UInt16 ReadSimpleUInt16(byte[] array, int offset)
    {
      UInt32 value = ReadSimpleUInt32(array, offset);
      return NumericCast.ToUInt16(value);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static UInt16 ReadSimpleUInt16(ReadOnlySpan<byte> span, out int rBytesRead)
    {
      UInt32 value = ReadSimpleUInt32(span, out rBytesRead);
      return NumericCast.ToUInt16(value);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static UInt16 ReadSimpleUInt16(ref ReadOnlySpan<byte> rSpan)
    {
      UInt32 value = ReadSimpleUInt32(ref rSpan);
      return NumericCast.ToUInt16(value);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static int ReadSimple(byte[] array, int startIndex, out UInt16 rResult)
    {
      int bytesRead = ReadSimple(array, startIndex, out UInt32 result);
      rResult = NumericCast.ToUInt16(result);
      return bytesRead;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static int ReadSimple(ReadOnlySpan<byte> span, out UInt16 rResult)
    {
      int bytesRead = ReadSimple(span, out UInt32 result);
      rResult = NumericCast.ToUInt16(result);
      return bytesRead;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static Int16 ReadSimpleInt16(byte[] array, int offset)
    {
      Debug.Assert(array != null);

      UInt16 value = ReadSimpleUInt16(array, offset);

      return (Int16)((value >> 1) ^ (-(value & 1)));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static Int16 ReadSimpleInt16(ReadOnlySpan<byte> span, out int rBytesRead)
    {
      UInt16 value = ReadSimpleUInt16(span, out rBytesRead);
      return (Int16)((value >> 1) ^ (-(value & 1)));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static Int16 ReadSimpleInt16(ref ReadOnlySpan<byte> rSpan)
    {
      UInt16 value = ReadSimpleUInt16(ref rSpan);

      return (Int16)((value >> 1) ^ (-(value & 1)));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static int ReadSimple(byte[] array, int startIndex, out Int16 rResult)
    {
      Debug.Assert(array != null);

      UInt16 value;
      int result = ReadSimple(array, startIndex, out value);
      rResult = (Int16)((value >> 1) ^ (-(value & 1)));
      return result;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static int ReadSimple(ReadOnlySpan<byte> span, out Int16 rResult)
    {
      UInt16 value;
      int result = ReadSimple(span, out value);
      rResult = (Int16)((value >> 1) ^ (-(value & 1)));
      return result;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Encodes a integer into a variable length encoding where the length can be determined from the first byte.
    /// The encoding favors small values.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    /// <returns>the number of bytes written</returns>
    public static int WriteSimple(byte[] array, int offset, Int16 value)
    {
      Debug.Assert(array != null);

      // ZigZag encode signed numbers
      return WriteSimple(array, offset, (UInt16)((value << 1) ^ (value >> 15)));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Encodes a integer into a variable length encoding where the length can be determined from the first byte.
    /// The encoding favors small values.
    /// </summary>
    /// <param name="span"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    /// <returns>the number of bytes written</returns>
    public static int WriteSimple(Span<byte> span, Int16 value)
    {
      // ZigZag encode signed numbers
      return WriteSimple(span, (UInt16)((value << 1) ^ (value >> 15)));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Encodes a integer into a variable length encoding where the length can be determined from the first byte.
    /// The encoding favors small values.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    /// <returns>the number of bytes written</returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static int WriteSimple(byte[] array, int offset, UInt16 value)
    {
      Debug.Assert(array != null);
      if (value <= 0x7F)
      {
        // <=7 bits value
        array[offset] = (byte)value;
        return 1;
      }
      if (value <= 0x3FFF)
      {
        // <=14 bits value
        array[offset + 0] = (byte)(0x80 | (value & 0x3F));
        array[offset + 1] = (byte)((value & 0x3FC0) >> 6);
        return 2;
      }
      // <=21 bits value
      array[offset + 0] = (byte)(0xC0 | (value & 0x1F));
      array[offset + 1] = (byte)((value & 0x001FE0) >> 5);
      array[offset + 2] = (byte)((value & 0x1FE000) >> 13);
      return 3;
    }

    /// <summary>
    /// Encodes a integer into a variable length encoding where the length can be determined from the first byte.
    /// The encoding favors small values.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    /// <returns>the number of bytes written</returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static int WriteSimple(Span<byte> array, UInt16 value)
    {
      Debug.Assert(array != null);
      if (value <= 0x7F)
      {
        // <=7 bits value
        array[0] = (byte)value;
        return 1;
      }
      if (value <= 0x3FFF)
      {
        // <=14 bits value
        array[0] = (byte)(0x80 | (value & 0x3F));
        array[1] = (byte)((value & 0x3FC0) >> 6);
        return 2;
      }
      // <=21 bits value
      array[0] = (byte)(0xC0 | (value & 0x1F));
      array[1] = (byte)((value & 0x001FE0) >> 5);
      array[2] = (byte)((value & 0x1FE000) >> 13);
      return 3;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------
    // 32 bit support
    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static UInt32 ReadSimpleUInt32(byte[] array, int offset)
    {
      Debug.Assert(array != null);
      UInt32 value = array[offset];
      if ((value & 0x80) == 0)
      {
        return value;
      }
      if ((value & 0x40) == 0)
      {
        return (value & 0x3F) | (((UInt32)array[offset + 1]) << 6);
      }
      if ((value & 0x20) == 0)
      {
        return (value & 0x1F) | (((UInt32)array[offset + 1]) << 5) | (((UInt32)array[offset + 2]) << 13);
      }
      if ((value & 0x10) == 0)
      {
        return (value & 0x0F) | (((UInt32)array[offset + 1]) << 4) | (((UInt32)array[offset + 2]) << 12) | (((UInt32)array[offset + 3]) << 20);
      }
      return (value & 0x07) | (((UInt32)array[offset + 1]) << 3) | (((UInt32)array[offset + 2]) << 11) | (((UInt32)array[offset + 3]) << 19) |
              (((UInt32)array[offset + 4]) << 27);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static UInt32 ReadSimpleUInt32(ReadOnlySpan<byte> span, out int rBytesRead)
    {
      UInt32 value = span[0];
      if ((value & 0x80) == 0)
      {
        rBytesRead = 1;
        return value;
      }
      if ((value & 0x40) == 0)
      {
        rBytesRead = 2;
        return (value & 0x3F) | (((UInt32)span[1]) << 6);
      }
      if ((value & 0x20) == 0)
      {
        rBytesRead = 3;
        return (value & 0x1F) | (((UInt32)span[1]) << 5) | (((UInt32)span[2]) << 13);
      }
      if ((value & 0x10) == 0)
      {
        rBytesRead = 4;
        return (value & 0x0F) | (((UInt32)span[1]) << 4) | (((UInt32)span[2]) << 12) | (((UInt32)span[3]) << 20);
      }

      rBytesRead = 5;
      return (value & 0x07) | (((UInt32)span[1]) << 3) | (((UInt32)span[2]) << 11) | (((UInt32)span[3]) << 19) | (((UInt32)span[4]) << 27);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static UInt32 ReadSimpleUInt32(ref ReadOnlySpan<byte> rSpan)
    {
      UInt32 value = rSpan[0];
      if ((value & 0x80) == 0)
      {
        rSpan = rSpan.Slice(1);
        return value;
      }
      if ((value & 0x40) == 0)
      {
        value = (value & 0x3F) | (((UInt32)rSpan[1]) << 6);
        rSpan = rSpan.Slice(2);
        return value;
      }
      if ((value & 0x20) == 0)
      {
        value = (value & 0x1F) | (((UInt32)rSpan[1]) << 5) | (((UInt32)rSpan[2]) << 13);
        rSpan = rSpan.Slice(3);
        return value;
      }
      if ((value & 0x10) == 0)
      {
        value = (value & 0x0F) | (((UInt32)rSpan[1]) << 4) | (((UInt32)rSpan[2]) << 12) | (((UInt32)rSpan[3]) << 20);
        rSpan = rSpan.Slice(4);
        return value;
      }

      value = (value & 0x07) | (((UInt32)rSpan[1]) << 3) | (((UInt32)rSpan[2]) << 11) | (((UInt32)rSpan[3]) << 19) | (((UInt32)rSpan[4]) << 27);
      rSpan = rSpan.Slice(5);
      return value;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    ///
    /// </summary>
    /// <param name="span"></param>
    /// <param name="rValue"></param>
    /// <returns>the number of bytes read</returns>
    public static int ReadSimple(ReadOnlySpan<byte> span, out UInt32 rValue)
    {
      UInt32 value = span[0];
      if ((value & 0x80) == 0)
      {
        rValue = value;
        return 1;
      }
      if ((value & 0x40) == 0)
      {
        rValue = (value & 0x3F) | (((UInt32)span[1]) << 6);
        return 2;
      }
      if ((value & 0x20) == 0)
      {
        rValue = (value & 0x1F) | (((UInt32)span[1]) << 5) | (((UInt32)span[2]) << 13);
        return 3;
      }
      if ((value & 0x10) == 0)
      {
        rValue = (value & 0x0F) | (((UInt32)span[1]) << 4) | (((UInt32)span[2]) << 12) | (((UInt32)span[3]) << 20);
        return 4;
      }

      rValue = (value & 0x07) | (((UInt32)span[1]) << 3) | (((UInt32)span[2]) << 11) | (((UInt32)span[3]) << 19) | (((UInt32)span[4]) << 27);
      return 5;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static int ReadSimple(byte[] array, int startIndex, out UInt32 rResult)
    {
      Debug.Assert(array != null);

      int rOffset = startIndex;
      rResult = array[rOffset];
      if ((rResult & 0x80) == 0)
      {
        ++rOffset;
      }
      else if ((rResult & 0x40) == 0)
      {
        rResult = (rResult & 0x3F) | (((UInt32)array[rOffset + 1]) << 6);
        rOffset += 2;
      }
      else if ((rResult & 0x20) == 0)
      {
        rResult = (rResult & 0x1F) | (((UInt32)array[rOffset + 1]) << 5) | (((UInt32)array[rOffset + 2]) << 13);
        rOffset += 3;
      }
      else if ((rResult & 0x10) == 0)
      {
        rResult =
          (rResult & 0x0F) | (((UInt32)array[rOffset + 1]) << 4) | (((UInt32)array[rOffset + 2]) << 12) | (((UInt32)array[rOffset + 3]) << 20);
        rOffset += 4;
      }
      else
      {
        rResult = (rResult & 0x07) | (((UInt32)array[rOffset + 1]) << 3) | (((UInt32)array[rOffset + 2]) << 11) |
                  (((UInt32)array[rOffset + 3]) << 19) | (((UInt32)array[rOffset + 4]) << 27);
        rOffset += 5;
      }
      return rOffset - startIndex;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static Int32 ReadSimpleInt32(byte[] array, int offset)
    {
      Debug.Assert(array != null);

      UInt32 value = ReadSimpleUInt32(array, offset);

      return (Int32)((value >> 1) ^ (-(value & 1)));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static Int32 ReadSimpleInt32(ReadOnlySpan<byte> span, out int rBytesRead)
    {
      UInt32 value = ReadSimpleUInt32(span, out rBytesRead);
      return (Int32)((value >> 1) ^ (-(value & 1)));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static Int32 ReadSimpleInt32(ref ReadOnlySpan<byte> rSpan)
    {
      UInt32 value = ReadSimpleUInt32(ref rSpan);
      return (Int32)((value >> 1) ^ (-(value & 1)));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static int ReadSimple(byte[] array, int startIndex, out Int32 rResult)
    {
      Debug.Assert(array != null);

      UInt32 value;
      int result = ReadSimple(array, startIndex, out value);
      rResult = (Int32)((value >> 1) ^ (-(value & 1)));
      return result;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static int ReadSimple(ReadOnlySpan<byte> span, out Int32 rResult)
    {
      UInt32 value;
      int result = ReadSimple(span, out value);
      rResult = (Int32)((value >> 1) ^ (-(value & 1)));
      return result;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Encodes a integer into a variable length encoding where the length can be determined from the first byte.
    /// The encoding favors small values.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    /// <returns>the number of bytes written</returns>
    public static int WriteSimple(byte[] array, int offset, Int32 value)
    {
      Debug.Assert(array != null);

      // ZigZag encode signed numbers
      return WriteSimple(array, offset, (UInt32)((value << 1) ^ (value >> 31)));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Encodes a integer into a variable length encoding where the length can be determined from the first byte.
    /// The encoding favors small values.
    /// </summary>
    /// <param name="span"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    /// <returns>the number of bytes written</returns>
    public static int WriteSimple(Span<byte> span, Int32 value)
    {
      // ZigZag encode signed numbers
      return WriteSimple(span, (UInt32)((value << 1) ^ (value >> 31)));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Encodes a integer into a variable length encoding where the length can be determined from the first byte.
    /// The encoding favors small values.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    /// <returns>the number of bytes written</returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static int WriteSimple(byte[] array, int offset, UInt32 value)
    {
      Debug.Assert(array != null);
      if (value <= 0x7F)
      {
        // <=7 bits value
        array[offset] = (byte)value;
        return 1;
      }
      if (value <= 0x3FFF)
      {
        // <=14 bits value
        array[offset + 0] = (byte)(0x80 | (value & 0x3F));
        array[offset + 1] = (byte)((value & 0x3FC0) >> 6);
        return 2;
      }
      if (value <= 0x1FFFFF)
      {
        // <=21 bits value
        array[offset + 0] = (byte)(0xC0 | (value & 0x1F));
        array[offset + 1] = (byte)((value & 0x001FE0) >> 5);
        array[offset + 2] = (byte)((value & 0x1FE000) >> 13);
        return 3;
      }
      if (value <= 0xFFFFFFF)
      {
        // <=28 bits value
        array[offset + 0] = (byte)(0xE0 | (value & 0x0F));
        array[offset + 1] = (byte)((value & 0x00000FF0) >> 4);
        array[offset + 2] = (byte)((value & 0x000FF000) >> 12);
        array[offset + 3] = (byte)((value & 0x0FF00000) >> 20);
        return 4;
      }

      // >28 bits value
      array[offset + 0] = (byte)(0xF0 | (value & 0x07));
      array[offset + 1] = (byte)((value & 0x000007F8) >> 3);
      array[offset + 2] = (byte)((value & 0x0007F800) >> 11);
      array[offset + 3] = (byte)((value & 0x07F80000) >> 19);
      array[offset + 4] = (byte)((value & 0xF8000000) >> 27);
      return 5;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Encodes a integer into a variable length encoding where the length can be determined from the first byte.
    /// The encoding favors small values.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    /// <returns>the number of bytes written</returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static int WriteSimple(Span<byte> array, UInt32 value)
    {
      Debug.Assert(array != null);
      if (value <= 0x7F)
      {
        // <=7 bits value
        array[0] = (byte)value;
        return 1;
      }
      if (value <= 0x3FFF)
      {
        // <=14 bits value
        array[0] = (byte)(0x80 | (value & 0x3F));
        array[1] = (byte)((value & 0x3FC0) >> 6);
        return 2;
      }
      if (value <= 0x1FFFFF)
      {
        // <=21 bits value
        array[0] = (byte)(0xC0 | (value & 0x1F));
        array[1] = (byte)((value & 0x001FE0) >> 5);
        array[2] = (byte)((value & 0x1FE000) >> 13);
        return 3;
      }
      if (value <= 0xFFFFFFF)
      {
        // <=28 bits value
        array[0] = (byte)(0xE0 | (value & 0x0F));
        array[1] = (byte)((value & 0x00000FF0) >> 4);
        array[2] = (byte)((value & 0x000FF000) >> 12);
        array[3] = (byte)((value & 0x0FF00000) >> 20);
        return 4;
      }

      // >28 bits value
      array[0] = (byte)(0xF0 | (value & 0x07));
      array[1] = (byte)((value & 0x000007F8) >> 3);
      array[2] = (byte)((value & 0x0007F800) >> 11);
      array[3] = (byte)((value & 0x07F80000) >> 19);
      array[4] = (byte)((value & 0xF8000000) >> 27);
      return 5;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------
    // 64 bit support
    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static UInt64 ReadSimpleUInt64(byte[] array, int offset)
    {
      Debug.Assert(array != null);
      UInt64 value = array[offset];
      if ((value & 0x80) == 0)
      {
        return value;
      }
      if ((value & 0x40) == 0)
      {
        return (value & 0x3F) | (((UInt64)array[offset + 1]) << 6);
      }
      if ((value & 0x20) == 0)
      {
        return (value & 0x1F) | (((UInt64)array[offset + 1]) << 5) | (((UInt64)array[offset + 2]) << 13);
      }
      if ((value & 0x10) == 0)
      {
        return (value & 0x0F) | (((UInt64)array[offset + 1]) << 4) | (((UInt64)array[offset + 2]) << 12) |
               (((UInt64)array[offset + 3]) << 20);
      }
      if ((value & 0x8) == 0)
      {
        return (value & 0x07) | (((UInt64)array[offset + 1]) << 3) | (((UInt64)array[offset + 2]) << 11) |
               (((UInt64)array[offset + 3]) << 19) | (((UInt64)array[offset + 4]) << 27);
      }
      if ((value & 0x4) == 0)
      {
        return (value & 0x03) | (((UInt64)array[offset + 1]) << 2) | (((UInt64)array[offset + 2]) << 10) |
               (((UInt64)array[offset + 3]) << 18) | (((UInt64)array[offset + 4]) << 26) |
               (((UInt64)array[offset + 5]) << 34);
      }
      if ((value & 0x2) == 0)
      {
        return (value & 0x01) | (((UInt64)array[offset + 1]) << 1) | (((UInt64)array[offset + 2]) << 9) |
               (((UInt64)array[offset + 3]) << 17) | (((UInt64)array[offset + 4]) << 25) |
               (((UInt64)array[offset + 5]) << 33) | (((UInt64)array[offset + 6]) << 41);
      }
      if ((value & 0x1) == 0)
      {
        return ((UInt64)array[offset + 1]) | (((UInt64)array[offset + 2]) << 8) | (((UInt64)array[offset + 3]) << 16) |
               (((UInt64)array[offset + 4]) << 24) | (((UInt64)array[offset + 5]) << 32) |
               (((UInt64)array[offset + 6]) << 40) | (((UInt64)array[offset + 7]) << 48);
      }

      return ((UInt64)array[offset + 1]) | (((UInt64)array[offset + 2]) << 8) | (((UInt64)array[offset + 3]) << 16) |
             (((UInt64)array[offset + 4]) << 24) | (((UInt64)array[offset + 5]) << 32) |
             (((UInt64)array[offset + 6]) << 40) | (((UInt64)array[offset + 7]) << 48) |
             (((UInt64)array[offset + 8]) << 56);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static UInt64 ReadSimpleUInt64(ReadOnlySpan<byte> span, out int rBytesRead)
    {
      Debug.Assert(span != null);
      UInt64 value = span[0];
      if ((value & 0x80) == 0)
      {
        rBytesRead = 1;
        return value;
      }
      if ((value & 0x40) == 0)
      {
        rBytesRead = 2;
        return (value & 0x3F) | (((UInt64)span[1]) << 6);
      }
      if ((value & 0x20) == 0)
      {
        rBytesRead = 3;
        return (value & 0x1F) | (((UInt64)span[1]) << 5) | (((UInt64)span[2]) << 13);
      }
      if ((value & 0x10) == 0)
      {
        rBytesRead = 4;
        return (value & 0x0F) | (((UInt64)span[1]) << 4) | (((UInt64)span[2]) << 12) |
               (((UInt64)span[3]) << 20);
      }
      if ((value & 0x8) == 0)
      {
        rBytesRead = 5;
        return (value & 0x07) | (((UInt64)span[1]) << 3) | (((UInt64)span[2]) << 11) |
               (((UInt64)span[3]) << 19) | (((UInt64)span[4]) << 27);
      }
      if ((value & 0x4) == 0)
      {
        rBytesRead = 6;
        return (value & 0x03) | (((UInt64)span[1]) << 2) | (((UInt64)span[2]) << 10) |
               (((UInt64)span[3]) << 18) | (((UInt64)span[4]) << 26) |
               (((UInt64)span[5]) << 34);
      }
      if ((value & 0x2) == 0)
      {
        rBytesRead = 7;
        return (value & 0x01) | (((UInt64)span[1]) << 1) | (((UInt64)span[2]) << 9) |
               (((UInt64)span[3]) << 17) | (((UInt64)span[4]) << 25) |
               (((UInt64)span[5]) << 33) | (((UInt64)span[6]) << 41);
      }
      if ((value & 0x1) == 0)
      {
        rBytesRead = 8;
        return ((UInt64)span[1]) | (((UInt64)span[2]) << 8) | (((UInt64)span[3]) << 16) |
               (((UInt64)span[4]) << 24) | (((UInt64)span[5]) << 32) |
               (((UInt64)span[6]) << 40) | (((UInt64)span[7]) << 48);
      }

      rBytesRead = 9;
      return ((UInt64)span[1]) | (((UInt64)span[2]) << 8) | (((UInt64)span[3]) << 16) |
             (((UInt64)span[4]) << 24) | (((UInt64)span[5]) << 32) |
             (((UInt64)span[6]) << 40) | (((UInt64)span[7]) << 48) |
             (((UInt64)span[8]) << 56);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static UInt64 ReadSimpleUInt64(ref ReadOnlySpan<byte> rSpan)
    {
      Debug.Assert(rSpan != null);
      UInt64 value = rSpan[0];
      if ((value & 0x80) == 0)
      {
        rSpan = rSpan.Slice(1);
        return value;
      }
      if ((value & 0x40) == 0)
      {
        value = (value & 0x3F) | (((UInt64)rSpan[1]) << 6);
        rSpan = rSpan.Slice(2);
        return value;
      }
      if ((value & 0x20) == 0)
      {
        value = (value & 0x1F) | (((UInt64)rSpan[1]) << 5) | (((UInt64)rSpan[2]) << 13);
        rSpan = rSpan.Slice(3);
        return value;
      }
      if ((value & 0x10) == 0)
      {
        value = (value & 0x0F) | (((UInt64)rSpan[1]) << 4) | (((UInt64)rSpan[2]) << 12) |
               (((UInt64)rSpan[3]) << 20);
        rSpan = rSpan.Slice(4);
        return value;
      }
      if ((value & 0x8) == 0)
      {
        value = (value & 0x07) | (((UInt64)rSpan[1]) << 3) | (((UInt64)rSpan[2]) << 11) |
               (((UInt64)rSpan[3]) << 19) | (((UInt64)rSpan[4]) << 27);
        rSpan = rSpan.Slice(5);
        return value;
      }
      if ((value & 0x4) == 0)
      {
        value = (value & 0x03) | (((UInt64)rSpan[1]) << 2) | (((UInt64)rSpan[2]) << 10) |
               (((UInt64)rSpan[3]) << 18) | (((UInt64)rSpan[4]) << 26) |
               (((UInt64)rSpan[5]) << 34);
        rSpan = rSpan.Slice(6);
        return value;
      }
      if ((value & 0x2) == 0)
      {
        value = (value & 0x01) | (((UInt64)rSpan[1]) << 1) | (((UInt64)rSpan[2]) << 9) |
               (((UInt64)rSpan[3]) << 17) | (((UInt64)rSpan[4]) << 25) |
               (((UInt64)rSpan[5]) << 33) | (((UInt64)rSpan[6]) << 41);
        rSpan = rSpan.Slice(7);
        return value;
      }
      if ((value & 0x1) == 0)
      {
        value = ((UInt64)rSpan[1]) | (((UInt64)rSpan[2]) << 8) | (((UInt64)rSpan[3]) << 16) |
               (((UInt64)rSpan[4]) << 24) | (((UInt64)rSpan[5]) << 32) |
               (((UInt64)rSpan[6]) << 40) | (((UInt64)rSpan[7]) << 48);
        rSpan = rSpan.Slice(8);
        return value;
      }

      value = ((UInt64)rSpan[1]) | (((UInt64)rSpan[2]) << 8) | (((UInt64)rSpan[3]) << 16) |
             (((UInt64)rSpan[4]) << 24) | (((UInt64)rSpan[5]) << 32) |
             (((UInt64)rSpan[6]) << 40) | (((UInt64)rSpan[7]) << 48) |
             (((UInt64)rSpan[8]) << 56);
      rSpan = rSpan.Slice(9);
      return value;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static int ReadSimple(byte[] array, int startIndex, out UInt64 rResult)
    {
      Debug.Assert(array != null);
      int currentIndex = startIndex;
      UInt64 result = array[currentIndex];
      if ((result & 0x80) == 0)    // 0AAA AAAA
      {
        ++currentIndex;
      }
      else if ((result & 0x40) == 0)    // 10AA AAAA - BBBB BBAA
      {
        result = (result & 0x3F) | (((UInt64)array[currentIndex + 1]) << 6);
        currentIndex += 2;
      }
      else if ((result & 0x20) == 0)    // 110A AAAA - BBBB BAAA - CCCC CBBB
      {
        result = (result & 0x1F) | (((UInt64)array[currentIndex + 1]) << 5) | (((UInt64)array[currentIndex + 2]) << 13);
        currentIndex += 3;
      }
      else if ((result & 0x10) == 0)    // 1110 AAAA - BBBB AAAA - CCCC BBBB - DDDD CCCC
      {
        result = (result & 0x0F) | (((UInt64)array[currentIndex + 1]) << 4) | (((UInt64)array[currentIndex + 2]) << 12) |
                 (((UInt64)array[currentIndex + 3]) << 20);
        currentIndex += 4;
      }
      else if ((result & 0x8) == 0)    // 1111 0AAA - BBBA AAAA - CCCB BBBB - DDDC CCCC - EEED DDDD
      {
        result = (result & 0x07) | (((UInt64)array[currentIndex + 1]) << 3) | (((UInt64)array[currentIndex + 2]) << 11) |
                 (((UInt64)array[currentIndex + 3]) << 19) | (((UInt64)array[currentIndex + 4]) << 27);
        currentIndex += 5;
      }
      else if ((result & 0x4) == 0)    // 1111 10AA - BBAA AAAA - CCVB BBBB - DDCC CCCC - EEDD DDDD - FFEE EEEE
      {
        result = (result & 0x03) | (((UInt64)array[currentIndex + 1]) << 2) | (((UInt64)array[currentIndex + 2]) << 10) |
                 (((UInt64)array[currentIndex + 3]) << 18) | (((UInt64)array[currentIndex + 4]) << 26) |
                 (((UInt64)array[currentIndex + 5]) << 34);

        currentIndex += 6;
      }
      else if ((result & 0x2) == 0)    // 1111 110A - BAAA AAAA - CCBB BBBB - DCCC CCCC - EDDD DDDD - FEEE EEEE - GFFF FFFF
      {
        result = (result & 0x01) | (((UInt64)array[currentIndex + 1]) << 1) | (((UInt64)array[currentIndex + 2]) << 9) |
                 (((UInt64)array[currentIndex + 3]) << 17) | (((UInt64)array[currentIndex + 4]) << 25) |
                 (((UInt64)array[currentIndex + 5]) << 33) | (((UInt64)array[currentIndex + 6]) << 41);

        currentIndex += 7;
      }
      else if ((result & 0x1) == 0)    // 1111 1110 - AAAA AAAA - BBBB BBBB - CCCC CCCC - DDDD DDDD - EEEE EEEE - FFFF FFFF - GGGG GGGG
      {
        result = (((UInt64)array[currentIndex + 1])) | (((UInt64)array[currentIndex + 2]) << (8 * 1)) |
                 (((UInt64)array[currentIndex + 3]) << (8 * 2)) | (((UInt64)array[currentIndex + 4]) << (8 * 3)) |
                 (((UInt64)array[currentIndex + 5]) << (8 * 4)) | (((UInt64)array[currentIndex + 6]) << (8 * 5)) |
                 (((UInt64)array[currentIndex + 7]) << (8 * 6));
        currentIndex += 8;
      }
      else    // 1111 1111 - AAAA AAAA - BBBB BBBB - CCCC CCCC - DDDD DDDD - EEEE EEEE - FFFF FFFF - GGGG GGGG - HHHH HHHH
      {
        Debug.Assert(result == 0xFF);
        result = (((UInt64)array[currentIndex + 1])) | (((UInt64)array[currentIndex + 2]) << (8 * 1)) |
                 (((UInt64)array[currentIndex + 3]) << (8 * 2)) | (((UInt64)array[currentIndex + 4]) << (8 * 3)) |
                 (((UInt64)array[currentIndex + 5]) << (8 * 4)) | (((UInt64)array[currentIndex + 6]) << (8 * 5)) |
                 (((UInt64)array[currentIndex + 7]) << (8 * 6)) | (((UInt64)array[currentIndex + 8]) << (8 * 7));
        currentIndex += 9;
      }
      rResult = result;
      return currentIndex - startIndex;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static int ReadSimple(ReadOnlySpan<byte> span, out UInt64 rResult)
    {
      UInt64 result = span[0];
      if ((result & 0x80) == 0)    // 0AAA AAAA
      {
        rResult = result;
        return 1;
      }
      else if ((result & 0x40) == 0)    // 10AA AAAA - BBBB BBAA
      {
        rResult = (result & 0x3F) | (((UInt64)span[1]) << 6);
        return 2;
      }
      else if ((result & 0x20) == 0)    // 110A AAAA - BBBB BAAA - CCCC CBBB
      {
        rResult = (result & 0x1F) | (((UInt64)span[1]) << 5) | (((UInt64)span[2]) << 13);
        return 3;
      }
      else if ((result & 0x10) == 0)    // 1110 AAAA - BBBB AAAA - CCCC BBBB - DDDD CCCC
      {
        rResult = (result & 0x0F) | (((UInt64)span[1]) << 4) | (((UInt64)span[2]) << 12) |
                  (((UInt64)span[3]) << 20);
        return 4;
      }
      else if ((result & 0x8) == 0)    // 1111 0AAA - BBBA AAAA - CCCB BBBB - DDDC CCCC - EEED DDDD
      {
        rResult = (result & 0x07) | (((UInt64)span[1]) << 3) | (((UInt64)span[2]) << 11) |
                  (((UInt64)span[3]) << 19) | (((UInt64)span[4]) << 27);
        return 5;
      }
      else if ((result & 0x4) == 0)    // 1111 10AA - BBAA AAAA - CCVB BBBB - DDCC CCCC - EEDD DDDD - FFEE EEEE
      {
        rResult = (result & 0x03) | (((UInt64)span[1]) << 2) | (((UInt64)span[2]) << 10) |
                  (((UInt64)span[3]) << 18) | (((UInt64)span[4]) << 26) |
                  (((UInt64)span[5]) << 34);

        return 6;
      }
      else if ((result & 0x2) == 0)    // 1111 110A - BAAA AAAA - CCBB BBBB - DCCC CCCC - EDDD DDDD - FEEE EEEE - GFFF FFFF
      {
        rResult = (result & 0x01) | (((UInt64)span[1]) << 1) | (((UInt64)span[2]) << 9) |
                  (((UInt64)span[3]) << 17) | (((UInt64)span[4]) << 25) |
                  (((UInt64)span[5]) << 33) | (((UInt64)span[6]) << 41);

        return 7;
      }
      else if ((result & 0x1) == 0)    // 1111 1110 - AAAA AAAA - BBBB BBBB - CCCC CCCC - DDDD DDDD - EEEE EEEE - FFFF FFFF - GGGG GGGG
      {
        rResult = (((UInt64)span[1])) | (((UInt64)span[2]) << (8 * 1)) |
                  (((UInt64)span[3]) << (8 * 2)) | (((UInt64)span[4]) << (8 * 3)) |
                  (((UInt64)span[5]) << (8 * 4)) | (((UInt64)span[6]) << (8 * 5)) |
                  (((UInt64)span[7]) << (8 * 6));
        return 8;
      }

      // 1111 1111 - AAAA AAAA - BBBB BBBB - CCCC CCCC - DDDD DDDD - EEEE EEEE - FFFF FFFF - GGGG GGGG - HHHH HHHH
      Debug.Assert(result == 0xFF);
      rResult = (((UInt64)span[1])) | (((UInt64)span[2]) << (8 * 1)) |
                (((UInt64)span[3]) << (8 * 2)) | (((UInt64)span[4]) << (8 * 3)) |
                (((UInt64)span[5]) << (8 * 4)) | (((UInt64)span[6]) << (8 * 5)) |
                (((UInt64)span[7]) << (8 * 6)) | (((UInt64)span[8]) << (8 * 7));
      return 9;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static Int64 ReadSimpleInt64(byte[] array, int offset)
    {
      Debug.Assert(array != null);

      UInt64 value = ReadSimpleUInt64(array, offset);

      return (Int64)((value >> 1) ^ ((~(UInt64)0) + ((~value) & 1)));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static Int64 ReadSimpleInt64(ReadOnlySpan<byte> span, out int rBytesRead)
    {
      Debug.Assert(span != null);

      UInt64 value = ReadSimpleUInt64(span, out rBytesRead);

      return (Int64)((value >> 1) ^ ((~(UInt64)0) + ((~value) & 1)));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static Int64 ReadSimpleInt64(ref ReadOnlySpan<byte> rSpan)
    {
      Debug.Assert(rSpan != null);

      UInt64 value = ReadSimpleUInt64(ref rSpan);

      return (Int64)((value >> 1) ^ ((~(UInt64)0) + ((~value) & 1)));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static int ReadSimple(byte[] array, int startIndex, out Int64 rResult)
    {
      Debug.Assert(array != null);

      UInt64 value;
      int result = ReadSimple(array, startIndex, out value);
      rResult = (Int64)((value >> 1) ^ ((~(UInt64)0) + ((~value) & 1)));
      return result;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static int ReadSimple(ReadOnlySpan<byte> span, out Int64 rResult)
    {
      UInt64 value;
      int result = ReadSimple(span, out value);
      rResult = (Int64)((value >> 1) ^ ((~(UInt64)0) + ((~value) & 1)));
      return result;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Encodes a integer into a variable length encoding where the length can be determined from the first byte.
    /// The encoding favors small values.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    /// <returns>the number of bytes written</returns>
    public static int WriteSimple(byte[] array, int offset, Int64 value)
    {
      Debug.Assert(array != null);

      // ZigZag encode signed numbers
      return WriteSimple(array, offset, (UInt64)((value << 1) ^ (value >> 63)));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Encodes a integer into a variable length encoding where the length can be determined from the first byte.
    /// The encoding favors small values.
    /// </summary>
    /// <param name="span"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    /// <returns>the number of bytes written</returns>
    public static int WriteSimple(Span<byte> span, Int64 value)
    {
      // ZigZag encode signed numbers
      return WriteSimple(span, (UInt64)((value << 1) ^ (value >> 63)));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Encodes a integer into a variable length encoding where the length can be determined from the first byte.
    /// The encoding favors small values.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    /// <returns>the number of bytes written</returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static int WriteSimple(byte[] array, int offset, UInt64 value)
    {
      Debug.Assert(array != null);
      if (value <= 0x7F)
      {
        // <=7 bits value
        array[offset] = (byte)value;
        return 1;
      }
      if (value <= 0x3FFF)
      {
        // <=14 bits value
        array[offset + 0] = (byte)(0x80 | (value & 0x3F));
        array[offset + 1] = (byte)((value & 0x3FC0) >> 6);
        return 2;
      }
      if (value <= 0x1FFFFF)
      {
        // <=21 bits value
        array[offset + 0] = (byte)(0xC0 | (value & 0x1F));
        array[offset + 1] = (byte)((value & 0x001FE0) >> 5);
        array[offset + 2] = (byte)((value & 0x1FE000) >> 13);
        return 3;
      }
      if (value <= 0xFFFFFFF)
      {
        // <=28 bits value
        array[offset + 0] = (byte)(0xE0 | (value & 0x0F));
        array[offset + 1] = (byte)((value & 0x00000FF0) >> 4);
        array[offset + 2] = (byte)((value & 0x000FF000) >> 12);
        array[offset + 3] = (byte)((value & 0x0FF00000) >> 20);
        return 4;
      }
      if (value <= 0x7FFFFFFFF)
      {
        // <=35 bits value
        array[offset + 0] = (byte)(0xF0 | (value & 0x07));
        array[offset + 1] = (byte)((value & (((UInt64)0xFF) << 3)) >> 3);
        array[offset + 2] = (byte)((value & (((UInt64)0xFF) << 11)) >> 11);
        array[offset + 3] = (byte)((value & (((UInt64)0xFF) << 19)) >> 19);
        array[offset + 4] = (byte)((value & (((UInt64)0xFF) << 27)) >> 27);
        return 5;
      }
      if (value <= 0x3FFFFFFFFFF)    // 1111 10AA - BBAA AAAA - CCVB BBBB - DDCC CCCC - EEDD DDDD - FFEE EEEE
      {
        // <=42 bits value
        array[offset + 0] = (byte)(0xF8 | (value & 0x03));
        array[offset + 1] = (byte)((value & (((UInt64)0xFF) << 2)) >> 2);
        array[offset + 2] = (byte)((value & (((UInt64)0xFF) << 10)) >> 10);
        array[offset + 3] = (byte)((value & (((UInt64)0xFF) << 18)) >> 18);
        array[offset + 4] = (byte)((value & (((UInt64)0xFF) << 26)) >> 26);
        array[offset + 5] = (byte)((value & (((UInt64)0xFF) << 34)) >> 34);
        return 6;
      }
      if (value <= 0x1FFFFFFFFFFFF)    // 1111 110A - BAAA AAAA - CCBB BBBB - DCCC CCCC - EDDD DDDD - FEEE EEEE - GFFF FFFF
      {
        // <=49 bits value
        array[offset + 0] = (byte)(0xFC | (value & 0x01));
        array[offset + 1] = (byte)((value & (((UInt64)0xFF) << 1)) >> 1);
        array[offset + 2] = (byte)((value & (((UInt64)0xFF) << 9)) >> 9);
        array[offset + 3] = (byte)((value & (((UInt64)0xFF) << 17)) >> 17);
        array[offset + 4] = (byte)((value & (((UInt64)0xFF) << 25)) >> 25);
        array[offset + 5] = (byte)((value & (((UInt64)0xFF) << 33)) >> 33);
        array[offset + 6] = (byte)((value & (((UInt64)0xFF) << 41)) >> 41);
        return 7;
      }
      if (value <= 0xFFFFFFFFFFFFFF)    // 1111 1110 - AAAA AAAA - BBBB BBBB - CCCC CCCC - DDDD DDDD - EEEE EEEE - FFFF FFFF - GGGG GGGG
      {
        // <=56 bits value
        array[offset + 0] = (byte)(0xFE);
        array[offset + 1] = (byte)((value & 0x00000000000000FF));
        array[offset + 2] = (byte)((value & 0x000000000000FF00) >> (8 * 1));
        array[offset + 3] = (byte)((value & 0x0000000000FF0000) >> (8 * 2));
        array[offset + 4] = (byte)((value & 0x00000000FF000000) >> (8 * 3));
        array[offset + 5] = (byte)((value & 0x000000FF00000000) >> (8 * 4));
        array[offset + 6] = (byte)((value & 0x0000FF0000000000) >> (8 * 5));
        array[offset + 7] = (byte)((value & 0x00FF000000000000) >> (8 * 6));
        return 8;
      }

      // 1111 1111 - AAAA AAAA - BBBB BBBB - CCCC CCCC - DDDD DDDD - EEEE EEEE - FFFF FFFF - GGGG GGGG - HHHH HHHH

      // >56 bits value (aka 64bit)
      array[offset + 0] = (byte)(0xFF);
      array[offset + 1] = (byte)((value & 0x00000000000000FF));
      array[offset + 2] = (byte)((value & 0x000000000000FF00) >> (8 * 1));
      array[offset + 3] = (byte)((value & 0x0000000000FF0000) >> (8 * 2));
      array[offset + 4] = (byte)((value & 0x00000000FF000000) >> (8 * 3));
      array[offset + 5] = (byte)((value & 0x000000FF00000000) >> (8 * 4));
      array[offset + 6] = (byte)((value & 0x0000FF0000000000) >> (8 * 5));
      array[offset + 7] = (byte)((value & 0x00FF000000000000) >> (8 * 6));
      array[offset + 8] = (byte)((value & 0xFF00000000000000) >> (8 * 7));
      return 9;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Encodes a integer into a variable length encoding where the length can be determined from the first byte.
    /// The encoding favors small values.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    /// <returns>the number of bytes written</returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static int WriteSimple(Span<byte> array, UInt64 value)
    {
      Debug.Assert(array != null);
      if (value <= 0x7F)
      {
        // <=7 bits value
        array[0] = (byte)value;
        return 1;
      }
      if (value <= 0x3FFF)
      {
        // <=14 bits value
        array[0] = (byte)(0x80 | (value & 0x3F));
        array[1] = (byte)((value & 0x3FC0) >> 6);
        return 2;
      }
      if (value <= 0x1FFFFF)
      {
        // <=21 bits value
        array[0] = (byte)(0xC0 | (value & 0x1F));
        array[1] = (byte)((value & 0x001FE0) >> 5);
        array[2] = (byte)((value & 0x1FE000) >> 13);
        return 3;
      }
      if (value <= 0xFFFFFFF)
      {
        // <=28 bits value
        array[0] = (byte)(0xE0 | (value & 0x0F));
        array[1] = (byte)((value & 0x00000FF0) >> 4);
        array[2] = (byte)((value & 0x000FF000) >> 12);
        array[3] = (byte)((value & 0x0FF00000) >> 20);
        return 4;
      }
      if (value <= 0x7FFFFFFFF)
      {
        // <=35 bits value
        array[0] = (byte)(0xF0 | (value & 0x07));
        array[1] = (byte)((value & (((UInt64)0xFF) << 3)) >> 3);
        array[2] = (byte)((value & (((UInt64)0xFF) << 11)) >> 11);
        array[3] = (byte)((value & (((UInt64)0xFF) << 19)) >> 19);
        array[4] = (byte)((value & (((UInt64)0xFF) << 27)) >> 27);
        return 5;
      }
      if (value <= 0x3FFFFFFFFFF)    // 1111 10AA - BBAA AAAA - CCVB BBBB - DDCC CCCC - EEDD DDDD - FFEE EEEE
      {
        // <=42 bits value
        array[0] = (byte)(0xF8 | (value & 0x03));
        array[1] = (byte)((value & (((UInt64)0xFF) << 2)) >> 2);
        array[2] = (byte)((value & (((UInt64)0xFF) << 10)) >> 10);
        array[3] = (byte)((value & (((UInt64)0xFF) << 18)) >> 18);
        array[4] = (byte)((value & (((UInt64)0xFF) << 26)) >> 26);
        array[5] = (byte)((value & (((UInt64)0xFF) << 34)) >> 34);
        return 6;
      }
      if (value <= 0x1FFFFFFFFFFFF)    // 1111 110A - BAAA AAAA - CCBB BBBB - DCCC CCCC - EDDD DDDD - FEEE EEEE - GFFF FFFF
      {
        // <=49 bits value
        array[0] = (byte)(0xFC | (value & 0x01));
        array[1] = (byte)((value & (((UInt64)0xFF) << 1)) >> 1);
        array[2] = (byte)((value & (((UInt64)0xFF) << 9)) >> 9);
        array[3] = (byte)((value & (((UInt64)0xFF) << 17)) >> 17);
        array[4] = (byte)((value & (((UInt64)0xFF) << 25)) >> 25);
        array[5] = (byte)((value & (((UInt64)0xFF) << 33)) >> 33);
        array[6] = (byte)((value & (((UInt64)0xFF) << 41)) >> 41);
        return 7;
      }
      if (value <= 0xFFFFFFFFFFFFFF)    // 1111 1110 - AAAA AAAA - BBBB BBBB - CCCC CCCC - DDDD DDDD - EEEE EEEE - FFFF FFFF - GGGG GGGG
      {
        // <=56 bits value
        array[0] = (byte)(0xFE);
        array[1] = (byte)((value & 0x00000000000000FF));
        array[2] = (byte)((value & 0x000000000000FF00) >> (8 * 1));
        array[3] = (byte)((value & 0x0000000000FF0000) >> (8 * 2));
        array[4] = (byte)((value & 0x00000000FF000000) >> (8 * 3));
        array[5] = (byte)((value & 0x000000FF00000000) >> (8 * 4));
        array[6] = (byte)((value & 0x0000FF0000000000) >> (8 * 5));
        array[7] = (byte)((value & 0x00FF000000000000) >> (8 * 6));
        return 8;
      }

      // 1111 1111 - AAAA AAAA - BBBB BBBB - CCCC CCCC - DDDD DDDD - EEEE EEEE - FFFF FFFF - GGGG GGGG - HHHH HHHH

      // >56 bits value (aka 64bit)
      array[0] = (byte)(0xFF);
      array[1] = (byte)((value & 0x00000000000000FF));
      array[2] = (byte)((value & 0x000000000000FF00) >> (8 * 1));
      array[3] = (byte)((value & 0x0000000000FF0000) >> (8 * 2));
      array[4] = (byte)((value & 0x00000000FF000000) >> (8 * 3));
      array[5] = (byte)((value & 0x000000FF00000000) >> (8 * 4));
      array[6] = (byte)((value & 0x0000FF0000000000) >> (8 * 5));
      array[7] = (byte)((value & 0x00FF000000000000) >> (8 * 6));
      array[8] = (byte)((value & 0xFF00000000000000) >> (8 * 7));
      return 9;
    }
  }
}

//****************************************************************************************************************************************************

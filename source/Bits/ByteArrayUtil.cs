#nullable enable
//****************************************************************************************************************************************************
//* BSD 3-Clause License
//*
//* Copyright (c) 2012-2024, Mana Battery
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

namespace MB.Base.Bits
{
  /// <summary>
  /// Various helper methods to read bytes as little or big endian values in a safe way.
  /// Here we trade performance for correctness.
  /// </summary>
  public static class ByteArrayUtil
  {
    /// <summary>
    /// Read little endian int8 (just for completeness).
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="rValue"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static int ReadLE(byte[] array, int offset, out bool rValue)
    {
      Debug.Assert(array != null);
      rValue = (array[offset] != (byte)0 ? true : false);
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
    public static int ReadLE(byte[] array, int offset, out sbyte rValue)
    {
      Debug.Assert(array != null);
      rValue = (sbyte)array[offset];
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
    public static int ReadLE(byte[] array, int offset, out byte rValue)
    {
      Debug.Assert(array != null);
      rValue = array[offset];
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
    public static int ReadLE(byte[] array, int offset, out Int16 rValue)
    {
      Debug.Assert(array != null);
      rValue = (Int16)(((UInt32)array[offset]) | (((UInt32)array[offset + 1]) << 8));
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
    public static int ReadLE(byte[] array, int offset, out UInt16 rValue)
    {
      Debug.Assert(array != null);
      rValue = (UInt16)(((UInt32)array[offset]) | (((UInt32)array[offset + 1]) << 8));
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
    public static int ReadLE(byte[] array, int offset, out Int32 rValue)
    {
      Debug.Assert(array != null);
      rValue = (Int32)(((UInt32)array[offset]) | (((UInt32)array[offset + 1]) << 8) | (((UInt32)array[offset + 2]) << 16) |
                       (((UInt32)array[offset + 3]) << 24));
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
    public static int ReadLE(byte[] array, int offset, out UInt32 rValue)
    {
      Debug.Assert(array != null);
      rValue = (((UInt32)array[offset]) | (((UInt32)array[offset + 1]) << 8) | (((UInt32)array[offset + 2]) << 16) |
                (((UInt32)array[offset + 3]) << 24));
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
    public static int ReadLE(byte[] array, int offset, out Int64 rValue)
    {
      Debug.Assert(array != null);
      rValue = (Int64)(((UInt64)array[offset]) | (((UInt64)array[offset + 1]) << 8) | (((UInt64)array[offset + 2]) << 16) |
                       (((UInt64)array[offset + 3]) << 24) | (((UInt64)array[offset + 4]) << 32) | (((UInt64)array[offset + 5]) << 40) |
                       (((UInt64)array[offset + 6]) << 48) | (((UInt64)array[offset + 7]) << 56));
      return 8;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Read a uint32 from the byte array in little endian format.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="rValue"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static int ReadLE(byte[] array, int offset, out UInt64 rValue)
    {
      Debug.Assert(array != null);
      rValue = (((UInt64)array[offset]) | (((UInt64)array[offset + 1]) << 8) | (((UInt64)array[offset + 2]) << 16) |
                (((UInt64)array[offset + 3]) << 24) | (((UInt64)array[offset + 4]) << 32) | (((UInt64)array[offset + 5]) << 40) |
                (((UInt64)array[offset + 6]) << 48) | (((UInt64)array[offset + 7]) << 56));
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
    public static int ReadLEArrayCanBeModified(byte[] array, int offset, out float rValue)
    {
      Debug.Assert(array != null);
      Debug.Assert(array.Length >= 4);
      if (!BitConverter.IsLittleEndian)
        ByteArrayUtil.ReverseBytes(array, 4, offset);
      rValue = BitConverter.ToSingle(array, offset);
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
    public static int ReadLEArrayCanBeModified(byte[] array, int offset, out double rValue)
    {
      Debug.Assert(array != null);
      Debug.Assert(array.Length >= 8);
      if (!BitConverter.IsLittleEndian)
        ByteArrayUtil.ReverseBytes(array, 8, offset);
      rValue = BitConverter.ToDouble(array, offset);
      return 8;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Read a little endian Int16
    /// </summary>
    /// <param name="array"></param>
    /// <param name="size"></param>
    /// <param name="offset"></param>
    /// <returns>the Int16 value</returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static Int16 ReadInt16LE(byte[] array, int size, int offset)
    {
      Debug.Assert(array != null);
      Debug.Assert(size >= 2);
      Debug.Assert(offset <= (size - 2));
      return (Int16)(((UInt32)array[offset]) | (((UInt32)array[offset + 1]) << 8));
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
    public static UInt16 ReadUInt16LE(byte[] array, int size, int offset)
    {
      Debug.Assert(array != null);
      Debug.Assert(size >= 2);
      Debug.Assert(offset <= (size - 2));
      return (UInt16)(((UInt32)array[offset]) | (((UInt32)array[offset + 1]) << 8));
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
    public static UInt16 ReadUInt16LE(byte[] array, uint size, int offset)
    {
      Debug.Assert(array != null);
      Debug.Assert(size >= 2);
      Debug.Assert(offset <= (size - 2));
      return (UInt16)(((UInt32)array[offset]) | (((UInt32)array[offset + 1]) << 8));
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
    public static Int32 ReadInt32LE(byte[] array, int size, int offset)
    {
      Debug.Assert(array != null);
      Debug.Assert(size >= 4);
      Debug.Assert(offset <= (size - 4));
      return (Int32)(((UInt32)array[offset]) | (((UInt32)array[offset + 1]) << 8) | (((UInt32)array[offset + 2]) << 16) |
                     (((UInt32)array[offset + 3]) << 24));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static Int32 ReadInt32LE(byte[] array, uint size, int offset)
    {
      Debug.Assert(array != null);
      Debug.Assert(size >= 4);
      Debug.Assert(offset <= (size - 4));
      return (Int32)(((UInt32)array[offset]) | (((UInt32)array[offset + 1]) << 8) | (((UInt32)array[offset + 2]) << 16) |
                     (((UInt32)array[offset + 3]) << 24));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static UInt32 ReadUInt32LE(byte[] array, int size, int offset)
    {
      Debug.Assert(array != null);
      Debug.Assert(size >= 4);
      Debug.Assert(offset <= (size - 4));
      return (((UInt32)array[offset]) | (((UInt32)array[offset + 1]) << 8) | (((UInt32)array[offset + 2]) << 16) |
              (((UInt32)array[offset + 3]) << 24));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static UInt32 ReadUInt32LE(byte[] array, uint size, int offset)
    {
      Debug.Assert(array != null);
      Debug.Assert(size >= 4);
      Debug.Assert(offset <= (size - 4));
      return (((UInt32)array[offset]) | (((UInt32)array[offset + 1]) << 8) | (((UInt32)array[offset + 2]) << 16) |
              (((UInt32)array[offset + 3]) << 24));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static void WriteUInt16LE(byte[] dst, uint dstSize, int dstOffset, UInt16 value)
    {
      Debug.Assert(dst != null);
      Debug.Assert(dstSize >= 2);
      Debug.Assert(dstOffset <= (dstSize - 2));

      dst[dstOffset + 0] = (byte)(value & 0xFF);
      dst[dstOffset + 1] = (byte)((value >> 8) & 0xFF);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static void WriteInt32LE(byte[] dst, uint dstSize, int dstOffset, Int32 value)
    {
      WriteUInt32LE(dst, dstSize, dstOffset, (UInt32)value);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static void WriteUInt32LE(byte[] dst, uint dstSize, int dstOffset, UInt32 value)
    {
      Debug.Assert(dst != null);
      Debug.Assert(dstSize >= 4);
      Debug.Assert(dstOffset <= (dstSize - 4));

      dst[dstOffset + 0] = (byte)(value & 0xFF);
      dst[dstOffset + 1] = (byte)((value >> 8) & 0xFF);
      dst[dstOffset + 2] = (byte)((value >> 16) & 0xFF);
      dst[dstOffset + 3] = (byte)((value >> 24) & 0xFF);
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
    //public static void ReadLE(byte[] array, ref int rOffset, out Int32 rValue)
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
    //public static void ReadLE(byte[] array, ref int rOffset, out UInt32 rValue)
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
    public static int WriteLE(byte[] array, int offset, bool value)
    {
      array[offset] = (byte)(value ? 1 : 0);
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
    public static int WriteLE(byte[] array, int offset, sbyte value)
    {
      Debug.Assert(array != null);
      array[offset] = (byte)value;
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
    public static int WriteLE(byte[] array, int offset, byte value)
    {
      Debug.Assert(array != null);
      array[offset] = value;
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
    public static int WriteLE(byte[] array, int offset, Int16 value)
    {
      Debug.Assert(array != null);
      UInt16 valueEx = (UInt16)value;
      array[offset] = (byte)(valueEx & 0xFF);
      array[offset + 1] = (byte)((valueEx >> 8) & 0xFF);
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
    public static int WriteLE(byte[] array, int offset, UInt16 value)
    {
      Debug.Assert(array != null);
      array[offset] = (byte)(value & 0xFF);
      array[offset + 1] = (byte)((value >> 8) & 0xFF);
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
    public static int WriteLE(byte[] array, int offset, Int32 value)
    {
      Debug.Assert(array != null);
      UInt32 valueEx = (UInt32)value;
      array[offset] = (byte)(valueEx & 0xFF);
      array[offset + 1] = (byte)((valueEx >> 8) & 0xFF);
      array[offset + 2] = (byte)((valueEx >> 16) & 0xFF);
      array[offset + 3] = (byte)((valueEx >> 24) & 0xFF);
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
    public static int WriteLE(byte[] array, int offset, UInt32 value)
    {
      Debug.Assert(array != null);
      array[offset] = (byte)(value & 0xFF);
      array[offset + 1] = (byte)((value >> 8) & 0xFF);
      array[offset + 2] = (byte)((value >> 16) & 0xFF);
      array[offset + 3] = (byte)((value >> 24) & 0xFF);
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
    public static int WriteLE(byte[] array, int offset, Int64 value)
    {
      Debug.Assert(array != null);
      UInt64 valueEx = (UInt64)value;
      array[offset] = (byte)(valueEx & 0xFF);
      array[offset + 1] = (byte)((valueEx >> 8) & 0xFF);
      array[offset + 2] = (byte)((valueEx >> 16) & 0xFF);
      array[offset + 3] = (byte)((valueEx >> 24) & 0xFF);
      array[offset + 4] = (byte)((valueEx >> 32) & 0xFF);
      array[offset + 5] = (byte)((valueEx >> 40) & 0xFF);
      array[offset + 6] = (byte)((valueEx >> 48) & 0xFF);
      array[offset + 7] = (byte)((valueEx >> 56) & 0xFF);
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
    public static int WriteLE(byte[] array, int offset, UInt64 value)
    {
      Debug.Assert(array != null);
      array[offset] = (byte)(value & 0xFF);
      array[offset + 1] = (byte)((value >> 8) & 0xFF);
      array[offset + 2] = (byte)((value >> 16) & 0xFF);
      array[offset + 3] = (byte)((value >> 24) & 0xFF);
      array[offset + 4] = (byte)((value >> 32) & 0xFF);
      array[offset + 5] = (byte)((value >> 40) & 0xFF);
      array[offset + 6] = (byte)((value >> 48) & 0xFF);
      array[offset + 7] = (byte)((value >> 56) & 0xFF);
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
    public static int WriteLE(byte[] array, int offset, float value)
    {
      Debug.Assert((array.Length - offset) >= 4);
      var dstSpan = array.AsSpan(offset, 4);
      if (!BitConverter.TryWriteBytes(dstSpan, value))
        throw new Exception("Failed to convert float to bytes");
      if (!BitConverter.IsLittleEndian)
        ByteArrayUtil.ReverseBytes(dstSpan);
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
    public static int WriteLE(byte[] array, int offset, double value)
    {
      Debug.Assert((array.Length - offset) >= 8);
      var dstSpan = array.AsSpan(offset, 8);
      if (!BitConverter.TryWriteBytes(dstSpan, value))
        throw new Exception("Failed to convert float to bytes");
      if (!BitConverter.IsLittleEndian)
        ByteArrayUtil.ReverseBytes(dstSpan);
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
    //public static void WriteLE(byte[] array, ref int rOffset, Int32 value)
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
    //public static void WriteLE(byte[] array, ref int rOffset, UInt32 value)
    //{
    //  rOffset += WriteLE(array, rOffset, value);
    //}

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static void ReverseBytes(Span<byte> inArray)
    {
      Debug.Assert(inArray != null);

      byte temp;
      int highCtr = inArray.Length - 1;

      for (int ctr = 0; ctr < inArray.Length / 2; ctr++)
      {
        temp = inArray[ctr];
        inArray[ctr] = inArray[highCtr];
        inArray[highCtr] = temp;
        highCtr -= 1;
      }
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static void ReverseBytes(byte[] inArray)
    {
      Debug.Assert(inArray != null);

      byte temp;
      int highCtr = inArray.Length - 1;

      for (int ctr = 0; ctr < inArray.Length / 2; ctr++)
      {
        temp = inArray[ctr];
        inArray[ctr] = inArray[highCtr];
        inArray[highCtr] = temp;
        highCtr -= 1;
      }
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static void ReverseBytes(byte[] inArray, int length)
    {
      Debug.Assert(inArray != null);
      Debug.Assert(length >= 0);
      Debug.Assert(length <= inArray.Length);

      byte temp;
      int highIdx = length - 1;
      int endIdx = length / 2;
      for (int idx = 0; idx < endIdx; ++idx)
      {
        temp = inArray[idx];
        inArray[idx] = inArray[highIdx];
        inArray[highIdx] = temp;
        highIdx -= 1;
      }
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static void ReverseBytes(byte[] inArray, int length, int offset)
    {
      Debug.Assert(inArray != null);
      Debug.Assert(length >= 0);
      Debug.Assert(length <= inArray.Length);

      byte temp;
      int highIdx = offset + length - 1;
      int endIdx = offset + (length / 2);
      for (int idx = offset; idx < endIdx; ++idx)
      {
        temp = inArray[idx];
        inArray[idx] = inArray[highIdx];
        inArray[highIdx] = temp;
        highIdx -= 1;
      }
    }
  }
}

//****************************************************************************************************************************************************

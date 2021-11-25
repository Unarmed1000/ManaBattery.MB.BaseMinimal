//****************************************************************************************************************************************************
//* BSD 3-Clause License
//*
//* Copyright (c) 2015, Mana Battery
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
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static UInt32 ReadSimpleUInt32(byte[] array, int offset)
    {
      Debug.Assert(array != null);

      UInt32 value = array[offset];
      if ((value & 0x80) == 0)
        return value;
      else if ((value & 0x40) == 0)
        return (value & 0x3F) | (((UInt32)array[offset + 1]) << 6);
      else if ((value & 0x20) == 0)
        return (value & 0x1F) | (((UInt32)array[offset + 1]) << 5) | (((UInt32)array[offset + 2]) << 13);
      else if ((value & 0x10) == 0)
        return (value & 0x0F) | (((UInt32)array[offset + 1]) << 4) | (((UInt32)array[offset + 2]) << 12) | (((UInt32)array[offset + 3]) << 20);
      else
        return (value & 0x07) | (((UInt32)array[offset + 1]) << 3) | (((UInt32)array[offset + 2]) << 11) | (((UInt32)array[offset + 3]) << 19) |
               (((UInt32)array[offset + 4]) << 27);
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
    public static int ReadSimple(byte[] array, int startIndex, out UInt32 rResult)
    {
      Debug.Assert(array != null);

      int rOffset = startIndex;
      rResult = array[rOffset];
      if ((rResult & 0x80) == 0)
        ++rOffset;
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


    public static Int32 ReadSimpleInt32(byte[] array, int offset)
    {
      Debug.Assert(array != null);

      UInt32 value = ReadSimpleUInt32(array, offset);

      return (Int32)((value >> 1) ^ (-(value & 1)));
    }

    public static int ReadSimple(byte[] array, int startIndex, out Int32 rResult)
    {
      Debug.Assert(array != null);

      UInt32 value;
      int result = ReadSimple(array, startIndex, out value);
      rResult = (Int32)((value >> 1) ^ (-(value & 1)));
      return result;
    }

    /// <summary>
    /// Encodes a integer into a variable length encoding where the length can be determined from the first byte.
    /// The encoding favors small values.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="offset"></param>
    /// <param name="value"></param>
    /// <returns>the number of bytes written</returns>
    public static int WriteSimple(byte[] array, int offset, int value)
    {
      Debug.Assert(array != null);

      // ZigZag encode signed numbers
      return WriteSimple(array, offset, (UInt32)((value << 1) ^ (value >> 31)));
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
    public static int WriteSimple(byte[] array, int offset, UInt32 value)
    {
      Debug.Assert(array != null);
      if (value <= 0x7F)
      {
        // <=7 bits value
        array[offset] = (byte)value;
        return 1;
      }
      else if (value <= 0x3FFF)
      {
        // <=14 bits value
        array[offset + 0] = (byte)(0x80 | (value & 0x3F));
        array[offset + 1] = (byte)((value & 0x3FC0) >> 6);
        return 2;
      }
      else if (value <= 0x1FFFFF)
      {
        // <=21 bits value
        array[offset + 0] = (byte)(0xC0 | (value & 0x1F));
        array[offset + 1] = (byte)((value & 0x001FE0) >> 5);
        array[offset + 2] = (byte)((value & 0x1FE000) >> 13);
        return 3;
      }
      else if (value <= 0xFFFFFFF)
      {
        // <=28 bits value
        array[offset + 0] = (byte)(0xE0 | (value & 0x0F));
        array[offset + 1] = (byte)((value & 0x00000FF0) >> 4);
        array[offset + 2] = (byte)((value & 0x000FF000) >> 12);
        array[offset + 3] = (byte)((value & 0x0FF00000) >> 20);
        return 4;
      }
      else
      {
        // >28 bits value
        array[offset + 0] = (byte)(0xF0 | (value & 0x07));
        array[offset + 1] = (byte)((value & 0x000007F8) >> 3);
        array[offset + 2] = (byte)((value & 0x0007F800) >> 11);
        array[offset + 3] = (byte)((value & 0x07F80000) >> 19);
        array[offset + 4] = (byte)((value & 0xF8000000) >> 27);
        return 5;
      }
    }
  }
}

//****************************************************************************************************************************************************

//****************************************************************************************************************************************************
//* BSD 3-Clause License
//*
//* Copyright (c) 2019, Mana Battery
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

using MB.Base.Bits;
using MB.Base.Compression;
using System;
using System.Collections.Generic;
using System.Text;

//----------------------------------------------------------------------------------------------------------------------------------------------------

namespace MB.Base.Container
{
  public class ByteList
  {
    private List<byte> m_content;
    private byte[] m_scratchpad = new byte[32];

    public ByteList(int initialCapacity)
    {
      m_content = new List<byte>(initialCapacity);
    }

    public ByteList(byte[] initialContent)
    {
      m_content = new List<byte>(initialContent);
    }


    public int Count => m_content.Count;

    public byte this[int index] => m_content[index];

    public void AddUInt16(UInt16 value)
    {
      ByteArrayUtil.WriteUInt16LE(m_scratchpad, (UInt32)m_scratchpad.Length, 0, value);
      for (int i = 0; i < 2; ++i)
        m_content.Add(m_scratchpad[i]);
    }

    public void AddUInt32(UInt32 value)
    {
      ByteArrayUtil.WriteUInt32LE(m_scratchpad, (UInt32)m_scratchpad.Length, 0, value);
      for (int i = 0; i < 4; ++i)
        m_content.Add(m_scratchpad[i]);
    }

    public void SetUInt32(int index, UInt32 value)
    {
      ByteArrayUtil.WriteUInt32LE(m_scratchpad, (UInt32)m_scratchpad.Length, 0, value);
      for (int i = 0; i < 4; ++i)
        m_content[index + i] = m_scratchpad[i];
    }

    public void AddEncodedUInt16(UInt16 value)
    {
      int bytesWritten = ValueCompression.WriteSimple(m_scratchpad, 0, (UInt32)value);
      for (int i = 0; i < bytesWritten; ++i)
        m_content.Add(m_scratchpad[i]);
    }

    public void AddEncodedUInt32(UInt32 value)
    {
      int bytesWritten = ValueCompression.WriteSimple(m_scratchpad, 0, value);
      for (int i = 0; i < bytesWritten; ++i)
        m_content.Add(m_scratchpad[i]);
    }

    public void AddEncodedInt32(Int32 value)
    {
      int bytesWritten = ValueCompression.WriteSimple(m_scratchpad, 0, value);
      for (int i = 0; i < bytesWritten; ++i)
        m_content.Add(m_scratchpad[i]);
    }

    public void AddString(string strValue)
    {
      if (strValue == null)
        throw new ArgumentNullException(nameof(strValue));

      // Encode the string to UTF8  (FIX: we could use the scratchpad to avoid allocations here)
      byte[] bytes = UTF8Encoding.UTF8.GetBytes(strValue);
      AddEncodedUInt32((UInt32)bytes.Length);
      m_content.AddRange(bytes);
    }

    public void AddPureString(string strValue)
    {
      // Encode the string to UTF8  (FIX: we could use the scratchpad to avoid allocations here)
      byte[] bytes = UTF8Encoding.UTF8.GetBytes(strValue);
      m_content.AddRange(bytes);
    }


    public byte[] ToArray()
    {
      return m_content.ToArray();
    }
  }
}

//****************************************************************************************************************************************************

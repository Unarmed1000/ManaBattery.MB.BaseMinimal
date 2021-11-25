//****************************************************************************************************************************************************
//* BSD 3-Clause License
//*
//* Copyright (c) 2020, Mana Battery
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

//----------------------------------------------------------------------------------------------------------------------------------------------------

namespace MB.Base.Text
{
  /// <summary>
  /// The C# ReadonlySpan class will be better once its supported properly in Unity.
  /// </summary>
  public readonly ref struct StringView // : IEquatable<StringView>
  {
    private readonly string m_source;
    private readonly int m_startIndex;
    public readonly int Length;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public StringView(string source, int startIndex, int length)
    {
      if (source == null)
      {
        throw new ArgumentNullException(nameof(source));
      }
      if (startIndex < 0 || startIndex > source.Length)
      {
        throw new ArgumentOutOfRangeException(nameof(startIndex));
      }
      if (length < 0 || (source.Length - length) < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(length));
      }

      m_source = source;
      m_startIndex = startIndex;
      Length = length;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public StringView Slice(int start) => Slice(start, Length - start);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public StringView Slice(int start, int length)
    {
      if (start < 0 || start > Length)
        throw new ArgumentOutOfRangeException(nameof(start));
      if (length < 0 || length > (Length - start))
        throw new ArgumentOutOfRangeException(nameof(length));
      return new StringView(m_source, m_startIndex + start, length);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public char this[int index]
    {
      get
      {
        Debug.Assert(index >= 0 && index <= Length);
        return m_source[m_startIndex + index];
      }
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => m_source != null ? m_source.Substring(m_startIndex, Length) : string.Empty;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public char Front
    {
      get
      {
        Debug.Assert(m_source != null);
        Debug.Assert(Length > 0);
        return m_source[0];
      }
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public char Back
    {
      get
      {
        Debug.Assert(m_source != null);
        Debug.Assert(Length > 0);
        return m_source[m_startIndex + Length - 1];
      }
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringView Create(string src)
    {
      src = src != null ? src : string.Empty;
      return new StringView(src, 0, src.Length);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringView Create(string src, int startIndex, int length)
    {
      src = src != null ? src : string.Empty;
      return new StringView(src, startIndex, length);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CompareTo(in StringView v1, in StringView v2)
    {
      // min of v1.Length and v2.Length
      int countCompare = v1.Length <= v2.Length ? v1.Length : v2.Length;
      int result;
      if (countCompare == 0)
      {
        result = 0;
      }
      else
      {
        result = 0;
        for (int i = 0; i < countCompare; ++i)
        {
          if (v1.m_source[v1.m_startIndex + i] != v2.m_source[v2.m_startIndex + i])
          {
            result = v1.m_source[v1.m_startIndex + i] - v2.m_source[v2.m_startIndex + i];
            break;
          }
        }
      }
      return result == 0 ? (((v1.Length > v2.Length) ? 1 : 0) - ((v1.Length < v2.Length) ? 1 : 0)) : (result < 0 ? -1 : 1);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(in StringView v1, in StringView v2)
    {
      return StringView.CompareTo(v1, v2) == 0;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(in StringView v1, in StringView v2) => !(v1 == v2);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
      // a ref struct can not be converted to a object, so this will always be false
      return false;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode()
    {
      int hashCode = 0;
      int endIndex = m_startIndex + Length;
      for (int i = m_startIndex; i < endIndex; ++i)
      {
        hashCode ^= m_source[i].GetHashCode();
      }
      return hashCode;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public bool Equals(StringView other) => this == other;
  }
}

//****************************************************************************************************************************************************

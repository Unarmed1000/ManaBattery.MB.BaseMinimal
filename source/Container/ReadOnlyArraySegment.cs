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

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

//----------------------------------------------------------------------------------------------------------------------------------------------------

namespace MB.Base.Container
{
  /// <summary>
  /// Represents a segment (span) of a read only array.
  /// The main difference of a 'segment' compared to a 'span' is
  /// - the section can be members as its not a ref type.
  /// - the use of it 'might' be slightly slower (once unity includes proper span support)
  /// </summary>
  /// <remarks>On .net core this could be replaced by the native ArraySegment which has been marked as ReadOnly on .net core</remarks>
  /// <typeparam name="T"></typeparam>
  [Serializable]
  public readonly struct ReadOnlyArraySegment<T> : IEquatable<ReadOnlyArraySegment<T>>
  {
    private readonly T[] m_array;
    private readonly int m_startIndex;
    public readonly int Count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlyArraySegment(T[] array)
    {
      if (array == null)
      {
        throw new ArgumentNullException(nameof(array));
      }

      m_array = array;
      m_startIndex = 0;
      Count = array.Length;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlyArraySegment(T[] array, int startIndex, int length)
    {
      if (array == null)
      {
        throw new ArgumentNullException(nameof(array));
      }
      if (startIndex < 0 || startIndex > array.Length)
      {
        throw new ArgumentOutOfRangeException(nameof(startIndex));
      }
      if (length < 0 || length > (array.Length - startIndex))
      {
        throw new ArgumentOutOfRangeException(nameof(length));
      }

      m_array = array;
      m_startIndex = startIndex;
      Count = length;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<T> AsSpan() => new ReadOnlySpan<T>(m_array, m_startIndex, Count);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<T> AsSpan(int start) => AsSpan(start, Count - start);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<T> AsSpan(int start, int length)
    {
      if (start < 0 || start > Count)
        throw new ArgumentOutOfRangeException(nameof(start));
      if (length < 0 || length > (Count - start))
        throw new ArgumentOutOfRangeException(nameof(length));
      return new ReadOnlySpan<T>(m_array, m_startIndex + start, length);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlyArraySegment<T> Slice(int start) => Slice(start, Count - start);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlyArraySegment<T> Slice(int start, int length)
    {
      if (start < 0 || start > Count)
        throw new ArgumentOutOfRangeException(nameof(start));
      if (length < 0 || length > (Count - start))
        throw new ArgumentOutOfRangeException(nameof(length));
      return new ReadOnlyArraySegment<T>(m_array, m_startIndex + start, length);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public ref readonly T this[int index]
    {
      get
      {
        Debug.Assert(index >= 0 && index <= Count);
        return ref m_array[m_startIndex + index];
      }
    }


    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
	[SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>")]
    public T[] SYS_GetArray() => m_array;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int SYS_GetStartIndex() => m_startIndex;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"{{StartIndex:{m_startIndex} Length:{Count} Array:{m_array}}}";

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public ref readonly T Front
    {
      get
      {
        Debug.Assert(m_array != null);
        Debug.Assert(Count > 0);
        Debug.Assert(m_startIndex < Count);
        return ref m_array[m_startIndex];
      }
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public ref readonly T Back
    {
      get
      {
        Debug.Assert(m_array != null);
        Debug.Assert(Count > 0);
        return ref m_array[m_startIndex + Count - 1];
      }
    }


    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(ReadOnlyArraySegment<T> lhs, ReadOnlyArraySegment<T> rhs)
      => lhs.m_array == rhs.m_array && lhs.m_startIndex == rhs.m_startIndex && lhs.Count == rhs.Count;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(ReadOnlyArraySegment<T> lhs, ReadOnlyArraySegment<T> rhs) => !(lhs == rhs);
    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is ReadOnlyArraySegment<T> other && Equals(other);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode()
    {
      return m_array.GetHashCode() ^ m_startIndex.GetHashCode() ^ Count.GetHashCode();
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public bool Equals(ReadOnlyArraySegment<T> other) => this == other;
  }

  //--------------------------------------------------------------------------------------------------------------------------------------------------

  public static class ReadOnlyArraySegment
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "The constructor validates this")]
    public static ReadOnlyArraySegment<T> Create<T>(T[] src) where T : IEquatable<T> => src != null ? new ReadOnlyArraySegment<T>(src) : default;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlyArraySegment<T> Create<T>(T[] src, int startIndex, int length) where T : IEquatable<T>
      => new ReadOnlyArraySegment<T>(src, startIndex, length);


    public static bool IsContentEqual<T>(ReadOnlyArraySegment<T> lhs, ReadOnlyArraySegment<T> rhs) where T : IEquatable<T>
    {
      var lhsSpan = lhs.AsSpan();
      var rhsSpan = rhs.AsSpan();
      if (lhsSpan.Length != rhsSpan.Length)
        return false;
      for (int i = 0; i < lhsSpan.Length; ++i)
      {
        if (!lhsSpan[i].Equals(rhsSpan[i]))
          return false;
      }
      return true;
    }

    //public static bool IsContentEqual2<T>(ReadOnlyArraySegment<T> lhs, ReadOnlyArraySegment<T> rhs) where T : IComparable<T>
    //{
    //  var lhsSpan = lhs.AsSpan();
    //  var rhsSpan = rhs.AsSpan();
    //  if (lhsSpan.Length != rhsSpan.Length)
    //    return false;
    //  for (int i = 0; i < lhsSpan.Length; ++i)
    //  {
    //    if (lhsSpan[i].CompareTo(rhsSpan[i]) != 0)
    //      return false;
    //  }
    //  return true;
    //}

  }

}

//****************************************************************************************************************************************************

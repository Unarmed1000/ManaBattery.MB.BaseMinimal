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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

//----------------------------------------------------------------------------------------------------------------------------------------------------

namespace MB.Base.MathEx.Pixel
{
  [Serializable]
  public struct PxSize2DF : IEquatable<PxSize2DF>
  {
    public const float MinValue = float.MinValue;
    public const float MaxValue = float.MaxValue;

    private float m_width;
    private float m_height;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxSize2DF(float widthPx, float heightPx)
    {
      m_width = Math.Max(widthPx, 0);
      m_height = Math.Max(heightPx, 0);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter",
                                                     Justification = "Used to select this constructor variant")]
    public PxSize2DF(float widthPx, float heightPx, OptimizationCheckFlag optimizationFlag)
    {
      Debug.Assert(widthPx >= 0);
      Debug.Assert(heightPx >= 0);
      Debug.Assert(optimizationFlag == OptimizationCheckFlag.NoCheck);    // remove warning
      m_width = widthPx;
      m_height = heightPx;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public float Width
    {
      get => m_width;
      set => m_width = Math.Max(value, 0);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public float Height
    {
      get => m_height;
      set => m_height = Math.Max(value, 0);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Add
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void AddWidth(float value)
    {
      m_width = Math.Max(m_width + value, 0);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Add
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void AddHeight(float value)
    {
      m_height = Math.Max(m_height + value, 0);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetMax(PxSize2DF value)
    {
      m_width = Math.Max(m_width, value.m_width);
      m_height = Math.Max(m_height, value.m_height);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetMaxWidth(float value)
    {
      m_width = Math.Max(m_width, value);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetMaxHeight(float value)
    {
      m_height = Math.Max(m_height, value);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Add
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize2DF Add(PxSize2DF lhs, PxSize2DF rhs)
    {
      Debug.Assert(lhs.Width <= (float.MaxValue - rhs.Width));
      Debug.Assert(lhs.Height <= (float.MaxValue - rhs.Height));
      return new PxSize2DF(lhs.m_width + rhs.m_width, lhs.m_height + rhs.m_height);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize2DF Subtract(PxSize2DF sizePx, PxSize2DF valuePx)
      => new PxSize2DF(Math.Max(sizePx.m_width - valuePx.m_width, 0), Math.Max(sizePx.m_height - valuePx.m_height, 0),
                      OptimizationCheckFlag.NoCheck);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]

    public static PxSize2DF Divide(PxSize2DF sizePx, float value)
    {
      Debug.Assert(value != 0);
      return new PxSize2DF(sizePx.m_width / value, sizePx.m_height / value, OptimizationCheckFlag.NoCheck);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Add two PxPoint2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxSize2DF operator +(PxSize2DF lhs, PxSize2DF rhs)
    {
      Debug.Assert(lhs.Width <= (float.MaxValue - rhs.Width));
      Debug.Assert(lhs.Height <= (float.MaxValue - rhs.Height));

      return new PxSize2DF(lhs.m_width + rhs.m_width, lhs.m_height + rhs.m_height);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PxSize2DF lhs, PxSize2DF rhs) => (lhs.m_width == rhs.m_width && lhs.m_height == rhs.m_height);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PxSize2DF lhs, PxSize2DF rhs) => !(lhs == rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is PxSize2DF other && (this == other);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => m_width.GetHashCode() ^ m_height.GetHashCode();

    //------------------------------------------------------------------------------------------------------------------------------------------------


    public bool Equals(PxSize2DF other) => m_width == other.m_width && m_height == other.m_height;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"Width:{m_width} Height:{m_height}";


    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static PxSize2DF Min(PxSize2DF val0, PxSize2DF val1)
      => new PxSize2DF(Math.Min(val0.m_width, val1.m_width), Math.Min(val0.m_height, val1.m_height));

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static PxSize2DF Max(PxSize2DF val0, PxSize2DF val1)
      => new PxSize2DF(Math.Max(val0.m_width, val1.m_width), Math.Max(val0.m_height, val1.m_height));
  }
}

//****************************************************************************************************************************************************

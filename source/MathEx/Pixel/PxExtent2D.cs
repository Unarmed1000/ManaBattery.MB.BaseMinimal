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
  public readonly struct PxExtent2D : IEquatable<PxExtent2D>
  {
    public const UInt32 MinValue = UInt32.MinValue;
    public const UInt32 MaxValue = UInt32.MaxValue;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public readonly UInt32 Width;
    public readonly UInt32 Height;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxExtent2D(UInt32 widthPx, UInt32 heightPx)
    {
      Width = widthPx;
      Height = heightPx;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxExtent2D(PxPoint2U value)
    {
      Width = value.X;
      Height = value.Y;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Add
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxExtent2D operator +(PxExtent2D lhs, PxExtent2D rhs) => new PxExtent2D(lhs.Width + rhs.Width, lhs.Height + rhs.Height);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Substract
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxExtent2D operator -(PxExtent2D lhs, PxExtent2D rhs)
    {
      Debug.Assert(lhs.Width >= rhs.Width);
      Debug.Assert(lhs.Height >= rhs.Height);
      return new PxExtent2D(lhs.Width - rhs.Width, lhs.Height - rhs.Height);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Multiply
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxExtent2D operator *(PxExtent2D lhs, PxExtent2D rhs) => new PxExtent2D(lhs.Width * rhs.Width, lhs.Height * rhs.Height);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Multiply by constant
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxExtent2D operator *(PxExtent2D lhs, UInt32 rhs) => new PxExtent2D(lhs.Width * rhs, lhs.Height * rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Multiply
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxExtent2D operator *(UInt32 lhs, PxExtent2D rhs) => new PxExtent2D(lhs * rhs.Width, lhs * rhs.Height);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Divide by constant
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxExtent2D operator /(PxExtent2D lhs, UInt32 rhs) => new PxExtent2D(lhs.Width / rhs, lhs.Height / rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PxExtent2D lhs, PxExtent2D rhs) => (lhs.Width == rhs.Width && lhs.Height == rhs.Height);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PxExtent2D lhs, PxExtent2D rhs) => !(lhs == rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is PxExtent2D other && (this == other);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => Width.GetHashCode() ^ Height.GetHashCode();

    //------------------------------------------------------------------------------------------------------------------------------------------------


    public bool Equals(PxExtent2D other) => Width == other.Width && Height == other.Height;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"Width:{Width} Height:{Height}";
  }
}

//****************************************************************************************************************************************************

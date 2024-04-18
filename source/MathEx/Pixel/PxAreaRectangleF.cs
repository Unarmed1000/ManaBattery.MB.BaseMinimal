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
  /// <summary>
  /// Represents a single float point
  /// </summary>
  [Serializable]
  public readonly struct PxAreaRectangleF : IEquatable<PxAreaRectangleF>
  {
    public readonly float Left;
    public readonly float Top;
    public readonly float Right;
    public readonly float Bottom;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private  PxAreaRectangleF(float left, float top, float right, float bottom, OptimizationInternal flag)
    {
      Debug.Assert(right >= left);
      Debug.Assert(bottom >= top);
      Debug.Assert(flag == OptimizationInternal.NoCheck);
      Left = left;
      Top = top;
      Right = right;
      Bottom = bottom;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxAreaRectangleF(float left, float top, float width, float height)
    {
      Left = left;
      Top = top;
      Right = left + Math.Max(width, 0);
      Bottom = top + Math.Max(height, 0);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxAreaRectangleF(float left, float top, float width, float height, OptimizationCheckFlag flag)
    {
      Debug.Assert(width >= 0);
      Debug.Assert(height >= 0);
      Debug.Assert(flag == OptimizationCheckFlag.NoCheck);

      Left = left;
      Top = top;
      Right = left + width;
      Bottom = top + height;
    }


    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxAreaRectangleF(PxFloat2 topLeft, PxSize2DF size)
    {
      Left = topLeft.X;
      Top = topLeft.Y;
      Right = Left + Math.Max(size.Width, 0);
      Bottom = Top + Math.Max(size.Height, 0);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static PxAreaRectangleF FromLeftTopRightBottom(float left, float top, float right, float bottom)
      => new PxAreaRectangleF(left, top, Math.Max(right, left), Math.Max(bottom, top), OptimizationInternal.NoCheck);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public static PxAreaRectangleF FromLeftTopRightBottom(float left, float top, float right, float bottom, OptimizationCheckFlag flag)
    {
      Debug.Assert(right >= left);
      Debug.Assert(bottom >= top);
      return new PxAreaRectangleF(left, top, right, bottom, OptimizationInternal.NoCheck);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public float Width => Right - Left;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public float Height => Bottom - Top;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    //public float Left => m_left;

    ////------------------------------------------------------------------------------------------------------------------------------------------------

    //public float Top => m_top;

    ////------------------------------------------------------------------------------------------------------------------------------------------------

    //public float Right => m_right;

    ////------------------------------------------------------------------------------------------------------------------------------------------------

    //public float Bottom => m_bottom;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public PxFloat2 Size => new PxFloat2(Right - Left, Bottom - Top);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public PxFloat2 TopLeft => new PxFloat2(Left, Top);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public PxFloat2 TopRight => new PxFloat2(Right, Top);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public PxFloat2 BottomLeft => new PxFloat2(Left, Bottom);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// The bottom right coordinate
    /// </summary>
    public PxFloat2 BottomRight => new PxFloat2(Right, Bottom);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// The top-left coordinates of this.
    /// </summary>
    public PxFloat2 Location
    {
      get => new PxFloat2(Left, Top);
      //set
      //{
      //  m_left = value.X;
      //  m_top = value.Y;
      //}
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public PxFloat2 Center => new PxFloat2(Left + (Width / 2), Top + (Height / 2));

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Gets a value that indicates whether the Rectangle is empty. An empty rectangle has all its values set to 0.
    /// </summary>
    public bool IsEmpty => (Left == 0 && Top == 0 && Right == 0 && Bottom == 0);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxAreaRectangleF SetWidth(in PxAreaRectangleF rect, float value)
      => PxAreaRectangleF.FromLeftTopRightBottom(rect.Left, rect.Top, rect.Left + value, rect.Bottom);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxAreaRectangleF SetHeight(in PxAreaRectangleF rect, float value)
      => PxAreaRectangleF.FromLeftTopRightBottom(rect.Left, rect.Top, rect.Right, rect.Top + value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Set the start location of this rect
    /// </summary>
    /// <param name="rect"></param>
    /// <param name="location"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxAreaRectangleF MoveToLocation(in PxAreaRectangleF rect, PxFloat2 location)
      => new PxAreaRectangleF(location.X, location.Y, rect.Width, rect.Height);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxAreaRectangleF MoveLeft(in PxAreaRectangleF rect, float value)
      => PxAreaRectangleF.FromLeftTopRightBottom(value, rect.Top, value + (rect.Right - rect.Left), rect.Bottom);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxAreaRectangleF MoveTop(in PxAreaRectangleF rect, float value)
      => PxAreaRectangleF.FromLeftTopRightBottom(rect.Left, value, rect.Right, value + (rect.Bottom - rect.Top));


    ////------------------------------------------------------------------------------------------------------------------------------------------------

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public void SetLeftRight(float left, float right)
    //{
    //  m_left = left;
    //  m_right = Math.Max(right, left);
    //}

    ////------------------------------------------------------------------------------------------------------------------------------------------------

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public void SetTopBottom(float top, float bottom)
    //{
    //  m_top = top;
    //  m_bottom = Math.Max(bottom, top);
    //}

    ////------------------------------------------------------------------------------------------------------------------------------------------------

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public void SetWidth(float value)
    //{
    //  m_right = Math.Max(m_left + value, m_left);
    //}

    ////------------------------------------------------------------------------------------------------------------------------------------------------

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public void SetHeight(float value)
    //{
    //  m_bottom = Math.Max(m_top + value, m_top);
    //}

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxAreaRectangleF Deflate(in PxAreaRectangleF source, PxThicknessF value)
    {
      return FromLeftTopRightBottom(source.Left + value.Left, source.Top + value.Top, source.Right - value.Right, source.Bottom - value.Bottom);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(in PxAreaRectangleF lhs, in PxAreaRectangleF rhs)
      => (lhs.Left == rhs.Left && lhs.Top == rhs.Top && lhs.Right == rhs.Right && lhs.Bottom == rhs.Bottom);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(in PxAreaRectangleF lhs, in PxAreaRectangleF rhs) => !(lhs == rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"{{Left:{Left} Top:{Top} Right:{Right} Bottom:{Bottom}}}";

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is PxAreaRectangleF other && (this == other);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => Left.GetHashCode() ^ Top.GetHashCode() ^ Right.GetHashCode() ^ Bottom.GetHashCode();

    //------------------------------------------------------------------------------------------------------------------------------------------------


    public bool Equals(PxAreaRectangleF other)
      => Left == other.Left && Top == other.Top && Right == other.Right && Bottom == other.Bottom;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Contains(float x, float y) => x >= Left && x < Right && y >= Top && y < Bottom;

    /// <summary>
    /// Gets whether or not the provided <see cref="PxAreaRectangleF"/> lies within the bounds of this <see cref="PxAreaRectangleF"/>.
    /// </summary>
    /// <param name="value">The <see cref="PxAreaRectangleF"/> to check for inclusion in this <see cref="PxAreaRectangleF"/>.</param>
    /// <returns><c>true</c> if the provided <see cref="PxAreaRectangleF"/>'s bounds lie entirely inside this <see cref="PxAreaRectangleF"/>; <c>false</c> otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Contains(in PxAreaRectangleF value)
      => Left <= value.Left && value.Right <= Right && Top <= value.Top && value.Bottom <= Bottom;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Contains(float srcLeft, float srcTop, float srcRight, float srcBottom)
      => Left <= srcLeft && srcRight <= Right && Top <= srcTop && srcBottom <= Bottom;

    /// <summary>
    /// Gets whether or not the other <see cref="Rectangle"/> intersects with this rectangle.
    /// </summary>
    /// <param name="value">The other rectangle for testing.</param>
    /// <returns><c>true</c> if other <see cref="Rectangle"/> intersects with this rectangle; <c>false</c> otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Intersects(in PxAreaRectangleF value)
      => value.Left < Right && Left < value.Right && value.Top < Bottom && Top < value.Bottom;


    /// <summary>
    /// Creates a new <see cref="Rectangle"/> that contains overlapping region of two other rectangles.
    /// </summary>
    /// <param name="value1">The first <see cref="Rectangle"/>.</param>
    /// <param name="value2">The second <see cref="Rectangle"/>.</param>
    /// <returns>Overlapping region of the two rectangles.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxAreaRectangleF Intersect(in PxAreaRectangleF value1, in PxAreaRectangleF value2)
    {
      if (value1.Intersects(value2))
      {
        var rightSide = Math.Min(value1.Right, value2.Right);
        var leftSide = Math.Max(value1.Left, value2.Left);
        var topSide = Math.Max(value1.Top, value2.Top);
        var bottomSide = Math.Min(value1.Bottom, value2.Bottom);

        return FromLeftTopRightBottom(leftSide, topSide, rightSide, bottomSide, OptimizationCheckFlag.NoCheck);
      }
      return new PxAreaRectangleF();
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Creates a new Rectangle that exactly contains the two supplied rectangles
    /// </summary>
    /// <param name="rect1"></param>
    /// <param name="rect2"></param>
    /// <returns></returns>
    public static PxAreaRectangleF Union(in PxAreaRectangleF rect1, in PxAreaRectangleF rect2)
    {
      var left = Math.Min(rect1.Left, rect2.Left);
      var top = Math.Min(rect1.Top, rect2.Top);
      var right = Math.Max(rect1.Right, rect2.Right);
      var bottom = Math.Max(rect1.Bottom, rect2.Bottom);

      return FromLeftTopRightBottom(left, top, right, bottom);
    }
  }
}

//****************************************************************************************************************************************************

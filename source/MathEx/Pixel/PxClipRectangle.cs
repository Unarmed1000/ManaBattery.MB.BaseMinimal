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
  public readonly struct PxClipRectangle : IEquatable<PxClipRectangle>
  {
    public readonly Int32 Left;
    public readonly Int32 Top;
    public readonly Int32 Right;
    public readonly Int32 Bottom;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private PxClipRectangle(Int32 leftPx, Int32 topPx, Int32 rightPx, Int32 bottomPx, OptimizationCheckFlag flag)
    {
      Debug.Assert(leftPx <= rightPx);
      Debug.Assert(topPx <= bottomPx);
      Debug.Assert(flag == OptimizationCheckFlag.NoCheck);
      Left = leftPx;
      Top = topPx;
      Right = rightPx;
      Bottom = bottomPx;

      // Detect overflow (the size overflows a int32)
      Debug.Assert((((Int64)rightPx) - ((Int64)leftPx)) <= Int32.MaxValue);
      Debug.Assert((((Int64)bottomPx) - ((Int64)topPx)) <= Int32.MaxValue);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxClipRectangle(Int32 xPx, Int32 yPx, Int32 widthPx, Int32 heightPx)
    {
      Left = xPx;
      Top = yPx;
      Right = xPx + Math.Max(widthPx, 0);
      Bottom = yPx + Math.Max(heightPx, 0);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxClipRectangle(PxPoint2 offset, PxPoint2 size)
    {
      Left = offset.X;
      Top = offset.Y;
      Right = offset.X + Math.Max(size.X, 0);
      Bottom = offset.Y + Math.Max(size.Y, 0);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxClipRectangle(PxPoint2 offset, PxSize2D size)
    {
      Left = offset.X;
      Top = offset.Y;
      Right = offset.X + size.Width;
      Bottom = offset.Y + size.Height;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxClipRectangle(PxRectangle rectPx)
    {
      Left = rectPx.Left;
      Top = rectPx.Top;
      Right = rectPx.Right;
      Bottom = rectPx.Bottom;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxClipRectangle FromLeftTopRightBottom(Int32 leftPx, Int32 topPx, Int32 rightPx, Int32 bottomPx)
      => new PxClipRectangle(leftPx, topPx, Math.Max(leftPx, rightPx), Math.Max(topPx, bottomPx), OptimizationCheckFlag.NoCheck);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxClipRectangle FromLeftTopRightBottom(Int32 leftPx, Int32 topPx, Int32 rightPx, Int32 bottomPx, OptimizationCheckFlag flag)
    {
      Debug.Assert(leftPx <= rightPx);
      Debug.Assert(topPx <= bottomPx);
      return new PxClipRectangle(leftPx, topPx, rightPx, bottomPx, flag);
    }


    public Int32 X => Left;

    public Int32 Y => Top;

    public Int32 Width => Right - Left;

    public Int32 Height => Bottom - Top;

    //public Int32 Left => m_left;

    //public Int32 Top => m_top;

    //public Int32 Right => m_right;

    //public Int32 Bottom => m_bottom;

    /// <summary>
    /// Get the location
    /// </summary>
    public PxPoint2 Location => new PxPoint2(Left, Top);

    public static readonly PxClipRectangle Empty = new PxClipRectangle();

    /// <summary>
    /// Get the size of the rect
    /// </summary>
    public PxSize2D Size => new PxSize2D(Right - Left, Bottom - Top, OptimizationCheckFlag.NoCheck);

    public PxPoint2 TopLeft => new PxPoint2(Left, Top);

    public PxPoint2 TopRight => new PxPoint2(Right, Top);

    public PxPoint2 BottomLeft => new PxPoint2(Left, Bottom);

    public PxPoint2 BottomRight => new PxPoint2(Right, Bottom);


    public PxPoint2 Center => new PxPoint2(Left + ((Right - Left) / 2), Top + ((Bottom - Left) / 2));

    /// <summary>
    /// Move the rect to the given location (Changes left, top, right, bottom)
    /// </summary>
    /// <param name="location"></param>
    /// <param name="rectangle"></param>
    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public void MoveLocation(PxPoint2 location)
    //{
    //  m_right = location.X + (m_right - m_left);
    //  m_bottom = location.Y + (m_bottom - m_top);
    //  m_left = location.X;
    //  m_top = location.Y;
    //}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxClipRectangle MoveLocation(in PxClipRectangle rectangle, PxPoint2 location)
    {
      return FromLeftTopRightBottom(location.X, location.Y, location.X + (rectangle.Right - rectangle.Left),
                                    location.Y + (rectangle.Bottom - rectangle.Top), OptimizationCheckFlag.NoCheck);
    }

    /// <summary>
    /// Move the rect to the given x location(Changes left, right)
    /// </summary>
    /// <param name = "rectangle" ></param>
    /// <param name = "value" ></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxClipRectangle MoveLeft(in PxClipRectangle rectangle, Int32 value)
      => PxClipRectangle.FromLeftTopRightBottom(value, rectangle.Top, value + (rectangle.Right - rectangle.Left), rectangle.Bottom);

    /// <summary>
    /// Move the rect to the given x location(Changes left, right)
    /// </summary>
    /// <param name="rectangle"></param>
    /// <param name = "value" ></param >
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxClipRectangle MoveTop(in PxClipRectangle rectangle, Int32 value)
      => PxClipRectangle.FromLeftTopRightBottom(rectangle.Left, value, rectangle.Right, value + (rectangle.Bottom - rectangle.Top));

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public void SetWidth(Int32 value)
    //{
    //  m_right = Math.Max(m_left + value, m_left);
    //}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxClipRectangle SetWidth(in PxClipRectangle rectangle, Int32 value)
    {
      return FromLeftTopRightBottom(rectangle.Left, rectangle.Top, Math.Max(rectangle.Left + value, rectangle.Left), rectangle.Bottom,
                                    OptimizationCheckFlag.NoCheck);
    }

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public void SetHeight(Int32 value)
    //{
    //  m_bottom = Math.Max(m_top + value, m_top);
    //}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxClipRectangle SetHeight(in PxClipRectangle rectangle, Int32 value)
    {
      return FromLeftTopRightBottom(rectangle.Left, rectangle.Top, rectangle.Right, Math.Max(rectangle.Top + value, rectangle.Top),
                                    OptimizationCheckFlag.NoCheck);
    }

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public void SetSpanX(Int32 left, Int32 width)
    //{
    //  m_left = left;
    //  m_right = Math.Max(m_left + width, m_left);
    //}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxClipRectangle SetSpanX(in PxClipRectangle rectangle, Int32 left, Int32 width)
    {
      return FromLeftTopRightBottom(left, rectangle.Top, Math.Max(left + width, left), rectangle.Bottom, OptimizationCheckFlag.NoCheck);
    }

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public void SetSpanY(Int32 top, Int32 height)
    //{
    //  m_top = top;
    //  m_bottom = Math.Max(m_top + height, m_top);
    //}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxClipRectangle SetSpanY(in PxClipRectangle rectangle, Int32 top, Int32 height)
    {
      return FromLeftTopRightBottom(rectangle.Left, top, rectangle.Right, Math.Max(top + height, top), OptimizationCheckFlag.NoCheck);
    }

    /// <summary>
    /// Check if the x,y coordinate is considered to be contained within this rectangle
    /// </summary>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Contains(Int32 posX, Int32 posY) => ((((posX >= Left) && (posX < Right)) && (posY >= Top)) && (posY < Bottom));

    /// <summary>
    /// Check if the x,y coordinate is considered to be contained within this rectangle
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Contains(PxPoint2 value) => ((((value.X >= Left) && (value.X < Right)) && (value.Y >= Top)) && (value.Y < Bottom));

    /// <summary>
    /// Check if the rectangle is considered to be contained within this rectangle
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Contains(in PxClipRectangle value)
      => ((((value.Left >= Left) && (value.Right <= Right)) && (value.Top >= Top)) && ((value.Top + value.Bottom) <= Bottom));

    public bool IsEmpty => ((((Right == 0) && (Bottom == 0)) && (Left == 0)) && (Top == 0));

    /// <summary>
    /// Determines whether a specified Rectangle intersects with this Rectangle.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Intersects(in PxClipRectangle value)
      => value.Left < Right && Left < value.Right && value.Top < Bottom && Top < value.Bottom;

    /// <summary>
    /// Creates a Rectangle defining the area where one rectangle overlaps another rectangle.
    /// </summary>
    /// <param name="rect1"></param>
    /// <param name="rect2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxClipRectangle Intersect(in PxClipRectangle rect1, in PxClipRectangle rect2)
    {
      if (rect1.Intersects(rect2))
      {
        var rightSide = Math.Min(rect1.Right, rect2.Right);
        var leftSide = Math.Max(rect1.Left, rect2.Left);
        var topSide = Math.Max(rect1.Top, rect2.Top);
        var bottomSide = Math.Min(rect1.Bottom, rect2.Bottom);
        return FromLeftTopRightBottom(leftSide, topSide, rightSide, bottomSide);
      }

      return new PxClipRectangle();
    }


    /// <summary>
    /// Creates a new Rectangle that exactly contains the two supplied rectangles
    /// </summary>
    /// <param name="rect1"></param>
    /// <param name="rect2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxClipRectangle Union(in PxClipRectangle rect1, in PxClipRectangle rect2)
    {
      var x = Math.Min(rect1.Left, rect2.Left);
      var y = Math.Min(rect1.Top, rect2.Top);
      return FromLeftTopRightBottom(x, y, Math.Max(rect1.Right, rect2.Right), Math.Max(rect1.Bottom, rect2.Bottom));
    }


    /// <summary>
    /// Compares whether two <see cref="Rectangle"/> instances are equal.
    /// </summary>
    /// <param name="a"><see cref="Rectangle"/> instance on the left of the equal sign.</param>
    /// <param name="b"><see cref="Rectangle"/> instance on the right of the equal sign.</param>
    /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(in PxClipRectangle a, in PxClipRectangle b)
      => ((a.Left == b.Left) && (a.Top == b.Top) && (a.Right == b.Right) && (a.Bottom == b.Bottom));

    /// <summary>
    /// Compares whether two <see cref="Rectangle"/> instances are not equal.
    /// </summary>
    /// <param name="a"><see cref="Rectangle"/> instance on the left of the not equal sign.</param>
    /// <param name="b"><see cref="Rectangle"/> instance on the right of the not equal sign.</param>
    /// <returns><c>true</c> if the instances are not equal; <c>false</c> otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(in PxClipRectangle a, in PxClipRectangle b) => !(a == b);

    /// <summary>
    /// Compares whether current instance is equal to specified <see cref="Object"/>.
    /// </summary>
    /// <param name="obj">The <see cref="Object"/> to compare.</param>
    /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
    public override bool Equals([NotNullWhen(true)] object? obj) => obj is PxClipRectangle other && this == other;

    /// <summary>
    /// Compares whether current instance is equal to specified <see cref="Rectangle"/>.
    /// </summary>
    /// <param name="other">The <see cref="Rectangle"/> to compare.</param>
    /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
    public bool Equals(PxClipRectangle other) => this == other;

    /// <summary>
    /// Gets the hash code of this <see cref="Rectangle"/>.
    /// </summary>
    /// <returns>Hash code of this <see cref="Rectangle"/>.</returns>
    public override int GetHashCode()
    {
      unchecked
      {
        var hash = 17;
        hash = hash * 23 + Left.GetHashCode();
        hash = hash * 23 + Top.GetHashCode();
        hash = hash * 23 + Right.GetHashCode();
        hash = hash * 23 + Bottom.GetHashCode();
        return hash;
      }
    }

    public override string ToString() => $"X:{Left} Y:{Top} Width:{Right} Height:{Bottom}";
  }
}

//****************************************************************************************************************************************************

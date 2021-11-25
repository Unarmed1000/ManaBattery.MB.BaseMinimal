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

namespace MB.Base.MathEx.Pixel
{
  [Serializable]
  public struct PxRectangleM : IEquatable<PxRectangleM>
  {
    private Int32 m_x;
    private Int32 m_y;
    private Int32 m_width;
    private Int32 m_height;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private PxRectangleM(Int32 xPx, Int32 yPx, Int32 widthPx, Int32 heightPx, OptimizationCheckFlag flag)
    {
      Debug.Assert(widthPx >= 0);
      Debug.Assert(heightPx >= 0);
      Debug.Assert(flag == OptimizationCheckFlag.NoCheck);
      m_x = xPx;
      m_y = yPx;
      m_width = widthPx;
      m_height = heightPx;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxRectangleM(Int32 xPx, Int32 yPx, Int32 widthPx, Int32 heightPx)
    {
      m_x = xPx;
      m_y = yPx;
      m_width = Math.Max(widthPx, 0);
      m_height = Math.Max(heightPx, 0);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxRectangleM(PxPoint2 offset, PxPoint2 size)
    {
      m_x = offset.X;
      m_y = offset.Y;
      m_width = Math.Max(size.X, 0);
      m_height = Math.Max(size.Y, 0);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxRectangleM(PxPoint2 offset, PxSize2D size)
    {
      m_x = offset.X;
      m_y = offset.Y;
      m_width = size.Width;
      m_height = size.Height;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxRectangleM FromLeftTopRightBottom(int leftPx, int topPx, int rightPx, int bottomPx)
    {
      Debug.Assert((((Int64)rightPx) - ((Int64)leftPx)) <= Int32.MaxValue);
      Debug.Assert((((Int64)bottomPx) - ((Int64)topPx)) <= Int32.MaxValue);

      Int32 widthPx = (Int32)MathUtil.Clamp(((Int64)rightPx) - ((Int64)leftPx), (Int64)0, (Int64)Int32.MaxValue);
      Int32 heightPx = (Int32)MathUtil.Clamp(((Int64)bottomPx) - ((Int64)topPx), (Int64)0, (Int64)Int32.MaxValue);
      return new PxRectangleM(leftPx, topPx, widthPx, heightPx);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxRectangleM FromLeftTopRightBottom(Int32 leftPx, Int32 topPx, Int32 rightPx, Int32 bottomPx, OptimizationCheckFlag flag)
    {
      Debug.Assert(leftPx <= rightPx);
      Debug.Assert(topPx <= bottomPx);
      // Detect overflow
      Debug.Assert((((Int64)rightPx) - ((Int64)leftPx)) <= Int32.MaxValue);
      Debug.Assert((((Int64)bottomPx) - ((Int64)topPx)) <= Int32.MaxValue);
      return new PxRectangleM(leftPx, topPx, rightPx - leftPx, bottomPx - topPx, flag);
    }


    public Int32 X
    {
      readonly get => m_x;
      set => m_x = value;
    }

    public Int32 Y
    {
      readonly get => m_y;
      set => m_y = value;
    }

    public Int32 Width
    {
      readonly get => m_width;
      set => m_width = Math.Max(value, 0);
    }

    public Int32 Height
    {
      readonly get => m_height;
      set => m_height = Math.Max(value, 0);
    }

    public readonly Int32 Left => m_x;

    public readonly Int32 Top => m_y;


    public readonly Int32 Right => m_x + m_width;

    public readonly Int32 Bottom => m_y + m_height;

    /// <summary>
    /// Get the location
    /// </summary>
    public PxPoint2 Location
    {
      readonly get => new PxPoint2(m_x, m_y);
      set
      {
        m_x = value.X;
        m_y = value.Y;
      }
    }

    public static readonly PxRectangleM Empty;

    /// <summary>
    /// Get the size of the rect
    /// </summary>
    public PxSize2D Size
    {
      readonly get => new PxSize2D(m_width, m_height, OptimizationCheckFlag.NoCheck);
      set
      {
        m_width = value.Width;
        m_height = value.Height;
      }
    }

    public readonly PxPoint2 TopLeft => new PxPoint2(m_x, m_y);

    public readonly PxPoint2 TopRight => new PxPoint2(m_x + m_width, m_y);

    public readonly PxPoint2 BottomLeft => new PxPoint2(m_x, m_y + m_height);

    public readonly PxPoint2 BottomRight => new PxPoint2(m_x + m_width, m_y + m_height);


    public readonly PxPoint2 Center => new PxPoint2(m_x + (m_width / 2), m_y + (m_height / 2));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void AddX(Int32 value)
    {
      m_x += value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void AddY(Int32 value)
    {
      m_y += value;
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Add(PxPoint2 offsetPx)
    {
      m_x += offsetPx.X;
      m_y += offsetPx.Y;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Sub(PxPoint2 offsetPx)
    {
      m_x -= offsetPx.X;
      m_y -= offsetPx.Y;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void AddSize(PxSize2D sizePx)
    {
      m_width += sizePx.Width;
      m_height += sizePx.Height;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SubSize(PxSize2D sizePx)
    {
      m_width = Math.Max(m_width - sizePx.Width, 0);
      m_height = Math.Max(m_height - sizePx.Height, 0);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetSize(PxSize2D size)
    {
      m_width = size.Width;
      m_height = size.Height;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetSize(PxPoint2 size)
    {
      m_width = Math.Max(size.X, 0);
      m_height = Math.Max(size.Y, 0);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Deflate(PxThickness value)
    {
      m_x += value.Left;
      m_y += value.Top;
      m_width = Math.Max(m_width - value.SumX, 0);
      m_height = Math.Max(m_height - value.SumY, 0);
    }

    /// <summary>
    /// Check if the x,y coordinate is considered to be contained within this rectangle
    /// </summary>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Contains(Int32 posX, Int32 posY)
      => ((((posX >= m_x) && (posX < Right)) && (posY >= m_y)) && (posY < Bottom));

    /// <summary>
    /// Check if the x,y coordinate is considered to be contained within this rectangle
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Contains(PxPoint2 value)
      => ((((value.X >= m_x) && (value.X < Right)) && (value.Y >= m_y)) && (value.Y < Bottom));

    /// <summary>
    /// Check if the rectangle is considered to be contained within this rectangle
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.", Justification = "<Pending>")]
    public readonly bool Contains(in PxRectangleM value)
      => ((((value.m_x >= m_x) && (value.Right <= Right)) && (value.m_y >= m_y)) && ((value.m_y + value.m_height) <= Bottom));

    public bool IsEmpty => ((((m_width == 0) && (m_height == 0)) && (m_x == 0)) && (m_y == 0));

    /// <summary>
    /// Determines whether a specified Rectangle intersects with this Rectangle.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.", Justification = "<Pending>")]
    public readonly bool Intersects(in PxRectangleM value)
      => value.Left < Right && Left < value.Right && value.Top < Bottom && Top < value.Bottom;

    /// <summary>
    /// Creates a Rectangle defining the area where one rectangle overlaps another rectangle.
    /// </summary>
    /// <param name="rect1"></param>
    /// <param name="rect2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.", Justification = "<Pending>")]
    public static PxRectangleM Intersect(in PxRectangleM rect1, in PxRectangleM rect2)
    {
      if (rect1.Intersects(rect2))
      {
        var rightSide = Math.Min(rect1.m_x + rect1.m_width, rect2.m_x + rect2.m_width);
        var leftSide = Math.Max(rect1.m_x, rect2.m_x);
        var topSide = Math.Max(rect1.m_y, rect2.m_y);
        var bottomSide = Math.Min(rect1.m_y + rect1.m_height, rect2.m_y + rect2.m_height);
        return FromLeftTopRightBottom(leftSide, topSide, rightSide, bottomSide);
      }

      return new PxRectangleM();
    }


    /// <summary>
    /// Creates a new Rectangle that exactly contains the two supplied rectangles
    /// </summary>
    /// <param name="rect1"></param>
    /// <param name="rect2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.", Justification = "<Pending>")]
    public static PxRectangleM Union(in PxRectangleM rect1, in PxRectangleM rect2)
      => FromLeftTopRightBottom(Math.Min(rect1.m_x, rect2.m_x), Math.Min(rect1.m_y, rect2.m_y),
                                Math.Max(rect1.Right, rect2.Right), Math.Max(rect1.Bottom, rect2.Bottom));


    /// <summary>
    /// Compares whether two <see cref="PxRectangleM"/> instances are equal.
    /// </summary>
    /// <param name="a"><see cref="PxRectangleM"/> instance on the left of the equal sign.</param>
    /// <param name="b"><see cref="PxRectangleM"/> instance on the right of the equal sign.</param>
    /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.", Justification = "<Pending>")]
    public static bool operator ==(in PxRectangleM a, in PxRectangleM b)
      => ((a.m_x == b.m_x) && (a.m_y == b.m_y) && (a.m_width == b.m_width) && (a.m_height == b.m_height));

    /// <summary>
    /// Compares whether two <see cref="PxRectangleM"/> instances are not equal.
    /// </summary>
    /// <param name="a"><see cref="PxRectangleM"/> instance on the left of the not equal sign.</param>
    /// <param name="b"><see cref="PxRectangleM"/> instance on the right of the not equal sign.</param>
    /// <returns><c>true</c> if the instances are not equal; <c>false</c> otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.", Justification = "<Pending>")]
    public static bool operator !=(in PxRectangleM a, in PxRectangleM b) => !(a == b);

    /// <summary>
    /// Compares whether current instance is equal to specified <see cref="Object"/>.
    /// </summary>
    /// <param name="obj">The <see cref="Object"/> to compare.</param>
    /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
    public override bool Equals([NotNullWhen(true)] object? obj) => obj is PxRectangleM other && this == other;

    /// <summary>
    /// Compares whether current instance is equal to specified <see cref="PxRectangleM"/>.
    /// </summary>
    /// <param name="other">The <see cref="PxRectangleM"/> to compare.</param>
    /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
    public readonly bool Equals(PxRectangleM other) => this == other;

    /// <summary>
    /// Gets the hash code of this <see cref="PxRectangleM"/>.
    /// </summary>
    /// <returns>Hash code of this <see cref="PxRectangleM"/>.</returns>
    public readonly override int GetHashCode()
    {
      unchecked
      {
        var hash = 17;
        hash = hash * 23 + m_x.GetHashCode();
        hash = hash * 23 + m_y.GetHashCode();
        hash = hash * 23 + m_width.GetHashCode();
        hash = hash * 23 + m_height.GetHashCode();
        return hash;
      }
    }

    public readonly override string ToString() => $"X:{m_x} Y:{m_y} Width:{m_width} Height:{m_height}";
  }
}

//****************************************************************************************************************************************************

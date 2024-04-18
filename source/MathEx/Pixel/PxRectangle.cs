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
  public readonly struct PxRectangle : IEquatable<PxRectangle>
  {
    public readonly Int32 X;
    public readonly Int32 Y;
    public readonly Int32 Width;
    public readonly Int32 Height;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private PxRectangle(Int32 xPx, Int32 yPx, Int32 widthPx, Int32 heightPx, OptimizationCheckFlag flag)
    {
      Debug.Assert(widthPx >= 0);
      Debug.Assert(heightPx >= 0);
      Debug.Assert(flag == OptimizationCheckFlag.NoCheck);
      X = xPx;
      Y = yPx;
      Width = widthPx;
      Height = heightPx;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxRectangle(Int32 xPx, Int32 yPx, Int32 widthPx, Int32 heightPx)
    {
      X = xPx;
      Y = yPx;
      Width = Math.Max(widthPx, 0);
      Height = Math.Max(heightPx, 0);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxRectangle(PxPoint2 offset, PxPoint2 size)
    {
      X = offset.X;
      Y = offset.Y;
      Width = Math.Max(size.X, 0);
      Height = Math.Max(size.Y, 0);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxRectangle(PxPoint2 offset, PxSize2D size)
    {
      X = offset.X;
      Y = offset.Y;
      Width = size.Width;
      Height = size.Height;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxRectangle FromLeftTopRightBottom(int leftPx, int topPx, int rightPx, int bottomPx)
    {
      Debug.Assert((((Int64)rightPx) - ((Int64)leftPx)) <= Int32.MaxValue);
      Debug.Assert((((Int64)bottomPx) - ((Int64)topPx)) <= Int32.MaxValue);

      Int32 widthPx = (Int32)MathUtil.Clamp(((Int64)rightPx) - ((Int64)leftPx), (Int64)0, (Int64)Int32.MaxValue);
      Int32 heightPx = (Int32)MathUtil.Clamp(((Int64)bottomPx) - ((Int64)topPx), (Int64)0, (Int64)Int32.MaxValue);
      return new PxRectangle(leftPx, topPx, widthPx, heightPx);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxRectangle FromLeftTopRightBottom(Int32 leftPx, Int32 topPx, Int32 rightPx, Int32 bottomPx, OptimizationCheckFlag flag)
    {
      Debug.Assert(leftPx <= rightPx);
      Debug.Assert(topPx <= bottomPx);
      // Detect overflow
      Debug.Assert((((Int64)rightPx) - ((Int64)leftPx)) <= Int32.MaxValue);
      Debug.Assert((((Int64)bottomPx) - ((Int64)topPx)) <= Int32.MaxValue);
      return new PxRectangle(leftPx, topPx, rightPx - leftPx, bottomPx - topPx, flag);
    }



    public Int32 Left => X;

    public Int32 Top => Y;


    public Int32 Right => X + Width;

    public Int32 Bottom => Y + Height;

    /// <summary>
    /// Get the location
    /// </summary>
    public PxPoint2 Location
    {
      get => new PxPoint2(X, Y);
      //set
      //{
      //  m_x = value.X;
      //  m_y = value.Y;
      //}
    }

    public static readonly PxRectangle Empty = new PxRectangle();

    /// <summary>
    /// Get the size of the rect
    /// </summary>
    public PxSize2D Size
    {
      get => new PxSize2D(Width, Height, OptimizationCheckFlag.NoCheck);
      //set
      //{
      //  m_width = value.Width;
      //  m_height = value.Height;
      //}
    }

    public PxPoint2 TopLeft => new PxPoint2(X, Y);

    public PxPoint2 TopRight => new PxPoint2(X + Width, Y);

    public PxPoint2 BottomLeft => new PxPoint2(X, Y + Height);

    public PxPoint2 BottomRight => new PxPoint2(X + Width, Y + Height);


    public PxPoint2 Center => new PxPoint2(X + (Width / 2), Y + (Height / 2));

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public void AddX(Int32 value)
    //{
    //  m_x += value;
    //}

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public void AddY(Int32 value)
    //{
    //  m_y += value;
    //}


    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public void Add(PxPoint2 offsetPx)
    //{
    //  m_x += offsetPx.X;
    //  m_y += offsetPx.Y;
    //}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxRectangle AddLocation(in PxRectangle source, PxPoint2 offsetPx)
    {
      return new PxRectangle(source.X + offsetPx.X, source.Y + offsetPx.Y, source.Width, source.Height);
    }

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public void Sub(PxPoint2 offsetPx)
    //{
    //  m_x -= offsetPx.X;
    //  m_y -= offsetPx.Y;
    //}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxRectangle SubLocation(in PxRectangle source, PxPoint2 offsetPx)
    {
      return new PxRectangle(source.X - offsetPx.X, source.Y - offsetPx.Y, source.Width, source.Height);
    }

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public void AddSize(PxSize2D sizePx)
    //{
    //  m_width += sizePx.Width;
    //  m_height += sizePx.Height;
    //}

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public void SubSize(PxSize2D sizePx)
    //{
    //  m_width = Math.Max(m_width - sizePx.Width, 0);
    //  m_height = Math.Max(m_height - sizePx.Height, 0);
    //}

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public void SetSize(PxSize2D size)
    //{
    //  m_width = size.Width;
    //  m_height = size.Height;
    //}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxRectangle SetWidth(in PxRectangle src, Int32 newWidth)
      => new PxRectangle(src.Left, src.Top, newWidth, src.Height);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxRectangle SetHeight(in PxRectangle src, Int32 newHeight)
      => new PxRectangle(src.Left, src.Top, src.Width, newHeight);

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public void SetSize(PxPoint2 size)
    //{
    //  m_width = Math.Max(size.X, 0);
    //  m_height = Math.Max(size.Y, 0);
    //}

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public void Deflate(PxThickness value)
    //{
    //  m_x += value.Left;
    //  m_y += value.Top;
    //  m_width = Math.Max(m_width - value.SumX, 0);
    //  m_height = Math.Max(m_height - value.SumY, 0);
    //}


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxRectangle Deflate(in PxRectangle source, PxThickness value)
    {
      return new PxRectangle(source.X + value.Left, source.Y + value.Top, Math.Max(source.Width - value.SumX, 0),
                             Math.Max(source.Height - value.SumY, 0));
    }

    /// <summary>
    /// Check if the x,y coordinate is considered to be contained within this rectangle
    /// </summary>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Contains(Int32 posX, Int32 posY)
      => ((((posX >= X) && (posX < Right)) && (posY >= Y)) && (posY < Bottom));

    /// <summary>
    /// Check if the x,y coordinate is considered to be contained within this rectangle
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Contains(PxPoint2 value)
      => ((((value.X >= X) && (value.X < Right)) && (value.Y >= Y)) && (value.Y < Bottom));

    /// <summary>
    /// Check if the rectangle is considered to be contained within this rectangle
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Contains(PxRectangle value)
      => ((((value.X >= X) && (value.Right <= Right)) && (value.Y >= Y)) && ((value.Y + value.Height) <= Bottom));

    public bool IsEmpty => ((((Width == 0) && (Height == 0)) && (X == 0)) && (Y == 0));

    /// <summary>
    /// Determines whether a specified Rectangle intersects with this Rectangle.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Intersects(PxRectangle value)
      => value.Left < Right && Left < value.Right && value.Top < Bottom && Top < value.Bottom;

    /// <summary>
    /// Creates a Rectangle defining the area where one rectangle overlaps another rectangle.
    /// </summary>
    /// <param name="rect1"></param>
    /// <param name="rect2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxRectangle Intersect(PxRectangle rect1, PxRectangle rect2)
    {
      if (rect1.Intersects(rect2))
      {
        var rightSide = Math.Min(rect1.X + rect1.Width, rect2.X + rect2.Width);
        var leftSide = Math.Max(rect1.X, rect2.X);
        var topSide = Math.Max(rect1.Y, rect2.Y);
        var bottomSide = Math.Min(rect1.Y + rect1.Height, rect2.Y + rect2.Height);
        return FromLeftTopRightBottom(leftSide, topSide, rightSide, bottomSide);
      }

      return new PxRectangle();
    }


    /// <summary>
    /// Creates a new Rectangle that exactly contains the two supplied rectangles
    /// </summary>
    /// <param name="rect1"></param>
    /// <param name="rect2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxRectangle Union(PxRectangle rect1, PxRectangle rect2)
      => FromLeftTopRightBottom(Math.Min(rect1.X, rect2.X), Math.Min(rect1.Y, rect2.Y),
                                Math.Max(rect1.Right, rect2.Right), Math.Max(rect1.Bottom, rect2.Bottom));


    /// <summary>
    /// Compares whether two <see cref="PxRectangle"/> instances are equal.
    /// </summary>
    /// <param name="a"><see cref="PxRectangle"/> instance on the left of the equal sign.</param>
    /// <param name="b"><see cref="PxRectangle"/> instance on the right of the equal sign.</param>
    /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(in PxRectangle a, in PxRectangle b)
      => ((a.X == b.X) && (a.Y == b.Y) && (a.Width == b.Width) && (a.Height == b.Height));

    /// <summary>
    /// Compares whether two <see cref="PxRectangle"/> instances are not equal.
    /// </summary>
    /// <param name="a"><see cref="PxRectangle"/> instance on the left of the not equal sign.</param>
    /// <param name="b"><see cref="PxRectangle"/> instance on the right of the not equal sign.</param>
    /// <returns><c>true</c> if the instances are not equal; <c>false</c> otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(in PxRectangle a, in PxRectangle b) => !(a == b);

    /// <summary>
    /// Compares whether current instance is equal to specified <see cref="Object"/>.
    /// </summary>
    /// <param name="obj">The <see cref="Object"/> to compare.</param>
    /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
    public override bool Equals([NotNullWhen(true)] object? obj) => obj is PxRectangle other && this == other;

    /// <summary>
    /// Compares whether current instance is equal to specified <see cref="PxRectangle"/>.
    /// </summary>
    /// <param name="other">The <see cref="PxRectangle"/> to compare.</param>
    /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
    public bool Equals(PxRectangle other) => this == other;

    /// <summary>
    /// Gets the hash code of this <see cref="PxRectangle"/>.
    /// </summary>
    /// <returns>Hash code of this <see cref="PxRectangle"/>.</returns>
    public override int GetHashCode()
    {
      unchecked
      {
        var hash = 17;
        hash = hash * 23 + X.GetHashCode();
        hash = hash * 23 + Y.GetHashCode();
        hash = hash * 23 + Width.GetHashCode();
        hash = hash * 23 + Height.GetHashCode();
        return hash;
      }
    }

    public override string ToString() => $"X:{X} Y:{Y} Width:{Width} Height:{Height}";

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxRectangle SetLocation(PxRectangle value, PxPoint2 newLocation)
       => new PxRectangle(newLocation.X, newLocation.Y, value.Width, value.Height, OptimizationCheckFlag.NoCheck);
  }
}

//****************************************************************************************************************************************************

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
  public readonly struct PxRectangleU : IEquatable<PxRectangleU>
  {
    public readonly UInt32 X;
    public readonly UInt32 Y;
    public readonly UInt32 Width;
    public readonly UInt32 Height;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxRectangleU(UInt32 xPx, UInt32 yPx, UInt32 widthPx, UInt32 heightPx)
    {
      X = xPx;
      Y = yPx;
      Width = widthPx;
      Height = heightPx;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxRectangleU FromLeftTopRightBottom(UInt32 left, UInt32 top, UInt32 right, UInt32 bottom)
    {
      return new PxRectangleU(left, top, (right >= left ? right - left : 0u), (bottom >= top ? bottom - top : 0u));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxRectangleU FromLeftTopRightBottom(UInt32 left, UInt32 top, UInt32 right, UInt32 bottom, OptimizationCheckFlag flag)
    {
      Debug.Assert(flag == OptimizationCheckFlag.NoCheck);
      Debug.Assert(left <= right);
      Debug.Assert(top <= bottom);
      return new PxRectangleU(left, top, right - left, bottom - top);
    }

    public static readonly PxRectangleU Empty = new PxRectangleU();

    public UInt32 Left => X;

    public UInt32 Top => Y;


    public UInt32 Right => X + Width;

    public UInt32 Bottom => Y + Height;

    public PxExtent2D Extent => new PxExtent2D(Width, Height);

    public PxPoint2U Location => new PxPoint2U(X, Y);

    public PxPoint2U TopLeft => new PxPoint2U(X, Y);

    public PxPoint2U TopRight => new PxPoint2U(X + Width, Y);

    public PxPoint2U BottomLeft => new PxPoint2U(X, Y + Height);

    public PxPoint2U BottomRight => new PxPoint2U(X + Width, Y + Height);

    public PxPoint2U Center => new PxPoint2U(X + (Width / 2), Y + (Height / 2));

    public bool IsEmpty => ((((Width == 0) && (Height == 0)) && (X == 0)) && (Y == 0));

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public void Add(PxPoint2U value)
    //{
    //  X += value.X;
    //  Y += value.Y;
    //}

    /// <summary>
    /// Check if the x,y coordinate is considered to be contained within this rectangle
    /// </summary>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Contains(UInt32 posX, UInt32 posY) => ((((posX >= X) && (posX < (X + Width))) && (posY >= Y)) && (posY < (Y + Height)));

    /// <summary>
    /// Check if the x,y coordinate is considered to be contained within this rectangle
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Contains(PxPoint2U value) => ((((value.X >= X) && (value.X < (X + Width))) && (value.Y >= Y)) && (value.Y < (Y + Height)));

    /// <summary>
    /// Check if the rectangle is considered to be contained within this rectangle
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Contains(in PxRectangleU value)
      => ((((value.X >= X) && ((value.X + value.Width) <= (X + Width))) && (value.Y >= Y)) && ((value.Y + value.Height) <= (Y + Height)));

    /// <summary>
    /// Gets whether or not the other <see cref="PxRectangleU"/> intersects with this rectangle.
    /// </summary>
    /// <param name="value">The other rectangle for testing.</param>
    /// <returns><c>true</c> if other <see cref="PxRectangleU"/> intersects with this rectangle; <c>false</c> otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Intersects(in PxRectangleU value) => value.X < Right && X < value.Right && value.Y < Bottom && Y < value.Bottom;

    /// <summary>
    /// Creates a Rectangle defining the area where one rectangle overlaps another rectangle.
    /// </summary>
    /// <param name="rect1"></param>
    /// <param name="rect2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxRectangleU Intersect(in PxRectangleU rect1, in PxRectangleU rect2)
    {
      if (rect1.Intersects(rect2))
      {
        var rightSide = Math.Min(rect1.X + rect1.Width, rect2.X + rect2.Width);
        var leftSide = Math.Max(rect1.X, rect2.X);
        var topSide = Math.Max(rect1.Y, rect2.Y);
        var bottomSide = Math.Min(rect1.Y + rect1.Height, rect2.Y + rect2.Height);
        return FromLeftTopRightBottom(leftSide, topSide, rightSide, bottomSide, OptimizationCheckFlag.NoCheck);
      }
      return new PxRectangleU();
    }


    /// <summary>
    /// Creates a new Rectangle that exactly contains the two supplied rectangles
    /// </summary>
    /// <param name="rect1"></param>
    /// <param name="rect2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxRectangleU Union(in PxRectangleU rect1, in PxRectangleU rect2)
      => FromLeftTopRightBottom(Math.Min(rect1.X, rect2.X), Math.Min(rect1.Y, rect2.Y),
                                Math.Max(rect1.Right, rect2.Right), Math.Max(rect1.Bottom, rect2.Bottom), OptimizationCheckFlag.NoCheck);


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxRectangleU SetLocation(PxRectangleU value, PxPoint2U newLocation)
       => new PxRectangleU(newLocation.X, newLocation.Y, value.Width, value.Height);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxRectangleU SetWidth(PxRectangleU value, UInt32 newWidth)
       => new PxRectangleU(value.Left, value.Top, newWidth, value.Height);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PxRectangleU SetHeight(PxRectangleU value, UInt32 newHeight)
       => new PxRectangleU(value.Left, value.Top, value.Width, newHeight);

    /// <summary>
    /// Compares whether two <see cref="PxRectangleU"/> instances are equal.
    /// </summary>
    /// <param name="a"><see cref="PxRectangleU"/> instance on the left of the equal sign.</param>
    /// <param name="b"><see cref="PxRectangleU"/> instance on the right of the equal sign.</param>
    /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(in PxRectangleU a, in PxRectangleU b)
      => ((a.X == b.X) && (a.Y == b.Y) && (a.Width == b.Width) && (a.Height == b.Height));

    /// <summary>
    /// Compares whether two <see cref="PxRectangleU"/> instances are not equal.
    /// </summary>
    /// <param name="a"><see cref="PxRectangleU"/> instance on the left of the not equal sign.</param>
    /// <param name="b"><see cref="PxRectangleU"/> instance on the right of the not equal sign.</param>
    /// <returns><c>true</c> if the instances are not equal; <c>false</c> otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(in PxRectangleU a, in PxRectangleU b) => !(a == b);

    /// <summary>
    /// Compares whether current instance is equal to specified <see cref="Object"/>.
    /// </summary>
    /// <param name="obj">The <see cref="Object"/> to compare.</param>
    /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
    public override bool Equals([NotNullWhen(true)] object? obj) => obj is PxRectangleU other && this == other;

    /// <summary>
    /// Compares whether current instance is equal to specified <see cref="PxRectangleU"/>.
    /// </summary>
    /// <param name="other">The <see cref="PxRectangleU"/> to compare.</param>
    /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
    public bool Equals(PxRectangleU other) => this == other;

    /// <summary>
    /// Gets the hash code of this <see cref="PxRectangleU"/>.
    /// </summary>
    /// <returns>Hash code of this <see cref="PxRectangleU"/>.</returns>
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
  }
}

//****************************************************************************************************************************************************

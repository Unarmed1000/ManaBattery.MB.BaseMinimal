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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

//----------------------------------------------------------------------------------------------------------------------------------------------------

namespace MB.Base.MathEx.Pixel
{
  [Serializable]
  public readonly struct PxTrimmedImage : IEquatable<PxTrimmedImage>
  {
    /// <summary>
    /// The image size in pixels
    /// </summary>
    public readonly PxSize2D SizePx;

    /// <summary>
    /// The image trim in pixels
    /// </summary>
    public readonly PxThicknessF TrimMarginPxf;

    /// <summary>
    /// The trimmed image size in pixels
    /// </summary>
    public readonly PxSize2DF TrimmedSizePxf;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxTrimmedImage(PxSize2D sizePx, PxThicknessF trimMarginPxf, PxSize2DF trimmedSizePxf)
    {
      float diffX = Math.Abs(sizePx.Width - (trimMarginPxf.SumX + trimmedSizePxf.Width));
      float diffY = Math.Abs(sizePx.Height - (trimMarginPxf.SumY + trimmedSizePxf.Height));

      if (diffX >= 0.01f || diffY >= 0.01f)
        throw new ArgumentException($"{sizePx}!={trimMarginPxf.Sum + trimmedSizePxf}");
      SizePx = sizePx;
      TrimMarginPxf = trimMarginPxf;
      TrimmedSizePxf = trimmedSizePxf;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PxTrimmedImage lhs, PxTrimmedImage rhs)
      => (lhs.SizePx == rhs.SizePx && lhs.TrimMarginPxf == rhs.TrimMarginPxf && lhs.TrimmedSizePxf == rhs.TrimmedSizePxf);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PxTrimmedImage lhs, PxTrimmedImage rhs) => !(lhs == rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is PxTrimmedImage other && (this == other);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => SizePx.GetHashCode() ^ TrimMarginPxf.GetHashCode() ^ TrimmedSizePxf.GetHashCode();

    //------------------------------------------------------------------------------------------------------------------------------------------------


    public bool Equals(PxTrimmedImage other) => SizePx == other.SizePx && TrimMarginPxf == other.TrimMarginPxf && TrimmedSizePxf == other.TrimmedSizePxf;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"SizePx:{SizePx} TrimMarginPxf:{TrimMarginPxf} TrimmedSizePxf:{TrimmedSizePxf}";
  }
}

//****************************************************************************************************************************************************

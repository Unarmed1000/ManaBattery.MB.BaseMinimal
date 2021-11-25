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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

//----------------------------------------------------------------------------------------------------------------------------------------------------

namespace MB.Base.MathEx.Pixel
{
  [Serializable]
  public readonly struct PxTrimmedNineSlice : IEquatable<PxTrimmedNineSlice>
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
    /// The scaled trimmed nine slice (basically the nine slice information minus the trim, scaled to the current density)
    /// </summary>
    public readonly PxThicknessF TrimmedNineSlicePxf;

    /// <summary>
    /// The scaled content margin
    /// </summary>
    public readonly PxThickness ContentMarginPx;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PxTrimmedNineSlice(PxSize2D sizePx, in PxThicknessF trimMarginPxf, in PxThicknessF trimmedNineSlicePxf, in PxThickness contentMarginPx)
    {
      SizePx = sizePx;
      TrimMarginPxf = trimMarginPxf;
      TrimmedNineSlicePxf = trimmedNineSlicePxf;
      ContentMarginPx = contentMarginPx;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PxTrimmedNineSlice lhs, PxTrimmedNineSlice rhs)
      => (lhs.SizePx == rhs.SizePx && lhs.TrimMarginPxf == rhs.TrimMarginPxf && lhs.TrimmedNineSlicePxf == rhs.TrimmedNineSlicePxf && lhs.ContentMarginPx == rhs.ContentMarginPx);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PxTrimmedNineSlice lhs, PxTrimmedNineSlice rhs) => !(lhs == rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is PxTrimmedNineSlice other && (this == other);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => SizePx.GetHashCode() ^ TrimMarginPxf.GetHashCode() ^ TrimmedNineSlicePxf.GetHashCode() ^ ContentMarginPx.GetHashCode();

    //------------------------------------------------------------------------------------------------------------------------------------------------


    public bool Equals(PxTrimmedNineSlice other) => this == other;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"SizePx:{SizePx} TrimmedNineSlicePxf:{TrimmedNineSlicePxf} ContentMarginPx:{ContentMarginPx}";
  }
}

//****************************************************************************************************************************************************

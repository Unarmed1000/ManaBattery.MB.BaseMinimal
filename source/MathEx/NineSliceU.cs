//****************************************************************************************************************************************************
//* BSD 3-Clause License
//*
//* Copyright (c) 2020, Mana Battery
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

namespace MB.Base.MathEx
{
  [Serializable]
  public readonly struct NineSliceU : IEquatable<NineSliceU>
  {
    public readonly UInt32 SliceFromTopLeftX;
    public readonly UInt32 SliceFromTopLeftY;
    public readonly UInt32 SliceFromBottomRightX;
    public readonly UInt32 SliceFromBottomRightY;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public NineSliceU(UInt32 sliceFromTopLeftX, UInt32 sliceFromTopLeftY, UInt32 sliceFromBottomRightX, UInt32 sliceFromBottomRightY)
    {
      SliceFromTopLeftX = sliceFromTopLeftX;
      SliceFromTopLeftY = sliceFromTopLeftY;
      SliceFromBottomRightX = sliceFromBottomRightX;
      SliceFromBottomRightY = sliceFromBottomRightY;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public UInt32 SumX => SliceFromTopLeftX + SliceFromBottomRightX;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public UInt32 SumY => SliceFromTopLeftY + SliceFromBottomRightY;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public bool IsEmpty => (SliceFromTopLeftX + SliceFromTopLeftY + SliceFromBottomRightX + SliceFromBottomRightY) == 0;

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Check if a NineSliceU is equal to another NineSliceU
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(in NineSliceU lhs, in NineSliceU rhs)
      => (lhs.SliceFromTopLeftX == rhs.SliceFromTopLeftX && lhs.SliceFromTopLeftY == rhs.SliceFromTopLeftY &&
          lhs.SliceFromBottomRightX == rhs.SliceFromBottomRightX && lhs.SliceFromBottomRightY == rhs.SliceFromBottomRightY);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Check if a NineSliceU is not equal to another NineSliceU
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(in NineSliceU lhs, in NineSliceU rhs) => !(lhs == rhs);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is NineSliceU other && (this == other);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override int GetHashCode() => (SliceFromTopLeftX ^ SliceFromTopLeftY ^ SliceFromBottomRightX ^ SliceFromBottomRightY).GetHashCode();

    //------------------------------------------------------------------------------------------------------------------------------------------------

    public override string ToString() => $"({SliceFromTopLeftX}:{SliceFromTopLeftY}:{SliceFromBottomRightX}:{SliceFromBottomRightY})";

    //------------------------------------------------------------------------------------------------------------------------------------------------
    #region IEquatable < NineSliceU> Members
    //------------------------------------------------------------------------------------------------------------------------------------------------

    public bool Equals(NineSliceU other)
      => (SliceFromTopLeftX == other.SliceFromTopLeftX && SliceFromTopLeftY == other.SliceFromTopLeftY &&
          SliceFromBottomRightX == other.SliceFromBottomRightX && SliceFromBottomRightY == other.SliceFromBottomRightY);

    //------------------------------------------------------------------------------------------------------------------------------------------------
    #endregion
    //------------------------------------------------------------------------------------------------------------------------------------------------
  };
}

//****************************************************************************************************************************************************

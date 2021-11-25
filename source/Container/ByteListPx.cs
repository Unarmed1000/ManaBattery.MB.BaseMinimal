﻿//****************************************************************************************************************************************************
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

using MB.Base.MathEx.Pixel;
using System.Diagnostics;

//----------------------------------------------------------------------------------------------------------------------------------------------------

namespace MB.Base.Container
{
  public static class ByteListPx
  {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Should behave the same was a calling a method on a null pointer")]
    public static void AddEncodedPxPoint2U(this ByteList thisObj, PxPoint2U pointPx)
    {
      Debug.Assert(thisObj != null);
      thisObj.AddEncodedUInt32(pointPx.X);
      thisObj.AddEncodedUInt32(pointPx.Y);
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Should behave the same was a calling a method on a null pointer")]
    public static void AddEncodedPxPoint2(this ByteList thisObj, PxPoint2 pointPx)
    {
      Debug.Assert(thisObj != null);
      thisObj.AddEncodedInt32(pointPx.X);
      thisObj.AddEncodedInt32(pointPx.Y);
    }


    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Should behave the same was a calling a method on a null pointer")]
    public static void AddEncodedPxRectangleU(this ByteList thisObj, PxRectangleU trimmedRectPx)
    {
      Debug.Assert(thisObj != null);
      thisObj.AddEncodedUInt32(trimmedRectPx.X);
      thisObj.AddEncodedUInt32(trimmedRectPx.Y);
      thisObj.AddEncodedUInt32(trimmedRectPx.Width);
      thisObj.AddEncodedUInt32(trimmedRectPx.Height);
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Should behave the same was a calling a method on a null pointer")]
    public static void AddEncodedThicknessU(this ByteList thisObj, PxThicknessU trimMarginPx)
    {
      Debug.Assert(thisObj != null);
      thisObj.AddEncodedUInt32(trimMarginPx.Left);
      thisObj.AddEncodedUInt32(trimMarginPx.Top);
      thisObj.AddEncodedUInt32(trimMarginPx.Right);
      thisObj.AddEncodedUInt32(trimMarginPx.Bottom);
    }

  }
}

//****************************************************************************************************************************************************

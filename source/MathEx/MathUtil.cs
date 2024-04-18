#nullable enable
//****************************************************************************************************************************************************
//* BSD 3-Clause License
//*
//* Copyright (c) 2010-2024, Mana Battery
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
using System.Runtime.CompilerServices;

//----------------------------------------------------------------------------------------------------------------------------------------------------

namespace MB.Base.MathEx
{
  /// <summary>
  /// </summary>
  public static partial class MathUtil
  {
    public const float PI = 3.1415926535f;
    public const float TO_RADS = (PI / 180.0f);
    public const float TO_DEGREES = (1.0f / (PI / 180.0f));
    public const float RADS360 = (360.0f * TO_RADS);
    public const float RADS315 = (315.0f * TO_RADS);
    public const float RADS270 = (270.0f * TO_RADS);
    public const float RADS225 = (225.0f * TO_RADS);
    public const float RADS180 = (180.0f * TO_RADS);
    public const float RADS135 = (135.0f * TO_RADS);
    public const float RADS90 = (90.0f * TO_RADS);
    public const float RADS45 = (45.0f * TO_RADS);
    public const float RADS0 = (0);

    /// <summary>
    /// The golden ratio (http://en.wikipedia.org/wiki/Golden_rectangle)
    /// ((1.0 + Math.Sqrt(5.0)) / 2.0);
    /// </summary>
    public const float GoldenRatio = (float)((1.0 + 2.23606797749979) / 2.0);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Clamp(float value, float min, float max) => Math.Min(Math.Max(value, min), max);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte Clamp(byte value, byte min, byte max) => Math.Min(Math.Max(value, min), max);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Clamp(Int32 value, Int32 min, Int32 max) => Math.Min(Math.Max(value, min), max);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt32 Clamp(UInt32 value, UInt32 min, UInt32 max) => Math.Min(Math.Max(value, min), max);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int64 Clamp(Int64 value, Int64 min, Int64 max) => Math.Min(Math.Max(value, min), max);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt64 Clamp(UInt64 value, UInt64 min, UInt64 max) => Math.Min(Math.Max(value, min), max);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Clamp the angle so it's always between 0-2PI
    /// </summary>
    /// <param name="angle"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float ClampAngle(float angle)
    {
      float angleMod = ((float)Math.Floor((Math.Abs(angle) / RADS360))) * RADS360;
      angle += (angle >= 0.0f) ? -angleMod : angleMod;
      return angle >= 0.0f ? angle : angle + RADS360;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte ClampToUInt8(Int32 value) => (byte)Math.Min(Math.Max(value, byte.MinValue), byte.MaxValue);

    //------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Performs a Catmull-Rom interpolation using the specified positions
    /// </summary>
    /// <param name="pos0">the first position</param>
    /// <param name="pos1">the second position</param>
    /// <param name="pos2">the third position</param>
    /// <param name="pos3">the fourth position</param>
    /// <param name="amount">weight factor</param>
    /// <returns>A position that is the result of the Catmull-Rom interpolation</returns>
    public static float CatmullRom(float pos0, float pos1, float pos2, float pos3, float amount)
    {
      // Using formula from http://www.mvps.org/directx/articles/catmull/
      // Using doubles internally to not lose precision.
      double amountSquared = ((double)amount) * amount;
      double amountCubed = amountSquared * amount;
      return (float)(0.5 * ((2.0 * pos1) + ((pos2 - pos0) * amount) + (((2.0 * pos0) - (5.0 * pos1) + (4.0 * pos2) - pos3) * amountSquared) +
                            (((3.0 * pos1) - pos0 - (3.0 * pos2) + pos3) * amountCubed)));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Calc the shortest distance between two angles in radians.
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="rFullRotationDiff">is the number of full rotation that the from and to value differ by</param>
    /// <returns></returns>
    public static float DistBetweenAngles(float from, float to, out int rFullRotationDiff)
    {
      //var diffAngle:Number = Math.atan2(Math.sin(angleTo - currentAngle), Math.cos(angleTo - currentAngle));

      float delta = to - from;
      float numRotations = ((float)Math.Floor((Math.Abs(delta) / RADS360)));
      rFullRotationDiff = Convert.ToInt32(numRotations) * (delta >= 0 ? 1 : -1);
      float deltaMod = numRotations * RADS360;
      delta += (delta >= 0.0f) ? -deltaMod : deltaMod;
      if (delta > 0)
      {
        if (delta <= RADS180)
          return delta;
        rFullRotationDiff += delta >= 0.0f ? 1 : -1;
        return -(RADS360 - delta);
      }
      else
      {
        if (delta >= -RADS180)
          return delta;
        rFullRotationDiff += delta >= 0.0f ? 1 : -1;
        return (RADS360 + delta);
      }
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Calc the shortest distance between two angles in radians.
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    public static float DistBetweenAngles(float from, float to)
    {
      // return (float)Math.Atan2(Math.Sin(to - from), Math.Cos(to - from));

      //float result = (from - to % (PI * 2.0f));
      //if (result < 0)
      //  result = result + (PI * 2.0f);
      //if (result > PI)
      //  result = result - (PI * 2.0f);
      //return (-result);

      float delta = to - from;
      float deltaMod = ((float)Math.Floor((Math.Abs(delta) / RADS360))) * RADS360;
      delta += (delta >= 0.0f) ? -deltaMod : deltaMod;
      if (delta > 0)
        return delta <= RADS180 ? delta : -(RADS360 - delta);
      else
        return delta >= -RADS180 ? delta : (RADS360 + delta);
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Check if a angle is between two other angles (the minimum angle distance between begin and end is that is checked)
    /// </summary>
    /// <param name="begin"></param>
    /// <param name="end"></param>
    /// <param name="angle"></param>
    /// <returns></returns>
    public static bool IsBetweenAngles(float begin, float end, float angle)
    {
      float dist1 = DistBetweenAngles(begin, end);
      float dist2 = DistBetweenAngles(begin, angle);
      if (dist1 < 0)
        return dist2 <= 0 ? dist1 <= dist2 : false;
      else
        return dist2 >= -0 ? dist1 >= dist2 : false;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Convert a vector to a angle.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float UnitVectorToAngle(float x, float y) => (float)Math.Atan2(y, x);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Convert a vector to a angle.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float UnitVectorToClampedAngle(float x, float y)
    {
      var res = (float)Math.Atan2(y, x);
      return res >= 0 ? res : (res + RADS360);
    }

    ///-----------------------------------------------------------------------------------------------------------------------------------------------
    /// Right-angled triangle definitions - http://en.wikipedia.org/wiki/Cotangent#Reciprocal_functions
    ///
    ///                  B
    ///                 /|
    ///                / |
    /// (hypotenuse) h/  |a (opposite)
    ///              /   |
    ///             /____|
    ///            A  b   C
    ///            (adjact)
    /// A right triangle always includes a 90° (π/2 radians) angle, here labeled C. Angles A and B may vary.
    /// Trigonometric functions specify the relationships among side lengths and interior angles of a right triangle.
    ///
    /// Sine      | opposite/hypotenuse | sinθ = cos(π/2 - θ)             = 1/cscθ
    /// Cosine    | adjact/hypotenuse   | cosθ = sin(π/2 - θ)             = 1/secθ
    /// Tangent   | opposite/adjact     | tanθ = sinθ/cosθ = cot(π/2 - θ) = 1/cotθ
    /// Cotangent | adjact/opposite     | cotθ = cosθ/sinθ = tan(π/2 - θ) = 1/tanθ
    /// Secant    | hypotenuse/adjact   | secθ = csc(π/2 - θ)             = 1/cosθ
    /// Cosecant  | hypotenuse/opposite | cscθ = sec(π/2 - θ)             = 1/sinθ
    ///-----------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Cotangent (adjact/opposite | cotθ = cosθ/sinθ = tan(π/2 - θ) = 1/tanθ)
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Cot(double value) => 1.0 / Math.Tan(value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Secant (hypotenuse/adjact | secθ = csc(π/2 - θ) = 1/cosθ)
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Sec(double value) => 1.0 / Math.Cos(value);


    //------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Cosecant (hypotenuse/opposite | cscθ = sec(π/2 - θ) = 1/sinθ)
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Csc(double value) => 1.0 / Math.Sin(value);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int32 RoundToInt32(float value)
    {
      var res = Math.Round(value, MidpointRounding.AwayFromZero);
      Debug.Assert(res >= ((float)Int32.MinValue) && res <= ((float)Int32.MaxValue));
      return (Int32)res;
    }


    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt16 RoundToUInt16(float value)
    {
      var res = Math.Round(value, MidpointRounding.AwayFromZero);
      Debug.Assert(res >= 0.0f && res <= ((float)UInt16.MaxValue));
      return (UInt16)res;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt32 RoundToUInt32(float value)
    {
      var res = Math.Round(value, MidpointRounding.AwayFromZero);
      Debug.Assert(res >= 0.0f && res <= ((float)UInt32.MaxValue));
      return (UInt32)res;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int32 RoundToInt32(double value)
    {
      var res = Math.Round(value, MidpointRounding.AwayFromZero);
      Debug.Assert(res >= ((float)Int32.MinValue) && res <= ((float)Int32.MaxValue));
      return (Int32)res;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int64 RoundToInt64(float value)
    {
      var res = Math.Round(value, MidpointRounding.AwayFromZero);
      Debug.Assert(res >= ((double)Int64.MinValue) && res <= ((double)Int64.MaxValue));
      return (Int64)res;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Int64 RoundToInt64(double value)
    {
      var res = Math.Round(value, MidpointRounding.AwayFromZero);
      Debug.Assert(res >= ((float)Int64.MinValue) && res <= ((float)Int64.MaxValue));
      return (Int64)res;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt16 RoundToUInt16(double value)
    {
      var res = Math.Round(value, MidpointRounding.AwayFromZero);
      Debug.Assert(res >= 0.0f && res <= ((float)UInt16.MaxValue));
      return (UInt16)res;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt32 RoundToUInt32(double value)
    {
      var res = Math.Round(value, MidpointRounding.AwayFromZero);
      Debug.Assert(res >= 0.0f && res <= ((float)UInt32.MaxValue));
      return (UInt32)res;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt64 RoundToUInt64(float value)
    {
      var res = Math.Round(value, MidpointRounding.AwayFromZero);
      Debug.Assert(res >= ((double)UInt64.MinValue) && res <= ((double)UInt64.MaxValue));
      return (UInt64)res;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt64 RoundToUInt64(double value)
    {
      var res = Math.Round(value, MidpointRounding.AwayFromZero);
      Debug.Assert(res >= ((float)UInt64.MinValue) && res <= ((float)UInt64.MaxValue));
      return (UInt64)res;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float RoundToFloat(float value) => (float)Math.Round(value, MidpointRounding.AwayFromZero);

    //------------------------------------------------------------------------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float RoundToFloat(double value) => (float)Math.Round(value, MidpointRounding.AwayFromZero);


  }
}

//****************************************************************************************************************************************************

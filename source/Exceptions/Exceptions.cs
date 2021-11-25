//****************************************************************************************************************************************************
//* BSD 3-Clause License
//*
//* Copyright (c) 2015, Mana Battery
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

//----------------------------------------------------------------------------------------------------------------------------------------------------

using System;

namespace MB.Base.Exceptions
{
  /// <summary>
  /// </summary>
  //public class RecoverRequiresUserActionException : System.Exception
  //{
  //  public RecoverRequiresUserActionException() : base() { }
  //  public RecoverRequiresUserActionException(string desc) : base(desc) { }
  //}


  public class ConversionException : System.Exception
  {
    public ConversionException()
      : base()
    {
    }
    public ConversionException(string desc)
      : base(desc)
    {
    }
    public ConversionException(string desc, Exception innerException)
      : base(desc, innerException)
    {
    }
  }


  public class ConversionUnderflowException : ConversionException
  {
    public ConversionUnderflowException()
      : base()
    {
    }
    public ConversionUnderflowException(string desc)
      : base(desc)
    {
    }
    public ConversionUnderflowException(string desc, Exception innerException)
      : base(desc, innerException)
    {
    }
  }

  public class ConversionOverflowException : ConversionException
  {
    public ConversionOverflowException()
      : base()
    {
    }
    public ConversionOverflowException(string desc)
      : base(desc)
    {
    }
    public ConversionOverflowException(string desc, Exception innerException)
      : base(desc, innerException)
    {
    }
  }


  /// <summary>
  /// </summary>
  public class DecodingErrorException : System.Exception
  {
    public DecodingErrorException()
      : base()
    {
    }
    public DecodingErrorException(string desc)
      : base(desc)
    {
    }
    public DecodingErrorException(string desc, Exception innnerException)
      : base(desc, innnerException)
    {
    }
  }

  /// <summary>
  /// </summary>
  public class DecodingCapacityExceededErrorException : DecodingErrorException
  {
    public DecodingCapacityExceededErrorException()
      : base()
    {
    }
    public DecodingCapacityExceededErrorException(string desc)
      : base(desc)
    {
    }
    public DecodingCapacityExceededErrorException(string desc, Exception innnerException)
      : base(desc, innnerException)
    {
    }
  }

  /// <summary>
  /// </summary>
  public class MissingFormatHeaderException : DecodingErrorException
  {
    public MissingFormatHeaderException()
      : base()
    {
    }
    public MissingFormatHeaderException(string desc)
      : base(desc)
    {
    }
    public MissingFormatHeaderException(string desc, Exception innnerException)
      : base(desc, innnerException)
    {
    }
  }

  /// <summary>
  /// </summary>
  public class UnexpectedFormatContentTypeException : DecodingErrorException
  {
    public UnexpectedFormatContentTypeException()
      : base()
    {
    }
    public UnexpectedFormatContentTypeException(string desc)
      : base(desc)
    {
    }
    public UnexpectedFormatContentTypeException(string desc, Exception innnerException)
      : base(desc, innnerException)
    {
    }
  }

  /// <summary>
  /// </summary>
  public class UnsupportedFormatVersionException : DecodingErrorException
  {
    public UnsupportedFormatVersionException()
      : base()
    {
    }
    public UnsupportedFormatVersionException(string desc)
      : base(desc)
    {
    }
    public UnsupportedFormatVersionException(string desc, Exception innnerException)
      : base(desc, innnerException)
    {
    }
  }


  /// <summary>
  /// </summary>
  public class DecodingCRCException : DecodingErrorException
  {
    public DecodingCRCException()
      : base()
    {
    }
    public DecodingCRCException(string desc)
      : base(desc)
    {
    }
    public DecodingCRCException(string desc, Exception innnerException)
      : base(desc, innnerException)
    {
    }
  }


  /// <summary>
  /// Throw this if an error in the program logic is detected.
  /// </summary>
  public class LogicErrorException : System.Exception
  {
    public LogicErrorException()
      : base()
    {
    }
    public LogicErrorException(string desc)
      : base(desc)
    {
    }
    public LogicErrorException(string desc, Exception innnerException)
      : base(desc, innnerException)
    {
    }
  }

  /// <summary>
  /// Throw this if something happens that shouldnt happen.
  /// </summary>
  public class UnexpectedException : LogicErrorException
  {
    public UnexpectedException()
      : base()
    {
    }
    public UnexpectedException(string desc)
      : base(desc)
    {
    }
    public UnexpectedException(string desc, Exception innnerException)
      : base(desc, innnerException)
    {
    }
  }

  /// <summary>
  /// Throw this if a program is given a invalid parameter.
  /// </summary>
  public class InvalidArgumentException : LogicErrorException
  {
    public InvalidArgumentException()
      : base()
    {
    }
    public InvalidArgumentException(string desc)
      : base(desc)
    {
    }
    public InvalidArgumentException(string desc, Exception innnerException)
      : base(desc, innnerException)
    {
    }
  }

  /// <summary>
  /// Throw this when a object is used in a illegal way.
  /// For example called from the wrong context or using a wrong sequence.
  /// </summary>
  public class UsageErrorException : LogicErrorException
  {
    public UsageErrorException()
      : base()
    {
    }
    public UsageErrorException(string desc)
      : base(desc)
    {
    }
    public UsageErrorException(string desc, Exception innnerException)
      : base(desc, innnerException)
    {
    }
  }

  /// <summary>
  /// Thrown if a internal error occurred in the object
  /// </summary>
  public class InternalErrorException : LogicErrorException
  {
    public InternalErrorException()
      : base()
    {
    }
    public InternalErrorException(string desc)
      : base(desc)
    {
    }
    public InternalErrorException(string desc, Exception innnerException)
      : base(desc, innnerException)
    {
    }
  }


  /// <summary>
  /// Throw this when a object is used in a illegal way.
  /// For example called from the wrong context or using a wrong sequence.
  /// </summary>
  public class OutOfBoundsException : LogicErrorException
  {
    public OutOfBoundsException()
      : base()
    {
    }
    public OutOfBoundsException(string desc)
      : base(desc)
    {
    }
    public OutOfBoundsException(string desc, Exception innnerException)
      : base(desc, innnerException)
    {
    }
  }

  public class NotFoundException : LogicErrorException
  {
    public NotFoundException()
      : base()
    {
    }
    public NotFoundException(string desc)
      : base(desc)
    {
    }
    public NotFoundException(string desc, Exception innnerException)
      : base(desc, innnerException)
    {
    }
  }

  public class ObjectDestroyedException : InvalidOperationException
  {
    public ObjectDestroyedException()
      : base()
    {
    }
    public ObjectDestroyedException(string className)
      : base(className)
    {
    }
    public ObjectDestroyedException(string desc, Exception innnerException)
      : base(desc, innnerException)
    {
    }
  }

}

//****************************************************************************************************************************************************

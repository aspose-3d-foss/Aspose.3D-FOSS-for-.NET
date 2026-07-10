// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Aspose.ThreeD.Render;

/// <summary>
/// The exception raised by internal rendering drivers.
/// </summary>
public class DriverException : Exception
{
    /// <summary>
    /// Initialize an instance of  with specified native driver error code and message.
    /// </summary>
    public DriverException(uint code, string message)
    {
    }

    /// <summary>
    /// Gets the native error code.
    /// </summary>
    public uint ErrorCode { get; }
}

using System;

namespace GHWLauncher;

public class miHoYoApiException : Exception
{

    public int ReturnCode { get; init; }


    public miHoYoApiException(int returnCode, string? message) : base($"{message} ({returnCode})")
    {
        ReturnCode = returnCode;
    }

}
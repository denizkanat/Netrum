﻿namespace Infrastructure.CustomExceptions
{
    public class NoContentException : Exception
    {
        public NoContentException(string message) : base(message) 
        {
            
        }
    }
}

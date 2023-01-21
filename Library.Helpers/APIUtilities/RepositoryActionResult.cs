﻿using System;

namespace Library.Helpers.APIUtilities
{
    public class RepositoryActionResult : RepositoryResult, IRepositoryActionResult
    {
        public Exception Exception { get; }
        public new RepositoryActionStatus Status { get; }

        public RepositoryActionResult(object result = null, RepositoryActionStatus status = RepositoryActionStatus.BadRequest, Exception exception = null, string message = null)
        {
            Data = result;
            Exception = exception;
            Message = message;
            Status = status;
        }

        public IRepositoryActionResult GetRepositoryActionResult(object result = null, RepositoryActionStatus status = RepositoryActionStatus.BadRequest, Exception exception = null, string message = null)
        {
            return  new RepositoryActionResult(result: result, status: status, exception: exception, message: message);
        }
    }
    public class ReleaseNotes
    {
        public string Title { get; set; }
        public string Note { get; set; }
    }
}

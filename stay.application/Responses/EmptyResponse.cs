using stay.application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stay.application.Responses
{
    public class EmptyResponse : AUseCaseResponse
    {
        public IEnumerable<Error> Errors { get; } = Enumerable.Empty<Error>();

        public EmptyResponse(IEnumerable<Error> errors, bool success = false, string message = "") : base(success, message)
        {
            Errors = errors;
        }

        public EmptyResponse(bool success = true, string message = "") : base(success, message)
        {
        }
    }
}

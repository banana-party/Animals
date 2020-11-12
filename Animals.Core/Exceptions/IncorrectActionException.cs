using System;
using System.Runtime.Serialization;

namespace Animals.Core.Exceptions
{
	public class IncorrectActionException : Exception
	{
		public IncorrectActionException()
		{
		}

		public IncorrectActionException(string message) : base(message)
		{
		}

		public IncorrectActionException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected IncorrectActionException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}

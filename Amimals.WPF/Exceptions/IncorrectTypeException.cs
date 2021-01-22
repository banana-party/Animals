using System;
using System.Runtime.Serialization;
//Всё отлично
namespace Amimals.WPF.Exceptions
{
	internal class IncorrectTypeException : Exception
	{
		public IncorrectTypeException()
		{
		}

		public IncorrectTypeException(string message) : base(message)
		{
		}

		public IncorrectTypeException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected IncorrectTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
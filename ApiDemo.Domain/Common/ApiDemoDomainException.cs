using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDemo.Domain.Common
{
	class ApiDemoDomainException : Exception
	{
		public ApiDemoDomainException()
		{ }

		public ApiDemoDomainException(string message)
			: base(message)
		{ }

		public ApiDemoDomainException(string message, Exception innerException)
			: base(message, innerException)
		{ }
	}
}

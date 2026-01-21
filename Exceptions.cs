namespace UniResolve
{

	[System.Serializable]
	public class RegistrationException : System.Exception
	{
		public RegistrationException() { }
		public RegistrationException(string message) : base(message) { }
		public RegistrationException(string message, System.Exception inner) : base(message, inner) { }
		protected RegistrationException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
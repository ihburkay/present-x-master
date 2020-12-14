   namespace WebApi.Helpers{
   public class PresentXException : System.Exception
            {
                public PresentXException() { }
                public PresentXException(string message) : base(message) { }
                public PresentXException(string message, System.Exception inner) : base(message, inner) { }
                protected PresentXException(
                    System.Runtime.Serialization.SerializationInfo info,
                    System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
            }
   }
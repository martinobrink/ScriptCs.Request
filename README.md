ScriptCs.Request
=================
A ScriptCs script pack which allows you to write clean, declarative and non-boilerplate http requests from your scriptcs (.csx) files.

Using this script pack you can write very simple scripts similar to this:


	public class Notification
	{
		public string Message {get; set;}
		public string SenderName {get; set;}
	}
	var notificationToSend = new Notification { Message = "Merry christmas!", SenderName = "Santa"};
	var client = Require<Request>();
	var result = client.PostJson("http://your.site.com/api/notification", notificationToSend);
	Console.WriteLine("Response status code: " + result.StatusCode);


The script pack also has the Json.NET namespace available so you can make use of different Json.NET serialization possibilities (e.g. [JsonIgnore]) to suit your needs. 

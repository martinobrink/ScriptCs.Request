ScriptCs.Request
=================
A cross-platform ScriptCs script library which allows you to write clean, declarative and non-boilerplate http requests from your scriptcs (.csx) files.

Using this cross-platform script library you can write very simple scripts similar to this:


	public class Notification
	{
		public string Message {get; set;}
		public string SenderName {get; set;}
	}
	
	var request = new Request();
	
	var notifications = request.GetJson<List<Notification>>("http://your.site.com/api/notification");
	Console.WriteLine("First notification message: " + notifications[0].Message);
	
	var notificationToSend = new Notification { Message = "Merry christmas!", SenderName = "Santa"};
	var response = request.PostJson("http://your.site.com/api/notification", notificationToSend);
	Console.WriteLine("Response status code: " + response.StatusCode);	


The script library also has the Json.NET namespace available so you can make use of different Json.NET serialization possibilities (e.g. [JsonIgnore]) to suit your needs. 

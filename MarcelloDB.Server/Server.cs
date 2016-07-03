using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MarcelloDB.Server.Models;
using Newtonsoft.Json;

namespace MarcelloDB.Server
{
	public class Server
	{
		private readonly HttpListener _listener = new HttpListener ();

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MarcelloDB.Server.Server"/> class.
		/// </summary>
		/// <param name="prefixes">Prefixes.</param>
		public Server (string [] prefixes)
		{
			if (!HttpListener.IsSupported)
				throw new NotSupportedException ("Sytem does not support HttpListener.");

			// URI prefixes are required, for example 
			// "http://localhost:8080/index/".
			if (prefixes == null || prefixes.Length == 0)
				throw new ArgumentException ("prefixes");

			foreach (string s in prefixes)
				_listener.Prefixes.Add (s);


			//TODO Make function to check if ssl
			_listener.AuthenticationSchemes = AuthenticationSchemes.Basic;
		}

		/// <summary>
		/// Run this instance.
		/// </summary>
		public async void Run ()
		{
			_listener.Start ();

			Console.WriteLine ($"{Constants.Info.Name} {Constants.Info.Version.Short} running...");
			while (_listener.IsListening) {
				SendResponce (await _listener.GetContextAsync ());
			}
		}

		/// <summary>
		/// Stop this instance.
		/// </summary>
		public void Stop ()
		{
			_listener.Stop ();
			_listener.Close ();
		}


		void SendResponce (HttpListenerContext context)
		{
			var request = context.Request;
			var response = context.Response;
			response.ContentType = "application/json";


			Console.WriteLine ($"{request.HttpMethod} {String.Join ("::", ProcessUriPath (request.Url.AbsolutePath))}");

			string responseBody = "";

			try {
				switch (request.HttpMethod.ToUpper ()) {
				case "GET":
					responseBody = GET (ref context);
					break;

				case "POST":
					if (request.HasEntityBody) {
						responseBody = POST (ref context);

					} else {
						responseBody = Error (ref context, 400);
					}
					break;

				default:
					responseBody = Error (ref context, 405);
					break;
				}

			} catch (Exception e) {
				//TODO Log exception
				responseBody = Error (ref context, 500);

			} finally {
				byte [] buffer = System.Text.Encoding.UTF8.GetBytes (responseBody);
				context.Response.OutputStream.Write (buffer, 0, buffer.Length);
				context.Response.OutputStream.Close ();
			}
		}

		ResponseBody ErrorBody (ref HttpListenerContext context, int code)
		{
			//TODO Log Error
			var request = context.Request;
			var response = context.Response;

			response.StatusCode = code;

			var responseBody = new ResponseBody ();
			switch (code) {
			case 400:
				responseBody.Error = new ResponseError { Code = 400, Message = "Bad Request" };
				break;

			case 401:
				responseBody.Error = new ResponseError { Code = 401, Message = "Unauthorized" };
				break;

			case 403:
				responseBody.Error = new ResponseError { Code = 403, Message = "Forbidden" };
				break;

			case 404:
				responseBody.Error = new ResponseError { Code = 404, Message = "Not Found" };
				break;

			case 405:
				responseBody.Error = new ResponseError { Code = 405, Message = $"Method {request.HttpMethod} Not Allowed" };
				break;

			case 500:
				responseBody.Error = new ResponseError { Code = 500, Message = "Internal Server Error" };
				break;

			}
			return responseBody;
		}

		string Error (ref HttpListenerContext context, int code)
		{
			return ErrorBody (ref context, code).ToJSON ();
		}

		string GET (ref HttpListenerContext context)
		{
			var request = context.Request;
			var response = context.Response;

			var responseBody = new ResponseBody ();
			var identity = context.User.Identity as HttpListenerBasicIdentity;

			if (identity.IsAuthenticated) {

				var segments = ProcessUriPath (request.Url.AbsolutePath);

				switch (segments.Length) {
				case 0:
					responseBody = ErrorBody (ref context, 405);
					break;

				case 1:
					switch (segments [0]) {
					case "_Users":
						var user = Data._Users.Instance.Get (identity.Name);
						if (user?.Password == identity.Password && user.AdminPrivledges.Contains (Privledge.Read)) {
							responseBody.Data = Data._Users.Instance.All;
						} else {
							responseBody = ErrorBody (ref context, 403);
						}
						break;

					default:
						break;
					}
					break;

				case 2:
					break;


				default:
					responseBody = ErrorBody (ref context, 404);
					break;

				}
			} else {
				responseBody = ErrorBody (ref context, 405);
			}

			return responseBody.ToJSON ();
		}

		string POST (ref HttpListenerContext context)
		{
			var request = context.Request;
			var response = context.Response;

			var responseBody = new ResponseBody ();
			try {

				using (System.IO.Stream body = request.InputStream) {
					using (System.IO.StreamReader reader = new System.IO.StreamReader (body, request.ContentEncoding)) {
						var requestBody = JsonConvert.DeserializeObject<RequestBody> (reader.ReadToEnd ());
					}
				}
			} catch (Exception ex) {
				//TODO Log exception
				responseBody = ErrorBody (ref context, 400);
			}
			return responseBody.ToJSON ();
		}

		string [] ProcessUriPath (string path)
		{
			return path.Trim ('/').Split ('/');
		}


	}
}
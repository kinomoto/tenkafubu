// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Tenkafubu.Util
{
	public static class StringUtil
	{
		static Random random = new Random();
		static char[] randomChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();


		public static string GetRandomString(int length){
			var chars = new char[length];
			for(int i = 0;i < length;i++){
				chars[i] = randomChars[random.Next(length)];
			}
			return new string(chars);

		}

		public static string MakeUrl(string url, params string[] getParams){
			if(getParams.Length % 2 == 1){
				throw new InvalidOperationException("get params length must be even.");
			}
			
			var builder = new System.Text.StringBuilder();
			for(int i = 0;i < getParams.Length ; i+= 2){
				if(i > 0){
					builder.Append("&");
				}
				var key = getParams[i];
				var value = getParams[i + 1];
				builder.Append(key + "=" + Uri.EscapeUriString(value));
				
			}
			
			if(url.IndexOf("?") > 0){
				url = url + "?" + builder.ToString();
			}else{
				url = url + "&" + builder.ToString();
			}
			return url;
		}

		public static string JoinUrlPath(string server,string path){
			if(server.EndsWith("/") && path.StartsWith("/")){
				return server + path.Substring(1);
			}else if(server.EndsWith("/") || path.StartsWith("/")){
				return server + path;
			}else{
				return server + "/" + path;
			}
		}

		public static List<Tuple2<string,string>> GetGetParams(string url){
			var getParams = new List<Tuple2<string,string>>();
			if(url.IndexOf("#") >= 0){
				url = url.Substring(0,url.IndexOf("#"));
			}

			if(url.IndexOf("?") > 0){
				var query = url.Substring(url.IndexOf("?") + 1);
				foreach(var p in query.Split('&')){
					var kv = p.Split('=');
					if(kv.Length == 2){
						getParams.Add( Tuples.Tuple(kv[0],kv[1]));
					}
				}
			}
			return getParams;
		}

		public static string GetPathWithoutQuery(string url){
			if(url.IndexOf("?") >= 0){
				return url.Substring(0,url.IndexOf("?"));
			}else{
				return url;
			}
		}


	}
}

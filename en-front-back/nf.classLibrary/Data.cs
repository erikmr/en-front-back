using System;
using System.Net;
using System.Reflection;
using System.Text;

namespace nf.classLibrary
{
	public class Data	{
		public Data()
		{
		}

		public static string ExecuteForCrud(string postString) {
            string serverName = "http://backo.globaltoons.tv:3002";
            string endPoint = serverName + "/api/Nf_Data/ExecuteForCRUD";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";

            byte[] bytes = Encoding.UTF8.GetBytes(postString);
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }

            HttpWebResponse httpResponse = (HttpWebResponse)(request.GetResponse());
            string json;
            using (Stream responseStream = httpResponse.GetResponseStream())
            {
                json = new StreamReader(responseStream).ReadToEnd();
            }
            return json;
		}

    }
}


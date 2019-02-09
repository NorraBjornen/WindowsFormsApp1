using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1.Source.Model {
    class HttpRequest {
        private readonly String Address;

        public HttpRequest(String url, Dictionary<String, String> data) {
            StringBuilder builder = new StringBuilder();
            builder.Append(url).Append("?");
            foreach(KeyValuePair<string, string> pair in data) {
                builder.Append(pair.Key).Append("=").Append(pair.Value).Append("&");
            }
            if (builder.ToString().EndsWith("&"))
                builder = builder.Remove(builder.Length - 1, 1);
            Address = builder.ToString();
        }

        public String GetResponse() {
            try {
                Console.WriteLine(Address);
                WebRequest request = WebRequest.Create(Address);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                Stream dataStream = request.GetRequestStream();
                dataStream.Close();
                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                String responseString = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
                return responseString;
            } catch (Exception) {
                return "-";
            }
        }
    }
}

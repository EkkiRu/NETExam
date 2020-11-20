using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace NetworkExam
{
    public class NetworkPost
    {
        public async static void GetAllPosts()
        {
            var getRequest = HttpWebRequest.Create($"https://jsonplaceholder.typicode.com/posts/");
            getRequest.Method = "GET";
            //getRequest.Headers.Add(...)

            var getResponce = await getRequest.GetResponseAsync();
            var post = new List<Post>();

            using (var stream = new StreamReader(getResponce.GetResponseStream()))
            {
                post = JsonConvert.DeserializeObject<List<Post>>(stream.ReadToEnd());
            }

            getResponce.Close();
        }

        public async static void SetPost(Post post)
        {
            var getRequest = HttpWebRequest.Create($"https://jsonplaceholder.typicode.com/posts/");
            getRequest.Method = "POST";
            var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(post));
            var getResponce = await getRequest.GetRequestStreamAsync();
            await getResponce.WriteAsync(data, 0, data.Length);

            Console.WriteLine(((HttpWebResponse)getRequest.GetResponse()).StatusDescription);

            getResponce.Dispose();
        }

        public async static void GetSpecificPosts(int numberPost)
        {
            var getRequest = HttpWebRequest.Create($"https://jsonplaceholder.typicode.com/posts/{numberPost}");
            getRequest.Method = "GET";
            //getRequest.Headers.Add(...)

            var getResponce =await getRequest.GetResponseAsync();
            var post = new Post();

            using (var stream = new StreamReader(getResponce.GetResponseStream()))
            {
                post = JsonConvert.DeserializeObject<Post>(stream.ReadToEnd());
            }

            getResponce.Close();

        }
    }
}

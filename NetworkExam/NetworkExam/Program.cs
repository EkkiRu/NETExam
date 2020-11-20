using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace NetworkExam
{
    class Program
    {

        /*
* Есть сайт с API. https://jsonplaceholder.typicode.com/

Используя полученные навыки создайте консольное приложение способное:
1. Создавать посты
2. Получать список постов
3. Получать 1 пост.

3 пункта меню. Никакого другого вывода не нужно делать.
Но необходимо полученные данные превратить в объекты. А отправляемые объекты превратить в требуемый тиа данных.
*/


        static void Main(string[] args)
        {
            var post = new Post { Body = "Привет", Id = 100, Title = "Как дела", UserId = 90 };
            NetworkPost.SetPost(post);
            NetworkPost.GetAllPosts();
            NetworkPost.GetSpecificPosts(2);
        }




    }
}

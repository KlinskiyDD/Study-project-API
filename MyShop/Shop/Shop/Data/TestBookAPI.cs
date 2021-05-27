using Newtonsoft.Json;
using Shop.Data.Interface;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class TestBookAPI : IBooks
    {
        private HttpClient httpClient { get; set; }

        public TestBookAPI()
        {
            httpClient = new HttpClient();
        }
        public void AddBook(Book book)
        {
            string url = @"https://localhost:5001/api/values";
            var r = httpClient.PostAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8,
                mediaType: "application/json")).Result;
        }

        public void DeleteBook(int? id)
        {
            string url = @"https://localhost:5001/api/values/"+id;
            var r = httpClient.DeleteAsync(url).Result;    
        }

        public void EditeBook(Book book)
        {
            string url = @"https://localhost:5001/api/values";
            var r = httpClient.PutAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8,
                mediaType: "application/json")).Result;
        }

        public Book GetBookOnId(int? id)
        {
            string url = @"https://localhost:5001/api/values/"+id;

            string json = httpClient.GetStringAsync(url).Result;

            return JsonConvert.DeserializeObject<Book>(json);
        }

        public IEnumerable<Book> GetBooks()
        {
            string url = @"https://localhost:5001/api/values";

            string json = httpClient.GetStringAsync(url).Result;

            return JsonConvert.DeserializeObject<IEnumerable<Book>>(json);
        }
    }
}

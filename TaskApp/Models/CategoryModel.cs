using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskApp.Models
{
    public partial class CategoryModel
    {
        [JsonProperty("products")]
        public string[] Products { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }

    public partial class CategoryListModel
    {
        [JsonProperty("data")]
        public CategoryModel[] Data { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

}

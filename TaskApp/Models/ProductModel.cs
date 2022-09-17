using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Xamarin.CommunityToolkit.ObjectModel;

namespace TaskApp.Models
{
    

    public partial class ProductListModel
    {
        [JsonProperty("data")]
        public ProductModel[] Data { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public partial class ProductModel
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("category")]
        public CategoryModel Category { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("createdBy")]
        public CreatedBy CreatedBy { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }
    }

    

    public partial class CreatedBy
    {
        [JsonProperty("role")]
        public Role Role { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class CartModel : ObservableObject
    {
        private int count;
        public int Count
        {
            get => count;
            set => SetProperty(ref count, value);
        }

        public ProductModel Data { get; set; }

    }

    public enum Role { Role_Customer, Role_Super_Admin };

    //internal static class Converter
    //{
    //    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    //    {
    //        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
    //        DateParseHandling = DateParseHandling.None,
    //        Converters =
    //        {
    //            RoleConverter.Singleton,
    //            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
    //        },
    //    };
    //}

    //internal class RoleConverter : JsonConverter
    //{
    //    public override bool CanConvert(Type t) => t == typeof(Role) || t == typeof(Role?);

    //    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    //    {
    //        if (reader.TokenType == JsonToken.Null) return null;
    //        var value = serializer.Deserialize<string>(reader);
    //        switch (value)
    //        {
    //            case "ROLE_CUSTOMER":
    //                return Role.RoleCustomer;
    //            case "ROLE_SUPER_ADMIN":
    //                return Role.RoleSuperAdmin;
    //        }
    //        throw new Exception("Cannot unmarshal type Role");
    //    }

    //    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    //    {
    //        if (untypedValue == null)
    //        {
    //            serializer.Serialize(writer, null);
    //            return;
    //        }
    //        var value = (Role)untypedValue;
    //        switch (value)
    //        {
    //            case Role.RoleCustomer:
    //                serializer.Serialize(writer, "ROLE_CUSTOMER");
    //                return;
    //            case Role.RoleSuperAdmin:
    //                serializer.Serialize(writer, "ROLE_SUPER_ADMIN");
    //                return;
    //        }
    //        throw new Exception("Cannot marshal type Role");
    //    }

    //    public static readonly RoleConverter Singleton = new RoleConverter();
    //}
}

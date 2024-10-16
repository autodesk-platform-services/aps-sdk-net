using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Autodesk.DataManagement.Model;
using System.Collections.Generic;

namespace Autodesk.DataManagement
{

    public class FolderContentsDataConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(List<IFolderContentsData>).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            // If the token is an array, handle deserialization as a list
            if (token.Type == JTokenType.Array)
            {
                List<IFolderContentsData> list = new List<IFolderContentsData>();

                foreach (var item in token.Children<JObject>())
                {
                    var type = (string)item["type"];
                    IFolderContentsData obj;

                    // Determine type and deserialize accordingly
                    if (type == "folders")
                    {
                        obj = item.ToObject<FolderData>(serializer);
                    }
                    else if (type == "items")
                    {
                        obj = item.ToObject<ItemData>(serializer);
                    }
                    else
                    {
                        throw new InvalidOperationException("Unknown type in JSON.");
                    }

                    list.Add(obj);
                }

                return list;
            }

            throw new JsonSerializationException("Expected an array.");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Serialize list of objects
            serializer.Serialize(writer, value);
        }
    }

    public class FolderRefsDataConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(List<IFolderRefsData>).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            // If the token is an array, handle deserialization as a list
            if (token.Type == JTokenType.Array)
            {
                List<IFolderRefsData> list = new List<IFolderRefsData>();

                foreach (var item in token.Children<JObject>())
                {
                    var type = (string)item["type"];
                    IFolderRefsData obj;

                    // Determine type and deserialize accordingly
                    if (type == "folders")
                    {
                        obj = item.ToObject<FolderData>(serializer);
                    }
                    else if (type == "items")
                    {
                        obj = item.ToObject<ItemData>(serializer);
                    }
                    else if (type == "versions")
                    {
                        obj = item.ToObject<VersionData>(serializer);
                    }
                    else
                    {
                        throw new InvalidOperationException("Unknown type in JSON.");
                    }

                    list.Add(obj);
                }

                return list;
            }

            throw new JsonSerializationException("Expected an array.");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Serialize list of objects
            serializer.Serialize(writer, value);
        }
    }

    public class RefsDataConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(List<IRefsData>).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            // If the token is an array, handle deserialization as a list
            if (token.Type == JTokenType.Array)
            {
                List<IRefsData> list = new List<IRefsData>();

                foreach (var item in token.Children<JObject>())
                {
                    var type = (string)item["type"];
                    IRefsData obj;

                    // Determine type and deserialize accordingly
                    if (type == "folders")
                    {
                        obj = item.ToObject<FolderData>(serializer);
                    }
                    else if (type == "items")
                    {
                        obj = item.ToObject<ItemData>(serializer);
                    }
                    else if (type == "versions")
                    {
                        obj = item.ToObject<VersionData>(serializer);
                    }
                    else
                    {
                        throw new InvalidOperationException("Unknown type in JSON.");
                    }

                    list.Add(obj);
                }

                return list;
            }

            throw new JsonSerializationException("Expected an array.");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Serialize list of objects
            serializer.Serialize(writer, value);
        }
    }

    public class RelationshipRefsLinksConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IRelationshipRefsLinks).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);

            IRelationshipRefsLinks result;

            // Check if the JSON contains the "self" or "related" key
            if (jsonObject.ContainsKey("self"))
            {
                // Instantiate the appropriate class based on the key
                result = new JsonApiLinksSelf();
            }
            else if (jsonObject.ContainsKey("related"))
            {
                result = new JsonApiLinksRelated();
            }
            else
            {
                throw new InvalidOperationException("Unknown JSON object, expected 'self' or 'related'.");
            }

            // Populate the object with the JSON data
            serializer.Populate(jsonObject.CreateReader(), result);
            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Delegate the serialization process to the default behavior
            serializer.Serialize(writer, value);
        }
    }

    public class RelationshipRefsIncludedConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(List<IRelationshipRefsIncluded>).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            // If the token is an array, handle deserialization as a list
            if (token.Type == JTokenType.Array)
            {
                List<IRelationshipRefsIncluded> list = new List<IRelationshipRefsIncluded>();

                foreach (var item in token.Children<JObject>())
                {
                    var type = (string)item["type"];
                    IRelationshipRefsIncluded obj;

                    // Determine type and deserialize accordingly
                    if (type == "folders")
                    {
                        obj = item.ToObject<FolderData>(serializer);
                    }
                    else if (type == "items")
                    {
                        obj = item.ToObject<ItemData>(serializer);
                    }
                    else if (type == "versions")
                    {
                        obj = item.ToObject<VersionData>(serializer);
                    }
                    else
                    {
                        throw new InvalidOperationException("Unknown type in JSON.");
                    }

                    list.Add(obj);
                }

                return list;
            }

            throw new JsonSerializationException("Expected an array.");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Serialize list of objects
            serializer.Serialize(writer, value);
        }
    }

    public class ListRefsIncludedConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(List<IListRefsIncluded>).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            // If the token is an array, handle deserialization as a list
            if (token.Type == JTokenType.Array)
            {
                List<IListRefsIncluded> list = new List<IListRefsIncluded>();

                foreach (var item in token.Children<JObject>())
                {
                    var type = (string)item["type"];
                    IListRefsIncluded obj;

                    // Determine type and deserialize accordingly
                    if (type == "items")
                    {
                        obj = item.ToObject<ItemData>(serializer);
                    }
                    else if (type == "versions")
                    {
                        obj = item.ToObject<VersionData>(serializer);
                    }
                    else
                    {
                        throw new InvalidOperationException("Unknown type in JSON.");
                    }

                    list.Add(obj);
                }

                return list;
            }

            throw new JsonSerializationException("Expected an array.");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Serialize list of objects
            serializer.Serialize(writer, value);
        }
    }
}

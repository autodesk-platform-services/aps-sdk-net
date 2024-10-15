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

    // public class CommandDataConverter : JsonConverter
    // {
    //     public override bool CanConvert(Type objectType)
    //     {
    //         return typeof(ICommandData).IsAssignableFrom(objectType);
    //     }

    //     public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //     {
    //         JObject jsonObject = JObject.Load(reader);

    //         // Assuming there is a "type" field in the JSON to distinguish between different command data types
    //         var type = (string)jsonObject["attributes"]["extension"]["type"];

    //         ICommandData result;

    //         // Check the type and instantiate the appropriate class
    //         if (type == "commands:autodesk.core:CheckPermission")  // Adjust based on actual type value in your JSON
    //         {
    //             result = new CheckPermission();
    //         }
    //         else if (type == "commands:autodesk.core:ListRefs")
    //         {
    //             result = new ListRefs();
    //         }
    //         else if (type == "commands:autodesk.core:ListItems")
    //         {
    //             result = new ListItems();
    //         }
    //         else if (type == "commands:autodesk.bim360:C4RModelPublish")
    //         {
    //             result = new PublishModel();
    //         }
    //         else if (type == "commands:autodesk.bim360:C4RPublishWithoutLinks")
    //         {
    //             result = new PublishWithoutLinks();
    //         }
    //         else if (type == "commands:autodesk.bim360:C4RModelGetPublishJob")
    //         {
    //             result = new PublishModelJob();
    //         }
    //         else
    //         {
    //             throw new InvalidOperationException($"Unknown type: {type}");
    //         }

    //         // Populate the object with the JSON data
    //         serializer.Populate(jsonObject.CreateReader(), result);
    //         return result;
    //     }

    //     public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //     {
    //         // Delegate the serialization process to the default behavior
    //         serializer.Serialize(writer, value);
    //     }
    // }
}

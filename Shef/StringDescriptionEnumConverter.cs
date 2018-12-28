using System;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Shef
{
    public class StringDescriptionEnumConverter : StringEnumConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var t = value.GetType();
            foreach (var field in t.GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    writer.WriteValue(attribute.Description);
                    return;
                }
            }
            base.WriteJson(writer, value, serializer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (!objectType.IsEnum) throw new InvalidOperationException();
            foreach (var field in objectType.GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == existingValue.ToString())
                        return field.GetValue(null);
                }
                else
                {
                    if (field.Name == existingValue.ToString())
                        return field.GetValue(null);
                }
            }
            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
}

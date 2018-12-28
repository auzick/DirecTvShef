//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Schema;

//namespace Shef
//{
//    public class EnumMemberValueSerializer : JsonConverter
//    {
//        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
//        {
//            if (!(value is MemberInfo info))
//                throw new InvalidOperationException();
//            var att = Attribute.GetCustomAttribute(info, typeof(DescriptionAttribute)) as DescriptionAttribute;
//            writer.WriteValue(att != null ? att.Description : info.Name);
//        }

//        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
//        {
//            if (!objectType.IsEnum)
//                throw new ArgumentException();
//            FieldInfo[] fields = objectType.GetFields();
//            var field = fields
//                .SelectMany(f => f.GetCustomAttributes(
//                    typeof(DescriptionAttribute), false), (
//                    f, a) => new { Field = f, Att = a })
//                .Where(a => ((DescriptionAttribute)a.Att)
//                            .Description == existingValue).SingleOrDefault();
//            return field;

//        }

//        public override bool CanConvert(Type objectType)
//        {
//            return objectType == typeof(string);
//        }
//    }
//}

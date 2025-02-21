﻿using MyHordesOptimizerApi.Attributes.Firebase;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace MyHordesOptimizerApi.Extensions
{
    public static class JsonConvertExtensions
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static string ToFirebaseJson(this object obj)
        {
            var serializerSettings = new JsonSerializerSettings { ContractResolver = new FirebaseIgnoreResolver() };
            return JsonConvert.SerializeObject(obj, serializerSettings);
        }

        public static T FromJson<T>(this string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }

    public class FirebaseIgnoreResolver : DefaultContractResolver
    {
        public FirebaseIgnoreResolver()
        {
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            var ignoreAttribute = member.GetCustomAttribute<FirebaseSerializeIgnore>();
            if (ignoreAttribute != null)
            {
                property.ShouldSerialize = _ => false;
            }
            return property;
        }
    }
}

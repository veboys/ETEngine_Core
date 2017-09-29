using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class JsonNetPacker : IMessagePacker
    {
        public object DeserializeFrom(Type type, byte[] bytes)
        {
            var json = Encoding.UTF8.GetString(bytes);
            return JsonConvert.DeserializeObject(json, type);
        }

        public object DeserializeFrom(Type type, byte[] bytes, int index, int count)
        {
            var buffer = new byte[count];
            Array.Copy(bytes, index, buffer, 0, count);
            return DeserializeFrom(type, buffer);
        }

        public T DeserializeFrom<T>(byte[] bytes)
        {
            var json = Encoding.UTF8.GetString(bytes);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public T DeserializeFrom<T>(byte[] bytes, int index, int count)
        {
            var buffer = new byte[count];
            Array.Copy(bytes, index, buffer, 0, count);
            return DeserializeFrom<T>(buffer);
        }

        public T DeserializeFrom<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public object DeserializeFrom(Type type, string json)
        {
            return JsonConvert.DeserializeObject(json, type);
        }

        public byte[] SerializeToByteArray(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return Encoding.UTF8.GetBytes(json);
        }

        public string SerializeToText(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}

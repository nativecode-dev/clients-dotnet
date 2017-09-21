﻿using System.Linq;
using System.Net.Http;
using System.Text;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace NativeCode.BitBucket.Extensions
{
    public static class HttpRequestMessageExtensions
    {
        public static bool IsJson([NotNull] this HttpContent content)
        {
            return BitBucketHeaders.JsonMediaTypes.Contains(content.Headers.ContentType.MediaType.ToLower());
        }

        public static void Serialize<T>([NotNull] this HttpRequestMessage request, [NotNull] T instance)
        {
            var content = JsonConvert.SerializeObject(instance, SerializationOptions.Settings);
            request.Content = new StringContent(content, Encoding.UTF8, BitBucketHeaders.JsonMediaTypes.First());
        }
    }
}
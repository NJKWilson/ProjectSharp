using System.Collections.Generic;

namespace ProjectSharp.WebApi.Common.Extensions
{
    public static class DictionaryExtensions
    {
        public static void AddOrUpdate(this Dictionary<string, List<string>> targetDictionary, string key, string entry)
        {
            if (!targetDictionary.ContainsKey(key))
                targetDictionary.Add(key, new List<string>());

            targetDictionary[key].Add(entry);
        }
    }
}
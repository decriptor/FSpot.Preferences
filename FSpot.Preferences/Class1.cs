using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace FSpot.Preferences
{
    public interface IPrefencesStore
    {
        bool TryGet<T>(string key, out T val);
        void Set(string key, object value); 
    }

    public class DictionaryPreferenceStore : IPrefencesStore
    {
        readonly Dictionary<string, object> store = new Dictionary<string, object>();

        public bool TryGet<T>(string key, out T val)
        {
            if (store.ContainsKey(key))
            {
                val = (T)store[key];
                return true;
            }

            val = null;
            return false;
        }

        public void Set(string key, object value)
        {
            throw new NotImplementedException();
        }
    }
}

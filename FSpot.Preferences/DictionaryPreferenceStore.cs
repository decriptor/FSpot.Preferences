using System.Collections.Generic;

namespace FSpot.Preferences
{
    public class MemoryPreferenceStore : IPreferenceStore
    {
        readonly Dictionary<string, object> store;

        public MemoryPreferenceStore ()
        {
            store = new Dictionary<string, object>();
        }

        public int Count => store.Count;

        public bool TryGet<T>(string key, out T val)
        {
            if (store.ContainsKey(key))
            {
                val = (T)store[key];
                return true;
            }

            val = default(T);
            return false;
        }

        public void Set(string key, object value)
        {
            store[key] = value;
        }
    }
}

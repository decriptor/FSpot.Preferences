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

        public bool TryGet<T>(string key, out T result)
        {
            if (store.TryGetValue (key, out var value)) {
                if (value == null) {
                    result = default(T);
                    return true;
                } else if (value.GetType() == typeof(T)) {
                    result = (T)value;
                    return true;
                }
            }

            result = default(T);
            return false;
        }

        public void Set<T>(string key, T value)
        {
            store[key] = value;
        }
    }
}

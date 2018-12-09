﻿using System;

using Newtonsoft.Json;

namespace FSpot.Preferences
{
    public interface IPreferenceStore
    {
        bool TryGet<T>(string key, out T val);
        void Set(string key, object value); 
    }
}

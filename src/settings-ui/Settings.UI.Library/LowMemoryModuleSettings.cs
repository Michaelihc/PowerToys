// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Microsoft.PowerToys.Settings.UI.Library
{
    [JsonConverter(typeof(LowMemoryModuleSettingsJsonConverter))]
    public class LowMemoryModuleSettings
    {
        private readonly Dictionary<string, bool> _settings = new(StringComparer.Ordinal);

        public LowMemoryModuleSettings()
        {
            SetDefaultValue("TextExtractor", false);
            SetDefaultValue("ColorPicker", false);
            SetDefaultValue("AdvancedPaste", false);
            SetDefaultValue("Peek", false);
        }

        [JsonIgnore]
        public bool TextExtractor
        {
            get => GetValue("TextExtractor");
            set => SetValue("TextExtractor", value);
        }

        [JsonIgnore]
        public bool ColorPicker
        {
            get => GetValue("ColorPicker");
            set => SetValue("ColorPicker", value);
        }

        [JsonIgnore]
        public bool AdvancedPaste
        {
            get => GetValue("AdvancedPaste");
            set => SetValue("AdvancedPaste", value);
        }

        [JsonIgnore]
        public bool Peek
        {
            get => GetValue("Peek");
            set => SetValue("Peek", value);
        }

        public bool GetValue(string moduleKey, bool defaultValue = false)
        {
            return _settings.TryGetValue(moduleKey, out bool value) ? value : defaultValue;
        }

        public bool SetValue(string moduleKey, bool value)
        {
            bool oldValue = GetValue(moduleKey);
            _settings[moduleKey] = value;
            return oldValue != value;
        }

        public void EnsureValue(string moduleKey, bool defaultValue = false)
        {
            SetDefaultValue(moduleKey, defaultValue);
        }

        internal IEnumerable<KeyValuePair<string, bool>> ValuesForSerialization => _settings;

        private void SetDefaultValue(string moduleKey, bool defaultValue)
        {
            if (!_settings.ContainsKey(moduleKey))
            {
                _settings[moduleKey] = defaultValue;
            }
        }
    }
}

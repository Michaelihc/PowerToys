// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.PowerToys.Settings.UI.Library
{
    public sealed class LowMemoryModuleSettingsJsonConverter : JsonConverter<LowMemoryModuleSettings>
    {
        public override LowMemoryModuleSettings Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            var settings = new LowMemoryModuleSettings();
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return settings;
                }

                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException();
                }

                string moduleKey = reader.GetString();
                if (!reader.Read())
                {
                    throw new JsonException();
                }

                if (reader.TokenType == JsonTokenType.True || reader.TokenType == JsonTokenType.False)
                {
                    settings.SetValue(moduleKey, reader.GetBoolean());
                }
                else
                {
                    reader.Skip();
                }
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, LowMemoryModuleSettings value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            foreach (var setting in value.ValuesForSerialization)
            {
                writer.WriteBoolean(setting.Key, setting.Value);
            }

            writer.WriteEndObject();
        }
    }
}

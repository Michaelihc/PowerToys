// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Text.Json.Serialization;

namespace Microsoft.PowerToys.Settings.UI.Library
{
    public class FastLaunchSettings
    {
        public FastLaunchSettings()
        {
            TextExtractor = true;
            ColorPicker = true;
            AdvancedPaste = true;
            Peek = true;
        }

        [JsonPropertyName("TextExtractor")]
        public bool TextExtractor { get; set; }

        [JsonPropertyName("ColorPicker")]
        public bool ColorPicker { get; set; }

        [JsonPropertyName("AdvancedPaste")]
        public bool AdvancedPaste { get; set; }

        [JsonPropertyName("Peek")]
        public bool Peek { get; set; }
    }
}

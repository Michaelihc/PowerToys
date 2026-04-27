// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using ManagedCommon;

namespace Microsoft.PowerToys.Settings.UI.Library.Helpers
{
    public sealed class LowMemoryModuleDescriptor
    {
        public LowMemoryModuleDescriptor(ModuleType moduleType, string moduleKey, string generalSettingsResourceKey)
        {
            ModuleType = moduleType;
            ModuleKey = moduleKey;
            GeneralSettingsResourceKey = generalSettingsResourceKey;
        }

        public ModuleType ModuleType { get; }

        public string ModuleKey { get; }

        public string GeneralSettingsResourceKey { get; }
    }
}

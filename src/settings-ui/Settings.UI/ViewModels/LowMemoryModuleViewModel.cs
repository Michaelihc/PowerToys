// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

using ManagedCommon;
using Microsoft.PowerToys.Settings.UI.Library.Helpers;

namespace Microsoft.PowerToys.Settings.UI.ViewModels
{
    public sealed class LowMemoryModuleViewModel : Observable
    {
        private readonly Func<ModuleType, bool> _getLowMemoryMode;
        private readonly Func<ModuleType, bool, bool> _setLowMemoryMode;
        private bool _isEnabled;

        public LowMemoryModuleViewModel(
            LowMemoryModuleDescriptor descriptor,
            Func<string, string> getResourceString,
            Func<ModuleType, bool> getLowMemoryMode,
            Func<ModuleType, bool, bool> setLowMemoryMode)
        {
            Descriptor = descriptor;
            Header = getResourceString($"{descriptor.GeneralSettingsResourceKey}/Header");
            Description = getResourceString($"{descriptor.GeneralSettingsResourceKey}/Description");
            _getLowMemoryMode = getLowMemoryMode;
            _setLowMemoryMode = setLowMemoryMode;
            _isEnabled = _getLowMemoryMode(Descriptor.ModuleType);
        }

        public LowMemoryModuleDescriptor Descriptor { get; }

        public string Header { get; }

        public string Description { get; }

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                if (_isEnabled == value)
                {
                    return;
                }

                if (_setLowMemoryMode(Descriptor.ModuleType, value) || _getLowMemoryMode(Descriptor.ModuleType) == value)
                {
                    _isEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public void Refresh()
        {
            bool newValue = _getLowMemoryMode(Descriptor.ModuleType);
            if (_isEnabled != newValue)
            {
                _isEnabled = newValue;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }
    }
}

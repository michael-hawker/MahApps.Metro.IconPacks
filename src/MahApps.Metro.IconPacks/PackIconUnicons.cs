﻿using System;
using System.Collections.Generic;
#if (NETFX_CORE || WINDOWS_UWP)
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
#else
using System.Windows;
#endif

namespace MahApps.Metro.IconPacks
{
    /// <summary>
    /// Unicons are Open Source icons and licensed under [Apache 2.0](<see><cref>https://www.apache.org/licenses/LICENSE-2.0.txt</cref></see>). You're free to use these icons in your personal and commercial project. We would love to see the attribution in your app's **about** screen, but it's not mandatory.
    /// Contributions, corrections and requests can be made on GitHub <see><cref>https://github.com/Iconscout/unicons</cref></see>.
    /// </summary>
    public class PackIconUnicons : PackIconControlBase
    {
        private static Lazy<IDictionary<PackIconUniconsKind, string>> _dataIndex;

        public static readonly DependencyProperty KindProperty
            = DependencyProperty.Register(nameof(Kind), typeof(PackIconUniconsKind), typeof(PackIconUnicons), new PropertyMetadata(default(PackIconUniconsKind), KindPropertyChangedCallback));

        private static void KindPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                ((PackIconUnicons)dependencyObject).UpdateData();
            }
        }

        /// <summary>
        /// Gets or sets the icon to display.
        /// </summary>
        public PackIconUniconsKind Kind
        {
            get { return (PackIconUniconsKind)GetValue(KindProperty); }
            set { SetValue(KindProperty, value); }
        }

#if !(NETFX_CORE || WINDOWS_UWP)
        static PackIconUnicons()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PackIconUnicons), new FrameworkPropertyMetadata(typeof(PackIconUnicons)));
        }
#endif

        public PackIconUnicons()
        {
#if NETFX_CORE || WINDOWS_UWP
            this.DefaultStyleKey = typeof(PackIconUnicons);
#endif

            if (_dataIndex == null)
            {
                _dataIndex = new Lazy<IDictionary<PackIconUniconsKind, string>>(PackIconUniconsDataFactory.Create);
            }
        }

        protected override void SetKind<TKind>(TKind iconKind)
        {
#if NETFX_CORE || WINDOWS_UWP
            BindingOperations.SetBinding(this, PackIconUnicons.KindProperty, new Binding() { Source = iconKind, Mode = BindingMode.OneTime });
#else
            this.SetCurrentValue(KindProperty, iconKind);
#endif
        }

        protected override void UpdateData()
        {
            if (Kind != default(PackIconUniconsKind))
            {
                string data = null;
                _dataIndex.Value?.TryGetValue(Kind, out data);
                this.Data = data;
            }
            else
            {
                this.Data = null;
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace MahApps.Metro.IconPacks
{
    /// <summary>
    /// The Rpg Awesome font is licensed under the [SIL OFL 1.1](<see><cref>http://scripts.sil.org/OFL</cref></see>)
    /// Contributions, corrections and requests can be made on GitHub <see><cref>https://github.com/nagoshiashumari/Rpg-Awesome</cref></see>.
    /// </summary>
    public class PathIconRPGAwesome : PathIconControlBase
    {
        private static Lazy<IDictionary<PackIconRPGAwesomeKind, string>> _dataIndex;

        public static readonly DependencyProperty KindProperty
            = DependencyProperty.Register(nameof(Kind), typeof(PackIconRPGAwesomeKind), typeof(PathIconRPGAwesome), new PropertyMetadata(default(PackIconRPGAwesomeKind), KindPropertyChangedCallback));

        private static void KindPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                ((PathIconRPGAwesome)dependencyObject).UpdateData();
            }
        }

        /// <summary>
        /// Gets or sets the icon to display.
        /// </summary>
        public PackIconRPGAwesomeKind Kind
        {
            get { return (PackIconRPGAwesomeKind)GetValue(KindProperty); }
            set { SetValue(KindProperty, value); }
        }

        public PathIconRPGAwesome()
        {
            if (_dataIndex == null)
            {
                _dataIndex = new Lazy<IDictionary<PackIconRPGAwesomeKind, string>>(PackIconRPGAwesomeDataFactory.Create);
            }

            var transformGroup = this.RenderTransform as TransformGroup ?? new TransformGroup();
            var scaleTransform = new ScaleTransform() {ScaleY = -1};
            transformGroup.Children.Insert(0, scaleTransform);
        }

        protected override void UpdateData()
        {
            string data = null;
            _dataIndex.Value?.TryGetValue(Kind, out data);
            if (string.IsNullOrEmpty(data))
            {
                this.Data = default(Geometry);
            }
            else
            {
                BindingOperations.SetBinding(this, PathIcon.DataProperty, new Binding() {Source = data, Mode = BindingMode.OneTime});
            }
        }
    }
}
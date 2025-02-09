﻿using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace MahApps.Metro.IconPacks
{
    /// <summary>
    /// All icons sourced from Modern UI Icons Font - <see><cref>http://modernuiicons.com</cref></see> - in accordance of
    /// <see><cref>https://github.com/Templarian/WindowsIcons/blob/master/WindowsPhone/license.txt</cref></see>.
    /// </summary>
    public class PathIconModern : PathIconControlBase
    {
        private static Lazy<IDictionary<PackIconModernKind, string>> _dataIndex;

        public static readonly DependencyProperty KindProperty
            = DependencyProperty.Register(nameof(Kind), typeof(PackIconModernKind), typeof(PathIconModern), new PropertyMetadata(default(PackIconModernKind), KindPropertyChangedCallback));

        private static void KindPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                ((PathIconModern)dependencyObject).UpdateData();
            }
        }

        /// <summary>
        /// Gets or sets the icon to display.
        /// </summary>
        public PackIconModernKind Kind
        {
            get { return (PackIconModernKind)GetValue(KindProperty); }
            set { SetValue(KindProperty, value); }
        }

        public PathIconModern()
        {
            if (_dataIndex == null)
            {
                _dataIndex = new Lazy<IDictionary<PackIconModernKind, string>>(PackIconModernDataFactory.Create);
            }
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
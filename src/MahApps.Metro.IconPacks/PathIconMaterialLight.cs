﻿using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace MahApps.Metro.IconPacks
{
    /// <summary>
    /// All icons sourced from Material Design Light Icons - <see><cref>https://github.com/Templarian/MaterialDesignLight</cref></see> - in accordance of
    /// <see><cref>https://github.com/Templarian/MaterialDesignLight/blob/master/LICENSE.md</cref></see>.
    /// </summary>
    public class PathIconMaterialLight : PathIconControlBase
    {
        private static Lazy<IDictionary<PackIconMaterialLightKind, string>> _dataIndex;

        public static readonly DependencyProperty KindProperty
            = DependencyProperty.Register(nameof(Kind), typeof(PackIconMaterialLightKind), typeof(PathIconMaterialLight), new PropertyMetadata(default(PackIconMaterialLightKind), KindPropertyChangedCallback));

        private static void KindPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                ((PathIconMaterialLight)dependencyObject).UpdateData();
            }
        }

        /// <summary>
        /// Gets or sets the icon to display.
        /// </summary>
        public PackIconMaterialLightKind Kind
        {
            get { return (PackIconMaterialLightKind)GetValue(KindProperty); }
            set { SetValue(KindProperty, value); }
        }

        public PathIconMaterialLight()
        {
            if (_dataIndex == null)
            {
                _dataIndex = new Lazy<IDictionary<PackIconMaterialLightKind, string>>(PackIconMaterialLightDataFactory.Create);
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
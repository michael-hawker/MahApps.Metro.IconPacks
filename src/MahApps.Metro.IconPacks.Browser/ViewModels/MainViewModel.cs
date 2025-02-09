﻿using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Input;
using System.Windows.Threading;

namespace MahApps.Metro.IconPacks.Browser.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Dispatcher _dispatcher;
        private string _filterText;

        public MainViewModel(Dispatcher dispatcher)
        {
            this._dispatcher = dispatcher;
            this.AppVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.IconPacks = new ObservableCollection<IconPackViewModel>(
                new[]
                {
                    new IconPackViewModel(this, "BoxIcons", typeof(PackIconBoxIconsKind), typeof(PackIconBoxIcons)),
                    new IconPackViewModel(this, "Entypo+", typeof(PackIconEntypoKind), typeof(PackIconEntypo)),
                    new IconPackViewModel(this, "EvaIcons", typeof(PackIconEvaIconsKind), typeof(PackIconEvaIcons)),
                    new IconPackViewModel(this, "FeatherIcons", typeof(PackIconFeatherIconsKind), typeof(PackIconFeatherIcons)),
                    new IconPackViewModel(this, "FontAwesome", typeof(PackIconFontAwesomeKind), typeof(PackIconFontAwesome)),
                    new IconPackViewModel(this, "Ionicons", typeof(PackIconIoniconsKind), typeof(PackIconIonicons)),
                    new IconPackViewModel(this, "JamIcons", typeof(PackIconJamIconsKind), typeof(PackIconJamIcons)),
                    new IconPackViewModel(this, "Material", typeof(PackIconMaterialKind), typeof(PackIconMaterial)),
                    new IconPackViewModel(this, "MaterialDesign (Google)", typeof(PackIconMaterialDesignKind), typeof(PackIconMaterialDesign)),
                    new IconPackViewModel(this, "MaterialLight", typeof(PackIconMaterialLightKind), typeof(PackIconMaterialLight)),
                    new IconPackViewModel(this, "Modern", typeof(PackIconModernKind), typeof(PackIconModern)),
                    new IconPackViewModel(this, "Octicons", typeof(PackIconOcticonsKind), typeof(PackIconOcticons)),
                    new IconPackViewModel(this, "PICOL", typeof(PackIconPicolIconsKind), typeof(PackIconPicolIcons)),
                    new IconPackViewModel(this, "RPGAwesome", typeof(PackIconRPGAwesomeKind), typeof(PackIconRPGAwesome)),
                    new IconPackViewModel(this, "SimpleIcons", typeof(PackIconSimpleIconsKind), typeof(PackIconSimpleIcons)),
                    new IconPackViewModel(this, "Typicons", typeof(PackIconTypiconsKind), typeof(PackIconTypicons)),
                    new IconPackViewModel(this, "Unicons", typeof(PackIconUniconsKind), typeof(PackIconUnicons)),
                    new IconPackViewModel(this, "WeatherIcons", typeof(PackIconWeatherIconsKind), typeof(PackIconWeatherIcons)),
                    new IconPackViewModel(this, "Zondicons", typeof(PackIconZondiconsKind), typeof(PackIconZondicons)),
                    new IconPackViewModel(this, "All",
                        new[]
                        {
                            typeof(PackIconBoxIconsKind),
                            typeof(PackIconEntypoKind),
                            typeof(PackIconEvaIconsKind),
                            typeof(PackIconFeatherIconsKind),
                            typeof(PackIconFontAwesomeKind),
                            typeof(PackIconIoniconsKind),
                            typeof(PackIconJamIconsKind),
                            typeof(PackIconMaterialKind),
                            typeof(PackIconMaterialDesignKind),
                            typeof(PackIconMaterialLightKind),
                            typeof(PackIconModernKind),
                            typeof(PackIconOcticonsKind),
                            typeof(PackIconPicolIconsKind),
                            typeof(PackIconRPGAwesomeKind),
                            typeof(PackIconSimpleIconsKind),
                            typeof(PackIconTypiconsKind),
                            typeof(PackIconUniconsKind),
                            typeof(PackIconWeatherIconsKind),
                            typeof(PackIconZondiconsKind)
                        },
                        new[]
                        {
                            typeof(PackIconBoxIcons),
                            typeof(PackIconEntypo),
                            typeof(PackIconEvaIcons),
                            typeof(PackIconFeatherIcons),
                            typeof(PackIconFontAwesome),
                            typeof(PackIconIonicons),
                            typeof(PackIconJamIcons),
                            typeof(PackIconMaterial),
                            typeof(PackIconMaterialDesign),
                            typeof(PackIconMaterialLight),
                            typeof(PackIconModern),
                            typeof(PackIconOcticons),
                            typeof(PackIconPicolIcons),
                            typeof(PackIconRPGAwesome),
                            typeof(PackIconSimpleIcons),
                            typeof(PackIconTypicons),
                            typeof(PackIconUnicons),
                            typeof(PackIconWeatherIcons),
                            typeof(PackIconZondicons)
                        })
                });
            this.IconPacksVersion = Assembly.GetAssembly(typeof(PackIconMaterial)).GetName().Version.ToString();
            this.GoToGitHubCommand =
                new SimpleCommand
                {
                    CanExecuteDelegate = x => true,
                    ExecuteDelegate = x => System.Diagnostics.Process.Start("https://github.com/MahApps/MahApps.Metro.IconPacks")
                };
        }

        public ObservableCollection<IconPackViewModel> IconPacks { get; set; }

        public string AppVersion { get; }

        public string IconPacksVersion { get; }

        public ICommand GoToGitHubCommand { get; }

        public string FilterText
        {
            get { return _filterText; }
            set
            {
                if (Set(ref _filterText, value))
                {
                    foreach (var iconPack in this.IconPacks)
                    {
                        this._dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => iconPack.FilterText = value));
                    }
                }
            }
        }
    }
}
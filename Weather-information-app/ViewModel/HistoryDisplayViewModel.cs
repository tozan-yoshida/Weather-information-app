using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Weather_information_app.Data;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Weather_information_app.Pages;


namespace Weather_information_app.ViewModel
{
    public partial class HistoryDisplayViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<WeatherInformationForDB> _forDBs;

        [ObservableProperty]
        public bool _isRefreshing = false;
        [ObservableProperty]
        public bool _isBusy = false;

        [ObservableProperty]
        WeatherInformationForDB? _selectedData;

        public HistoryDisplayViewModel()
        {
            _forDBs = new ObservableCollection<WeatherInformationForDB>();

            WeakReferenceMessenger.Default.Register<ValueChangedMessage<bool>>(this, async (r, m) =>
            {
                await LoadData();
            });

            Task.Run(LoadData);
        }

        [RelayCommand]
        public async Task WeatherInformationSelected()
        {
            if(SelectedData == null)
            {
                return;
            }

            var navigationParameter = new Dictionary<string, object>()
            {
                {"WeatherInformationData", SelectedData }
            };

            await Shell.Current.GoToAsync("weatherInformationPage", navigationParameter);
            MainThread.BeginInvokeOnMainThread(() => SelectedData = null);
        }

        [RelayCommand]
        public async Task LoadData()
        {
            if (IsBusy)
                return;
            try
            {
                IsRefreshing = true;
                IsBusy = true;

                var weatherInformationDataCollection = await App.localDBService!.GetWeatherInformations();

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    ForDBs.Clear();

                    foreach (WeatherInformationForDB weatherInformation in weatherInformationDataCollection)
                    {
                        ForDBs.Add(weatherInformation);
                    }
                });
            }
            finally
            {
                IsRefreshing = false;
                IsBusy = false;
            }
        }
    }
}

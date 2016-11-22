﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Robotics.Mobile.BtLEExplorer;
using Robotics.Mobile.Core.Bluetooth.LE;
using Xamarin.Forms;

namespace EntMob_Xamarin
{
	public partial class DevicePage : ContentPage
	{

		IAdapter adapter;
		ObservableCollection<IDevice> devices;

		public DevicePage(IAdapter adapter)
		{
			InitializeComponent();
			this.adapter = adapter;
			this.devices = new ObservableCollection<IDevice>();
			listView.ItemsSource = devices;

			adapter.DeviceDiscovered += (object sender, DeviceDiscoveredEventArgs e) =>
			{
				Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
				{
					devices.Add(e.Device);
				});
			};

			adapter.ScanTimeoutElapsed += (sender, e) =>
			{
				adapter.StopScanningForDevices(); // not sure why it doesn't stop already, if the timeout elapses... or is this a fake timeout we made?
				Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
				{
					DisplayAlert("Timeout", "Bluetooth scan timeout elapsed", "OK", "");
				});
			};

			ScanAllButton.Activated += (sender, e) =>
			{
                try
                {
                    var status = await CrossPermissions.Current.CheckPermissionStatus(Permission.Location);
                    if (status != PermissionStatus.Granted)
                    {
                        if (await CrossPermissions.Current.ShouldShowRequestPermissionRationale(Permission.Location))
                        {
                            await DisplayAlert("Need location", "Gunna need that location", "OK");
                        }

                        var results = await CrossPermissions.Current.RequestPermissions(new[] { Permission.Location });
                        status = results[Permission.Location];
                    }

                    if (status == PermissionStatus.Granted)
                    {
                        var results = await CrossGeolocator.Current.GetPositionAsync(10000);
                        LabelGeolocation.Text = "Lat: " + results.Latitude + " Long: " + results.Longitude;
                        StartScanning();
                    }
                    else if (status != PermissionStatus.Unknown)
                    {
                        await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
                    }
                }
                catch (Exception ex)
                {

                    LabelGeolocation.Text = "Error: " + ex;
                }
			};

		}

		public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (((ListView)sender).SelectedItem == null)
			{
				return;
			}
			Debug.WriteLine(" xxxxxxxxxxxx  OnItemSelected " + e.SelectedItem.ToString());
			StopScanning();

			var device = e.SelectedItem as IDevice;
			var servicePage = new ServiceList(adapter, device);
			// load services on the next page
			Navigation.PushAsync(servicePage);

			((ListView)sender).SelectedItem = null; // clear selection
		}

		void StartScanning()
		{
			StartScanning(Guid.Empty);
		}
		void StartScanning(Guid forService)
		{
			if (adapter.IsScanning)
			{
				adapter.StopScanningForDevices();
				Debug.WriteLine("adapter.StopScanningForDevices()");
			}
			else
			{
				devices.Clear();
				adapter.StartScanningForDevices(forService);
				Debug.WriteLine("adapter.StartScanningForDevices(" + forService + ")");
			}
		}

		void StopScanning()
		{
			// stop scanning
			new Task(() =>
			{
				if (adapter.IsScanning)
				{
					Debug.WriteLine("Still scanning, stopping the scan");
					adapter.StopScanningForDevices();
				}
			}).Start();
		}
	}

}
using Android.Content.Res;
using Robotics.Mobile.BtLEExplorer;
using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using System.Windows.Input;

namespace EntMob_Xamarin
{
    public class DeviceViewModel
    {
        IAdapter adapter;
        static IAdapter Adapter;
        ObservableCollection<IDevice> devices;
        public ICommand LoadDevices { get; set; }
        public ICommand GetSelectedItem { get; set; }
        INavigation navigation;
        IDevice MySelectedDevice;


        public DeviceViewModel()
        {
            var a = new Robotics.Mobile.Core.Bluetooth.LE.Adapter();
            //SetAdapter(a);

            this.devices = new ObservableCollection<IDevice>();

            adapter.DeviceDiscovered += (object sender, DeviceDiscoveredEventArgs e) => {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => {
                    devices.Add(e.Device);
                });
            };

            adapter.ScanTimeoutElapsed += (sender, e) => {
                adapter.StopScanningForDevices(); // not sure why it doesn't stop already, if the timeout elapses... or is this a fake timeout we made?
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => {
                    //     DisplayAlert("Timeout", "Bluetooth scan timeout elapsed", "OK", "");
                });
            };

            /*         ScanAllButton.Activated += (sender, e) => {
                         StartScanning();
                     };

                     ScanHrmButton.Activated += (sender, e) => {
                         StartScanning(0x180D.UuidFromPartial());
                     };*/
        }

        public static void SetAdapter(IAdapter adapter)
        {
            Adapter = adapter;
        }

        public DeviceViewModel(INavigation navigation)
        {
            LoadCommands();
            this.navigation = navigation;
        }

        private void LoadCommands()
        {
            Debug.WriteLine("loading commands");
            LoadDevices = new Command(
            (parameter) =>
            {
                    StartScanning();
            });

            GetSelectedItem = new Command((obj) =>
            {

                if (MySelectedDevice == null)
                {
                    return;
                }
                StopScanning();
                navigation.PushAsync(new TimerPage());

            });
        }



        public void StartScanning()
        {
            StartScanning(Guid.Empty);
        }

        public void StartScanning(Guid forService)
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

        public void StopScanning()
        {
            // stop scanning
            new Task(() => {
                if (adapter.IsScanning)
                {
                    Debug.WriteLine("Still scanning, stopping the scan");
                    adapter.StopScanningForDevices();
                }
            }).Start();
        }
    }
}



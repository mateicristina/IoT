// Copyright (c) Microsoft. All rights reserved.

using System;
using Windows.Devices.Gpio;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using System.Data;



namespace Blinky
{
    public sealed partial class MainPage : Page
    {
        private const int LED_PIN1 = 5;
        private const int LED_PIN2 = 13;
        private const int LED_PIN3 = 26;
        private GpioPin pin1,pin2,pin3;
        private GpioPinValue pinValue;
        private DispatcherTimer timer;
        private SolidColorBrush redBrush = new SolidColorBrush(Windows.UI.Colors.Red);
        private SolidColorBrush grayBrush = new SolidColorBrush(Windows.UI.Colors.LightGray);

  

        public MainPage()
        {
            InitializeComponent();
            
            //timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromMilliseconds(500);
            //timer.Tick += Timer_Tick;
            InitGPIO();
            AzureIoTHub.ReceiveCloudToDeviceMessageAsync(this);
        }

        private void InitGPIO()
        {
      var gpio1 = GpioController.GetDefault();
      var gpio2 = GpioController.GetDefault();
      var gpio3 = GpioController.GetDefault();
      // Show an error if there is no GPIO controller
      if (gpio1 == null)
      {
          pin1 = null;
          GpioStatus.Text = "There is no GPIO1 controller on this device.";
          return;
      }
      if (gpio2 == null)
      {
        pin2 = null;
        GpioStatus1.Text = "There is no GPIO3 controller on this device.";
        return;
      }
      if (gpio3 == null)
      {
        pin3 = null;
        GpioStatus2.Text = "There is no GPIO3 controller on this device.";
        return;
      }
      pin1 = gpio1.OpenPin(LED_PIN1);
      pin2 = gpio2.OpenPin(LED_PIN2);
      pin3 = gpio3.OpenPin(LED_PIN3);

     
      pin1.Write(GpioPinValue.High);
      pin1.SetDriveMode(GpioPinDriveMode.Output);
      pin2.Write(GpioPinValue.High);
      pin2.SetDriveMode(GpioPinDriveMode.Output);
      pin3.Write(GpioPinValue.High);
      pin3.SetDriveMode(GpioPinDriveMode.Output);

      GpioStatus.Text = "GPIO 1 pin initialized correctly.";
      GpioStatus1.Text = "GPIO 2 pin initialized correctly.";
      GpioStatus2.Text = "GPIO 3 pin initialized correctly.";


    }

   

    public void Aprinde (object sender, object e, int nr)
    {
      pinValue = GpioPinValue.Low;
      switch (nr) {
        case 1:
          pin1.Write(pinValue);
          LED.Fill = redBrush;
          wallet.Visibility = Visibility.Visible;
          break;
        case 2:
          pin2.Write(pinValue);
          LED1.Fill = redBrush;
          keys.Visibility = Visibility.Visible;
          break;
        case 3:
          pin3.Write(pinValue);
          LED2.Fill = redBrush;
          ceas.Visibility= Visibility.Visible;
          break;
      }
    }

    public void Stinge (object sender, object e)
    {
      pinValue = GpioPinValue.High;
      pin1.Write(pinValue);
      pin2.Write(pinValue);
      pin3.Write(pinValue);
      ceas.Visibility = Visibility.Collapsed;
      wallet.Visibility = Visibility.Collapsed;
      keys.Visibility = Visibility.Collapsed;
      LED.Fill = grayBrush;
      LED1.Fill = grayBrush;
      LED2.Fill = grayBrush;

    }


  }
}

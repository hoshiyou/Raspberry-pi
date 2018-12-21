using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Gpio;
//添加gpio的定義

// 空白頁項目範本已記錄在 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x404

namespace First_LED_Test
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private bool led_status;
        private GpioPin pin5;

        public MainPage()
        {
            this.InitializeComponent();
            //初始化元件
            
            GpioController gpio = GpioController.GetDefault();
            //初始化IoT函數
            pin5 = gpio.OpenPin(5);
            //指定pin5
            pin5.SetDriveMode(GpioPinDriveMode.Output);
            //設定接腳以數位輸出
            pin5.Write(GpioPinValue.High);
            //設定pin5以高電位輸出
            
        }

        //當按鈕被按下時會觸發的事件
        //當按鈕被按下會顯示"Hello,Welcome IoT Core!"
        private void ClickMe_Click(object sender,RoutedEventArgs e)
        {
            this.HelloMessage.Text = "Hello,Welcome IoT Core!";
        }

        //當按鈕按下會觸發事件
        private void LED_Status_S(object sender,RoutedEventArgs e)
        {
            if(led_status == true)
            {
                this.HelloMessage.Text = "LED on";
                pin5.Write(GpioPinValue.High);
            }
            else
            {
                this.HelloMessage.Text = "LED off";
                pin5.Write(GpioPinValue.Low);
            }
            led_status = !led_status;
        }

       
    }
}

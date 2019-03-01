using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Blinky;

static class AzureIoTHub
{
    //
    // Note: this connection string is specific to the device "RasberryPi3". To configure other devices,
    // see information on iothub-explorer at http://aka.ms/iothubgetstartedVSCS
    //
    const string deviceConnectionString = "___IoT-Hub-key___";

    //
    // To monitor messages sent to device "RasberryPi3" use iothub-explorer as follows:
    //    iothub-explorer HostName=ITeam.azure-devices.net;SharedAccessKeyName=service;SharedAccessKey=ILK3NTqKB4JrF8P03ayPJm7rvcz99qu2l72ZRcJc+ks= monitor-events "RasberryPi3"
    //

    // Refer to http://aka.ms/azure-iot-hub-vs-cs-wiki for more information on Connected Service for Azure IoT Hub

    public static async Task SendDeviceToCloudMessageAsync()
    {
        var deviceClient = DeviceClient.CreateFromConnectionString(deviceConnectionString, TransportType.Http1);

        var str = "Hello, Cloud!";
        var message = new Message(Encoding.ASCII.GetBytes(str));

        await deviceClient.SendEventAsync(message);
    }

    public static async Task<string> ReceiveCloudToDeviceMessageAsync(MainPage Page)
    {
        var deviceClient = DeviceClient.CreateFromConnectionString(deviceConnectionString, TransportType.Http1);

        while (true)
        {
            var receivedMessage = await deviceClient.ReceiveAsync();

            if (receivedMessage != null)
            {
                var messageData = Encoding.ASCII.GetString(receivedMessage.GetBytes());
                await deviceClient.CompleteAsync(receivedMessage);
        //return messageData;
        switch (messageData) {
          case "0":
            Page.Stinge(null, null);
            break;
          case "1":
            Page.Stinge(null, null);
            Page.Aprinde(null, null, 1);
            break;
          case "2":
            Page.Stinge(null, null);
            Page.Aprinde(null, null, 2);
            break;
          case "3":
            Page.Stinge(null, null);
            Page.Aprinde(null, null, 3);
            break;
        }
      }


    //  Note: In this sample, the polling interval is set to 
    //  10 seconds to enable you to see messages as they are sent.
    //  To enable an IoT solution to scale, you should extend this 
    //  interval. For example, to scale to 1 million devices, set 
    //  the polling interval to 25 minutes.
    //  For further information, see
    //  https://azure.microsoft.com/documentation/articles/iot-hub-devguide/#messaging
    await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }
}

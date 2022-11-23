using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace BlazorSignaRTutorial.Data
{
    public class MyTestProcess
    {
        private HubConnection _hubConnection;
        private bool open;

        public MyTestProcess()
        {
        }


        public async Task<MyTestProcess> Start(string url)
        {
            _hubConnection = new HubConnectionBuilder().WithUrl(url).Build();

            await _hubConnection.StartAsync();
            open = true;
            return this;
        }

        public async Task SendAsync(int num)
        {
            if (open)
            {
                await _hubConnection.SendAsync("SendMessage", "ControllerProcess", $"I am a Bot! and this is my Number {num}");
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

    }
}

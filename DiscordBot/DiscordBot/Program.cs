﻿using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;


namespace DiscordBot
{
    public class Program
    {
        public static Task Main(string[] args) => new Program().MainAsync();

        private DiscordSocketClient _client;

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();

            _client.Log += Log;
            
            var token = System.IO.File.ReadAllText("../../../token.txt");

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }
        
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}

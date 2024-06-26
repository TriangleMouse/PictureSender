﻿using Microsoft.Extensions.DependencyInjection;
using PictureSender.Client.Pages;
using PictureSender.Client.ViewModels;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System.Windows;

namespace Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<MainWindow>()
                .AddScoped<MainPage>()
                .AddScoped<MainPageViewModel>()
                .AddTransient<DetailPage>()
                .AddTransient<DetailPageViewModel>()
                .AddSerilog(GetConfiguredLogger())
                .BuildServiceProvider();

            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        /// <summary>
        /// Конфигурирует Serilog
        /// </summary>
        /// <returns>Конфигурация логера</returns>
        private static Logger GetConfiguredLogger()
        {
            var logPath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "\\Logs\\log.log");
            var logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Logger(config =>
                    config.Filter.ByIncludingOnly(logEvent =>
                        logEvent.Level == LogEventLevel.Information ||
                        logEvent.Level == LogEventLevel.Error ||
                        logEvent.Level == LogEventLevel.Warning ||
                        logEvent.Level == LogEventLevel.Verbose
                    ).WriteTo.File(logPath, rollingInterval: RollingInterval.Day)
                ).CreateLogger();

            Log.Logger = logger;
            return logger;
        }
    }
}

﻿using DocumentFormat.OpenXml.Bibliography;
using IDC.App.ProjectManagement;
using IDC.App.ProjectManagement.ViewModels;
using IDC.App.ViewModels;
using IDC.App.Views;
using IDC.Services.Implements;
using IDC.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace IDC.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary> 
    public partial class App : Application
    {
        public App()
        {
            ConfigureServices();
        }
        public void ConfigureServices()
        {
            var svc = new ServiceCollection();
            svc.AddTransient<MainWindow>();
            svc.AddTransient<MainVM>()
               .AddTransient<ModificationDetailVM>();
            svc.AddScoped<IExcelServices, ExcelServices>();
            svc.AddSingleton<IProjectRepository, ProjectRepository>();
            svc.AddSingleton<IRuleRepository, IniRuleRepository>();
            svc.AddSingleton<ProjectSettingController>();

            this.Properties["serviceProvider"] = svc.BuildServiceProvider();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var _serviceProvider = (IServiceProvider)this.Properties["serviceProvider"];
            var main_vm = _serviceProvider.GetService<MainVM>();
            var excelSvc = _serviceProvider.GetRequiredService<IExcelServices>();
            MainWindow mainWindow = new MainWindow() { DataContext = main_vm };
            mainWindow.Show();
        }
    }
}

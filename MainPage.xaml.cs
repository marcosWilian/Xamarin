using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ConectandoServicoRest.Model;
using ConectandoServicoRest.Servico;
using Xamarin.Forms;

namespace ConectandoServicoRest
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {


        TarefasServico datasService;
        private List<Tarefas> tarefas { get; set; }

        public MainPage()
        {
            InitializeComponent();
            datasService = new TarefasServico();
            GetTask();
        }


        async void GetTask()
        {
            tarefas = await datasService.GetTarefasAsync();
            ListaDeTarefas.ItemsSource = tarefas.OrderBy(id => id.Id).ToList();

        }
    }
}

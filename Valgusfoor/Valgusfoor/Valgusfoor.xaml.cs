using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Valgusfoor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Valgusfoor : ContentPage
    {
        private bool ButtonSisseClicked = false; 
        private bool ButtonVäljaClicked = false; 

        public Valgusfoor()
        {
            InitializeComponent();

            punaneFrame.BackgroundColor = Color.Gray;
            kollaneFrame.BackgroundColor = Color.Gray;
            rohelineFrame.BackgroundColor = Color.Gray;

            punaneFrame.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    if (!ButtonSisseClicked)
                    {
                        DisplayAlert("Error", "First, turn on the light", "Ok");
                        return;
                    }
                    punaneFrame.BackgroundColor = Color.Red;
                    punaneLabel.Text = "Stop";
                    punaneLabel.FontSize = 20;
                    punaneLabel.TextColor = Color.Black;
                })
            });

            kollaneFrame.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    if (!ButtonSisseClicked)
                    {
                        DisplayAlert("Error", "First, turn on the light", "Ok");
                        return;
                    }
                    kollaneFrame.BackgroundColor = Color.Yellow;
                    kollaneLabel.Text = "Wait";
                    kollaneLabel.FontSize = 20;
                    kollaneLabel.TextColor = Color.Black;
                })
            });

            rohelineFrame.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    if (!ButtonSisseClicked)
                    {
                        DisplayAlert("Error", "First, turn on the traffic light", "Ok");
                        return;
                    }
                    rohelineFrame.BackgroundColor = Color.Green;
                    rohelineLabel.Text = "Drive";
                    rohelineLabel.FontSize = 20;
                    rohelineLabel.TextColor = Color.Black;
                })
            });

            ButtonSisse.Clicked += OnButtonSisseClicked;

            ButtonVälja.Clicked += OnButtonVäljaClicked;

            ButtonTagasi.Clicked += OnButtonTagasiClicked;
        }

        private async void OnButtonTagasiClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void OnButtonSisseClicked(object sender, EventArgs e)
        {
            ButtonSisseClicked = true;

            punaneFrame.BackgroundColor = Color.Red;
            kollaneFrame.BackgroundColor = Color.Yellow;
            rohelineFrame.BackgroundColor = Color.Green;
        }

        private void OnButtonVäljaClicked(object sender, EventArgs e)
        {
            ButtonVäljaClicked = true;

            Device.BeginInvokeOnMainThread(async () =>
            {
                bool answer = await DisplayAlert("Turning off the light", "Would you like to turn off the traffic light?", "yes", "no");

                if (answer == true)
                {
                    ButtonSisseClicked = false;

                    ButtonSisse.BackgroundColor = Color.Gray;

                    punaneFrame.BackgroundColor = Color.Gray;
                    kollaneFrame.BackgroundColor = Color.Gray;
                    rohelineFrame.BackgroundColor = Color.Gray;

                    punaneLabel.Text = "red";
                    punaneLabel.FontSize = 20;
                    kollaneLabel.Text = "yellow";
                    kollaneLabel.FontSize = 20;
                    rohelineLabel.Text = "green";
                    rohelineLabel.FontSize = 20;

                    lbl3.Text = "Turn on the traffic lights";
                }
                else
                {
                    ButtonVäljaClicked = false;
                    ButtonSisseClicked = true;

                }
            });
        }
    }
}
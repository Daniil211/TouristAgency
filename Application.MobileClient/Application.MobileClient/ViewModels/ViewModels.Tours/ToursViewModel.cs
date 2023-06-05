using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Application.MobileClient.Models;
using Application.MobileClient.Services;
using Application.MobileClient.Services.Services.Tour;
using Application.MobileClient.Views;
using Application.MobileClient.Views.Views.Tours;

namespace Application.MobileClient.ViewModels.ViewModels.Tours
{
    public class ToursViewModel : BaseViewModel
    {
        private ObservableCollection<Tour> tours;
        private Tour selectedTour;
        private readonly ITourService _tourService;

        public ToursViewModel(ITourService tourService)
        {
            _tourService = tourService;

            Tours = new ObservableCollection<Tour>();

            DeleteTourCommand = new Command<Tour>(async b => await DeleteTour(b));

            AddNewTourCommand = new Command(async () => await GoToAddtourView());
        }

        private async Task DeleteTour(Tour b)
        {
            await _tourService.DeleteTour(b);

            PopulateTours();
        }

        private async Task GoToAddtourView() 
            => await Shell.Current.GoToAsync(nameof(AddTour));

        public async void PopulateTours()
        {
            try
            {
                Tours.Clear();

                var tours = await _tourService.GetTours();
                foreach (var tour in tours)
                {
                    Tours.Add(tour);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        async void OnTourSelected(Tour tour)
        {
            if (tour == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(TourDetails)}?{nameof(TourDetailsViewModel.TourId)}={tour.TourId}");
        }

        public ObservableCollection<Tour> Tours
        {
            get => tours;
            set
            {
                tours = value;
                OnPropertyChanged(nameof(Tours));
            }
        }

        public Tour SelectedTour
        {
            get => selectedTour;
            set
            {
                if(selectedTour != value)
                {
                    selectedTour = value;

                    OnTourSelected(SelectedTour);
                }
            }
        }

        public ICommand DeleteTourCommand { get; }

        public ICommand AddNewTourCommand { get; }
    }
}

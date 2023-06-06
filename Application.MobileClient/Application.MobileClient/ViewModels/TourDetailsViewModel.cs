using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Application.MobileClient.Models;
using Xamarin.Forms;
using Application.MobileClient.Services;
using System.IO;


namespace Application.MobileClient.ViewModels
{
    [QueryProperty(nameof(TourId), nameof(TourId))]
    public class TourDetailsViewModel : BaseViewModel
    {
        private string id;
        private string namet;
        private string duration;
        private decimal price;
        private string videot;
        private bool sale;
        private string image;
        private DateTime? time;
        private string description;
        private readonly ITourService _tourService;

        public TourDetailsViewModel(ITourService tourService)
        {
            _tourService = tourService;

            SaveTourCommand = new Command(async () => await SaveTour());
        }

        private async Task SaveTour()
        {
            try
            {
                var tour = new Tour
                {
                    TourId = int.Parse(TourId),
                    TourName = TourName,
                    Duration = Duration,
                    Price = Price,
                    VideoTour = VideoTour,
                    InSale = InSale,
                    Image = Image,
                    Time = Time,
                    Description = Description
                };

                await _tourService.SaveTour(tour);

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void LoadTour(string tourId)
        {
            try
            {
                var tour = await _tourService.GetTour(int.Parse(tourId));
                if (tourId != null)
                {
                    TourName = tour.TourName;
                    Duration = tour.Duration;
                    Price = tour.Price;
                    VideoTour = tour.VideoTour;
                    InSale = tour.InSale;
                    Image = tour.Image;
                    Time = tour.Time;
                    Description = tour.Description;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public string TourId
        {
            get => id;
            set
            {
                id = value;
                LoadTour(TourId);
            }
        }
        public string TourName
        {
            get => namet;
            set
            {
                namet = value;
                OnPropertyChanged(nameof(TourName));
            }
        }
        public string Duration
        {
            get => duration;
            set
            {
                duration = value;
                OnPropertyChanged(nameof(Duration));
            }
        }
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public string Image
        {
            get => image;
            set
            {
                image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
        public DateTime? Time
        {
            get => time;
            set
            {
                time = value;
                OnPropertyChanged(nameof(Time));
            }
        }
        public bool InSale
        {
            get => sale;
            set
            {
                sale = value;
                OnPropertyChanged(nameof(InSale));
            }
        }
        public string VideoTour
        {
            get => videot;
            set
            {
                videot = value;
                OnPropertyChanged(nameof(VideoTour));
            }
        }
        public decimal Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public ICommand SaveTourCommand { get; }
    }
}

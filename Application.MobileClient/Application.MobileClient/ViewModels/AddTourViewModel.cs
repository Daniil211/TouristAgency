using Application.MobileClient.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Application.MobileClient.ViewModels
{
    public class AddTourViewModel : BaseViewModel
    {
        private readonly ITourService _tourService;
        private string name;
        private string duration;
        private decimal price;
        private string video;
        private bool sale;
        private string image;
        private DateTime? time;
        private string description;
        public AddTourViewModel(ITourService tourService)
        {
            _tourService = tourService;

            SaveTourCommand = new Command(async () => await SaveTour());
        }

        private async Task SaveTour()
        {
            try
            {
                var tour = new Models.Tour
                {
                    TourName = TourName,
                    Duration = Duration,
                    Price = Price,
                    VideoTour = VideoTour,
                    InSale = InSale,
                    Image = Image,
                    Time = Time,
                    Description = Description
                };

                await _tourService.AddTour(tour);

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string TourName
        {
            get => name;
            set
            {
                name = value;
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
            get => video;
            set
            {
                video = value;
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

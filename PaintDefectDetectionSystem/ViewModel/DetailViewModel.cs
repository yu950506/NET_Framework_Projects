using PaintDefectDetectionSystem.Model;
using System.Collections.ObjectModel;

namespace PaintDefectDetectionSystem.ViewModel
{
    internal class DetailViewModel : ObservableObject
    {
        private string imageUri;

        public string ImageUri
        {
            get => "pack://application:,,,/Images/body_no/1101/" + imageUri + ".jpg";
            set
            {
                //if (value == imageUri)
                //    return;
                //imageUri = value ?? throw new ArgumentNullException(nameof(value));
                imageUri = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<RectangleModel> rectangleModels;

        public ObservableCollection<RectangleModel> RectangleModels
        {
            get
            {
                return rectangleModels;
            }
            set
            {
                rectangleModels = value;
                OnPropertyChanged();
            }
        }

        public DetailViewModel()
        {
            // RectangleModels = new ObservableCollection<RectangleModel>();
        }
    }
}
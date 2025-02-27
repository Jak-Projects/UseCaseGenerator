// ViewModel/MainViewModel.cs
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UseCaseGenerator.Model;

namespace UseCaseGenerator.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private UseCase _useCase;
        private string _narrativePreview;

        public MainViewModel()
        {
            _useCase = new UseCase(); // setting UseCase dynamics below
            _useCase.PropertyChanged += UseCase_PropertyChanged; 
            UpdateNarrativePreview();
        }

        private void UseCase_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateNarrativePreview();
        }

        public UseCase UseCase
        {
            get => _useCase;
            set
            {
                if (_useCase != value)
                {
                    _useCase = value;
                    OnPropertyChanged();
                    UpdateNarrativePreview();
                }
            }
        }

        public string NarrativePreview
        {
            get => _narrativePreview;
            set
            {
                if (_narrativePreview != value)
                {
                    _narrativePreview = value;
                    OnPropertyChanged();
                }
            }
        }

        private void UpdateNarrativePreview()
        {
            NarrativePreview = _useCase?.GenerateNarrative() ?? "No data available";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
// Model/UseCase.cs
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UseCaseGenerator.Model
{
    public class UseCase : INotifyPropertyChanged, IDataErrorInfo // Extra Idata
    {
        private string _idTitle;
        private string _intent;
        private string _scopeLevel;
        private string _authorLastUpdate;
        private string _status;
        private string _primaryActors;
        private string _secondaryActors;
        private string _preconditions;
        private string _dynamicPreconditions;
        private string _assumptions;
        private string _successPostCondition;
        private string _failureCondition;
        private string _trigger;
        private string _operations;
        private string _operationsConcepts;

        public string IdTitle { get => _idTitle; set { _idTitle = value; OnPropertyChanged(); } }
        public string Intent { get => _intent; set { _intent = value; OnPropertyChanged(); } }
        public string ScopeLevel { get => _scopeLevel; set { _scopeLevel = value; OnPropertyChanged(); } }
        public string AuthorLastUpdate { get => _authorLastUpdate; set { _authorLastUpdate = value; OnPropertyChanged(); } }
        public string Status { get => _status; set { _status = value; OnPropertyChanged(); } }
        public string PrimaryActors { get => _primaryActors; set { _primaryActors = value; OnPropertyChanged(); } }
        public string SecondaryActors { get => _secondaryActors; set { _secondaryActors = value; OnPropertyChanged(); } }
        public string Preconditions { get => _preconditions; set { _preconditions = value; OnPropertyChanged(); } }
        public string DynamicPreconditions { get => _dynamicPreconditions; set { _dynamicPreconditions = value; OnPropertyChanged(); } }
        public string Assumptions { get => _assumptions; set { _assumptions = value; OnPropertyChanged(); } }
        public string SuccessPostCondition { get => _successPostCondition; set { _successPostCondition = value; OnPropertyChanged(); } }
        public string FailureCondition { get => _failureCondition; set { _failureCondition = value; OnPropertyChanged(); } }
        public string Trigger { get => _trigger; set { _trigger = value; OnPropertyChanged(); } }
        public string Operations { get => _operations; set { _operations = value; OnPropertyChanged(); } }
        public string OperationsConcepts { get => _operationsConcepts; set { _operationsConcepts = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string GenerateNarrative()
        {
            return $"Use Case: {IdTitle}\n\n" +
                   $"Intent: {Intent}\n" +
                   $"Scope & Level: {ScopeLevel}\n" +
                   $"Author & Last Update: {AuthorLastUpdate}\n" +
                   $"Status: {Status}\n" +
                   $"Primary Actors: {PrimaryActors}\n" +
                   $"Secondary Actors: {SecondaryActors}\n" +
                   $"Preconditions: {Preconditions}\n" +
                   $"Dynamic Preconditions: {DynamicPreconditions}\n" +
                   $"Assumptions: {Assumptions}\n" +
                   $"Success Post Condition: {SuccessPostCondition}\n" +
                   $"Failure Condition: {FailureCondition}\n" +
                   $"Trigger: {Trigger}\n" +
                   $"Operations: {Operations}\n" +
                   $"Operations Concepts: {OperationsConcepts}";
        }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(IdTitle):
                        return string.IsNullOrWhiteSpace(IdTitle) ? "ID & Title cannot be empty" : null;
                    case nameof(Intent):
                        return string.IsNullOrWhiteSpace(Intent) ? "Intent cannot be empty" : null;
                    case nameof(ScopeLevel):
                        return string.IsNullOrWhiteSpace(ScopeLevel) ? "Scope & Level cannot be empty" : null;
                    case nameof(AuthorLastUpdate):
                        return string.IsNullOrWhiteSpace(AuthorLastUpdate) ? "Author & Last Update cannot be empty" : null;
                    case nameof(Status):
                        return string.IsNullOrWhiteSpace(Status) ? "Status cannot be empty" : null;
                    case nameof(PrimaryActors):
                        return string.IsNullOrWhiteSpace(PrimaryActors) ? "Primary Actors cannot be empty" : null;
                    case nameof(SecondaryActors):
                        return string.IsNullOrWhiteSpace(SecondaryActors) ? "Secondary Actors cannot be empty" : null;
                    case nameof(Preconditions):
                        return string.IsNullOrWhiteSpace(Preconditions) ? "Preconditions cannot be empty" : null;
                    case nameof(DynamicPreconditions):
                        return string.IsNullOrWhiteSpace(DynamicPreconditions) ? "Dynamic Preconditions cannot be empty" : null;
                    case nameof(Assumptions):
                        return string.IsNullOrWhiteSpace(Assumptions) ? "Assumptions cannot be empty" : null;
                    case nameof(SuccessPostCondition):
                        return string.IsNullOrWhiteSpace(SuccessPostCondition) ? "Success Post Condition cannot be empty" : null;
                    case nameof(FailureCondition):
                        return string.IsNullOrWhiteSpace(FailureCondition) ? "Failure Condition cannot be empty" : null;
                    case nameof(Trigger):
                        return string.IsNullOrWhiteSpace(Trigger) ? "Trigger cannot be empty" : null;
                    case nameof(Operations):
                        return string.IsNullOrWhiteSpace(Operations) ? "Operations cannot be empty" : null;
                    case nameof(OperationsConcepts):
                        return string.IsNullOrWhiteSpace(OperationsConcepts) ? "Operations Concepts cannot be empty" : null;
                    default:
                        return null;
                }
            }
        }

        public string Error => null; //IDataErrorInfo stoof
    }
}
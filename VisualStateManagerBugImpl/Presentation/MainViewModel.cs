namespace VisualStateManagerBugImpl.Presentation;

public partial class MainViewModel : ObservableObject
{
    private INavigator _navigator;

    [ObservableProperty]
    private string? name;

    [ObservableProperty]
    private bool isMatch;

    public MainViewModel(
        IStringLocalizer localizer,
        IOptions<AppConfig> appInfo,
        INavigator navigator)
    {
        _navigator = navigator;
        Title = "Main";
        Title += $" - {localizer["ApplicationName"]}";
        Title += $" - {appInfo?.Value?.Environment}";
        this.ToggleCommand = new RelayCommand(() => IsMatch = !IsMatch);
    }

    public string? Title { get; }

    public ICommand ToggleCommand { get; }

}

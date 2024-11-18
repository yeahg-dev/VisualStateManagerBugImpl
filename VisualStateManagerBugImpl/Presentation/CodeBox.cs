namespace VisualStateManagerBugImpl.Presentation;

[TemplateVisualState(GroupName = "MatchState", Name = "Unknown")]
[TemplateVisualState(GroupName = "MatchState", Name = "NotMatched")]
[TemplateVisualState(GroupName = "MatchState", Name = "Matched")]
public partial class CodeBox : Control
{
    public static readonly DependencyProperty IsMatchProperty
        = DependencyProperty.Register(nameof(IsMatch), typeof(bool?),
            typeof(CodeBox), new PropertyMetadata(null, OnIsMatchChanged));

    public bool? IsMatch
    {
        get => (bool?)GetValue(IsMatchProperty);
        set => SetValue(IsMatchProperty, value);
    }

    public static readonly DependencyProperty DigitsProperty
    = DependencyProperty.Register(nameof(Digits), typeof(IList<int?>),
        typeof(CodeBox), new PropertyMetadata(new List<int?>(){1,2,3,4}));

    public IList<int?> Digits
    {
        get => (IList<int?>)GetValue(DigitsProperty);
        set => SetValue(DigitsProperty, value);
    }

    #region Callback
    protected override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        UpdateVisualState();
    }

    private static void OnIsMatchChanged(
        DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
    {
        var box = (CodeBox)dependencyObject;
        box.UpdateVisualState();
    }

    #endregion

    private void UpdateVisualState()
    {
        switch (this.IsMatch)
        {
            case true:
                VisualStateManager.GoToState(this, "Matched", true);
                break;

            case false:
                VisualStateManager.GoToState(this, "NotMatched", true);
                break;

            default:
                VisualStateManager.GoToState(this, "Unknown", true);
                break;
        }
    }
}
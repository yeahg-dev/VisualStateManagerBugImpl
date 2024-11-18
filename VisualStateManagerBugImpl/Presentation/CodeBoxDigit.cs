using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace VisualStateManagerBugImpl.Presentation;

[TemplateVisualState(GroupName = "MatchState", Name = "Unknown")]
[TemplateVisualState(GroupName = "MatchState", Name = "NotMatched")]
[TemplateVisualState(GroupName = "MatchState", Name = "Matched")]
public partial class CodeBoxDigit : Control
{
    public static readonly DependencyProperty DigitProperty
            = DependencyProperty.Register(nameof(Digit), typeof(int?),
                typeof(CodeBoxDigit), new PropertyMetadata(null));

    public int? Digit
    {
        get => (int?)GetValue(DigitProperty);
        set => SetValue(DigitProperty, value);
    }

    public static readonly DependencyProperty IsMatchProperty
        = DependencyProperty.Register(nameof(IsMatch), typeof(bool?),
            typeof(CodeBoxDigit), new PropertyMetadata(null, OnIsMatchChanged));

    public bool? IsMatch
    {
        get => (bool?)GetValue(IsMatchProperty);
        set => SetValue(IsMatchProperty, value);
    }

    private static void OnIsMatchChanged(
        DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
    {
        if (dependencyObject is CodeBoxDigit CodeBox)
        {
            CodeBox.UpdateMatchVisualState();
        }
    }

    private void UpdateMatchVisualState()
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

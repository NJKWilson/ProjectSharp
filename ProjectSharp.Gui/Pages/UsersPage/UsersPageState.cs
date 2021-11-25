namespace ProjectSharp.Gui.Pages.UsersPage;

// todo rename to UsersPageState
public class UsersPageState
{
    public bool EditUserFlyoutOpen { get; private set; } = false;
    public bool EditUserFlyoutHidden { get; private set; } = false;
    public event Action? OnChange;
    
    // EditUserFlyout
    public async Task ToggleEditUserFlyout()
    {
        if (EditUserFlyoutHidden)
        {
            EditUserFlyoutOpen = !EditUserFlyoutOpen;
            NotifyStateChanged();
            // Hides element when animation is done so you can click things again
            await Task.Delay(500);
            EditUserFlyoutHidden = !EditUserFlyoutHidden;
            NotifyStateChanged();
        }
        else
        {
            EditUserFlyoutHidden = !EditUserFlyoutHidden;
            NotifyStateChanged();
            // Needs delay for tailwind animation to work (no animation if element is hidden)
            await Task.Delay(10);
            EditUserFlyoutOpen = !EditUserFlyoutOpen;
            NotifyStateChanged();
        }
    }
    
    private void NotifyStateChanged() => OnChange?.Invoke();
}
namespace ProjectSharp.Gui.Core.States.CurrentUser;

public class UsersState
{
    public bool EditUserFlyoutOpen { get; private set; } = false;

    public event Action OnChange;
    
    public void ToggleEditUserFlyout()
    {
        EditUserFlyoutOpen = !EditUserFlyoutOpen;
        NotifyStateChanged();
    }
    
    public void CloseEditUserFlyout()
    {
        EditUserFlyoutOpen = false;
        NotifyStateChanged();
    }
    
    private void NotifyStateChanged() => OnChange?.Invoke();
}
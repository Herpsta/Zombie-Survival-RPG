public interface IPanelManager
{
    void InitializePanel();
    void ShowPanel();
    void UpdatePanel();
    void ApplyChanges();
    void ResetToDefaults();
    void ClosePanel();
    void PopulateDropdown()
    {
        // Default implementation: do nothing
        // Classes that don't need to populate a dropdown can use this default implementation.
    }
}
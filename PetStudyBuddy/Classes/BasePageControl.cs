// BasePageControl.cs - Foundation for all page controls in the application
// This is the base class that all pages will inherit from to implement proper OOP structure

using System;
using System.Windows.Forms;

namespace PetStudyBuddy
{
    // BasePageControl inherits from UserControl - this enables the control to be hosted in the MainForm
    public class BasePageControl : UserControl
    {
        // Reference to the parent MainForm - allows access to navigation and shared state
        protected MainForm? parentForm;

        // Default constructor required for designer
        public BasePageControl()
        {
            // Required empty constructor for the Windows Forms designer
        }

        // Constructor that takes a reference to the parent MainForm
        public BasePageControl(MainForm parent)
        {
            parentForm = parent;
        }

        // --- NAVIGATION METHODS ---

        // Navigate to any page by name
        protected void NavigateTo(string pageName)
        {
            parentForm?.ShowPage(pageName);
        }

        // Convenience methods for common navigation targets
        protected void GoToMainPage() => parentForm?.ShowMainPage();
        protected void GoToProfilePage() => NavigateTo("ProfilePage");
        protected void GoToShopPage() => NavigateTo("ShopPage");
        protected void GoToHistoryPage() => NavigateTo("HistoryPage");
        protected void GoToLoginPage() => NavigateTo("LoginPage");
        protected void GoToRegisterPage() => NavigateTo("RegisterPage");

        // --- LIFECYCLE METHODS ---

        // Called when the page becomes visible - override in derived classes
        protected virtual void OnPageEnter() { }

        // Called when the page is about to be hidden - override in derived classes
        protected virtual void OnPageLeave() { }

        // Called to refresh page data - override in derived classes
        protected virtual void RefreshPageData() { }

        // Called when the user changes - override in derived classes
        public virtual void OnUserChanged()
        {
            RefreshPageData();
        }

        // --- DATA ACCESS PROPERTIES ---

        // Access to the current user through the MainForm
        protected PetStudyBuddy.Classes.User? CurrentUser => parentForm?.CurrentUser;

        // Access to the current pet through the current user
        protected PetStudyBuddy.Classes.Pet? CurrentPet => parentForm?.CurrentUser?.CurrentPet;
    }
}
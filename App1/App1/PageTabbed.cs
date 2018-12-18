
using Xamarin.Forms;


namespace App1
{
    class PageTabbed : TabbedPage
    {
        public PageTabbed() {
            var navigationPage = new NavigationPage(new Calculator());
            navigationPage.Title = "Calculator";
            navigationPage.Icon = "fb.png";

            var navigationPage1 = new NavigationPage(new Picker());
            navigationPage1.Title = "Picker";
            navigationPage.Icon = "twitter.png";

            var navigationPage2 = new NavigationPage(new TriggerPage());
            navigationPage1.Title = "Trigger";
            navigationPage.Icon = "twitter1.png";

            Children.Add(navigationPage);
            Children.Add(navigationPage1);
            Children.Add(navigationPage2);
        }


    }
}

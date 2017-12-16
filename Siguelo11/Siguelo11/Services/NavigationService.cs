
namespace Siguelo11.Services
{
    using Views;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    public class NavigationService
    {

        public async Task Navigate(string pageName)
        {
            switch (pageName)
            {
                case "AlarmaView":
                    await Application.Current.MainPage.Navigation.PushAsync(new AlarmaView());
                    break;

                    
                case "UbicationsView":
                    await Application.Current.MainPage.Navigation.PushAsync(new UbicationsView());
                    break;
                    
                    /*
               case "NewContactView":
                   await Application.Current.MainPage.Navigation.PushAsync(new NewContactView());
                   break;*/
            }
        }

    }
}

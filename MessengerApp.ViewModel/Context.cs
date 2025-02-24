using MessengerApp.Model;
using MessengerApp.ViewModel.Utils;

namespace MessengerApp.ViewModel
{
    public class Context
    {
        public User? AutorizedUser { get; set; }
        public ApiServiceLoginAndAuthorize apiLAU { get; set; }
        public ApiServiceMessage serviceMessage { get; set; }

        public Context()
        {
            apiLAU = new ApiServiceLoginAndAuthorize();
            serviceMessage = new ApiServiceMessage();
        }
    }
}

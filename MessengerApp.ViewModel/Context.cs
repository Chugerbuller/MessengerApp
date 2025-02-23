using MessengerApp.Model;
using MessengerApp.ViewModel.Utils;

namespace MessengerApp.ViewModel
{
    public class Context
    {
        public User? AutorizedUser { get; set; }
        public ApiServiceLoginAndAuthorize apiLAU { get; set; }

        public Context()
        {
            apiLAU = new ApiServiceLoginAndAuthorize();
        }
    }
}

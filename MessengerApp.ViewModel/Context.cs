using MessengerApp.Model;
using MessengerApp.ViewModel.Utils;

namespace MessengerApp.ViewModel
{
    public class Context
    {
        public User? AuthorizedUser { get; set; }
        public ApiServiceLoginAndAuthorize apiLAU { get; set; }
        public ApiServiceChats serviceChats { get; set; }
        public ApiServiceMessage serviceMessage { get; set; }
        public ApiServiceHubMesseges serviceHubMessage { get; set; }
        public Context()
        {
            apiLAU = new ApiServiceLoginAndAuthorize();
            serviceChats = new ApiServiceChats();
            serviceMessage = new ApiServiceMessage();
            serviceHubMessage = new ApiServiceHubMesseges();
        }
    }
}

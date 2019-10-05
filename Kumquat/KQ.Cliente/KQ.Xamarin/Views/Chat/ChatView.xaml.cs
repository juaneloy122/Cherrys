using KQ.Xamarin.ViewModels.Chat;
using System.ComponentModel;
using Xamarin.Forms;

namespace KQ.Xamarin.Views.Chat
{
    [DesignTimeVisible(false)]
    public partial class ChatView : ContentPage
    {
        ChatViewModel viewModel;

        public ChatView()
        {
            InitializeComponent();

            BindingContext = viewModel = new ChatViewModel();
        }
    }
}
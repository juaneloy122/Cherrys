using AppCherrys.ViewModels.Chat;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppCherrys.Views.Chat
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
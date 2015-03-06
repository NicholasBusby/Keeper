using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MonoGame.Framework;
using Windows.ApplicationModel.Activation;


namespace Keeper
{
    public sealed partial class GamePage : SwapChainBackgroundPanel
    {
        readonly Keeper _game;

        public GamePage(LaunchActivatedEventArgs args)
        {
            this.InitializeComponent();

            _game = XamlGame<Keeper>.Create(args, Window.Current.CoreWindow, this);
        }
    }
}

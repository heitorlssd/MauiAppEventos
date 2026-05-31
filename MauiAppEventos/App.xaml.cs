namespace MauiAppEventos
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var w = new Window(new AppShell());

            w.Height = 850;
            w.Width = 500;

            return w;
        }
    }
}
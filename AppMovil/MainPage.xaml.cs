namespace AppMovil
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clickeaste {count} vez gil";
            else
                CounterBtn.Text = $"Clickeaste {count} veces gil";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}

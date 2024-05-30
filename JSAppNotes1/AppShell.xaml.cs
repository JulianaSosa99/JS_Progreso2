namespace JSAppNotes1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.JS_NotePage), typeof(Views.JS_NotePage));
        }
    }
}

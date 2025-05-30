namespace PetStudyBuddy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loginButton.Click += loginHandler;
            register.Click += registerHandler;
        }

        private void loginHandler(object sender, EventArgs e) {
            MessageBox.Show("Hello!");
            // TODO: Will Add the main screen to navigate to it
        }

        private void registerHandler(object sender, EventArgs e)
        {
            RegisterPage registerPage = new RegisterPage();
            registerPage.Show();
            this.Hide();
        }

    }
}

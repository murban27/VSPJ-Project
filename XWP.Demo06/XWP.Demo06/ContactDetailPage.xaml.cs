using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XWP.Demo06.Model;

namespace XWP.Demo06
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailPage : ContentPage
    {
        public ContactDetailPage(Contact contact)
        {
            InitializeComponent();

            FirstNameContentLabel.Text = contact.FirstName;
            LastNameContentLabel.Text = contact.LastName;
            EmailContentLabel.Text = contact.Email;
            PhoneNumberContentLabel.Text = contact.PhoneNumber;
        }
    }
}
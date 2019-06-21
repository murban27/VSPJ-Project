using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XWP.Demo06.Model;

namespace XWP.Demo06
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
   
    public partial class AddContact : ContentPage, INotifyPropertyChanged
    {
        private Contact Contact;
        public AddContact()
        {

            InitializeComponent();
            




        }
        public void DoIt()
        {
           
        }

        private void Button_Clicked(object sender, EventArgs e)
        {



            var DbContext = new ContactsDatabaseContext();




            Contact = new Contact() { FirstName = FirstName.Text, Email = Email2.Text, LastName = LastName.Text, PhoneNumber = Telefon_Cislo.Text };
            DbContext.Contacts.Add(Contact);
            DbContext.SaveChanges();
            MessagingCenter.Send(this, "Hi");
            Navigation.PushAsync(new MainPage());

           

           



        }
   
    }
}
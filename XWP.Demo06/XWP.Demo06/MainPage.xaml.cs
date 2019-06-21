using System;
using System.ComponentModel;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using Xamarin.Forms;
using XWP.Demo06.Model;

namespace XWP.Demo06
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

           

            InitializeComponent();

                LoadContactsIntoListView();



            MessagingCenter.Subscribe<MainPage>(this, "Hi", (sender) => { LoadContactsIntoListView(); });

        }

        private void LoadContactsIntoListView()
        {
            using (var dbContext = new ContactsDatabaseContext())
            {
                var contacts = dbContext.Contacts.ToList();
                ContactsListView.ItemsSource = contacts;
                
            }
        }

        private void FillDatabaseWithData()
        {
            using (var dbContext = new ContactsDatabaseContext())
            {
                dbContext.Database.EnsureCreated();

                if (!EnumerableExtensions.Any(dbContext.Contacts))
                {
                    dbContext.Contacts.AddRange(new[]
                    {
                        new Contact
                        {
                            FirstName = "Michal",
                            LastName = "Urban",
                            Email = "murban27@student.vspj.cz",
                            PhoneNumber = "725902008"
                        },
                        new Contact
                        {
                            FirstName = "Marek ",
                            LastName = "Musil",
                            Email = "marek.musil@vspj.cz",
                            PhoneNumber = "721236467"
                        },
                        new Contact
                        {
                            FirstName = "TOmáš ",
                            LastName = "Vejrátka",
                            Email = "vejratoko@email.cz",
                            PhoneNumber = "603669321"
                        }
                    });
                }

                dbContext.SaveChanges();
            }
        }

        private async void ContactsListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var contact = (Contact) e.Item;
            await Navigation.PushAsync(new ContactDetailPage(contact));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
          

            Navigation.PushAsync(new AddContact());



        }
    
    }
}

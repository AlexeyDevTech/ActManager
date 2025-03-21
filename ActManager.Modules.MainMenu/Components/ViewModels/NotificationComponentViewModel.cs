using ActManager.Domain.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ActManager.Modules.MainMenu.Components.ViewModels
{
    public class NotificationComponentViewModel : BindableBase
    {
        private int _notificationCount;
        private ObservableCollection<Notification> _notificationList;

        public int NotificationCount
        {
            get =>  _notificationCount;
            set => SetProperty(ref _notificationCount, value);
        }
        public ObservableCollection<Notification> NotificationList
        {
            get => _notificationList;
            set => SetProperty(ref _notificationList, value);
        }

        public NotificationComponentViewModel()
        {            
            NotificationList = new ObservableCollection<Notification>()
            {
                new Notification() { 
                    Message = "notification 1", 
                    EventDate = DateTime.Now, 
                    RelatedEntityId = 1, 
                    Type = "deadline", 
                    User = new User()
                    { 
                        Email = "example@sobaka.com",
                        Username = "admin",
                    }
                },
                new Notification() {
                    Message = "notification 2",
                    EventDate = DateTime.Now,
                    RelatedEntityId = 2,
                    Type = "Confirm",

                    User = new User()
                    {
                        Email = "example@sobaka.com",
                        Username = "admin",
                    }
                },
                new Notification() {
                    Message = "notification 3",
                    EventDate = DateTime.Now,
                    RelatedEntityId = 3,
                    Type = "deadline",
                    User = new User()
                    {
                        Email = "example@sobaka.com",
                        Username = "admin",
                    }
                },
                new Notification() {
                    Message = "notification 4",
                    EventDate = DateTime.Now,
                    RelatedEntityId = 4,
                    Type = "deadline",
                    IsRead = true,
                    User = new User()
                    {
                        Email = "example@sobaka.com",
                        Username = "admin",
                    }
                },
                new Notification() {
                    Message = "notification 5",
                    EventDate = DateTime.Now,
                    RelatedEntityId = 3,
                    Type = "deadline",
                    User = new User()
                    {
                        Email = "example@sobaka.com",
                        Username = "admin",
                    }
                },
            };
            NotificationCount = NotificationList.Count;
            NotificationList.CollectionChanged += NotificationList_CollectionChanged;
        }

        private void NotificationList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotificationCount = (sender as ObservableCollection<Notification>).Count;
        }
    }
}

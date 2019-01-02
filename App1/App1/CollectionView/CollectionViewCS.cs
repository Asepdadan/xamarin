using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App1.CollectionView
{
    public class CollectionViewCS
    {



    }

    public class PhotoGroup : ObservableCollection<PhotoItem>
    {
        public string Head { get; set; }
        public PhotoGroup(IEnumerable<PhotoItem> list) : base(list) { }
    }

    public class PhotoItem
    {
        public string PhotoUrl { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
    }

    public class SomeViewModel
    {
        public ObservableCollection<PhotoGroup> ItemsSource { get; } = new ObservableCollection<PhotoGroup>();

        public SomeViewModel()
        {
            var list1 = new List<PhotoItem>();
            for (var i = 0; i < 20; i++)
            {
                list1.Add(new PhotoItem
                {
                    PhotoUrl = $"http://www.touchegolfschool.com/images/1.jpg",
                    Title = $"Title {i + 1}",
                    Category = "AAA",
                });
            }
            var list2 = new List<PhotoItem>();
            for (var i = 20; i < 40; i++)
            {
                list2.Add(new PhotoItem
                {
                    PhotoUrl = $"http://www.touchegolfschool.com/images/1.jpg",
                    Title = $"Title {i + 1}",
                    Category = "BBB",
                });
            }

            var group1 = new PhotoGroup(list1) { Head = "SectionA" };
            var group2 = new PhotoGroup(list2) { Head = "SectionB" };

            ItemsSource.Add(group1);
            //ItemsSource.Add(group2);
        }
    }
}

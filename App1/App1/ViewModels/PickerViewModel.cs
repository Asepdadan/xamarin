using App1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App1.ViewModels
{
    public class PickerViewModel : INotifyPropertyChanged
    {
        public IList<RootModel> Humans { get { return HumanData.Humans; } }
        public event PropertyChangedEventHandler PropertyChanged;
        RootModel selectedHuman;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        
        public RootModel SelectedHuman
        {
            get { return selectedHuman; }
            set
            {
                if (SelectedHuman != value)
                {
                    selectedHuman = value;
                    OnPropertyChanged();
                }
            }
        }


    }

    public static class HumanData
    {
        public static IList<RootModel> Humans { get; private set; }

        static HumanData()
        {

            Humans = new List<RootModel>();

            Humans.Add(new RootModel
            {
                Name = "Ardipithecus kadabba",
                Location = "Eastern Africa (Middle Awash Valley, Ethiopia)",
                Details = "Ardipithecus kadabba was bipedal (walked upright), probably similar in body and brain size to a modern chimpanzee, and had canines that resemble those in later hominins but that still project beyond the tooth row. ",
                ImageUrl = "https://i.pinimg.com/originals/47/ea/3b/47ea3b98a3a4bbd66a0cf054cca1cdd3.jpg"
            });

            Humans.Add(new RootModel
            {
                Name = "Ardipithecus ramidus",
                Location = " Eastern Africa (Middle Awash and Gona, Ethiopia)",
                Details = "Ardipithecus ramidus was first reported in 1994; in 2009, scientists announced a partial skeleton, nicknamed ‘Ardi’.",
                ImageUrl = "https://pbs.twimg.com/profile_images/1048662481705426944/A8UVFdqC_400x400.jpg"
            });

            Humans.Add(new RootModel
            {
                Name = "Homo neanderthalensis",
                Location = " Europe and southwestern to central Asia",
                Details = "Neanderthals (the ‘th’ pronounced as ‘t’) are our closest extinct human relative. Some defining features of their skulls include the large middle part of the face, angled cheek bones, and a huge nose for humidifying and warming cold, dry air. ",
                ImageUrl = "https://c1.staticflickr.com/8/7238/7283199754_59ab87e2a5_b.jpg"
            });

            Humans.Add(new RootModel
            {
                Name = "Orang Utan",
                Location = " Europe and southwestern to central Asia",
                Details = "Neanderthals (the ‘th’ pronounced as ‘t’) are our closest extinct human relative. Some defining features of their skulls include the large middle part of the face, angled cheek bones, and a huge nose for humidifying and warming cold, dry air. ",
                ImageUrl = "https://c1.staticflickr.com/8/7238/7283199754_59ab87e2a5_b.jpg"
            });

            Humans.Add(new RootModel
            {
                Name = "Orang Utan 1",
                Location = " Europe and southwestern to central Asia",
                Details = "Neanderthals (the ‘th’ pronounced as ‘t’) are our closest extinct human relative. Some defining features of their skulls include the large middle part of the face, angled cheek bones, and a huge nose for humidifying and warming cold, dry air. ",
                ImageUrl = "https://c1.staticflickr.com/8/7238/7283199754_59ab87e2a5_b.jpg"
            });

            Humans.Add(new RootModel
            {
                Name = "Orang Utan 2",
                Location = " Europe and southwestern to central Asia",
                Details = "Neanderthals (the ‘th’ pronounced as ‘t’) are our closest extinct human relative. Some defining features of their skulls include the large middle part of the face, angled cheek bones, and a huge nose for humidifying and warming cold, dry air. ",
                ImageUrl = "https://c1.staticflickr.com/8/7238/7283199754_59ab87e2a5_b.jpg"
            });

            Humans.Add(new RootModel
            {
                Name = "Orang Utan 3",
                Location = " Europe and southwestern to central Asia",
                Details = "Neanderthals (the ‘th’ pronounced as ‘t’) are our closest extinct human relative. Some defining features of their skulls include the large middle part of the face, angled cheek bones, and a huge nose for humidifying and warming cold, dry air. ",
                ImageUrl = "https://c1.staticflickr.com/8/7238/7283199754_59ab87e2a5_b.jpg"
            });

            Humans.Add(new RootModel
            {
                Name = "Orang Utan 4",
                Location = " Europe and southwestern to central Asia",
                Details = "Neanderthals (the ‘th’ pronounced as ‘t’) are our closest extinct human relative. Some defining features of their skulls include the large middle part of the face, angled cheek bones, and a huge nose for humidifying and warming cold, dry air. ",
                ImageUrl = "https://c1.staticflickr.com/8/7238/7283199754_59ab87e2a5_b.jpg"
            });

            Humans.Add(new RootModel
            {
                Name = "Orang Utan 5",
                Location = " Europe and southwestern to central Asia",
                Details = "Neanderthals (the ‘th’ pronounced as ‘t’) are our closest extinct human relative. Some defining features of their skulls include the large middle part of the face, angled cheek bones, and a huge nose for humidifying and warming cold, dry air. ",
                ImageUrl = "https://c1.staticflickr.com/8/7238/7283199754_59ab87e2a5_b.jpg"
            });

            Humans.Add(new RootModel
            {
                Name = "Orang Utan 6",
                Location = " Europe and southwestern to central Asia",
                Details = "Neanderthals (the ‘th’ pronounced as ‘t’) are our closest extinct human relative. Some defining features of their skulls include the large middle part of the face, angled cheek bones, and a huge nose for humidifying and warming cold, dry air. ",
                ImageUrl = "https://c1.staticflickr.com/8/7238/7283199754_59ab87e2a5_b.jpg"
            });

            Humans.Add(new RootModel
            {
                Name = "Orang Utan 7",
                Location = " Europe and southwestern to central Asia",
                Details = "Neanderthals (the ‘th’ pronounced as ‘t’) are our closest extinct human relative. Some defining features of their skulls include the large middle part of the face, angled cheek bones, and a huge nose for humidifying and warming cold, dry air. ",
                ImageUrl = "https://c1.staticflickr.com/8/7238/7283199754_59ab87e2a5_b.jpg"
            });


        }
    }
}

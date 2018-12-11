using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;

namespace App1.Model
{
    public class DataSource
    {
        static DataSource()
        {
        }

        public static void Persist(List<light> lights)
        {
            //do something here
        }

        public static ObservableCollection<light> getLights()
        {
            ObservableCollection<light> lights = new ObservableCollection<light>() {
                new light(false, "Bedside",  "Mel's Bedroom"),
                new light(false, "Desk", "Mel's Bedroom"),
                new light(false, "Flood Lamp", "Outside"),
                new light(false, "hallway1", "Entry Hallway"),
                new light(false, "hallway2", "Entry Hallway")
            };
            return lights;
        }
    }
}

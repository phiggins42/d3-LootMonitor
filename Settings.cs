﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LootAlert
{
    class Settings
    {
        public static bool PlayOnLegendary;
        public static bool PlayOnRare;
        public static bool PlayOnMagic;
        public static bool PlayOnCrafting;

        public static int Min62s;
        public static int Min63s;
        public static int MinMagic;

        public static int OverrideProcessID;

        public static void load()
        {
            PlayOnLegendary = Properties.Settings.Default.PlayOnLegendary;
            PlayOnRare = Properties.Settings.Default.PlayOnRare;
            PlayOnMagic = Properties.Settings.Default.PlayOnMagic;
            PlayOnCrafting = Properties.Settings.Default.PlayOnCrafting;

            Min62s = Properties.Settings.Default.Min62s;
            Min63s = Properties.Settings.Default.Min63s;
            MinMagic = Properties.Settings.Default.MinMagic;
        }

        public static void save()
        {
            Properties.Settings.Default.PlayOnLegendary = PlayOnLegendary;
            Properties.Settings.Default.PlayOnRare = PlayOnRare;
            Properties.Settings.Default.PlayOnMagic = PlayOnMagic;
            Properties.Settings.Default.PlayOnCrafting = PlayOnCrafting;

            Properties.Settings.Default.Min62s = Min62s;
            Properties.Settings.Default.Min63s = Min63s;
            Properties.Settings.Default.MinMagic = MinMagic;
            Properties.Settings.Default.Save();
        }
    }
}

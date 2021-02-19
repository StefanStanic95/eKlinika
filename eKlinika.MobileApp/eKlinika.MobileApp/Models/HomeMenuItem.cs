using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.MobileApp.Models
{
    public enum MenuItemType
    {
        MojProfil,
        Uplate,
        Uputnice,
        Pregledi,
        ApotekaRacuni
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}

using DisasterMapping.Api.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Infrastructure.Persistance.DataSeeding
{
    public static class BaseContextDataSeeding
    {
       public static List<City> GetCities()
        {
            City Adana = new("Adana");
            City Adıyaman = new("Adıyaman");
            City Afyonkarahisar = new("Afyonkarahisar");
            City Ankara = new("Ankara");
            City Bolu = new("Bolu");
            City Çanakkale = new("Çanakkale");
            City İstanbul = new("İstanbul");
            City İzmir = new("İzmir");
            
            List<City> cities = new() { Adana, Adıyaman, Afyonkarahisar, Ankara, Bolu , Çanakkale , İstanbul, İzmir };
            var temp = 1;
            foreach (var city in cities)
            {
                city.Id = temp;
                temp++;
            }

            return cities;
        }

        //var Cities = new List<string>()
        //{
        //    "Adana",
        //    "Adıyaman",
        //    "Afyonkarahisar",
        //    "Ağrı",
        //    "Amasya",
        //    "Ankara",
        //    "Antalya",
        //    "Artvin",
        //    "Aydın",
        //    "Balıkesir",
        //    "Bilecik",
        //    "Bingöl",
        //    "Bitlis",
        //    "Bolu",
        //    "Burdur",
        //    "Bursa",
        //    "Çanakkale",
        //    "Çankırı",
        //    "Çorum",
        //    "Denizli",
        //    "Diyarbakır",
        //    "Edirne",
        //    "Elazığ",
        //    "Erzincan",
        //    "Erzurum",
        //    "Eskişehir",
        //    "Gaziantep",
        //    "Giresun",
        //    "Gümüşhane",
        //    "Hakkari",
        //    "Hatay",
        //    "Isparta",
        //    "İçel (Mersin)",
        //    "İstanbul",
        //    "İzmir",
        //    "Kars",
        //    "Kastamonu",
        //    "Kayseri",
        //    "Kırklareli",
        //    "Kırşehir",
        //    "Kocaeli",
        //    "Konya",
        //    "Kütahya",
        //    "Malatya",
        //    "Manisa",
        //    "Kahramanmaraş",
        //    "Mardin",
        //    "Muğla",
        //    "Muş",
        //    "Nevşehir",
        //    "Niğde",
        //    "Ordu",
        //    "Rize",
        //    "Sakarya",
        //    "Samsun",
        //    "Siirt",
        //    "Sinop",
        //    "Sivas",
        //    "Tekirdağ",
        //    "Tokat",
        //    "Trabzon",
        //    "Tunceli",
        //    "Şanlıurfa",
        //    "Uşak",
        //    "Van",
        //    "Yozgat",
        //    "Zonguldak",
        //    "Aksaray",
        //    "Bayburt",
        //    "Karaman",
        //    "Kırıkkale",
        //    "Batman",
        //    "Şırnak",
        //    "Bartın",
        //    "Ardahan",
        //    "Iğdır",
        //    "Yalova",
        //    "Karabük",
        //    "Kilis",
        //    "Osmaniye",
        //    "Düzce"
        //};
}
}

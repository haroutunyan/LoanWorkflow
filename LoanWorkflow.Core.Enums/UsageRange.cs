using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoanWorkflow.Core.Enums
{
    public enum UsageRange
    {
        [XmlEnum("1")]
        Consumer = 1,

        [XmlEnum("2")]
        Accommodation,

        [XmlEnum("3")]
        FoodIndustry,

        [XmlEnum("4")]
        Construction,

        [XmlEnum("5")]
        Trade,

        [XmlEnum("6")]
        Agriculture,

        [XmlEnum("7")]
        Mining,

        [XmlEnum("8")]
        LightIndustry,

        [XmlEnum("9")]
        EnergyIndustry,

        [XmlEnum("10")]
        ChemicalIndustry,

        [XmlEnum("11")]
        BuildingMaterialsIndustry,

        [XmlEnum("12")]
        Jewelery,

        [XmlEnum("13")]
        Metallurgy,

        [XmlEnum("14")]
        MechanicalElectricalEngineering,

        [XmlEnum("15")]
        TransportAndCommunication,

        [XmlEnum("16")]
        Education,

        [XmlEnum("17")]
        HealthAndSocial,

        [XmlEnum("18")]
        CultureAndSport,

        [XmlEnum("19")]
        HotelAndRestaurantBusiness,

        [XmlEnum("20")]
        Other,

        [XmlEnum("21")]
        OtherTest,

        [XmlEnum("31")]
        NewLoan = 31,

        [XmlEnum("34")]
        NewBorrower
    };
}

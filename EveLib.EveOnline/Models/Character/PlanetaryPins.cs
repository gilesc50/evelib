﻿using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Character {
    
    [Serializable]
    [XmlRoot("result")]
    public class PlanetaryPins {

        [XmlElement("rowset")]
        public EveOnlineRowCollection<PlanetaryPin> Pins { get; set; }

        public class PlanetaryPin {

            [XmlAttribute("pinID")]
            public long PinId { get; set; }

            [XmlAttribute("typeID")]
            public long TypeId { get; set; }

            [XmlAttribute("typeName")]
            public string TypeName { get; set; }

            [XmlAttribute("schematicID")]
            public int SchematicId { get; set; }

            [XmlAttribute("lastLaunchTime")]
            public string LastLaunchTimeAsString { get; set; }

            [XmlAttribute("cycleTime")]
            public string CycleTime { get; set; }

            [XmlAttribute("quantityperCycle")]
            public int QuantityPerCycle { get; set; }

            [XmlAttribute("installTime")]
            public string InstallTimeAsString { get; set; }

            [XmlAttribute("expiryTime")]
            public string ExpiryTimeAsString { get; set; }

            [XmlAttribute("headRadius")]
            public int headRadius { get; set; }

            [XmlAttribute("contentTypeID")]
            public int ContentTypeId { get; set; }

            [XmlAttribute("contentTypeName")]
            public string ContentTypeName { get; set; }

            [XmlAttribute("contentQuantity")]
            public int ContentQuantity { get; set; }

        }
    }
}

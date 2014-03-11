﻿using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnline.Model.Corporation {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class TitleList {
        [XmlElement("rowset")]
        public RowCollection<Title> Titles { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Role {
            [XmlAttribute("roleID")]
            public long RoleId { get; set; }

            [XmlAttribute("roleName")]
            public string RoleName { get; set; }

            [XmlAttribute("roleDescription")]
            public string RoleDescription { get; set; }
        }

        [Serializable]
        [XmlRoot("row")]
        public class Title : IXmlSerializable {
            [XmlAttribute("titleID")]
            public long TitleId { get; set; }

            [XmlAttribute("titleName")]
            public string TitleName { get; set; }

            [XmlElement("rowset")]
            public RowCollection<Role> Roles { get; set; }

            [XmlElement("rowset")]
            public RowCollection<Role> GrantableRoles { get; set; }

            [XmlElement("rowset")]
            public RowCollection<Role> RolesAtHq { get; set; }

            [XmlElement("rowset")]
            public RowCollection<Role> GrantableRolesAtHq { get; set; }

            [XmlElement("rowset")]
            public RowCollection<Role> RolesAtBase { get; set; }

            [XmlElement("rowset")]
            public RowCollection<Role> GrantableRolesAtBase { get; set; }

            [XmlElement("rowset")]
            public RowCollection<Role> RolesAtOther { get; set; }

            [XmlElement("rowset")]
            public RowCollection<Role> GrantableRolesAtOther { get; set; }

            public XmlSchema GetSchema() {
                throw new NotImplementedException();
            }

            public void ReadXml(XmlReader reader) {
                var xml = new XmlHelper(reader);
                TitleId = xml.getLongAttribute("titleID");
                TitleName = xml.getStringAttribute("titleName");
                Roles = xml.deserializeRowSet<Role>("roles");
                GrantableRoles = xml.deserializeRowSet<Role>("grantableRoles");
                RolesAtHq = xml.deserializeRowSet<Role>("rolesAtHQ");
                GrantableRolesAtHq = xml.deserializeRowSet<Role>("grantableRolesAtHQ");
                RolesAtBase = xml.deserializeRowSet<Role>("rolesAtBase");
                GrantableRolesAtBase = xml.deserializeRowSet<Role>("grantableRolesAtBase");
                RolesAtOther = xml.deserializeRowSet<Role>("rolesAtOther");
                GrantableRolesAtOther = xml.deserializeRowSet<Role>("grantableRolesAtOther");
            }

            public void WriteXml(XmlWriter writer) {
                throw new NotImplementedException();
            }
        }
    }
}
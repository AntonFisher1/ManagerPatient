using ManagePatient.Utils;
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ManagePatient.Models
{
    public class Patient : IXmlSerializable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LasUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            while (reader.Read())
            {
                var nodeName = reader.Name;
                reader.Read();
                switch (nodeName)
                {
                    case "FirstName":
                        FirstName = reader.Value.Decrypt();
                        break;
                    case "LastName":
                        LastName = reader.Value.Decrypt();
                        break;
                    case "Email":
                        Email = reader.Value.Decrypt();
                        break;
                    case "Notes":
                        Notes = reader.Value.Decrypt();
                        break;
                    case "Phone":
                        Phone = reader.Value.Decrypt();
                        break;
                    case "IsDeleted":
                        IsDeleted = bool.Parse(reader.Value);
                        break;
                    case "CreatedDate":
                        CreatedDate = DateTime.Parse(reader.Value);
                        break;
                    case "LasUpdatedDate":
                        LasUpdatedDate = DateTime.Parse(reader.Value);
                        break;
                    case "Gender":
                        Gender = (Gender)Enum.Parse(typeof(Gender), reader.Value.Decrypt());
                        break;
                }
                reader.Read();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("FirstName", FirstName.Encrypt());
            writer.WriteElementString("LastName", LastName.Encrypt());
            writer.WriteElementString("Phone", Phone.Encrypt());
            writer.WriteElementString("Email", Email.Encrypt());
            writer.WriteElementString("Gender", Gender.ToString().Encrypt());
            writer.WriteElementString("Notes", FirstName.Encrypt());
            writer.WriteElementString("IsDeleted", IsDeleted.ToString());
            writer.WriteElementString("CreatedDate", CreatedDate.ToUniversalTime().ToString());
            writer.WriteElementString("LasUpdatedDate", CreatedDate.ToUniversalTime().ToString());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PetPals.Entities
{
    internal class Participants
    {
        public int ParticipantID { get; set; }

        public string ParticipantName { get; set; }

        public string ParticipantType { get; set; }

        public int EventId { get; set; }

        public override string ToString()
        {
            return $"ParticicpantID: {ParticipantID}\t Name: {ParticipantName}\t Type: {ParticipantType}\t Even ID: {EventId}";
        }
    }
}

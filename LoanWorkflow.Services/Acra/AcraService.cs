using LoanWorkflow.Services.DTO.Acra;
using LoanWorkflow.Services.Interfaces.Acra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LoanWorkflow.Services.Acra
{
    public class AcraService : IAcraService
    {
        public AcraResult GetAcraData()
        {
            var xmlData = File.ReadAllText("C:\\Users\\User\\Downloads\\Telegram Desktop\\acralog.txt");
            var serializer = new XmlSerializer(typeof(AcraResult));

            using var reader = new StringReader(xmlData);
            var result = (AcraResult)serializer.Deserialize(reader);

            return result;
        }
    }
}

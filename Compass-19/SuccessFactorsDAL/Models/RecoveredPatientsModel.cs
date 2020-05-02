using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SuccessFactorsDAL.Models
{
    public class RecoveredPatientsModel
    {
        #region Recovered Factors

        [BsonId()]
        public ObjectId Id { get; set; }

        [BsonElement("nationalDocumentId")]
        public int NationalDocumentId { get; set; }

        [BsonElement("nameofPatient")]
        public string NameofPatient { get; set; }

        [BsonElement("situationBeforeRecover")]
        public string SituationBeforeRecover { get; set; }

        public IList<string> UsedMedicines { get; set; }

        [BsonElement("situationAfterMedicines")]
        public string SituationAfterMedicines { get; set; }

        #endregion Recovered Factors

        public RecoveredPatientsModel()
        {
        }

        public RecoveredPatientsModel UpdateRecoveredPatientProperties(RecoveredPatientsModel recoveredPatients, [Optional] int nationalDocument, [Optional] string nameofPatient, [Optional] string situationAfterMedicines,
       [Optional] string situationBeforeRecover, [Optional] IList<string> usedMedicines)
        {
            recoveredPatients.NationalDocumentId = nationalDocument;
            recoveredPatients.NameofPatient = nameofPatient;
            recoveredPatients.SituationAfterMedicines = situationAfterMedicines;
            recoveredPatients.SituationBeforeRecover = situationBeforeRecover;
            recoveredPatients.UsedMedicines = usedMedicines;

            return recoveredPatients;
        }
    }
}
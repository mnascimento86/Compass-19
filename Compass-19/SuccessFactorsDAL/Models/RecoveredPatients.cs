using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace SuccessFactorsDAL.Models
{
    public class RecoveredPatients : MongodbConnection
    {

        #region mongodb
        public IMongoCollection<RecoveredPatients> recoveredPatientCollection { get; set; }

        #endregion

        #region Recovered Factors 
        public int NationalDocumentId { get; set; }
        public string NameofPatient { get; set; }
        public string SituationBeforeRecover { get; set; }
        public IList<string> UsedMedicines { get; set; }
        public string SituationAfterMedicines { get; set; }

        #endregion

        public RecoveredPatients()
        {
            this.recoveredPatientCollection = database.GetCollection<RecoveredPatients>("RecoveredPatients");
        }

        public RecoveredPatients GetRecoveredPatient(int nationalDocument)
        {
            Expression<Func<RecoveredPatients, bool>> filter = x => x.NationalDocumentId.Equals(nationalDocument);

            return this.recoveredPatientCollection.Find(filter).FirstOrDefault();
        }

        public IEnumerable<RecoveredPatients> GetListAllRecoveredPatients()
        {
            return this.recoveredPatientCollection.Find(null).ToList();
        }

        public void InsertRecoveredPatients()
        {
            recoveredPatientCollection.InsertOne(this);
        }

        public RecoveredPatients UpdateRecoveredPatients(int nationalDocument)
        {
            Expression<Func<RecoveredPatients, bool>> filter = x => x.NationalDocumentId.Equals(nationalDocument);
            var recoveredPatients = recoveredPatientCollection.Find(filter).FirstOrDefault();

            if (recoveredPatients != null)
            {
                recoveredPatients = UpdateRecoveredPatientProperties(recoveredPatients, nationalDocument);
                recoveredPatientCollection.ReplaceOne(filter, recoveredPatients);
            }

            return recoveredPatients;
        }

     
        public void DeleteRecoveredPatients(int nationalDocument)
        {
            Expression<Func<RecoveredPatients, bool>> filter = x => x.NationalDocumentId.Equals(nationalDocument);
            this.recoveredPatientCollection.DeleteOne(filter);
        }

        private static RecoveredPatients UpdateRecoveredPatientProperties(RecoveredPatients recoveredPatients, [Optional] int nationalDocument, [Optional] string nameofPatient, [Optional] string situationAfterMedicines,
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

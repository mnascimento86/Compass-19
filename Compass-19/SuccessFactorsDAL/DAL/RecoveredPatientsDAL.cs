using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SuccessFactorsDAL.Models
{
    public class RecoveredPatientsDAL : MongodbConnection
    {
        #region mongodb

        public IMongoCollection<RecoveredPatientsModel> recoveredPatientCollection { get; set; }

        #endregion mongodb

        public RecoveredPatientsDAL()
            : base()
        {
            this.recoveredPatientCollection = database.GetCollection<RecoveredPatientsModel>("RecoveredPatientsModel");
        }

        public RecoveredPatientsModel GetRecoveredPatient(int nationalDocument)
        {
            Expression<Func<RecoveredPatientsModel, bool>> filter = x => x.NationalDocumentId.Equals(nationalDocument);

            return this.recoveredPatientCollection.Find(filter).FirstOrDefault();
        }

        public IEnumerable<RecoveredPatientsModel> GetListAllRecoveredPatients()
        {
            try
            {
                //Expression<Func<RecoveredPatientsModel, bool>> filter = x => x.NationalDocumentId.Equals(171);

                return this.recoveredPatientCollection.Find(_ => true).ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public void InsertRecoveredPatients(RecoveredPatientsModel patientsDAL)
        {
            recoveredPatientCollection.InsertOne(patientsDAL);
        }

        public RecoveredPatientsModel UpdateRecoveredPatients(RecoveredPatientsModel patientsDAL)
        {
            Expression<Func<RecoveredPatientsModel, bool>> filter = x => x.NationalDocumentId.Equals(patientsDAL.NationalDocumentId);
            RecoveredPatientsModel recoveredPatientsModel = recoveredPatientCollection.Find(filter).FirstOrDefault();

            if (recoveredPatientsModel != null)
            {
                recoveredPatientsModel = recoveredPatientsModel.UpdateRecoveredPatientProperties(recoveredPatientsModel, patientsDAL.NationalDocumentId);
                recoveredPatientCollection.ReplaceOne(filter, recoveredPatientsModel);
            }

            return recoveredPatientsModel;
        }

        public void DeleteRecoveredPatients(RecoveredPatientsModel patientsDAL)
        {
            Expression<Func<RecoveredPatientsModel, bool>> filter = x => x.NationalDocumentId.Equals(patientsDAL.NationalDocumentId);
            this.recoveredPatientCollection.DeleteOne(filter);
        }
    }
}
using SuccessFactorsDAL.Models;
using System;
using System.Collections.Generic;

namespace SuccessFactorsBLL
{
    public class RecoveredPatientsBLL
    {
        public RecoveredPatientsDAL recoveredPatientsDAL { get; set; }

        public RecoveredPatientsBLL()
        {
            if (this.recoveredPatientsDAL == null)
                this.recoveredPatientsDAL = new RecoveredPatientsDAL();
        }

        public RecoveredPatientsModel GetRecoveredPatient(int nationalDocumentID)
        {
            try
            {
                return this.recoveredPatientsDAL.GetRecoveredPatient(nationalDocumentID);
            }
            catch (Exception ex) { throw ex; }
        }

        public IEnumerable<RecoveredPatientsModel> GetListRecoveredPatient()
        {
            try
            {
                return this.recoveredPatientsDAL.GetListAllRecoveredPatients();
            }
            catch (Exception ex) { throw ex; }
        }

        public void InsertRecoveredPatients(RecoveredPatientsModel patientsModels)
        {
            try
            {
                this.recoveredPatientsDAL.InsertRecoveredPatients(patientsModels);
            }
            catch (Exception ex) { throw ex; }
        }

        public RecoveredPatientsModel UpdateRecoveredPatients(RecoveredPatientsModel patientsModels)
        {
            try
            {
                return this.recoveredPatientsDAL.UpdateRecoveredPatients(patientsModels);
            }
            catch (Exception ex) { throw ex; }
        }

        public void DeleteRecoveredPatients(Int32 patientsId)
        {
            try
            {
                RecoveredPatientsModel patientsModels = new RecoveredPatientsModel() { NationalDocumentId = patientsId };
                this.recoveredPatientsDAL.DeleteRecoveredPatients(patientsModels);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
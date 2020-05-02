using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuccessFactorsBLL;
using SuccessFactorsDAL.Models;

namespace SuccessFactorsService.Controllers
{
    [Route("api/RecoveredPatients")]
    [ApiController]
    public class RecoveredPatientsController : ControllerBase
    {
        // GET: api/RecoveredPatients
        [HttpGet]
        public IEnumerable<RecoveredPatientsModel> Get()
        {
            return new RecoveredPatientsBLL().GetListRecoveredPatient();
        }

        // GET: api/RecoveredPatients/5
        [HttpGet("{id}", Name = "Get")]
        public RecoveredPatientsModel Get(int id)
        {
            return new RecoveredPatientsBLL().GetRecoveredPatient(id);
        }

        // POST: api/RecoveredPatients
        [HttpPost]
        public RecoveredPatientsModel Post([FromBody] RecoveredPatientsModel recoveredPatientsModel)
        {
            return new RecoveredPatientsBLL().UpdateRecoveredPatients(recoveredPatientsModel);
        }

        // PUT: api/RecoveredPatients/5
        [HttpPut("{id}")]
        public void Put([FromBody] RecoveredPatientsModel recoveredPatientsModel)
        {
            new RecoveredPatientsBLL().InsertRecoveredPatients(recoveredPatientsModel);
        }

        // DELETE: api/RecoveredPatient/5
        [HttpDelete("{id}")]
        public void Delete(int patientsId)
        {        
           new RecoveredPatientsBLL().DeleteRecoveredPatients(patientsId);
        }
    }
}

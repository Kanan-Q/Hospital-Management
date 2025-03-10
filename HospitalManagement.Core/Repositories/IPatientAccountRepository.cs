﻿using HospitalManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Repositories
{
    public interface IPatientAccountRepository
    {
        Task AddAsync(PatientAccount patientAccount);
        Task<IEnumerable<PatientAccount>> GetAllAsync();
        Task<PatientAccount> GetByFinCodeAsync(string finCode);
        Task<IEnumerable<Prescription>> SearchAsync(string query);

    }
}

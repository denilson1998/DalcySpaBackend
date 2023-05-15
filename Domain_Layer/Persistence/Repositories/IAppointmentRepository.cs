﻿using Domain_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Persistence.Repositories
{
    public interface IAppointmentRepository
    {
        public Task<Appointment> CreateAppointmentAsync(Appointment appointment);
    }
}
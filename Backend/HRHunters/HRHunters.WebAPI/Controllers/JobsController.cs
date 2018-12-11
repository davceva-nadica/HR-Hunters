﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRHunters.Common.Entities;
using HRHunters.Common.Enums;
using HRHunters.Common.Interfaces;
using HRHunters.Common.Requests.Users;
using HRHunters.Common.Responses.AdminDashboard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRHunters.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobManager _jobManager;
        public JobsController(IJobManager jobManager)
        {
            _jobManager = jobManager;
        }

        [HttpGet]
        public ActionResult<JobResponse> GetJobs(int pageSize = 10, int currentPage = 1, string sortedBy = "Id", 
            SortDirection sortDir = SortDirection.ASC, string filterBy = "", string filterQuery = "")
        {
            return Ok(_jobManager.GetMultiple(pageSize, currentPage, sortedBy, sortDir, filterBy, filterQuery));
        }

        [HttpGet("{id}")]
        public ActionResult<JobResponse> GetOneJobPosting(int id)
        {
            return Ok(_jobManager.GetOneJobPosting(id));
        }

        [HttpPost]
        public async Task<ActionResult<object>> CreateJobPosting(JobSubmit jobSubmit)
        {
            return Ok(await _jobManager.CreateJobPosting(jobSubmit));
        }
    }
}
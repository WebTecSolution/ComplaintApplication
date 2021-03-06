﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using ComplaintsApplication.Common.Model;
using ComplaintsApplication.ReadWrite.Application.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintsApplication.ReadWrite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ComplaintController : ControllerBase
    {
        private readonly IComplaintService _complaintService;
        public ComplaintController(IComplaintService complaintService)
        {
            _complaintService = complaintService;
        }
        // GET: api/Complaint
        [HttpGet]
        public ActionResult<IEnumerable<Complaints>> Get()
        {
            return Ok(_complaintService?.GetComplaints());
        }

        // GET: api/Complaint/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Complaints> Get(int id)
        {
            return Ok(_complaintService?.GetComplaintById(id));
        }

        // POST: api/Complaint
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Complaints complaint)
        {
            try
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var jwtToken = new JwtSecurityToken(token);
                int cid = Convert.ToInt32(jwtToken.Claims.FirstOrDefault(x => x.Type == "sub").Value.ToString());
                complaint.ComplaintBy = cid;
                _complaintService.InsertComplaint(complaint);
                return Ok("New complaint register/log request sent successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest("Request not done. Please contact Admin! Error Message: " + ex.Message);
            }
        }

        // PUT: api/Complaint/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Complaints complaint)
        {
            try
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var jwtToken = new JwtSecurityToken(token);
                int cid = Convert.ToInt32(jwtToken.Claims.FirstOrDefault(x => x.Type == "sub").Value.ToString());
                complaint.ComplaintBy = cid;
                _complaintService.UpdateComplaint(id, complaint);
                return Ok("Update complaint request sent successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest("Request not done. Please contact Admin. Error Message: " + ex.Message);
            }
        }

        // DELETE: api/ApiWithActions/5

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _complaintService.DeleteComplaint(id);
                return Ok("Delete complaint request sent successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest("Request not done. Please contact Admin. Error Message: " + ex.Message);
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleApi.ServiceAgents;
using Digipolis.ServiceAgents;
using SampleApi.Models;

namespace SampleApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly GenericAgent<Address> _addressAgent;
        private IDemoAgent _serviceAgent;

        public ValuesController(IDemoAgent serviceAgent, GenericAgent<Address> addressAgent)
        {
            _serviceAgent = serviceAgent;
            _addressAgent = addressAgent;
        }

        // GET: api/values
        [HttpGet]
        public async Task<string> Get()
        {
            string result = String.Empty;
            try
            {
                //The call will throw an exception since no service is listening
                //result = await _serviceAgent.GetAddressAsync(1);

                result = await _serviceAgent.GetAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return result;
        }

        [HttpGet]
        [Route("getsomevalue")]
        public string GetSomeValue()
        {
            return "Some string value";
        }

    }
}

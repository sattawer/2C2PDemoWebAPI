using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Description;
using _2C2PDemoWebAPI.Models;

namespace _2C2PDemoWebAPI.Controllers
{
    public class CustomersController : ApiController
    {
        private Entities db = new Entities();

        // GET api/<controller>
        public IEnumerable<Customer> Get()
        {
            return db.Customers;
        }

        // GET api/<controller>/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrWhiteSpace(id.ToString()) || !IsCustomerIDValid(id.ToString()))
            {
                return BadRequest("Invalid Customer ID.");
            }

            CustomerDTO customer = db.Customers.Where(c => c.customerID == id)
                .Select(c => new CustomerDTO
                {
                    customerID = c.customerID,
                    name = c.name,
                    email = c.email,
                    mobile = c.mobile,
                    transactions = db.Transactions.Where(t => t.customerID == c.customerID)
                        .OrderByDescending(t => t.date)
                        .Take(5)
                        .Select(t => new TransactionDTO
                        {
                            Id = t.Id,
                            date = t.date,
                            amount = t.amount,
                            currency = t.currency,
                            status = t.status
                        })
                        .ToList()
                }).FirstOrDefault();

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // GET api/<controller>/example@mail.com
        [ResponseType(typeof(Customer))]
        public IHttpActionResult Get(string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrWhiteSpace(email) || !IsEmailValid(email))
            {
                return BadRequest("Invalid Email.");
            }

            CustomerDTO customer = db.Customers.Where(c => c.email == email)
                .Select(c => new CustomerDTO
                {
                    customerID = c.customerID,
                    name = c.name,
                    email = c.email,
                    mobile = c.mobile,
                    transactions = db.Transactions.Where(t => t.customerID == c.customerID)
                        .OrderByDescending(t => t.date)
                        .Take(5)
                        .Select(t => new TransactionDTO
                        {
                            Id = t.Id,
                            date = t.date,
                            amount = t.amount,
                            currency = t.currency,
                            status = t.status
                        })
                        .ToList()
                }).FirstOrDefault();

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // GET api/<controller>/id=5&example@mail.com
        [ResponseType(typeof(Customer))]
        public IHttpActionResult Get(string customerID, string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(customerID))
            {
                return BadRequest("No inquiry criteria.");
            }

            if (!IsCustomerIDValid(customerID))
            {
                return BadRequest("Invalid Customer ID.");
            }

            if (!IsEmailValid(email))
            {
                return BadRequest("Invalid Email.");
            }

            bool parseSuccess = int.TryParse(customerID, out int _customerID);

            CustomerDTO customer = db.Customers.Where(c => c.email == email && c.customerID == _customerID)
                .Select(c => new CustomerDTO
                {
                    customerID = c.customerID,
                    name = c.name,
                    email = c.email,
                    mobile = c.mobile,
                    transactions = db.Transactions.Where(t => t.customerID == c.customerID)
                        .OrderByDescending(t => t.date)
                        .Take(5)
                        .Select(t => new TransactionDTO
                        {
                            Id = t.Id,
                            date = t.date,
                            amount = t.amount,
                            currency = t.currency,
                            status = t.status
                        })
                        .ToList()
                }).FirstOrDefault();

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        public bool IsEmailValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public bool IsCustomerIDValid(string customerID)
        {
            try
            {
                Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");

                return regex.IsMatch(customerID);
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
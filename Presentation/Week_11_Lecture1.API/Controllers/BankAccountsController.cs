using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using Week_11_Lecture1.API.Models;
using Week_11_Lecture1.Domain.Entities;
using Week_11_Lecture1.Persistence.Contexts;

namespace Week_11_Lecture1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        public PerfectAppDbContext _perfectAppDbContext { get; set; }

        public BankAccountsController(PerfectAppDbContext perfectAppDbContext)
        {
            _perfectAppDbContext = perfectAppDbContext;

        }

        [HttpPost("[action]")]
        public void SetDefaultUsersData()
        {
            List<BankAccount> people = new List<BankAccount>
            {
                new BankAccount
                {
                    Id = Guid.Parse("f4ee11a6-9d8e-4584-8d7f-8ad2d83119c9"),
                    CreatedOn = DateTime.UtcNow,
                    CreatedByUserId = "1",
                    FirstName = "James",
                    LastName = "Smith",
                    PhoneNumber = "5523367351"
                },
                new BankAccount
                {
                    Id = Guid.Parse("f4ee11a6-9d8e-4584-8d7f-8ad2d83119c8"),
                    CreatedOn = DateTime.UtcNow,
                    CreatedByUserId = "2",
                    FirstName = "Emily",
                    LastName = "Johnson",
                    PhoneNumber = "5523367352"
                },
                new BankAccount
                {
                    Id = Guid.Parse("f4ee11a6-9d8e-4584-8d7f-8ad2d83119c7"),
                    CreatedOn = DateTime.UtcNow,
                    CreatedByUserId = "3",
                    FirstName = "Michael",
                    LastName = "Williams",
                    PhoneNumber = "5523367353"
                },
                new BankAccount
                {
                    Id = Guid.Parse("f4ee11a6-9d8e-4584-8d7f-8ad2d83119c6"),
                    CreatedOn = DateTime.UtcNow,
                    CreatedByUserId = "4",
                    FirstName = "Emma",
                    LastName = "Brown",
                    PhoneNumber = "5523367354"
                },
                 new BankAccount
                {
                    Id = Guid.Parse("f4ee11a6-9d8e-4584-8d7f-8ad2d83119c5"),
                    CreatedOn = DateTime.UtcNow.AddDays(-4), // Example: Four days earlier
                    CreatedByUserId = "5",
                    FirstName = "William",
                    LastName = "Jones",
                    PhoneNumber = "5523367355"
                }
            };

            _perfectAppDbContext.BankAccounts.AddRange(people);
            _perfectAppDbContext.SaveChanges();
        }

        [HttpGet("[action]/(bankAccountId:guid)")]
        public GetBankAccountDataResponseModel GetBankAccount(Guid bankAccountId)
        {
            //Guid.Parse(bankAccountId);

            var bankAccount = _perfectAppDbContext.BankAccounts.FirstOrDefault(x => x.Id == bankAccountId);

            var response = new GetBankAccountDataResponseModel()
            {
                FirstName = bankAccount.FirstName,
                LastName = bankAccount.LastName,
                Balance = bankAccount.Balance,
            };

            return response;
        }
    }
}

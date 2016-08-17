using System;
using System.Web.Http;
using Email.Services;
using EmailModel = Email.Web.Api.Models.EmailModel;
using AutoMapper;
using System.Threading.Tasks;

namespace Email.Web.Api.Controllers
{
    [Route("api/email")]
    [Authorize]
    public class EmailController : ApiController
    {
        private IEmailService _emailService;
        private IMapper _mapper;

        //TODO remove after Ioc implementation
        public EmailController()
        {
            _emailService = new EmailService();
        }

        public EmailController(IEmailService emailService, IMapper mapper)
        {
            _emailService = emailService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<EmailModel> Get()
        {
            //TODO make service async
            var result = Task.FromResult( _emailService.GetEmail(new Guid())).Result;

            //ToDO configure mapper
            //return _mapper.Map<EmailModel>(result);
            return new EmailModel
            {
                To = result.To,
                From = result.From,
                Subject = result.Subject,
                EmailBody = result.EmailBody
            };
        }
    }

}    
    


    

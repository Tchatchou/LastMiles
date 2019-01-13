using System.Threading.Tasks;
using Data_Base;
using Infrastructure.Communication.EmailSendgrid;
/* using LastMiles.API.BusinessLogic.Communication;
using LastMiles.API.DataBase; */
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LastMiles.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        ILogger _logger;
        private readonly IConfiguration _config;
        private  IMemoryCache _memoryCache;
        private readonly IEmail email;
        private readonly DataContext _context;
        public ValuesController(DataContext context, ILogger<ValuesController> logger, 
                                IConfiguration config, IMemoryCache memoryCache,
                                IEmail email
                                )
        {
            _context = context;
            _logger = logger;
            _config = config;
            _memoryCache = memoryCache;
            this.email = email;
        }
        // GET ap
        [HttpGet("GetValues")]
        public async Task<IActionResult> GetValues()
        {
            // var v = await  _context.Testdbs.ToListAsync();
            // _logger.LogInformation("vaa");
            return Ok("vaaa");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            // var v =await _context.Testdbs.FirstOrDefaultAsync(x=>x.id==id);

            // var c= new Communication(_config);
            //c.sendEmailSendgridViaLibrary();
            // c.OrangeSmsBalance();

           // var sms = new OrangeSMSProvider(_config,_memoryCache,_logger);
           //var token = sms.get_Token();
           //  sms.get_Balance();

        var wlc=   new WelcomeEmail(){
                        name="jonathan djouonang",
                        username="Djouonang",
                        password="@Jontred14",
                        customerServiceEmail="jonathan.nicanor@gmail.com",
                        customerServiceNumber="652012457"
                    };

email.sendResetPassswordEmailSendgrid("jonathan_djouonang@yahoo.fr","Djouonang",wlc);
//email.sendWelcomeEmailSendgrid("jonathan_djouonang@yahoo.fr","Djouonang",wlc);

        //   IEmail  email = new Email();

        //   email.sendWelcomeEmailSendgrid("jonathan_djouonang@yahoo.fr","Djouonang",wlc,_config,_logger);


           //sms.send_SMS("656896184", "API SMS TEST");
            return Ok("veee");
        }


    }
}

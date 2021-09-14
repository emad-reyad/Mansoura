using Mansoura.Model;
using Mansoura.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mansoura.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileIDataService dataService;
        public Members Members { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, JsonFileIDataService dataService)
        {
            _logger = logger;
            this.dataService = dataService;
        }

        public void OnGet()
        {
            Members= dataService.GetMembers();
        }
    }
}

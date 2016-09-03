using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SKCDirectory1.Models;
using Microsoft.AspNetCore.Mvc;

namespace SKCDirectory1.Controllers
{
    public class DirectoryEntriesController : Controller
    {
        private DirectoryInfoContext _context;

        public DirectoryEntriesController(DirectoryInfoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.DirectoryEntries.ToList());
        }

    }

}

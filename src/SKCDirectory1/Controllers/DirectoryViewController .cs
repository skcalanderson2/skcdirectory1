using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SKCDirectory1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection;

namespace SKCDirectory1.Controllers
{
    public class DirectoryViewController : Controller
    {
        private DirectoryInfoContext _context;
        private IDataProtector _protector;

        public DirectoryViewController(DirectoryInfoContext context, IDataProtectionProvider provider)
        {
            _context = context;
            _protector = provider.CreateProtector(GetType().FullName);
        }

        //public DirectoryViewController(IDataProtectionProvider provider)
        //{
        //    _protector = provider.CreateProtector(GetType().FullName);
        //}

        //public async Task<IActionResult> Index(string searchString)
        //{
        //    var entries = from e in _context.DirectoryView
        //                  select e;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        entries = entries.Where(s => s.FullName.Contains(searchString));
        //    }
        //    return View(await entries.ToListAsync());
        //}

        public IActionResult Index(string searchString)
        {
            var entries = from e in _context.DirectoryView
                          select e;

            // _protector.Protect(x.Id.ToString())

            if (!String.IsNullOrEmpty(searchString))
            {
                entries = entries.Where(s => s.FullName.Contains(searchString));
            }

            IEnumerable<DirectoryView> entriesList = entries.ToList();

            entriesList = entriesList.Select(e => new DirectoryView
            {
                UserId = _protector.Protect(e.Id.ToString()),
                FullName = e.FullName,
                Email = e.Email,
                Building = e.Building,
                Department = e.Department,
                OfficeNumber = e.OfficeNumber,
                PhoneNumber = e.PhoneNumber

            });

            return View(entriesList.ToList());

        }

        public IActionResult Group(string searchString)
        {
            var entries = from e in _context.DirectoryView
                          select e;

            // _protector.Protect(x.Id.ToString())
      
            if (!String.IsNullOrEmpty(searchString))
            {
                entries = entries.Where(s => s.FullName.Contains(searchString));
            }

            IEnumerable<DirectoryView> entriesList = entries.ToList();

            entriesList = entriesList.Select(e => new DirectoryView
            {
                UserId = _protector.Protect(e.Id.ToString()),
                FullName = e.FullName,
                Email = e.Email,
                Building = e.Building,
                Department = e.Department,
                OfficeNumber = e.OfficeNumber,
                PhoneNumber = e.PhoneNumber
                
            });

            return View(entriesList.ToList());

        }

        public async Task<IActionResult> DirectoryEntry(string id)
        {
            int realid = Convert.ToInt32(_protector.Unprotect(id));
            var entry = await _context.DirectoryView.SingleOrDefaultAsync(d => d.Id == realid);
            return View(entry);
        }

    }

}

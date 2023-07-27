using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManagement.DataLayer;
using ExpenseManagement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpenseManagement.Controllers
{
    public class ExpenseController : Controller
    {
        public readonly DBContextExpMgt _context;

        public ExpenseController(DBContextExpMgt context) {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<ExpenseEntity> expensesList = _context.Expences.ToList();
            foreach (var item in expensesList)
            {
                item.ExpenseCategory = _context.ExpencesCategory.FirstOrDefault
                    (u => u.ExpenseCategoryId == item.ExpenseCategoryId);
            }
            return View(expensesList);
        }

        public IActionResult Create(ExpenseEntity expenseDetails)
        {
            IEnumerable<SelectListItem> getExpenseCatList = 
                _context.ExpencesCategory.Select(i=>new SelectListItem { 
                Text=i.ExpenseCategoryName,
                Value=i.ExpenseCategoryId.ToString()
                });

            ViewBag.PopulateExpCategory = getExpenseCatList;

            if (ModelState.IsValid) {
                _context.Expences.Add(expenseDetails);
                _context.SaveChanges();
            }
            return View(expenseDetails);
        }


        public IActionResult GetExpenceForUpdate(int? id)
        {
            IEnumerable<SelectListItem> getExpenseCatList =
               _context.ExpencesCategory.Select(i => new SelectListItem
               {
                   Text = i.ExpenseCategoryName,
                   Value = i.ExpenseCategoryId.ToString()
               });

            ViewBag.PopulateExpCategory = getExpenseCatList;

            var _ExpenseDetail = _context.Expences.Find(id);
            if (_ExpenseDetail == null) {
                return NotFound();
            }
            return View(_ExpenseDetail);
        }

       

        [HttpPost]
        public IActionResult Update(ExpenseEntity expenseDetails)
        {
            if (ModelState.IsValid) {
                _context.Expences.Update(expenseDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


       

        public IActionResult GetExpenceForDelete(int? id)
        {
            IEnumerable<SelectListItem> getExpenseCatList =
              _context.ExpencesCategory.Select(i => new SelectListItem
              {
                  Text = i.ExpenseCategoryName,
                  Value = i.ExpenseCategoryId.ToString()
              });

            ViewBag.PopulateExpCategory = getExpenseCatList;

            var _ExpenseDetail = _context.Expences.Find(id);
            if (_ExpenseDetail == null)
            {
                return NotFound();
            }
            return View(_ExpenseDetail);
        }

        public IActionResult Delete(int? ExpenseId)
        {
            var _ExpenseDetail = _context.Expences.Find(ExpenseId);
            if (_ExpenseDetail == null) {
                return NotFound();
            }
            _context.Expences.Remove(_ExpenseDetail);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}

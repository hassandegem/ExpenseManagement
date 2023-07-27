using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManagement.DataLayer;
using ExpenseManagement.Models;

namespace ExpenseManagement.Controllers
{
    public class ExpenseCategoryController : Controller
    {
        public readonly DBContextExpMgt _context;

        public ExpenseCategoryController(DBContextExpMgt dbContext) {
            _context = dbContext;
        }


        public IActionResult Index()
        {
            IEnumerable<ExpenseCategoryEntity> ExpensesCategories = _context.ExpencesCategory.ToList();
            return View(ExpensesCategories);
        }

        public IActionResult Create(ExpenseCategoryEntity ExpenseCategory)
        {
            if (ModelState.IsValid)
            {
                _context.ExpencesCategory.Add(ExpenseCategory);
                _context.SaveChanges();
            }
            return View(ExpenseCategory);
        }

        public IActionResult GetExpenceForUpdate(int? id)
        {
            var _ExpenseCatDetail = _context.ExpencesCategory.Find(id);
            if (_ExpenseCatDetail == null)
            {
                return NotFound();
            }
            return View(_ExpenseCatDetail);
        }


        [HttpPost]
        public IActionResult Update(ExpenseCategoryEntity expenseCatDetails)
        {
            if (ModelState.IsValid)
            {
                _context.ExpencesCategory.Update(expenseCatDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult GetExpenceForDelete(int? id)
        {
            var _ExpenseCatDetail = _context.ExpencesCategory.Find(id);
            if (_ExpenseCatDetail == null)
            {
                return NotFound();
            }
            return View(_ExpenseCatDetail);
        }

        public IActionResult Delete(int? ExpenseCategoryId)
        {
            var _ExpenseCatDetail = _context.ExpencesCategory.Find(ExpenseCategoryId);
            if (_ExpenseCatDetail == null)
            {
                return NotFound();
            }
            _context.ExpencesCategory.Remove(_ExpenseCatDetail);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}

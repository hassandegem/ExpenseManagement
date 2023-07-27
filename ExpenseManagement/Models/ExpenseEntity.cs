using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManagement.Models
{
    public class ExpenseEntity
    {
        public ExpenseEntity()
        {
            ExpenseDate = DateTime.Today;
        }

        [Key]
        public int ExpenseId { get; set; }

        [Required(ErrorMessage = "Please Enter Expense Date")]
        [DataType(DataType.Date)]
        [Display(Name = "Expense Date")]
        //public DateTime ExpenseDate { get; set; } = DateTime.Today;
        public DateTime ExpenseDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Please Enter Expense Gicen to Detail")]
        [MinLength(3, ErrorMessage = "The name of given to is too Short")]
        [Display(Name = "Paid To")]
        public string ExpenseGivenTo { get; set; }

        [Required(ErrorMessage = "Please Enter Amount")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid expense Amount")]
        [Display(Name = "Paid Amount")]
        public double ExpenseAmount { get; set; }

        [Display(Name = "Expense Category")]
        public int ExpenseCategoryId{ get; set; }

        [ForeignKey("ExpenseCategoryId")]
        public virtual ExpenseCategoryEntity? ExpenseCategory { get; set; }

       
    }
}

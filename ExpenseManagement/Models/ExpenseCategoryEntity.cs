using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManagement.Models
{
    public class ExpenseCategoryEntity
    {
        [Key]
        public int ExpenseCategoryId{ get; set; }

        [Required(ErrorMessage ="Please Enter Category Here")]
        [MinLength(3,ErrorMessage ="Category name is too short")]
        [MaxLength(8,ErrorMessage ="Category name not exceed more than 8 charecters")]
        public String ExpenseCategoryName { get; set; }
    }
}

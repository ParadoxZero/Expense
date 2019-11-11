/*
 * MIT License
 * 
 * Copyright (c) 2019 Sidhin S Thomas
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.Linq;
using System.Collections.Generic;
using Expense.Data;
using Expense.Enum;
using Expense.Utils;

namespace Expense.Services
{
    public class CategoryDetails
    {
        #region Properties
        public BudgetStatus BudgetStatus
        {
            get
            {
                return GetBudgetStatus(TotalExpenseThisMonth, Category.MonthlyLimit);
            }
        }
        public decimal TotalExpenseThisMonth
        {
            get
            {
                return ExpenseList.Where(x => x.Date >= GetMonthYear(DateTime.Now))
                    .Select(x => x.Amount).Sum();
            }
        }
        public ExpenseCatagory Category { get; }
        public List<ExpenseItem> ExpenseList { get; }

        #endregion

        public CategoryDetails(ExpenseCatagory catagory, List<ExpenseItem> items)
        {
            Category = catagory;
            ExpenseList = items;
        }

        public BudgetStatus GetHistoricBudgetStatus(DateTime monthYear)
        {
            return GetBudgetStatus(GetTotalofMonth(monthYear), GetMonthlyLimit(monthYear));
        }

        public decimal GetHistoricTotal(DateTime monthYear)
        {
            return GetTotalofMonth(monthYear);
        }

        #region Private Methods

        private decimal GetTotalofMonth(DateTime monthYear)
        {
            return ExpenseList.Where(x => x.Date >= new DateTime(monthYear.Year, monthYear.Month, 1))
                    .Select(x => x.Amount).Sum();
        }

        private decimal GetMonthlyLimit(DateTime monthYear)
        {
            Ensure.MonthYear(monthYear);
            if (monthYear >= Category.MonthlyLimitValidFrom) // Check if given month year if valid for current limit.
            {
                return Category.MonthlyLimit;
            }
            return GetMonthlyLimitFromArchive(monthYear);
        }

        private decimal GetMonthlyLimitFromArchive(DateTime monthYear)
        {
            Ensure.MonthYear(monthYear);
            return Category.MonthlyLimitHistory.Where(x => x.ValidFrom >= monthYear && x.ValidTo <= monthYear).First().Limit;
        }

        private DateTime GetCategoryMonthYear()
        {
            try
            {
                return Category.MonthlyLimitHistory.OrderBy(x => x.ValidFrom).Select(x => x.ValidFrom).First();
            }
            catch (InvalidOperationException)
            {
                return GetMonthYear(DateTime.Now);
            }
        }
        private BudgetStatus GetBudgetStatus(decimal amount, decimal maxAllowed)
        {
            var percentage = Calculate.Percentage(amount, maxAllowed);
            if (percentage == 0) return BudgetStatus.Empty;
            else if (percentage < 50) return BudgetStatus.Low;
            else if (percentage < 100) return BudgetStatus.High;
            else return BudgetStatus.Overflowed;
        }

        private DateTime GetMonthYear(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        #endregion
    }
}
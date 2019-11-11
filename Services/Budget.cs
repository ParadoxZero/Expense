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
using System.Collections.Generic;
using Expense.Data;

namespace Expense.Services
{
    public class Budget
    {
        public List<CategoryDetails> CategoryDetails { get; private set; }

        #region Private Data
        private IDatabaseService _databaseService;
        private List<ExpenseCatagory> Categories { get; }
        #endregion

        public Budget(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <param name="amount"></param>
        /// <param name="description"></param>
        public void AddExpense(Guid CategoryId, decimal amount, string description)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ExpenseId"></param>
        public void RemoveExpense(Guid ExpenseId)
        {
            throw new NotImplementedException();

        }

        /// <summary>
        /// Adds a new Category to budget
        /// </summary>
        /// <param name="CategoryName"></param>
        /// <param name="CategoryColor">Optionally set color of category</param>
        public void AddCategory(string CategoryName, decimal Limit, string CategoryColor = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoryId"></param>
        public void RemoveCategory(Guid CategoryId)
        {
            throw new NotImplementedException();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <param name="Limit"></param>
        public void EditCategoryLimit(Guid CategoryId, decimal Limit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <param name="Color"></param>
        public void EditCategoryColor(Guid CategoryId, string Color)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <param name="Name"></param>
        public void EditCategoryName(Guid CategoryId, string Name)
        {
            throw new NotImplementedException();
        }


        #region Private Methods
        private void UpdateFromDb()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
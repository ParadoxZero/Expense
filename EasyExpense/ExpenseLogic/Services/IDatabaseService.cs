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
using ExpenseLogic.Data;

namespace ExpenseLogic.Services
{
    public interface IDatabaseService
    {
        /// <summary>
        /// Gets a single Entity From Database
        /// Will Throw error in case of multiple result.
        /// </summary>
        /// <param name="Condition"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetEntity<T>(Func<T, bool> Condition) where T : AbstractEntity;
        /// <summary>
        /// Get a queryable set of results.
        /// </summary>
        /// <param name="Condition"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> GetEntityQueryable<T>(Func<T, bool> Condition) where T : AbstractEntity;

        /// <summary>
        /// Updates Entity in Db.
        /// Note: Entity should be an object returned from IDatabaseService. Not created
        /// using 'new' statement.
        /// </summary>
        /// <param name="Entity"></param>
        /// <typeparam name="T"></typeparam>
        public void UpdateEntity<T>(T Entity) where T : AbstractEntity;

        /// <summary>
        /// Add new entity to db.
        /// </summary>
        /// <param name="Entity"></param>
        /// <typeparam name="T"></typeparam>
        public void AddEntity<T>(T Entity) where T : AbstractEntity;
    }
}
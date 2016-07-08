﻿#region License
// The MIT License (MIT)
// 
// Copyright (c) 2016 SimplePersistence
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion
namespace SimplePersistence.UoW.EFCore
{
    using System;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Represents a work area that can be used for aggregating
    /// UoW properties, specialized for the Entity Framework Core
    /// </summary>
    /// <typeparam name="TDbContext">The database context type</typeparam>
    public abstract class EFCoreWorkArea<TDbContext> : IEFCoreWorkArea<TDbContext>
        where TDbContext : DbContext
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="context">The database context</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected EFCoreWorkArea(TDbContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            Context = context;
        }

        #region Implementation of IEFCoreWorkArea<out TDbContext>

        /// <summary>
        /// The Entity Framework database context
        /// </summary>
        public TDbContext Context { get; }

        #endregion
    }

    /// <summary>
    /// Represents a work area that can be used for aggregating
    /// UoW properties, specialized for the Entity Framework Core
    /// </summary>
    public abstract class EFCoreWorkArea : EFCoreWorkArea<DbContext>, IEFCoreWorkArea
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="context">The database context</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected EFCoreWorkArea(DbContext context) : base(context)
        {

        }
    }
}
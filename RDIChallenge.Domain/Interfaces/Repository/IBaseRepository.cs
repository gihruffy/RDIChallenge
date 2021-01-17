﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RDIChallenge.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T, in TPk> : IDisposable
    {
        T Save(T entity);
    }
}

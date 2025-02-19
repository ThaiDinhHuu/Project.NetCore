﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Common
{
    public interface IStorageService
    {
        string GetFileUrl(string fileName);
        Task DeleteFileAsync(string fileName);
        Task SaveFileAsync(Stream stream, string fileName);
    }
}

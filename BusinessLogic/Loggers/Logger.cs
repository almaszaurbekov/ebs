﻿using Common;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BusinessLogic.Loggers
{
    public interface IBookOperationsLogger
    {
        Task AddLog(string message, EbsLoggerLevel level);
        Task AddLog(string message, EbsLoggerLevel level, string objectId);
    }

    public class Logger : IBookOperationsLogger
    {
        private readonly string DefaultValue = "Пусто";
        private EbsContext _context { get; set; }
        private DbSet<Log> DbSet => _context.Set<Log>();
        public virtual Task<int> Count => DbSet.CountAsync();

        public Logger(EbsContext context)
        {
            _context = context;
        }

        public async Task AddLog(string message, EbsLoggerLevel level)
        {
            var log = new Log()
            {
                Level = level,
                LevelText = level.ToString(),
                InfluencedObjectId = DefaultValue,
                Message = message
            };

            var entry = DbSet.Add(log);
            await _context.SaveChangesAsync();
        }

        public async Task AddLog(string message, EbsLoggerLevel level, string objectId)
        {
            var log = new Log()
            {
                Level = level,
                LevelText = level.ToString(),
                InfluencedObjectId = objectId,
                Message = message
            };

            var entry = DbSet.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}
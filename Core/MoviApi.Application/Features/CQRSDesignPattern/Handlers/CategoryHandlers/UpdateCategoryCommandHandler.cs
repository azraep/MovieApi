﻿using MoviApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly MovieContext _context;

        public UpdateCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handler(UpdateCategoryCommand command)
        {
            var value = await _context.Categories.FindAsync(command.CategoryId);
            value.CategoryName = command.CategoryName;
            await _context.SaveChangesAsync();
        }
    }
}

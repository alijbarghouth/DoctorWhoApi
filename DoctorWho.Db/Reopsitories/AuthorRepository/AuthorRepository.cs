﻿using DoctorWho.Db.Context;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Reopsitories.AuthorRepository;

public sealed class AuthorRepository : IAuthorRepository
{
    private readonly ApplicationDbContext _context;

    public AuthorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> IsAuthorExists(int authorId)
    {
        return await _context.Authors
            .AsNoTracking ()
            .AnyAsync(x => x.Id == authorId);
    }
}

﻿using System;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
	public class UpdateGenreCommand
    {

		public int GenreId { get; set; }
		public UpdateGenreModel Model { get; set; }
		private readonly BookStoreDbContext _context;
		public UpdateGenreCommand(BookStoreDbContext context)
		{
			_context = context;
		}
        public void Handle(int _id)
        {
			var genre = _context.Genres.SingleOrDefault(x => x.Id == _id);
			if (genre is null)
				throw new InvalidOperationException("Kitap türü bulunamadı");
			if (_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId))
				throw new InvalidOperationException("Aynı isimle bir kitap türü zaten mevcut.");

			genre.Name = Model.Name == default ? genre.Name : Model.Name;
            genre.IsActive = Model.IsActive;
			_context.SaveChanges();
        }

        public class UpdateGenreModel
		{
			public string Name { get; set; }
			public bool IsActive { get; set; } = true;
		}
	}
}


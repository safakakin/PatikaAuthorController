﻿using System;
using FluentValidation;
using WebApi.BookOperations.CreateBooks;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{
	public class CreateGenreCommandValidator: AbstractValidator<CreateGenreCommand>
    {
		public CreateGenreCommandValidator()
		{
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
        }
	}
}


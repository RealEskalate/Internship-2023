using CineFlex.Application.Contracts.Persistence;
using CineFlex.Persistence;
using CineFlex.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly CineFlexDbContex _context;
		private IMovieRepository _MovieRepository;

		private ICinemaRepository _cinemaRepository;
		private ISeatRepository _seatRepository;
		private IPostRepository _postRepository;
		public UnitOfWork(CineFlexDbContex context)
		{
			_context = context;
		}

		public IMovieRepository MovieRepository
		{
			get
			{
				if (_MovieRepository == null)
					_MovieRepository = new MovieRepository(_context);
				return _MovieRepository;
			}
		}
		public ICinemaRepository CinemaRepository
		{
			get
			{
				if (_cinemaRepository == null)
					_cinemaRepository = new CinemaRepository(_context);
				return _cinemaRepository;
			}
		}
		
		public ISeatRepository SeatRepository
		{
			get
			{
				if (_seatRepository == null)
					_seatRepository = new SeatRepository(_context);
				return _seatRepository;
			} 
		}
		public IPostRepository PostRepository
		{
			get
			{
				if (_postRepository == null)
					_postRepository = new PostRepository(_context);
				return _postRepository;
			} 
		}


		public void Dispose()
		{
			_context.Dispose();
			GC.SuppressFinalize(this);
		}

		public async Task<int> Save()
		{
			return await _context.SaveChangesAsync();
		}
	}
}

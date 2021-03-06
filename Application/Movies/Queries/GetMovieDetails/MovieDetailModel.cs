﻿using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Application.Movies.Queries.GetMovieDetails
{
    public class MovieDetailModel
    {
        private IEnumerable<WatchModel> _watchHistory;

        public List<Genre> Genres { get; set; }

        public int Id { get; set; }

        public string Overview { get; set; }

        public string PosterUrl { get; set; }

        public string Title { get; set; }

        public bool Watched
        {
            get { return WatchHistory.Any(); }
        }

        public IEnumerable<WatchModel> WatchHistory
        {
            get
            {
                return _watchHistory ?? Enumerable.Empty<WatchModel>();
            }
            set => _watchHistory = value;
        }
    }
}
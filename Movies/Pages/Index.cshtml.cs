using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    /// <summary>
    /// The current search terms 
    /// </summary>
    [BindProperty]
    public string SearchTerms { get; set; } = "";

    /// <summary>
    /// The filtered MPAA Ratings
    /// </summary>
    [BindProperty]
    public string[] MPAARatings { get; set; }

    /// <summary>
    /// The filtered genres
    /// </summary>
    [BindProperty]
    public string[] Genres { get; set; }

    /// <summary>
    /// The minimum IMDB Rating
    /// </summary>
    [BindProperty]
    public double? IMDBMin { get; set; }

    /// <summary>
    /// The maximum IMDB Rating
    /// </summary>
    [BindProperty]
    public double? IMDBMax { get; set; }
    public class IndexModel : PageModel
    {
        /// <summary>
        /// The movies to display on the index page 
        /// </summary>
        public IEnumerable<Movie> Movies { get; protected set; }

        /// <summary>
        /// The current search terms 
        /// </summary>
        public string SearchTerms { get; set; }
        /// <summary>
        /// Gets and sets the search terms
        /// </summary>
        [BindProperty]
        public string SearchTerms { get; set; }

        /// <summary>
        /// Gets and sets the MPAA rating filters
        /// </summary>
        [BindProperty]
        public string[] MPAARating { get; set; }

        /// <summary>
        /// Gets and sets the IMDB minimium rating
        /// </summary>
        public float IMDBMin { get; set; }

        /// <summary>
        /// Gets and sets the IMDB maximum rating
        /// </summary>
        public float IMDBMax { get; set; }
        var MPAARatings = Request.Query["MPAARatings"];
        /// <summary>
        /// Gets the search results for display on the page
        /// </summary>
        /// 

        public void OnGet(double? IMDBMin, double? IMDBMax)
        {
            // Nullable conversion workaround
            this.IMDBMin = IMDBMin;
            this.IMDBMax = IMDBMax;
            Movies = MovieDatabase.Search(SearchTerms);
            Movies = MovieDatabase.FilterByMPAARating(Movies, MPAARatings);
            Movies = MovieDatabase.FilterByGenre(Movies, Genres);
            Movies = MovieDatabase.FilterByIMDBRating(Movies, IMDBMin, IMDBMax);
        }




    }
}

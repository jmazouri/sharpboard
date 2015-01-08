using System;
using System.Collections.Generic;
using SharpBoard.App.Config;

namespace SharpBoard.App.Models
{
    public class Board
    {
        /// <summary>
        /// The full name of the board
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The shorthand name for the board. This is used in URLs
        /// </summary>
        public string Shorthand { get; set; }

        /// <summary>
        /// The maximum number of pages for the board. Posts past the maximum page are deleted.
        /// </summary>
        public int MaxPages { get; set; }

        public string FullName
        {
            get { return "/" + Shorthand + "/ - " + Name; }
        }

        /// <summary>
        /// The collection of posts made to this board.
        /// </summary>
        public List<Post> Posts = new List<Post>(); 
    }
}

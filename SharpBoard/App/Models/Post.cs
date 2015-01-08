using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SharpBoard.App.Models
{
    public class Post
    {
        /// <summary>
        /// The unique ID of the post.
        /// </summary>
        public long PostId { get; set; }

        /// <summary>
        /// The ID of the original post this post is replying to.
        /// </summary>
        /// <remarks>
        /// Will be -1 if post has no parent.
        /// </remarks>
        public long ParentPostId { get; set; }

        /// <summary>
        /// Name of the user making the post.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The HTML contents of the post.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// The date and time the post was made.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Extra data for plugins.
        /// </summary>
        public Dictionary<string, PluginData> PluginData = new Dictionary<string, PluginData>(); 

        /// <summary>
        /// The board that this post belongs to.
        /// </summary>
        public Board Board { get; set; }
    }
}

using SwiftViet.Data.Models;
using System.Collections.Generic;

namespace SwiftViet.Angular
{

    /// <summary>
    /// Angular HomePage Controller
    /// </summary>
    public class HomePageController
    {

        /// <summary>
        /// List of the video that display on home page
        /// </summary>
        public List<Video> Videos { get; set; }

        /// <summary>
        /// Run when page is loaded
        /// </summary>
        public void OnLoad()
        {
            Videos = new List<Video>()
            {
                new Video
                {
                    Title = "S-White Street Drummer",
                    Code = "qVTHoXRrhq4",
                },
                new Video
                {
                    Title = "S-White Street Drummer",
                    Code = "qVTHoXRrhq4",
                },
                new Video
                {
                    Title = "S-White Street Drummer",
                    Code = "qVTHoXRrhq4",
                },
                new Video
                {
                    Title = "S-White Street Drummer",
                    Code = "qVTHoXRrhq4",
                },
                new Video
                {
                    Title = "S-White Street Drummer",
                    Code = "qVTHoXRrhq4",
                },
                new Video
                {
                    Title = "S-White Street Drummer",
                    Code = "qVTHoXRrhq4",
                },
            };
        }
    }
}

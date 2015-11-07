using SwiftViet.Data.Models;
using SwiftViet.Data.Repository;
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
        /// The video repository
        /// </summary>
        private IRepository<Video> videoRepository;


        /// <summary>
        /// The home page controller constructor
        /// </summary>
        /// <param name="videoRepository"></param>
        public HomePageController(IRepository<Video> videoRepository)
        {
            this.videoRepository = videoRepository;
        }

        /// <summary>
        /// Run when page is loaded
        /// </summary>
        public void OnLoad()
        {
            var video = new Video()
            {
                Title = "S-White Street Drummer",
                Code = "qVTHoXRrhq4"
            };

            videoRepository.Save(video);

            Videos = videoRepository.FindAll();
        }
    }
}

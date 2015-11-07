using Google.Apis.YouTube.v3;
using SwiftViet.Data.Models;
using System.Linq;

namespace SwiftViet.Angular
{

    /// <summary>
    /// Add a Video
    /// </summary>
    public class AddVideoController
    {
        /// <summary>
        /// The service
        /// </summary>
        private YouTubeService youTubeService;

        /// <summary>
        /// The video
        /// </summary>
        public Video Video { get; set;}

        /// <summary>
        /// create a new controller
        /// </summary>
        /// <param name="youTubeService"></param>
        public AddVideoController(YouTubeService youTubeService)
        {
            this.youTubeService = youTubeService;
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnLoad()
        {
            var code = "qVTHoXRrhq4";
            var request = youTubeService.Videos.List("snippet");
            request.Id = code;

            var response = request.Execute();
            var snippet = response.Items.First().Snippet;

            Video = new Video()
            {
                Title = snippet.Title,
                Description = snippet.Description,
                Code = code
            };
        }
    }
}

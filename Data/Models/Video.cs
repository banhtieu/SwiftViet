using MongoDB.Bson;


namespace SwiftViet.Data.Models
{

    /// <summary>
    /// The Youtube Video
    /// </summary>
    public class Video: Entity
    {

        /// <summary>
        /// Video Title
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// Code of the video
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Description of the video
        /// </summary>
        public string Description { get; internal set; }
    }
}

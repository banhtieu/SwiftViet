using MongoDB.Bson;


namespace SwiftViet.Data.Models
{

    /// <summary>
    /// The Youtube Video
    /// </summary>
    public class Video
    {

        /// <summary>
        /// The Object Id
        /// </summary>
        public ObjectId Id { get; set; }


        /// <summary>
        /// Video Title
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// Code of the video
        /// </summary>
        public string Code { get; set; }
    }
}

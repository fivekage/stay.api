using stay.application.Models;

namespace stay.application.Requests.Message
{
    public class FileMessagePostRequest
    {
        public FileMessagePostRequest(Stream content)
        {
            FileCustom = new FileCustom(Guid.NewGuid().ToString(), content);
        }

        /// <summary>
        /// Chat Room
        /// </summary>
        public FileCustom FileCustom { get; set; }
    }
}
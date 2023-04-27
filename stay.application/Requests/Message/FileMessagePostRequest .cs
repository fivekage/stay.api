using stay.application.Models;

namespace stay.application.Requests.Message
{
    public class FileMessagePostRequest
    {
        public FileMessagePostRequest(string name, Stream content)
        {
            FileCustom = new FileCustom(name, content);
        }

        /// <summary>
        /// Chat Room
        /// </summary>
        public FileCustom FileCustom { get; set; }
    }
}
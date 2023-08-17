using System.Net.Http;

namespace Autodesk.ModelDerivative.Model
{
    public partial class DerivativeHead : HttpResponseMessage
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DerivativeHead" /> class.
        /// </summary>
        public DerivativeHead()
        {
        }

        /// <summary>
        /// Returns true if the response is 202 - Accepted
        /// </summary>
        /// <returns>boolean based on if the response is 202 - Accepted</returns>
        public bool IsProcessing { get; internal set; } = false;

    }


}
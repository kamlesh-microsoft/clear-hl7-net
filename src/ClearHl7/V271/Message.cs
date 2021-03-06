using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClearHl7.Helpers;
using ClearHl7.Serialization;

namespace ClearHl7.V271
{
    /// <summary>
    /// HL7 Version 2 Message.
    /// </summary>
    public class Message : IMessage
    {
        /// <inheritdoc/>
        public IEnumerable<ISegment> Segments { get; set; }

        /// <inheritdoc/>
        public void FromDelimitedString(string delimitedString)
        {
            Segments = MessageSerializer.Deserialize<Message>(delimitedString).Segments;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            StringBuilder output = new();
            SegmentHelper segmentHelper = Configuration.AutoSetSubcomponentFlags ? new SegmentHelper() : null;

            if (Segments?.Any() == true)
            {
                foreach (ISegment item in Segments.OrderBy(x => x.Ordinal))
                {
                    if (Configuration.AutoSetSubcomponentFlags)
                    {
                        segmentHelper.SetSubcomponentFlags(item);
                    }

                    output.Append(item.ToDelimitedString());
                    output.Append(Consts.LineTerminator);
                }
            }

            return output.ToString();
        }
    }
}

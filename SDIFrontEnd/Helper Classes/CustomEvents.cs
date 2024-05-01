using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITCLib;

namespace SDIFrontEnd
{
    public class QuestionCommentCreated : EventArgs
    {
        public List<QuestionCommentRecord> comments;
    }

    public class ContentLabelCreated : EventArgs
    {
        public ContentLabel CreatedLabel;
    }
}

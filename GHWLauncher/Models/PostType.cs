using System.ComponentModel;

namespace GHWLauncher;

public enum PostType
{

    [Description("Activity")]
    POST_TYPE_ACTIVITY,

    [Description("Announcement")]
    POST_TYPE_ANNOUNCE,

    [Description("Information")]
    POST_TYPE_INFO,

}
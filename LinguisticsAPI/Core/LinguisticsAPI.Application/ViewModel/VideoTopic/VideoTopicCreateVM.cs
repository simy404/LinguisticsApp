namespace LinguisticsAPI.Application.ViewModel.VideoTopic;

public class VideoTopicCreateVM
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public ICollection<VideoLinkCreateVM> VideoLinks { get; set; }
}
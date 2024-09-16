namespace LinguisticsAPI.Application.ViewModel.VideoTopic;

public class VideoTopicVM
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public ICollection<VideoLinkVM> VideoLinks { get; set; }
}
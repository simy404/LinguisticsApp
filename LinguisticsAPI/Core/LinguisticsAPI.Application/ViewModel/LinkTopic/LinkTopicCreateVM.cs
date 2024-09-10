namespace LinguisticsAPI.Application.ViewModel.LinkTopic;

public class LinkTopicCreateVM
{
    public string Title { get; set; }
    public Guid? ParentId { get; set; }
    public IEnumerable<LinkCreateVM> Links { get; set; }
}
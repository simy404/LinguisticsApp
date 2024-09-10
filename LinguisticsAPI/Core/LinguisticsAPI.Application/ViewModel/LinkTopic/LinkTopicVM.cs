namespace LinguisticsAPI.Application.ViewModel.LinkTopic;

public class LinkTopicVM
{
    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }
    public string Title { get; set; }
    public IEnumerable<LinkVM> Links { get; set; }
    public IEnumerable<LinkTopicVM> SubTopics { get; set; }
    
}
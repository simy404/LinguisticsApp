﻿using LinguisticsAPI.Application.DTOs;
using LinguisticsAPI.Application.RequestParameters.Common;
using LinguisticsAPI.Application.ViewModel.News;

namespace LinguisticsAPI.Application.Abstraction.News;

public interface INewsService
{
    Task<List<NewsVM>> GetAllNews(string? languageCode);
    Task<NewsVM> GetNewsById(Guid id, string? languageCode);
    
    Task CreateNews(NewsCreateVM newsVM, string userId);
}
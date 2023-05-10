﻿namespace BlogApp.Application.Features.Reviews.DTOs;

public class CreateReviewDto : IReviewDto
{
    public int BlogId { get; set; }
    public string ReviewerId { get; set; }
    public string Comment { get; set; }
    public bool IsResolved { get; set; }
}
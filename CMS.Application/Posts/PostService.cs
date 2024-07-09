using CMS.Application.Posts.Models;
using CMS.Application.Posts.Interfaces;
using CMS.Infraestructure.Repositories.Posts;
using CMS.Infraestructure.Repositories.Tags;
using CMS.Domain.Tags;
using System.Collections.Generic;

namespace CMS.Application.Posts
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ITagRepository _tagRepository;
        public PostService(IPostRepository postRepository, ITagRepository tagRepository)
        {
            _postRepository = postRepository;
            _tagRepository = tagRepository;
        }

        public async Task<PostDto> CreateAsync(PostCreateDto input)
        {

            var tagIdsToAdd = input.Tags.Select(x => x.Id).ToList();
            var tags = await _tagRepository.GetByIdsAsync(tagIdsToAdd);

            var postEntity = new Domain.Posts.Post
            {
                MainImage = input.MainImage,
                Content = input.Content,
                Description = input.Description,
                PersonId = input.PersonId,
                PublishDate = input.PublishDate,
                Title = input.Title,
                Tags = tags,
                CreatedBy = "API Call", //TODO: Get User from context
            };

            postEntity = await _postRepository.CreateAsync(postEntity);

            var mappedDto = new PostDto
            {
                Id = postEntity.Id,
                Content = postEntity.Content,
                Description = postEntity.Description,
                PublishDate = postEntity.PublishDate,
                Title = postEntity.Title,
                PersonId = postEntity.PersonId,
                MainImage = input.MainImage,
                Tags = postEntity.Tags.Select(x => new PostTagDto
                {
                    Id = x.Id,
                }).ToList()
            };

            return mappedDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _postRepository.DeleteAsync(id);
            return result;  
        }

        public async Task<List<PostDto>> GetAllAsync()
        {
            var posts = await _postRepository.GetAllAsync();

            var mappedPosts = posts.Select(x => new PostDto
            {
                Id = x.Id,
                Content =x.Content,
                Description = x.Description,
                PublishDate = x.PublishDate,
                Title = x.Title,
                MainImage = x.MainImage,
                Tags = x.Tags.Select(y => new PostTagDto { Id = y.Id}).ToList()
            }).ToList();

            return mappedPosts;
        }

        public async Task<PostDto> GetByIdAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);

            return new PostDto
            {
                Id =post.Id,
                Content=post.Content,
                Description = post.Description,
                PublishDate = post.PublishDate,
                Title = post.Title,
                MainImage = post.MainImage,
                PersonId = post.PersonId,
                Tags = post.Tags.Select(y => new PostTagDto { Id = y.Id }).ToList()
            };
        }

        public async Task<PostDto> UpdateAsync(PostDto input)
        {
            var postEntity = await _postRepository.GetByIdAsync(input.Id);

            var tagIdsToAdd = input.Tags.Select(x => x.Id).ToList();
            var tags = await _tagRepository.GetByIdsAsync(tagIdsToAdd);
            tagIdsToAdd.RemoveAll(item => tags.Any(x => x.Id == item));

            postEntity.Description = input.Description;
            postEntity.PublishDate = input.PublishDate;
            postEntity.Title = input.Title;
            postEntity.Tags = tags;

            postEntity = await _postRepository.UpdateAsync(postEntity);

            var mappedDto = new PostDto
            {
                Id = postEntity.Id,
                Content = postEntity.Content,
                Description = postEntity.Description,
                PublishDate = postEntity.PublishDate,
                Title = postEntity.Title,
                Tags = postEntity.Tags.Select(x => new PostTagDto
                {
                    Id = x.Id,
                }).ToList()
            };

            return mappedDto;
        }


    }
}

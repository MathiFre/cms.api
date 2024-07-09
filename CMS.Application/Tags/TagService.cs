using CMS.Application.Tags.Models;
using CMS.Infraestructure.Repositories.Tags;

namespace CMS.Application.Tags
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        public TagService(ITagRepository tagRepository)
        {
           _tagRepository = tagRepository;
        }

        public async Task<TagDto> CreateAsync(TagCreateDto tag)
        {
            var createdTag = await _tagRepository.CreateAsync(new Domain.Tags.Tag
            {
                Name = tag.Name
            });

            return new TagDto
            {
                Id = createdTag.Id,
                Name = createdTag.Name,
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _tagRepository.DeleteAsync(id);
            return result;
        }

        public async Task<ICollection<TagDto>> GetAllAsync()
        {
            var tags = await _tagRepository.GetAllAsync();

            return tags.Select(x => new TagDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
         }

        public async Task<TagDto> GetByIdAsync(int id)
        {
            var tag = await _tagRepository.GetByIdAsync(id);

            return new TagDto 
            { 
                Id = tag.Id, 
                Name = tag.Name 
            };
        }

        public async Task<TagDto> UpdateAsync(TagDto tag)
        {
            var tagEntity = await _tagRepository.GetByIdAsync(tag.Id);

            tagEntity.Name = tag.Name;
            tagEntity = await _tagRepository.UpdateAsync(tagEntity);

            return new TagDto
            {
                Id = tagEntity.Id,
                Name = tagEntity.Name
            };
        }
    }
}

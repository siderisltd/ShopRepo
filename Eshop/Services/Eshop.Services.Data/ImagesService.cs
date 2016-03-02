namespace Eshop.Services.Data
{
    using System;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Runtime.Caching;
    using Base;
    using Common.Contracts;
    using Contracts;
    using DTO;
    using Eshop.Data.Repositories;
    using Microsoft.AspNet.Identity;
    using Image = Eshop.Data.Models.Image;

    public class ImagesService : BaseService<Image> , IImagesService
    {
        private readonly IImageHelper imageHelper;

        private System.Drawing.Image BrandImage
        {
            get
            {
                ObjectCache cache = MemoryCache.Default;
                System.Drawing.Image brandImage = cache["brandImage"] as System.Drawing.Image;
                if (brandImage == null)
                {
                    var brandImg = System.Drawing.Image.FromFile(GlobalConstants.Services.APP_ROOT_PATH + "Content\\Uploads\\Brand\\brand.png");
                    cache["brandImage"] = brandImg;
                    brandImage = brandImg;
                }
                return brandImage;
            }
        }

        private readonly string rootImagesFolder = GlobalConstants.Services.ROOT_IMAGES_FOLDER;

        public ImagesService(IRepository<Image> repo, IImageHelper imageHelper)
            :base(repo)
        {
            this.imageHelper = imageHelper;
        }

        public Image SaveImageFromWeb(string url, string title, ImageFormat imageFormat, string authorId)
        {
            var date = DateTime.Now.ToString("MM.yyyy");
            var image = new Image();
            image.Title = title;
            image.AuthorId = authorId;
            this.repo.Add(image);
            this.repo.SaveChanges();
            var imagePath = date + "\\" + (image.Id % GlobalConstants.Services.MAX_FILES_IN_DIRECTORY);
            image.PathOriginalSize = imagePath + "\\ori_" + image.Title + ".jpg";
            image.PathResizedImage = imagePath + "\\400_" + image.Title + ".jpg";


            var directory = this.rootImagesFolder + imagePath;
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            byte[] originalImageArray = this.imageHelper.GetFromUrlAndBrandImage(url, imageFormat, this.BrandImage);
            var resizedImageArray400 = this.imageHelper.ScaleImage(this.imageHelper.ByteToImage(originalImageArray), 400, imageFormat);

            File.WriteAllBytes(this.rootImagesFolder + "\\" + image.PathOriginalSize, originalImageArray);
            File.WriteAllBytes(this.rootImagesFolder + "\\" + image.PathResizedImage, resizedImageArray400);

            this.repo.SaveChanges();

            return image;
        }

        public int SaveImage(Image image, ImageFormat imageFormat, bool addBrand = false)
        {
            var date = DateTime.Now.ToString("MM.yyyy");

            var imagePath = date + "\\" + (image.Id % GlobalConstants.Services.MAX_FILES_IN_DIRECTORY);
            image.PathOriginalSize = imagePath + "\\ori_" + image.Title + ".jpg";
            image.PathResizedImage = imagePath + "\\400_" + image.Title + ".jpg";


            var directory = this.rootImagesFolder + imagePath;
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            byte[] originalImageArray = this.imageHelper.StreamToByteArray(image.Stream);

            if (addBrand)
            {
                originalImageArray = this.imageHelper.AddBranding(originalImageArray, this.BrandImage, imageFormat);
            }

            var resizedImageArray400 = this.imageHelper.ScaleImage(this.imageHelper.ByteToImage(originalImageArray), 400, imageFormat);

            File.WriteAllBytes(this.rootImagesFolder + "\\" + image.PathOriginalSize, originalImageArray);
            File.WriteAllBytes(this.rootImagesFolder + "\\" + image.PathResizedImage, resizedImageArray400);

            this.repo.SaveChanges();

            return image.Id;
        }

        public PagedImageDTO AllPaged(int page, int pageSize)
        {
            var dto = new PagedImageDTO();
            var allImagesCount = this.repo.All().Count();
            dto.AllItemsCount = allImagesCount;
            dto.CurrentPage = page;
            dto.TotalPages = (int)Math.Ceiling(allImagesCount / (decimal)pageSize);

            var itemsToSkip = (page - 1) * pageSize;

            var query = this.repo.All();

            var images = query
                .OrderByDescending(x => x.CreatedOn)
                .Skip(itemsToSkip)
                .Take(pageSize)
                .AsQueryable();

            dto.Images = images;

            return dto;
        }
    }
}


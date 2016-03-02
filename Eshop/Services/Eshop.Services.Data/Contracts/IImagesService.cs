namespace Eshop.Services.Data.Contracts
{
    using System.Drawing.Imaging;
    using Base;
    using DTO;
    using Eshop.Data.Models;

    public interface IImagesService : IBaseService<Image>
    {
        int SaveImage(Image model, ImageFormat imageFormat, bool addBrand = false);

        PagedImageDTO AllPaged(int page, int pageSize);

        Image SaveImageFromWeb(string url, string title, ImageFormat imageFormat, string authorId);
    }
}

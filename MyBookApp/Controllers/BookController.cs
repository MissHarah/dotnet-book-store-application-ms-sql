using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBookApp.Models;
using MyBookApp.Repository;

namespace MyBookApp.Controllers
{
    public class BookController : Controller

    {
        private readonly IBookRepository? _bookrepository = null;
        private readonly ILanguageRepository? _Languagerepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(IBookRepository bookRepository,
            ILanguageRepository? languagerepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _bookrepository = bookRepository;
            _Languagerepository = languagerepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task <IActionResult> GetAllBook()
        {
            var data = await _bookrepository.GetAllBook();
            return View(data);
        }
        [Route("book-details/{id}")]
        public async Task <IActionResult> GetBook(int id)
        {
            var data = await _bookrepository.GetBookById(id);
            return View(data);
        }
        public List<Bookmodel> SearchBook(string bookName, string authorName)
        {
            return _bookrepository.searchAllBook(bookName, authorName);
        }
        public async Task<IActionResult> AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            var model = new Bookmodel();
         //   ViewBag.Language = new SelectList(await _Languagerepository.GetLanguages(), "Id,","name");
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(Bookmodel bookModel)
        {
            if (ModelState.IsValid)
            {
                if (bookModel.CoverPhoto != null)
                {
                    string folder = "books/cover/";
                   bookModel.CoverImageUrl= await UploadImage(folder,bookModel.CoverPhoto);
                }
                if (bookModel.Galleryfiles != null)
                {
                    string folder = "books/gallery/";

                    bookModel.Gallery = new List<GalleryModel>();

                    foreach (var file in bookModel.Galleryfiles)
                    {
                        var gallery = new GalleryModel() {
                            Name = file.FileName,
                            URL = await UploadImage(folder, file)
                    };
                        bookModel.Gallery.Add(gallery);
                        
                    }
                }

                if (bookModel.Bookpdf != null)
                {
                    string folder = "books/pdf/";
                    bookModel.BookpdfUrl = await UploadImage(folder, bookModel.Bookpdf);
                }
                    int id = await _bookrepository.AddNewBook(bookModel);
                
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }
            ViewBag.Language = new SelectList(await _Languagerepository.GetLanguages(), "Id,", "name");
            return View();
        }

        private async Task<string> UploadImage(string folderPath,IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/" + folderPath;
        }
        //   ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");
        // private List<LanguageModel> GetLanguage();
    }
}

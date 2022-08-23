using BL;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using System.Security.Claims;

namespace WebApp.Controllers
{
    public class ForumController : Controller
    {

        private ITopicRepository _topicRepository;
        private IPostRepository _postRepository;
        private IUserRepository _userRepository;

        public ForumController(ITopicRepository topicRepository, IPostRepository postRepository, IUserRepository userRepository)
        {
            _topicRepository = topicRepository;
            _postRepository = postRepository;
            _userRepository = userRepository;
        }
        public async Task<IActionResult> TopicList()
        {

            var user = UserViewModel.GetUserByName(User.Identity.Name, _userRepository);

            if (user != null)
            {
                if (user.IsConfirmed)
                    return View(TopicViewModel.GetTopicList(_topicRepository));
            }

            return RedirectToAction("Confirm", "User", new { message = "Login or register" });

        }

        public async Task<IActionResult> CreateTopic(IFormCollection formCollection)
        {
            string name = formCollection["name"];
            var user = UserViewModel.GetUserByName(User.Identity.Name, _userRepository);

            if (!String.IsNullOrEmpty(name) && user != null)
            {
                var topic = new TopicViewModel() { Name = name, DateCreated = DateTime.Now, UserId = user.Id };
                await _topicRepository.AddItemAsync(topic);
            }

            return RedirectToAction("TopicList");
        }
        public async Task<IActionResult> CreatePost(IFormCollection formCollection)
        {
            string message = formCollection["message"];
            var smth = formCollection["topicId"];
            Guid topicId = Guid.Parse(smth.ToString());
            var user = UserViewModel.GetUserByName(User.Identity.Name, _userRepository);

            if (!String.IsNullOrEmpty(message))
            {
                await _postRepository.AddItemAsync(new PostViewModel() { Message = message, TopicId = topicId, DateCreated = DateTime.Now, UserId = user.Id });
            }

            return RedirectToAction("Details", new { id = topicId });
        }

        public async Task<IActionResult> Details(Guid id)
        {
            ViewBag.TopicId = id;
            ViewBag.TopicName = TopicViewModel.GetTopicById(id, _topicRepository).Name;
            return View(PostViewModel.GetPostList(_postRepository, id));
        }


        public async Task<IActionResult> DeleteTopic(Guid? id)
        {
            if (id.HasValue)
            {
                await _postRepository.DeleteItemsAsync(_postRepository.AllItems.Where(post => post.TopicId == id));
                await _topicRepository.DeleteItemAsync(id.Value);
            }
            return RedirectToAction("TopicList");
        }
        public async Task<IActionResult> DeletePost(Guid? id, Guid topicId)
        {
            if (id.HasValue)
            {
                await _postRepository.DeleteItemAsync(id.Value);
            }

            ViewBag.TopicId = topicId;
            return RedirectToAction("Details", new { id = topicId });
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            return View(PostViewModel.GetPostById(id, _postRepository));
        }
        public async Task<IActionResult> AcceptEdit(PostViewModel model)
        {
            if (!model.IsEmpty)
            {
                await _postRepository.ChangeItemAsync(model);
            }
            return RedirectToAction("Details", new { id = model.TopicId });
        }



    }
}

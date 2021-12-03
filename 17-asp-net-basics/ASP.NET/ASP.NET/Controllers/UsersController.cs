using BLL;
using DAL.DB;
using Entities;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASP.NET.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserBL _userBL;
        private readonly IRewardBL _rewardBL;
        public UsersController(IUserBL userBL, IRewardBL rewardBL)
        {
            //_userBL = new UserManager(new UserDBDAO());
            //_rewardBL = new RewardManager(new RewardDBDAO());
            _userBL = userBL;
            _rewardBL = rewardBL; 
        }
        public IActionResult Index()
        {
            
            var users = _userBL.GetAllUsers();
            return View(users);
            
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var users = _userBL.GetAllUsers();
            foreach(var user in users)
            {
                if (id == user.ID) { _userBL.DeleteUser(user); }
            }  
           
            return RedirectToAction("Index", "Users");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var users = _userBL.GetAllUsers();
            User user = users.Where(u => u.ID == id).FirstOrDefault();
            ViewBag.Rewards = _rewardBL.GetAllRewards();  
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(int id, string newName, string newLastname, DateTime newBirthDate, int[] newRewards)
        {
            var users = _userBL.GetAllUsers();
            User user = users.Where(u => u.ID == id).FirstOrDefault();
            var rewards = _rewardBL.GetAllRewards();

            List<Reward> rewardsList = rewards.Where(r => newRewards.Contains(r.ID)).ToList();
            _userBL.EditUser(user, newName, newLastname, newBirthDate, rewardsList);
            return RedirectToAction("Index", "Users");
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Rewards = _rewardBL.GetAllRewards();
            return View();
        }
        [HttpPost]
        public IActionResult Add(string Name, string Lastname,  DateTime Birthdate, int[] Rewards)
        {
            User user = new Entities.User(Birthdate, Name, Lastname);
            var rewards = _rewardBL.GetAllRewards();
            List<Reward> rewardsList = rewards.Where(r => Rewards.Contains(r.ID)).ToList();
            user.Rewards = rewardsList;
            _userBL.AddUser(user);  
            return RedirectToAction("Index", "Users");
        }
    }
}

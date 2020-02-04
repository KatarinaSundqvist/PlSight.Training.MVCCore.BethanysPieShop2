﻿using BethanysPieShop2.Models;
using BethanysPieShop2.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace BethanysPieShop2.Controllers {
    public class HomeController : Controller {

            private readonly IPieRepository _pieRepository;

            public HomeController(IPieRepository pieRepository) {
                _pieRepository = pieRepository;
            }

            public IActionResult Index() {
                var homeViewModel = new HomeViewModel {
                    PiesOfTheWeek = _pieRepository.PiesOfTheWeek
                };

                return View(homeViewModel);
            }
        }
    }
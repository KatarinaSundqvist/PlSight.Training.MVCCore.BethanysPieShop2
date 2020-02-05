﻿using BethanysPieShop2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BethanysPieShop2.Components {
    public class CategoryMenu : ViewComponent {

        private readonly ICategoryRepository _categoryRepository;
        public CategoryMenu(ICategoryRepository categoryRepository) {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke() {
            var categories = _categoryRepository.AllCategories.OrderBy(c => c.CategoryName);
            return View(categories);
        }
    }
}
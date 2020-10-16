﻿using Queries.Persistence;

namespace Queries
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork(new PlutoContext()))
            {
                // ReSharper disable once InvalidXmlDocComment
                /**
                 * App Structure
                 *
                 * - Presentation
                 * -- Form
                 * -- ViewModel
                 * -- Controller
                 *
                 * - Business Logic / Core
                 * -- Domain
                 * -- IRepositories
                 * -- IUnitOfWork
                 *
                 * - Data Access / Persistence
                 * -- Entity Configurations
                 * -- Repositories
                 * -- DbContext
                 * -- UnitOfWork
                 */

                // Example1
                var course = unitOfWork.Courses.Get(1);

                // Example2
                var courses = unitOfWork.Courses.GetCoursesWithAuthors(1, 4);

                // Example3
                var author = unitOfWork.Authors.GetAuthorWithCourses(1);
                unitOfWork.Courses.RemoveRange(author.Courses);
                unitOfWork.Authors.Remove(author);
                unitOfWork.Complete();
            }
        }
    }
}
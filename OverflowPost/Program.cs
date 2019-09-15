using System;
using System.Collections.Generic;
using System.Linq;

namespace OverflowPost
{
    public class PostList
    {
        public static List<Post> Post_List;
        public PostList()
        {
            Post_List = new List<Post>();
        }
        public Post this[int Id]
        {
            get { return Post_List[Id]; }
            set { Post_List[Id] = value; }
        }
        public Post this[string title]
        {
            get { return Post_List.First(item => item.Title == title); }
        }
        public static void SortList()
        {
            Post_List = PostList.Post_List.OrderByDescending(p => p.Votes).ToList();
        }
    }
    public class Post
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDT { get; set; }
        public int Votes { get; private set; }
        public Post()
        {
            PostList.Post_List.Add(this);
            this.CreationDT = DateTime.Now;
            this.Votes = 0;
        }
        public void UpVote()
        {
            this.Votes++;
            PostList.SortList();
        }
        public void DownVote()
        {
            this.Votes--;
            PostList.SortList();

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var postList = new PostList();
            postList[0] = new Post { Title = "Bad Post", Description = "Post1 Description" };
            postList[1] = new Post { Title = "Okay Post", Description = "Post2 Description" };
            postList[2] = new Post { Title = "Really Awesome Post", Description = "Post3 Description" };
            DisplayPosts();
            postList["Really Awesome Post"].UpVote();
            postList["Okay Post"].UpVote();
            postList["Bad Post"].DownVote();
            DisplayPosts();
            postList["Really Awesome Post"].UpVote();
            postList["Okay Post"].DownVote();
            postList["Bad Post"].DownVote();
            DisplayPosts();
            postList[3] = new Post { Title = "Okay Late Post", Description = "Post4 Description" };
            postList["Really Awesome Post"].UpVote();
            postList["Okay Post"].UpVote();
            postList["Bad Post"].DownVote();
            DisplayPosts();

        }

        private static void DisplayPosts()
        {
            Console.Clear();
            foreach (var post in PostList.Post_List)
            {
                Console.WriteLine("======================");
                Console.WriteLine("Title: {0}", post.Title);
                Console.WriteLine("Description: {0}", post.Description);
                Console.WriteLine("Votes: {0}", post.Votes);
            }
            Console.ReadKey();
        }
    }
}

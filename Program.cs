using System;
using System.Globalization;
using System.Text;
using ConsoleApp1;

namespace ConsoleApp1
{
    class Comment
    {
        public string Text { get; set; }
    }
    class Post
    {
        public required string Title { get; set; }
        public string Content { get; set; }
        private DateTime Date = DateTime.Now;
        public List<Comment> Comments = new List<Comment>();

        public void addComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine(Title);
            s.AppendLine(Content);
            s.AppendLine(Date.ToString("dd/MM/yyyy HH/mm/ss"));
            
            s.AppendLine("Comments: ");
            foreach(Comment c in Comments)
            {
                s.AppendLine(c.Text);
            }
            return s.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Comment newComment = new Comment {Text="Hello"};
            Post newPost = new Post {Title="First book", Content="First Post on this page"};
            newPost.addComment(newComment);
            Console.WriteLine(newPost);
        }
    }
}
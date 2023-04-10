using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;

public class Solution
{
    public static void Main(string[] args)
    {
        IEnumerable<Comment> comments = Enumerable
            .Repeat(0, int.Parse(Console.ReadLine()))
            .Select(_ => Comment.Create(Console.ReadLine()))
            .Aggregate(ImmutableList<Comment>.Empty, (x, y) => y.IsReply ? x.SetItem(x.Count - 1, x[x.Count - 1].AddReply(y)) : x.Add(y))
            .Select(x => x.SortReplies());

        SortComments(comments).ToList().ForEach(x => Console.WriteLine(x.ToString()));        
    }

    private static ImmutableList<Comment> SortComments(IEnumerable<Comment> comments) => comments
        .OrderBy(x => x.Priority == "Pinned" ? 0 : x.Priority == "Followed" ? 1 : 2)
        .ThenByDescending(x => x.Likes)
        .ThenByDescending(x => x.Hours)
        .ThenByDescending(x => x.Minutes)
        .ToImmutableList();

    private class Comment
    {
        private readonly string m_rawComment;

        public byte Hours { get; }

        public byte Minutes { get; }

        public uint Likes { get; }

        public string Priority { get; }

        public bool IsReply { get; }

        public ImmutableList<Comment> Replies { get; }

        private Comment
        (
            string rawComment,
            byte hours,
            byte minutes,
            uint likes,
            string priority,
            bool isReply,
            ImmutableList<Comment> replies
        )
        {
            m_rawComment = rawComment;
            Hours = hours;
            Minutes = minutes;
            Likes = likes;
            Priority = priority;
            IsReply = isReply;
            Replies = replies;
        }

        public Comment AddReply(Comment reply) => new Comment(m_rawComment, Hours, Minutes, Likes, Priority, IsReply, Replies.Add(reply));

        public Comment SortReplies() => new Comment(m_rawComment, Hours, Minutes, Likes, Priority, IsReply, SortComments(Replies));

        public override string ToString() => string.Join(Environment.NewLine, ImmutableList.Create(m_rawComment).AddRange(Replies.Select(x => x.ToString())));

        public static Comment Create(string rawComment)
        {
            string[] splitRawComment = rawComment.Split('|');
            string[] splitTime = splitRawComment[1].Split(':');
            bool isReply = splitRawComment[0].StartsWith("    ");

            return new Comment
            (
                rawComment,
                byte.Parse(splitTime[0]),
                byte.Parse(splitTime[1]),
                uint.Parse(splitRawComment[2]),
                splitRawComment[3],
                splitRawComment[0].StartsWith("    "),
                ImmutableList<Comment>.Empty
            );
        }
    }
}
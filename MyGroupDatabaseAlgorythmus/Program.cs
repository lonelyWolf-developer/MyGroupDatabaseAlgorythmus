
using MyGroupDatabaseAlgorythmus;

List<Comment> comments = new List<Comment>
{
	new Comment( 1, null, 8),
	new Comment( 2, null, 9),
	new Comment( 3, 2, 10),
	new Comment( 4, 3, 11),
	new Comment( 5, 3, 12),
	new Comment( 6, null, 13),
	new Comment( 7, 6, 14),
	new Comment( 8, 4, 15),
	new Comment( 9, 5, 16),
	new Comment( 10, 11, 17),
	new Comment( 11, null, 18)
};

List<Comment> queryWithoutParrent = comments.Where(c => c.ParrentCommentId == null).OrderByDescending(c => c.Sent).ToList();

foreach (Comment comment in queryWithoutParrent)
{
    Console.WriteLine(comment.CommentId);
}

Console.WriteLine();

var queryWithParrent = from c in comments
					   where c.ParrentCommentId != null
					   orderby c.Sent descending
					   group c by c.ParrentCommentId;

var queryVariable = queryWithParrent.ToList();

List<Comment> endsCollection = queryWithoutParrent;

for (int i = 0; i < queryWithoutParrent.Count; i++)
{
	for(int j = 0; j < queryVariable.Count; j++)
	{
		if (queryWithoutParrent[i].CommentId == queryVariable[j].First().ParrentCommentId)
		{
			endsCollection.InsertRange(i + 1, queryVariable[j]);
			queryVariable.Remove(queryVariable[j]);
		}
	}	
}

foreach(Comment comment in endsCollection)
    Console.WriteLine(comment.CommentId);

Console.ReadKey();
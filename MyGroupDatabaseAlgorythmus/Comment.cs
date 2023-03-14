using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroupDatabaseAlgorythmus
{
	public class Comment
	{
		public Comment(int commentId, int? parrentCommentId, int sent)
		{
			CommentId = commentId;
			ParrentCommentId = parrentCommentId;
			Sent = sent;
		}

		public int CommentId {  get; set; }

		public int? ParrentCommentId { get; set; }

		public int Sent { get; set; }
	}
}

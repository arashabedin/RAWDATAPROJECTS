using System;
using System.Collections.Generic;
using System.Text;
using DataService.DomainModel;
using DataService.DTO;


namespace DataService.DataAccessLayer
{
    public interface Repository
    {
        //Annotations

        //Post
        PostDTO GetPostById();
        ICollection<PostDTO> GetPosts();

        //PostType
        PostTypeDTO GetPostTypeByPostId();

        //Answer
        AnswerDTO GetAnswer();
        ICollection<AnswerDTO> GetAnswersByQuestionId();

        //Answer
        QuestionDTO GetQuestions();
        QuestionDTO GetQuestionByAnswreId();

        //Comment
        CommentDTO GetComment();
        ICollection<CommentDTO> GetCommentsByPostId();

 

        //PostTags
        ICollection<PostTagsDTO> GetPostTagsByPostId();


        //UserInfo

        UserInfoDTO GetUserByPostId();
        ICollection<PostDTO> GetAllPostsByUserId();
        ICollection<QuestionDTO> GetAllQuestionsByUserID();
        ICollection<AnswerDTO> GetAllAnswersByUserId();


    }
}

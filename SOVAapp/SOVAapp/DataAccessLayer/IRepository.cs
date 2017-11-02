using System;
using System.Collections.Generic;
using System.Text;
using DataService.DomainModel;
using DataService.DTO;


namespace DataService.DataAccessLayer
{
    public interface IRepository
    {



        //Post
        PostDTO GetPostById(int id);
        ICollection<PostDTO> GetPosts();
        ICollection<PostDTO> GetAllPostsByUserId(int id);
        int CountPosts();

        //PostType
        PostTypeDTO GetPostTypeByPostId(int id);
        

        //Answer
        ICollection<Post> GetAnswers(int page, int pageSize);
        AnswerDTO GetAnswerById(int id);
        ICollection<AnswerDTO> GetAllAnswersByUserId(int id, int page, int pageSize);
        ICollection<AnswerDTO> GetAllAnswersByQuestionId(int id, int page, int pageSize);
        int CountAnswers();
        int CountAnswersByUserId(int id);
        int CountAnswersByQuestionId(int id);

        //Question
        QuestionDTO GetQuestionById(int id);
        QuestionDTO GetQuestionByAnswerId(int id);
        ICollection<Post> GetQuestions(int page, int pageSize);
        ICollection<QuestionDTO> GetAllQuestionsByUserID(int id);
        int CountQuestions();
        int CountQuestionsByUserId(int id);

        //Comment
        CommentDTO GetCommentById(int id);
        ICollection<CommentDTO> GetComments();
        ICollection<CommentDTO> GetCommentsByPostId(int postId);
        int CountComments();

        //Tags
        TagsDTO GetTagByPostTagId(int id);
        TagsDTO GetTagByID(int id);
        ICollection<TagsDTO> GetTags();
        int CountTags();
 

        //PostTags
        ICollection<PostTagsDTO> GetPostTagsByPostId(int id);
        int CountPostTags();


        //UserInfo
        ICollection<UserInfoDTO> GetUsers(int page, int pageSize);
        UserInfoDTO GetUserById(int id);
        UserInfoDTO GetUserByPostId(int id);
        UserInfoDTO GetUserByCommentId(int id);
        int CountUsers();
       

        //Markings
        Boolean AddMarking(int postId);
        Boolean RemoveMarking(int id);

        //Annotations
        Boolean AddAnnotation();
        Boolean EditAnnotation();
        Boolean DeleteAnnotation(int id);
        AnnotationsDTO GetAnnotationById(int id);
        ICollection<AnnotationsDTO> GetAnnotations();
        int CountAnnotations();

        //SearchHistory
        Boolean AddSearchHistory(String SearchText);
        SearchHistoryDTO GetSearchHistoryById(int id);
        ICollection<SearchHistoryDTO> GetSearchHistories();
        int GetNumberOfSearches();

        //FavoriteTags
        Boolean AddFavoriteTags();
        Boolean RemoveFavoriteTags(int id);
        ICollection<FavoriteTagsDTO> GetFavoriteTagsByCustomeId(int id);
        int CountFavoriteTags();

        //UserCustomeField
        Boolean AddUserCustomeField();
        Boolean DeleteUserCustomeField(int id);
        UserCustomeFieldDTO GetUserCustomeFieldById(int id);
        ICollection<UserCustomeFieldDTO> GetUserCustomeFields();
        int CountUserCustomeFields();

      


    }
}

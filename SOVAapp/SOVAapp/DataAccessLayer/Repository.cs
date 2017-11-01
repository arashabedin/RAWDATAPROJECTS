using System;
using System.Collections.Generic;
using System.Text;
using DataService.DomainModel;
using DataService.DTO;


namespace DataService.DataAccessLayer
{
    public interface Repository
    {



        //Post
        PostDTO GetPostById(int id);
        ICollection<PostDTO> GetPosts();
        int CountPosts();

        //PostType
        PostTypeDTO GetPostTypeByPostId(int id);
        

        //Answer
        AnswerDTO GetAnswerById(int id);
        ICollection<AnswerDTO> GetAllAnswersByUserId(int id);
        ICollection<AnswerDTO> GetAllAnswersByQuestionId(int id);
        int CountAnswers();

        //Question
        QuestionDTO GetQuestionById(int id);
        QuestionDTO GetQuestionByAnswreId(int id);
        ICollection<QuestionDTO> GetQuestions();
        int CountQuestions();

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

        UserInfoDTO GetUserByPostId(int id);
        UserInfoDTO GetUserByCommentId(int id);
        ICollection<PostDTO> GetAllPostsByUserId(int id);
        ICollection<QuestionDTO> GetAllQuestionsByUserID(int id);


        int CountUsers();
        int CountAnswersByUserId(int id);
        int CountQuestionsByUserId(int id);

        //Markings
        Boolean AddMarking(int postId);
        Boolean RemoveMarking(int id);

        //Annotations
        Boolean AddAnnotation();
        Boolean DeleteAnnotation(int id);
        Boolean EditAnnotation();
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

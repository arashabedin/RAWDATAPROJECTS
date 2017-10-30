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
        PostTypeDTO GetPostTypeByPostId();
        

        //Answer
        AnswerDTO GetAnswerById(int id);
        ICollection<AnswerDTO> GetAnswersByQuestionId();
        int CountAnswers();

        //Question
        QuestionDTO GetQuestionById(int id);
        QuestionDTO GetQuestionByAnswreId();
        ICollection<QuestionDTO> GetQuestions();
        int CountQuestions();

        //Comment
        CommentDTO GetCommentById();
        ICollection<CommentDTO> GetComments();
        ICollection<CommentDTO> GetCommentsByPostId();
        int CountComments();

        //Tags
        TagsDTO GetTag(int id);
        ICollection<TagsDTO> GetTags();
        int CountTags();
 

        //PostTags
        ICollection<PostTagsDTO> GetPostTagsByPostId();
        int CountPostTags();


        //UserInfo

        UserInfoDTO GetUserByPostId();
        ICollection<PostDTO> GetAllPostsByUserId();
        ICollection<QuestionDTO> GetAllQuestionsByUserID();
        ICollection<AnswerDTO> GetAllAnswersByUserId();
        int CountOfUsers();
        int CountAnswersByUserId();
        int CountQuestionsByUserId();

        //Markings
        Boolean AddMarking(int postId);
        Boolean RemoveMarking(int id);

        //Annotations
        Boolean AddAnnotation();
        Boolean DeleteAnnotation(int id);
        Boolean EditAnnotation();
        AnnotationsDTO GetAnnotationById(int id);
        ICollection<AnnotationsDTO> GetAnnotations();
        int CountAnnotationsById();
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
        ICollection<FavoriteTagsDTO> GetFavoriteTags();
        int CountFavoriteTags();

        //UserCustomeField
        Boolean AddUserCustomeField();
        Boolean DeleteUserCustomeField(int id);
        UserCustomeFieldDTO GetUserCustomeFieldById(int id);
        ICollection<UserCustomeFieldDTO> GetUserCustomeFields();
        int CountUserCustomeFields();

      


    }
}

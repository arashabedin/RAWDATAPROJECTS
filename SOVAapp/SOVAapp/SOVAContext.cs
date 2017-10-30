using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataService.DomainModel;
namespace DataService
{

    public class SOVAContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<PostType> PostTypes { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<PostTags> PostTags { get; set; }
        public DbSet<SearchHistory> SearchHistory { get; set; }
        public DbSet<Annotations> Annotations { get; set; }
        public DbSet<FavoriteTags> FavoriteTags { get; set; }
        public DbSet<UserCustomeField> UserCustomeField { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("server=wt-220.ruc.dk;database=raw5;uid=raw5;pwd=raw5");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Table Posts
            modelBuilder.Entity<Post>().ToTable("posts");
            modelBuilder.Entity<Post>().Property(x => x.PostTypeId).HasColumnName("Posttypeid");
            modelBuilder.Entity<Post>().Property(x => x.Id).HasColumnName("Postid");
            modelBuilder.Entity<Post>().Property(x => x.ParentId).HasColumnName("ParentId");
            modelBuilder.Entity<Post>().Property(x => x.AcceptedAnswerId).HasColumnName("AcceptedAnswerId");
            modelBuilder.Entity<Post>().Property(x => x.LinkPostId).HasColumnName("LinkPostId");
            modelBuilder.Entity<Post>().Property(x => x.OwneruserId).HasColumnName("OwneruserId");
            modelBuilder.Entity<Post>().Property(x => x.Body).HasColumnName("Body");
            modelBuilder.Entity<Post>().Property(x => x.Score).HasColumnName("Score");
            modelBuilder.Entity<Post>().Property(x => x.CreationDate).HasColumnName("CreationDate");
            modelBuilder.Entity<Post>().Property(x => x.ClosedDate).HasColumnName("ClosedDate");

            // Table Comment
            modelBuilder.Entity<Comment>().ToTable("comments");
            modelBuilder.Entity<Comment>().Property(x => x.CommentId).HasColumnName("Commentid");
            modelBuilder.Entity<Comment>().Property(x => x.PostId).HasColumnName("Postid");
            modelBuilder.Entity<Comment>().Property(x => x.CommentText).HasColumnName("CommentText");
            modelBuilder.Entity<Comment>().Property(x => x.CommentScore).HasColumnName("CommentScore");
            modelBuilder.Entity<Comment>().Property(x => x.CommentCreateDate).HasColumnName("CommentCreateDate");
            modelBuilder.Entity<Comment>().Property(x => x.OwnerUserId).HasColumnName("OwneruserId");


            // Table UserInfo
            modelBuilder.Entity<UserInfo>().ToTable("userinfo");
            modelBuilder.Entity<UserInfo>().Property(x => x.Id).HasColumnName("Userinfoid");
            modelBuilder.Entity<UserInfo>().Property(x => x.OwnerUserAge).HasColumnName("OwnerUserAge");
            modelBuilder.Entity<UserInfo>().Property(x => x.OwnerUserDisplayName).HasColumnName("OwnerUserDisplayName");
            modelBuilder.Entity<UserInfo>().Property(x => x.OwnerUserLocation).HasColumnName("OwnerUserLocation");
            modelBuilder.Entity<UserInfo>().Property(x => x.CreationDate).HasColumnName("CreationDate");


            // Table Tags
            modelBuilder.Entity<Tags>().ToTable("tags");
            modelBuilder.Entity<Tags>().Property(x => x.Id).HasColumnName("Tagid");
            modelBuilder.Entity<Tags>().Property(x => x.Tag).HasColumnName("Tag");

            // Table PostTags
            modelBuilder.Entity<PostTags>().ToTable("posttags");
            modelBuilder.Entity<PostTags>().Property(x => x.PostId).HasColumnName("PostId");
            modelBuilder.Entity<PostTags>().Property(x => x.TagId).HasColumnName("TagId");

            // Table SearchHistory
            modelBuilder.Entity<SearchHistory>().ToTable("searchhistory");
            modelBuilder.Entity<SearchHistory>().Property(x => x.Id).HasColumnName("Id");
            modelBuilder.Entity<SearchHistory>().Property(x => x.SearchContent).HasColumnName("SearchContent");
            modelBuilder.Entity<SearchHistory>().Property(x => x.SearchDate).HasColumnName("SearchDate");


            // Table Marking
            modelBuilder.Entity<Marking>().ToTable("marking");
            modelBuilder.Entity<Marking>().Property(x => x.MarkedPostId).HasColumnName("MarkedPostId");
            modelBuilder.Entity<Marking>().Property(x => x.MarkingDate).HasColumnName("MarkingDate");

            // Table Annotation
            modelBuilder.Entity<Annotations>().ToTable("annotations");
            modelBuilder.Entity<Annotations>().Property(x => x.MarkedPostId).HasColumnName("MarkedPostId");
            modelBuilder.Entity<Annotations>().Property(x => x.Annotation).HasColumnName("annotation");


            // Table UserCustomeField
            modelBuilder.Entity<UserCustomeField>().ToTable("usercustomefield");
            modelBuilder.Entity<UserCustomeField>().Property(x => x.Id).HasColumnName("Id");
            modelBuilder.Entity<UserCustomeField>().Property(x => x.Postlimit).HasColumnName("PostLimit");
            modelBuilder.Entity<UserCustomeField>().Property(x => x.CreationDate).HasColumnName("CreationDate");


            // Table FavoriteTags
            modelBuilder.Entity<FavoriteTags>().ToTable("favoritetags");
            modelBuilder.Entity<FavoriteTags>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<FavoriteTags>().Property(x => x.User_CustomeField_Id).HasColumnName("User_CustomeField_Id");
            modelBuilder.Entity<FavoriteTags>().Property(x => x.TagId).HasColumnName("TagId");



            // Table PostType

            modelBuilder.Entity<PostType>().ToTable("posttypes");
            modelBuilder.Entity<PostType>().Property(x => x.Id).HasColumnName("Posttypeid");
            modelBuilder.Entity<PostType>().Property(x => x.Type).HasColumnName("posttype");



        }
    }
}

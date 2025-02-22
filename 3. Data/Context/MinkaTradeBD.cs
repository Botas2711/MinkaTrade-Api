﻿using _3._Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Context
{
    public class MinkaTradeBD : DbContext
    {
        public MinkaTradeBD() { }
        public MinkaTradeBD(DbContextOptions<MinkaTradeBD> options) : base(options) { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
                optionsBuilder.UseMySql("Server=localhost;Uid=root;Pwd=admin;Database=MinkaTradeBD;", serverVersion);
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Clients
            builder.Entity<Client>().ToTable("Clients");
            builder.Entity<Client>().HasKey(p => p.Id);
            builder.Entity<Client>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<Client>().Property(p => p.first_name)
                .IsRequired().HasMaxLength(80);
            builder.Entity<Client>().Property(p => p.last_name)
                .IsRequired().HasMaxLength(120);
            builder.Entity<Client>().Property(p => p.birthdate)
                .IsRequired();
            builder.Entity<Client>().Property(p => p.dni)
                .IsRequired().HasMaxLength(8);
            builder.Entity<Client>().Property(p => p.gender)
                .IsRequired().HasMaxLength(1);
            builder.Entity<Client>().Property(p => p.email)
                .IsRequired().HasMaxLength(150);
            builder.Entity<Client>().Property(p => p.phone_number)
                .IsRequired().HasMaxLength(9);
            builder.Entity<Client>().Property(p => p.hasPremiun).HasDefaultValue(false);

            //Category
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name)
                .IsRequired().HasMaxLength(50);

            //Post
            builder.Entity<Post>().ToTable("Posts");
            builder.Entity<Post>().HasKey(p => p.Id);
            builder.Entity<Post>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<Post>().Property(p => p.title)
                .IsRequired().HasMaxLength(100);
            builder.Entity<Post>().Property(p => p.price)
                .IsRequired().HasColumnType("decimal(18,2)");
            builder.Entity<Post>().Property(p => p.description)
                .IsRequired().HasMaxLength(200);
            builder.Entity<Post>().Property(p => p.status)
                .HasDefaultValue(true);
            builder.Entity<Post>().Property(p => p.created_date)
                .HasDefaultValue(DateTime.Now);

            //PostImage
            builder.Entity<PostImage>().ToTable("PostImages");
            builder.Entity<PostImage>().HasKey(p => p.Id);
            builder.Entity<PostImage>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<PostImage>().Property(p => p.Images)
                .IsRequired();

            //Relation
            builder.Entity<PostImage>().HasOne(pi => pi.Post).WithMany(p => p.PostImages)
                .HasForeignKey(pi => pi.PostId).OnDelete(DeleteBehavior.Cascade);


            //Review
            builder.Entity<Review>().ToTable("Reviews");
            builder.Entity<Review>().HasKey(p => p.Id);
            builder.Entity<Review>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<Review>().Property(p => p.description).IsRequired().HasMaxLength(200);
            builder.Entity<Review>().Property(p => p.rate).IsRequired();
            builder.Entity<Review>().Property(p => p.created_date).HasDefaultValue(DateTime.Now);

            //Relation
            builder.Entity<Review>().HasOne(m => m.SendBy).WithMany().HasForeignKey(m => m.SendById)
                .OnDelete(DeleteBehavior.Restrict);

            //Chat
            builder.Entity<Chat>().ToTable("Chats");
            builder.Entity<Chat>().HasKey(p => p.Id);
            builder.Entity<Chat>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<Chat>().Property(p => p.created_date).HasDefaultValue(DateTime.Now);

            //Relation
            builder.Entity<Chat>().HasOne(c => c.ClientOne).WithMany(c => c.ChatsAsSender)
                .HasForeignKey(c => c.ClientOneId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Chat>().HasOne(c => c.ClientTwo).WithMany(c => c.ChatsAsReceiver)
                .HasForeignKey(c => c.ClientTwoId).OnDelete(DeleteBehavior.Restrict);

            //Message
            builder.Entity<Message>().ToTable("Messages");
            builder.Entity<Message>().HasKey(p => p.Id);
            builder.Entity<Message>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<Message>().Property(p => p.content).IsRequired().HasMaxLength(200);
            builder.Entity<Message>().Property(p => p.created_date).HasDefaultValue(DateTime.Now);

            //Relation
            builder.Entity<Message>().HasOne(m => m.SendBy).WithMany().HasForeignKey(m => m.SendById)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Message>().HasOne(m => m.Chat).WithMany(c => c.Messages).HasForeignKey(m => m.ChatId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

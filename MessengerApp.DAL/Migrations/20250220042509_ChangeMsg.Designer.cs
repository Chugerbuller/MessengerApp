﻿// <auto-generated />
using System;
using MessengerApp.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MessengerApp.DAL.Migrations
{
    [DbContext(typeof(MessengerDbContext))]
    [Migration("20250220042509_ChangeMsg")]
    partial class ChangeMsg
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MessengerApp.Model.Chat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ChatName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("MessengerApp.Model.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MessageContent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("MessengerApp.Model.MessagesInChat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ChatId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("MessageId");

                    b.ToTable("MessagesInChat");
                });

            modelBuilder.Entity("MessengerApp.Model.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("MessengerApp.Model.PersonsInChat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ChatId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonsInChat");
                });

            modelBuilder.Entity("MessengerApp.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PersonID")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PersonID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MessengerApp.Model.Message", b =>
                {
                    b.HasOne("MessengerApp.Model.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MessengerApp.Model.MessagesInChat", b =>
                {
                    b.HasOne("MessengerApp.Model.Chat", "Chat")
                        .WithMany("MessagesInChats")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MessengerApp.Model.Message", "Message")
                        .WithMany("MessagesInChats")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("Message");
                });

            modelBuilder.Entity("MessengerApp.Model.PersonsInChat", b =>
                {
                    b.HasOne("MessengerApp.Model.Chat", "Chat")
                        .WithMany("PersonsInChat")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MessengerApp.Model.Person", "Person")
                        .WithMany("UsersInChat")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MessengerApp.Model.User", b =>
                {
                    b.HasOne("MessengerApp.Model.Person", "Person")
                        .WithMany("Users")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MessengerApp.Model.Chat", b =>
                {
                    b.Navigation("MessagesInChats");

                    b.Navigation("PersonsInChat");
                });

            modelBuilder.Entity("MessengerApp.Model.Message", b =>
                {
                    b.Navigation("MessagesInChats");
                });

            modelBuilder.Entity("MessengerApp.Model.Person", b =>
                {
                    b.Navigation("Users");

                    b.Navigation("UsersInChat");
                });
#pragma warning restore 612, 618
        }
    }
}

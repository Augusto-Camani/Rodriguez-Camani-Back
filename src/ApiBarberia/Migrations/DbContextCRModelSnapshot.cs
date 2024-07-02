﻿// <auto-generated />
using System;
using ApiBarberia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiBarberia.Migrations
{
    [DbContext(typeof(DbContextCR))]
    partial class DbContextCRModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("ApiBarberia.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BarberAvailabilityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BarberId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Service")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("AppointmentId");

                    b.HasIndex("BarberAvailabilityId");

                    b.HasIndex("BarberId");

                    b.HasIndex("ClientId");

                    b.ToTable("Appointments", (string)null);
                });

            modelBuilder.Entity("ApiBarberia.BarberAvailability", b =>
                {
                    b.Property<int>("BarberAvailabilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AvailabilityDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("BarberScheduleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DayOfTheWeek")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("BarberAvailabilityId");

                    b.HasIndex("BarberScheduleId");

                    b.ToTable("BarberAvailabilities", (string)null);
                });

            modelBuilder.Entity("ApiBarberia.BarberSchedule", b =>
                {
                    b.Property<int>("BarberScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BarberId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentYear")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("BarberScheduleId");

                    b.HasIndex("BarberId");

                    b.ToTable("BarberShcedules", (string)null);
                });

            modelBuilder.Entity("ApiBarberia.Reply", b =>
                {
                    b.Property<int>("ReplyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Response")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ReviewId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ReplyId");

                    b.HasIndex("ReviewId")
                        .IsUnique();

                    b.ToTable("Replies");
                });

            modelBuilder.Entity("ApiBarberia.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppointmentId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Rating")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ReviewId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews", (string)null);
                });

            modelBuilder.Entity("ApiBarberia.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserType")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasDiscriminator<int>("UserType");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ApiBarberia.Admin", b =>
                {
                    b.HasBaseType("ApiBarberia.User");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("ApiBarberia.Barber", b =>
                {
                    b.HasBaseType("ApiBarberia.User");

                    b.Property<int>("Specialties")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("ApiBarberia.Client", b =>
                {
                    b.HasBaseType("ApiBarberia.User");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("ApiBarberia.Appointment", b =>
                {
                    b.HasOne("ApiBarberia.Review", "Review")
                        .WithOne("Appointment")
                        .HasForeignKey("ApiBarberia.Appointment", "AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiBarberia.BarberAvailability", "BarberAvailability")
                        .WithMany()
                        .HasForeignKey("BarberAvailabilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiBarberia.Barber", "Barber")
                        .WithMany("Appointments")
                        .HasForeignKey("BarberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiBarberia.Client", "Client")
                        .WithMany("Appointments")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barber");

                    b.Navigation("BarberAvailability");

                    b.Navigation("Client");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("ApiBarberia.BarberAvailability", b =>
                {
                    b.HasOne("ApiBarberia.BarberSchedule", "BarberSchedule")
                        .WithMany("AvailabilitySlots")
                        .HasForeignKey("BarberScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BarberSchedule");
                });

            modelBuilder.Entity("ApiBarberia.BarberSchedule", b =>
                {
                    b.HasOne("ApiBarberia.Barber", "Barber")
                        .WithMany()
                        .HasForeignKey("BarberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barber");
                });

            modelBuilder.Entity("ApiBarberia.Reply", b =>
                {
                    b.HasOne("ApiBarberia.Review", "Review")
                        .WithOne("Reply")
                        .HasForeignKey("ApiBarberia.Reply", "ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Review");
                });

            modelBuilder.Entity("ApiBarberia.Review", b =>
                {
                    b.HasOne("ApiBarberia.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApiBarberia.BarberSchedule", b =>
                {
                    b.Navigation("AvailabilitySlots");
                });

            modelBuilder.Entity("ApiBarberia.Review", b =>
                {
                    b.Navigation("Appointment")
                        .IsRequired();

                    b.Navigation("Reply")
                        .IsRequired();
                });

            modelBuilder.Entity("ApiBarberia.Barber", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("ApiBarberia.Client", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}

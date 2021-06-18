﻿using System;
using System.Net;
using System.Threading.Tasks;
using backend_api.Data.Notification;
using backend_api.Exceptions.Auth;
using backend_api.Exceptions.Notifications;
using backend_api.Models.Notification;
using backend_api.Models.Notification.Requests;
using backend_api.Models.Notification.Responses;
using backend_api.Services.Notification;
using Moq;
using Xunit;

namespace backend_api.Tests.NotificationTests.UnitTests
{
    public class NotificationServiceTests
    {
        private readonly NotificationService _sut;
        private readonly Mock<INotificationRepository> _notificationRepoMock = new Mock<INotificationRepository>();
        private readonly DateTime _mockedDate;
        
        public NotificationServiceTests()
        {
            // Mocks the implementation of Notification repository
            _sut = new NotificationService(_notificationRepoMock.Object);
            
            _mockedDate = new DateTime();
        }
        
        [Fact]
        public async Task CreateNotification_ShouldReturnCreatedStatusCodeAsync()
        {
            // Arrange
            var requestDto = new CreateNotificationRequest(
                    "Notification Test",
                    NotificationTypeEnum.Email,
                    this._mockedDate,
                    1
                );
            var responseDto = new CreateNotificationResponse(HttpStatusCode.Created);
            
            _notificationRepoMock.Setup(n => n.CreateNotification(requestDto)).ReturnsAsync(responseDto);
            
            // Act
            var createdNotification = await _sut.CreateNotification(requestDto);
            
            // Assert
            Assert.Equal(responseDto, createdNotification);
        }
        
        
        [Fact]
        public async Task CreateNotification_ShouldThrowExceptionWhenPayloadIsEmptyAsync()
        {
            // Arrange
            var requestDto = new CreateNotificationRequest(
                "",
                NotificationTypeEnum.Email,
                this._mockedDate,
                1
            );

            // Act
            var exception = await Assert.ThrowsAsync<InvalidNotificationRequestException>(() => _sut.CreateNotification(requestDto));
            
            // Assert
            Assert.Equal("Payload cannot be null or empty", exception.Message);
        } 
        
        [Fact]
        public async Task CreateNotification_ShouldThrowExceptionWhenPayloadIsNullAsync()
        {
            // Arrange
            var requestDto = new CreateNotificationRequest(
                null,
                NotificationTypeEnum.Email,
                this._mockedDate,
                1
            );

            // Act
            var exception = await Assert.ThrowsAsync<InvalidNotificationRequestException>(() => _sut.CreateNotification(requestDto));
            
            // Assert
            Assert.Equal("Payload cannot be null or empty", exception.Message);
        }
        
        [Fact]
        public async Task CreateNotification_ShouldThrowExceptionWhenUserIdIsZeroAsync()
        {
            // Arrange
            var requestDto = new CreateNotificationRequest(
                "Notification Test",
                NotificationTypeEnum.Email,
                this._mockedDate,
                0
                );

            // Act
            var exception = await Assert.ThrowsAsync<InvalidNotificationRequestException>(() => _sut.CreateNotification(requestDto));
            
            // Assert
            Assert.Equal("UserID is invalid", exception.Message);
        }
        
        [Fact]
        public async Task CreateNotification_ShouldThrowExceptionWhenUserIdIsLessThanZeroAsync()
        {
            // Arrange
            var requestDto = new CreateNotificationRequest(
                "Notification Test",
                NotificationTypeEnum.Email,
                this._mockedDate,
                -1
            );

            // Act
            var exception = await Assert.ThrowsAsync<InvalidNotificationRequestException>(() => _sut.CreateNotification(requestDto));
            
            // Assert
            Assert.Equal("UserID is invalid", exception.Message);
        } 
    }
}
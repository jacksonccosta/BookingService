using NUnit.Framework;
using Domain.Entities;
using Domain.Enums;
using Action = Domain.Enums.Action;

namespace DomainTests.Bookings;

public class StateMachineTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ShouldAlwaysStartWithCreatedStatus()
    {
        var booking = new Booking();

        Assert.AreEqual(booking.CurrentStatus, Status.Created);
    }

    [Test]
    public void ShouldSetStatusToPaidWhenPayingForBookingWithCreatedStatus()
    {
        var booking = new Booking();

        booking.ChangeState(Action.Pay);

        Assert.AreEqual(booking.CurrentStatus, Status.Paid);
    }

    [Test]
    public void ShouldSetStatusToFinishedWhenFinishingBookingWithPaidStatus()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Pay);
        booking.ChangeState(Action.Finish);
        Assert.AreEqual(booking.CurrentStatus, Status.Finished);
    }

    [Test]
    public void ShouldSetStatusToRefoundedWhenRefoundingBookingWithPaidStatus()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Pay);
        booking.ChangeState(Action.Refound);
        Assert.AreEqual(booking.CurrentStatus, Status.Refounded);
    }

    [Test]
    public void ShouldSetStatusToCanceledWhenCancelingBookingWithCreatedStatus()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Cancel);
        Assert.AreEqual(booking.CurrentStatus, Status.Canceled);
    }

    [Test]
    public void ShouldSetStatusToCreatedWhenReopeningBookingWithCanceledStatus()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Cancel);
        booking.ChangeState(Action.Reopen);
        Assert.AreEqual(booking.CurrentStatus, Status.Created);
    }

    [Test]
    public void ShouldNotChangeStatusWhenPerformingInvalidAction()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Finish);
        Assert.AreEqual(booking.CurrentStatus, Status.Created);
    }

    [Test]
    public void ShouldNotChangeStatusWhenPerformingAnotherInvalidAction()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Pay);
        booking.ChangeState(Action.Cancel);
        Assert.AreEqual(booking.CurrentStatus, Status.Paid);
    }

    [Test]
    public void ShouldNotChangeStatusWhenPerformingYetAnotherInvalidAction()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Pay);
        booking.ChangeState(Action.Finish);
        booking.ChangeState(Action.Reopen);
        Assert.AreEqual(booking.CurrentStatus, Status.Finished);
    }

    [Test]
    public void ShouldNotChangeStatusWhenPerformingOneMoreInvalidAction()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Cancel);
        booking.ChangeState(Action.Refound);
        Assert.AreEqual(booking.CurrentStatus, Status.Canceled);
    }

    [Test]
    public void ShouldNotChangeStatusWhenPerformingLastInvalidAction()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Cancel);
        booking.ChangeState(Action.Reopen);
        booking.ChangeState(Action.Refound);
        Assert.AreEqual(booking.CurrentStatus, Status.Created);
    }

    [Test]
    public async Task ShouldHandleMultipleValidStateTransitions()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Pay);
        Assert.AreEqual(booking.CurrentStatus, Status.Paid);
        booking.ChangeState(Action.Finish);
        Assert.AreEqual(booking.CurrentStatus, Status.Finished);
        // Reset to Created
        booking = new Booking();
        booking.ChangeState(Action.Cancel);
        Assert.AreEqual(booking.CurrentStatus, Status.Canceled);
        booking.ChangeState(Action.Reopen);
        Assert.AreEqual(booking.CurrentStatus, Status.Created);
        booking.ChangeState(Action.Pay);
        Assert.AreEqual(booking.CurrentStatus, Status.Paid);
        booking.ChangeState(Action.Refound);
        Assert.AreEqual(booking.CurrentStatus, Status.Refounded);
    }

    [Test]
    public async Task ShouldHandleMultipleInvalidStateTransitions()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Finish);
        Assert.AreEqual(booking.CurrentStatus, Status.Created);
        booking.ChangeState(Action.Refound);
        Assert.AreEqual(booking.CurrentStatus, Status.Created);
        booking.ChangeState(Action.Reopen);
        Assert.AreEqual(booking.CurrentStatus, Status.Created);
        booking.ChangeState(Action.Cancel);
        Assert.AreEqual(booking.CurrentStatus, Status.Canceled);
        booking.ChangeState(Action.Finish);
        Assert.AreEqual(booking.CurrentStatus, Status.Canceled);
        booking.ChangeState(Action.Pay);
        Assert.AreEqual(booking.CurrentStatus, Status.Canceled);
    }

    [Test]
    public async Task ShouldHandleMixedValidAndInvalidStateTransitions()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Pay);
        Assert.AreEqual(booking.CurrentStatus, Status.Paid);
        booking.ChangeState(Action.Cancel);
        Assert.AreEqual(booking.CurrentStatus, Status.Paid);
        booking.ChangeState(Action.Finish);
        Assert.AreEqual(booking.CurrentStatus, Status.Finished);
        booking.ChangeState(Action.Reopen);
        Assert.AreEqual(booking.CurrentStatus, Status.Finished);
        // Reset to Created
        booking = new Booking();
        booking.ChangeState(Action.Cancel);
        Assert.AreEqual(booking.CurrentStatus, Status.Canceled);
        booking.ChangeState(Action.Reopen);
        Assert.AreEqual(booking.CurrentStatus, Status.Created);
        booking.ChangeState(Action.Refound);
        Assert.AreEqual(booking.CurrentStatus, Status.Created);
        booking.ChangeState(Action.Pay);
        Assert.AreEqual(booking.CurrentStatus, Status.Paid);
        booking.ChangeState(Action.Refound);
        Assert.AreEqual(booking.CurrentStatus, Status.Refounded);
    }
}

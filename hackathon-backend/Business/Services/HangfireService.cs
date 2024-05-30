using Business.HangfireJobs;

namespace Business.Services;
using System;
using Hangfire;
public class HangfireService
{
    public static void ScheduleRecurringJobs(IServiceProvider serviceProvider)
    {
        RecurringJob.AddOrUpdate<NotificationReminderJob>("aaa",job => job.SendNotifications() ,Cron.Hourly(0));
    }
}
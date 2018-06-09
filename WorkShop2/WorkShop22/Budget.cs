﻿using System;
using WorkShop22;

namespace WorkShop2.Tests
{
    public class Budget
    {
        public int Amount { get; set; }
        public string YearMonth { get; set; }

        private int DaysInMonth
        {
            get
            {
                return DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);
            }
        }

        public DateTime FirstDay
        {
            get
            {
                return DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null);
            }
        }

        public DateTime LastDay
        {
            get { return DateTime.ParseExact(YearMonth + DaysInMonth, "yyyyMMdd", null); }
        }

        public int DailyAmount()
        {
            return Amount / DaysInMonth;
        }

        public Period PeriodFromBudget()
        {
            var periodFromBudget = new Period(FirstDay, LastDay);
            return periodFromBudget;
        }

        public int OverlappingAmount(Period period)
        {
            return period.OverlappingDays(PeriodFromBudget()) * DailyAmount();
        }
    }
}
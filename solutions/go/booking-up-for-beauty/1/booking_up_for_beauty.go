package booking

import (
    "time"
	"fmt"
)

func Schedule(date string) time.Time {
    t, _:= time.Parse("1/02/2006 15:04:05", date)

    return t
}

func HasPassed(date string) bool {
	now := time.Now()
	
    scheduledDate, _ := time.Parse("January 2, 2006 15:04:05", date)
    
    return now.After(scheduledDate)
}

func IsAfternoonAppointment(date string) bool {
	scheduledDate, _ := time.Parse("Monday, January 2, 2006 15:04:05", date)
    
    return scheduledDate.Hour() >= 12 && scheduledDate.Hour() < 19
     
}

func Description(date string) string {
    t, _ := time.Parse("1/2/2006 15:04:05" , date)
    
    return fmt.Sprintf("You have an appointment on %v, %v %v, %v, at %v:%v.", t.Weekday(), t.Month(), t.Day(), t.Year(), t.Hour(), t.Minute())
}

// AnniversaryDate returns a Time with this year's anniversary.
func AnniversaryDate() time.Time {
	 year := time.Now().Year()
     
     anniversaryDate := fmt.Sprintf("09/15/%v 00:00:00", year)

     return Schedule(anniversaryDate)
    
}

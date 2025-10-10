package expenses
import "errors"

type Record struct {
	Day      int
	Amount   float64
	Category string
}

type DaysPeriod struct {
	From int
	To   int
}

func Filter(in []Record, predicate func(Record) bool) []Record {
    newRecord := make([]Record, 0)
    
	for _, record := range in{
        if predicate(record) {
            newRecord = append(newRecord, record)
        }
    }
    
    return newRecord
    }

func ByDaysPeriod(p DaysPeriod) func(Record) bool {
	return func(r Record) bool {
        if r.Day < p.From || r.Day > p.To {
            return false
        }
        
        return true
    }
}

func ByCategory(c string) func(Record) bool {
	return func(r Record) bool {
        return c == r.Category
    }
}

func TotalByPeriod(in []Record, p DaysPeriod) float64 {
    var count float64
	
    records := Filter(in, ByDaysPeriod(p))

    for _, record := range records{
        count += (record.Amount)
    }
    
	return count
}

func CategoryExpenses(in []Record, p DaysPeriod, c string) (float64, error) {
    recordsByCategory := Filter(in, ByCategory(c))
	
    if len(recordsByCategory) == 0 {
        return 0, errors.New("unknown category entertainment")
    }
    
	return TotalByPeriod(recordsByCategory, p), nil
}

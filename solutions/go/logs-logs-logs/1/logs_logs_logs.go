package logs
import "unicode/utf8"

// Application identifies the application emitting the given log.
func Application(log string) string {
    for _, c := range log {
        switch c {
            case '❗':
            	 return "recommendation"
            case '🔍':
            	 return "search"
            case '☀':
            	 return "weather"
        }
    }
    
    return "default"
}

func Replace(log string, oldRune, newRune rune) string {
    newLog := ""
    
	for _, c := range log {
        if c == oldRune{
            c = newRune
            newLog += string(c)
            continue
        }
        newLog += string(c)
    }

    return newLog
}

func WithinLimit(log string, limit int) bool {
	numberOfRunes := utf8.RuneCountInString(log)

    return numberOfRunes <= limit
}

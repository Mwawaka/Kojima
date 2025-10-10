package parsinglogfiles
import "regexp"
import "fmt"

func IsValidLine(text string) bool {
	// reg, err := regexp.Compile(`^\[[A-Z]{3}\]`)
    reg := regexp.MustCompile(`^\[(TRC|DBG|INF|WRN|ERR|FTL)\]`)

    return reg.MatchString(text)
}

func SplitLogLine(text string) []string {
    reg := regexp.MustCompile(`<(~|\*|=|-)*>`)

    return reg.Split(text, -1)
}

func CountQuotedPasswords(lines []string) int {
    count := 0
	reg := regexp.MustCompile(`"(?i)[^"]*password[^"]*"`)

    for _, line := range lines{
        if reg.MatchString(line){
            fmt.Println(line)
            
            count ++
        }
    }
    
    return count
}

func RemoveEndOfLineText(text string) string {
    reg := regexp.MustCompile(`end-of-line\d+`)
    
	return reg.ReplaceAllString(text, "")
}

func TagWithUserName(lines []string) []string {
    var tagSlice []string = make([]string, len(lines))
    
    reg := regexp.MustCompile(`User\s+([^\s]+)`)
    
    for i, line := range lines{
       matches := reg.FindStringSubmatch(line)
       
       if len(matches) > 1{
          tagSlice[i] = fmt.Sprintf("[USR] %v %v", matches[1], line)
       }else{
           tagSlice[i] = line
       }
    }
    
    return tagSlice
}

package isogram
import "strings"

func IsIsogram(w string) bool {
	word := clean(strings.ToUpper(w))
    
	for i := 0; i < len(word); i++{
        for j := i+1; j < len(word); j++{
            if word[j] == word[i]{
                return false
            }
        }
    }
    return true
}

func clean(s string) string {
	var cleaned string

    for _, r := range s{
        if r >= 'A' && r <= 'Z'{
            cleaned += string(r)
        }
    }

    return cleaned
}
package isogram
import (
		"strings"
    	"unicode"
    	"fmt"
)


func IsIsogram(word string) bool {
  	s := strings.ToUpper(word)
	fmt.Print(s)

    for i, c := range s {
        if unicode.IsLetter(c) && strings.ContainsRune(s[i + 1 : ], c){
            return false
        }
    }
    return true
}


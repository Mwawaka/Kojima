package hamming
import "errors"

func Distance(a, b string) (int, error) {
	hammingDistance := 0

    if len(a) != len(b){
        return 0, errors.New("the length of dna strands are not equal")
    }
    for indx, strand := range a {
        if strand != rune(b[indx]) {
            hammingDistance ++
        }
    }

    return hammingDistance, nil
}

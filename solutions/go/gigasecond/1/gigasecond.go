package gigasecond

import "time"

const gigaSecond int64 = 1000000000

func AddGigasecond(t time.Time) time.Time {
    seconds := t.Unix() + gigaSecond
    
    t = time.Unix(seconds, 0)

	return t
}

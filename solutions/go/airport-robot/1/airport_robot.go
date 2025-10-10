package airportrobot

type Greeter interface{
    LanguageName() string
    Greet(name string) string
}

type  Italian struct{}    
type  Portuguese struct{} 

func (i Italian) LanguageName() string{
    return "Italian"
}

func (i Italian) Greet(name string) string{
    return "Ciao " + name + "!"
}

func (p Portuguese) LanguageName() string{
    return "Portuguese"
}

func (p Portuguese) Greet(name string) string{
    return "Olá " + name + "!"
}

func SayHello(name string, greeter Greeter) string{
    return "I can speak " + greeter.LanguageName() + ": " + greeter.Greet(name)
}
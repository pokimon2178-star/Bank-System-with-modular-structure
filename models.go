package main

type Client struct {
	Name     string
	Age      int
	Contact  string
	Password string
	Accounts []string
}

type Bank struct {
	Clients map[string]*Client
}

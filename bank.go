package main

import "fmt"

func (b *Bank) Register(name string, age int, contact string, pass string) {
	if b.Clients == nil {
		b.Clients = make(map[string]*Client)
	}

	if _, exists := b.Clients[name]; exists {
		fmt.Println("[!] Ошибка: Пользователь с таким именем уже есть.")
		return
	}

	b.Clients[name] = &Client{
		Name:     name,
		Age:      age,
		Contact:  contact,
		Password: pass,
	}
	fmt.Println("[+] Регистрация прошла успешно!")
}

func (b *Bank) OpenAccount(name string) {
	client, exists := b.Clients[name]
	if !exists {
		fmt.Println("[!] Ошибка: Сначала нужно зарегистрировать клиента.")
		return
	}

	newAcc := fmt.Sprintf("ACC-%d", len(client.Accounts)+101)
	client.Accounts = append(client.Accounts, newAcc)
	fmt.Printf("[+] Открыт счет %s для %s\n", newAcc, name)
}

func (b *Bank) Authenticate(name string, pass string) bool {
	client, exists := b.Clients[name]
	if !exists || client.Password != pass {
		fmt.Println("[x] Ошибка: Неверное имя или пароль.")
		return false
	}
	fmt.Printf("[v] Вход выполнен! Добро пожаловать, %s.\n", name)
	return true
}

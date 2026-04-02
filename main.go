package main

import (
	"fmt"
)

func main() {
	// Инициализируем банк
	bank := Bank{Clients: make(map[string]*Client)}
	var choice int

	fmt.Println("=== КОНСОЛЬНЫЙ БАНК v1.0 ===")

	for {
		fmt.Println("\n--- ГЛАВНОЕ МЕНЮ ---")
		fmt.Println("1. Регистрация клиента")
		fmt.Println("2. Открыть новый счет")
		fmt.Println("3. Вход в систему")
		fmt.Println("4. Проверка суммы (Финмониторинг)")
		fmt.Println("0. Выход")
		fmt.Print("Выберите действие: ")

		fmt.Scanln(&choice)

		if choice == 0 {
			fmt.Println("Программа завершена.")
			break
		}

		switch choice {
		case 1:
			var n, c, p string
			var a int
			fmt.Print("Имя: ")
			fmt.Scanln(&n)
			fmt.Print("Возраст: ")
			fmt.Scanln(&a)
			fmt.Print("Контакты: ")
			fmt.Scanln(&c)
			fmt.Print("Пароль: ")
			fmt.Scanln(&p)
			bank.Register(n, a, c, p)

		case 2:
			var n string
			fmt.Print("Имя клиента: ")
			fmt.Scanln(&n)
			bank.OpenAccount(n)

		case 3:
			var n, p string
			fmt.Print("Имя: ")
			fmt.Scanln(&n)
			fmt.Print("Пароль: ")
			fmt.Scanln(&p)
			bank.Authenticate(n, p)

		case 4:
			var sum float64
			fmt.Print("Введите сумму для проверки: ")
			fmt.Scanln(&sum)
			if sum > 100000 {
				fmt.Println("[ALARM] Внимание! Сумма превышает лимит мониторинга.")
			} else {
				fmt.Println("[OK] Сумма проверена, замечаний нет.")
			}

		default:
			fmt.Println("[!] Неверный ввод, попробуйте еще раз.")
		}
	}
}

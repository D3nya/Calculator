# Calculator — Web API & Frontend

Полноценное web-приложение «Калькулятор» с разделением на backend (ASP.NET Core Web API) и frontend (React + Vite + Tailwind + shadcn/ui).

Поддерживает вычисление простых арифметических операций и сложных выражений с приоритетами.

---

## Структура проекта

- **backend** — серверная часть на ASP.NET Core Web API
  - `Calculator.API` — основной API-проект
    - `Controllers/CalculatorController.cs` — все арифметические эндпоинты
    - `Filters/` — фильтры логирования и измерения времени
    - `Middlewares/` — глобальная обработка ошибок
    - `Models/` — модели запросов
    - `Program.cs` — конфигурация приложения, CORS, Swagger
  - `Calculator.Domain` — бизнес-логика, use case, исключения
  - `Calculator.Services` — сервисы для вычислений
  - `Calculator.Domain.DependencyInjection`, `Calculator.Services.DependencyInjection` — DI-расширения
- **frontend** — клиентская часть на React
  - `src/pages/` — страницы калькулятора (по операциям)
  - `src/components/` — UI-компоненты (sidebar, header, формы, кнопки и др.)
  - `src/api/` — функции для работы с API
  - `src/hooks/` — хуки (например, для темы)
  - `src/lib/` — утилиты

---

## Возможности

### Backend

- Четыре базовые операции: сложение, вычитание, умножение, деление
- Возведение в степень
- Извлечение корня по основанию
- Вычисление строкового выражения: `5 + 6 * 4^(4 / 2)`
- Обработка ошибок (валидация, деление на ноль, некорректный ввод и др.)
- Swagger-документация (`/swagger`)
- Фильтры: логирование, измерение времени выполнения
- Middleware: глобальная обработка ошибок
- CORS (разрешён frontend на `http://localhost:5173`)

#### API эндпоинты

Все запросы — POST, Content-Type: application/json

- `/calculator/sum` { a, b }
- `/calculator/subtract` { a, b }
- `/calculator/multiply` { a, b }
- `/calculator/divide` { a, b }
- `/calculator/pow` { a, b }
- `/calculator/sqrt` { a, b } (a — число, b — основание)
- `/calculator/expression` { expression: string }

Ответ: число или объект ошибки (ProblemDetails)

### Frontend

- SPA на React + Vite
- Ввод выражения и чисел пользователем
- Отображение результата и ошибок
- UI на TailwindCSS и shadcn/ui
- Валидация форм через Zod и React Hook Form
- Поддержка светлой/тёмной темы

---

## Установка и запуск

### Backend

```bash
cd backend
# Восстановить зависимости
 dotnet restore
# Запустить сервер
 dotnet run
```

API будет доступен по адресу: `https://localhost:5280`

### Frontend

```bash
cd frontend
# Установить зависимости (npm или pnpm)
npm install
# Запустить dev-сервер
npm run dev
```

Приложение будет доступно по адресу: `http://localhost:5173`

> В .env или через переменную окружения укажите:
> `VITE_API_BASE_URL=https://localhost:5280`

---

## Технологии

- **Backend**: ASP.NET Core, C#, FluentValidation, Swagger
- **Frontend**: React, Vite, TypeScript, TailwindCSS, shadcn/ui, React Hook Form, Zod, Radix UI, React Query

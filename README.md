# Calculator API & Frontend

Полноценное web-приложение "Калькулятор" с разделением на backend (ASP.NET Core Web API) и frontend (React).

Поддерживает вычисление как простых арифметических операций, так и сложных строк-выражений с приоритетами операций.

---

## Структура проекта

- backend - ASP.NET Core Web API
- frontend - React + Vite + Tailwind + shadcn/ui

---

## Возможности

### Backend

- Четыре базовы операции: сложение, вычитание, умножение, деление
- Возведение в степень
- Извлечение корня по основанию
- Вычисление строкового выражения: `5 + 6 * 4^(4 / 2)`
- Обработка ошибок (ошибки валидации, деление на ноль, некорректный ввод и др.)
- Swagger-документация
- Фильтры и middleware (логгирование, измерение времени, глобальная обработка ошибок)

### Frontend

- Ввод выражения пользователем
- Отображение результата и ошибок
- UI с TailwindCSS и shadcn/ui

---

## Установка и запуск

### Backend

```bash
cd backend
dotnet restore
dotnet run
```

API будет доступен по адресу: `https://localhost:5280`

### 🌐 Frontend

```bash
cd frontend
npm install
npm run dev
```

Приложение будет доступно по адресу: `http://localhost:5173`

> В `frontend` используется `fetch` к `http://localhost:5280/calculator/expression`. Убедитесь, что backend запущен.
